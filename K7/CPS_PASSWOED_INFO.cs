using System.Runtime.InteropServices;

namespace K7;

public struct CPS_PASSWOED_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] pass_word;
}
