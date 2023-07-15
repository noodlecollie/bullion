using System;
using System.Runtime.InteropServices;

namespace Bullion.PlayerMovement
{
	internal static class PMShared
	{
		[DllImport(Defs.DllName, CallingConvention = CallingConvention.Cdecl)]
		internal static extern void PM_Init(ref PMPlayerMove pmove);
		internal static extern void PM_Move(ref PMPlayerMove pmove, int server);
		internal static extern Int8 PM_FindTextureType([MarshalAs(UnmanagedType.LPStr)] string name);
	}
}
