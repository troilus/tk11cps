using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class wfm_progress : Form
{
	private const int TIME_STRING_LEN = 32;

	private int VER_STRING_LEN = 16;

	private int VER_POSITION = 8192;

	public static int versionHighNo = -1;

	public static int addr = 0;

	public static int seed = 0;

	public static bool exit = false;

	public static string file_ver = "old";

	public static string version;

	private string[] str_err = new string[12]
	{
		"channel_error", "vfo_error", "fm_error", "gen_error", "gen1_error", "scan_error", "Password_error", "dtmf_error", "5tone_error", "NoaaDecode_error",
		"NoaaEven_error", "HideParam_error"
	};

	private IContainer components = null;

	private ProgressBar progressBar1;

	private Label label1;

	private BackgroundWorker backgroundWorker1;

	public wfm_progress()
	{
		InitializeComponent();
		base.StartPosition = FormStartPosition.CenterScreen;
		Control.CheckForIllegalCrossThreadCalls = false;
	}

	public string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	private void wfm_progress_Load(object sender, EventArgs e)
	{
		exit = false;
		base.Icon = Resources.标题;
		if (main.m_Progress == "read")
		{
			Text = GetLang("read");
			label1.Text = GetLang("cps_read_param");
		}
		else
		{
			Text = GetLang("write");
			label1.Text = GetLang("cps_write_param");
		}
		progressBar1.Maximum = main.CpsData.Length;
		backgroundWorker1.RunWorkerAsync();
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		if (!ComPort.Instance.Open())
		{
			return;
		}
		try
		{
			bool[] array = new bool[20];
			int num = 0;
			bool flag = true;
			if (main.m_Progress == "read")
			{
				array[num++] = CpsReadChannel();
				array[num++] = CpsReadVfo();
				array[num++] = CpsReadFm();
				array[num++] = CpsReadGen();
				array[num++] = CpsReadGen2();
				array[num++] = CpsReadScan();
				array[num++] = CpsReadPassword();
				array[num++] = CpsReadDtmfcontact();
				array[num++] = CpsRead_5tonecontact();
				array[num++] = CpsReadNoaaDecodeAddr();
				array[num++] = CpsReadNoaaEvent();
				array[num++] = CpsRead_HideParam();
				CpsRead_ChannelIdx();
				backgroundWorker1.ReportProgress(main.CpsData.Length);
				for (int i = 0; i < num; i++)
				{
					if (!array[i])
					{
						flag = false;
						MessageBox.Show(str_err[i]);
					}
				}
				if (flag)
				{
					MessageBox.Show(GetLang("read_success"));
				}
				else
				{
					MessageBox.Show(GetLang("read_fail"));
				}
			}
			else if (main.m_Progress == "write")
			{
				array[num++] = WriteChannel();
				array[num++] = CpsWriteVfo();
				array[num++] = CpsWriteFm();
				array[num++] = CpsWriteGen();
				array[num++] = CpsWriteGen2();
				array[num++] = CpsWriteNoaaSendSame();
				array[num++] = CpsWriteCHN_Idx();
				array[num++] = CpsWriteScan();
				array[num++] = CpsWritePassword();
				array[num++] = CpsWriteDtmfContact();
				array[num++] = CpsWrite_5toneContact();
				array[num++] = CpsWriteNoaaDecodeAddr();
				array[num++] = CpsWriteNoaaEvent();
				array[num++] = CpsWriteHideParam();
				array[num++] = CpsWriteSelfTone();
				array[num++] = CpsWritePicture();
				Thread.Sleep(1000);
				protocol_struct.Reboot();
				backgroundWorker1.ReportProgress(main.CpsData.Length);
				for (int i = 0; i < num; i++)
				{
					if (!array[i])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					MessageBox.Show(GetLang("write_success"));
				}
				else
				{
					MessageBox.Show(GetLang("write_fail"));
				}
			}
			else if (main.m_Progress == "updata")
			{
				Random random = new Random();
				protocol_struct.magiccode = (uint)random.Next();
				Updata();
			}
			else if (main.m_Progress == "resource")
			{
				Resource();
			}
		}
		catch (Exception)
		{
		}
		ComPort.Instance.Close();
	}

	public static bool ContentNorOr(ref byte[] content)
	{
		byte[] array = new byte[128]
		{
			71, 34, 192, 82, 93, 87, 72, 148, 177, 96,
			96, 219, 111, 227, 76, 124, 216, 74, 214, 139,
			48, 236, 37, 224, 76, 217, 0, 127, 191, 227,
			84, 5, 233, 58, 151, 107, 176, 110, 12, 251,
			177, 26, 226, 201, 193, 86, 71, 233, 186, 241,
			66, 182, 103, 95, 15, 150, 247, 201, 60, 132,
			27, 38, 225, 78, 59, 111, 102, 230, 160, 106,
			176, 191, 198, 165, 112, 58, 186, 24, 158, 39,
			26, 83, 91, 113, 177, 148, 30, 24, 242, 214,
			129, 2, 34, 253, 90, 40, 145, 219, 186, 93,
			100, 198, 254, 134, 131, 156, 80, 28, 115, 3,
			17, 214, 175, 48, 244, 44, 119, 178, 125, 187,
			63, 41, 40, 87, 34, 214, 146, 139
		};
		for (int i = 0; i < content.Length; i++)
		{
			content[i] ^= array[i % array.Length];
		}
		return true;
	}

	public byte[] PareUpdataFile1(string path)
	{
		bool flag = false;
		int result = 0;
		string empty = string.Empty;
		FileInfo fileInfo = new FileInfo(path);
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			byte[] content = new byte[VER_STRING_LEN];
			fileStream.Seek(VER_POSITION, SeekOrigin.Begin);
			fileStream.Read(content, 0, VER_STRING_LEN);
			ContentNorOr(ref content);
			empty = Encoding.ASCII.GetString(content, 0, VER_STRING_LEN);
			version = empty.Substring(0, 1);
			if (empty.Substring(0, 1).Equals("*"))
			{
				flag = true;
			}
			if (!flag && !int.TryParse(empty.Split('.')[0], out result))
			{
				return null;
			}
			if (!flag)
			{
				if (result <= 0)
				{
					return null;
				}
				if ((result != 2 || versionHighNo != -1) && result != versionHighNo)
				{
					return null;
				}
			}
		}
		if (!flag && result <= 0)
		{
			MessageBox.Show(GetLang("ver_err"));
			return null;
		}
		byte[] content2 = new byte[(int)fileInfo.Length];
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			fileStream.Seek(0L, SeekOrigin.Begin);
			fileStream.Read(content2, 0, content2.Length);
		}
		ushort num = Util.CRC16XMODEM(content2.Take(content2.Length - 2).ToArray());
		ushort num2 = BitConverter.ToUInt16(content2, content2.Length - 2);
		if (num2 != num)
		{
			MessageBox.Show(GetLang("ver_err"));
			return null;
		}
		ContentNorOr(ref content2);
		byte[] array = new byte[(int)fileInfo.Length - VER_STRING_LEN - 2];
		Array.Copy(content2, 0, array, 0, VER_POSITION);
		Array.Copy(content2, VER_POSITION + VER_STRING_LEN, array, VER_POSITION, array.Length - VER_POSITION);
		return array;
	}

	public void Updata()
	{
		string path = Iparse.getchart("path", "program");
		if (!protocol_struct.GetUpdataReady())
		{
			return;
		}
		byte[] array = null;
		try
		{
			array = PareUpdataFile(path);
			file_ver = "new";
		}
		catch (Exception)
		{
			array = null;
			file_ver = "old";
		}
		if (array == null)
		{
			try
			{
				array = PareUpdataFile1(path);
			}
			catch (Exception)
			{
				array = null;
			}
		}
		if (array != null)
		{
			if (downloadFileEx(array))
			{
				MessageBox.Show(GetLang("write_success"));
			}
			else
			{
				MessageBox.Show(GetLang("write_fail"));
			}
		}
		else
		{
			MessageBox.Show(GetLang("文件版本错误"));
		}
	}

	public byte[] PareAesFile(byte[] src, uint seed_idx)
	{
		byte[] value = new byte[512]
		{
			225, 110, 13, 41, 224, 200, 52, 24, 152, 127,
			148, 51, 245, 255, 98, 14, 20, 183, 162, 190,
			2, 35, 226, 89, 178, 6, 109, 136, 134, 151,
			126, 54, 176, 217, 58, 247, 118, 26, 80, 202,
			203, 150, 110, 184, 168, 5, 188, 187, 145, 108,
			80, 251, 158, 72, 6, 147, 177, 85, 178, 229,
			85, 203, 120, 10, 19, 87, 204, 36, 209, 56,
			165, 119, 153, 221, 14, 236, 91, 154, 24, 249,
			251, 20, 157, 76, 69, 231, 215, 169, 90, 166,
			75, 194, 39, 101, 168, 192, 168, 239, 79, 145,
			118, 136, 197, 193, 72, 127, 42, 106, 129, 30,
			85, 77, 50, 200, 96, 223, 206, 101, 202, 48,
			46, 197, 52, 170, 95, 136, 136, 75, 151, 163,
			135, 86, 123, 35, 75, 85, 201, 33, 205, 130,
			246, 95, 0, 135, 232, 171, 78, 14, 52, 76,
			181, 160, 177, 231, 219, 122, 5, 212, 104, 195,
			240, 36, 14, 2, 237, 93, 169, 101, 83, 157,
			129, 83, 6, 242, 211, 75, 198, 17, 107, 213,
			190, 163, 134, 115, 116, 98, 5, 238, 83, 77,
			88, 159, 115, 77, 216, 172, 132, 192, 196, 34,
			203, 202, 40, 254, 200, 133, 100, 115, 75, 254,
			53, 88, 36, 54, 87, 128, 20, 233, 112, 237,
			141, 171, 158, 160, 127, 103, 72, 5, 112, 186,
			82, 84, 215, 206, 229, 156, 162, 164, 131, 181,
			150, 133, 140, 223, 89, 69, 74, 95, 168, 79,
			170, 54, 99, 116, 139, 141, 103, 236, 124, 56,
			206, 250, 158, 219, 56, 187, 137, 181, 137, 134,
			235, 26, 47, 154, 52, 188, 236, 48, 43, 198,
			197, 182, 188, 85, 44, 22, 109, 201, 8, 234,
			58, 125, 200, 166, 233, 97, 183, 6, 31, 126,
			82, 236, 142, 109, 95, 111, 46, 205, 131, 93,
			118, 11, 92, 30, 120, 240, 190, 26, 135, 135,
			78, 50, 76, 86, 94, 50, 190, 138, 106, 175,
			38, 217, 255, 55, 238, 135, 61, 104, 11, 21,
			166, 39, 76, 114, 188, 51, 19, 161, 131, 241,
			55, 43, 79, 217, 215, 36, 57, 22, 84, 60,
			35, 173, 153, 89, 55, 228, 187, 124, 161, 11,
			231, 3, 41, 96, 198, 213, 220, 189, 198, 180,
			236, 251, 227, 26, 161, 214, 198, 28, 140, 92,
			34, 129, 220, 126, 55, 28, 163, 195, 241, 104,
			146, 94, 183, 120, 35, 46, 139, 75, 31, 6,
			165, 130, 73, 139, 33, 73, 17, 224, 101, 237,
			63, 158, 139, 150, 186, 230, 31, 121, 167, 216,
			163, 23, 139, 103, 151, 132, 113, 251, 211, 113,
			220, 244, 78, 217, 47, 86, 86, 45, 196, 99,
			105, 88, 225, 131, 15, 35, 198, 217, 206, 21,
			178, 221, 195, 90, 91, 114, 55, 221, 185, 197,
			41, 14, 21, 81, 144, 24, 206, 172, 186, 118,
			191, 152, 98, 214, 128, 249, 72, 25, 95, 92,
			144, 84, 94, 29, 133, 120, 129, 114, 234, 20,
			145, 107, 96, 104, 85, 255, 42, 171, 229, 46,
			153, 60
		};
		uint[][] array = new uint[16][];
		uint[][] array2 = new uint[16][];
		for (int i = 0; i < 16; i++)
		{
			array[i] = new uint[4];
			for (int j = 0; j < 4; j++)
			{
				array[i][j] = BitConverter.ToUInt32(value, i * 32 + j * 4);
			}
			array2[i] = new uint[4];
			for (int j = 0; j < 4; j++)
			{
				array2[i][j] = BitConverter.ToUInt32(value, i * 32 + 16 + j * 4);
			}
		}
		uint[] array3 = new uint[4];
		for (int i = 0; i < array3.Length; i++)
		{
			array3[i] = array[seed_idx][i];
		}
		uint[] array4 = new uint[4];
		for (int i = 0; i < array4.Length; i++)
		{
			array4[i] = array2[seed_idx][i];
		}
		return Util.AESDecrypt(src, array3, array4);
	}

	public byte[] PareUpdataFile(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return null;
		}
		if (!File.Exists(path.Trim()))
		{
			return null;
		}
		FileInfo fileInfo = new FileInfo(path.Trim());
		if (fileInfo.Length < VER_POSITION)
		{
			return null;
		}
		byte[] array = new byte[(int)fileInfo.Length];
		using (FileStream fileStream = new FileStream(path.Trim(), FileMode.Open, FileAccess.Read))
		{
			fileStream.Seek(0L, SeekOrigin.Begin);
			fileStream.Read(array, 0, array.Length);
		}
		byte[] key = new byte[8] { 204, 26, 65, 221, 145, 157, 48, 68 };
		byte[] iv = new byte[8] { 133, 125, 204, 109, 50, 9, 97, 98 };
		byte[] array2 = Util.DESDecrypt(array, key, iv);
		ushort num = Util.CRC16XMODEM(array2.Take(array2.Length - 2).ToArray());
		ushort num2 = BitConverter.ToUInt16(array2, array2.Length - 2);
		if (num2 != num)
		{
			return null;
		}
		byte[] content = new byte[32];
		Array.Copy(array2, 128, content, 0, 32);
		Util.ContentNorOrEx(ref content, 1);
		uint num3 = BitConverter.ToUInt32(content, 16);
		bool flag = false;
		int result = 0;
		string empty = string.Empty;
		content = new byte[VER_STRING_LEN];
		Array.Copy(array2, 256, content, 0, VER_STRING_LEN);
		Util.ContentNorOrEx(ref content, 2);
		empty = Encoding.ASCII.GetString(content, 0, VER_STRING_LEN);
		int num4 = empty.IndexOf('.');
		int num5 = empty.IndexOf('.', num4 + 1);
		if (num4 <= 0 || num5 <= 0)
		{
			return null;
		}
		string s = empty.Substring(num4 + 1, num5 - num4 - 1);
		uint result2 = 0u;
		if (!uint.TryParse(s, out result2))
		{
			return null;
		}
		uint num6 = (num3 % 10 + result2) % 16;
		version = empty.Substring(0, 1);
		if (empty.Substring(0, 1).Equals("*"))
		{
			flag = true;
		}
		if (!flag && !int.TryParse(empty.Split('.')[0], out result))
		{
			return null;
		}
		if (!flag)
		{
			if (result <= 0)
			{
				return null;
			}
			if ((result != 2 || versionHighNo != -1) && result != versionHighNo)
			{
				return null;
			}
		}
		byte[] array3 = new byte[array2.Length - 32 - VER_STRING_LEN - 2];
		Array.Copy(array2, 0, array3, 0, 128);
		Array.Copy(array2, 160, array3, 128, 96);
		Array.Copy(array2, 256 + VER_STRING_LEN, array3, 224, array2.Length - (256 + VER_STRING_LEN) - 2);
		return array3;
	}

	private bool downloadFileEx(byte[] allBuffer)
	{
		int num = 1024;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		uint num6 = 0u;
		bool flag = false;
		try
		{
			num = 256;
			num6 = generateSeqNo();
			num2 = allBuffer.Length / num;
			num5 = ((allBuffer.Length % num == 0) ? num2 : (num2 + 1));
			byte[] array = new byte[num5 * num];
			Array.Copy(allBuffer, array, allBuffer.Length);
			progressBar1.Maximum = num5;
			bool flag2 = false;
			if (protocol_struct.check_boot_ver(protocol_struct.boot_version))
			{
				Random random = new Random();
				seed = random.Next(0, 16);
				for (num4 = 0; num4 < 5; num4++)
				{
					try
					{
						flag2 = protocol_struct.SendUpdataConnectReq(protocol_struct.boot_version, seed);
					}
					catch (Exception)
					{
						flag2 = false;
					}
					if (protocol_struct.boot_version == "4.00.03" || flag2)
					{
						break;
					}
				}
				if (!flag2)
				{
					return false;
				}
				Thread.Sleep(500);
				byte[] array2 = new byte[16];
				byte[] array3 = new byte[16];
				for (int i = 0; i < 16; i++)
				{
					array2[i] = Util.updatakey[seed, i];
					array3[i] = Util.updatakey[seed, i + 16];
				}
				for (num4 = 0; num4 < array3.Length; num4++)
				{
					array3[num4] ^= protocol_struct.UpdataConnRsp.u8RandCode[num4];
				}
				array = Util.AESEncrypt(array, array2, array3);
			}
			else
			{
				protocol_struct.SendUpdataConnectOldReq(protocol_struct.boot_version);
			}
			addr = 0;
			for (num4 = 0; num4 < num5; num4++)
			{
				byte[] array4 = new byte[num];
				Array.Copy(array, addr, array4, 0, num);
				addr += num;
				flag = protocol_struct.packetFileEx(array4, num4, num5, num, num6);
				backgroundWorker1.ReportProgress(num4);
				if (!flag)
				{
					break;
				}
			}
		}
		catch (Exception)
		{
			flag = false;
		}
		return flag;
	}

	private uint generateSeqNo()
	{
		Random random = new Random();
		return (uint)random.Next(1, int.MaxValue);
	}

	public void Resource()
	{
		try
		{
			FileStream fileStream = File.OpenRead(Iparse.getchart("path", "resource"));
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			bool flag = downloadFile(array);
			Thread.Sleep(1000);
			protocol_struct.Reboot();
			if (flag)
			{
				MessageBox.Show(GetLang("write_success"));
			}
			else
			{
				MessageBox.Show(GetLang("write_fail"));
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private bool downloadFile(byte[] allBuffer)
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 512;
		try
		{
			num = allBuffer.Length / num4;
			num3 = ((allBuffer.Length % num4 == 0) ? num : (num + 1));
			byte[] array = new byte[num3 * num4];
			Array.Copy(allBuffer, array, allBuffer.Length);
			progressBar1.Minimum = 0;
			progressBar1.Maximum = array.Length;
			if (!protocol_struct.Link(5))
			{
				return false;
			}
			if (protocol_struct.Model != main.ModelVersion)
			{
				MessageBox.Show(GetLang("model_error"));
				return false;
			}
			Cursor = Cursors.WaitCursor;
			addr = 1048576;
			int num5 = 0;
			while (num5 < array.Length)
			{
				byte[] array2 = new byte[num4];
				Array.Copy(array, num5, array2, 0, array2.Length);
				flag = protocol_struct.Write(addr, array2, (ushort)array2.Length);
				backgroundWorker1.ReportProgress(num5);
				if (!flag)
				{
					break;
				}
				num5 += num4;
				addr += num4;
			}
		}
		catch (Exception)
		{
			flag = false;
		}
		Cursor = Cursors.Default;
		return flag;
	}

	public bool CpsReadNoaaEvent()
	{
		bool result = true;
		int num = 143360;
		try
		{
			for (int i = 0; i < 32; i++)
			{
				byte[] sourceArray = protocol_struct.Read(num, 64);
				Array.Copy(sourceArray, 0, main.CpsData, num, 64);
				num += 4096;
				backgroundWorker1.ReportProgress(num);
			}
		}
		catch (Exception)
		{
			MessageBox.Show("noaa event error");
			result = false;
		}
		return result;
	}

	public bool CpsReadNoaaDecodeAddr()
	{
		bool result = true;
		int num = 139264;
		try
		{
			for (int i = 0; i < 2; i++)
			{
				byte[] sourceArray = protocol_struct.Read(num, 512);
				Array.Copy(sourceArray, 0, main.CpsData, num, 512);
				num += 512;
				backgroundWorker1.ReportProgress(num);
			}
		}
		catch (Exception)
		{
			MessageBox.Show("noaa error");
			result = false;
		}
		return result;
	}

	public bool CpsReadPassword()
	{
		bool result = true;
		int num = 94208;
		try
		{
			byte[] array = protocol_struct.Read(num, 4);
			if (array != null)
			{
				Array.Copy(array, 0, main.CpsData, num, array.Length);
				num += 4;
				backgroundWorker1.ReportProgress(num);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception)
		{
			MessageBox.Show("password error");
			result = false;
		}
		return result;
	}

	public bool CpsWritePassword()
	{
		bool flag = false;
		try
		{
			byte[] array = new byte[4];
			addr = 94208;
			Array.Copy(main.CpsData, addr, array, 0, 4);
			flag = protocol_struct.Write(addr, array, (ushort)array.Length);
			addr += array.Length;
			backgroundWorker1.ReportProgress(addr);
		}
		catch (Exception)
		{
			flag = false;
			MessageBox.Show(GetLang("read_err_fm"));
		}
		return flag;
	}

	public bool CpsWriteNoaaEvent()
	{
		bool result = true;
		try
		{
			addr = 143360;
			for (int i = 0; i < 32; i++)
			{
				byte[] array = new byte[64];
				Array.Copy(main.CpsData, addr, array, 0, array.Length);
				result = protocol_struct.Write(addr, array, (ushort)array.Length);
				addr += 4096;
				backgroundWorker1.ReportProgress(addr);
			}
		}
		catch (Exception)
		{
			result = false;
			MessageBox.Show(GetLang("read_err_fm"));
		}
		return result;
	}

	public bool CpsWriteNoaaDecodeAddr()
	{
		bool result = true;
		try
		{
			addr = 139264;
			for (int i = 0; i < 2; i++)
			{
				byte[] array = new byte[512];
				Array.Copy(main.CpsData, addr, array, 0, array.Length);
				result = protocol_struct.Write(addr, array, (ushort)array.Length);
				addr += array.Length;
				backgroundWorker1.ReportProgress(addr);
			}
		}
		catch (Exception)
		{
			result = false;
			MessageBox.Show(GetLang("read_err_fm"));
		}
		return result;
	}

	public bool CpsWriteNoaaSendSame()
	{
		bool result = true;
		try
		{
			if (main.NoaaSendSameInfo.write_flag)
			{
				addr = 82032;
				for (int i = 0; i < 4; i++)
				{
					byte[] array = new byte[128];
					Array.Copy(main.CpsData, addr, array, 0, array.Length);
					result = protocol_struct.Write(addr, array, (ushort)array.Length);
					addr += array.Length;
					backgroundWorker1.ReportProgress(addr);
				}
			}
		}
		catch (Exception)
		{
			result = false;
			MessageBox.Show(GetLang("read_err_fm"));
		}
		return result;
	}

	public bool CpsWritePicture()
	{
		bool result = true;
		try
		{
			if (main.GenInfo.picture)
			{
				addr = 876544;
				if (main.CpsPictureInfo.flag == 2596035162u)
				{
					for (int i = 0; i < 5; i++)
					{
						byte[] array = new byte[256];
						Array.Copy(main.CpsData, addr, array, 0, array.Length);
						result = protocol_struct.Write(addr, array, (ushort)array.Length);
						addr += array.Length;
						backgroundWorker1.ReportProgress(addr);
					}
				}
			}
		}
		catch (Exception)
		{
			result = false;
			MessageBox.Show(GetLang("read_err_fm"));
		}
		return result;
	}

	public bool CpsWriteSelfTone()
	{
		bool result = true;
		CPS_USER_TAIL_TONE_INFO cPS_USER_TAIL_TONE_INFO = default(CPS_USER_TAIL_TONE_INFO);
		try
		{
			addr = 282624;
			for (int i = 0; i < 5; i++)
			{
				if (main.CpsTailToneInfo[i].flag == 305420890)
				{
					byte[] sourceArray = Iparse.StructToBytes(main.CpsTailToneInfo[i], Iparse.GetStructSizeof(cPS_USER_TAIL_TONE_INFO));
					for (int j = 0; j < 16384; j += 512)
					{
						byte[] array = new byte[512];
						Array.Copy(sourceArray, j, array, 0, array.Length);
						result = protocol_struct.Write(addr, array, (ushort)array.Length);
						addr += 512;
						backgroundWorker1.ReportProgress(addr);
					}
				}
				else
				{
					addr += 16384;
					backgroundWorker1.ReportProgress(addr);
				}
			}
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("read_err_fm"));
			result = false;
		}
		return result;
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBar1.Value = e.ProgressPercentage;
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		Close();
	}

	public bool CpsReadChannel()
	{
		bool result = true;
		byte[] array = new byte[999];
		CPS_CHANNEL_INFO cPS_CHANNEL_INFO = default(CPS_CHANNEL_INFO);
		addr = 69632;
		try
		{
			ushort num = 0;
			addr = 69632;
			for (int i = 0; i < 2; i++)
			{
				byte[] sourceArray = protocol_struct.Read(addr, 512);
				Array.Copy(sourceArray, 0, main.CpsData, addr, 512);
				addr += 512;
			}
			addr = 69632;
			Array.Copy(main.CpsData, addr, array, 0, 999);
			addr = 0;
			num = (ushort)Iparse.GetStructSizeof(cPS_CHANNEL_INFO);
			for (int i = 0; i < 999; i++)
			{
				if (array[i] != byte.MaxValue)
				{
					byte[] sourceArray = protocol_struct.Read(addr, num);
					if (sourceArray != null)
					{
						Array.Copy(sourceArray, 0, main.CpsData, addr, num);
					}
				}
				addr += num;
				backgroundWorker1.ReportProgress(addr);
			}
		}
		catch (Exception)
		{
			MessageBox.Show("channel error");
			result = false;
		}
		return result;
	}

	public bool WriteChannel()
	{
		CPS_CHANNEL_INFO cPS_CHANNEL_INFO = default(CPS_CHANNEL_INFO);
		byte[] array = new byte[512];
		addr = 0;
		int num = (ushort)Iparse.GetStructSizeof(cPS_CHANNEL_INFO);
		array = new byte[num];
		for (int i = 0; i < 999; i++)
		{
			if (main.CpsChannelFlagInfo.flag[i] != byte.MaxValue)
			{
				Array.Copy(main.CpsData, addr, array, 0, array.Length);
				if (!protocol_struct.Write(addr, array, (ushort)array.Length))
				{
					return false;
				}
			}
			addr += num;
			backgroundWorker1.ReportProgress(addr);
		}
		array = new byte[13];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)(240 + i);
		}
		addr = 70631;
		Array.Copy(array, 0, main.CpsData, addr, array.Length);
		addr = 69632;
		for (int i = 0; i < 2; i++)
		{
			array = new byte[512];
			Array.Copy(main.CpsData, addr, array, 0, array.Length);
			bool flag = protocol_struct.Write(addr, array, (ushort)array.Length);
			addr += 512;
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	public bool CpsWriteVfo()
	{
		bool result = true;
		addr = 65536;
		try
		{
			for (int i = 0; i < 4; i++)
			{
				byte[] array = new byte[512];
				Array.Copy(main.CpsData, addr, array, 0, array.Length);
				result = protocol_struct.Write(addr, array, (ushort)array.Length);
				addr += array.Length;
				backgroundWorker1.ReportProgress(addr);
			}
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("read_err_vfo"));
			result = false;
		}
		return result;
	}

	public bool CpsReadVfo()
	{
		bool result = true;
		addr = 65536;
		try
		{
			for (int i = 0; i < 4; i++)
			{
				byte[] array = protocol_struct.Read(addr, 512);
				if (array == null)
				{
					result = false;
					break;
				}
				Array.Copy(array, 0, main.CpsData, addr, 512);
				addr += 512;
				backgroundWorker1.ReportProgress(addr);
			}
		}
		catch (Exception)
		{
			MessageBox.Show("vfo error");
			result = false;
		}
		return result;
	}

	public bool CpsWriteFm()
	{
		bool flag = true;
		try
		{
			addr = 73728;
			byte[] array = new byte[128];
			Array.Copy(main.CpsData, addr, array, 0, array.Length);
			flag = protocol_struct.Write(addr, array, (ushort)array.Length);
			backgroundWorker1.ReportProgress(addr);
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("read_err_fm"));
			flag = false;
		}
		return flag;
	}

	public bool CpsReadFm()
	{
		bool result = true;
		try
		{
			addr = 73728;
			byte[] array = protocol_struct.Read(addr, 128);
			if (array != null)
			{
				Array.Copy(array, 0, main.CpsData, addr, 128);
				backgroundWorker1.ReportProgress(addr);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception)
		{
			MessageBox.Show("fm error");
			result = false;
		}
		return result;
	}

	public bool CpsWriteGen()
	{
		bool result = false;
		int num = 77824;
		try
		{
			int structSizeof = Iparse.GetStructSizeof(default(CPS_GEN_INFO));
			byte[] array = new byte[structSizeof];
			Array.Copy(main.CpsData, num, array, 0, array.Length);
			result = protocol_struct.Write(num, array, (ushort)array.Length);
			backgroundWorker1.ReportProgress(num);
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("read_err_gen"));
		}
		return result;
	}

	public bool CpsWriteGen2()
	{
		bool flag = false;
		int num = 81920;
		try
		{
			byte[] array = new byte[112];
			Array.Copy(main.CpsData, num, array, 0, array.Length);
			flag = protocol_struct.Write(num, array, (ushort)array.Length);
			backgroundWorker1.ReportProgress(num);
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("read_err_gen"));
			flag = false;
		}
		return flag;
	}

	public bool CpsReadGen2()
	{
		bool result = true;
		int num = 81920;
		try
		{
			for (int i = 0; i < 2; i++)
			{
				byte[] array = protocol_struct.Read(num, 512);
				if (array != null)
				{
					Array.Copy(array, 0, main.CpsData, num, 512);
					num += 512;
					backgroundWorker1.ReportProgress(num);
					continue;
				}
				result = false;
				break;
			}
		}
		catch (Exception)
		{
			MessageBox.Show("gen2 error");
			result = false;
		}
		return result;
	}

	public bool CpsReadGen()
	{
		bool result = true;
		int num = 77824;
		try
		{
			int structSizeof = Iparse.GetStructSizeof(default(CPS_GEN_INFO));
			byte[] array = protocol_struct.Read(num, (ushort)structSizeof);
			if (array != null)
			{
				Array.Copy(array, 0, main.CpsData, num, structSizeof);
				backgroundWorker1.ReportProgress(num);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception)
		{
			MessageBox.Show("gen1 error");
			result = false;
		}
		return result;
	}

	public bool CpsReadScan()
	{
		bool result = true;
		int num = 90112;
		try
		{
			for (int i = 0; i < 8; i++)
			{
				byte[] array = protocol_struct.Read(num, 512);
				if (array != null)
				{
					Array.Copy(array, 0, main.CpsData, num, array.Length);
					num += 512;
					backgroundWorker1.ReportProgress(num);
				}
				else
				{
					result = false;
				}
			}
		}
		catch (Exception)
		{
			MessageBox.Show("scan error");
			result = false;
		}
		return result;
	}

	public bool CpsWriteScan()
	{
		bool result = false;
		try
		{
			addr = 90112;
			for (int i = 0; i < 8; i++)
			{
				byte[] array = new byte[512];
				Array.Copy(main.CpsData, addr, array, 0, array.Length);
				result = protocol_struct.Write(addr, array, (ushort)array.Length);
				addr += 512;
				backgroundWorker1.ReportProgress(addr);
			}
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("read_err_fm"));
			result = false;
		}
		return result;
	}

	public bool CpsWriteDtmfContact()
	{
		bool flag = false;
		try
		{
			addr = 106496;
			byte[] array = new byte[384];
			Array.Copy(main.CpsData, addr, array, 0, array.Length);
			flag = protocol_struct.Write(addr, array, (ushort)array.Length);
			addr += array.Length;
			backgroundWorker1.ReportProgress(addr);
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("read_err_fm"));
			flag = false;
		}
		return flag;
	}

	public bool CpsWrite_5toneContact()
	{
		bool flag = false;
		try
		{
			addr = 108544;
			byte[] array = new byte[384];
			Array.Copy(main.CpsData, addr, array, 0, array.Length);
			flag = protocol_struct.Write(addr, array, (ushort)array.Length);
			addr += array.Length;
			backgroundWorker1.ReportProgress(addr);
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("read_err_fm"));
			flag = false;
		}
		return flag;
	}

	public bool CpsReadDtmfcontact()
	{
		bool result = true;
		int num = 106496;
		try
		{
			byte[] array = protocol_struct.Read(num, 384);
			if (array != null)
			{
				Array.Copy(array, 0, main.CpsData, num, array.Length);
				num += 384;
				backgroundWorker1.ReportProgress(num);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception)
		{
			MessageBox.Show("dtmf error");
			result = false;
		}
		return result;
	}

	public bool CpsRead_5tonecontact()
	{
		bool result = true;
		int num = 108544;
		try
		{
			byte[] array = protocol_struct.Read(num, 384);
			if (array != null)
			{
				Array.Copy(array, 0, main.CpsData, num, array.Length);
				num += 384;
				backgroundWorker1.ReportProgress(num);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception)
		{
			MessageBox.Show("5tone error");
			result = false;
		}
		return result;
	}

	public bool CpsRead_ChannelIdx()
	{
		bool result = true;
		int num = 86016;
		try
		{
			byte[] array = protocol_struct.Read(num, 64);
			if (array != null)
			{
				Array.Copy(array, 0, main.CpsData, num, array.Length);
				num += 64;
			}
			else
			{
				result = false;
			}
		}
		catch (Exception)
		{
			MessageBox.Show("channel idx error");
			result = false;
		}
		return result;
	}

	public bool CpsRead_HideParam()
	{
		bool result = true;
		int num = 102400;
		int structSizeof = Iparse.GetStructSizeof(default(CPS_HIDE_PARAM_INFO));
		try
		{
			byte[] array = protocol_struct.Read(num, (ushort)structSizeof);
			if (array != null)
			{
				Array.Copy(array, 0, main.CpsData, num, array.Length);
				num += structSizeof;
				backgroundWorker1.ReportProgress(num);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception)
		{
			MessageBox.Show("hide error");
			result = false;
		}
		return result;
	}

	public byte[] convert_cpsHideParamFlag()
	{
		CPS_HIDE_PARAM_FLAG cPS_HIDE_PARAM_FLAG = default(CPS_HIDE_PARAM_FLAG);
		int structSizeof = Iparse.GetStructSizeof(cPS_HIDE_PARAM_FLAG);
		cPS_HIDE_PARAM_FLAG.cps_retry_time = (byte)main.HideParamFlag.cps_retry_time;
		cPS_HIDE_PARAM_FLAG.kill_flag = (byte)(main.HideParamFlag.kill_flag ? 1u : 0u);
		cPS_HIDE_PARAM_FLAG.encrypt_flag = (byte)(main.HideParamFlag.encrypt_flag ? 1u : 0u);
		cPS_HIDE_PARAM_FLAG.lock_freq_flag = (byte)(main.HideParamFlag.lock_freq_flag ? 1u : 0u);
		List<string> list = param_string.noaa_send_type_Items();
		cPS_HIDE_PARAM_FLAG.noaa_send_type = (byte)list.IndexOf(main.HideParamFlag.noaa_send_type);
		return Iparse.StructToBytes(cPS_HIDE_PARAM_FLAG, structSizeof);
	}

	public bool CpsWriteHideParam()
	{
		bool result = true;
		int num = 102400;
		try
		{
			byte[] array = null;
			if (main.HideParamFlag.write_flag)
			{
				array = convert_cpsHideParamFlag();
				result = protocol_struct.Write(num, array, (ushort)array.Length);
				backgroundWorker1.ReportProgress(num);
			}
			if (!main.IsHideParamTree)
			{
				return result;
			}
			num += 16;
			array = new byte[Iparse.GetStructSizeof(default(CPS_HIDE_PARAM_INFO))];
			Array.Copy(main.CpsData, num, array, 0, array.Length);
			result = protocol_struct.Write(num, array, (ushort)array.Length);
			backgroundWorker1.ReportProgress(num);
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("read_err_gen"));
			result = false;
		}
		return result;
	}

	public bool CpsWriteCHN_Idx()
	{
		bool flag = false;
		int num = 86016;
		byte[] array = new byte[32];
		Array.Copy(main.CpsData, num, array, 0, array.Length);
		try
		{
			flag = protocol_struct.Write(num, array, (ushort)array.Length);
			backgroundWorker1.ReportProgress(num);
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("read_err_gen"));
			flag = false;
		}
		return flag;
	}

	private void wfm_progress_FormClosing(object sender, FormClosingEventArgs e)
	{
		exit = true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.label1 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.progressBar1.Location = new System.Drawing.Point(34, 74);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(492, 42);
		this.progressBar1.TabIndex = 0;
		this.backgroundWorker1.WorkerReportsProgress = true;
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("宋体", 22.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(37, 22);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(0, 38);
		this.label1.TabIndex = 1;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(574, 171);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.progressBar1);
		base.Name = "wfm_progress";
		this.Text = "wfm_progress";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(wfm_progress_FormClosing);
		base.Load += new System.EventHandler(wfm_progress_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
