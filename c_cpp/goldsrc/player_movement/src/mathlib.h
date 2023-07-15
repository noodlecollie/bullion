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

#ifndef MATHLIB_H
#define MATHLIB_H

#include "pm_basictypes.h"

#define M_PI 3.14159265358979323846  // matches value in gcc v2 math.h
#define M_PI_F ((float)M_PI)

extern const pmvec3_t vec3_origin;
extern const int nanmask;

#define IS_NAN(x) (((*(int*)&x) & nanmask) == nanmask)

#define DotProduct(x, y) ((x)[0] * (y)[0] + (x)[1] * (y)[1] + (x)[2] * (y)[2])

#define VectorSubtract(a, b, c) \
	{ \
		(c)[0] = (a)[0] - (b)[0]; \
		(c)[1] = (a)[1] - (b)[1]; \
		(c)[2] = (a)[2] - (b)[2]; \
	}

#define VectorAdd(a, b, c) \
	{ \
		(c)[0] = (a)[0] + (b)[0]; \
		(c)[1] = (a)[1] + (b)[1]; \
		(c)[2] = (a)[2] + (b)[2]; \
	}

#define VectorCopy(a, b) \
	{ \
		(b)[0] = (a)[0]; \
		(b)[1] = (a)[1]; \
		(b)[2] = (a)[2]; \
	}

#define VectorClear(a) \
	{ \
		(a)[0] = 0.0; \
		(a)[1] = 0.0; \
		(a)[2] = 0.0; \
	}

void VectorMA(const pmvec3_t veca, float scale, const pmvec3_t vecb, pmvec3_t vecc);
int VectorCompare(const pmvec3_t v1, const pmvec3_t v2);
float Length(const pmvec3_t v);
void CrossProduct(const pmvec3_t v1, const pmvec3_t v2, pmvec3_t cross);
float VectorNormalize(pmvec3_t v);  // returns vector length
void VectorScale(const pmvec3_t in, pmvec_t scale, pmvec3_t out);
void AngleVectors(const pmvec3_t angles, pmvec3_t forward, pmvec3_t right, pmvec3_t up);
void AngleVectorsTranspose(const pmvec3_t angles, pmvec3_t forward, pmvec3_t right, pmvec3_t up);

#endif  // MATHLIB_H
