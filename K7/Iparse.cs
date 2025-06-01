using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace K7;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class Iparse
{
	public static int Getdimensional2StringIndex(string s, string[,] str)
	{
		int num = 0;
		foreach (string text in str)
		{
			if (s == text)
			{
				goto end_IL_006d;
			}
			num++;
		}
		if (num % 2 == 0)
		{
			return num / 2;
		}
		return (num - 1) / 2;
	}

	public static int ConverStringToInt(string s)
	{
		if (s == null)
		{
			return -1;
		}
		return int.Parse(s);
	}

	public static string ConvertByteToString(byte[] array, string Encoding)
	{
		byte[] array2 = new byte[array.Length];
		for (int i = 0; i < array2.Length && array[i] != 0; i++)
		{
			array2[i] = array[i];
		}
		char[] trimChars;
		if (Encoding == "unicode")
		{
			string @string = System.Text.Encoding.Unicode.GetString(array2);
			trimChars = new char[1];
			return @string.Trim(trimChars);
		}
		if (Encoding == "utf8")
		{
			string string2 = System.Text.Encoding.UTF8.GetString(array2);
			trimChars = new char[1];
			return string2.Trim(trimChars);
		}
		string string3 = System.Text.Encoding.Default.GetString(array2);
		trimChars = new char[1];
		return string3.Trim(trimChars);
	}

	public static string CutOutString(string s, int length)
	{
		if (s == "")
		{
			return null;
		}
		string text = null;
		int num = 0;
		for (int i = 0; i < s.Length; i++)
		{
			num = ((s[i] <= '\u007f') ? (num + 1) : (num + 2));
			if (num > length)
			{
				break;
			}
			text += s[i];
		}
		return text;
	}

	public static byte[] ConvertStringToByte(string str, string Encoding)
	{
		if (str == null)
		{
			return new byte[1];
		}
		if (Encoding == "unicode")
		{
			return System.Text.Encoding.Unicode.GetBytes(str);
		}
		if (Encoding == "utf8")
		{
			return System.Text.Encoding.UTF8.GetBytes(str);
		}
		return System.Text.Encoding.Default.GetBytes(str);
	}

	public static int GetStructSizeof(object structObj)
	{
		return Marshal.SizeOf(structObj);
	}

	public static byte[] StructToBytes(object structObj, int size)
	{
		byte[] array = new byte[size];
		IntPtr intPtr = Marshal.AllocHGlobal(size);
		Marshal.StructureToPtr(structObj, intPtr, fDeleteOld: false);
		Marshal.Copy(intPtr, array, 0, size);
		Marshal.FreeHGlobal(intPtr);
		return array;
	}

	public static byte[] StructToBytes(object structObj)
	{
		int num = Marshal.SizeOf(structObj);
		byte[] array = new byte[num];
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		Marshal.StructureToPtr(structObj, intPtr, fDeleteOld: false);
		Marshal.Copy(intPtr, array, 0, num);
		Marshal.FreeHGlobal(intPtr);
		return array;
	}

	public static object ByteToStruct(byte[] bytes, Type type)
	{
		int num = Marshal.SizeOf(type);
		if (num > bytes.Length)
		{
			return null;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		Marshal.Copy(bytes, 0, intPtr, num);
		object result = Marshal.PtrToStructure(intPtr, type);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	public static ushort CheckSum(byte[] buf, int len)
	{
		int num = 0;
		int num2 = 0;
		while (len > 1)
		{
			num += 0xFFFF & ((buf[num2] << 8) | buf[num2 + 1]);
			num2 += 2;
			len -= 2;
		}
		if (len > 0)
		{
			num += (0xFF & buf[num2]) << 8;
		}
		while (num >> 16 != 0)
		{
			num = (num & 0xFFFF) + (num >> 16);
		}
		return (ushort)((uint)num ^ 0xFFFFu);
	}

	public static string getchart(string typeface, string key)
	{
		string text = null;
		string text2 = null;
		text = Application.StartupPath;
		text += "\\config.ini";
		IniFile iniFile = new IniFile(text);
		return iniFile.IniReadValue(typeface, key);
	}

	public static void setchart(string typeface, string key, string value)
	{
		string text = null;
		text = Application.StartupPath;
		text += "\\config.ini";
		IniFile iniFile = new IniFile(text);
		iniFile.IniWriteValue(typeface, key, value);
	}

	public static ushort CRC16XMODEM(byte[] content)
	{
		int[] array = new int[256]
		{
			0, 4129, 8258, 12387, 16516, 20645, 24774, 28903, 33032, 37161,
			41290, 45419, 49548, 53677, 57806, 61935, 4657, 528, 12915, 8786,
			21173, 17044, 29431, 25302, 37689, 33560, 45947, 41818, 54205, 50076,
			62463, 58334, 9314, 13379, 1056, 5121, 25830, 29895, 17572, 21637,
			42346, 46411, 34088, 38153, 58862, 62927, 50604, 54669, 13907, 9842,
			5649, 1584, 30423, 26358, 22165, 18100, 46939, 42874, 38681, 34616,
			63455, 59390, 55197, 51132, 18628, 22757, 26758, 30887, 2112, 6241,
			10242, 14371, 51660, 55789, 59790, 63919, 35144, 39273, 43274, 47403,
			23285, 19156, 31415, 27286, 6769, 2640, 14899, 10770, 56317, 52188,
			64447, 60318, 39801, 35672, 47931, 43802, 27814, 31879, 19684, 23749,
			11298, 15363, 3168, 7233, 60846, 64911, 52716, 56781, 44330, 48395,
			36200, 40265, 32407, 28342, 24277, 20212, 15891, 11826, 7761, 3696,
			65439, 61374, 57309, 53244, 48923, 44858, 40793, 36728, 37256, 33193,
			45514, 41451, 53516, 49453, 61774, 57711, 4224, 161, 12482, 8419,
			20484, 16421, 28742, 24679, 33721, 37784, 41979, 46042, 49981, 54044,
			58239, 62302, 689, 4752, 8947, 13010, 16949, 21012, 25207, 29270,
			46570, 42443, 38312, 34185, 62830, 58703, 54572, 50445, 13538, 9411,
			5280, 1153, 29798, 25671, 21540, 17413, 42971, 47098, 34713, 38840,
			59231, 63358, 50973, 55100, 9939, 14066, 1681, 5808, 26199, 30326,
			17941, 22068, 55628, 51565, 63758, 59695, 39368, 35305, 47498, 43435,
			22596, 18533, 30726, 26663, 6336, 2273, 14466, 10403, 52093, 56156,
			60223, 64286, 35833, 39896, 43963, 48026, 19061, 23124, 27191, 31254,
			2801, 6864, 10931, 14994, 64814, 60687, 56684, 52557, 48554, 44427,
			40424, 36297, 31782, 27655, 23652, 19525, 15522, 11395, 7392, 3265,
			61215, 65342, 53085, 57212, 44955, 49082, 36825, 40952, 28183, 32310,
			20053, 24180, 11923, 16050, 3793, 7920
		};
		ushort num = 0;
		for (int i = 0; i < content.Length; i++)
		{
			num = (ushort)((num << 8) ^ array[((num >> 8) ^ content[i]) & 0xFF]);
		}
		return num;
	}

	public static ushort CRC16IBM(byte[] content)
	{
		int[] array = new int[256]
		{
			0, 49345, 49537, 320, 49921, 960, 640, 49729, 50689, 1728,
			1920, 51009, 1280, 50625, 50305, 1088, 52225, 3264, 3456, 52545,
			3840, 53185, 52865, 3648, 2560, 51905, 52097, 2880, 51457, 2496,
			2176, 51265, 55297, 6336, 6528, 55617, 6912, 56257, 55937, 6720,
			7680, 57025, 57217, 8000, 56577, 7616, 7296, 56385, 5120, 54465,
			54657, 5440, 55041, 6080, 5760, 54849, 53761, 4800, 4992, 54081,
			4352, 53697, 53377, 4160, 61441, 12480, 12672, 61761, 13056, 62401,
			62081, 12864, 13824, 63169, 63361, 14144, 62721, 13760, 13440, 62529,
			15360, 64705, 64897, 15680, 65281, 16320, 16000, 65089, 64001, 15040,
			15232, 64321, 14592, 63937, 63617, 14400, 10240, 59585, 59777, 10560,
			60161, 11200, 10880, 59969, 60929, 11968, 12160, 61249, 11520, 60865,
			60545, 11328, 58369, 9408, 9600, 58689, 9984, 59329, 59009, 9792,
			8704, 58049, 58241, 9024, 57601, 8640, 8320, 57409, 40961, 24768,
			24960, 41281, 25344, 41921, 41601, 25152, 26112, 42689, 42881, 26432,
			42241, 26048, 25728, 42049, 27648, 44225, 44417, 27968, 44801, 28608,
			28288, 44609, 43521, 27328, 27520, 43841, 26880, 43457, 43137, 26688,
			30720, 47297, 47489, 31040, 47873, 31680, 31360, 47681, 48641, 32448,
			32640, 48961, 32000, 48577, 48257, 31808, 46081, 29888, 30080, 46401,
			30464, 47041, 46721, 30272, 29184, 45761, 45953, 29504, 45313, 29120,
			28800, 45121, 20480, 37057, 37249, 20800, 37633, 21440, 21120, 37441,
			38401, 22208, 22400, 38721, 21760, 38337, 38017, 21568, 39937, 23744,
			23936, 40257, 24320, 40897, 40577, 24128, 23040, 39617, 39809, 23360,
			39169, 22976, 22656, 38977, 34817, 18624, 18816, 35137, 19200, 35777,
			35457, 19008, 19968, 36545, 36737, 20288, 36097, 19904, 19584, 35905,
			17408, 33985, 34177, 17728, 34561, 18368, 18048, 34369, 33281, 17088,
			17280, 33601, 16640, 33217, 32897, 16448
		};
		int num = 0;
		foreach (byte b in content)
		{
			num = (num >> 8) ^ array[(num ^ b) & 0xFF];
		}
		return BitConverter.ToUInt16(new byte[2]
		{
			(byte)(0xFFu & (uint)num),
			(byte)((0xFF00 & num) >> 8)
		}, 0);
	}
}
