function(generate_export_header_template exportTargetName outputFile)
	string(TOUPPER "${exportTargetName}" uppercaseTargetName)
	set(sharedLibDefLine "#cmakedefine ${uppercaseTargetName}_SHARED_LIBRARY")
	configure_file("${CMAKE_SOURCE_DIR}/cmake/export_header_template.in" "${outputFile}")
endfunction()

macro(create_library_target)
	set(options "")
	set(oneValueArgs TARGET TYPE INSTALL_PREFIX EXPORT_HEADER)
	set(multiValueArgs SOURCES)
	cmake_parse_arguments(LIBTARGET "${options}" "${oneValueArgs}" "${multiValueArgs}" ${ARGN})

	string(TOUPPER "${LIBTARGET_TARGET}" uppercaseTargetName)

	set(${uppercaseTargetName}_SHARED_LIBRARY YES)
	set(targetNameSuffix "")
	set(generatedHeaderDir "generated_headers_shared")

	if("${LIBTARGET_TYPE}" STREQUAL "STATIC")
		set(${uppercaseTargetName}_SHARED_LIBRARY NO)
		set(targetNameSuffix "_Static")
		set(generatedHeaderDir "generated_headers_static")
	endif()

	set(fullTargetName "${LIBTARGET_TARGET}${targetNameSuffix}")
	message(STATUS "Creating library target: ${fullTargetName}")

	# Generate an export header for this target, in a generated header directory
	# that corresponds to whether we're building a shared or static library.
	configure_file(${CMAKE_CURRENT_BINARY_DIR}/${LIBTARGET_EXPORT_HEADER}.in ${CMAKE_CURRENT_BINARY_DIR}/${generatedHeaderDir}/${LIBTARGET_EXPORT_HEADER})

	# Create the library target itself.
	add_library(${fullTargetName} ${LIBTARGET_TYPE}
		${LIBTARGET_SOURCES}
		"${CMAKE_CURRENT_BINARY_DIR}/${generatedHeaderDir}/${LIBTARGET_EXPORT_HEADER}"
	)

	# Add the appropriate include directories.
	target_include_directories(${fullTargetName}
		PUBLIC
		include
		"${CMAKE_CURRENT_BINARY_DIR}/${generatedHeaderDir}"

		PRIVATE
		src
	)

	# Set the compiled binaries to install to the correct location.
	install(TARGETS ${fullTargetName}
		ARCHIVE DESTINATION "${LIBTARGET_INSTALL_PREFIX}/${fullTargetName}/lib"
		LIBRARY DESTINATION "${LIBTARGET_INSTALL_PREFIX}/${fullTargetName}/lib"
		RUNTIME DESTINATION "${LIBTARGET_INSTALL_PREFIX}/${fullTargetName}/bin"
	)

	# Install all public headers too.
	install(DIRECTORY include DESTINATION "${LIBTARGET_INSTALL_PREFIX}/${fullTargetName}")

	# Also install the export header.
	install(
		FILES "${CMAKE_CURRENT_BINARY_DIR}/${generatedHeaderDir}/${LIBTARGET_EXPORT_HEADER}"
		DESTINATION "${LIBTARGET_INSTALL_PREFIX}/${fullTargetName}/include")
endmacro()
