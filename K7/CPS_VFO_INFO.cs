using System.Runtime.InteropServices;

namespace K7;

public struct CPS_VFO_INFO
{
	public uint rx_freq;

	public uint freq_diff;

	public byte tx_non_standard_1;

	public byte tx_non_standard_2;

	public byte rx_qt_type;

	public byte tx_qt_type;

	public byte freq_dir;

	public byte band;

	public byte step;

	public byte encypt;

	public byte power;

	public byte busy;

	public byte reverse;

	public byte dtmf_decdoe_flag;

	public byte pttid;

	public byte am;

	public byte resv5;

	public byte sq;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] resv6;

	public uint rx_qt;

	public uint tx_qt1;

	public uint scan_star;

	public uint scan_end;

	public uint tx_qt2;

	public byte signal;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] resv3;
}
