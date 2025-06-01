using System.Runtime.InteropServices;

namespace K7;

public struct CPS_VFO_QT_INFO
{
	public uint flag;

	public ushort lenght;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] resv1;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] qt_data;
}
