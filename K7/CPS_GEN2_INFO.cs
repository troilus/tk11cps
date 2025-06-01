using System.Runtime.InteropServices;

namespace K7;

public struct CPS_GEN2_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public byte[] revs2;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] dtmf_kill;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] dtmf_wakeup;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] _5tone_kill;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] _5tone_wakeup;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] revs3;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] device_name;
}
