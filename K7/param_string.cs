using System.Collections.Generic;

namespace K7;

internal class param_string
{
	public static string[] NOAA_SAME_EVENT_LIST = new string[154]
	{
		"ADR", "Administrative Message       ", "AVA", "Avalanche Watch              ", "AVW", "Avalanche Warning            ", "BLU", "Blue Alert                   ", "BWW", "Boil Water Warning           ",
		"BZW", "Blizzard Warning             ", "CAE", "Child Abduction Emergency    ", "CDW", "Civil Danger Warning         ", "CEM", "Civil Emergency Message      ", "CFA", "Coastal Flood Watch          ",
		"CFW", "Coastal Flood Warning        ", "DBA", "DAM Watch                   ", "DMO", "Practice/Demo Warning        ", "DSW", "Dust Storm Warning           ", "EAN", "Emergency Action Notification",
		"EQW", "Civil Earthquake Warning     ", "EVA", "Evacuation Watch             ", "EVI", "Evacuation Immediate         ", "EWW", "Extreme Wind Warning         ", "FFA", "Flash Flood Watch            ",
		"FFS", "Flash Flood Statement        ", "FFW", "Flash Flood Warning          ", "FLA", "Flood Watch                  ", "FLS", "Flood Statement              ", "FLW", "Flood Warning                ",
		"FRW", "Fire Warning                 ", "FSW", "Flash Freeze Warning         ", "FZW", "Freeze Warning               ", "HLS", "Hurricane Statement          ", "HMW", "Hazardous Materials Warning  ",
		"HUA", "Hurricane Watch              ", "HUW", "Hurricane Warning            ", "HWA", "High Wind Watch              ", "HWW", "High Wind Warning            ", "IBW", "Iceberg Warning              ",
		"LAE", "Local Area Emergency         ", "LEW", "Law Enforcement Warning      ", "NAT", "National Audible Test        ", "NIC", "National Information Center  ", "NMN", "Network Message Notification ",
		"NPT", "National Periodic Test       ", "NST", "National Silent Test         ", "NUW", "Nuclear Power Plant Warning  ", "POS", "Power Outage Advisory        ", "RHW", "Radiological Hazard Warning  ",
		"RMT", "Required Monthly Test        ", "RWT", "Required Weekly Test         ", "SMW", "Special Marine Warning       ", "SPS", "Special Weather Statement    ", "SPW", "Shelter In Place Warning     ",
		"SQW", "Snow Squall Warning          ", "SSA", "Storm Surge Watch            ", "SSW", "Storm Surge Warning          ", "SVA", "Severe Thunderstorm Watch    ", "SVR", "Severe Thunderstorm Warning  ",
		"SVS", "Severe Weather Statement     ", "TOA", "Tornado Watch                ", "TOE", "911 Telephone Outage Emergency", "TOW", "Tornado Warning              ", "TRA", "Tropical Storm Watch         ",
		"TRW", "Tropical Storm Warning       ", "TSA", "Tsunami Watch                ", "TSW", "Tsunami Warning              ", "TXB", "Transmitter Backup On        ", "TXF", "Transmitter Carrier Off      ",
		"TXO", "Transmitter Carrier On       ", "TXP", "Transmitter Primary On       ", "VOW", "Volcano Warning              ", "WFA", "Wild Fire Watch              ", "WFW", "Wild Fire Warning            ",
		"WSA", "Winter Storm Watch           ", "WSW", "Winter Storm Warning         ", "", "Unrecognized Warning         ", "", "Unrecognized Watch           ", "", "Unrecognized Emergency       ",
		"", "Unrecognized Statement       ", "", "Unrecognized Message         "
	};

	public static readonly string[] CtcssString = new string[51]
	{
		"63.0", "67.0", "69.3", "71.9", "74.4", "77.0", "79.7", "82.5", "85.4", "88.5",
		"91.5", "94.8", "97.4", "100.0", "103.5", "107.2", "110.9", "114.8", "118.8", "123.0",
		"127.3", "131.8", "136.5", "141.3", "146.2", "151.4", "156.7", "159.8", "162.2", "165.5",
		"167.9", "171.3", "173.8", "177.3", "179.9", "183.5", "186.2", "189.9", "192.8", "196.6",
		"199.5", "203.5", "206.5", "210.7", "218.1", "225.7", "229.1", "233.6", "241.8", "250.3",
		"254.1"
	};

