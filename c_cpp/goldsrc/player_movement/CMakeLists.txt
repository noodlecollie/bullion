add_library(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT} SHARED
	include/steam/steamtypes.h
	include/archtypes.h
	include/pm_debug.h
	include/pm_defs.h
	include/pm_info.h
	include/pm_materials.h
	include/pm_movevars.h
	include/pm_shared.h
	include/pmtrace.h
	include/usercmd.h

	src/const.h
	src/in_buttons.h
	src/mathlib.h
	src/pm_debug.c
	src/pm_math.c
	src/pm_shared.c
)

target_include_directories(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}
	PUBLIC include
	PRIVATE src
)
