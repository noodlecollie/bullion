using System;
using System.Runtime.InteropServices;

namespace Bullion.PlayerMovement.Internal
{
	internal static class PMShared
	{
		[DllImport(Defs.DllName, CallingConvention = CallingConvention.Cdecl)]
		internal static extern void PM_Init(ref PMPlayerMove pmove);

		[DllImport(Defs.DllName, CallingConvention = CallingConvention.Cdecl)]
		internal static extern void PM_Move(ref PMPlayerMove pmove, int server);

		[DllImport(Defs.DllName, CallingConvention = CallingConvention.Cdecl)]
		internal static extern char PM_FindTextureType([MarshalAs(UnmanagedType.LPStr)] string name);
	}

	internal static class PMDebug
	{
		[DllImport(Defs.DllName, CallingConvention = CallingConvention.Cdecl)]
		internal static extern void PM_ViewEntity();

		[DllImport(Defs.DllName, CallingConvention = CallingConvention.Cdecl)]
		internal static extern void PM_DrawBBox(
			[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] mins,
			[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] maxs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] origin,
			int pcolor,
			float life);

		[DllImport(Defs.DllName, CallingConvention = CallingConvention.Cdecl)]
		internal static extern void PM_ParticleLine(
			[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] start,
			[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] float[] end,
			int pcolor,
			float life,
			float vert);

		[DllImport(Defs.DllName, CallingConvention = CallingConvention.Cdecl)]
		internal static extern void PM_ShowClipBox();
	}
}