	public static readonly string[] DcsString = new string[107]
	{
		"017", "023", "025", "026", "031", "032", "036", "043", "047", "050",
		"051", "053", "054", "065", "071", "072", "073", "074", "114", "115",
		"116", "122", "125", "131", "132", "134", "143", "145", "152", "155",
		"156", "162", "165", "172", "174", "205", "212", "223", "225", "226",
		"243", "244", "245", "246", "251", "252", "255", "261", "263", "265",
		"266", "271", "274", "306", "311", "315", "325", "331", "332", "343",
		"346", "351", "356", "364", "365", "371", "411", "412", "413", "423",
		"431", "432", "445", "446", "452", "454", "455", "462", "464", "465",
		"466", "503", "506", "516", "523", "526", "532", "546", "565", "606",
		"612", "624", "627", "631", "632", "645", "654", "662", "664", "703",
		"712", "723", "731", "732", "734", "743", "754"
	};

	public static double[] freq_rang = new double[26]
	{
		0.153, 1.8, 1.8, 18.0, 18.0, 32.0, 32.0, 76.0, 108.0, 136.0,
		136.0, 174.0, 174.0, 350.0, 350.0, 400.0, 400.0, 470.0, 470.0, 580.0,
		580.0, 760.0, 760.0, 1000.0, 1000.0, 1160.0
	};

	public static string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	public static List<string> chn_freq_rang_Items()
	{
		List<string> list = new List<string>();
		list.Add("150K-1.8M");
		list.Add("1.8M-18M");
		list.Add("18M-32M");
		list.Add("32M-76M");
		list.Add("108M-136M");
		list.Add("136M-174M");
		list.Add("174M-350M");
		list.Add("350M-400M");
		list.Add("400M-470M");
		list.Add("470M-580M");
		list.Add("580M-760M");
		list.Add("760M-1000M");
		list.Add("1000M-1160M");
		return list;
	}

