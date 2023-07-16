using System;
using System.Runtime.InteropServices;

namespace Bullion.PlayerMovement.Internal
{
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
	internal struct PMPlane
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

		internal PMPlane plane;

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

		// Unsure how best to marshal this - it's a pointer to pmmovevars_t.
		// For now, just use IntPtr I guess.
		internal IntPtr movevars;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		internal float[] player_mins;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		internal float[] player_maxs;

		// TODO
		// // Common functions
		// const char* (*PM_Info_ValueForKey)(const char* s, const char* key);
		// void (*PM_Particle)(float* origin, int color, float life, int zpos, int zvel);
		// int (*PM_TestPlayerPosition)(float* pos, pmtrace_t* ptrace);
		// void (*Con_NPrintf)(int idx, char* fmt, ...);
		// void (*Con_DPrintf)(char* fmt, ...);
		// void (*Con_Printf)(char* fmt, ...);
		// double (*Sys_FloatTime)(void);
		// void (*PM_StuckTouch)(int hitent, pmtrace_t* ptraceresult);
		// int (*PM_PointContents)(float* p, int* truecontents /*filled in if this is non-null*/);
		// int (*PM_TruePointContents)(float* p);
		// int (*PM_HullPointContents)(struct pmhull_s* hull, int num, float* p);
		// pmtrace_t (*PM_PlayerTrace)(float* start, float* end, int traceFlags, int ignore_pe);
		// struct pmtrace_s* (*PM_TraceLine)(float* start, float* end, int flags, int usehulll, int ignore_pe);
		// long (*RandomLong)(long lLow, long lHigh);
		// float (*RandomFloat)(float flLow, float flHigh);
		// int (*PM_GetModelType)(struct pmmodel_s* mod);
		// void (*PM_GetModelBounds)(struct pmmodel_s* mod, float* mins, float* maxs);
		// void* (*PM_HullForBsp)(pmphysent_t* pe, float* offset);
		// float (*PM_TraceModel)(pmphysent_t* pEnt, float* start, float* end, pmtrace_t* trace);
		// int (*COM_FileSize)(char* filename);
		// pmbyte* (*COM_LoadFile)(char* path, int usehunk, int* pLength);
		// void (*COM_FreeFile)(void* buffer);
		// char* (*memfgets)(pmbyte* pMemFile, int fileSize, int* pFilePos, char* pBuffer, int bufferSize);

		[MarshalAs(UnmanagedType.I1)]
		internal bool runfuncs;

		// void (*PM_PlaySound)(int channel, const char* sample, float volume, float attenuation, int fFlags, int pitch);
		// const char* (*PM_TraceTexture)(int ground, float* vstart, float* vend);

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

		// pmtrace_t (*PM_PlayerTraceEx)(float* start, float* end, int traceFlags, int (*pfnIgnore)(pmphysent_t* pe));
		// int (*PM_TestPlayerPositionEx)(float* pos, pmtrace_t* ptrace, int (*pfnIgnore)(pmphysent_t* pe));

		// struct pmtrace_s* (
		// 	*PM_TraceLineEx)(float* start, float* end, int flags, int usehulll, int (*pfnIgnore)(pmphysent_t* pe));
	}
}
