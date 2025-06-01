using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace K7;

internal class protocol_struct
{
	public enum MessageType
	{
		O_CALMS_CONN_REQ = 500,
		O_MSCAL_CONN_RSP = 501,
		O_CALMS_ENCRYPT_REQ = 502,
		O_MSCAL_ENCRYPT_RSP = 503,
		O_MSCAL_FILE_UPDATE_READY = 504,
		O_CALMS_FILE_UPDATE_DATA = 505,
		O_MSCAL_FILE_UPDATE_DATA_RSP = 506,
		O_CALMS_PARA_READ_REQ = 507,
		O_MSCAL_PARA_READ_RSP = 508,
		O_CALMS_PARA_WRITE_REQ = 509,
		O_MSCAL_PARA_WRITE_RSP = 510,
		O_CALMS_CFG_RX_CHAN_REQ = 511,
		O_MSCAL_CFG_RX_CHAN_RSP = 512,
		O_CALMS_CFG_TX_CHAN_REQ = 513,
		O_MSCAL_CFG_TX_CHAN_RSP = 514,
		O_CALMS_CFG_TX_PWR_REQ = 515,
		O_MSCAL_CFG_TX_PWR_RSP = 516,
		O_CALMS_CFG_RX_SQL_REQ = 517,
		O_MSCAL_CFG_RX_SQL_RSP = 518,
		O_CALMS_GET_SQL_REQ = 519,
		O_MSCAL_GET_SQL_RSP = 520,
		O_CALMS_GET_VOL_REQ = 521,
		O_MSCAL_GET_VOL_RSP = 522,
		O_CALMS_GET_VOX_REQ = 523,
		O_MSCAL_GET_VOX_RSP = 524,
		O_CALMS_AUTH_REQ = 525,
		O_MSCAL_AUTH_RSP = 526,
		O_CALMS_CAL_CONN_REQ = 527,
		O_CALMS_UPDATE_CONN_REQ = 528,
		O_CALMS_SIMPLE_CFG_RX_CHAN_REQ = 529,
		O_CALMS_UPDATE_CONN_RSP = 530,
		O_CALMS_CMD_IND = 1500,
		O_CALMS_REBOOT_REQ = 1501
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_AuthReq
	{
		public const int NOHEADERLENGTH = 16;

		public OSP_MSG_HEADER struMsgHeader;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public uint[] u32AuthDataBuffer;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_AuthRsp
	{
		public const int NOHEADERLENGTH = 4;

		public OSP_MSG_HEADER struMsgHeader;

		public byte u8Result;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] u8Rsv;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct STRU_CAL_HEADER
	{
		public const int LENGTH = 4;

		public byte u8HeaderFlag1;

		public byte u8HeaderFlag2;

		public ushort u16Length;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct STRU_CAL_ENDER
	{
		public const int LENGTH = 4;

		public ushort u16CRC;

		public byte u8EnderFlag1;

		public byte u8EnderFlag2;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct OSP_MSG_HEADER
	{
		public const int LENGTH = 4;

		public ushort u16MsgType;

		public ushort u16MsgLen;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_ConnReq
	{
		public const int NOHEADERLENGTH = 4;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32MagicCode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_ConnRsp
	{
		public const int NOHEADERLENGTH = 52;

		public OSP_MSG_HEADER struMsgHeader;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] versionString;

		public byte u8PasswordValid;

		public byte u8StartLockFlag;

		public byte u8ParamsVersion;

		public byte u8Rsv;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public uint[] u32RandCode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public uint[] u32UUID;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_FileUpdateDataRsp
	{
		public const int NOHEADERLENGTH = 12;

		public OSP_MSG_HEADER struMsgHeader;

		private uint u32SeqNo;

		private ushort u16BlockIndex;

		private byte u8Result;

		private byte u8Rsv;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_ParaReadReq
	{
		public const int NOHEADERLENGTH = 12;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32Address;

		public ushort u8DataLen;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] u8Rsv;

		public uint u32MagicCode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_ParaReadRsp
	{
		public OSP_MSG_HEADER struMsgHeader;

		public uint u32Address;

		public ushort u8DataLen;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] u8Rsv;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
		public byte[] u8Data;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_ParaWriteReq
	{
		public const int NOHEADERLENGTH = 12;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32Address;

		public ushort u8DataLen;

		public byte u8AdvanceFlag;

		public byte u8Rsv;

		public uint u32MagicCode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_ParaWriteRsp
	{
		public const int NOHEADERLENGTH = 4;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32Address;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_FileUpdateReady
	{
		public const int NOHEADERLENGTH = 32;

		public OSP_MSG_HEADER struMsgHeader;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public uint[] u32UUID;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] versionString;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_RebootReq
	{
		public const int NOHEADERLENGTH = 0;

		public OSP_MSG_HEADER struMsgHeader;
	}

	public const int PARA_MAX_LEN = 512;

	public const int g_offet_addr = 524288;

	public const int g_channel_addr = 0;

	public const int g_channel_flag_addr = 69632;

	public const int g_vfo_addr = 65536;

	public const int g_fm_addr = 73728;

	public const int g_scan_addr = 90112;

	public const int g_gen_addr = 77824;

	public const int g_gen2_addr = 81920;

	public const int g_noaa_send_same = 82032;

	public const int g_channel_idx_addr = 86016;

	public const int g_pwron_password_addr = 94208;

	public const int g_cps_password = 98304;

	public const int g_hide_param_addr = 102400;

	public const int g_dtmf_contact_addr = 106496;

	public const int g_5tone_contact_addr = 108544;

	public const int g_Noaa_Decode_addr = 139264;

	public const int g_Noaa_Same_SelfEventCtrl_addr = 139904;

	public const int g_Noaa_event = 143360;

	public const int g_user_tailtone_addr = 282624;

	public const int g_vfo_QT_addr = 368640;

	public const int g_mr_QT_addr = 466944;

	public const int g_pwron_picture = 876544;

	public const int CAL_HEADER_FLAG1 = 171;

	public const int CAL_HEADER_FLAG2 = 205;

	public const int CAL_ENDER_FLAG1 = 220;

	public const int CAL_ENDER_FLAG2 = 186;

	public static byte[] ChallengeRand = new byte[16];

	public static byte u8PasswordValid = 0;

	public static byte Model = 0;

	public static string cps_version;

	public static string boot_version = null;

	public static byte seed = 0;

	public static uint magiccode = 4660u;

	public static ConfigMessage.MSG_MSCAL_UpdateConnRsp UpdataConnRsp = default(ConfigMessage.MSG_MSCAL_UpdateConnRsp);

	private static byte[] ParaRanData(byte[] buf)
	{
		byte[] array = null;
		try
		{
			for (int i = 0; i < buf.Length; i++)
			{
				if (buf[i] == 171 && buf[i + 1] == 205)
				{
					ushort num = BitConverter.ToUInt16(buf, i + 2);
					int num2 = i + num + 6;
					if (buf[num2] == 220 && buf[num2 + 1] == 186)
					{
						array = new byte[num + 8];
						Array.Copy(buf, i, array, 0, array.Length);
						break;
					}
				}
			}
		}
		catch (Exception)
		{
			array = null;
		}
		return array;
	}

	public static bool GetUpdataReady()
	{
		byte[] buf = ComPort.Instance.Read(1000);
		buf = ParaRanData(buf);
		if (buf != null)
		{
			buf = PareData(buf);
			if (buf != null)
			{
				byte[] array = new byte[36];
				buf.CopyTo(array, 0);
				object obj = Iparse.ByteToStruct(array, default(MSG_MSCAL_FileUpdateReady).GetType());
				if (obj != null)
				{
					MSG_MSCAL_FileUpdateReady mSG_MSCAL_FileUpdateReady = (MSG_MSCAL_FileUpdateReady)obj;
					if (mSG_MSCAL_FileUpdateReady.struMsgHeader.u16MsgType == 504)
					{
						if (buf.Length == 36)
						{
							boot_version = Iparse.ConvertByteToString(mSG_MSCAL_FileUpdateReady.versionString, "default");
							string @string = Encoding.ASCII.GetString(mSG_MSCAL_FileUpdateReady.versionString);
							char[] trimChars = new char[1];
							string[] array2 = @string.Trim(trimChars).Split('.');
							wfm_progress.versionHighNo = int.Parse(array2[0]);
						}
						return true;
					}
				}
			}
		}
		return false;
	}

	public static bool SendUpdataConnectOldReq(string ver)
	{
		ConfigMessage.MSG_CALMS_UpdateConnOldReq mSG_CALMS_UpdateConnOldReq = default(ConfigMessage.MSG_CALMS_UpdateConnOldReq);
		mSG_CALMS_UpdateConnOldReq.struMsgHeader.u16MsgType = 528;
		mSG_CALMS_UpdateConnOldReq.struMsgHeader.u16MsgLen = 24;
		mSG_CALMS_UpdateConnOldReq.u32MagicCode = magiccode;
		mSG_CALMS_UpdateConnOldReq.versionString = new byte[16];
		Encoding.ASCII.GetBytes(ver).CopyTo(mSG_CALMS_UpdateConnOldReq.versionString, 0);
		byte[] buf = Iparse.StructToBytes(mSG_CALMS_UpdateConnOldReq, Iparse.GetStructSizeof(mSG_CALMS_UpdateConnOldReq));
		ComPort.Instance.Write(makefram(buf));
		ConfigMessage.MSG_MSCAL_UpdateConnRsp mSG_MSCAL_UpdateConnRsp = default(ConfigMessage.MSG_MSCAL_UpdateConnRsp);
		byte[] array = ComPort.Instance.Read(1000);
		return true;
	}

	public static bool SendUpdataConnectReq(string ver, int seed)
	{
		ConfigMessage.MSG_CALMS_UpdateConnReq mSG_CALMS_UpdateConnReq = default(ConfigMessage.MSG_CALMS_UpdateConnReq);
		mSG_CALMS_UpdateConnReq.struMsgHeader.u16MsgType = 528;
		mSG_CALMS_UpdateConnReq.struMsgHeader.u16MsgLen = 24;
		mSG_CALMS_UpdateConnReq.u32MagicCode = magiccode;
		mSG_CALMS_UpdateConnReq.u8SeedIndex = (byte)seed;
		mSG_CALMS_UpdateConnReq.versionString = new byte[16];
		Encoding.ASCII.GetBytes(ver).CopyTo(mSG_CALMS_UpdateConnReq.versionString, 0);
		byte[] buf = Iparse.StructToBytes(mSG_CALMS_UpdateConnReq, Iparse.GetStructSizeof(mSG_CALMS_UpdateConnReq));
		ComPort.serialPorts.DiscardInBuffer();
		ComPort.Instance.Write(makefram(buf));
		ConfigMessage.MSG_MSCAL_UpdateConnRsp mSG_MSCAL_UpdateConnRsp = default(ConfigMessage.MSG_MSCAL_UpdateConnRsp);
		byte[] buf2 = ComPort.Instance.Read(1000);
		buf2 = ParaRanData(buf2);
		if (buf2 != null)
		{
			buf2 = PareData(buf2);
			if (buf2 != null)
			{
				object obj = Iparse.ByteToStruct(buf2, mSG_MSCAL_UpdateConnRsp.GetType());
				if (obj != null)
				{
					mSG_MSCAL_UpdateConnRsp = (ConfigMessage.MSG_MSCAL_UpdateConnRsp)obj;
					if (mSG_MSCAL_UpdateConnRsp.struMsgHeader.u16MsgType == 530)
					{
						UpdataConnRsp = mSG_MSCAL_UpdateConnRsp;
						return true;
					}
				}
			}
		}
		return true;
	}

	public static byte[] makefram(byte[] buf)
	{
		STRU_CAL_HEADER sTRU_CAL_HEADER = default(STRU_CAL_HEADER);
		sTRU_CAL_HEADER.u8HeaderFlag1 = 171;
		sTRU_CAL_HEADER.u8HeaderFlag2 = 205;
		sTRU_CAL_HEADER.u16Length = (ushort)buf.Length;
		STRU_CAL_ENDER sTRU_CAL_ENDER = default(STRU_CAL_ENDER);
		sTRU_CAL_ENDER.u8EnderFlag1 = 220;
		sTRU_CAL_ENDER.u8EnderFlag2 = 186;
		sTRU_CAL_ENDER.u16CRC = Iparse.CRC16XMODEM(buf);
		byte[] array = new byte[4 + sTRU_CAL_HEADER.u16Length + 4];
		Iparse.StructToBytes(sTRU_CAL_HEADER, Iparse.GetStructSizeof(sTRU_CAL_HEADER)).CopyTo(array, 0);
		buf.CopyTo(array, 4);
		Iparse.StructToBytes(sTRU_CAL_ENDER, Iparse.GetStructSizeof(sTRU_CAL_ENDER)).CopyTo(array, 4 + sTRU_CAL_HEADER.u16Length);
		return byteNorOrParaEx(array, 4, sTRU_CAL_HEADER.u16Length + 2);
	}

	public static byte[] byteNorOrParaEx(byte[] para, int startIndex, int norOrLen)
	{
		byte[] content = new byte[norOrLen];
		Array.Copy(para, startIndex, content, 0, norOrLen);
		ContentNorOr(ref content);
		byte[] array = new byte[para.Length];
		Array.Copy(para, 0, array, 0, startIndex);
		Array.Copy(content, 0, array, startIndex, norOrLen);
		Array.Copy(para, startIndex + norOrLen, array, startIndex + norOrLen, para.Length - (startIndex + norOrLen));
		return array;
	}

	public static bool ContentNorOr(ref byte[] content)
	{
		byte[] array = new byte[16]
		{
			22, 108, 20, 230, 46, 145, 13, 64, 33, 53,
			213, 64, 19, 3, 233, 128
		};
		for (int i = 0; i < content.Length; i++)
		{
			content[i] ^= array[i & 0xF];
		}
		return true;
	}

	public static void Reboot()
	{
		MSG_CALMS_RebootReq mSG_CALMS_RebootReq = default(MSG_CALMS_RebootReq);
		mSG_CALMS_RebootReq.struMsgHeader.u16MsgType = 1501;
		mSG_CALMS_RebootReq.struMsgHeader.u16MsgLen = 0;
		byte[] buf = Iparse.StructToBytes(mSG_CALMS_RebootReq, Iparse.GetStructSizeof(mSG_CALMS_RebootReq));
		ComPort.Instance.Write(makefram(buf));
	}

	public static bool AuthReq(uint[] key)
	{
		MSG_CALMS_AuthReq mSG_CALMS_AuthReq = default(MSG_CALMS_AuthReq);
		mSG_CALMS_AuthReq.struMsgHeader.u16MsgType = 525;
		mSG_CALMS_AuthReq.struMsgHeader.u16MsgLen = 16;
		mSG_CALMS_AuthReq.u32AuthDataBuffer = new uint[4];
		key.CopyTo(mSG_CALMS_AuthReq.u32AuthDataBuffer, 0);
		byte[] buf = Iparse.StructToBytes(mSG_CALMS_AuthReq, Iparse.GetStructSizeof(mSG_CALMS_AuthReq));
		bool flag = ComPort.Instance.Write(makefram(buf));
		MSG_MSCAL_AuthRsp mSG_MSCAL_AuthRsp = default(MSG_MSCAL_AuthRsp);
		byte[] array = ComPort.Instance.Read(1000);
		if (array != null)
		{
			array = PareData(array);
			if (array != null)
			{
				mSG_MSCAL_AuthRsp = (MSG_MSCAL_AuthRsp)Iparse.ByteToStruct(array, mSG_MSCAL_AuthRsp.GetType());
				if (mSG_MSCAL_AuthRsp.struMsgHeader.u16MsgType == 526 && mSG_MSCAL_AuthRsp.u8Result == 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static byte[] PareData(byte[] buf)
	{
		if (buf.Length < 4)
		{
			return null;
		}
		byte[] array = new byte[buf[2] | (buf[3] << 8)];
		int num = 4 + array.Length + 2;
		if (num > buf.Length)
		{
			return null;
		}
		if (buf[0] == 171 && buf[1] == 205 && buf[num] == 220 && buf[num + 1] == 186)
		{
			Array.Copy(buf, 4, array, 0, array.Length);
			array = byteNorOrParaEx(array, 0, array.Length);
		}
		else
		{
			array = null;
		}
		return array;
	}

	public static bool Link(byte retry)
	{
		MSG_CALMS_ConnReq mSG_CALMS_ConnReq = default(MSG_CALMS_ConnReq);
		mSG_CALMS_ConnReq.struMsgHeader.u16MsgType = 500;
		mSG_CALMS_ConnReq.struMsgHeader.u16MsgLen = 4;
		mSG_CALMS_ConnReq.u32MagicCode = magiccode;
		byte[] buf = Iparse.StructToBytes(mSG_CALMS_ConnReq, Iparse.GetStructSizeof(mSG_CALMS_ConnReq));
		for (int i = 0; i < retry; i++)
		{
			ComPort.Instance.Write(makefram(buf));
			MSG_MSCAL_ConnRsp mSG_MSCAL_ConnRsp = default(MSG_MSCAL_ConnRsp);
			byte[] array = ComPort.Instance.Read(1000);
			if (array == null)
			{
				continue;
			}
			array = PareData(array);
			if (array == null)
			{
				continue;
			}
			mSG_MSCAL_ConnRsp = (MSG_MSCAL_ConnRsp)Iparse.ByteToStruct(array, mSG_MSCAL_ConnRsp.GetType());
			if (mSG_MSCAL_ConnRsp.struMsgHeader.u16MsgType == 501)
			{
				cps_version = Iparse.ConvertByteToString(mSG_MSCAL_ConnRsp.versionString, "utf8").Trim();
				for (int j = 0; j < mSG_MSCAL_ConnRsp.u32RandCode.Length; j++)
				{
					BitConverter.GetBytes(mSG_MSCAL_ConnRsp.u32RandCode[j]).Reverse().ToArray()
						.CopyTo(ChallengeRand, j * 4);
				}
				u8PasswordValid = mSG_MSCAL_ConnRsp.u8PasswordValid;
				Model = mSG_MSCAL_ConnRsp.u8ParamsVersion;
				return true;
			}
		}
		return false;
	}

	public static byte[] Read(int address, ushort len)
	{
		MSG_CALMS_ParaReadReq mSG_CALMS_ParaReadReq = default(MSG_CALMS_ParaReadReq);
		mSG_CALMS_ParaReadReq.struMsgHeader.u16MsgType = 507;
		mSG_CALMS_ParaReadReq.struMsgHeader.u16MsgLen = 12;
		mSG_CALMS_ParaReadReq.u32Address = (uint)(524288 + address);
		mSG_CALMS_ParaReadReq.u8DataLen = len;
		mSG_CALMS_ParaReadReq.u32MagicCode = magiccode;
		byte[] buf = Iparse.StructToBytes(mSG_CALMS_ParaReadReq, Iparse.GetStructSizeof(mSG_CALMS_ParaReadReq));
		for (int i = 0; i < 2; i++)
		{
			if (!ComPort.Instance.Write(makefram(buf)))
			{
				continue;
			}
			byte[] array = ComPort.Instance.Read(2000);
			bool flag = false;
			if (array != null)
			{
				array = PareData(array);
				if (array != null && (ushort)(array[0] | (array[1] << 8)) == 508)
				{
					byte[] array2 = new byte[len];
					Array.Copy(array, 12, array2, 0, array2.Length);
					return array2;
				}
			}
		}
		return null;
	}

	public static int Findidx(byte[] buf, int StartIndex, byte cmd1, byte cmd2)
	{
		int num = 0;
		int result = 0;
		for (num = StartIndex; num < buf.Length; num++)
		{
			if (buf[num] == cmd1 && buf[num + 1] == cmd2)
			{
				result = num;
				break;
			}
		}
		return result;
	}

	public static bool paredata(byte[] buf, ushort cmd)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < buf.Length; i++)
		{
			int num3 = Findidx(buf, num, 171, 205);
			if (num3 < num)
			{
				break;
			}
			num = num3;
			num3 = Findidx(buf, num, 220, 186);
			if (num3 < num2)
			{
				break;
			}
			num2 = num3;
			byte[] array = new byte[num2 + 2 - num];
			Array.Copy(buf, num, array, 0, array.Length);
			array = byteNorOrParaEx(array, 4, array[2] | (array[3] << 8));
			if ((ushort)(array[4] | (array[5] << 8)) == cmd)
			{
				if (array[14] == 0)
				{
					return true;
				}
				return false;
			}
			num = num2 + 2;
		}
		return false;
	}

	public static bool check_boot_ver(string ver)
	{
		string[] array = ver.Split('.');
		int num = Convert.ToInt32(array[0]);
		int num2 = Convert.ToInt32(array[2]);
		if (num > 4)
		{
			return true;
		}
		if (num2 > 3)
		{
			return true;
		}
		return false;
	}

	public static bool packetFileEx(byte[] data, int index, int count, int blockLen, uint seqNo)
	{
		byte[] array = null;
		if (check_boot_ver(boot_version))
		{
			ConfigMessage.MSG_CALMS_FileUpdateData mSG_CALMS_FileUpdateData = default(ConfigMessage.MSG_CALMS_FileUpdateData);
			mSG_CALMS_FileUpdateData.struMsgHeader.u16MsgType = 505;
			mSG_CALMS_FileUpdateData.struMsgHeader.u16MsgLen = 272;
			mSG_CALMS_FileUpdateData.u32SeqNo = seqNo;
			mSG_CALMS_FileUpdateData.u16BlockIndex = (ushort)index;
			mSG_CALMS_FileUpdateData.u16BlockSumNum = (ushort)count;
			mSG_CALMS_FileUpdateData.u16ByteCount = (ushort)blockLen;
			mSG_CALMS_FileUpdateData.u8Version = (byte)wfm_progress.version[0];
			mSG_CALMS_FileUpdateData.u32MagicCode = magiccode;
			array = Iparse.StructToBytes(mSG_CALMS_FileUpdateData, Iparse.GetStructSizeof(mSG_CALMS_FileUpdateData));
		}
		else
		{
			ConfigMessage.MSG_CALMS_FileUpdateDataOld mSG_CALMS_FileUpdateDataOld = default(ConfigMessage.MSG_CALMS_FileUpdateDataOld);
			mSG_CALMS_FileUpdateDataOld.struMsgHeader.u16MsgType = 505;
			mSG_CALMS_FileUpdateDataOld.struMsgHeader.u16MsgLen = 272;
			mSG_CALMS_FileUpdateDataOld.u32SeqNo = seqNo;
			mSG_CALMS_FileUpdateDataOld.u16BlockIndex = (ushort)index;
			mSG_CALMS_FileUpdateDataOld.u16BlockSumNum = (ushort)count;
			mSG_CALMS_FileUpdateDataOld.u16ByteCount = (ushort)blockLen;
			array = Iparse.StructToBytes(mSG_CALMS_FileUpdateDataOld, Iparse.GetStructSizeof(mSG_CALMS_FileUpdateDataOld));
		}
		byte[] array2 = new byte[array.Length + blockLen];
		Array.Copy(array, array2, array.Length);
		Array.Copy(data, 0, array2, array.Length, blockLen);
		if (ComPort.Instance.Write(makefram(array2)))
		{
			array2 = ComPort.Instance.Read(1000);
			if (array2 != null)
			{
				return paredata(array2, 506);
			}
		}
		return false;
	}

	public static bool Write(int address, byte[] data, ushort len)
	{
		bool flag = false;
		MSG_CALMS_ParaWriteReq mSG_CALMS_ParaWriteReq = default(MSG_CALMS_ParaWriteReq);
		mSG_CALMS_ParaWriteReq.struMsgHeader.u16MsgType = 509;
		mSG_CALMS_ParaWriteReq.struMsgHeader.u16MsgLen = 12;
		mSG_CALMS_ParaWriteReq.u32Address = (uint)(524288 + address);
		mSG_CALMS_ParaWriteReq.u8DataLen = len;
		mSG_CALMS_ParaWriteReq.u32MagicCode = magiccode;
		byte[] array = Iparse.StructToBytes(mSG_CALMS_ParaWriteReq, Iparse.GetStructSizeof(mSG_CALMS_ParaWriteReq));
		byte[] array2 = new byte[array.Length + len];
		Array.Copy(array, array2, array.Length);
		Array.Copy(data, 0, array2, array.Length, len);
		if (ComPort.Instance.Write(makefram(array2)))
		{
			array2 = ComPort.Instance.Read(1000);
			if (array2 != null)
			{
				array2 = PareData(array2);
				if (array2 != null)
				{
					ushort num = BitConverter.ToUInt16(array2, 0);
					if (num == 510)
					{
						return true;
					}
				}
			}
		}
		return false;
	}
}
