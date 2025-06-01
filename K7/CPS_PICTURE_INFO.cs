using System.Runtime.InteropServices;

namespace K7;

public struct CPS_PICTURE_INFO
{
	public uint flag;

	public ushort lenght;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] resv1;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bmp_data;
}
