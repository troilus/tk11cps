using System.Runtime.InteropServices;

namespace K7;

public struct CPS_DTMF_CONTACT_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] name;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] id;
}
