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

#ifndef CONST_H
#define CONST_H

//
// Constants shared by the engine and dlls
// This header file included by engine files and DLL files.
// Most came from server.h

// edict->flags
#define FL_FLY (1 << 0)   // Changes the SV_Movestep() behavior to not need to be on ground
#define FL_SWIM (1 << 1)  // Changes the SV_Movestep() behavior to not need to be on ground (but stay in water)
#define FL_CONVEYOR (1 << 2)
#define FL_CLIENT (1 << 3)
#define FL_INWATER (1 << 4)
#define FL_MONSTER (1 << 5)
#define FL_GODMODE (1 << 6)
#define FL_NOTARGET (1 << 7)
#define FL_SKIPLOCALHOST (1 << 8)   // Don't send entity to local host, it's predicting this entity itself
#define FL_ONGROUND (1 << 9)        // At rest / on the ground
#define FL_PARTIALGROUND (1 << 10)  // not all corners are valid
#define FL_WATERJUMP (1 << 11)      // player jumping out of water
#define FL_FROZEN (1 << 12)         // Player is frozen for 3rd person camera
#define FL_FAKECLIENT (1 << 13)     // JAC: fake client, simulated server side; don't send network messages to them
#define FL_DUCKING (1 << 14)        // Player flag -- Player is fully crouched
#define FL_FLOAT (1 << 15)          // Apply floating force to this entity when in water
#define FL_GRAPHED (1 << 16)        // worldgraph has this ent listed as something that blocks a connection

// UNDONE: Do we need these?
#define FL_IMMUNE_WATER (1 << 17)
#define FL_IMMUNE_SLIME (1 << 18)
#define FL_IMMUNE_LAVA (1 << 19)

#define FL_PROXY (1 << 20)  // This is a spectator proxy
#define FL_ALWAYSTHINK \
	(1 << 21)  // Brush model flag -- call think every frame regardless of nextthink - ltime (for constantly changing
			   // velocity/path)
#define FL_BASEVELOCITY \
	(1 << 22)  // Base velocity has been applied this frame (used to convert base velocity into momentum)
#define FL_MONSTERCLIP (1 << 23)  // Only collide in with monsters who have FL_MONSTERCLIP set
#define FL_ONTRAIN \
	(1 << 24)  // Player is _controlling_ a train, so movement commands should be ignored on client during prediction.
#define FL_WORLDBRUSH \
	(1 << 25)  // Not moveable/removeable brush entity (really part of the world, but represented as an entity for
			   // transparency or something)
#define FL_SPECTATOR (1 << 26)     // This client is a spectator, don't run touch functions, etc.
#define FL_CUSTOMENTITY (1 << 29)  // This is a custom entity
#define FL_KILLME \
	(1 << 30)  // This entity is marked for death -- This allows the engine to kill ents at the appropriate time
#define FL_DORMANT (1 << 31)  // Entity is dormant, no updates to client

// edict->movetype values
#define MOVETYPE_NONE 0  // never moves
// #define	MOVETYPE_ANGLENOCLIP	1
// #define	MOVETYPE_ANGLECLIP		2
#define MOVETYPE_WALK 3            // Player only - moving on the ground
#define MOVETYPE_STEP 4            // gravity, special edge handling -- monsters use this
#define MOVETYPE_FLY 5             // No gravity, but still collides with stuff
#define MOVETYPE_TOSS 6            // gravity/collisions
#define MOVETYPE_PUSH 7            // no clip to world, push and crush
#define MOVETYPE_NOCLIP 8          // No gravity, no collisions, still do velocity/avelocity
#define MOVETYPE_FLYMISSILE 9      // extra size to monsters
#define MOVETYPE_BOUNCE 10         // Just like Toss, but reflect velocity when contacting surfaces
#define MOVETYPE_BOUNCEMISSILE 11  // bounce w/o gravity
#define MOVETYPE_FOLLOW 12         // track movement of aiment
#define MOVETYPE_PUSHSTEP 13  // BSP model that needs physics/world collisions (uses nearest hull for world collision)

// edict->deadflag values
#define DEAD_NO 0     // alive
#define DEAD_DYING 1  // playing death animation or still falling off of a ledge waiting to hit ground
#define DEAD_DEAD 2   // dead. lying still.
#define DEAD_RESPAWNABLE 3
#define DEAD_DISCARDBODY 4

// contents of a spot in the world
#define CONTENTS_EMPTY -1
#define CONTENTS_SOLID -2
#define CONTENTS_WATER -3
#define CONTENTS_SLIME -4
#define CONTENTS_LAVA -5
#define CONTENTS_SKY -6
#define CONTENTS_LADDER -16

// channels
#define CHAN_AUTO 0
#define CHAN_WEAPON 1
#define CHAN_VOICE 2
#define CHAN_ITEM 3
#define CHAN_BODY 4
#define CHAN_STREAM 5             // allocate stream channel from the static or dynamic area
#define CHAN_STATIC 6             // allocate channel from the static area
#define CHAN_NETWORKVOICE_BASE 7  // voice data coming across the network
#define CHAN_NETWORKVOICE_END \
	500               // network voice data reserves slots (CHAN_NETWORKVOICE_BASE through CHAN_NETWORKVOICE_END).
#define CHAN_BOT 501  // channel used for bot chatter.

// attenuation values
#define ATTN_NONE 0.0f
#define ATTN_NORM 0.8f
#define ATTN_IDLE 2.0f
#define ATTN_STATIC 1.25f

// pitch values
#define PITCH_NORM 100  // non-pitch shifted
#define PITCH_LOW 95    // other values are possible - 0-255, where 255 is very high
#define PITCH_HIGH 120

#endif // CONST_H
