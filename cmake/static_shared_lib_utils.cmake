function(generate_export_header_template exportTargetName outputFile)
	string(TOUPPER "${exportTargetName}" uppercaseTargetName)
	set(sharedLibDefLine "#cmakedefine ${uppercaseTargetName}_SHARED_LIBRARY")
	configure_file("${CMAKE_SOURCE_DIR}/cmake/export_header_template.in" "${outputFile}")
endfunction()

macro(create_library_target)
	set(options "")
	set(oneValueArgs TARGET TYPE INSTALL_PREFIX EXPORT_HEADER)
	set(multiValueArgs SOURCES LIBS)
	cmake_parse_arguments(LIBTARGET "${options}" "${oneValueArgs}" "${multiValueArgs}" ${ARGN})

	string(TOUPPER "${LIBTARGET_TARGET}" uppercaseTargetName)

	if("${LIBTARGET_TYPE}" STREQUAL "STATIC")
		# Strip the "_STATIC" from the end of the name.
		string(REGEX REPLACE "_STATIC$" "" uppercaseTargetName "${uppercaseTargetName}")
	endif()

	set(${uppercaseTargetName}_SHARED_LIBRARY YES)
	set(generatedHeaderDir "generated_headers_shared")

	if("${LIBTARGET_TYPE}" STREQUAL "STATIC")
		set(${uppercaseTargetName}_SHARED_LIBRARY NO)
		set(generatedHeaderDir "generated_headers_static")
	endif()

	message(STATUS "Creating library target: ${LIBTARGET_TARGET} (${uppercaseTargetName})")

	# Generate an export header for this target, in a generated header directory
	# that corresponds to whether we're building a shared or static library.
	configure_file(${CMAKE_CURRENT_BINARY_DIR}/${LIBTARGET_EXPORT_HEADER}.in ${CMAKE_CURRENT_BINARY_DIR}/${generatedHeaderDir}/${LIBTARGET_EXPORT_HEADER})

	# Create the library target itself.
	add_library(${LIBTARGET_TARGET} ${LIBTARGET_TYPE}
		${LIBTARGET_SOURCES}
		"${CMAKE_CURRENT_BINARY_DIR}/${generatedHeaderDir}/${LIBTARGET_EXPORT_HEADER}"
	)

	# Add the appropriate include directories.
	target_include_directories(${LIBTARGET_TARGET}
		PUBLIC
		include
		"${CMAKE_CURRENT_BINARY_DIR}/${generatedHeaderDir}"

		PRIVATE
		src
	)

	# Add dependent libraries.
	target_link_libraries(${LIBTARGET_TARGET} ${LIBS})

	if("${LIBTARGET_TYPE}" STREQUAL "SHARED")
		# Add a private definition to say that this library is being built rather than used.
		target_compile_definitions(${LIBTARGET_TARGET} PRIVATE
			-D${uppercaseTargetName}_PRODUCER
		)
	endif()

	# Set the compiled binaries to install to the correct location.
	install(TARGETS ${LIBTARGET_TARGET}
		ARCHIVE DESTINATION "${LIBTARGET_INSTALL_PREFIX}/${LIBTARGET_TARGET}/lib"
		LIBRARY DESTINATION "${LIBTARGET_INSTALL_PREFIX}/${LIBTARGET_TARGET}/lib"
		RUNTIME DESTINATION "${LIBTARGET_INSTALL_PREFIX}/${LIBTARGET_TARGET}/bin"
	)

	# Install all public headers too.
	install(DIRECTORY include DESTINATION "${LIBTARGET_INSTALL_PREFIX}/${LIBTARGET_TARGET}")

	# Also install the export header.
	install(
		FILES "${CMAKE_CURRENT_BINARY_DIR}/${generatedHeaderDir}/${LIBTARGET_EXPORT_HEADER}"
		DESTINATION "${LIBTARGET_INSTALL_PREFIX}/${LIBTARGET_TARGET}/include")
endmacro()
