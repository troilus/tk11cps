using System.Runtime.InteropServices;

namespace K7;

public struct CPS_NOAA_EVENT
{
	public int seq;

	public byte number;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] resv3;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] duration;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] date;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] event_befor_org;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] event_current_org;
}
