using System;
using System.Collections.Generic;

namespace K7;

internal class cps_convert
{
	public static string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	public static CPS_DTMF_CONTACT_INFO convert_data(DTMF_CONTACT_INFO chn)
	{
		CPS_DTMF_CONTACT_INFO result = default(CPS_DTMF_CONTACT_INFO);
		result.name = new byte[16];
		result.id = new byte[8];
		byte[] array = Iparse.ConvertStringToByte(chn.name, "default");
		Array.Copy(array, result.name, array.Length);
		array = Iparse.ConvertStringToByte(chn.id, "default");
		Array.Copy(array, result.id, array.Length);
		return result;
	}

	public static DTMF_CONTACT_INFO convert_data(CPS_DTMF_CONTACT_INFO chn)
	{
		DTMF_CONTACT_INFO result = default(DTMF_CONTACT_INFO);
		if (chn.name[0] != byte.MaxValue)
		{
			result.name = Iparse.ConvertByteToString(chn.name, "default");
			result.id = Iparse.ConvertByteToString(chn.id, "default");
		}
		return result;
	}

	public static CPS_5TONE_CONTACT_INFO convert_data(_5TONE_CONTACT_INFO chn)
	{
		CPS_5TONE_CONTACT_INFO result = default(CPS_5TONE_CONTACT_INFO);
		result.name = new byte[16];
		result.id = new byte[8];
		byte[] array = Iparse.ConvertStringToByte(chn.name, "default");
		Array.Copy(array, result.name, array.Length);
		array = Iparse.ConvertStringToByte(chn.id, "default");
		Array.Copy(array, result.id, array.Length);
		return result;
	}

	public static _5TONE_CONTACT_INFO convert_data(CPS_5TONE_CONTACT_INFO chn)
	{
		_5TONE_CONTACT_INFO result = default(_5TONE_CONTACT_INFO);
		if (chn.name[0] != byte.MaxValue)
		{
			result.name = Iparse.ConvertByteToString(chn.name, "default");
			result.id = Iparse.ConvertByteToString(chn.id, "default");
		}
		return result;
	}

	public static string PareScanChannelIdx(ushort idx)
	{
		if (idx == 23130)
		{
			return GetLang("scan_current_ch");
		}
		string text = null;
		try
		{
			text = ((idx > 32) ? GetLang("_null") : main.ChannelInfo[idx].name);
		}
		catch (Exception)
		{
			text = GetLang("_null");
		}
		return text;
	}

	public static SCAN_INFO convert_data(CPS_SCAN_INFO chn, int idx)
	{
		SCAN_INFO result = default(SCAN_INFO);
		if (chn.name[0] == byte.MaxValue)
		{
			result.name = GetLang("chn_scan") + (idx + 1);
		}
		else
		{
			result.name = Iparse.ConvertByteToString(chn.name, "deault");
		}
		result.prio_1 = PareScanChannelIdx(chn.prio_1);
		result.prio_2 = PareScanChannelIdx(chn.prio_2);
		result.member = new string[48];
		for (int i = 0; i < 48 && chn.channel[i] < 999; i++)
		{
			try
			{
				result.member[i] = main.ChannelInfo[chn.channel[i]].name;
			}
			catch (Exception)
			{
			}
		}
		return result;
	}

	public static CPS_SCAN_INFO convert_data(SCAN_INFO chn)
	{
		CPS_SCAN_INFO result = default(CPS_SCAN_INFO);
		result.name = new byte[16];
		result.channel = new ushort[48];
		main.InitParam(ref result.name);
		main.InitParam(ref result.channel);
		if (chn.member == null)
		{
			result.prio_1 = 255;
			result.prio_2 = 255;
			return result;
		}
		byte[] array = Iparse.ConvertStringToByte(chn.name, "default");
		if (array.Length != 0)
		{
			result.name = new byte[16];
			Array.Copy(array, result.name, array.Length);
		}
		result.prio_1 = (ushort)FindScanChanneIndex(chn.prio_1);
		result.prio_2 = (ushort)FindScanChanneIndex(chn.prio_2);
		int num = 0;
		for (int i = 0; i < chn.member.Length; i++)
		{
			if (!string.IsNullOrEmpty(chn.member[i]) && chn.member[i] != GetLang("scan_current_ch"))
			{
				result.channel[num++] = (ushort)FindScanChanneIndex(chn.member[i]);
			}
		}
		return result;
	}

