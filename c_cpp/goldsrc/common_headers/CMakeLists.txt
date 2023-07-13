add_library(${TARGETNAME_LIB_GOLDSRC_COMMON_HEADERS} INTERFACE
	include/steam/steamtypes.h
	include/archtypes.h
	include/const.h
	include/in_buttons.h
	include/mathlib.h
	include/pmtrace.h
	include/usercmd.h
)

target_include_directories(${TARGETNAME_LIB_GOLDSRC_COMMON_HEADERS}
	INTERFACE include
)
