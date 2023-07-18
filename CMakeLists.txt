cmake_minimum_required(VERSION 3.21)

list(APPEND CMAKE_MODULE_PATH "${CMAKE_CURRENT_SOURCE_DIR}/cmake")

project(bullion VERSION 0.1.0 LANGUAGES C CXX)

option(ENABLE_TRACE "Enables trace debugging messages (very verbose)." OFF)

set(CMAKE_CXX_STANDARD 11)
set(CMAKE_CXX_STANDARD_REQUIRED YES)

set(CMAKE_C_STANDARD 99)
set(CMAKE_C_STANDARD_REQUIRED YES)

set(CMAKE_POSITION_INDEPENDENT_CODE YES)
set(CMAKE_CXX_VISIBILITY_PRESET hidden)
set(CMAKE_VISIBILITY_INLINES_HIDDEN YES)
set(CMAKE_COMPILE_WARNING_AS_ERROR YES)

include(project_definitions)

add_subdirectory(c_cpp)

if(CMAKE_CXX_COMPILER_ID STREQUAL "MSVC")
	enable_language(CSharp)
	add_subdirectory(csharp)
endif()
