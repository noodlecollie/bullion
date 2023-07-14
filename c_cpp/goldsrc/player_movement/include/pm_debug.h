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

#ifndef PM_DEBUG_H
#define PM_DEBUG_H

#pragma once

#include "pm_export.h"

GOLDSRC_PM_PUBLIC(void) PM_ViewEntity( void );
GOLDSRC_PM_PUBLIC(void) PM_DrawBBox(vec3_t mins, vec3_t maxs, vec3_t origin, int pcolor, float life);
GOLDSRC_PM_PUBLIC(void) PM_ParticleLine(vec3_t start, vec3_t end, int pcolor, float life, float vert);
GOLDSRC_PM_PUBLIC(void) PM_ShowClipBox( void );

#endif // PMOVEDBG_H
