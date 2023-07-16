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
}
