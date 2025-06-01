using System.Runtime.InteropServices;

namespace K7;

public struct CPS_PWRON_PASSWOED_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public byte[] pass_word;
}
