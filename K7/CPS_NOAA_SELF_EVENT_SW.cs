using System.Runtime.InteropServices;

namespace K7;

public struct CPS_NOAA_SELF_EVENT_SW
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	public byte[] flag;
}
