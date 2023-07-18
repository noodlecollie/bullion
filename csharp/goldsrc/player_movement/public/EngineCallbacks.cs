using System;
using System.Runtime.InteropServices;

namespace Bullion.PlayerMovement
{
	public class EngineCallbacks
	{
		internal IntPtr CB_Info_ValueForKey(IntPtr str, string key)
		{
			// TODO
			return IntPtr.Zero;
		}

		internal void CB_Particle([In] float[] origin, float life, int zpos, int zvel)
		{
			// TODO
		}

		internal int CB_TestPlayerPosition([In] float[] pos, [Out] Internal.PMTrace trace)
		{
			// TODO
			trace = new Internal.PMTrace();
			return 0;
		}

		internal void CB_Con_NPrintf(int idx, string fmt, IntPtr argAddresses)
		{
			// TODO
		}

		internal void CB_Con_DPrintf(string fmt, IntPtr argAddresses)
		{
			// TODO
		}

		internal void CB_Con_Printf(string fmt, IntPtr argAddresses)
		{
			// TODO
		}

		internal double CB_Sys_FloatTime()
		{
			// TODO
			return 0.0;
		}

		internal void CB_StuckTouch(int hitent, [Out] Internal.PMTrace traceresult)
		{
			// TODO
			traceresult = new Internal.PMTrace();
		}

		internal int CB_PointContents([In] float[] point, IntPtr truecontents)
		{
			// TODO
			return 0;
		}

		internal int CB_TruePointContents([In] float[] point)
		{
			// TODO
			return 0;
		}

		internal int CB_HullPointContents(ref Internal.PMHull hull, int num, [In] float[] point)
		{
			// TODO
			return 0;
		}

		internal Internal.PMTrace CB_PlayerTrace([In] float[] start, [In] float[] end)
		{
			// TODO
			return new Internal.PMTrace();
		}

		internal IntPtr CB_TraceLine([In] float[] start, [In] float[] end, int flags, int usehull, int ignore_pe)
		{
			// TODO
			return IntPtr.Zero;
		}

		internal int CB_RandomLong(int low, int high)
		{
			// TODO
			return 0;
		}

		internal float CB_RandomFloat(float low, float high)
		{
			// TODO
			return 0.0f;
		}

		internal int CB_GetModelType(IntPtr model)
		{
			// TODO
			return 0;
		}

		internal void CB_GetModelBounds(IntPtr model, [Out] float[] mins, [Out] float[] maxs)
		{
			// TODO
			mins[0] = 0.0f;
			mins[1] = 0.0f;
			mins[2] = 0.0f;
		}

		internal IntPtr CB_HullForBSP([In] Internal.PMPhysEnt physEnt, [Out] float[] offset)
		{
			// TODO
			offset[0] = 0.0f;
			offset[1] = 0.0f;
			offset[2] = 0.0f;
			return IntPtr.Zero;
		}

		internal float CB_TraceModel(
			[In] Internal.PMPhysEnt physEnt,
			[In] float[] start,
			[In] float[] end,
			[Out] Internal.PMTrace trace)
		{
			// TODO
			trace = new Internal.PMTrace();
			return 0.0f;
		}

		internal int CB_COM_FileSize([MarshalAs(UnmanagedType.LPStr)] string filename)
		{
			// TODO
			return 0;
		}

		internal IntPtr CB_COM_LoadFile([MarshalAs(UnmanagedType.LPStr)] string path, int usehunk, IntPtr length)
		{
			// TODO
			return IntPtr.Zero;
		}

		internal void CB_COM_FreeFile(IntPtr buffer)
		{
			// TODO
		}

		internal IntPtr CB_memfgets(
			IntPtr memFile,
			int fileSize,
			[Out] int filePos,
			[Out, MarshalAs(UnmanagedType.LPArray)] byte[] buffer,
			int bufferSize)
		{
			// TODO
			filePos = 0;
			return IntPtr.Zero;
		}

		internal void CB_PlaySound(
			int channel,
			[MarshalAs(UnmanagedType.LPStr)] string sample,
			float volume,
			float attenuation,
			int flags,
			int pitch)
		{
			// TODO
		}

		internal IntPtr CB_TraceTexture(int ground, [In] float[] start, [In] float[] end)
		{
			// TODO
			return IntPtr.Zero;
		}

		internal void CB_PlayBackEventFull(
			int flags,
			int clientindex,
			ushort eventindex,
			float delay,
			[In] float[] origin,
			[In] float[] angles,
			float fparam1,
			float fparam2,
			int iparam1,
			int iparam2,
			int bparam1,
			int bparam2)
		{
			// TODO
		}

		internal Internal.PMTrace CB_PlayerTraceEx(
			[In] float[] start,
			[In] float[] end,
			int traceFlags,
			[MarshalAs(UnmanagedType.FunctionPtr)] Internal.PMDelegate_IgnoreEnt ignore)
		{
			// TODO
			return new Internal.PMTrace();
		}

		internal int CB_TestPlayerPositionEx(
			[In] float[] pos,
			[Out] Internal.PMTrace trace,
			[MarshalAs(UnmanagedType.FunctionPtr)] Internal.PMDelegate_IgnoreEnt ignore)
		{
			// TODO
			trace = new Internal.PMTrace();
			return 0;
		}

		internal IntPtr CB_TraceLineEx(
			[In] float[] start,
			[In] float[] end,
			int flags,
			int usehull,
			[MarshalAs(UnmanagedType.FunctionPtr)] Internal.PMDelegate_IgnoreEnt ignore)
		{
			// TODO
			return IntPtr.Zero;
		}
	}
}
