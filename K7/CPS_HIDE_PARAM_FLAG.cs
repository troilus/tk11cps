using System.Runtime.InteropServices;

namespace K7;

public struct CPS_HIDE_PARAM_FLAG
{
	public byte resv1;

	public byte cps_retry_time;

	public byte kill_flag;

	public byte encrypt_flag;

	public byte noaa_send_type;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] resv2;

	public byte lock_freq_flag;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
	public byte[] resv3;
}