	public static int FindScanChanneIndex(string name)
	{
		int num = 0;
		if (name == GetLang("scan_current_ch"))
		{
			return 23130;
		}
		CHANNEL_INFO[] channelInfo = main.ChannelInfo;
		for (int i = 0; i < channelInfo.Length; i++)
		{
			CHANNEL_INFO cHANNEL_INFO = channelInfo[i];
			if (cHANNEL_INFO.name == name)
			{
				break;
			}
			num++;
		}
		return num;
	}

	public static int FindChanneIndex(string name)
	{
		int num = 0;
		CHANNEL_INFO[] channelInfo = main.ChannelInfo;
		for (int i = 0; i < channelInfo.Length; i++)
		{
			CHANNEL_INFO cHANNEL_INFO = channelInfo[i];
			if (cHANNEL_INFO.name == name)
			{
				break;
			}
			num++;
		}
		return num;
	}

	public static CHANNEL_INFO convert_data(CPS_CHANNEL_INFO chn, int idx)
	{
		CHANNEL_INFO result = default(CHANNEL_INFO);
		result.rx_freq = conver_freq(chn.rx_freq);
		if (chn.freq_dir == 0)
		{
			result.tx_freq = result.rx_freq;
		}
		else if (chn.freq_dir == 1)
		{
			result.tx_freq = conver_freq(chn.rx_freq + chn.freq_diff);
		}
		else if (chn.freq_dir == 2)
		{
			result.tx_freq = conver_freq(chn.rx_freq - chn.freq_diff);
		}
		List<string> list = param_string.chn_qttype_Items();
		try
		{
			result.non_stand_type1 = list[chn.tx_non_standard_1];
			result.non_stand_type2 = list[chn.tx_non_standard_2];
		}
		catch (Exception)
		{
			result.non_stand_type1 = null;
			result.non_stand_type2 = null;
		}
		try
		{
			result.rx_qt_type = list[chn.rx_qt_type];
			result.tx_qt_type = list[chn.tx_qt_type];
		}
		catch (Exception)
		{
			result.rx_qt_type = list[0];
			result.tx_qt_type = list[0];
		}
		list = param_string.chn_band_Items();
		try
		{
			result.band = list[chn.band & 0xF];
		}
		catch (Exception)
		{
			result.band = list[0];
		}
		list = param_string.chn_MSW_Items();
		try
		{
			result.msw = list[chn.band >> 4];
		}
		catch (Exception)
		{
			result.msw = list[0];
		}
		list = param_string.chn_encypt_Items();
		try
		{
			result.encypt = list[chn.encypt];
		}
		catch (Exception)
		{
			result.encypt = list[0];
		}
		list = param_string.chn_power_Items();
		try
		{
			result.power = list[chn.power];
		}
		catch (Exception)
		{
			result.power = list[0];
		}
		list = param_string.chn_on_off_Items();
		try
		{
			result.busy = list[chn.busy];
		}
		catch (Exception)
		{
			result.busy = list[0];
		}
		try
		{
			result.reverse = list[chn.reverse];
		}
		catch (Exception)
		{
			result.reverse = list[0];
		}
		try
		{
			result.dtmf_decdoe_flag = list[chn.dtmf_decdoe_flag];
		}
		catch (Exception)
		{
			result.dtmf_decdoe_flag = list[0];
		}
		list = param_string.chn_pttid_Items();
		try
		{
			result.pttid = list[chn.pttid];
		}
		catch (Exception)
		{
			result.pttid = list[0];
		}
		list = param_string.chn_demode_Items();
		try
		{
			result.am = list[chn.am];
		}
		catch (Exception)
		{
			result.am = list[0];
		}
		list = param_string.chn_scanlist1_Items();
		try
		{
			if (chn.scanlist == byte.MaxValue)
			{
				chn.scanlist = 33;
			}
			result.scanlist = list[chn.scanlist];
		}
		catch (Exception)
		{
			result.scanlist = list[33];
		}
		list = param_string.gen_sq_Items();
		try
		{
			result.sq = list[chn.sq];
		}
		catch (Exception)
		{
			result.sq = list[0];
		}
		if (chn.name[0] == 0 || chn.name[0] == byte.MaxValue)
		{
			result.name = (result.name = "CH-" + (idx + 1).ToString("000"));
		}
		else
		{
			result.name = Iparse.ConvertByteToString(chn.name, "default");
		}
		result.qt_rx_null = GetLang("_null");
		result.qt_tx_null = GetLang("_null");
		try
		{
			if (chn.rx_qt_type == 1)
			{
				result.qt_rx_ctc = conver_qt_ctc(chn.rx_qt);
			}
			else if (chn.rx_qt_type == 2 || chn.rx_qt_type == 3)
			{
				result.qt_rx_dcs = conver_qt_dcs(chn.rx_qt);
			}
			else
			{
				result.qt_rx_ctc = conver_qt_ctc(630u);
				result.qt_rx_dcs = conver_qt_dcs(15u);
			}
		}
		catch (Exception)
		{
			result.qt_rx_ctc = conver_qt_ctc(630u);
			result.qt_rx_dcs = conver_qt_dcs(15u);
		}
		try
		{
			if (chn.tx_qt_type == 1)
			{
				result.qt_tx_ctc = conver_qt_ctc(chn.tx_qt1);
			}
			else if (chn.tx_qt_type == 2 || chn.tx_qt_type == 3)
			{
				result.qt_tx_dcs = conver_qt_dcs(chn.tx_qt1);
			}
			else
			{
				result.qt_tx_ctc = conver_qt_ctc(630u);
				result.qt_tx_dcs = conver_qt_dcs(15u);
			}
		}
		catch (Exception)
		{
			result.qt_tx_ctc = conver_qt_ctc(630u);
			result.qt_tx_dcs = conver_qt_dcs(15u);
		}
		list = param_string.gen_signal_Items();
		try
		{
			result.signal = list[chn.signal];
		}
		catch (Exception)
		{
			result.signal = list[0];
		}
		return result;
	}

