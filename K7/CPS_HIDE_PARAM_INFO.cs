using System.Runtime.InteropServices;

namespace K7;

public struct CPS_HIDE_PARAM_INFO
{
	public byte resv5;

	public byte air_cps_retry;

	public byte kill_flag;

	public byte encrypt_flag;

	public byte noaa_tx_flag;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] resv6;

	public byte lock_freq_flag;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
	public byte[] resv1;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
	public byte[] band_enable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] resv2;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
	public byte[] band_tx_enable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] resv3;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
	public uint[] band_rx_start;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] resv4;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
	public uint[] band_rx_end;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] resv8;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
	public uint[] band_tx_start;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] resv9;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
	public uint[] band_tx_end;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] resv7;

	public short MwSwAgc_period;

	public short MwSwAgc_step;

	public short MwSwAgc_LowerLimit;

	public short MwSwAgc_UpperLimit;

	public short MwSwAgc_gain;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public byte[] resv10;
}
