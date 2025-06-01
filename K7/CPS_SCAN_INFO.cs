using System.Runtime.InteropServices;

namespace K7;

public struct CPS_SCAN_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] name;

	public ushort prio_1;

	public ushort prio_2;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] resv1;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public ushort[] channel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] resv2;
}