	public static CPS_CHANNEL_INFO convert_data(CHANNEL_INFO chn)
	{
		CPS_CHANNEL_INFO result = default(CPS_CHANNEL_INFO);
		if (!string.IsNullOrEmpty(chn.rx_freq))
		{
			result.name = new byte[16];
			uint num = conver_freq(chn.rx_freq);
			uint num2 = conver_freq(chn.tx_freq);
			result.rx_freq = num;
			if (num == num2)
			{
				result.freq_dir = 0;
				result.freq_diff = 0u;
			}
			else if (num < num2)
			{
				result.freq_dir = 1;
				result.freq_diff = num2 - num;
			}
			else if (num > num2)
			{
				result.freq_dir = 2;
				result.freq_diff = num - num2;
			}
			List<string> list = param_string.chn_qttype_Items();
			result.tx_non_standard_1 = (byte)list.IndexOf(chn.non_stand_type1);
			result.tx_non_standard_2 = (byte)list.IndexOf(chn.non_stand_type2);
			result.rx_qt_type = (byte)list.IndexOf(chn.rx_qt_type);
			result.tx_qt_type = (byte)list.IndexOf(chn.tx_qt_type);
			list = param_string.chn_band_Items();
			result.band = (byte)list.IndexOf(chn.band);
			list = param_string.chn_MSW_Items();
			result.band |= (byte)(list.IndexOf(chn.msw) << 4);
			result.step = 0;
			list = param_string.chn_encypt_Items();
			result.encypt = (byte)list.IndexOf(chn.encypt);
			list = param_string.chn_power_Items();
			result.power = (byte)list.IndexOf(chn.power);
			list = param_string.chn_on_off_Items();
			result.busy = (byte)list.IndexOf(chn.busy);
			result.reverse = (byte)list.IndexOf(chn.reverse);
			result.dtmf_decdoe_flag = (byte)list.IndexOf(chn.dtmf_decdoe_flag);
			list = param_string.chn_pttid_Items();
			result.pttid = (byte)list.IndexOf(chn.pttid);
			list = param_string.chn_demode_Items();
			result.am = (byte)list.IndexOf(chn.am);
			list = param_string.chn_scanlist1_Items();
			result.scanlist = (byte)list.IndexOf(chn.scanlist);
			if (result.scanlist == 33)
			{
				result.scanlist = byte.MaxValue;
			}
			list = param_string.gen_sq_Items();
			result.sq = (byte)list.IndexOf(chn.sq);
			byte[] array = Iparse.ConvertStringToByte(chn.name, "default");
			Array.Copy(array, result.name, array.Length);
			if (result.rx_qt_type == 1)
			{
				result.rx_qt = conver_qt_ctc(chn.qt_rx_ctc);
			}
			else if (result.rx_qt_type == 2 || result.rx_qt_type == 3)
			{
				result.rx_qt = conver_qt_dcs(chn.qt_rx_dcs);
			}
			if (result.tx_qt_type == 1)
			{
				result.tx_qt1 = conver_qt_ctc(chn.qt_tx_ctc);
			}
			else if (result.tx_qt_type == 2 || result.tx_qt_type == 3)
			{
				result.tx_qt1 = conver_qt_dcs(chn.qt_tx_dcs);
			}
			list = param_string.gen_signal_Items();
			result.signal = (byte)list.IndexOf(chn.signal);
		}
		return result;
	}

