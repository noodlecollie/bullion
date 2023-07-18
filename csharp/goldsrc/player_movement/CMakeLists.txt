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
