using System;
using System.Runtime.InteropServices;

namespace Bullion.PlayerMovement.Internal
{
	internal delegate int PMDelegate_IgnoreEnt([In] PMPhysEnt physEnt);

	// const char* (*PM_Info_ValueForKey)(const char* s, const char* key);
	internal delegate IntPtr PMDelegate_Info_ValueForKey(
		IntPtr str,
		[MarshalAs(UnmanagedType.LPStr)] string key);

	// void (*PM_Particle)(float* origin, int color, float life, int zpos, int zvel);
	internal delegate void PMDelegate_Particle(
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] origin,
		float life,
		int zpos,
		int zvel);

	// int (*PM_TestPlayerPosition)(float* pos, pmtrace_t* ptrace);
	internal delegate int PMDelegate_TestPlayerPosition(
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] pos,
		[Out] PMTrace trace);

	// Variadic functions like this are...interesting.
	// This solution may help? https://stackoverflow.com/questions/10361369/marshal-va-list-in-c-sharp-delegate

	// void (*Con_NPrintf)(int idx, char* fmt, ...);
	internal delegate void PMDelegate_Con_NPrintf(
		int idx,
		[MarshalAs(UnmanagedType.LPStr)] string fmt,
		IntPtr argAddresses);

	// void (*Con_DPrintf)(char* fmt, ...);
	internal delegate void PMDelegate_Con_DPrintf(
		[MarshalAs(UnmanagedType.LPStr)] string fmt,
		IntPtr argAddresses);

	// void (*Con_Printf)(char* fmt, ...);
	internal delegate void PMDelegate_Con_Printf(
		[MarshalAs(UnmanagedType.LPStr)] string fmt,
		IntPtr argAddresses);

	// double (*Sys_FloatTime)(void);
	internal delegate double PMDelegate_Sys_FloatTime();

	// void (*PM_StuckTouch)(int hitent, pmtrace_t* ptraceresult);
	internal delegate void PMDelegate_StuckTouch(
		int hitent,
		[Out] PMTrace traceresult);

	// int (*PM_PointContents)(float* p, int* truecontents /*filled in if this is non-null*/);
	internal delegate int PMDelegate_PointContents(
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] point,
		IntPtr truecontents);

	// int (*PM_TruePointContents)(float* p);
	internal delegate int PMDelegate_TruePointContents(
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] point);

	// int (*PM_HullPointContents)(struct pmhull_s* hull, int num, float* p);
	internal delegate int PMDelegate_HullPointContents(
		ref PMHull hull,
		int num,
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] point);

	// pmtrace_t (*PM_PlayerTrace)(float* start, float* end, int traceFlags, int ignore_pe);
	internal delegate PMTrace PMDelegate_PlayerTrace(
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] start,
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] end);

	// Returns a static pointer
	// struct pmtrace_s* (*PM_TraceLine)(float* start, float* end, int flags, int usehulll, int ignore_pe);
	internal delegate IntPtr PMDelegate_TraceLine(
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] start,
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] end,
		int flags,
		int usehull,
		int ignore_pe);

	// long (*RandomLong)(long lLow, long lHigh);
	internal delegate int PMDelegate_RandomLong(int low, int high);

	// float (*RandomFloat)(float flLow, float flHigh);
	internal delegate float PMDelegate_RandomFloat(float low, float high);

	// int (*PM_GetModelType)(struct pmmodel_s* mod);
	internal delegate int PMDelegate_GetModelType(IntPtr model);

	// void (*PM_GetModelBounds)(struct pmmodel_s* mod, float* mins, float* maxs);
	internal delegate void PMDelegate_GetModelBounds(
		IntPtr model,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] mins,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] maxs);

	// void* (*PM_HullForBsp)(pmphysent_t* pe, float* offset);
	internal delegate IntPtr PMDelegate_HullForBSP(
		[In] PMPhysEnt physEnt,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] offset);

	// float (*PM_TraceModel)(pmphysent_t* pEnt, float* start, float* end, pmtrace_t* trace);
	internal delegate float PMDelegate_TraceModel(
		[In] PMPhysEnt physEnt,
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] start,
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] end,
		[Out] PMTrace trace);

	// int (*COM_FileSize)(char* filename);
	internal delegate int PMDelegate_COM_FileSize(
		[MarshalAs(UnmanagedType.LPStr)] string filename);

	// pmbyte* (*COM_LoadFile)(char* path, int usehunk, int* pLength);
	internal delegate IntPtr PMDelegate_COM_LoadFile(
		[MarshalAs(UnmanagedType.LPStr)] string path,
		int usehunk,
		IntPtr length);

	// void (*COM_FreeFile)(void* buffer);
	internal delegate void PMDelegate_COM_FreeFile(IntPtr buffer);

	// char* (*memfgets)(pmbyte* pMemFile, int fileSize, int* pFilePos, char* pBuffer, int bufferSize);
	internal delegate IntPtr PMDelegate_memfgets(
		IntPtr memFile,
		int fileSize,
		[Out] int filePos,
		[Out, MarshalAs(UnmanagedType.LPArray)] byte[] buffer,
		int bufferSize);

	// void (*PM_PlaySound)(int channel, const char* sample, float volume, float attenuation, int fFlags, int pitch);
	internal delegate void PMDelegate_PlaySound(
		int channel,
		[MarshalAs(UnmanagedType.LPStr)] string sample,
		float volume,
		float attenuation,
		int flags,
		int pitch);

	// const char* (*PM_TraceTexture)(int ground, float* vstart, float* vend);
	internal delegate IntPtr PMDelegate_TraceTexture(
		int ground,
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] start,
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] end);

	// void (*PM_PlaybackEventFull)(
	// 	int flags,
	// 	int clientindex,
	// 	unsigned short eventindex,
	// 	float delay,
	// 	float* origin,
	// 	float* angles,
	// 	float fparam1,
	// 	float fparam2,
	// 	int iparam1,
	// 	int iparam2,
	// 	int bparam1,
	// 	int bparam2);
	internal delegate void PMDelegate_PlayBackEventFull(
		int flags,
		int clientindex,
		ushort eventindex,
		float delay,
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] origin,
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] angles,
		float fparam1,
		float fparam2,
		int iparam1,
		int iparam2,
		int bparam1,
		int bparam2);

	// pmtrace_t (*PM_PlayerTraceEx)(float* start, float* end, int traceFlags, int (*pfnIgnore)(pmphysent_t* pe));
	internal delegate PMTrace PMDelegate_PlayerTraceEx(
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] start,
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] end,
		int traceFlags,
		[MarshalAs(UnmanagedType.FunctionPtr)] PMDelegate_IgnoreEnt ignore);

	// int (*PM_TestPlayerPositionEx)(float* pos, pmtrace_t* ptrace, int (*pfnIgnore)(pmphysent_t* pe));
	internal delegate int PMDelegate_TestPlayerPositionEx(
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] pos,
		[Out] PMTrace trace,
		[MarshalAs(UnmanagedType.FunctionPtr)] PMDelegate_IgnoreEnt ignore);

	// struct pmtrace_s* (
	// 	*PM_TraceLineEx)(float* start, float* end, int flags, int usehulll, int (*pfnIgnore)(pmphysent_t* pe));
	internal delegate IntPtr PMDelegate_TraceLineEx(
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] start,
		[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] end,
		int flags,
		int usehull,
		[MarshalAs(UnmanagedType.FunctionPtr)] PMDelegate_IgnoreEnt ignore);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct Vec3
	{
		internal float x;
		internal float y;
		internal float z;
	};

	// pm_defs.h: pmclipnode_t
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct PMClipNode
	{
		internal int planenum;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		internal short[] children;
	}

	// pm_defs.h: pmplane_t
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct PMPlane
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] normal;

		internal float dist;
		internal byte type;
		internal byte signbits;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		internal byte[] pad;
	}

	// pm_defs.h: pmhull_t
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct PMHull
	{
		internal IntPtr clipnodes; // PMClipNode
		internal IntPtr planes; // PMPlane
		internal int firstclipnode;
		internal int lastclipnode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] clip_mins;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] clip_maxs;
	}

	// pm_defs.h: pmphysent_t
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct PMPhysEnt
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		internal string name;

		internal int player;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] origin;

		internal IntPtr model;
		internal IntPtr studiomodel;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] mins;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] maxs;

		internal int info;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] angles;

		internal int solid;
		internal int skin;
		internal int rendermode;

		internal float frame;
		internal int sequence;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		internal byte[] controller;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		internal byte[] blending;

		internal int movetype;
		internal int takedamage;
		internal int blooddecal;
		internal int team;
		internal int classnumber;

		internal int iuser1;
		internal int iuser2;
		internal int iuser3;
		internal int iuser4;
		internal float fuser1;
		internal float fuser2;
		internal float fuser3;
		internal float fuser4;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] vuser1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] vuser2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] vuser3;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] vuser4;
	}

	// pm_defs.h: pmusercmd_t
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct PMUserCmd
	{
		internal short lerp_msec;
		internal byte msec;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] viewangles;

		internal float forwardmove;
		internal float sidemove;
		internal float upmove;
		internal byte lightlevel;
		internal ushort buttons;
		internal byte impulse;
		internal byte weaponselect;

		internal int impact_index;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] impact_position;
	}

	// pmtrace.h: pmplane_t
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct PMTracePlane
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] normal;

		internal float dist;
	}

	// pmtrace.h: pmtrace_t
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct PMTrace
	{
		[MarshalAs(UnmanagedType.I1)]
		internal bool allsolid;

		[MarshalAs(UnmanagedType.I1)]
		internal bool startsolid;

		[MarshalAs(UnmanagedType.I1)]
		internal bool inopen, inwater;

		internal float fraction;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] endpos;

		internal PMTracePlane plane;

		internal int ent;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] deltavelocity;

		internal int hitgroup;
	}

	// pm_movevars.h: pmmovevars_t
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct PMMoveVars
	{
		internal float gravity;
		internal float stopspeed;
		internal float maxspeed;
		internal float spectatormaxspeed;
		internal float accelerate;
		internal float airaccelerate;
		internal float wateraccelerate;
		internal float friction;
		internal float edgefriction;
		internal float waterfriction;
		internal float entgravity;
		internal float bounce;
		internal float stepsize;
		internal float maxvelocity;
		internal float zmax;
		internal float waveHeight;

		[MarshalAs(UnmanagedType.I1)]
		internal bool footsteps;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		internal string skyName;

		internal float rollangle;
		internal float rollspeed;
		internal float skycolor_r;
		internal float skycolor_g;
		internal float skycolor_b;
		internal float skyvec_x;
		internal float skyvec_y;
		internal float skyvec_z;
	};

	// pm_defs.h: pmplayermove_t
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct PMPlayerMove
	{
		internal int player_index;

		[MarshalAs(UnmanagedType.I1)]
		internal bool server;

		[MarshalAs(UnmanagedType.I1)]
		internal bool multiplayer;

		internal float time;
		internal float frametime;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] forward;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] right;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] up;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] origin;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] angles;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] oldangles;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] velocity;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] movedir;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] basevelocity;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] view_ofs;

		internal float flDuckTime;

		[MarshalAs(UnmanagedType.I1)]
		internal bool bInDuck;

		internal int flTimeStepSound;
		internal int iStepLeft;

		internal float flFallVelocity;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] punchangle;

		internal float flSwimTime;

		internal float flNextPrimaryAttack;

		internal int effects;

		internal int flags;
		internal int usehull;
		internal float gravity;
		internal float friction;
		internal int oldbuttons;
		internal float waterjumptime;

		[MarshalAs(UnmanagedType.I1)]
		internal bool dead;

		internal int deadflag;
		internal int spectator;
		internal int movetype;

		internal int onground;
		internal int waterlevel;
		internal int watertype;
		internal int oldwaterlevel;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		internal string sztexturename;

		internal char chtexturetype;

		internal float maxspeed;
		internal float clientmaxspeed;

		internal int iuser1;
		internal int iuser2;
		internal int iuser3;
		internal int iuser4;
		internal float fuser1;
		internal float fuser2;
		internal float fuser3;
		internal float fuser4;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] vuser1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] vuser2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] vuser3;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] vuser4;

		internal int numphysent;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 600)]
		internal PMPhysEnt[] physents;

		internal int nummoveent;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		internal PMPhysEnt[] moveents;

		internal int numvisent;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 600)]
		internal PMPhysEnt[] visents;

		internal PMUserCmd cmd;

		internal int numtouch;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 600)]
		internal PMTrace[] touchindex;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		internal string physinfo;

		internal IntPtr movevars; // PMMoveVars

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		internal float[] player_mins;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		internal float[] player_maxs;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_Info_ValueForKey Info_ValueForKey;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_Particle Particle;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_TestPlayerPosition TestPlayerPosition;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_Con_NPrintf Con_NPrintf;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_Con_DPrintf Con_DPrintf;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_Con_Printf Con_Printf;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_Sys_FloatTime Sys_FloatTime;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_StuckTouch StuckTouch;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_PointContents PointContents;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_TruePointContents TruePointContents;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_HullPointContents HullPointContents;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_PlayerTrace PlayerTrace;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_TraceLine TraceLine;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_RandomLong RandomLong;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_RandomFloat RandomFloat;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_GetModelType GetModelType;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_GetModelBounds GetModelBounds;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_HullForBSP HullForBSP;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_TraceModel TraceModel;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_COM_FileSize COM_FileSize;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_COM_LoadFile COM_LoadFile;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_COM_FreeFile COM_FreeFile;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_memfgets memfgets;

		[MarshalAs(UnmanagedType.I1)]
		internal bool runfuncs;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_PlaySound PlaySound;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_TraceTexture TraceTexture;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_PlayBackEventFull PlayBackEventFull;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_PlayerTraceEx PlayerTraceEx;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_TestPlayerPositionEx TestPlayerPositionEx;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		internal PMDelegate_TraceLineEx TraceLineEx;
	}
}