	public static VFO_INFO convert_data(CPS_VFO_INFO chn)
	{
		VFO_INFO result = default(VFO_INFO);
		result.rx_freq = conver_freq(chn.rx_freq);
		result.freq_diff = conver_freq(chn.freq_diff);
		result.scan_start = conver_freq(chn.scan_star);
		result.scan_end = conver_freq(chn.scan_end);
		if (chn.freq_dir == 0)
		{
			result.tx_freq = result.rx_freq;
		}
		else if (chn.freq_dir == 1)
		{
			result.tx_freq = conver_freq(chn.rx_freq + chn.freq_diff);
		}
		else if (chn.freq_dir == 2)
		{
			result.tx_freq = conver_freq(chn.rx_freq - chn.freq_diff);
		}
		List<string> list = param_string.vfo_direction_Items();
		try
		{
			result.freq_dir = list[chn.freq_dir];
		}
		catch (Exception)
		{
			result.freq_dir = list[0];
		}
		list = param_string.vfo_step_Items();
		if (chn.step >= list.Count)
		{
			list = param_string.vfo_step2_Items();
		}
		try
		{
			result.step = list[chn.step];
		}
		catch (Exception)
		{
			result.step = list[0];
		}
		list = param_string.chn_qttype_Items();
		try
		{
			result.non_stand_type1 = list[chn.tx_non_standard_1];
			result.non_stand_type2 = list[chn.tx_non_standard_2];
		}
		catch (Exception)
		{
			result.non_stand_type1 = null;
			result.non_stand_type2 = null;
		}
		try
		{
			result.rx_qt_type = list[chn.rx_qt_type];
			result.tx_qt_type = list[chn.tx_qt_type];
		}
		catch (Exception)
		{
			result.rx_qt_type = list[0];
			result.tx_qt_type = list[0];
		}
		list = param_string.chn_band_Items();
		try
		{
			result.band = list[chn.band & 0xF];
		}
		catch (Exception)
		{
			result.band = list[0];
		}
		list = param_string.chn_MSW_Items();
		try
		{
			result.msw = list[chn.band >> 4];
		}
		catch (Exception)
		{
			result.msw = list[0];
		}
		list = param_string.chn_encypt_Items();
		try
		{
			result.encypt = list[chn.encypt];
		}
		catch (Exception)
		{
			result.encypt = list[0];
		}
		list = param_string.chn_power_Items();
		try
		{
			result.power = list[chn.power];
		}
		catch (Exception)
		{
			result.power = list[0];
		}
		list = param_string.chn_on_off_Items();
		try
		{
			result.busy = list[chn.busy];
		}
		catch (Exception)
		{
			result.busy = list[0];
		}
		try
		{
			result.reverse = list[chn.reverse];
		}
		catch (Exception)
		{
			result.reverse = list[0];
		}
		try
		{
			result.dtmf_decdoe_flag = list[chn.dtmf_decdoe_flag];
		}
		catch (Exception)
		{
			result.dtmf_decdoe_flag = list[0];
		}
		list = param_string.chn_pttid_Items();
		try
		{
			result.pttid = list[chn.pttid];
		}
		catch (Exception)
		{
			result.pttid = list[0];
		}
		list = param_string.chn_demode_Items();
		try
		{
			result.am = list[chn.am];
		}
		catch (Exception)
		{
			result.am = list[0];
		}
		list = param_string.gen_sq_Items();
		try
		{
			result.sq = list[chn.sq];
		}
		catch (Exception)
		{
			result.sq = list[0];
		}
		result.qt_rx_null = GetLang("_null");
		result.qt_tx_null = GetLang("_null");
		try
		{
			if (chn.rx_qt_type == 1)
			{
				result.qt_rx_ctc = conver_qt_ctc(chn.rx_qt);
			}
			else if (chn.rx_qt_type == 2 || chn.rx_qt_type == 3)
			{
				result.qt_rx_dcs = conver_qt_dcs(chn.rx_qt);
			}
			else
			{
				result.qt_rx_ctc = conver_qt_ctc(630u);
				result.qt_rx_dcs = conver_qt_dcs(15u);
			}
		}
		catch (Exception)
		{
			result.qt_rx_ctc = conver_qt_ctc(630u);
			result.qt_rx_dcs = conver_qt_dcs(15u);
		}
		try
		{
			if (chn.tx_qt_type == 1)
			{
				result.qt_tx_ctc = conver_qt_ctc(chn.tx_qt1);
			}
			else if (chn.tx_qt_type == 2 || chn.tx_qt_type == 3)
			{
				result.qt_tx_dcs = conver_qt_dcs(chn.tx_qt1);
			}
			else
			{
				result.qt_tx_ctc = conver_qt_ctc(630u);
				result.qt_tx_dcs = conver_qt_dcs(15u);
			}
		}
		catch (Exception)
		{
			result.qt_tx_ctc = conver_qt_ctc(630u);
			result.qt_tx_dcs = conver_qt_dcs(15u);
		}
		list = param_string.gen_signal_Items();
		try
		{
			result.signal = list[chn.signal];
		}
		catch (Exception)
		{
			result.signal = list[0];
		}
		return result;
	}

