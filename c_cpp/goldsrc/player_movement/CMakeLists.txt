include(export_header_template)
generate_export_header_template(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT} ${CMAKE_CURRENT_BINARY_DIR}/pm_export.h.in)

set(SOURCES
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

# Static target

set(GOLDSRC_PLAYERMOVEMENT_SHARED_LIBRARY NO)
configure_file(${CMAKE_CURRENT_BINARY_DIR}/pm_export.h.in ${CMAKE_CURRENT_BINARY_DIR}/generated_headers_static/pm_export.h)

add_library(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static STATIC
	${SOURCES}
	${CMAKE_CURRENT_BINARY_DIR}/generated_headers_static/pm_export.h
)

target_include_directories(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static
	PUBLIC
	include
	${CMAKE_CURRENT_BINARY_DIR}/generated_headers_static

	PRIVATE
	src
)

install(TARGETS ${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static
	ARCHIVE DESTINATION ${INSTALL_CATEGORY_LIB_GOLDSRC}/${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static/lib
	LIBRARY DESTINATION ${INSTALL_CATEGORY_LIB_GOLDSRC}/${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static/lib
	RUNTIME DESTINATION ${INSTALL_CATEGORY_LIB_GOLDSRC}/${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static/bin
)

install(DIRECTORY include DESTINATION ${INSTALL_CATEGORY_LIB_GOLDSRC}/${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static)
install(
	FILES ${CMAKE_CURRENT_BINARY_DIR}/generated_headers_static/pm_export.h
	DESTINATION ${INSTALL_CATEGORY_LIB_GOLDSRC}/${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static/include)

# Shared target

set(GOLDSRC_PLAYERMOVEMENT_SHARED_LIBRARY YES)
configure_file(${CMAKE_CURRENT_BINARY_DIR}/pm_export.h.in ${CMAKE_CURRENT_BINARY_DIR}/generated_headers_shared/pm_export.h)

add_library(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT} SHARED
	${SOURCES}
	${CMAKE_CURRENT_BINARY_DIR}/generated_headers_shared/pm_export.h
)

target_include_directories(${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}
	PUBLIC
	include
	${CMAKE_CURRENT_BINARY_DIR}/generated_headers_shared

	PRIVATE
	src
)

install(TARGETS ${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}
	ARCHIVE DESTINATION ${INSTALL_CATEGORY_LIB_GOLDSRC}/${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}/lib
	LIBRARY DESTINATION ${INSTALL_CATEGORY_LIB_GOLDSRC}/${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}/lib
	RUNTIME DESTINATION ${INSTALL_CATEGORY_LIB_GOLDSRC}/${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}/bin
)

install(DIRECTORY include DESTINATION ${INSTALL_CATEGORY_LIB_GOLDSRC}/${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT})
install(
	FILES ${CMAKE_CURRENT_BINARY_DIR}/generated_headers_shared/pm_export.h
	DESTINATION ${INSTALL_CATEGORY_LIB_GOLDSRC}/${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}/include)
