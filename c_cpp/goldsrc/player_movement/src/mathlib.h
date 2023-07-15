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

typedef pmvec_t vec4_t[4];  // x,y,z,w
typedef pmvec_t vec5_t[5];

typedef short vec_s_t;
typedef vec_s_t vec3s_t[3];
typedef vec_s_t vec4s_t[4];  // x,y,z,w
typedef vec_s_t vec5s_t[5];

typedef int fixed4_t;
typedef int fixed8_t;
typedef int fixed16_t;

#ifndef M_PI
#define M_PI 3.14159265358979323846  // matches value in gcc v2 math.h
#endif

struct mplane_s;

extern pmvec3_t vec3_origin;
extern int nanmask;

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

pmvec_t _DotProduct(pmvec3_t v1, pmvec3_t v2);
void _VectorSubtract(pmvec3_t veca, pmvec3_t vecb, pmvec3_t out);
void _VectorAdd(pmvec3_t veca, pmvec3_t vecb, pmvec3_t out);
void _VectorCopy(pmvec3_t in, pmvec3_t out);

int VectorCompare(const pmvec3_t v1, const pmvec3_t v2);
float Length(const pmvec3_t v);
void CrossProduct(const pmvec3_t v1, const pmvec3_t v2, pmvec3_t cross);
float VectorNormalize(pmvec3_t v);  // returns vector length
void VectorInverse(pmvec3_t v);
void VectorScale(const pmvec3_t in, pmvec_t scale, pmvec3_t out);
int Q_log2(int val);

void R_ConcatRotations(float in1[3][3], float in2[3][3], float out[3][3]);
void R_ConcatTransforms(float in1[3][4], float in2[3][4], float out[3][4]);

// Here are some "manual" INLINE routines for doing floating point to integer conversions
extern short new_cw, old_cw;

typedef union DLONG
{
	int i[2];
	double d;
	float f;
} DLONG;

extern DLONG dlong;

void FloorDivMod(double numer, double denom, int* quotient, int* rem);
fixed16_t Invert24To16(fixed16_t val);
int GreatestCommonDivisor(int i1, int i2);

void AngleVectors(const pmvec3_t angles, pmvec3_t forward, pmvec3_t right, pmvec3_t up);
void AngleVectorsTranspose(const pmvec3_t angles, pmvec3_t forward, pmvec3_t right, pmvec3_t up);
#define AngleIVectors AngleVectorsTranspose

void AngleMatrix(const pmvec3_t angles, float (*matrix)[4]);
void AngleIMatrix(const pmvec3_t angles, float (*matrix)[4]);
void VectorTransform(const pmvec3_t in1, float in2[3][4], pmvec3_t out);

void NormalizeAngles(pmvec3_t angles);
void InterpolateAngles(pmvec3_t start, pmvec3_t end, pmvec3_t output, float frac);
float AngleBetweenVectors(const pmvec3_t v1, const pmvec3_t v2);

void VectorMatrix(pmvec3_t forward, pmvec3_t right, pmvec3_t up);
void VectorAngles(const pmvec3_t forward, pmvec3_t angles);

int InvertMatrix(const float* m, float* out);

int BoxOnPlaneSide(pmvec3_t emins, pmvec3_t emaxs, struct mplane_s* plane);
float anglemod(float a);

#define BOX_ON_PLANE_SIDE(emins, emaxs, p) \
	(((p)->type < 3) ? (((p)->dist <= (emins)[(p)->type]) ? 1 : (((p)->dist >= (emaxs)[(p)->type]) ? 2 : 3)) \
					 : BoxOnPlaneSide((emins), (emaxs), (p)))

#endif // MATHLIB_H
