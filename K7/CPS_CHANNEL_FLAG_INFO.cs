using System.Runtime.InteropServices;

namespace K7;

public struct CPS_CHANNEL_FLAG_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 999)]
	public byte[] flag;
}
