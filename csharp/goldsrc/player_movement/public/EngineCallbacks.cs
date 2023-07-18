using System;
using System.Runtime.InteropServices;

namespace Bullion.PlayerMovement
{
	public class EngineCallbacks
	{
		internal IntPtr CB_Info_ValueForKey(IntPtr str, string key)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_Info_ValueForKey");
			Console.WriteLine($"TRACE:   str = {str}");
			Console.WriteLine($"TRACE:   key = {key}");
			Console.WriteLine($"TRACE: END CB_Info_ValueForKey");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return IntPtr.Zero;
		}

		internal void CB_Particle([In] float[] origin, float life, int zpos, int zvel)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_Particle");
			Console.WriteLine($"TRACE:   origin = {origin}");
			Console.WriteLine($"TRACE:   life = {life}");
			Console.WriteLine($"TRACE:   zpos = {zpos}");
			Console.WriteLine($"TRACE:   zvel = {zvel}");
			Console.WriteLine($"TRACE: END CB_Particle");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
		}

		internal int CB_TestPlayerPosition([In] float[] pos, [Out] Internal.PMTrace trace)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_TestPlayerPosition");
			Console.WriteLine($"TRACE:   pos = {pos}");
			Console.WriteLine($"TRACE:   trace = {trace}");
			Console.WriteLine($"TRACE: END CB_TestPlayerPosition");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			trace = new Internal.PMTrace();
			return 0;
		}

		internal void CB_Con_NPrintf(int idx, string fmt, IntPtr argAddresses)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_Con_NPrintf");
			Console.WriteLine($"TRACE:   idx = {idx}");
			Console.WriteLine($"TRACE:   fmt = {fmt}");
			Console.WriteLine($"TRACE:   argAddresses = {argAddresses}");
			Console.WriteLine($"TRACE: END CB_Con_NPrintf");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
		}

		internal void CB_Con_DPrintf(string fmt, IntPtr argAddresses)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_Con_DPrintf");
			Console.WriteLine($"TRACE:   fmt = {fmt}");
			Console.WriteLine($"TRACE:   argAddresses = {argAddresses}");
			Console.WriteLine($"TRACE: END CB_Con_DPrintf");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
		}

		internal void CB_Con_Printf(string fmt, IntPtr argAddresses)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_Con_Printf");
			Console.WriteLine($"TRACE:   fmt = {fmt}");
			Console.WriteLine($"TRACE:   argAddresses = {argAddresses}");
			Console.WriteLine($"TRACE: END CB_Con_Printf");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
		}

		internal double CB_Sys_FloatTime()
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_Sys_FloatTime");
			Console.WriteLine($"TRACE: END CB_Sys_FloatTime");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return 0.0;
		}

		internal void CB_StuckTouch(int hitent, [Out] Internal.PMTrace traceresult)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_StuckTouch");
			Console.WriteLine($"TRACE:   hitent = {hitent}");
			Console.WriteLine($"TRACE:   traceresult = {traceresult}");
			Console.WriteLine($"TRACE: END CB_StuckTouch");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			traceresult = new Internal.PMTrace();
		}

		internal int CB_PointContents([In] float[] point, IntPtr truecontents)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_PointContents");
			Console.WriteLine($"TRACE:   point = {point}");
			Console.WriteLine($"TRACE:   truecontents = {truecontents}");
			Console.WriteLine($"TRACE: END CB_PointContents");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return 0;
		}

		internal int CB_TruePointContents([In] float[] point)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_TruePointContents");
			Console.WriteLine($"TRACE:   point = {point}");
			Console.WriteLine($"TRACE: END CB_TruePointContents");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return 0;
		}

		internal int CB_HullPointContents(ref Internal.PMHull hull, int num, [In] float[] point)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_HullPointContents");
			Console.WriteLine($"TRACE:   hull = {hull}");
			Console.WriteLine($"TRACE:   num = {num}");
			Console.WriteLine($"TRACE:   point = {point}");
			Console.WriteLine($"TRACE: END CB_HullPointContents");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return 0;
		}

		internal Internal.PMTrace CB_PlayerTrace([In] float[] start, [In] float[] end)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_PlayerTrace");
			Console.WriteLine($"TRACE:   start = {start}");
			Console.WriteLine($"TRACE:   end = {end}");
			Console.WriteLine($"TRACE: END CB_PlayerTrace");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return new Internal.PMTrace();
		}

		internal IntPtr CB_TraceLine([In] float[] start, [In] float[] end, int flags, int usehull, int ignore_pe)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_TraceLine");
			Console.WriteLine($"TRACE:   start = {start}");
			Console.WriteLine($"TRACE:   end = {end}");
			Console.WriteLine($"TRACE:   flags = {flags}");
			Console.WriteLine($"TRACE:   usehull = {usehull}");
			Console.WriteLine($"TRACE:   ignore_pe = {ignore_pe}");
			Console.WriteLine($"TRACE: END CB_TraceLine");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return IntPtr.Zero;
		}

		internal int CB_RandomLong(int low, int high)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_RandomLong");
			Console.WriteLine($"TRACE:   low = {low}");
			Console.WriteLine($"TRACE:   high = {high}");
			Console.WriteLine($"TRACE: END CB_RandomLong");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return 0;
		}

		internal float CB_RandomFloat(float low, float high)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_RandomFloat");
			Console.WriteLine($"TRACE:   low = {low}");
			Console.WriteLine($"TRACE:   high = {high}");
			Console.WriteLine($"TRACE: END CB_RandomFloat");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return 0.0f;
		}

		internal int CB_GetModelType(IntPtr model)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_GetModelType");
			Console.WriteLine($"TRACE:   model = {model}");
			Console.WriteLine($"TRACE: END CB_GetModelType");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return 0;
		}

		internal void CB_GetModelBounds(IntPtr model, [Out] float[] mins, [Out] float[] maxs)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_GetModelBounds");
			Console.WriteLine($"TRACE:   model = {model}");
			Console.WriteLine($"TRACE:   mins = {mins}");
			Console.WriteLine($"TRACE:   maxs = {maxs}");
			Console.WriteLine($"TRACE: END CB_GetModelBounds");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			mins[0] = 0.0f;
			mins[1] = 0.0f;
			mins[2] = 0.0f;
		}

		internal IntPtr CB_HullForBSP([In] Internal.PMPhysEnt physEnt, [Out] float[] offset)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_HullForBSP");
			Console.WriteLine($"TRACE:   physEnt = {physEnt}");
			Console.WriteLine($"TRACE:   offset = {offset}");
			Console.WriteLine($"TRACE: END CB_HullForBSP");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

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
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_TraceModel");
			Console.WriteLine($"TRACE:   physEnt = {physEnt}");
			Console.WriteLine($"TRACE:   start = {start}");
			Console.WriteLine($"TRACE:   end = {end}");
			Console.WriteLine($"TRACE:   trace = {trace}");
			Console.WriteLine($"TRACE: END CB_TraceModel");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			trace = new Internal.PMTrace();
			return 0.0f;
		}

		internal int CB_COM_FileSize([MarshalAs(UnmanagedType.LPStr)] string filename)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_COM_FileSize");
			Console.WriteLine($"TRACE:   filename = {filename}");
			Console.WriteLine($"TRACE: END CB_COM_FileSize");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return 0;
		}

		internal IntPtr CB_COM_LoadFile([MarshalAs(UnmanagedType.LPStr)] string path, int usehunk, IntPtr length)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_COM_LoadFile");
			Console.WriteLine($"TRACE:   path = {path}");
			Console.WriteLine($"TRACE:   usehunk = {usehunk}");
			Console.WriteLine($"TRACE:   length = {length}");
			Console.WriteLine($"TRACE: END CB_COM_LoadFile");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return IntPtr.Zero;
		}

		internal void CB_COM_FreeFile(IntPtr buffer)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_COM_FreeFile");
			Console.WriteLine($"TRACE:   buffer = {buffer}");
			Console.WriteLine($"TRACE: END CB_COM_FreeFile");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
		}

		internal IntPtr CB_memfgets(
			IntPtr memFile,
			int fileSize,
			[Out] int filePos,
			[Out, MarshalAs(UnmanagedType.LPArray)] byte[] buffer,
			int bufferSize)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_memfgets");
			Console.WriteLine($"TRACE:   memFile = {memFile}");
			Console.WriteLine($"TRACE:   fileSize = {fileSize}");
			Console.WriteLine($"TRACE:   filePos = {filePos}");
			Console.WriteLine($"TRACE:   buffer = {buffer}");
			Console.WriteLine($"TRACE:   bufferSize = {bufferSize}");
			Console.WriteLine($"TRACE: END CB_memfgets");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

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
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_PlaySound");
			Console.WriteLine($"TRACE:   channel = {channel}");
			Console.WriteLine($"TRACE:   sample = {sample}");
			Console.WriteLine($"TRACE:   volume = {volume}");
			Console.WriteLine($"TRACE:   attenuation = {attenuation}");
			Console.WriteLine($"TRACE:   flags = {flags}");
			Console.WriteLine($"TRACE:   pitch = {pitch}");
			Console.WriteLine($"TRACE: END CB_PlaySound");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
		}

		internal IntPtr CB_TraceTexture(int ground, [In] float[] start, [In] float[] end)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_TraceTexture");
			Console.WriteLine($"TRACE:   ground = {ground}");
			Console.WriteLine($"TRACE:   start = {start}");
			Console.WriteLine($"TRACE:   end = {end}");
			Console.WriteLine($"TRACE: END CB_TraceTexture");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

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
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_PlayBackEventFull");
			Console.WriteLine($"TRACE:   flags = {flags}");
			Console.WriteLine($"TRACE:   clientindex = {clientindex}");
			Console.WriteLine($"TRACE:   eventindex = {eventindex}");
			Console.WriteLine($"TRACE:   delay = {delay}");
			Console.WriteLine($"TRACE:   origin = {origin}");
			Console.WriteLine($"TRACE:   angles = {angles}");
			Console.WriteLine($"TRACE:   fparam1 = {fparam1}");
			Console.WriteLine($"TRACE:   fparam2 = {fparam2}");
			Console.WriteLine($"TRACE:   iparam1 = {iparam1}");
			Console.WriteLine($"TRACE:   iparam2 = {iparam2}");
			Console.WriteLine($"TRACE:   bparam1 = {bparam1}");
			Console.WriteLine($"TRACE:   bparam2 = {bparam2}");
			Console.WriteLine($"TRACE: END CB_PlayBackEventFull");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
		}

		internal Internal.PMTrace CB_PlayerTraceEx(
			[In] float[] start,
			[In] float[] end,
			int traceFlags,
			[MarshalAs(UnmanagedType.FunctionPtr)] Internal.PMDelegate_IgnoreEnt ignore)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_PlayerTraceEx");
			Console.WriteLine($"TRACE:   start = {start}");
			Console.WriteLine($"TRACE:   end = {end}");
			Console.WriteLine($"TRACE:   traceFlags = {traceFlags}");
			Console.WriteLine($"TRACE:   ignore = {ignore}");
			Console.WriteLine($"TRACE: END CB_PlayerTraceEx");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return new Internal.PMTrace();
		}

		internal int CB_TestPlayerPositionEx(
			[In] float[] pos,
			[Out] Internal.PMTrace trace,
			[MarshalAs(UnmanagedType.FunctionPtr)] Internal.PMDelegate_IgnoreEnt ignore)
		{
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_TestPlayerPositionEx");
			Console.WriteLine($"TRACE:   pos = {pos}");
			Console.WriteLine($"TRACE:   trace = {trace}");
			Console.WriteLine($"TRACE:   ignore = {ignore}");
			Console.WriteLine($"TRACE: END CB_TestPlayerPositionEx");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

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
			#if GOLDSRC_PLAYERMOVEMENT_TRACE
			Console.WriteLine($"TRACE: BEGIN CB_TraceLineEx");
			Console.WriteLine($"TRACE:   start = {start}");
			Console.WriteLine($"TRACE:   end = {end}");
			Console.WriteLine($"TRACE:   flags = {flags}");
			Console.WriteLine($"TRACE:   usehull = {usehull}");
			Console.WriteLine($"TRACE:   ignore = {ignore}");
			Console.WriteLine($"TRACE: END CB_TraceLineEx");
			#endif // GOLDSRC_PLAYERMOVEMENT_TRACE

			// TODO
			return IntPtr.Zero;
		}
	}
}
