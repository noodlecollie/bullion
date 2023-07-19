configure_file(configure/Directory.Build.props.in ${CMAKE_CURRENT_BINARY_DIR}/Directory.Build.props)

add_library(${TARGETNAME_CSLIB_GOLDSRC_PLAYER_MOVEMENT} SHARED
	public/EngineCallbacks.cs
	public/Interface.cs

	private/Defs.cs
	private/LibInterface.cs
	private/LibTypes.cs
)

target_compile_definitions(${TARGETNAME_CSLIB_GOLDSRC_PLAYER_MOVEMENT} PUBLIC
	$<$<BOOL:${ENABLE_TRACE}>:GOLDSRC_PLAYERMOVEMENT_TRACE>
)

set_property(TARGET ${TARGETNAME_CSLIB_GOLDSRC_PLAYER_MOVEMENT} PROPERTY VS_PACKAGE_REFERENCES
	"Unity3D_2.1.2"
)
