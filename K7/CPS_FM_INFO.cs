using System.Runtime.InteropServices;

namespace K7;

public struct CPS_FM_INFO
{
	public ushort vfo_freq;

	public byte mr_idx;

	public byte mr_vfo_flag;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] resv1;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public ushort[] freq;
}
