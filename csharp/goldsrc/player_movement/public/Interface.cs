using System;
using UnityEngine;

namespace Bullion.PlayerMovement
{
	public static class Interface
	{
		public static void Initialise(EngineCallbacks engineCallbacksObject)
		{
			if ( engineCallbacksObject == null )
			{
				throw new ArgumentException("Engine callbacks object cannot be null.");
			}

			if ( _initialised )
			{
				return;
			}

			SetCallbacks(engineCallbacksObject);

			Internal.PMShared.PM_Init(ref _pmove);
			_initialised = true;
		}

		private static void SetCallbacks(EngineCallbacks engineCallbacksObject)
		{
			_callbacksObj = engineCallbacksObject;

			_pmove.Info_ValueForKey = _callbacksObj.CB_Info_ValueForKey;
			_pmove.Particle = _callbacksObj.CB_Particle;
			_pmove.TestPlayerPosition = _callbacksObj.CB_TestPlayerPosition;
			_pmove.Con_NPrintf = _callbacksObj.CB_Con_NPrintf;
			_pmove.Con_DPrintf = _callbacksObj.CB_Con_DPrintf;
			_pmove.Con_Printf = _callbacksObj.CB_Con_Printf;
			_pmove.Sys_FloatTime = _callbacksObj.CB_Sys_FloatTime;
			_pmove.StuckTouch = _callbacksObj.CB_StuckTouch;
			_pmove.PointContents = _callbacksObj.CB_PointContents;
			_pmove.TruePointContents = _callbacksObj.CB_TruePointContents;
			_pmove.HullPointContents = _callbacksObj.CB_HullPointContents;
			_pmove.PlayerTrace = _callbacksObj.CB_PlayerTrace;
			_pmove.TraceLine = _callbacksObj.CB_TraceLine;
			_pmove.RandomLong = _callbacksObj.CB_RandomLong;
			_pmove.RandomFloat = _callbacksObj.CB_RandomFloat;
			_pmove.GetModelType = _callbacksObj.CB_GetModelType;
			_pmove.GetModelBounds = _callbacksObj.CB_GetModelBounds;
			_pmove.HullForBSP = _callbacksObj.CB_HullForBSP;
			_pmove.TraceModel = _callbacksObj.CB_TraceModel;
			_pmove.COM_FileSize = _callbacksObj.CB_COM_FileSize;
			_pmove.COM_LoadFile = _callbacksObj.CB_COM_LoadFile;
			_pmove.COM_FreeFile = _callbacksObj.CB_COM_FreeFile;
			_pmove.memfgets = _callbacksObj.CB_memfgets;
			_pmove.PlaySound = _callbacksObj.CB_PlaySound;
			_pmove.TraceTexture = _callbacksObj.CB_TraceTexture;
			_pmove.PlayBackEventFull = _callbacksObj.CB_PlayBackEventFull;
			_pmove.PlayerTraceEx = _callbacksObj.CB_PlayerTraceEx;
			_pmove.TestPlayerPositionEx = _callbacksObj.CB_TestPlayerPositionEx;
			_pmove.TraceLineEx = _callbacksObj.CB_TraceLineEx;
		}

		private static bool _initialised = false;
		private static EngineCallbacks _callbacksObj = null;
		private static Internal.PMPlayerMove _pmove = new Internal.PMPlayerMove();
	}
}
