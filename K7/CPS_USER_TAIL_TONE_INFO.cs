using System.Runtime.InteropServices;

namespace K7;

public struct CPS_USER_TAIL_TONE_INFO
{
	public uint flag;

	public ushort lenght;

	public byte voice_type;

	public byte timer;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16376)]
	public byte[] pcm_data;
}
