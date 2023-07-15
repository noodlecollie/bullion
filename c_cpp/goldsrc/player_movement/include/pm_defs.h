/***
*
*	Copyright (c) 1996-2002, Valve LLC. All rights reserved.
*
*	This product contains software technology licensed from Id
*	Software, Inc. ("Id Technology").  Id Technology (c) 1996 Id Software, Inc.
*	All Rights Reserved.
*
*   Use, distribution, and modification of this source code and/or resulting
*   object code is restricted to non-commercial enhancements to products from
*   Valve LLC.  All other use, distribution, or modification is prohibited
*   without written permission from Valve LLC.
*
****/
// pm_defs.h
#if !defined( PM_DEFSH )
#define PM_DEFSH
#pragma once

#define	MAX_PHYSENTS 600 		  // Must have room for all entities in the world.
#define MAX_MOVEENTS 64
#define	MAX_CLIP_PLANES	5

#define PM_NORMAL			0x00000000
#define PM_STUDIO_IGNORE	0x00000001		// Skip studio models
#define PM_STUDIO_BOX		0x00000002		// Use boxes for non-complex studio models (even in traceline)
#define PM_GLASS_IGNORE		0x00000004		// Ignore entities with non-normal rendermode
#define PM_WORLD_ONLY		0x00000008		// Only trace against the world

// Values for flags parameter of PM_TraceLine
#define PM_TRACELINE_PHYSENTSONLY	0
#define PM_TRACELINE_ANYVISIBLE		1


#include "pm_info.h"

// PM_PlayerTrace results.
#include "pmtrace.h"

struct pmhull_s;
struct pmmodel_s;
struct pmmovevars_s;

// pmphysent_t
typedef struct pmphysent_s
{
	char			name[32];             // Name of model, or "player" or "world".
	int				player;
	pmvec3_t			origin;               // Model's origin in world coordinates.
	struct pmmodel_s	*model;		          // only for bsp models
	struct pmmodel_s	*studiomodel;         // SOLID_BBOX, but studio clip intersections.
	pmvec3_t			mins, maxs;	          // only for non-bsp models
	int				info;		          // For client or server to use to identify (index into edicts or cl_entities)
	pmvec3_t			angles;               // rotated entities need this info for hull testing to work.

	int				solid;				  // Triggers and func_door type WATER brushes are SOLID_NOT
	int				skin;                 // BSP Contents for such things like fun_door water brushes.
	int				rendermode;			  // So we can ignore glass

	// Complex collision detection.
	float			frame;
	int				sequence;
	pmbyte			controller[4];
	pmbyte			blending[2];

	int				movetype;
	int				takedamage;
	int				blooddecal;
	int				team;
	int				classnumber;

	// For mods
	int				iuser1;
	int				iuser2;
	int				iuser3;
	int				iuser4;
	float			fuser1;
	float			fuser2;
	float			fuser3;
	float			fuser4;
	pmvec3_t			vuser1;
	pmvec3_t			vuser2;
	pmvec3_t			vuser3;
	pmvec3_t			vuser4;
} pmphysent_t;

typedef struct pmusercmd_s
{
	short	lerp_msec;      // Interpolation time on client
	pmbyte	msec;           // Duration in ms of command
	pmvec3_t	viewangles;     // Command view angles.

// intended velocities
	float	forwardmove;    // Forward velocity.
	float	sidemove;       // Sideways velocity.
	float	upmove;         // Upward velocity.
	pmbyte	lightlevel;     // Light level at spot where we are standing.
	unsigned short  buttons;  // Attack buttons
	pmbyte    impulse;          // Impulse command issued.
	pmbyte	weaponselect;	// Current weapon id

// Experimental player impact stuff.
	int		impact_index;
	pmvec3_t	impact_position;
} pmusercmd_t;

