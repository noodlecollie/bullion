include(static_shared_lib_utils)
generate_export_header_template(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT} ${CMAKE_CURRENT_BINARY_DIR}/pm_export.h.in)

set(SOURCES
	include/steam/steamtypes.h
	include/archtypes.h
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

)

create_library_target(
	TARGET ${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}
	TYPE STATIC
	INSTALL_PREFIX ${INSTALL_CATEGORY_LIB_GOLDSRC}
	EXPORT_HEADER pm_export.h
	SOURCES ${SOURCES}
)

create_library_target(
	TARGET ${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}
	TYPE SHARED
	INSTALL_PREFIX ${INSTALL_CATEGORY_LIB_GOLDSRC}
	EXPORT_HEADER pm_export.h
	SOURCES ${SOURCES}
)
