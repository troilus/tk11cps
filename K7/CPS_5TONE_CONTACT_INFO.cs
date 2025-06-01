using System.Runtime.InteropServices;

namespace K7;

public struct CPS_5TONE_CONTACT_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] name;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] id;
}
