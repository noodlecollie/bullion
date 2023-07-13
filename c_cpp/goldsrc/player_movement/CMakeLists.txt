add_library(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT} SHARED
	include/pm_debug.h
	include/pm_defs.h
	include/pm_info.h
	include/pm_materials.h
	include/pm_movevars.h
	include/pm_shared.h

	src/pm_debug.c
	src/pm_math.c
	src/pm_shared.c
)

target_include_directories(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}
	PUBLIC include
	PRIVATE src
)

target_link_libraries(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT} PUBLIC
	${TARGETNAME_LIB_GOLDSRC_COMMON_HEADERS}
)
