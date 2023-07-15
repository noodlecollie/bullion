include(static_shared_lib_utils)
include(compile_settings)

generate_export_header_template(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT} ${CMAKE_CURRENT_BINARY_DIR}/pm_export.h.in)

set(SOURCES
	include/pm_basictypes.h
	include/pm_debug.h
	include/pm_defs.h
	include/pm_info.h
	include/pm_materials.h
	include/pm_movevars.h
	include/pm_shared.h
	include/pmtrace.h

	src/const.h
	src/in_buttons.h
	src/mathlib.h
	src/pm_debug.c
	src/pm_math.c
	src/pm_shared.c
	src/posix_string.h
)

set(LIBS
	$<$<NOT:$<STREQUAL:"${CMAKE_CXX_COMPILER_ID}","MSVC">>:m>
	$<$<NOT:$<STREQUAL:"${CMAKE_CXX_COMPILER_ID}","MSVC">>:safestring_static>
)

create_library_target(
	TARGET ${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static
	TYPE STATIC
	INSTALL_PREFIX ${INSTALL_CATEGORY_LIB_GOLDSRC}
	EXPORT_HEADER pm_export.h
	SOURCES ${SOURCES}
	LIBS ${LIBS}
)

set_basic_library_compiler_settings(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static)
set_pedantic_library_compiler_settings(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static)

create_library_target(
	TARGET ${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}
	TYPE SHARED
	INSTALL_PREFIX ${INSTALL_CATEGORY_LIB_GOLDSRC}
	EXPORT_HEADER pm_export.h
	SOURCES ${SOURCES}
	LIBS ${LIBS}
)

set_basic_library_compiler_settings(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT})
set_pedantic_library_compiler_settings(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT})