typedef struct pmplayermove_s
{
	int				player_index;  // So we don't try to run the PM_CheckStuck nudging too quickly.
	pmboolean		server;        // For debugging, are we running physics code on server side?

	pmboolean		multiplayer;   // 1 == multiplayer server
	float			time;          // realtime on host, for reckoning duck timing
	float			frametime;	   // Duration of this frame

	pmvec3_t			forward, right, up; // Vectors for angles
	// player state
	pmvec3_t			origin;        // Movement origin.
	pmvec3_t			angles;        // Movement view angles.
	pmvec3_t			oldangles;     // Angles before movement view angles were looked at.
	pmvec3_t			velocity;      // Current movement direction.
	pmvec3_t			movedir;       // For waterjumping, a forced forward velocity so we can fly over lip of ledge.
	pmvec3_t			basevelocity;  // Velocity of the conveyor we are standing, e.g.

	// For ducking/dead
	pmvec3_t			view_ofs;      // Our eye position.
	float			flDuckTime;    // Time we started duck
	pmboolean		bInDuck;       // In process of ducking or ducked already?

	// For walking/falling
	int				flTimeStepSound;  // Next time we can play a step sound
	int				iStepLeft;

	float			flFallVelocity;
	pmvec3_t			punchangle;

	float			flSwimTime;

	float			flNextPrimaryAttack;

	int				effects;		// MUZZLE FLASH, e.g.

	int				flags;         // FL_ONGROUND, FL_DUCKING, etc.
	int				usehull;       // 0 = regular player hull, 1 = ducked player hull, 2 = point hull
	float			gravity;       // Our current gravity and friction.
	float			friction;
	int				oldbuttons;    // Buttons last usercmd
	float			waterjumptime; // Amount of time left in jumping out of water cycle.
	pmboolean		dead;          // Are we a dead player?
	int				deadflag;
	int				spectator;     // Should we use spectator physics model?
	int				movetype;      // Our movement type, NOCLIP, WALK, FLY

	int				onground;
	int				waterlevel;
	int				watertype;
	int				oldwaterlevel;

	char			sztexturename[256];
	char			chtexturetype;

	float			maxspeed;
	float			clientmaxspeed; // Player specific maxspeed

	// For mods
	int				iuser1;
	int				iuser2;
	int				iuser3;
	int				iuser4;
	float			fuser1;
	float			fuser2;
	float			fuser3;
	float			fuser4;
	pmvec3_t			vuser1;
	pmvec3_t			vuser2;
	pmvec3_t			vuser3;
	pmvec3_t			vuser4;
	// world state
	// Number of entities to clip against.
	int				numphysent;
	pmphysent_t		physents[MAX_PHYSENTS];
	// Number of momvement entities (ladders)
	int				nummoveent;
	// just a list of ladders
	pmphysent_t		moveents[MAX_MOVEENTS];

	// All things being rendered, for tracing against things you don't actually collide with
	int				numvisent;
	pmphysent_t		visents[ MAX_PHYSENTS ];

	// input to run through physics.
	pmusercmd_t		cmd;

	// Trace results for objects we collided with.
	int				numtouch;
	pmtrace_t		touchindex[MAX_PHYSENTS];

	char			physinfo[ MAX_PHYSINFO_STRING ]; // Physics info string

	struct pmmovevars_s *movevars;
	pmvec3_t player_mins[ 4 ];
	pmvec3_t player_maxs[ 4 ];

	// Common functions
	const char		*(*PM_Info_ValueForKey) ( const char *s, const char *key );
	void			(*PM_Particle)( float *origin, int color, float life, int zpos, int zvel);
	int				(*PM_TestPlayerPosition) (float *pos, pmtrace_t *ptrace );
	void			(*Con_NPrintf)( int idx, char *fmt, ... );
	void			(*Con_DPrintf)( char *fmt, ... );
	void			(*Con_Printf)( char *fmt, ... );
	double			(*Sys_FloatTime)( void );
	void			(*PM_StuckTouch)( int hitent, pmtrace_t *ptraceresult );
	int				(*PM_PointContents) (float *p, int *truecontents /*filled in if this is non-null*/ );
	int				(*PM_TruePointContents) (float *p);
	int				(*PM_HullPointContents) ( struct pmhull_s *hull, int num, float *p);
	pmtrace_t		(*PM_PlayerTrace) (float *start, float *end, int traceFlags, int ignore_pe );
	struct pmtrace_s *(*PM_TraceLine)( float *start, float *end, int flags, int usehulll, int ignore_pe );
	int32			(*RandomLong)( int32 lLow, int32 lHigh );
	float			(*RandomFloat)( float flLow, float flHigh );
	int				(*PM_GetModelType)( struct pmmodel_s *mod );
	void			(*PM_GetModelBounds)( struct pmmodel_s *mod, float *mins, float *maxs );
	void			*(*PM_HullForBsp)( pmphysent_t *pe, float *offset );
	float			(*PM_TraceModel)( pmphysent_t *pEnt, float *start, float *end, pmtrace_t *trace );
	int				(*COM_FileSize)(char *filename);
	pmbyte			*(*COM_LoadFile) (char *path, int usehunk, int *pLength);
	void			(*COM_FreeFile) ( void *buffer );
	char			*(*memfgets)( pmbyte *pMemFile, int fileSize, int *pFilePos, char *pBuffer, int bufferSize );

	// Functions
	// Run functions for this frame?
	pmboolean		runfuncs;
	void			(*PM_PlaySound) ( int channel, const char *sample, float volume, float attenuation, int fFlags, int pitch );
	const char		*(*PM_TraceTexture) ( int ground, float *vstart, float *vend );
	void			(*PM_PlaybackEventFull) ( int flags, int clientindex, unsigned short eventindex, float delay, float *origin, float *angles, float fparam1, float fparam2, int iparam1, int iparam2, int bparam1, int bparam2 );

	pmtrace_t		(*PM_PlayerTraceEx) (float *start, float *end, int traceFlags, int (*pfnIgnore)( pmphysent_t *pe ) );
	int				(*PM_TestPlayerPositionEx) (float *pos, pmtrace_t *ptrace, int (*pfnIgnore)( pmphysent_t *pe ) );
	struct pmtrace_s *(*PM_TraceLineEx)( float *start, float *end, int flags, int usehulll, int (*pfnIgnore)( pmphysent_t *pe ) );
} pmplayermove_t;

#endif
