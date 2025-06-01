using System.Runtime.InteropServices;

namespace K7;

public struct CPS_GEN_INFO
{
	public byte chn_AB;

	public byte Noaa_sq;

	public byte tx_tot;

	public byte NoaaScan;

	public byte keylock;

	public byte vox_sw;

	public byte vox_lvl;

	public byte mic;

	public byte FreqModeFlag;

	public byte ChnDispMode;

	public byte MwSw;

	public byte pwrsave;

	public byte dualwatch;

	public byte autobacklight;

	public ushort call_ch;

	public byte beep;

	public byte key_short1;

	public byte key_long1;

	public byte key_short2;

	public byte key_long2;

	public byte scan_mode;

	public byte auto_lock;

	public byte pwron_disp_sel;

	public byte alarm_mode;

	public byte roger_tone;

	public byte repeater_tail;

	public byte tail_tone;

	public byte denoise_sw;

	public byte denoise_lvl;

	public byte transpositional_sw;

	public byte transpositional_lvl;

	public byte chn_A_volume;

	public byte chn_B_volume;

	public byte key_tone_flag;

	public byte language;

	public byte NoaaSameDecode;

	public byte NoaaSameEvent;

	public byte NoaaSame_Addr;

	public byte resv2;

	public byte sbar;

	public byte brightness;

	public byte kill_flag;

	public byte dtmf_side_tone;

	public byte dtmf_decode_rspn;

	public byte match_tot;

	public byte match_qt_mode;

	public byte match_dcs_bit;

	public byte match_threshold;

	public byte resv4;

	public ushort CWPitchFreq;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] resv3;

	public ushort dtmf_separator;

	public ushort dtmf_group_code;

	public byte dtmf_reset_time;

	public byte dtmf_resv4;

	public ushort dtmf_carry_time;

	public ushort dtmf_first_code_time;

	public ushort dtmf_D_code_time;

	public ushort dtmf_single_continue_time;

	public ushort dtmf_single_interval_time;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] dtmf_id;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] dtmf_UpCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] dtmf_DnCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] resv5;

	public ushort _5tone_separator;

	public ushort _5tone_group_code;

	public byte _5tonef_reset_time;

	public byte _5tone_resv4;

	public ushort _5tone_carry_time;

	public ushort _5tone_first_code_time;

	public byte _5tone_protocol;

	public byte _5tone_resv1;

	public ushort _5tone_single_continue_time;

	public ushort _5tone_single_interval_time;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] _5tone_id;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] _5tone_UpCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] _5tone_DnCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
	public ushort[] _5tone_user_freq;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] _5tone_revs5;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] logo_string1;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] logo_string2;
}
