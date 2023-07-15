function(set_basic_library_compiler_settings targetname)
	if(NOT CMAKE_CXX_COMPILER_ID STREQUAL "MSVC")
		target_link_options(${targetname} PRIVATE
			-Wl,--no-undefined
		)
	endif()
endfunction()

function(set_pedantic_library_compiler_settings targetname)
	if(CMAKE_CXX_COMPILER_ID STREQUAL "MSVC")
		target_compile_options(${targetname} PRIVATE
			/W4
		)
	else()
		target_compile_options(${targetname} PRIVATE
			-Wall
			-Wextra
			-pedantic
		)
	endif()
endfunction()
