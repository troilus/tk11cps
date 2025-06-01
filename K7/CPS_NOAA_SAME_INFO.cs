using System.Runtime.InteropServices;

namespace K7;

public struct CPS_NOAA_SAME_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] same;
}
