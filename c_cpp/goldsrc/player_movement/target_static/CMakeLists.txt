configure_file(${CONFIGURE_DIR}/pm_export.h.in ${CMAKE_CURRENT_BINARY_DIR}/generated_headers/pm_export.h)

add_library("${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static" STATIC
	${PUBLIC_HEADERS_LIST}
	${SOURCES_LIST}
)

target_include_directories("${TARGETNAME_LIB_GOLDSRC_PLAYER_MOVEMENT}_Static"
	PUBLIC
	${PUBLIC_INCLUDE_DIRS}

	PRIVATE
	${PRIVATE_INCLIDE_DIRS}
	${CMAKE_CURRENT_BINARY_DIR}/generated_headers
)