	public static List<string> chn_power_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("low"));
		list.Add(GetLang("mid"));
		list.Add(GetLang("high"));
		return list;
	}

	public static List<string> chn_MSW_Items()
	{
		List<string> list = new List<string>();
		list.Add("2K");
		list.Add("2.5K");
		list.Add("3K");
		list.Add("3.5K");
		list.Add("4K");
		list.Add("4.5K");
		list.Add("5K");
		list.Add("5.5K");
		return list;
	}

	public static List<string> chn_band_Items()
	{
		List<string> list = new List<string>();
		list.Add("25K");
		list.Add("12.5K");
		return list;
	}

	public static List<string> chn_on_off_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		list.Add(GetLang("on"));
		return list;
	}

	public static List<string> chn_pttid_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		list.Add(GetLang("start"));
		list.Add(GetLang("end"));
		list.Add(GetLang("start_end"));
		return list;
	}

	public static List<string> chn_normal_qttype_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("_null"));
		list.Add(GetLang("qt_ctc"));
		list.Add(GetLang("qt_ndcs"));
		list.Add(GetLang("qt_idcs"));
		return list;
	}

	public static List<string> chn_demode_Items()
	{
		List<string> list = new List<string>();
		list.Add("FM");
		list.Add("AM");
		list.Add("LSB");
		list.Add("USB");
		list.Add("CW");
		return list;
	}

	public static List<string> chn_qttype_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("_null"));
		list.Add(GetLang("qt_ctc"));
		list.Add(GetLang("qt_ndcs"));
		list.Add(GetLang("qt_idcs"));
		list.Add(GetLang("qt_23bit"));
		list.Add(GetLang("qt_24bit"));
		list.Add(GetLang("qt_hopping"));
		list.Add(GetLang("qt_Self_learning"));
		return list;
	}

	public static List<string> chn_encypt_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		for (int i = 1; i <= 10; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> chn_scanlist_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("_null"));
		for (int i = 1; i <= 32; i++)
		{
			list.Add(i.ToString());
		}
		list.Add(GetLang("scan_all"));
		return list;
	}

	public static List<string> chn_scanlist1_Items()
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= 32; i++)
		{
			list.Add(i.ToString());
		}
		list.Add(GetLang("scan_all"));
		list.Add(GetLang("_null"));
		return list;
	}

	public static List<string> dtmf_split_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("_null"));
		string[] collection = new string[6] { "A", "B", "C", "D", "*", "#" };
		list.AddRange(collection);
		return list;
	}

	public static List<string> dtmf_groupcode_Items()
	{
		List<string> list = new List<string>();
		string[] collection = new string[6] { "A", "B", "C", "D", "*", "#" };
		list.AddRange(collection);
		return list;
	}

	public static List<string> dtmf_reset_Items()
	{
		List<string> list = new List<string>();
		for (int i = 5; i <= 60; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> dtmf_Preload_Items()
	{
		List<string> list = new List<string>();
		for (int i = 30; i <= 1000; i += 10)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> dtmf_rsp_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		list.Add(GetLang("remind"));
		list.Add(GetLang("reply"));
		list.Add(GetLang("remind_reply"));
		return list;
	}

	public static List<string> gen_A_MR_VFO_Items()
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= 999; i++)
		{
			list.Add("CH-" + i.ToString("00"));
		}
		for (int i = 1; i <= 13; i++)
		{
			list.Add("A-F" + i.ToString("00"));
		}
		return list;
	}

	public static List<string> gen_B_MR_VFO_Items()
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= 999; i++)
		{
			list.Add("CH-" + i.ToString("00"));
		}
		for (int i = 1; i <= 13; i++)
		{
			list.Add("B-F" + i.ToString("00"));
		}
		return list;
	}

	public static List<string> gen_main_A_MR_VFO_Items()
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= 11; i++)
		{
			list.Add("A-F" + i.ToString("00"));
		}
		for (int i = 1; i <= 999; i++)
		{
			list.Add("CH-" + i.ToString("00"));
		}
		return list;
	}

	public static List<string> gen_main_B_MR_VFO_Items()
	{
		List<string> list = new List<string>();
		for (int i = 5; i <= 10; i++)
		{
			list.Add("B-F" + i.ToString("00"));
		}
		for (int i = 12; i <= 13; i++)
		{
			list.Add("B-F" + i.ToString("00"));
		}
		for (int i = 1; i <= 999; i++)
		{
			list.Add("CH-" + i.ToString("00"));
		}
		return list;
	}

	public static List<string> gen_main_chn_Items()
	{
		List<string> list = new List<string>();
		list.Add("A");
		list.Add("B");
		return list;
	}

	public static List<string> gen_VFO_MR_Items()
	{
		List<string> list = new List<string>();
		list.Add("VFO");
		list.Add("MR");
		return list;
	}

	public static List<string> gen_sq_Items()
	{
		List<string> list = new List<string>();
		for (int i = 0; i <= 9; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> gen_tot_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		for (int i = 1; i <= 10; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> gen_autobacklight_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		for (int i = 1; i <= 5; i++)
		{
			list.Add(i.ToString());
		}
		for (int i = 10; i <= 30; i += 5)
		{
			list.Add(i.ToString());
		}
		list.Add(GetLang("backligth_alwayon"));
		return list;
	}

	public static List<string> gen_keylock_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("unlock"));
		list.Add(GetLang("_lock"));
		return list;
	}

	public static List<string> gen_vox_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		for (int i = 1; i <= 10; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> gen_mic_Items()
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= 5; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> gen_repeater_tail_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		for (int i = 100; i <= 1000; i += 100)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> gen_chn_volume_Items()
	{
		List<string> list = new List<string>();
		list.Add("A_0%-B_100%");
		list.Add("A_33%-B_100%");
		list.Add("A_66%-B_100%");
		list.Add("A_100%-B_100%");
		list.Add("A_100%-B_66%");
		list.Add("A_100%-B_33%");
		list.Add("A_100%-B_0%");
		return list;
	}

	public static List<string> gen_chnA_volume_Items()
	{
		List<string> list = new List<string>();
		list.Add("A_0%-B_100%");
		list.Add("A_33%-B_100%");
		list.Add("A_66%-B_100%");
		list.Add("A_100%-B_100%");
		return list;
	}

	public static List<string> gen_chnB_volume_Items()
	{
		List<string> list = new List<string>();
		list.Add("A_100%-B_0%");
		list.Add("A_100%-B_33%");
		list.Add("A_100%-B_66%");
		return list;
	}

	public static List<string> gen_pwron_disp_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_fullscreen"));
		list.Add(GetLang("gen_welcome"));
		list.Add(GetLang("gen_battery_voltage"));
		list.Add(GetLang("gen_pictrue"));
		list.Add(GetLang("_null"));
		return list;
	}

	public static List<string> gen_chn_disp_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_disp_freq"));
		list.Add(GetLang("gen_disp_id"));
		list.Add(GetLang("gen_disp_name"));
		return list;
	}

	public static List<string> gen_tx_chn_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		list.Add(GetLang("gen_tx_chnA"));
		list.Add(GetLang("gen_tx_chnB"));
		return list;
	}

	public static List<string> gen_power_save_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		list.Add("1:1");
		list.Add("1:2");
		list.Add("1:3");
		list.Add("1:4");
		return list;
	}

	public static List<string> gen_scan_mode_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_to"));
		list.Add(GetLang("gen_co"));
		list.Add(GetLang("gen_se"));
		return list;
	}

	public static List<string> gen_talk_tail_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		list.Add(GetLang("gen_beep"));
		list.Add(GetLang("gen_mdc"));
		for (int i = 1; i <= 5; i++)
		{
			list.Add(GetLang("gen_user") + i);
		}
		return list;
	}

	public static List<string> gen_denoise_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		for (int i = 1; i <= 6; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> gen_lang_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_lang_CN"));
		list.Add(GetLang("gen_lang_EN"));
		return list;
	}

	public static List<string> gen_sidekey_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("_null"));
		list.Add(GetLang("gen_flashlight"));
		list.Add(GetLang("gen_power"));
		list.Add(GetLang("gen_monitor"));
		list.Add(GetLang("gen_scan"));
		list.Add(GetLang("gen_vox"));
		list.Add(GetLang("gen_alarm"));
		list.Add(GetLang("gen_fm"));
		list.Add(GetLang("gen_1750"));
		return list;
	}

	public static List<string> gen_SAME_event_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_default"));
		list.Add(GetLang("gen_all_on"));
		list.Add(GetLang("gen_all_off"));
		list.Add(GetLang("gen_user"));
		return list;
	}

	public static List<string> gen_SAME_address_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_single_addr"));
		list.Add(GetLang("gen_mul_addr"));
		list.Add(GetLang("gen_any_addr"));
		return list;
	}

	public static List<string> gen_signal_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_dtmf"));
		list.Add(GetLang("gen_5tone"));
		return list;
	}

	public static List<string> gen_match_tot_Items()
	{
		List<string> list = new List<string>();
		for (int i = 8; i <= 32; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> gen_match_mode_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_normal"));
		list.Add(GetLang("gen_special"));
		list.Add(GetLang("gen_auto_learning"));
		return list;
	}

	public static List<string> gen_match_dcs_bit_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_23bit"));
		list.Add(GetLang("gen_24bit"));
		return list;
	}

	public static List<string> gen_match_threshold_Items()
	{
		List<string> list = new List<string>();
		for (int i = 10; i <= 200; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> GetGen_Brightness_Items()
	{
		List<string> list = new List<string>();
		for (int i = 8; i <= 200; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> GetChannelName_Items()
	{
		List<string> list = new List<string>();
		string[] channelName = main.GetChannelName();
		list.Add(GetLang("_null"));
		if (channelName.Length > 0)
		{
			list.AddRange(channelName);
		}
		return list;
	}

	public static List<string> gen_transpositional_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		for (int i = 1; i <= 5; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> gen_fm_mode_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_mode_freq"));
		list.Add(GetLang("gen_mode_chn"));
		return list;
	}

	public static List<string> gen_fm_chn_idx_Items()
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= 32; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> gen_alarm_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_local_alarm"));
		list.Add(GetLang("gen_remote_alarm"));
		return list;
	}

	public static List<string> gen_noaa_decode_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("_null"));
		list.Add("1050HZ");
		list.Add(GetLang("gen_same_decode"));
		return list;
	}

	public static List<string> gen_noaa_scan_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("gen_manual_search"));
		list.Add(GetLang("gen_auto_search"));
		return list;
	}

	public static List<string> _5tone_RepeatTone_Items()
	{
		List<string> list = new List<string>();
		string[] collection = new string[5] { "A", "B", "C", "D", "E" };
		list.AddRange(collection);
		return list;
	}

	public static List<string> _5tone_GroupCode_Items()
	{
		List<string> list = new List<string>();
		string[] collection = new string[5] { "A", "B", "C", "D", "E" };
		list.AddRange(collection);
		return list;
	}

	public static List<string> _5tone_reset_Items()
	{
		List<string> list = new List<string>();
		for (int i = 0; i <= 60; i++)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> _5tone_interval_Items()
	{
		List<string> list = new List<string>();
		for (int i = 0; i <= 1000; i += 10)
		{
			list.Add(i.ToString());
		}
		return list;
	}

	public static List<string> _5tone_protocol_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("_5tone_EIA"));
		list.Add("EEA");
		list.Add(GetLang("_5tone_CCIR"));
		list.Add(GetLang("_5tone_ZVEI1"));
		list.Add(GetLang("_5tone_ZVEI2"));
		list.Add(GetLang("_5tone_user"));
		return list;
	}

	public static List<string> vfo_step1_Items()
	{
		List<string> list = new List<string>();
		list.Add("0.1K");
		list.Add("0.5K");
		list.Add("1K");
		list.Add("1.5K");
		list.Add("2K");
		list.Add("2.5K");
		list.Add("5K");
		list.Add("6.25K");
		list.Add("8.33K");
		list.Add("9K");
		list.Add("10K");
		list.Add("12.5K");
		list.Add("15K");
		list.Add("20K");
		list.Add("25K");
		return list;
	}

	public static List<string> vfo_step2_Items()
	{
		List<string> list = new List<string>();
		list.Add("1K");
		list.Add("1.5K");
		list.Add("2K");
		list.Add("2.5K");
		list.Add("5K");
		list.Add("6.25K");
		list.Add("8.33K");
		list.Add("9K");
		list.Add("10K");
		list.Add("12.5K");
		list.Add("15K");
		list.Add("20K");
		list.Add("25K");
		list.Add("0.1K");
		list.Add("0.5K");
		return list;
	}

	public static List<string> vfo_step_Items()
	{
		List<string> list = new List<string>();
		list.Add("1K");
		list.Add("1.5K");
		list.Add("2K");
		list.Add("2.5K");
		list.Add("5K");
		list.Add("6.25K");
		list.Add("8.33K");
		list.Add("9K");
		list.Add("10K");
		list.Add("12.5K");
		list.Add("15K");
		list.Add("20K");
		list.Add("25K");
		return list;
	}

	public static List<string> vfo_direction_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("_null"));
		list.Add("+");
		list.Add("-");
		return list;
	}

	public static List<string> noaa_send_type_Items()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("off"));
		list.Add(GetLang("NOAA_SEND_TYPE_1"));
		list.Add(GetLang("NOAA_SEND_TYPE_2"));
		list.Add(GetLang("NOAA_SEND_TYPE_3"));
		list.Add(GetLang("NOAA_SEND_TYPE_4"));
		list.Add(GetLang("NOAA_SEND_TYPE_5"));
		return list;
	}
}