	public static CPS_VFO_INFO convert_data(VFO_INFO chn)
	{
		CPS_VFO_INFO result = default(CPS_VFO_INFO);
		if (!string.IsNullOrEmpty(chn.rx_freq))
		{
			result.rx_freq = conver_freq(chn.rx_freq);
			result.freq_diff = conver_freq(chn.freq_diff);
			result.scan_star = conver_freq(chn.scan_start);
			result.scan_end = conver_freq(chn.scan_end);
			List<string> list = param_string.vfo_direction_Items();
			result.freq_dir = (byte)list.IndexOf(chn.freq_dir);
			list = param_string.vfo_step1_Items();
			list = ((!(chn.step == list[0]) && !(chn.step == list[1])) ? param_string.vfo_step_Items() : param_string.vfo_step2_Items());
			result.step = (byte)list.IndexOf(chn.step);
			list = param_string.chn_qttype_Items();
			result.tx_non_standard_1 = (byte)list.IndexOf(chn.non_stand_type1);
			result.tx_non_standard_2 = (byte)list.IndexOf(chn.non_stand_type2);
			result.rx_qt_type = (byte)list.IndexOf(chn.rx_qt_type);
			result.tx_qt_type = (byte)list.IndexOf(chn.tx_qt_type);
			list = param_string.chn_band_Items();
			result.band = (byte)list.IndexOf(chn.band);
			list = param_string.chn_MSW_Items();
			result.band |= (byte)(list.IndexOf(chn.msw) << 4);
			list = param_string.chn_encypt_Items();
			result.encypt = (byte)list.IndexOf(chn.encypt);
			list = param_string.chn_power_Items();
			result.power = (byte)list.IndexOf(chn.power);
			list = param_string.chn_on_off_Items();
			result.busy = (byte)list.IndexOf(chn.busy);
			result.reverse = (byte)list.IndexOf(chn.reverse);
			result.dtmf_decdoe_flag = (byte)list.IndexOf(chn.dtmf_decdoe_flag);
			list = param_string.chn_pttid_Items();
			result.pttid = (byte)list.IndexOf(chn.pttid);
			list = param_string.chn_demode_Items();
			result.am = (byte)list.IndexOf(chn.am);
			list = param_string.gen_sq_Items();
			result.sq = (byte)list.IndexOf(chn.sq);
			if (result.rx_qt_type == 1)
			{
				result.rx_qt = conver_qt_ctc(chn.qt_rx_ctc);
			}
			else if (result.rx_qt_type == 2 || result.rx_qt_type == 3)
			{
				result.rx_qt = conver_qt_dcs(chn.qt_rx_dcs);
			}
			if (result.tx_qt_type == 1)
			{
				result.tx_qt1 = conver_qt_ctc(chn.qt_tx_ctc);
			}
			else if (result.tx_qt_type == 2 || result.tx_qt_type == 3)
			{
				result.tx_qt1 = conver_qt_dcs(chn.qt_tx_dcs);
			}
			list = param_string.gen_signal_Items();
			result.signal = (byte)list.IndexOf(chn.signal);
		}
		return result;
	}

	public static string conver_freq(uint f)
	{
		return ((double)f / 100000.0).ToString("0.00000");
	}

	public static uint conver_freq(string s)
	{
		double num = Convert.ToDouble(s);
		num *= 100000.0;
		return (uint)(num + 0.5);
	}

	public static string conver_qt_ctc(uint val)
	{
		double num = val;
		return (num / 10.0).ToString("0.0");
	}

	public static uint conver_qt_ctc(string s)
	{
		double num = Convert.ToDouble(s);
		num *= 10.0;
		return (uint)num;
	}

	public static string conver_qt_dcs(uint val)
	{
		string text = null;
		int num = (int)(((val >> 6) & 7) + 48);
		int num2 = (int)(((val >> 3) & 7) + 48);
		int num3 = (int)((val & 7) + 48);
		text += (char)num;
		text += (char)num2;
		return text + (char)num3;
	}

	public static uint conver_qt_dcs(string s)
	{
		int num = 0;
		int num2 = 0;
		byte[] array = Iparse.ConvertStringToByte(s, "defalut");
		for (int num3 = array.Length; num3 > 0; num3--)
		{
			num += array[num3 - 1] - 48 << 3 * num2++;
		}
		return (uint)num;
	}
}
