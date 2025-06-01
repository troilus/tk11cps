using System.Runtime.InteropServices;

namespace K7;

public struct CPS_NOAA_DECODE_ADDR
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] addr;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] info;
}
