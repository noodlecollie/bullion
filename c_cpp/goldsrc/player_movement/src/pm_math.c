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
// pm_math.c -- math primitives

#include "mathlib.h"
#include "const.h"
#include <math.h>

// up / down
#define PITCH 0
// left / right
#define YAW 1
// fall over
#define ROLL 2

#pragma warning(disable : 4244)

const pmvec3_t vec3_origin = {0, 0, 0};
const int nanmask = 255 << 23;

void AngleVectors(const pmvec3_t angles, pmvec3_t forward, pmvec3_t right, pmvec3_t up)
{
	float angle;
	float sr, sp, sy, cr, cp, cy;

	angle = angles[YAW] * (M_PI * 2 / 360);
	sy = sin(angle);
	cy = cos(angle);
	angle = angles[PITCH] * (M_PI * 2 / 360);
	sp = sin(angle);
	cp = cos(angle);
	angle = angles[ROLL] * (M_PI * 2 / 360);
	sr = sin(angle);
	cr = cos(angle);

	if ( forward )
	{
		forward[0] = cp * cy;
		forward[1] = cp * sy;
		forward[2] = -sp;
	}
	if ( right )
	{
		right[0] = (-1 * sr * sp * cy + -1 * cr * -sy);
		right[1] = (-1 * sr * sp * sy + -1 * cr * cy);
		right[2] = -1 * sr * cp;
	}
	if ( up )
	{
		up[0] = (cr * sp * cy + -sr * -sy);
		up[1] = (cr * sp * sy + -sr * cy);
		up[2] = cr * cp;
	}
}

void AngleVectorsTranspose(const pmvec3_t angles, pmvec3_t forward, pmvec3_t right, pmvec3_t up)
{
	float angle;
	float sr, sp, sy, cr, cp, cy;

	angle = angles[YAW] * (M_PI * 2 / 360);
	sy = sin(angle);
	cy = cos(angle);
	angle = angles[PITCH] * (M_PI * 2 / 360);
	sp = sin(angle);
	cp = cos(angle);
	angle = angles[ROLL] * (M_PI * 2 / 360);
	sr = sin(angle);
	cr = cos(angle);

	if ( forward )
	{
		forward[0] = cp * cy;
		forward[1] = (sr * sp * cy + cr * -sy);
		forward[2] = (cr * sp * cy + -sr * -sy);
	}
	if ( right )
	{
		right[0] = cp * sy;
		right[1] = (sr * sp * sy + cr * cy);
		right[2] = (cr * sp * sy + -sr * cy);
	}
	if ( up )
	{
		up[0] = -sp;
		up[1] = sr * cp;
		up[2] = cr * cp;
	}
}

int VectorCompare(const pmvec3_t v1, const pmvec3_t v2)
{
	int i;

	for ( i = 0; i < 3; i++ )
		if ( v1[i] != v2[i] )
			return 0;

	return 1;
}

void VectorMA(const pmvec3_t veca, float scale, const pmvec3_t vecb, pmvec3_t vecc)
{
	vecc[0] = veca[0] + scale * vecb[0];
	vecc[1] = veca[1] + scale * vecb[1];
	vecc[2] = veca[2] + scale * vecb[2];
}

void CrossProduct(const pmvec3_t v1, const pmvec3_t v2, pmvec3_t cross)
{
	cross[0] = v1[1] * v2[2] - v1[2] * v2[1];
	cross[1] = v1[2] * v2[0] - v1[0] * v2[2];
	cross[2] = v1[0] * v2[1] - v1[1] * v2[0];
}

double sqrt(double x);

float Length(const pmvec3_t v)
{
	int i;
	float length = 0.0f;

	for ( i = 0; i < 3; i++ )
		length += v[i] * v[i];
	length = sqrt(length);  // FIXME

	return length;
}

float Distance(const pmvec3_t v1, const pmvec3_t v2)
{
	pmvec3_t d;
	VectorSubtract(v2, v1, d);
	return Length(d);
}

float VectorNormalize(pmvec3_t v)
{
	float length, ilength;

	length = v[0] * v[0] + v[1] * v[1] + v[2] * v[2];
	length = sqrt(length);  // FIXME

	if ( length )
	{
		ilength = 1 / length;
		v[0] *= ilength;
		v[1] *= ilength;
		v[2] *= ilength;
	}

	return length;
}

void VectorScale(const pmvec3_t in, pmvec_t scale, pmvec3_t out)
{
	out[0] = in[0] * scale;
	out[1] = in[1] * scale;
	out[2] = in[2] * scale;
}
