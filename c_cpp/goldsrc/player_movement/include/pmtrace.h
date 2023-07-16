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

#ifndef PM_TRACE_H
#define PM_TRACE_H

#include "pm_basictypes.h"

typedef struct
{
	pmvec3_t normal;
	float dist;
} pmtraceplane_t;

typedef struct pmtrace_s pmtrace_t;

struct pmtrace_s
{
	pmboolean allsolid;         // if true, plane is not valid
	pmboolean startsolid;       // if true, the initial point was in a solid area
	pmboolean inopen, inwater;  // End point is in empty space or in water
	float fraction;             // time completed, 1.0 = didn't hit anything
	pmvec3_t endpos;            // final position
	pmtraceplane_t plane;       // surface normal at impact
	int ent;                    // entity at impact
	pmvec3_t deltavelocity;     // Change in player's velocity caused by impact.
								// Only run on server.
	int hitgroup;
};

#endif  // PM_TRACE_H
