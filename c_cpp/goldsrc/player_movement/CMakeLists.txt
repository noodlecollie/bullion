set(PUBLIC_HEADERS_LIST
	${CMAKE_CURRENT_SOURCE_DIR}/include/steam/steamtypes.h
	${CMAKE_CURRENT_SOURCE_DIR}/include/archtypes.h
	${CMAKE_CURRENT_SOURCE_DIR}/include/pm_debug.h
	${CMAKE_CURRENT_SOURCE_DIR}/include/pm_defs.h
	${CMAKE_CURRENT_SOURCE_DIR}/include/pm_info.h
	${CMAKE_CURRENT_SOURCE_DIR}/include/pm_materials.h
	${CMAKE_CURRENT_SOURCE_DIR}/include/pm_movevars.h
	${CMAKE_CURRENT_SOURCE_DIR}/include/pm_shared.h
	${CMAKE_CURRENT_SOURCE_DIR}/include/pmtrace.h
	${CMAKE_CURRENT_SOURCE_DIR}/include/usercmd.h
)

set(SOURCES_LIST
	${CMAKE_CURRENT_SOURCE_DIR}/src/const.h
	${CMAKE_CURRENT_SOURCE_DIR}/src/in_buttons.h
	${CMAKE_CURRENT_SOURCE_DIR}/src/mathlib.h
	${CMAKE_CURRENT_SOURCE_DIR}/src/pm_debug.c
	${CMAKE_CURRENT_SOURCE_DIR}/src/pm_math.c
	${CMAKE_CURRENT_SOURCE_DIR}/src/pm_shared.c
)

set(CONFIGURE_DIR ${CMAKE_CURRENT_SOURCE_DIR}/configure)

set(PUBLIC_INCLUDE_DIRS
	${CMAKE_CURRENT_SOURCE_DIR}/include
)

set(PRIVATE_INCLUDE_DIRS
	${CMAKE_CURRENT_SOURCE_DIR}/src
)

add_compile_definitions(GOLDSRC_PLAYER_MOVEMENT_PRODUCER)

add_subdirectory(target_static)
add_subdirectory(target_shared)
