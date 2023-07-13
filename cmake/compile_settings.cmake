function(set_basic_library_compiler_settings targetname)
	if(NOT CMAKE_CXX_COMPILER_ID STREQUAL "MSVC")
		target_compile_options(${targetname} PRIVATE
			-fvisibility=hidden
		)

		target_link_options(${targetname} PRIVATE
			-Wl,--no-undefined
		)
	endif()
endfunction()

function(set_pedantic_library_compiler_settings targetname)
	if(NOT CMAKE_CXX_COMPILER_ID STREQUAL "MSVC")
		target_compile_options(${targetname} PRIVATE
			-Wall
			-Wextra
			-pedantic
			-Werror
		)

		target_link_options(${targetname} PRIVATE
			-Wl,-Werror
		)
	endif()
endfunction()
