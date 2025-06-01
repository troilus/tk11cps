using System.Runtime.InteropServices;

namespace K7;

public class ConfigMessage
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
		O_CALMS_CMD_IND = 1500,
		O_CALMS_REBOOT_REQ = 1501
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

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] u8Rsv;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public uint[] u32RandCode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public uint[] u32UUID;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_EncryptReq
	{
		public const int NOHEADERLENGTH = 104;

		public OSP_MSG_HEADER struMsgHeader;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 104)]
		public byte[] u8KeyBuffer;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_EncryptRsp
	{
		public const int NOHEADERLENGTH = 4;

		public OSP_MSG_HEADER struMsgHeader;

		public byte u8Result;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] u8Rev;
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
	public struct MSG_CALMS_FileUpdateData
	{
		public const int NOHEADERLENGTH = 272;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32SeqNo;

		public ushort u16BlockIndex;

		public ushort u16BlockSumNum;

		public ushort u16ByteCount;

		public byte u8Version;

		public byte u16Rsv;

		public uint u32MagicCode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_FileUpdateDataOld
	{
		public const int NOHEADERLENGTH = 268;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32SeqNo;

		public ushort u16BlockIndex;

		public ushort u16BlockSumNum;

		public ushort u16ByteCount;

		public ushort u16Rsv;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_FileUpdateDataRsp
	{
		public const int NOHEADERLENGTH = 8;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32SeqNo;

		public ushort u16BlockIndex;

		public byte u8Result;

		public byte u8Rsv;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_ParaReadReq
	{
		public const int NOHEADERLENGTH = 12;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32Address;

		public ushort u16DataLen;

		public ushort u16Rsv;

		public uint u32MagicCode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_ParaReadRsp
	{
		public const int NOHEADERLENGTH = 8;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32Address;

		public ushort u16DataLen;

		public ushort u16Rsv;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_ParaWriteReq
	{
		public const int NOHEADERLENGTH = 524;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32Address;

		public ushort u16DataLen;

		public byte u8AdvanceFlag;

		public byte u8Rsv;

		public uint u32MagicCode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
		public byte[] u8Data;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_ParaWriteRsp
	{
		public const int NOHEADERLENGTH = 4;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32Address;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_CfgRxChanReq
	{
		public const int NOHEADERLENGTH = 20;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32Freq;

		public ushort u16SqlOpenRssiValue;

		public ushort u16SqlOpenNoiseValue;

		public ushort u16SqlOpenGlitchValue;

		public ushort u16SqlCloseRssiValue;

		public ushort u16SqlCloseNoiseValue;

		public ushort u16SqlCloseGlitchValue;

		public short s16FreqError;

		public byte u8Bk4819ChipId;

		public byte u8Rsv;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_CfgRxChanRsp
	{
		public const int NOHEADERLENGTH = 0;

		public OSP_MSG_HEADER struMsgHeader;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_CfgTxChanReq
	{
		public const int NOHEADERLENGTH = 8;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32Freq;

		public byte u8PwrValid;

		public byte u8PwrValue;

		public short s16FreqError;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_CfgTxChanRsp
	{
		public const int NOHEADERLENGTH = 0;

		public OSP_MSG_HEADER struMsgHeader;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_CfgTxPwrReq
	{
		public const int NOHEADERLENGTH = 4;

		public OSP_MSG_HEADER struMsgHeader;

		public byte u8PwrValue;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] u8Rsv;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_CfgTxPwrRsp
	{
		public const int NOHEADERLENGTH = 0;

		public OSP_MSG_HEADER struMsgHeader;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_CfgRxSqlReq
	{
		public const int NOHEADERLENGTH = 12;

		public OSP_MSG_HEADER struMsgHeader;

		public ushort u16SqlOpenRssiValue;

		public ushort u16SqlOpenNoiseValue;

		public ushort u16SqlOpenGlitchValue;

		public ushort u16SqlCloseRssiValue;

		public ushort u16SqlCloseNoiseValue;

		public ushort u16SqlCloseGlitchValue;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_CfgRxSqlRsp
	{
		public const int NOHEADERLENGTH = 0;

		public OSP_MSG_HEADER struMsgHeader;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_GetSqlReq
	{
		public const int NOHEADERLENGTH = 0;

		public OSP_MSG_HEADER struMsgHeader;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_GetSqlRsp
	{
		public const int NOHEADERLENGTH = 4;

		public OSP_MSG_HEADER struMsgHeader;

		public ushort u16RssiValue;

		public byte u8NoiseValue;

		public byte u8GlitchValue;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_GetVolReq
	{
		public const int NOHEADERLENGTH = 0;

		public OSP_MSG_HEADER struMsgHeader;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_GetVolRsp
	{
		public const int NOHEADERLENGTH = 4;

		public OSP_MSG_HEADER struMsgHeader;

		public ushort u16VolValue;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] u8Rsv;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_GetVoxReq
	{
		public const int NOHEADERLENGTH = 0;

		public OSP_MSG_HEADER struMsgHeader;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_GetVoxRsp
	{
		public const int NOHEADERLENGTH = 4;

		public OSP_MSG_HEADER struMsgHeader;

		public ushort u16VoxValue;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] u8Rsv;
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
	public struct MSG_CALMS_CalConnReq
	{
		public const int NOHEADERLENGTH = 4;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32MagicCode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_UpdateConnOldReq
	{
		public const int NOHEADERLENGTH = 24;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32MagicCode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] versionString;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_UpdateConnReq
	{
		public const int NOHEADERLENGTH = 24;

		public OSP_MSG_HEADER struMsgHeader;

		public uint u32MagicCode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] versionString;

		public byte u8SeedIndex;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] rsv;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_MSCAL_UpdateConnRsp
	{
		public const int NOHEADERLENGTH = 52;

		public OSP_MSG_HEADER struMsgHeader;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] versionString;

		public byte u8ParamsVersion;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] rsv;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] u8RandCode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public uint[] u32UUID;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_CmdInd
	{
		public const int NOHEADERLENGTH = 0;

		public OSP_MSG_HEADER struMsgHeader;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MSG_CALMS_RebootReq
	{
		public const int NOHEADERLENGTH = 0;

		public OSP_MSG_HEADER struMsgHeader;
	}

	public const byte PARA_LEN = 8;

	public const int PARA_MAX_LEN = 512;

	public const int UPDATE_CONTENT_LEN = 256;

	public const uint BASE_START_ADDRESS = 524288u;

	public const uint MR_CHANNEL_START_ADDRESS = 524288u;

	public const uint VFO_CHANNEL_START_ADDRESS = 589824u;

	public const uint CHANNEL_FLAG_ADDRESS = 593920u;

	public const uint FMCHNLPARA_START_ADDRESS = 598016u;

	public const uint COMMPARA_START_ADDRESS = 602112u;

	public const uint COMMPARA2_START_ADDRESS = 606208u;

	public const uint CHANINDEX_START_ADDRESS = 610304u;

	public const uint SCANPARA_START_ADDRESS = 614400u;

	public const uint ACCESSPWD_START_ADDRESS = 618496u;

	public const uint PASSWORD_START_ADDRESS = 622592u;

	public const uint PREMIUMPARA_START_ADDRESS = 626688u;

	public const uint DTMF_CONTACT_ADDRESS = 630784u;

	public const uint RFPARA_START_ADDRESS = 655360u;

	public const uint RESOURCE_START_ADDRESS = 1572864u;

	public const uint ENCRYPT_START_ADDRESS = 2023424u;

	public const uint UPDATE_PARAM_START_ADDRESS = 2027520u;

	public const uint UPDATE_SAVE_START_ADDRESS = 2031616u;

	public const uint UPDATE_MAGIC_CODE1 = 305419896u;

	public const uint UPDATE_MAGIC_CODE2 = 2271560481u;

	public const uint UPDATE_MAGIC_CODE3 = 2427178479u;

	public const int CAL_HEADER_FLAG1 = 171;

	public const int CAL_HEADER_FLAG2 = 205;

	public const int CAL_ENDER_FLAG1 = 220;

	public const int CAL_ENDER_FLAG2 = 186;
}
