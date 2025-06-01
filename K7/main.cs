using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using K7.Properties;
using Ude;

namespace K7;

public class main : Form
{
	public const int CH_MAX = 999;

	public const int FM_MAX = 32;

	public const int CONTACT_MAX = 16;

	public const int SCAN_MAX = 32;

	public const int SCAN_MEM_MAX = 48;

	public const int _5TONE_USER_MAX = 15;

	public const int VFO_MAX = 13;

	private static TreeNode tn = new TreeNode();

	public static byte[] CpsData = new byte[880640];

	private SaveFileDialog saveFileDialog1 = new SaveFileDialog();

	private OpenFileDialog openFileDialog1 = new OpenFileDialog();

	private bool isRun = false;

	public static ResourceManager RM;

	public static CHANNEL_INFO[] ChannelInfo = new CHANNEL_INFO[999];

	public static FM_INFO[] FmInfo = new FM_INFO[32];

	public static NOAA_DECODE_ADDR[] NoaaDecodeAddrInfo = new NOAA_DECODE_ADDR[16];

	public static DTMF_INFO DtmfInfo = default(DTMF_INFO);

	public static DTMF_CONTACT_INFO[] DtmfContactInfo = new DTMF_CONTACT_INFO[16];

	public static _5TONE_CONTACT_INFO[] _5toneContactInfo = new _5TONE_CONTACT_INFO[16];

	public static SCAN_INFO[] ScanInfo = new SCAN_INFO[32];

	public static NOAA_EVENT[] NoaaEventInfo = new NOAA_EVENT[32];

	public static GEN_INFO GenInfo = default(GEN_INFO);

	public static _5TONE_INFO _5ToneInfo = default(_5TONE_INFO);

	public static VFO_INFO[,] VfoInfo = new VFO_INFO[2, 13];

	public static CPS_FM_INFO CpsFm = default(CPS_FM_INFO);

	public static NOAA_SEND_SAME NoaaSendSameInfo = default(NOAA_SEND_SAME);

	public static CPS_CHANNEL_INFO[] CpsChannelInfo = new CPS_CHANNEL_INFO[999];

	public static CPS_VFO_INFO[,] CpsVfoInfo = new CPS_VFO_INFO[2, 13];

	public static CPS_CHANNEL_FLAG_INFO CpsChannelFlagInfo = default(CPS_CHANNEL_FLAG_INFO);

	public static CPS_SCAN_INFO[] CpsScanInfo = new CPS_SCAN_INFO[32];

	public static CPS_GEN_INFO CpsGenInfo = default(CPS_GEN_INFO);

	public static CPS_HIDE_PARAM_INFO CpsHideParamInfo = default(CPS_HIDE_PARAM_INFO);

	public static CPS_DTMF_CONTACT_INFO[] CpsDtmfContactInfo = new CPS_DTMF_CONTACT_INFO[16];

	public static CPS_5TONE_CONTACT_INFO[] Cps5toneContactInfo = new CPS_5TONE_CONTACT_INFO[16];

	public static CPS_USER_TAIL_TONE_INFO[] CpsTailToneInfo = new CPS_USER_TAIL_TONE_INFO[5];

	public static CPS_GEN2_INFO CpsGen2Info = default(CPS_GEN2_INFO);

	public static CPS_NOAA_SAME_INFO[] CpsNoaaSame = new CPS_NOAA_SAME_INFO[4];

	public static CPS_CHANNEL_IDX_INFO CpsChnIndex = default(CPS_CHANNEL_IDX_INFO);

	public static CPS_NOAA_DECODE_ADDR[] CpsNoaaDecodeAddr = new CPS_NOAA_DECODE_ADDR[16];

	public static CPS_NOAA_EVENT[] CpsNoaaEventInfo = new CPS_NOAA_EVENT[32];

	public static HIDE_PARAM_FLAG HideParamFlag = default(HIDE_PARAM_FLAG);

	public static int channel_Index = 0;

	public static int fm_Index = 0;

	public static int contact_Index = 0;

	public static int scan_Index = 0;

	public static int vfo_index = 0;

	public static int noaa_decode_addr_index = 0;

	public static int noaa_event_index = 0;

	public static int ModelVersion = 0;

	public static bool IsHideParamTree = false;

	public static byte[] VfoIndexMap = new byte[19]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 4, 5, 6, 7, 8, 9, 11, 12
	};

	public static int m_index;

	public static ToolStripComboBox com_name = new ToolStripComboBox();

	public static string click_item = null;

	public static bool gEngineerMode = false;

	public static string password_mode = "cps";

	public static bool login = false;

	public static string m_Progress = "write";

	public static CPS_PICTURE_INFO CpsPictureInfo = default(CPS_PICTURE_INFO);

	private IContainer components = null;

	private ToolStrip toolStrip1;

	private ToolStripButton 打开OToolStripButton;

	private ToolStripButton 保存SToolStripButton;

	private ToolStripSeparator toolStripSeparator6;

	private ToolStripButton toolStripButton1;

	private ToolStripButton toolStripButton2;

	private ToolStripComboBox toolStripComboBox1;

	private ToolStripComboBox tscmb_lang;

	private ToolStripLabel toolStripLabel1;

	private TreeView treeView1;

	private ToolStripSeparator toolStripSeparator3;

	private ToolStripSeparator toolStripSeparator4;

	private ToolStripSeparator toolStripSeparator5;

	private ToolStripSeparator toolStripSeparator1;

	private ToolStripSeparator toolStripSeparator2;

	private ToolStripButton toolStripButton3;

	private DataGridView dgv_ch;

	private DataGridView dgv_fm;

	private DataGridView dgv_dtmf_contact;

	private DataGridView dgv_scan;

	private DataGridView dgv_vfo;

	private DataGridView dgv_5tone_contacts;

	private ToolStripButton toolStripButton4;

	private ToolStripSeparator toolStripSeparator7;

	private DataGridView dgv_noaa_decode_addr;

	private DataGridView dgv_noaa_event;

	private ToolStripButton toolStripButton5;

	private ToolStripSplitButton tssbt_csv;

	private ToolStripMenuItem tsm_export_ch_csv;

	private ToolStripMenuItem tsm_import_ch_csv;

	public main()
	{
		InitializeComponent();
		NoaaSendSameInfo.same = new string[4];
		tscmb_lang.Visible = false;
		com_name = toolStripComboBox1;
		RefreshCom();
		openFileDialog1.FileOk += openFileDialog1_FileOk;
		dgv_ch.KeyUp += dgv_KeyUp;
		dgv_fm.KeyUp += dgv_KeyUp;
		dgv_scan.KeyUp += dgv_KeyUp;
		dgv_dtmf_contact.KeyUp += dgv_KeyUp;
		dgv_5tone_contacts.KeyUp += dgv_KeyUp;
		dgv_noaa_decode_addr.KeyUp += dgv_KeyUp;
		dgv_noaa_event.KeyUp += dgv_KeyUp;
		dgv_ch.CellClick += dgv_dig_addrbook_CellClick;
		dgv_fm.CellClick += dgv_dig_addrbook_CellClick;
		dgv_scan.CellClick += dgv_dig_addrbook_CellClick;
		dgv_dtmf_contact.CellClick += dgv_dig_addrbook_CellClick;
		dgv_5tone_contacts.CellClick += dgv_dig_addrbook_CellClick;
		dgv_noaa_decode_addr.CellClick += dgv_dig_addrbook_CellClick;
		dgv_noaa_event.CellClick += dgv_dig_addrbook_CellClick;
	}

	private void dgv_dig_addrbook_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		m_index = e.RowIndex;
	}

	private void dgv_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete)
		{
			DataGridView dataGridView = sender as DataGridView;
			if (dataGridView == dgv_ch)
			{
				string name = ChannelInfo[m_index].name;
				ChannelInfo[m_index] = default(CHANNEL_INFO);
				LoadChannelParam(dataGridView, m_index);
				UpdataCallCH(name);
				UpdataScan(name);
			}
			else if (dataGridView == dgv_scan)
			{
				ScanInfo[m_index] = default(SCAN_INFO);
				LoadScanParam(dataGridView, m_index);
			}
			else if (dataGridView == dgv_fm)
			{
				FmInfo[m_index] = default(FM_INFO);
				LoadFmParam(dataGridView, m_index);
			}
			else if (dataGridView == dgv_dtmf_contact)
			{
				DtmfContactInfo[m_index] = default(DTMF_CONTACT_INFO);
				LoadContactParam(dataGridView, m_index);
			}
			else if (dataGridView == dgv_5tone_contacts)
			{
				_5toneContactInfo[m_index] = default(_5TONE_CONTACT_INFO);
				Load_5toneContactParam(dataGridView, m_index);
			}
			else if (dataGridView == dgv_noaa_decode_addr)
			{
				NoaaDecodeAddrInfo[m_index] = default(NOAA_DECODE_ADDR);
				LoadNoaaDecodeAddrParam(dataGridView, m_index);
			}
			else if (dataGridView == dgv_noaa_event)
			{
				NoaaEventInfo[m_index] = default(NOAA_EVENT);
				LoadNoaaEventParam(dataGridView, m_index);
			}
		}
	}

	public void UpdataCallCH(string name)
	{
		if (!string.IsNullOrEmpty(name) && GenInfo.call_chn == name)
		{
			GenInfo.call_chn = GetLang("_null");
		}
	}

	public void UpdataScan(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return;
		}
		for (int i = 0; i < ScanInfo.Length; i++)
		{
			if (ScanInfo[i].member == null)
			{
				continue;
			}
			if (ScanInfo[i].member.Contains(name))
			{
				int num = 0;
				string[] array = new string[ScanInfo[i].member.Length];
				for (int j = 0; j < ScanInfo[i].member.Length && ScanInfo[i].member[j] != null; j++)
				{
					if (ScanInfo[i].member[j] != name)
					{
						array[num++] = ScanInfo[i].member[j];
					}
				}
				if (num == 0)
				{
					ScanInfo[i].name = null;
				}
				for (int j = 0; j < ScanInfo[i].member.Length; j++)
				{
					ScanInfo[i].member[j] = array[j];
				}
			}
			if (ScanInfo[i].prio_1 == name)
			{
				ScanInfo[i].prio_1 = GetLang("_null");
			}
			if (ScanInfo[i].prio_2 == name)
			{
				ScanInfo[i].prio_2 = GetLang("_null");
			}
			LoadScanParam(dgv_scan, i);
		}
	}

	public HIDE_PARAM_FLAG HideParamInit()
	{
		HIDE_PARAM_FLAG result = default(HIDE_PARAM_FLAG);
		result.cps_retry_time = 1m;
		result.noaa_send_type = GetLang("off");
		return result;
	}

	public static string GetComName()
	{
		return com_name.Text;
	}

	public void RefreshCom()
	{
		string value = Iparse.getchart("com", "com");
		try
		{
			toolStripComboBox1.Items.Clear();
			string[] portNames = SerialPort.GetPortNames();
			if (portNames.Length > 0)
			{
				toolStripComboBox1.Items.AddRange(SerialPort.GetPortNames());
				if (portNames.Contains(value))
				{
					toolStripComboBox1.Text = value;
				}
				else
				{
					toolStripComboBox1.Text = portNames[0];
				}
				Iparse.setchart("com", "com", toolStripComboBox1.Text);
			}
			else
			{
				toolStripComboBox1.Text = null;
			}
		}
		catch (Exception)
		{
		}
	}

	public string GetLang(string s)
	{
		string @string = RM.GetString(s);
		string[] array = @string.Split('/');
		return array[GetLang()];
	}

	public static string[] GetChannelName()
	{
		List<string> list = new List<string>();
		CHANNEL_INFO[] channelInfo = ChannelInfo;
		for (int i = 0; i < channelInfo.Length; i++)
		{
			CHANNEL_INFO cHANNEL_INFO = channelInfo[i];
			if (!string.IsNullOrWhiteSpace(cHANNEL_INFO.tx_freq))
			{
				list.Add(cHANNEL_INFO.name);
			}
		}
		string[] array = new string[list.Count];
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = list[j];
		}
		return array;
	}

	public void CreatChnParam()
	{
		for (int i = 0; i < 999; i++)
		{
			ref CHANNEL_INFO reference = ref ChannelInfo[i];
			reference = ChannelInit(i);
			LoadChannelParam(dgv_ch, i);
		}
	}

	public CHANNEL_INFO ChannelInit(int idx)
	{
		CHANNEL_INFO result = default(CHANNEL_INFO);
		result.name = "CH-" + (idx + 1).ToString("000");
		result.rx_freq = "400.02500";
		result.tx_freq = result.rx_freq;
		result.freq_rang = "400M-470M";
		result.step = "12.5K";
		result.power = GetLang("high");
		result.scanlist = "0";
		result.rx_qt_type = GetLang("_null");
		result.tx_qt_type = GetLang("_null");
		result.qt_rx_null = GetLang("_null");
		result.qt_rx_ctc = param_string.CtcssString[0];
		result.qt_rx_dcs = param_string.DcsString[0];
		result.qt_tx_null = GetLang("_null");
		result.qt_tx_ctc = param_string.CtcssString[0];
		result.qt_tx_dcs = param_string.DcsString[0];
		result.non_stand_type1 = GetLang("_null");
		result.non_stand_type2 = GetLang("_null");
		result.qt_encode2 = GetLang("_null");
		result.busy = GetLang("off");
		result.pttid = GetLang("off");
		result.dtmf_decdoe_flag = GetLang("off");
		result.am = "FM";
		result.reverse = GetLang("off");
		result.encypt = GetLang("off");
		result.sq = "4";
		result.band = "25K";
		result.msw = "2K";
		return result;
	}

	private void main_Load(object sender, EventArgs e)
	{
		tssbt_csv.Visible = true;
		isRun = false;
		base.WindowState = FormWindowState.Maximized;
		RM = new ResourceManager("K7.Resource", Assembly.GetExecutingAssembly());
		toolStripButton2.Image = Resources.read;
		toolStripButton1.Image = Resources.write;
		toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		tscmb_lang.DropDownStyle = ComboBoxStyle.DropDownList;
		tscmb_lang.SelectedIndex = GetLang();
		toolStripButton3.Text = GetLang("password");
		toolStripButton5.Text = GetLang("firmware_updata");
		toolStripButton4.Text = GetLang("eng_mode");
		tssbt_csv.Text = GetLang("CSV操作");
		tsm_export_ch_csv.Text = GetLang("导出信道CSV");
		tsm_import_ch_csv.Text = GetLang("导入信道CSV");
		Text = GetLang("model");
		base.Icon = Resources.标题;
		loadTreeMenu();
		GridViewChannelInit();
		GridViewFmInit();
		GridViewDtmfContactInit();
		GridView5toneContactInit();
		GridViewScanInit();
		GridViewVfoInit();
		GridViewNoaaDecodeAddrInit();
		GridViewNoaaEventInit();
		dgv_visible(dgv_ch);
		for (int i = 0; i < 13; i++)
		{
			VfoParamInfo(0, i);
			VfoParamInfo(1, i);
		}
		RefreshDgvVfo();
		HideParamFlag = HideParamInit();
		isRun = true;
	}

	public void VfoParamInfo(int ab, int index)
	{
		VFO_INFO vFO_INFO = default(VFO_INFO);
		if (ab == 0)
		{
			vFO_INFO.name += "A";
		}
		else
		{
			vFO_INFO.name += "B";
		}
		vFO_INFO.name += "-";
		vFO_INFO.name = vFO_INFO.name + "F" + (index + 1).ToString("00");
		vFO_INFO.rx_freq = param_string.freq_rang[index * 2].ToString("0.00000");
		vFO_INFO.tx_freq = vFO_INFO.rx_freq;
		List<string> list = param_string.chn_freq_rang_Items();
		vFO_INFO.freq_rang = list[index];
		vFO_INFO.band = "25K";
		vFO_INFO.msw = "2K";
		vFO_INFO.power = GetLang("high");
		vFO_INFO.scanlist = "0";
		vFO_INFO.rx_qt_type = GetLang("_null");
		vFO_INFO.tx_qt_type = GetLang("_null");
		vFO_INFO.qt_rx_null = GetLang("_null");
		vFO_INFO.qt_rx_ctc = param_string.CtcssString[0];
		vFO_INFO.qt_rx_dcs = param_string.DcsString[0];
		vFO_INFO.qt_tx_null = GetLang("_null");
		vFO_INFO.qt_tx_ctc = param_string.CtcssString[0];
		vFO_INFO.qt_tx_dcs = param_string.DcsString[0];
		vFO_INFO.busy = GetLang("off");
		vFO_INFO.pttid = GetLang("off");
		vFO_INFO.dtmf_decdoe_flag = GetLang("off");
		vFO_INFO.am = "FM";
		vFO_INFO.reverse = GetLang("off");
		vFO_INFO.encypt = GetLang("off");
		vFO_INFO.sq = "4";
		vFO_INFO.qt_encode2 = GetLang("_null");
		vFO_INFO.non_stand_type1 = GetLang("_null");
		vFO_INFO.non_stand_type2 = GetLang("_null");
		vFO_INFO.signal = GetLang("gen_dtmf");
		vFO_INFO.scan_start = param_string.freq_rang[index * 2].ToString("0.00000");
		vFO_INFO.scan_end = param_string.freq_rang[index * 2 + 1].ToString("0.00000");
		vFO_INFO.step = "12.5K";
		vFO_INFO.freq_dir = GetLang("_null");
		vFO_INFO.freq_diff = "0";
		vFO_INFO.forbid_tx = false;
		VfoInfo[ab, index] = vFO_INFO;
	}

	public void dgv_visible(DataGridView dgv)
	{
		dgv_fm.Visible = false;
		dgv_ch.Visible = false;
		dgv_dtmf_contact.Visible = false;
		dgv_scan.Visible = false;
		dgv_vfo.Visible = false;
		dgv_5tone_contacts.Visible = false;
		dgv_noaa_decode_addr.Visible = false;
		dgv_noaa_event.Visible = false;
		dgv.Visible = true;
	}

	public void GridViewChannelInit()
	{
		DataGridView dataGridView = dgv_ch;
		DoubleBuffered(dataGridView);
		dataGridView.ReadOnly = true;
		dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowHeadersVisible = false;
		dataGridView.AllowUserToAddRows = false;
		dataGridView.RowTemplate.Height = 20;
		for (int i = 0; i < 20; i++)
		{
			DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
			dataGridView.Columns.Add(dataGridViewColumn);
			dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
		}
		dataGridView.Columns[0].Width = 50;
		for (int i = 1; i < 20; i++)
		{
			dataGridView.Columns[i].Width = 100;
		}
		int num = 0;
		dataGridView.Columns[num++].HeaderText = GetLang("chn_no");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_name");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_rxfreq");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_txfreq");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_encode");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_qt_encode1");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_decode");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_qt_decode");
		dataGridView.Columns[num++].HeaderText = "MSW";
		dataGridView.Columns[num++].HeaderText = GetLang("chn_band");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_power");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_busy");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_scan");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_AM");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_freq_revers");
		dataGridView.Columns[num++].HeaderText = GetLang("gen_sq");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_encrpyt");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_dtmf_decode");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_pttid");
		dataGridView.Columns[num++].HeaderText = GetLang("gen_signal");
		dataGridView.Rows.Add(999);
		for (int i = 0; i < 999; i++)
		{
			dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
		}
	}

	public void GridViewVfoInit()
	{
		DataGridView dataGridView = dgv_vfo;
		DoubleBuffered(dataGridView);
		dataGridView.ReadOnly = true;
		dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
		dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowHeadersVisible = false;
		dataGridView.AllowUserToAddRows = false;
		dataGridView.RowTemplate.Height = 20;
		for (int i = 0; i < 20; i++)
		{
			DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
			dataGridView.Columns.Add(dataGridViewColumn);
			dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			if (i == 1)
			{
				dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			}
			else
			{
				dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
		}
		dataGridView.Columns[0].Width = 50;
		dataGridView.Columns[1].Width = 50;
		dataGridView.Columns[2].Width = 100;
		dataGridView.Columns[3].Width = 100;
		dataGridView.Columns[18].Width = 150;
		int num = 0;
		dataGridView.Columns[num++].HeaderText = GetLang("chn_no");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_name");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_rxfreq");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_encode");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_decode");
		dataGridView.Columns[num++].HeaderText = "MSW";
		dataGridView.Columns[num++].HeaderText = GetLang("chn_band");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_power");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_busy");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_AM");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_freq_revers");
		dataGridView.Columns[num++].HeaderText = GetLang("gen_sq");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_encrpyt");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_dtmf_decode");
		dataGridView.Columns[num++].HeaderText = GetLang("chn_pttid");
		dataGridView.Columns[num++].HeaderText = GetLang("vfo_step");
		dataGridView.Columns[num++].HeaderText = GetLang("vfo_direction");
		dataGridView.Columns[num++].HeaderText = GetLang("vfo_difference");
		dataGridView.Columns[num++].HeaderText = GetLang("vfo_scan_rang");
		dataGridView.Columns[num++].HeaderText = GetLang("gen_signal");
		dataGridView.Rows.Add(19);
		for (int i = 0; i < 19; i++)
		{
			dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
		}
	}

	public static void LoadChannelParam(DataGridView dgv, int i)
	{
		int num = 0;
		CHANNEL_INFO cHANNEL_INFO = ChannelInfo[i];
		dgv.Rows[i].Cells[num++].Value = (i + 1).ToString();
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.name;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.rx_freq;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.tx_freq;
		string text = null;
		List<string> list = param_string.chn_qttype_Items();
		text = list.IndexOf(cHANNEL_INFO.tx_qt_type) switch
		{
			0 => cHANNEL_INFO.qt_tx_null, 
			1 => cHANNEL_INFO.qt_tx_ctc, 
			_ => cHANNEL_INFO.qt_tx_dcs, 
		};
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.tx_qt_type;
		dgv.Rows[i].Cells[num++].Value = text;
		switch (list.IndexOf(cHANNEL_INFO.rx_qt_type))
		{
		case 0:
			text = cHANNEL_INFO.qt_rx_null;
			break;
		case 1:
			text = cHANNEL_INFO.qt_rx_ctc;
			break;
		case 2:
			text = cHANNEL_INFO.qt_rx_dcs;
			break;
		}
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.rx_qt_type;
		dgv.Rows[i].Cells[num++].Value = text;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.msw;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.band;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.power;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.busy;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.scanlist;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.am;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.reverse;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.sq;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.encypt;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.dtmf_decdoe_flag;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.pttid;
		dgv.Rows[i].Cells[num++].Value = cHANNEL_INFO.signal;
	}

	public new static void DoubleBuffered(DataGridView dgvMain)
	{
		Type type = dgvMain.GetType();
		PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
		property.SetValue(dgvMain, true, null);
	}

	public void loadTreeMenu()
	{
		treeView1.Nodes.Clear();
		tn = treeView1.Nodes.Add(GetLang("model"), GetLang("model"), 0, 0);
		tn.Nodes.Add(GetLang("basic_info"), GetLang("basic_info"), 0, 0);
		tn.Nodes.Add(GetLang("genset"), GetLang("genset"), 0, 0);
		tn.Nodes.Add(GetLang("channel"), GetLang("channel"), 0, 0);
		tn.Nodes.Add(GetLang("scan"), GetLang("scan"), 0, 0);
		tn.Nodes.Add(GetLang("dmtf"), GetLang("dmtf"), 0, 0);
		tn.Nodes.Add(GetLang("contact"), GetLang("contact"), 0, 0);
		tn.Nodes.Add(GetLang("_5tone"), GetLang("_5tone"), 0, 0);
		tn.Nodes.Add(GetLang("_5tone_contacts"), GetLang("_5tone_contacts"), 0, 0);
		tn.Nodes.Add(GetLang("fm"), GetLang("fm"), 0, 0);
		tn.Nodes.Add(GetLang("vfo"), GetLang("vfo"), 0, 0);
		tn.Nodes.Add(GetLang("NOAA_DECODE_ADDR"), GetLang("NOAA_DECODE_ADDR"), 0, 0);
		tn.Nodes.Add(GetLang("NOAA_EVENT"), GetLang("NOAA_EVENT"), 0, 0);
		tn.Expand();
	}

	private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (isRun)
		{
			if (GetLang() == 0)
			{
				Iparse.setchart("Lang", "Lang", "EN");
			}
			else
			{
				Iparse.setchart("Lang", "Lang", "CN");
			}
			Application.ExitThread();
			Thread thread = new Thread(run);
			object executablePath = Application.ExecutablePath;
			Thread.Sleep(1);
			thread.Start(executablePath);
		}
	}

	public static byte GetLang()
	{
		return 1;
	}

	private void run(object obj)
	{
		Process process = new Process();
		process.StartInfo.FileName = obj.ToString();
		process.Start();
	}

	private void toolStripButton3_Click(object sender, EventArgs e)
	{
		Passwrod passwrod = new Passwrod();
		passwrod.ShowDialog();
	}

	private void GridViewInfo_CH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			channel_Index = e.RowIndex;
			channel channel2 = new channel();
			channel2.ShowDialog();
			LoadChannelParam(dgv_ch, channel_Index);
		}
	}

	public void GridViewFmInit()
	{
		DataGridView dataGridView = new DataGridView();
		dataGridView = dgv_fm;
		DoubleBuffered(dataGridView);
		dataGridView.ReadOnly = true;
		dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowHeadersVisible = false;
		dataGridView.AllowUserToAddRows = false;
		dataGridView.RowTemplate.Height = 20;
		for (int i = 0; i < 3; i++)
		{
			DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
			dataGridView.Columns.Add(dataGridViewColumn);
			dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
		}
		dataGridView.Columns[0].Width = 100;
		dataGridView.Columns[1].Width = 300;
		dataGridView.Columns[0].HeaderText = GetLang("fm_no");
		dataGridView.Columns[1].HeaderText = GetLang("fm_freq");
		dataGridView.Rows.Add(32);
		for (int i = 0; i < 32; i++)
		{
			dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
		}
	}

	public void GridViewNoaaEventInit()
	{
		DataGridView dataGridView = new DataGridView();
		dataGridView = dgv_noaa_event;
		DoubleBuffered(dataGridView);
		dataGridView.ReadOnly = true;
		dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowHeadersVisible = false;
		dataGridView.AllowUserToAddRows = false;
		dataGridView.RowTemplate.Height = 20;
		for (int i = 0; i < 6; i++)
		{
			DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
			dataGridView.Columns.Add(dataGridViewColumn);
			dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
		}
		dataGridView.Columns[0].Width = 100;
		dataGridView.Columns[1].Width = 200;
		dataGridView.Columns[2].Width = 100;
		dataGridView.Columns[3].Width = 100;
		int num = 0;
		dataGridView.Columns[num++].HeaderText = GetLang("fm_no");
		dataGridView.Columns[num++].HeaderText = GetLang("NOAA_EVENT_NUMBER");
		dataGridView.Columns[num++].HeaderText = GetLang("NOAA_EVENT_DURATION");
		dataGridView.Columns[num++].HeaderText = GetLang("NOAA_EVENT_DATE");
		dataGridView.Columns[num++].HeaderText = GetLang("NOAA_EVENT_BEFOR_ORG");
		dataGridView.Columns[num++].HeaderText = GetLang("NOAA_EVENT_CURRENT_ORG");
		dataGridView.Rows.Add(32);
		for (int i = 0; i < 32; i++)
		{
			dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
		}
	}

	public void GridViewNoaaDecodeAddrInit()
	{
		DataGridView dataGridView = new DataGridView();
		dataGridView = dgv_noaa_decode_addr;
		DoubleBuffered(dataGridView);
		dataGridView.ReadOnly = true;
		dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowHeadersVisible = false;
		dataGridView.AllowUserToAddRows = false;
		dataGridView.RowTemplate.Height = 20;
		for (int i = 0; i < 3; i++)
		{
			DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
			dataGridView.Columns.Add(dataGridViewColumn);
			dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
		}
		dataGridView.Columns[0].Width = 100;
		dataGridView.Columns[1].Width = 300;
		dataGridView.Columns[0].HeaderText = GetLang("fm_no");
		dataGridView.Columns[1].HeaderText = GetLang("NOAA_ADDR");
		dataGridView.Columns[2].HeaderText = GetLang("NOAA_INFO");
		dataGridView.Rows.Add(16);
		for (int i = 0; i < 16; i++)
		{
			dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
		}
	}

	public void GridViewDtmfContactInit()
	{
		DataGridView dataGridView = new DataGridView();
		dataGridView = dgv_dtmf_contact;
		DoubleBuffered(dataGridView);
		dataGridView.ReadOnly = true;
		dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowHeadersVisible = false;
		dataGridView.AllowUserToAddRows = false;
		dataGridView.RowTemplate.Height = 20;
		for (int i = 0; i < 4; i++)
		{
			DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
			dataGridView.Columns.Add(dataGridViewColumn);
			dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
		}
		dataGridView.Columns[0].Width = 100;
		dataGridView.Columns[1].Width = 200;
		dataGridView.Columns[2].Width = 200;
		dataGridView.Columns[0].HeaderText = GetLang("chn_no");
		dataGridView.Columns[1].HeaderText = GetLang("chn_name");
		dataGridView.Columns[2].HeaderText = GetLang("dtmf_code");
		dataGridView.Rows.Add(16);
		for (int i = 0; i < 16; i++)
		{
			dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
		}
	}

	public void GridView5toneContactInit()
	{
		DataGridView dataGridView = new DataGridView();
		dataGridView = dgv_5tone_contacts;
		DoubleBuffered(dataGridView);
		dataGridView.ReadOnly = true;
		dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowHeadersVisible = false;
		dataGridView.AllowUserToAddRows = false;
		dataGridView.RowTemplate.Height = 20;
		for (int i = 0; i < 4; i++)
		{
			DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
			dataGridView.Columns.Add(dataGridViewColumn);
			dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
		}
		dataGridView.Columns[0].Width = 100;
		dataGridView.Columns[1].Width = 200;
		dataGridView.Columns[2].Width = 200;
		dataGridView.Columns[0].HeaderText = GetLang("chn_no");
		dataGridView.Columns[1].HeaderText = GetLang("chn_name");
		dataGridView.Columns[2].HeaderText = GetLang("dtmf_code");
		dataGridView.Rows.Add(16);
		for (int i = 0; i < 16; i++)
		{
			dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
		}
	}

	private void dgv_fm_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			fm_Index = e.RowIndex;
			fm fm2 = new fm();
			fm2.ShowDialog();
			LoadFmParam(dgv_fm, fm_Index);
		}
	}

	public static void LoadFmParam(DataGridView dgv, int i)
	{
		int num = 0;
		FM_INFO fM_INFO = FmInfo[i];
		dgv.Rows[i].Cells[num++].Value = (i + 1).ToString();
		dgv.Rows[i].Cells[num++].Value = fM_INFO.freq;
	}

	private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		if (e.Node.Parent != null)
		{
			Text = e.Node.Name;
			if (e.Node.Name == GetLang("basic_info"))
			{
				wfm_basicinfo wfm_basicinfo2 = new wfm_basicinfo();
				wfm_basicinfo2.ShowDialog();
			}
			else if (e.Node.Name == GetLang("channel"))
			{
				dgv_visible(dgv_ch);
			}
			else if (e.Node.Name == GetLang("vfo"))
			{
				dgv_visible(dgv_vfo);
			}
			else if (e.Node.Name == GetLang("scan"))
			{
				dgv_visible(dgv_scan);
			}
			else if (e.Node.Name == GetLang("dmtf"))
			{
				dtmf dtmf2 = new dtmf();
				DoubleBuffered(dtmf2);
				dtmf2.ShowDialog();
			}
			else if (e.Node.Name == GetLang("_5tone"))
			{
				_5tone _5tone2 = new _5tone();
				DoubleBuffered(_5tone2);
				_5tone2.ShowDialog();
			}
			else if (e.Node.Name == GetLang("genset"))
			{
				genset genset2 = new genset();
				DoubleBuffered(genset2);
				genset2.ShowDialog();
			}
			else if (e.Node.Name == GetLang("fm"))
			{
				dgv_visible(dgv_fm);
			}
			else if (e.Node.Name == GetLang("contact"))
			{
				dgv_visible(dgv_dtmf_contact);
			}
			else if (e.Node.Name == GetLang("_5tone_contacts"))
			{
				dgv_visible(dgv_5tone_contacts);
			}
			else if (e.Node.Name == GetLang("Hide_param"))
			{
				wfm_hide_param wfm_hide_param2 = new wfm_hide_param();
				DoubleBuffered(wfm_hide_param2);
				wfm_hide_param2.ShowDialog();
			}
			else if (e.Node.Name == GetLang("NOAA_DECODE_ADDR"))
			{
				dgv_visible(dgv_noaa_decode_addr);
			}
			else if (e.Node.Name == GetLang("NOAA_EVENT"))
			{
				dgv_visible(dgv_noaa_event);
			}
		}
	}

	public new static void DoubleBuffered(Form dgvMain)
	{
		Type type = dgvMain.GetType();
		PropertyInfo property = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
		property.SetValue(dgvMain, true, null);
	}

	private void dgv_dtmf_contact_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			contact_Index = e.RowIndex;
			contact contact2 = new contact();
			click_item = "dtmf";
			contact2.ShowDialog();
			LoadContactParam(dgv_dtmf_contact, contact_Index);
		}
	}

	public static void LoadContactParam(DataGridView dgv, int i)
	{
		int num = 0;
		DTMF_CONTACT_INFO dTMF_CONTACT_INFO = DtmfContactInfo[i];
		dgv.Rows[i].Cells[num++].Value = (i + 1).ToString();
		dgv.Rows[i].Cells[num++].Value = dTMF_CONTACT_INFO.name;
		dgv.Rows[i].Cells[num++].Value = dTMF_CONTACT_INFO.id;
	}

	public static void Load_5toneContactParam(DataGridView dgv, int i)
	{
		int num = 0;
		_5TONE_CONTACT_INFO _5TONE_CONTACT_INFO2 = _5toneContactInfo[i];
		dgv.Rows[i].Cells[num++].Value = (i + 1).ToString();
		dgv.Rows[i].Cells[num++].Value = _5TONE_CONTACT_INFO2.name;
		dgv.Rows[i].Cells[num++].Value = _5TONE_CONTACT_INFO2.id;
	}

	private void dgv_scan_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			scan_Index = e.RowIndex;
			scan scan2 = new scan();
			scan2.ShowDialog();
			LoadScanParam(dgv_scan, scan_Index);
		}
	}

	public static void LoadScanParam(DataGridView dgv, int i)
	{
		int num = 0;
		SCAN_INFO sCAN_INFO = ScanInfo[i];
		dgv.Rows[i].Cells[num++].Value = (i + 1).ToString();
		dgv.Rows[i].Cells[num++].Value = sCAN_INFO.name;
		dgv.Rows[i].Cells[num++].Value = sCAN_INFO.prio_1;
		dgv.Rows[i].Cells[num++].Value = sCAN_INFO.prio_2;
	}

	public void GridViewScanInit()
	{
		DataGridView dataGridView = new DataGridView();
		dataGridView = dgv_scan;
		DoubleBuffered(dataGridView);
		dataGridView.ReadOnly = true;
		dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowHeadersVisible = false;
		dataGridView.AllowUserToAddRows = false;
		dataGridView.RowTemplate.Height = 20;
		for (int i = 0; i < 5; i++)
		{
			DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
			dataGridView.Columns.Add(dataGridViewColumn);
			dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
		}
		dataGridView.Columns[0].Width = 100;
		dataGridView.Columns[1].Width = 150;
		dataGridView.Columns[2].Width = 150;
		dataGridView.Columns[3].Width = 150;
		dataGridView.Columns[0].HeaderText = GetLang("fm_no");
		dataGridView.Columns[1].HeaderText = GetLang("chn_name");
		dataGridView.Columns[2].HeaderText = GetLang("prio_1");
		dataGridView.Columns[3].HeaderText = GetLang("prio_2");
		dataGridView.Rows.Add(32);
		for (int i = 0; i < 32; i++)
		{
			dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
		}
	}

	private void dgv_vfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			vfo_index = e.RowIndex;
			vfo vfo2 = new vfo();
			vfo2.ShowDialog();
			LoadVfoParam(dgv_vfo, vfo_index);
		}
	}

	public static void LoadVfoParam(DataGridView dgv, int i)
	{
		int num = 0;
		int num2 = 0;
		num2 = ((i >= 11) ? 1 : 0);
		VFO_INFO vFO_INFO = VfoInfo[num2, VfoIndexMap[i]];
		num = 0;
		dgv.Rows[i].Cells[num++].Value = (i + 1).ToString();
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.name;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.rx_freq;
		string value = null;
		List<string> list = param_string.chn_qttype_Items();
		switch (list.IndexOf(vFO_INFO.tx_qt_type))
		{
		case 0:
			value = vFO_INFO.qt_tx_null;
			break;
		case 1:
			value = vFO_INFO.qt_tx_ctc;
			break;
		case 2:
			value = "DN" + vFO_INFO.qt_tx_dcs;
			break;
		case 3:
			value = "DI" + vFO_INFO.qt_tx_dcs;
			break;
		}
		dgv.Rows[i].Cells[num++].Value = value;
		switch (list.IndexOf(vFO_INFO.rx_qt_type))
		{
		case 0:
			value = vFO_INFO.qt_rx_null;
			break;
		case 1:
			value = vFO_INFO.qt_rx_ctc;
			break;
		case 2:
			value = "DN" + vFO_INFO.qt_rx_dcs;
			break;
		case 3:
			value = "DI" + vFO_INFO.qt_rx_dcs;
			break;
		}
		dgv.Rows[i].Cells[num++].Value = value;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.msw;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.band;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.power;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.busy;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.am;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.reverse;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.sq;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.encypt;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.dtmf_decdoe_flag;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.pttid;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.step;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.freq_dir;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.freq_diff;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.scan_start + "-" + vFO_INFO.scan_end;
		dgv.Rows[i].Cells[num++].Value = vFO_INFO.signal;
	}

	private void toolStripComboBox1_Enter(object sender, EventArgs e)
	{
	}

	private void toolStripComboBox1_DropDown(object sender, EventArgs e)
	{
		RefreshCom();
	}

	private void toolStripButton1_Click(object sender, EventArgs e)
	{
		bool flag = false;
		wfm_progress.exit = false;
		Random random = new Random();
		protocol_struct.magiccode = (uint)random.Next();
		if (ComPort.Instance.Open())
		{
			flag = Login();
			ComPort.Instance.Close();
			if (flag)
			{
				m_Progress = "read";
				InitParam(ref CpsData);
				wfm_progress wfm_progress2 = new wfm_progress();
				wfm_progress2.ShowDialog();
				string text = (text = Application.StartupPath + "\\tmp.dat");
				FileStream fileStream = new FileStream(text, FileMode.OpenOrCreate);
				fileStream.SetLength(0L);
				BinaryWriter binaryWriter = new BinaryWriter(fileStream, Encoding.Default);
				binaryWriter.Write(CpsData);
				binaryWriter.Close();
				PareCpsData("cps");
			}
		}
	}

	public bool Login()
	{
		if (!protocol_struct.Link(3))
		{
			MessageBox.Show(GetLang("link_error"));
			return false;
		}
		if (protocol_struct.Model != ModelVersion)
		{
			MessageBox.Show(GetLang("model_error"));
			return false;
		}
		if (protocol_struct.u8PasswordValid == 1)
		{
			login login2 = new login();
			password_mode = "cps";
			login2.ShowDialog();
			if (!login)
			{
				return false;
			}
		}
		return true;
	}

	public void PareCpsData(string path)
	{
		ConvertCpsChannelParam();
		ConvertCpsVfoParam();
		ConvertCpsFmParam();
		ConvertCpsHideParam();
		ConvertCpsGenParam();
		ConvertCpsGen2Param();
		ConvertCpsScanParam();
		ConvertCpsPasswordParam();
		ConvertCpsDtmfContctParam();
		ConvertCps_5toneContctParam();
		ConvertCpsNoaaDecodeAddrParam();
		ConverCpsNoaaEventParam();
		ConverCpsChannelIdxParam();
		if (path == "cps" || IsHideParamTree)
		{
			ConvertCpsHideParamflag();
		}
		dgv_visible(dgv_ch);
		RefreshDgvVfo();
	}

	public void RefreshDgvVfo()
	{
		for (int i = 0; i < 11; i++)
		{
			LoadVfoParam(dgv_vfo, i);
		}
		for (int i = 0; i < 8; i++)
		{
			LoadVfoParam(dgv_vfo, i + 11);
		}
	}

	public void ConverCpsChannelIdxParam()
	{
		int sourceIndex = 86016;
		CPS_CHANNEL_IDX_INFO cPS_CHANNEL_IDX_INFO = default(CPS_CHANNEL_IDX_INFO);
		ushort num = (ushort)Iparse.GetStructSizeof(cPS_CHANNEL_IDX_INFO);
		byte[] array = new byte[num];
		Array.Copy(CpsData, sourceIndex, array, 0, num);
		cPS_CHANNEL_IDX_INFO = (CPS_CHANNEL_IDX_INFO)Iparse.ByteToStruct(array, cPS_CHANNEL_IDX_INFO.GetType());
		List<string> list = param_string.gen_A_MR_VFO_Items();
		try
		{
			GenInfo.A_vfo_mr_mode = list[cPS_CHANNEL_IDX_INFO.A_idx];
		}
		catch (Exception)
		{
			GenInfo.A_vfo_mr_mode = list[0];
		}
		list = param_string.gen_B_MR_VFO_Items();
		try
		{
			GenInfo.B_vfo_mr_mode = list[cPS_CHANNEL_IDX_INFO.B_idx];
		}
		catch (Exception)
		{
			GenInfo.B_vfo_mr_mode = list[0];
		}
	}

	public void ConvertCpsNoaaDecodeAddrParam()
	{
		int num = 139264;
		CPS_NOAA_DECODE_ADDR cPS_NOAA_DECODE_ADDR = default(CPS_NOAA_DECODE_ADDR);
		ushort num2 = (ushort)Iparse.GetStructSizeof(cPS_NOAA_DECODE_ADDR);
		for (int i = 0; i < 16; i++)
		{
			byte[] array = new byte[num2];
			Array.Copy(CpsData, num, array, 0, num2);
			if (array[0] == byte.MaxValue)
			{
				array = new byte[num2];
			}
			ref CPS_NOAA_DECODE_ADDR reference = ref CpsNoaaDecodeAddr[i];
			reference = (CPS_NOAA_DECODE_ADDR)Iparse.ByteToStruct(array, cPS_NOAA_DECODE_ADDR.GetType());
			num += num2;
		}
		NoaaDecodeAddrInfo = new NOAA_DECODE_ADDR[16];
		for (int i = 0; i < 16; i++)
		{
			if (CpsNoaaDecodeAddr[i].addr != null)
			{
				NoaaDecodeAddrInfo[i].addr = Iparse.ConvertByteToString(CpsNoaaDecodeAddr[i].addr, "ANSI").Trim();
				NoaaDecodeAddrInfo[i].info = Iparse.ConvertByteToString(CpsNoaaDecodeAddr[i].info, "ANSI").Trim();
			}
			LoadNoaaDecodeAddrParam(dgv_noaa_decode_addr, i);
		}
		num = 139904;
		GenInfo.self_noaa_event = new bool[param_string.NOAA_SAME_EVENT_LIST.Length / 2];
		for (int i = 0; i < GenInfo.self_noaa_event.Length; i++)
		{
			GenInfo.self_noaa_event[i] = ((CpsData[num + i] != 0) ? true : false);
		}
	}

	public void ConverCpsNoaaEventParam()
	{
		int num = 143360;
		CPS_NOAA_EVENT cPS_NOAA_EVENT = default(CPS_NOAA_EVENT);
		ushort num2 = (ushort)Iparse.GetStructSizeof(cPS_NOAA_EVENT);
		for (int i = 0; i < 32; i++)
		{
			byte[] array = new byte[num2];
			Array.Copy(CpsData, num, array, 0, num2);
			if (array[0] == byte.MaxValue)
			{
				array = new byte[num2];
			}
			ref CPS_NOAA_EVENT reference = ref CpsNoaaEventInfo[i];
			reference = (CPS_NOAA_EVENT)Iparse.ByteToStruct(array, cPS_NOAA_EVENT.GetType());
			num += 4096;
		}
		NoaaEventInfo = new NOAA_EVENT[32];
		for (int i = 0; i < 32; i++)
		{
			int number = CpsNoaaEventInfo[i].number;
			if (number < param_string.NOAA_SAME_EVENT_LIST.Length / 2 && CpsNoaaEventInfo[i].seq > 0 && CpsNoaaEventInfo[i].seq < int.MaxValue)
			{
				NoaaEventInfo[i].even_seq = CpsNoaaEventInfo[i].seq.ToString().Trim();
				NoaaEventInfo[i].even_number = param_string.NOAA_SAME_EVENT_LIST[number * 2] + "(" + param_string.NOAA_SAME_EVENT_LIST[number * 2 + 1].Trim() + ")";
				NoaaEventInfo[i].date = Iparse.ConvertByteToString(CpsNoaaEventInfo[i].date, "ANSI").Trim();
				NoaaEventInfo[i].duration = Iparse.ConvertByteToString(CpsNoaaEventInfo[i].duration, "ANSI").Trim();
				NoaaEventInfo[i].event_befor_org = Iparse.ConvertByteToString(CpsNoaaEventInfo[i].event_befor_org, "ANSI").Trim();
				NoaaEventInfo[i].event_current_org = Iparse.ConvertByteToString(CpsNoaaEventInfo[i].event_current_org, "ANSI").Trim();
			}
			LoadNoaaEventParam(dgv_noaa_event, i);
		}
	}

	public void ConvertCpsHideParamflag()
	{
		HideParamFlag.cps_retry_time = CpsHideParamInfo.air_cps_retry;
		HideParamFlag.kill_flag = CpsHideParamInfo.kill_flag == 1;
		HideParamFlag.encrypt_flag = CpsHideParamInfo.encrypt_flag == 1;
		HideParamFlag.lock_freq_flag = CpsHideParamInfo.lock_freq_flag == 1;
		HideParamFlag.MwSwAgc_UpperLimit = (short)(((ushort)CpsHideParamInfo.MwSwAgc_UpperLimit == ushort.MaxValue) ? (-65) : CpsHideParamInfo.MwSwAgc_UpperLimit);
		HideParamFlag.MwSwAgc_step = (short)(((ushort)CpsHideParamInfo.MwSwAgc_step == ushort.MaxValue) ? 50 : CpsHideParamInfo.MwSwAgc_step);
		HideParamFlag.MwSwAgc_period = (short)(((ushort)CpsHideParamInfo.MwSwAgc_period == ushort.MaxValue) ? 50 : CpsHideParamInfo.MwSwAgc_period);
		HideParamFlag.MwSwAgc_LowerLimit = (short)(((ushort)CpsHideParamInfo.MwSwAgc_LowerLimit == ushort.MaxValue) ? (-85) : CpsHideParamInfo.MwSwAgc_LowerLimit);
		HideParamFlag.MwSwAgc_gain = (short)(((ushort)CpsHideParamInfo.MwSwAgc_gain == ushort.MaxValue) ? 255 : CpsHideParamInfo.MwSwAgc_gain);
		List<string> list = param_string.noaa_send_type_Items();
		try
		{
			HideParamFlag.noaa_send_type = list[CpsHideParamInfo.noaa_tx_flag];
		}
		catch (Exception)
		{
			HideParamFlag.noaa_send_type = list[0];
		}
		byte[] array = new byte[128];
		int num = 82032;
		for (int i = 0; i < 4; i++)
		{
			Array.Copy(CpsData, num, array, 0, array.Length);
			NoaaSendSameInfo.same[i] = Iparse.ConvertByteToString(array, "ANSI").Trim();
			num += array.Length;
		}
	}

	public void ConvertCpsHideParam()
	{
		int sourceIndex = 102400;
		CPS_HIDE_PARAM_INFO cPS_HIDE_PARAM_INFO = default(CPS_HIDE_PARAM_INFO);
		ushort num = (ushort)Iparse.GetStructSizeof(cPS_HIDE_PARAM_INFO);
		byte[] array = new byte[num];
		Array.Copy(CpsData, sourceIndex, array, 0, num);
		CpsHideParamInfo = (CPS_HIDE_PARAM_INFO)Iparse.ByteToStruct(array, cPS_HIDE_PARAM_INFO.GetType());
	}

	public void ConvertCps_5toneContctParam()
	{
		CPS_5TONE_CONTACT_INFO cPS_5TONE_CONTACT_INFO = default(CPS_5TONE_CONTACT_INFO);
		int structSizeof = Iparse.GetStructSizeof(cPS_5TONE_CONTACT_INFO);
		int num = 108544;
		for (int i = 0; i < 16; i++)
		{
			byte[] array = new byte[structSizeof];
			Array.Copy(CpsData, num, array, 0, structSizeof);
			ref CPS_5TONE_CONTACT_INFO reference = ref Cps5toneContactInfo[i];
			reference = (CPS_5TONE_CONTACT_INFO)Iparse.ByteToStruct(array, cPS_5TONE_CONTACT_INFO.GetType());
			num += structSizeof;
		}
		for (int i = 0; i < 16; i++)
		{
			ref _5TONE_CONTACT_INFO reference2 = ref _5toneContactInfo[i];
			reference2 = cps_convert.convert_data(Cps5toneContactInfo[i]);
		}
		for (int i = 0; i < 16; i++)
		{
			Load_5toneContactParam(dgv_5tone_contacts, i);
		}
	}

	public void ConvertCpsDtmfContctParam()
	{
		CPS_DTMF_CONTACT_INFO cPS_DTMF_CONTACT_INFO = default(CPS_DTMF_CONTACT_INFO);
		int structSizeof = Iparse.GetStructSizeof(cPS_DTMF_CONTACT_INFO);
		int num = 106496;
		for (int i = 0; i < 16; i++)
		{
			byte[] array = new byte[structSizeof];
			Array.Copy(CpsData, num, array, 0, structSizeof);
			ref CPS_DTMF_CONTACT_INFO reference = ref CpsDtmfContactInfo[i];
			reference = (CPS_DTMF_CONTACT_INFO)Iparse.ByteToStruct(array, cPS_DTMF_CONTACT_INFO.GetType());
			num += structSizeof;
		}
		for (int i = 0; i < 16; i++)
		{
			ref DTMF_CONTACT_INFO reference2 = ref DtmfContactInfo[i];
			reference2 = cps_convert.convert_data(CpsDtmfContactInfo[i]);
		}
		for (int i = 0; i < 16; i++)
		{
			LoadContactParam(dgv_dtmf_contact, i);
		}
	}

	public void ConvertCpsPasswordParam()
	{
		int sourceIndex = 94208;
		byte[] array = new byte[4];
		Array.Copy(CpsData, sourceIndex, array, 0, array.Length);
		uint num = BitConverter.ToUInt32(array, 0);
		if (0 < num && num <= 999999)
		{
			GenInfo.pass_word = num.ToString();
		}
		else if (0 == num)
		{
			GenInfo.pass_word = "000000";
		}
	}

	public void ConvertCpsScanParam()
	{
		CPS_SCAN_INFO cPS_SCAN_INFO = default(CPS_SCAN_INFO);
		int structSizeof = Iparse.GetStructSizeof(cPS_SCAN_INFO);
		int num = 90112;
		for (int i = 0; i < 32; i++)
		{
			byte[] array = new byte[structSizeof];
			Array.Copy(CpsData, num, array, 0, structSizeof);
			ref CPS_SCAN_INFO reference = ref CpsScanInfo[i];
			reference = (CPS_SCAN_INFO)Iparse.ByteToStruct(array, cPS_SCAN_INFO.GetType());
			num += 128;
		}
		for (int i = 0; i < 32; i++)
		{
			ref SCAN_INFO reference2 = ref ScanInfo[i];
			reference2 = cps_convert.convert_data(CpsScanInfo[i], i);
		}
		for (int i = 0; i < 32; i++)
		{
			LoadScanParam(dgv_scan, i);
		}
	}

	public void ConvertCpsGen2Param()
	{
		int sourceIndex = 81920;
		CPS_GEN2_INFO cPS_GEN2_INFO = default(CPS_GEN2_INFO);
		ushort num = (ushort)Iparse.GetStructSizeof(cPS_GEN2_INFO);
		byte[] array = new byte[num];
		Array.Copy(CpsData, sourceIndex, array, 0, num);
		cPS_GEN2_INFO = (CPS_GEN2_INFO)Iparse.ByteToStruct(array, cPS_GEN2_INFO.GetType());
		CpsGen2Info = cPS_GEN2_INFO;
		if (CpsGen2Info.device_name[0] != byte.MaxValue)
		{
			GenInfo.device_name = Iparse.ConvertByteToString(CpsGen2Info.device_name, "default");
		}
		if (CpsGen2Info.dtmf_kill[0] != byte.MaxValue)
		{
			DtmfInfo.kill = Iparse.ConvertByteToString(CpsGen2Info.dtmf_kill, "default");
		}
		if (CpsGen2Info.dtmf_wakeup[0] != byte.MaxValue)
		{
			DtmfInfo.wakeup = Iparse.ConvertByteToString(CpsGen2Info.dtmf_wakeup, "default");
		}
		if (CpsGen2Info._5tone_kill[0] != byte.MaxValue)
		{
			_5ToneInfo.kill = Iparse.ConvertByteToString(CpsGen2Info._5tone_kill, "default");
		}
		if (CpsGen2Info._5tone_wakeup[0] != byte.MaxValue)
		{
			_5ToneInfo.wakeup = Iparse.ConvertByteToString(CpsGen2Info._5tone_wakeup, "default");
		}
	}

	public void ConvertCpsGenParam()
	{
		int sourceIndex = 77824;
		CPS_GEN_INFO cPS_GEN_INFO = default(CPS_GEN_INFO);
		ushort num = (ushort)Iparse.GetStructSizeof(cPS_GEN_INFO);
		byte[] array = new byte[num];
		Array.Copy(CpsData, sourceIndex, array, 0, num);
		CpsGenInfo = (CPS_GEN_INFO)Iparse.ByteToStruct(array, cPS_GEN_INFO.GetType());
		GenInfo = default(GEN_INFO);
		List<string> list = param_string.gen_main_chn_Items();
		try
		{
			GenInfo.chn_AB = list[CpsGenInfo.chn_AB];
		}
		catch (Exception)
		{
			GenInfo.chn_AB = list[0];
		}
		list = param_string.gen_sq_Items();
		try
		{
			GenInfo.Noaa_sq = list[CpsGenInfo.Noaa_sq];
		}
		catch (Exception)
		{
			GenInfo.Noaa_sq = list[0];
		}
		list = param_string.gen_tot_Items();
		try
		{
			GenInfo.tot = list[CpsGenInfo.tx_tot];
		}
		catch (Exception)
		{
			GenInfo.tot = list[0];
		}
		list = param_string.gen_noaa_scan_Items();
		try
		{
			GenInfo.noaa_scan = list[CpsGenInfo.NoaaScan];
		}
		catch (Exception)
		{
			GenInfo.noaa_scan = list[0];
		}
		list = param_string.gen_keylock_Items();
		try
		{
			GenInfo.key_lock = list[CpsGenInfo.keylock];
		}
		catch (Exception)
		{
			GenInfo.key_lock = list[0];
		}
		list = param_string.gen_vox_Items();
		try
		{
			if (CpsGenInfo.vox_sw == 0)
			{
				GenInfo.vox = list[0];
			}
			else
			{
				GenInfo.vox = list[CpsGenInfo.vox_lvl + 1];
			}
		}
		catch (Exception)
		{
			GenInfo.vox = list[0];
		}
		list = param_string.gen_mic_Items();
		try
		{
			GenInfo.mic = list[CpsGenInfo.mic];
		}
		catch (Exception)
		{
			GenInfo.mic = list[0];
		}
		list = param_string.chn_on_off_Items();
		try
		{
			GenInfo.FreqModeFlag = list[CpsGenInfo.FreqModeFlag];
		}
		catch (Exception)
		{
			GenInfo.FreqModeFlag = list[0];
		}
		list = param_string.gen_chn_disp_Items();
		try
		{
			GenInfo.chn_disp_mode = list[CpsGenInfo.ChnDispMode];
		}
		catch (Exception)
		{
			GenInfo.chn_disp_mode = list[0];
		}
		list = param_string.gen_power_save_Items();
		try
		{
			GenInfo.power_save = list[CpsGenInfo.pwrsave];
		}
		catch (Exception)
		{
			GenInfo.power_save = list[0];
		}
		list = param_string.chn_on_off_Items();
		try
		{
			GenInfo.dual_watch = list[CpsGenInfo.dualwatch];
		}
		catch (Exception)
		{
			GenInfo.dual_watch = list[0];
		}
		list = param_string.GetGen_Brightness_Items();
		try
		{
			if (CpsGenInfo.brightness > 200 || CpsGenInfo.brightness < 8)
			{
				GenInfo.brightness = list[0];
			}
			else
			{
				GenInfo.brightness = list[CpsGenInfo.brightness - 8];
			}
		}
		catch (Exception)
		{
			GenInfo.brightness = list[0];
		}
		list = param_string.chn_on_off_Items();
		try
		{
			GenInfo.MwSw = list[CpsGenInfo.MwSw];
		}
		catch (Exception)
		{
			GenInfo.MwSw = list[1];
		}
		list = param_string.gen_autobacklight_Items();
		try
		{
			if (CpsGenInfo.autobacklight > 11)
			{
				CpsGenInfo.autobacklight = 5;
			}
			GenInfo.backlight = list[CpsGenInfo.autobacklight];
		}
		catch (Exception)
		{
			GenInfo.backlight = list[0];
		}
		list = param_string.GetChannelName_Items();
		try
		{
			if (CpsChannelFlagInfo.flag[CpsGenInfo.call_ch] <= 12)
			{
				GenInfo.call_chn = ChannelInfo[CpsGenInfo.call_ch].name;
			}
			else
			{
				GenInfo.call_chn = list[0];
			}
		}
		catch (Exception)
		{
			GenInfo.call_chn = list[0];
		}
		list = param_string.chn_on_off_Items();
		try
		{
			GenInfo.beep = list[CpsGenInfo.beep];
		}
		catch (Exception)
		{
			GenInfo.beep = list[0];
		}
		list = param_string.gen_sidekey_Items();
		try
		{
			GenInfo.key_short1 = list[CpsGenInfo.key_short1];
		}
		catch (Exception)
		{
			GenInfo.key_short1 = list[0];
		}
		try
		{
			GenInfo.key_short2 = list[CpsGenInfo.key_short2];
		}
		catch (Exception)
		{
			GenInfo.key_short2 = list[0];
		}
		try
		{
			GenInfo.key_long1 = list[CpsGenInfo.key_long1];
		}
		catch (Exception)
		{
			GenInfo.key_long1 = list[0];
		}
		try
		{
			GenInfo.key_long2 = list[CpsGenInfo.key_long2];
		}
		catch (Exception)
		{
			GenInfo.key_long2 = list[0];
		}
		list = param_string.gen_scan_mode_Items();
		try
		{
			GenInfo.scan_mode = list[CpsGenInfo.scan_mode];
		}
		catch (Exception)
		{
			GenInfo.scan_mode = list[0];
		}
		list = param_string.chn_on_off_Items();
		try
		{
			GenInfo.auto_lock = list[CpsGenInfo.auto_lock];
		}
		catch (Exception)
		{
			GenInfo.auto_lock = list[0];
		}
		list = param_string.gen_pwron_disp_Items();
		try
		{
			GenInfo.pwron_disp = list[CpsGenInfo.pwron_disp_sel];
		}
		catch (Exception)
		{
			GenInfo.pwron_disp = list[0];
		}
		list = param_string.gen_alarm_Items();
		try
		{
			GenInfo.alarm = list[CpsGenInfo.alarm_mode];
		}
		catch (Exception)
		{
			GenInfo.alarm = list[0];
		}
		list = param_string.gen_talk_tail_Items();
		try
		{
			GenInfo.talk_tail = list[CpsGenInfo.roger_tone];
		}
		catch (Exception)
		{
			GenInfo.talk_tail = list[0];
		}
		list = param_string.gen_repeater_tail_Items();
		try
		{
			GenInfo.repeater_tail = list[CpsGenInfo.repeater_tail];
		}
		catch (Exception)
		{
			GenInfo.repeater_tail = list[0];
		}
		list = param_string.chn_on_off_Items();
		try
		{
			GenInfo.tail_tone = list[CpsGenInfo.tail_tone];
		}
		catch (Exception)
		{
			GenInfo.talk_tail = list[0];
		}
		list = param_string.gen_denoise_Items();
		try
		{
			if (CpsGenInfo.denoise_sw == 0)
			{
				GenInfo.denoise = list[0];
			}
			else
			{
				GenInfo.denoise = list[CpsGenInfo.denoise_lvl + 1];
			}
		}
		catch (Exception)
		{
			GenInfo.denoise = list[0];
		}
		list = param_string.gen_transpositional_Items();
		try
		{
			if (CpsGenInfo.transpositional_sw == 0)
			{
				GenInfo.transpositional = list[0];
			}
			else
			{
				GenInfo.transpositional = list[CpsGenInfo.transpositional_lvl + 1];
			}
		}
		catch (Exception)
		{
			GenInfo.transpositional = list[0];
		}
		try
		{
			if (CpsGenInfo.chn_B_volume == 3)
			{
				list = param_string.gen_chnA_volume_Items();
				GenInfo.chn_A_volume = list[CpsGenInfo.chn_A_volume];
			}
			else
			{
				list = param_string.gen_chnB_volume_Items();
				GenInfo.chn_A_volume = list[CpsGenInfo.chn_B_volume];
			}
		}
		catch (Exception)
		{
			list = param_string.gen_chnA_volume_Items();
			GenInfo.chn_A_volume = list[3];
			GenInfo.chn_B_volume = list[3];
		}
		list = param_string.chn_on_off_Items();
		try
		{
			GenInfo.key_tone = list[CpsGenInfo.key_tone_flag];
		}
		catch (Exception)
		{
			GenInfo.key_tone = list[0];
		}
		list = param_string.gen_lang_Items();
		try
		{
			GenInfo.lang = list[CpsGenInfo.language];
		}
		catch (Exception)
		{
			GenInfo.lang = list[0];
		}
		list = param_string.gen_noaa_decode_Items();
		try
		{
			GenInfo.same_decode = list[CpsGenInfo.NoaaSameDecode];
		}
		catch (Exception)
		{
			GenInfo.same_decode = list[0];
		}
		list = param_string.gen_SAME_event_Items();
		try
		{
			GenInfo.same_event = list[CpsGenInfo.NoaaSameEvent];
		}
		catch (Exception)
		{
			GenInfo.same_event = list[0];
		}
		list = param_string.gen_SAME_address_Items();
		try
		{
			GenInfo.same_addr = list[CpsGenInfo.NoaaSame_Addr];
		}
		catch (Exception)
		{
			GenInfo.same_addr = list[0];
		}
		list = param_string.chn_on_off_Items();
		try
		{
			GenInfo.sbar = list[CpsGenInfo.sbar];
		}
		catch (Exception)
		{
			GenInfo.sbar = list[0];
		}
		list = param_string.gen_signal_Items();
		list = param_string.chn_on_off_Items();
		try
		{
			GenInfo.kill = list[CpsGenInfo.kill_flag];
		}
		catch (Exception)
		{
			GenInfo.kill = list[0];
		}
		list = param_string.chn_on_off_Items();
		try
		{
			GenInfo.MwSw = list[CpsGenInfo.MwSw];
		}
		catch (Exception)
		{
			GenInfo.MwSw = list[1];
		}
		try
		{
			GenInfo.side_tone = list[CpsGenInfo.dtmf_side_tone];
		}
		catch (Exception)
		{
			GenInfo.side_tone = list[0];
		}
		list = param_string.dtmf_rsp_Items();
		try
		{
			GenInfo.dtmf_decode_rspn = list[CpsGenInfo.dtmf_decode_rspn];
		}
		catch (Exception)
		{
			GenInfo.dtmf_decode_rspn = list[0];
		}
		try
		{
			if (8 <= CpsGenInfo.match_tot && CpsGenInfo.match_tot <= 32)
			{
				GenInfo.match_tot = CpsGenInfo.match_tot.ToString();
			}
			else
			{
				GenInfo.match_tot = "32";
			}
		}
		catch (Exception)
		{
			GenInfo.match_tot = "32";
		}
		list = param_string.gen_match_mode_Items();
		try
		{
			GenInfo.match_mode = list[CpsGenInfo.match_qt_mode];
		}
		catch (Exception)
		{
			GenInfo.match_mode = list[0];
		}
		list = param_string.gen_match_dcs_bit_Items();
		try
		{
			GenInfo.match_dcs_bit = list[CpsGenInfo.match_dcs_bit];
		}
		catch (Exception)
		{
			GenInfo.match_dcs_bit = list[0];
		}
		try
		{
			if (10 <= CpsGenInfo.match_threshold && CpsGenInfo.match_threshold <= 200)
			{
				GenInfo.match_threshold = CpsGenInfo.match_threshold.ToString();
			}
			else
			{
				GenInfo.match_threshold = "100";
			}
		}
		catch (Exception)
		{
			GenInfo.match_threshold = "100";
		}
		DtmfInfo = default(DTMF_INFO);
		DtmfInfo.separator = CharToString(CpsGenInfo.dtmf_separator);
		DtmfInfo.group_code = CharToString(CpsGenInfo.dtmf_group_code);
		DtmfInfo.reset_time = CpsGenInfo.dtmf_reset_time.ToString();
		DtmfInfo.carry_time = CpsGenInfo.dtmf_carry_time.ToString();
		DtmfInfo.first_code_time = CpsGenInfo.dtmf_first_code_time.ToString();
		DtmfInfo.D_code_time = CpsGenInfo.dtmf_D_code_time.ToString();
		DtmfInfo.single_continue_time = CpsGenInfo.dtmf_single_continue_time.ToString();
		DtmfInfo.single_interval_time = CpsGenInfo.dtmf_single_interval_time.ToString();
		DtmfInfo.id = Iparse.ConvertByteToString(GetArrayData(CpsGenInfo.dtmf_id), "default");
		DtmfInfo.UpCode = Iparse.ConvertByteToString(GetArrayData(CpsGenInfo.dtmf_UpCode), "default");
		DtmfInfo.DnCode = Iparse.ConvertByteToString(GetArrayData(CpsGenInfo.dtmf_DnCode), "default");
		_5ToneInfo = default(_5TONE_INFO);
		_5ToneInfo.RepeatTone = CharToString(CpsGenInfo._5tone_separator);
		_5ToneInfo.group_code = CharToString(CpsGenInfo._5tone_group_code);
		_5ToneInfo.reset_time = CpsGenInfo._5tonef_reset_time.ToString();
		_5ToneInfo.carry_time = CpsGenInfo._5tone_carry_time.ToString();
		_5ToneInfo.first_code_time = CpsGenInfo._5tone_first_code_time.ToString();
		list = param_string._5tone_protocol_Items();
		try
		{
			_5ToneInfo.protocol = list[CpsGenInfo._5tone_protocol];
		}
		catch (Exception)
		{
			_5ToneInfo.protocol = list[0];
		}
		_5ToneInfo.single_continue_time = CpsGenInfo._5tone_single_continue_time.ToString();
		_5ToneInfo.single_interval_time = CpsGenInfo._5tone_single_interval_time.ToString();
		_5ToneInfo.id = Iparse.ConvertByteToString(GetArrayData(CpsGenInfo._5tone_id), "default").Trim();
		_5ToneInfo.UpCode = Iparse.ConvertByteToString(GetArrayData(CpsGenInfo._5tone_UpCode), "default").Trim();
		_5ToneInfo.DnCode = Iparse.ConvertByteToString(GetArrayData(CpsGenInfo._5tone_DnCode), "default").Trim();
		_5ToneInfo.user_freq = new int[15];
		for (int i = 0; i < 15; i++)
		{
			_5ToneInfo.user_freq[i] = CpsGenInfo._5tone_user_freq[i];
		}
		try
		{
			list = param_string.gen_fm_mode_Items();
			GenInfo.fm_mode = list[CpsFm.mr_vfo_flag];
		}
		catch (Exception)
		{
			GenInfo.fm_mode = list[0];
		}
		if (CpsFm.mr_idx > 31)
		{
			CpsFm.mr_idx = 0;
		}
		GenInfo.fm_chn_idx = (CpsFm.mr_idx + 1).ToString();
		if (CpsFm.vfo_freq != ushort.MaxValue)
		{
			GenInfo.fm_vfo_freq = ((double)(int)CpsFm.vfo_freq / 10.0).ToString("0.0");
		}
		int num2 = 13;
		GenInfo.band_enable = new bool[num2];
		GenInfo.band_tx_enable = new bool[num2];
		GenInfo.rx_start = new string[num2];
		GenInfo.rx_end = new string[num2];
		GenInfo.tx_start = new string[num2];
		GenInfo.tx_end = new string[num2];
		GenInfo.self_tone_path = new string[5];
		if (CpsHideParamInfo.band_rx_start[0] == uint.MaxValue)
		{
			for (int i = 0; i < num2; i++)
			{
				GenInfo.band_enable[i] = true;
				GenInfo.band_tx_enable[i] = true;
				GenInfo.rx_start[i] = param_string.freq_rang[i * 2].ToString("0.00000");
				GenInfo.rx_end[i] = param_string.freq_rang[i * 2 + 1].ToString("0.00000");
				GenInfo.tx_start[i] = GenInfo.rx_start[i];
				GenInfo.tx_end[i] = GenInfo.rx_end[i];
			}
			GenInfo.band_tx_enable[0] = false;
			GenInfo.band_tx_enable[1] = false;
			GenInfo.band_tx_enable[4] = false;
			GenInfo.band_tx_enable[10] = false;
			GenInfo.band_tx_enable[11] = false;
			GenInfo.band_tx_enable[12] = false;
		}
		else
		{
			for (int i = 0; i < num2; i++)
			{
				GenInfo.band_enable[i] = CpsHideParamInfo.band_enable[i] == 1;
				GenInfo.band_tx_enable[i] = CpsHideParamInfo.band_tx_enable[i] == 1;
				GenInfo.rx_start[i] = ((double)CpsHideParamInfo.band_rx_start[i] / 100000.0).ToString("0.00000");
				GenInfo.rx_end[i] = ((double)CpsHideParamInfo.band_rx_end[i] / 100000.0).ToString("0.00000");
				GenInfo.tx_start[i] = ((double)CpsHideParamInfo.band_tx_start[i] / 100000.0).ToString("0.00000");
				GenInfo.tx_end[i] = ((double)CpsHideParamInfo.band_tx_end[i] / 100000.0).ToString("0.00000");
			}
		}
		if (CpsGenInfo.logo_string1[0] != byte.MaxValue)
		{
			GenInfo.logo_1 = Iparse.ConvertByteToString(CpsGenInfo.logo_string1, "default");
		}
		else
		{
			GenInfo.logo_1 = null;
		}
		if (CpsGenInfo.logo_string2[0] != byte.MaxValue)
		{
			GenInfo.logo_2 = Iparse.ConvertByteToString(CpsGenInfo.logo_string2, "default");
		}
		else
		{
			GenInfo.logo_2 = null;
		}
		if (CpsGenInfo.CWPitchFreq > 1000)
		{
			CpsGenInfo.CWPitchFreq = 400;
		}
		GenInfo.CwPitchFreq = CpsGenInfo.CWPitchFreq;
	}

	public byte[] GetArrayData(byte[] src)
	{
		int num = 0;
		for (int i = 0; i < src.Length && src[i] != byte.MaxValue; i++)
		{
			num++;
		}
		if (num < src.Length - 1)
		{
			src[num] = 0;
		}
		return src;
	}

	public string CharToString(ushort val)
	{
		if (val == 0 || val == 255)
		{
			return GetLang("_null");
		}
		return new string(new char[1] { (char)val });
	}

	public void ConvertCpsFmParam()
	{
		int sourceIndex = 73728;
		CPS_FM_INFO cPS_FM_INFO = default(CPS_FM_INFO);
		ushort num = (ushort)Iparse.GetStructSizeof(cPS_FM_INFO);
		byte[] array = new byte[num];
		Array.Copy(CpsData, sourceIndex, array, 0, num);
		CpsFm = (CPS_FM_INFO)Iparse.ByteToStruct(array, cPS_FM_INFO.GetType());
		for (int i = 0; i < 32; i++)
		{
			if (CpsFm.freq[i] != ushort.MaxValue)
			{
				FmInfo[i].freq = ((double)(int)CpsFm.freq[i] / 10.0).ToString();
			}
			else
			{
				FmInfo[i] = default(FM_INFO);
			}
		}
		for (int i = 0; i < 32; i++)
		{
			LoadFmParam(dgv_fm, i);
		}
	}

	public void ConvertCpsVfoParam()
	{
		int num = 65536;
		CPS_VFO_INFO cPS_VFO_INFO = default(CPS_VFO_INFO);
		ushort num2 = (ushort)Iparse.GetStructSizeof(cPS_VFO_INFO);
		byte[] array = new byte[num2];
		string text = null;
		for (int i = 0; i < 13; i++)
		{
			Array.Copy(CpsData, num, array, 0, num2);
			text = VfoInfo[0, i].name;
			ref CPS_VFO_INFO reference = ref CpsVfoInfo[0, i];
			reference = (CPS_VFO_INFO)Iparse.ByteToStruct(array, cPS_VFO_INFO.GetType());
			ref VFO_INFO reference2 = ref VfoInfo[0, i];
			reference2 = cps_convert.convert_data(CpsVfoInfo[0, i]);
			VfoInfo[0, i].name = text;
			num += num2;
			Array.Copy(CpsData, num, array, 0, num2);
			text = VfoInfo[1, i].name;
			ref CPS_VFO_INFO reference3 = ref CpsVfoInfo[1, i];
			reference3 = (CPS_VFO_INFO)Iparse.ByteToStruct(array, cPS_VFO_INFO.GetType());
			ref VFO_INFO reference4 = ref VfoInfo[1, i];
			reference4 = cps_convert.convert_data(CpsVfoInfo[1, i]);
			VfoInfo[1, i].name = text;
			num += num2;
		}
	}

	public void ConvertCpsChannelParam()
	{
		List<string> list = param_string.chn_freq_rang_Items();
		CpsChannelFlagInfo.flag = new byte[999];
		int sourceIndex = 69632;
		Array.Copy(CpsData, sourceIndex, CpsChannelFlagInfo.flag, 0, 999);
		sourceIndex = 0;
		CPS_CHANNEL_INFO cPS_CHANNEL_INFO = default(CPS_CHANNEL_INFO);
		ushort num = (ushort)Iparse.GetStructSizeof(cPS_CHANNEL_INFO);
		byte[] array = new byte[num];
		for (int i = 0; i < 999; i++)
		{
			if (CpsChannelFlagInfo.flag[i] != byte.MaxValue)
			{
				Array.Copy(CpsData, sourceIndex, array, 0, num);
				ref CPS_CHANNEL_INFO reference = ref CpsChannelInfo[i];
				reference = (CPS_CHANNEL_INFO)Iparse.ByteToStruct(array, cPS_CHANNEL_INFO.GetType());
				ref CHANNEL_INFO reference2 = ref ChannelInfo[i];
				reference2 = cps_convert.convert_data(CpsChannelInfo[i], i);
				ChannelInfo[i].freq_rang = list[CpsChannelFlagInfo.flag[i]];
			}
			else
			{
				ChannelInfo[i] = default(CHANNEL_INFO);
			}
			sourceIndex += num;
		}
		for (int i = 0; i < 999; i++)
		{
			LoadChannelParam(dgv_ch, i);
		}
	}

	public void CpsReadScan()
	{
		try
		{
			CPS_SCAN_INFO cPS_SCAN_INFO = default(CPS_SCAN_INFO);
			int num = 90112;
			ushort num2 = (ushort)Iparse.GetStructSizeof(cPS_SCAN_INFO);
			int num3 = 0;
			for (int i = 0; i < 32; i += 7)
			{
				byte[] array = protocol_struct.Read(num + i * num2, 512);
				if (array == null)
				{
					continue;
				}
				for (int j = 0; j < 7; j++)
				{
					byte[] array2 = new byte[num2];
					Array.Copy(array, array2, num2);
					ref CPS_SCAN_INFO reference = ref CpsScanInfo[num3++];
					reference = (CPS_SCAN_INFO)Iparse.ByteToStruct(array2, cPS_SCAN_INFO.GetType());
					if (num3 == 32)
					{
						break;
					}
				}
			}
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("read_err_fm"));
		}
	}

	private void toolStripButton2_Click(object sender, EventArgs e)
	{
		bool flag = false;
		Random random = new Random();
		protocol_struct.magiccode = (uint)random.Next();
		wfm_progress.exit = false;
		if (ComPort.Instance.Open())
		{
			flag = Login();
			ComPort.Instance.Close();
			if (flag)
			{
				GetCpsData();
				m_Progress = "write";
				wfm_progress wfm_progress2 = new wfm_progress();
				wfm_progress2.ShowDialog();
			}
		}
	}

	public byte[] GetChnFreqRang()
	{
		byte[] buf = new byte[999];
		InitParam(ref buf);
		List<string> list = param_string.chn_freq_rang_Items();
		for (int i = 0; i < 999; i++)
		{
			if (CpsChannelInfo[i].rx_freq != uint.MaxValue)
			{
				buf[i] = (byte)(buf[i] & 0xFu);
				buf[i] |= (byte)list.IndexOf(ChannelInfo[i].freq_rang);
			}
		}
		return buf;
	}

	public static void InitParam(ref byte[] buf)
	{
		for (int i = 0; i < buf.Length; i++)
		{
			buf[i] = byte.MaxValue;
		}
	}

	public static void InitParam(ref ushort[] buf)
	{
		for (int i = 0; i < buf.Length; i++)
		{
			buf[i] = ushort.MaxValue;
		}
	}

	private void 保存SToolStripButton_Click(object sender, EventArgs e)
	{
		string text = Iparse.getchart("path", "path");
		if (!Directory.Exists(text))
		{
			text = Application.StartupPath;
		}
		saveFileDialog1.FileName = GetLang("model");
		saveFileDialog1.Filter = "(*.dat)|*.dat";
		saveFileDialog1.InitialDirectory = text;
		if (saveFileDialog1.ShowDialog() == DialogResult.OK)
		{
			text = saveFileDialog1.FileName.ToString();
			Iparse.setchart("path", "path", Path.GetDirectoryName(text));
			FileStream fileStream = new FileStream(text, FileMode.OpenOrCreate);
			GetCpsData();
			fileStream.SetLength(0L);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream, Encoding.Default);
			binaryWriter.Write(CpsData);
			binaryWriter.Close();
			MessageBox.Show(GetLang("save_success"));
		}
	}

	public void GetCpsData()
	{
		InitParam(ref CpsData);
		ConvertChannelParam();
		ConvertVfoParam();
		ConvertFmParam();
		ConvertGen1Param();
		ConvertGen2Param();
		ConvertScanlistParam();
		ConvertDtmfContactParam();
		Convert5toneContactParam();
		ConvertNoaaDecodeAddr();
		ConvertNoaaEvent();
		ConvertHidetParam();
		GetChannelParam();
		GetVfoParam();
		GetChannelFlagParam();
		GetFmParam();
		GetGen1Param();
		GetGen2Param();
		GetChannelIndexParam();
		byte b = CpsData[94208];
		GetScanlistParam();
		GetPwronPassword();
		GetHideParam();
		GetDtmfContactParam();
		Get5toneContactParam();
		GetNoaaDecodeAddr();
		GetNoaaEvent();
		GetPictureData();
		GetNoaaSendData();
	}

	public void GetNoaaSendData()
	{
		int num = 82032;
		for (int i = 0; i < 4; i++)
		{
			byte[] array = new byte[128];
			byte[] array2 = Iparse.ConvertStringToByte(NoaaSendSameInfo.same[i], "ANSI");
			Array.Copy(array2, array, array2.Length);
			Array.Copy(array, 0, CpsData, num, array.Length);
			num += 128;
		}
	}

	public void GetPictureData()
	{
		int destinationIndex = 876544;
		byte[] array = Iparse.StructToBytes(CpsPictureInfo, Iparse.GetStructSizeof(CpsPictureInfo));
		Array.Copy(array, 0, CpsData, destinationIndex, array.Length);
	}

	public void ConvertNoaaDecodeAddr()
	{
		for (int i = 0; i < 16; i++)
		{
			CpsNoaaDecodeAddr[i] = default(CPS_NOAA_DECODE_ADDR);
			if (!string.IsNullOrEmpty(NoaaDecodeAddrInfo[i].addr))
			{
				ref CPS_NOAA_DECODE_ADDR reference = ref CpsNoaaDecodeAddr[i];
				reference = ConvertNoaaDecodeAddr(NoaaDecodeAddrInfo[i]);
			}
		}
	}

	public CPS_NOAA_DECODE_ADDR ConvertNoaaDecodeAddr(NOAA_DECODE_ADDR src_info)
	{
		CPS_NOAA_DECODE_ADDR result = default(CPS_NOAA_DECODE_ADDR);
		result.addr = new byte[8];
		result.info = new byte[32];
		byte[] array = Iparse.ConvertStringToByte(src_info.addr.Trim(), "ANSI");
		Array.Copy(array, result.addr, array.Length);
		array = Iparse.ConvertStringToByte(src_info.info.Trim(), "ANSI");
		Array.Copy(array, result.info, array.Length);
		return result;
	}

	public void GetNoaaDecodeAddr()
	{
		CPS_NOAA_DECODE_ADDR cPS_NOAA_DECODE_ADDR = default(CPS_NOAA_DECODE_ADDR);
		int num = 139264;
		for (int i = 0; i < 16; i++)
		{
			if (!string.IsNullOrEmpty(NoaaDecodeAddrInfo[i].info))
			{
				byte[] array = Iparse.StructToBytes(CpsNoaaDecodeAddr[i], Iparse.GetStructSizeof(cPS_NOAA_DECODE_ADDR));
				Array.Copy(array, 0, CpsData, num, array.Length);
			}
			num += Iparse.GetStructSizeof(cPS_NOAA_DECODE_ADDR);
		}
		num = 139904;
		for (int i = 0; i < param_string.NOAA_SAME_EVENT_LIST.Length / 2; i++)
		{
			CpsData[num + i] = (byte)(GenInfo.self_noaa_event[i] ? 1u : 0u);
		}
	}

	public void ConvertNoaaEvent()
	{
		for (int i = 0; i < 32; i++)
		{
			if (!string.IsNullOrEmpty(NoaaEventInfo[i].even_number))
			{
				byte number = CpsNoaaEventInfo[i].number;
				int seq = CpsNoaaEventInfo[i].seq;
				ref CPS_NOAA_EVENT reference = ref CpsNoaaEventInfo[i];
				reference = ConvertNoaaEvent(NoaaEventInfo[i]);
				CpsNoaaEventInfo[i].seq = seq;
				CpsNoaaEventInfo[i].number = number;
			}
			else
			{
				CpsNoaaEventInfo[i] = default(CPS_NOAA_EVENT);
			}
		}
	}

	public CPS_NOAA_EVENT ConvertNoaaEvent(NOAA_EVENT src_info)
	{
		CPS_NOAA_EVENT result = default(CPS_NOAA_EVENT);
		result.duration = new byte[8];
		result.date = new byte[8];
		result.event_befor_org = new byte[8];
		result.event_current_org = new byte[8];
		byte[] array = Iparse.ConvertStringToByte(src_info.duration.Trim(), "ANSI");
		Array.Copy(array, result.duration, array.Length);
		array = Iparse.ConvertStringToByte(src_info.date.Trim(), "ANSI");
		Array.Copy(array, result.date, array.Length);
		array = Iparse.ConvertStringToByte(src_info.event_befor_org.Trim(), "ANSI");
		Array.Copy(array, result.event_befor_org, array.Length);
		array = Iparse.ConvertStringToByte(src_info.event_current_org.Trim(), "ANSI");
		Array.Copy(array, result.event_current_org, array.Length);
		return result;
	}

	public void GetNoaaEvent()
	{
		int num = 143360;
		CPS_NOAA_EVENT cPS_NOAA_EVENT = default(CPS_NOAA_EVENT);
		for (int i = 0; i < 32; i++)
		{
			if (!string.IsNullOrEmpty(NoaaEventInfo[i].even_number))
			{
				byte[] array = Iparse.StructToBytes(CpsNoaaEventInfo[i], Iparse.GetStructSizeof(cPS_NOAA_EVENT));
				Array.Copy(array, 0, CpsData, num, array.Length);
			}
			num += 4096;
		}
	}

	public void GetPwronPassword()
	{
		int destinationIndex = 94208;
		if (!string.IsNullOrEmpty(GenInfo.pass_word))
		{
			byte[] bytes = BitConverter.GetBytes(Convert.ToUInt32(GenInfo.pass_word));
			Array.Copy(bytes, 0, CpsData, destinationIndex, bytes.Length);
		}
	}

	public void ConvertHidetParam()
	{
		CpsHideParamInfo = default(CPS_HIDE_PARAM_INFO);
		int num = 13;
		CpsHideParamInfo.band_tx_enable = new byte[num];
		CpsHideParamInfo.band_enable = new byte[num];
		CpsHideParamInfo.band_rx_start = new uint[num];
		CpsHideParamInfo.band_rx_end = new uint[num];
		CpsHideParamInfo.band_tx_start = new uint[num];
		CpsHideParamInfo.band_tx_end = new uint[num];
		double num2 = 0.0;
		for (int i = 0; i < num; i++)
		{
			CpsHideParamInfo.band_tx_enable[i] = (byte)(GenInfo.band_tx_enable[i] ? 1u : 0u);
			CpsHideParamInfo.band_enable[i] = (byte)(GenInfo.band_enable[i] ? 1u : 0u);
			num2 = Convert.ToDouble(GenInfo.rx_start[i]) * 100000.0;
			CpsHideParamInfo.band_rx_start[i] = (uint)num2;
			num2 = Convert.ToDouble(GenInfo.rx_end[i]) * 100000.0;
			CpsHideParamInfo.band_rx_end[i] = (uint)num2;
			num2 = Convert.ToDouble(GenInfo.tx_start[i]) * 100000.0;
			CpsHideParamInfo.band_tx_start[i] = (uint)num2;
			num2 = Convert.ToDouble(GenInfo.tx_end[i]) * 100000.0;
			CpsHideParamInfo.band_tx_end[i] = (uint)num2;
		}
		CpsHideParamInfo.air_cps_retry = (byte)((HideParamFlag.cps_retry_time > 4m) ? 2m : HideParamFlag.cps_retry_time);
		CpsHideParamInfo.encrypt_flag = (byte)(HideParamFlag.encrypt_flag ? 1u : 0u);
		CpsHideParamInfo.kill_flag = (byte)(HideParamFlag.kill_flag ? 1u : 0u);
		CpsHideParamInfo.lock_freq_flag = (byte)(HideParamFlag.lock_freq_flag ? 1u : 0u);
		List<string> list = param_string.noaa_send_type_Items();
		CpsHideParamInfo.noaa_tx_flag = (byte)list.IndexOf(HideParamFlag.noaa_send_type);
		CpsHideParamInfo.MwSwAgc_UpperLimit = (short)(((ushort)HideParamFlag.MwSwAgc_UpperLimit == ushort.MaxValue) ? (-65) : HideParamFlag.MwSwAgc_UpperLimit);
		CpsHideParamInfo.MwSwAgc_step = (short)(((ushort)HideParamFlag.MwSwAgc_step == ushort.MaxValue) ? 50 : HideParamFlag.MwSwAgc_step);
		CpsHideParamInfo.MwSwAgc_period = (short)(((ushort)HideParamFlag.MwSwAgc_period == ushort.MaxValue) ? 50 : HideParamFlag.MwSwAgc_period);
		CpsHideParamInfo.MwSwAgc_LowerLimit = (short)(((ushort)HideParamFlag.MwSwAgc_LowerLimit == ushort.MaxValue) ? (-85) : HideParamFlag.MwSwAgc_LowerLimit);
		CpsHideParamInfo.MwSwAgc_gain = (short)(((ushort)HideParamFlag.MwSwAgc_gain == ushort.MaxValue) ? 255 : HideParamFlag.MwSwAgc_gain);
	}

	public void Convert5toneContactParam()
	{
		for (int i = 0; i < 16; i++)
		{
			ref CPS_5TONE_CONTACT_INFO reference = ref Cps5toneContactInfo[i];
			reference = cps_convert.convert_data(_5toneContactInfo[i]);
		}
	}

	public void ConvertDtmfContactParam()
	{
		for (int i = 0; i < 16; i++)
		{
			ref CPS_DTMF_CONTACT_INFO reference = ref CpsDtmfContactInfo[i];
			reference = cps_convert.convert_data(DtmfContactInfo[i]);
		}
	}

	public void ConvertScanlistParam()
	{
		for (int i = 0; i < 32; i++)
		{
			ref CPS_SCAN_INFO reference = ref CpsScanInfo[i];
			reference = cps_convert.convert_data(ScanInfo[i]);
		}
	}

	public void ConvertGen2Param()
	{
		CpsGen2Info = default(CPS_GEN2_INFO);
		CpsGen2Info._5tone_kill = new byte[8];
		CpsGen2Info._5tone_wakeup = new byte[8];
		CpsGen2Info.device_name = new byte[16];
		CpsGen2Info.dtmf_kill = new byte[8];
		CpsGen2Info.dtmf_wakeup = new byte[8];
		byte[] array = Iparse.ConvertStringToByte(DtmfInfo.kill, "default");
		Array.Copy(array, CpsGen2Info.dtmf_kill, array.Length);
		array = Iparse.ConvertStringToByte(DtmfInfo.wakeup, "default");
		Array.Copy(array, CpsGen2Info.dtmf_wakeup, array.Length);
		array = Iparse.ConvertStringToByte(_5ToneInfo.kill, "default");
		Array.Copy(array, CpsGen2Info._5tone_kill, array.Length);
		array = Iparse.ConvertStringToByte(_5ToneInfo.wakeup, "default");
		Array.Copy(array, CpsGen2Info._5tone_wakeup, array.Length);
		array = Iparse.ConvertStringToByte(GenInfo.device_name, "default");
		Array.Copy(array, CpsGen2Info.device_name, array.Length);
	}

	public void ConvertGen1Param()
	{
		if (string.IsNullOrEmpty(GenInfo.auto_lock))
		{
			GenInfo = genset.InitStructInfo();
		}
		List<string> list = param_string.gen_main_chn_Items();
		CpsGenInfo.chn_AB = (byte)list.IndexOf(GenInfo.chn_AB);
		list = param_string.gen_sq_Items();
		CpsGenInfo.Noaa_sq = (byte)list.IndexOf(GenInfo.Noaa_sq);
		list = param_string.gen_tot_Items();
		CpsGenInfo.tx_tot = (byte)list.IndexOf(GenInfo.tot);
		list = param_string.gen_noaa_scan_Items();
		CpsGenInfo.NoaaScan = (byte)list.IndexOf(GenInfo.noaa_scan);
		list = param_string.gen_keylock_Items();
		CpsGenInfo.keylock = (byte)list.IndexOf(GenInfo.key_lock);
		list = param_string.gen_vox_Items();
		byte b = (byte)list.IndexOf(GenInfo.vox);
		if (b == 0)
		{
			CpsGenInfo.vox_sw = 0;
			CpsGenInfo.vox_lvl = 0;
		}
		else
		{
			CpsGenInfo.vox_sw = 1;
			CpsGenInfo.vox_lvl = (byte)(b - 1);
		}
		list = param_string.gen_mic_Items();
		CpsGenInfo.mic = (byte)list.IndexOf(GenInfo.mic);
		list = param_string.chn_on_off_Items();
		CpsGenInfo.FreqModeFlag = (byte)list.IndexOf(GenInfo.FreqModeFlag);
		list = param_string.gen_chn_disp_Items();
		CpsGenInfo.ChnDispMode = (byte)list.IndexOf(GenInfo.chn_disp_mode);
		list = param_string.gen_power_save_Items();
		CpsGenInfo.pwrsave = (byte)list.IndexOf(GenInfo.power_save);
		list = param_string.chn_on_off_Items();
		CpsGenInfo.dualwatch = (byte)list.IndexOf(GenInfo.dual_watch);
		list = param_string.gen_autobacklight_Items();
		CpsGenInfo.autobacklight = (byte)list.IndexOf(GenInfo.backlight);
		if (CpsGenInfo.autobacklight > 11)
		{
			CpsGenInfo.autobacklight = 5;
		}
		list = param_string.GetChannelName_Items();
		try
		{
			CpsGenInfo.call_ch = (ushort)cps_convert.FindChanneIndex(GenInfo.call_chn);
			if (CpsGenInfo.call_ch >= 999)
			{
				CpsGenInfo.call_ch = 0;
			}
		}
		catch (Exception)
		{
			CpsGenInfo.call_ch = 0;
		}
		list = param_string.chn_on_off_Items();
		CpsGenInfo.beep = (byte)list.IndexOf(GenInfo.beep);
		list = param_string.gen_sidekey_Items();
		CpsGenInfo.key_short1 = (byte)list.IndexOf(GenInfo.key_short1);
		CpsGenInfo.key_short2 = (byte)list.IndexOf(GenInfo.key_short2);
		CpsGenInfo.key_long1 = (byte)list.IndexOf(GenInfo.key_long1);
		CpsGenInfo.key_long2 = (byte)list.IndexOf(GenInfo.key_long2);
		list = param_string.gen_scan_mode_Items();
		CpsGenInfo.scan_mode = (byte)list.IndexOf(GenInfo.scan_mode);
		list = param_string.chn_on_off_Items();
		CpsGenInfo.auto_lock = (byte)list.IndexOf(GenInfo.auto_lock);
		list = param_string.gen_pwron_disp_Items();
		CpsGenInfo.pwron_disp_sel = (byte)list.IndexOf(GenInfo.pwron_disp);
		list = param_string.gen_alarm_Items();
		CpsGenInfo.alarm_mode = (byte)list.IndexOf(GenInfo.alarm);
		list = param_string.gen_talk_tail_Items();
		CpsGenInfo.roger_tone = (byte)list.IndexOf(GenInfo.talk_tail);
		list = param_string.gen_repeater_tail_Items();
		CpsGenInfo.repeater_tail = (byte)list.IndexOf(GenInfo.repeater_tail);
		list = param_string.chn_on_off_Items();
		CpsGenInfo.tail_tone = (byte)list.IndexOf(GenInfo.tail_tone);
		list = param_string.gen_denoise_Items();
		b = (byte)list.IndexOf(GenInfo.denoise);
		if (b == 0)
		{
			CpsGenInfo.denoise_sw = 0;
			CpsGenInfo.denoise_lvl = 0;
		}
		else
		{
			CpsGenInfo.denoise_sw = 1;
			CpsGenInfo.denoise_lvl = (byte)(b - 1);
		}
		list = param_string.gen_transpositional_Items();
		b = (byte)list.IndexOf(GenInfo.transpositional);
		if (b == 0)
		{
			CpsGenInfo.transpositional_sw = 0;
			CpsGenInfo.transpositional_lvl = 0;
		}
		else
		{
			CpsGenInfo.transpositional_sw = 1;
			CpsGenInfo.transpositional_lvl = (byte)(b - 1);
		}
		list = param_string.gen_chn_volume_Items();
		byte b2 = (byte)list.IndexOf(GenInfo.chn_A_volume);
		if (b2 <= 3)
		{
			CpsGenInfo.chn_A_volume = b2;
			CpsGenInfo.chn_B_volume = 3;
		}
		else
		{
			CpsGenInfo.chn_A_volume = 3;
			CpsGenInfo.chn_B_volume = (byte)(6 - b2);
		}
		list = param_string.chn_on_off_Items();
		CpsGenInfo.key_tone_flag = (byte)list.IndexOf(GenInfo.key_tone);
		list = param_string.gen_lang_Items();
		CpsGenInfo.language = (byte)list.IndexOf(GenInfo.lang);
		list = param_string.gen_noaa_decode_Items();
		CpsGenInfo.NoaaSameDecode = (byte)list.IndexOf(GenInfo.same_decode);
		list = param_string.gen_SAME_event_Items();
		CpsGenInfo.NoaaSameEvent = (byte)list.IndexOf(GenInfo.same_event);
		list = param_string.gen_SAME_address_Items();
		CpsGenInfo.NoaaSame_Addr = (byte)list.IndexOf(GenInfo.same_addr);
		list = param_string.chn_on_off_Items();
		CpsGenInfo.sbar = (byte)list.IndexOf(GenInfo.sbar);
		list = param_string.GetGen_Brightness_Items();
		CpsGenInfo.brightness = (byte)(list.IndexOf(GenInfo.brightness) + 8);
		list = param_string.chn_on_off_Items();
		CpsGenInfo.kill_flag = (byte)list.IndexOf(GenInfo.kill);
		CpsGenInfo.dtmf_side_tone = (byte)list.IndexOf(GenInfo.side_tone);
		list = param_string.dtmf_rsp_Items();
		CpsGenInfo.dtmf_decode_rspn = (byte)list.IndexOf(GenInfo.dtmf_decode_rspn);
		CpsGenInfo.match_tot = Convert.ToByte(GenInfo.match_tot);
		list = param_string.gen_match_mode_Items();
		CpsGenInfo.match_qt_mode = (byte)list.IndexOf(GenInfo.match_mode);
		list = param_string.gen_match_dcs_bit_Items();
		CpsGenInfo.match_dcs_bit = (byte)list.IndexOf(GenInfo.match_dcs_bit);
		CpsGenInfo.match_threshold = Convert.ToByte(GenInfo.match_threshold);
		if (string.IsNullOrEmpty(DtmfInfo.separator))
		{
			DtmfInfo = dtmf.InitStructInfo();
		}
		if (DtmfInfo.separator == GetLang("_null"))
		{
			CpsGenInfo.dtmf_separator = 0;
		}
		else
		{
			CpsGenInfo.dtmf_separator = DtmfInfo.separator[0];
		}
		CpsGenInfo.dtmf_group_code = DtmfInfo.group_code[0];
		CpsGenInfo.dtmf_reset_time = Convert.ToByte(DtmfInfo.reset_time);
		CpsGenInfo.dtmf_carry_time = Convert.ToUInt16(DtmfInfo.carry_time);
		CpsGenInfo.dtmf_first_code_time = Convert.ToUInt16(DtmfInfo.first_code_time);
		CpsGenInfo.dtmf_D_code_time = Convert.ToUInt16(DtmfInfo.D_code_time);
		CpsGenInfo.dtmf_single_continue_time = Convert.ToUInt16(DtmfInfo.single_continue_time);
		CpsGenInfo.dtmf_single_interval_time = Convert.ToUInt16(DtmfInfo.single_interval_time);
		CpsGenInfo.dtmf_id = new byte[8];
		CpsGenInfo.dtmf_DnCode = new byte[16];
		CpsGenInfo.dtmf_UpCode = new byte[16];
		byte[] array = Iparse.ConvertStringToByte(DtmfInfo.id, "default");
		Array.Copy(array, CpsGenInfo.dtmf_id, array.Length);
		array = Iparse.ConvertStringToByte(DtmfInfo.UpCode, "default");
		Array.Copy(array, CpsGenInfo.dtmf_UpCode, array.Length);
		array = Iparse.ConvertStringToByte(DtmfInfo.DnCode, "default");
		Array.Copy(array, CpsGenInfo.dtmf_DnCode, array.Length);
		if (string.IsNullOrEmpty(_5ToneInfo.RepeatTone))
		{
			_5ToneInfo = _5tone.InitStructInfo();
		}
		CpsGenInfo._5tone_separator = _5ToneInfo.RepeatTone[0];
		CpsGenInfo._5tone_group_code = _5ToneInfo.group_code[0];
		CpsGenInfo._5tonef_reset_time = Convert.ToByte(_5ToneInfo.reset_time);
		CpsGenInfo._5tone_carry_time = Convert.ToUInt16(_5ToneInfo.carry_time);
		CpsGenInfo._5tone_first_code_time = Convert.ToUInt16(_5ToneInfo.first_code_time);
		list = param_string._5tone_protocol_Items();
		CpsGenInfo._5tone_protocol = (byte)list.IndexOf(_5ToneInfo.protocol);
		CpsGenInfo._5tone_single_continue_time = Convert.ToUInt16(_5ToneInfo.single_continue_time);
		CpsGenInfo._5tone_single_interval_time = Convert.ToUInt16(_5ToneInfo.single_interval_time);
		CpsGenInfo._5tone_id = new byte[8];
		CpsGenInfo._5tone_UpCode = new byte[16];
		CpsGenInfo._5tone_DnCode = new byte[16];
		array = Iparse.ConvertStringToByte(_5ToneInfo.id, "default");
		Array.Copy(array, CpsGenInfo._5tone_id, array.Length);
		array = Iparse.ConvertStringToByte(_5ToneInfo.UpCode, "default");
		Array.Copy(array, CpsGenInfo._5tone_UpCode, array.Length);
		array = Iparse.ConvertStringToByte(_5ToneInfo.DnCode, "default");
		Array.Copy(array, CpsGenInfo._5tone_DnCode, array.Length);
		CpsGenInfo._5tone_user_freq = new ushort[15];
		for (int i = 0; i < 15; i++)
		{
			CpsGenInfo._5tone_user_freq[i] = Convert.ToUInt16(_5ToneInfo.user_freq[i]);
		}
		CpsGenInfo.logo_string1 = new byte[16];
		CpsGenInfo.logo_string2 = new byte[16];
		array = Iparse.ConvertStringToByte(GenInfo.logo_1, "default");
		Array.Copy(array, CpsGenInfo.logo_string1, array.Length);
		array = Iparse.ConvertStringToByte(GenInfo.logo_2, "default");
		Array.Copy(array, CpsGenInfo.logo_string2, array.Length);
		CpsGenInfo.CWPitchFreq = (ushort)GenInfo.CwPitchFreq;
	}

	public void ConvertFmParam()
	{
		if (string.IsNullOrEmpty(GenInfo.auto_lock))
		{
			GenInfo = genset.InitStructInfo();
		}
		CpsFm.vfo_freq = ConvertFmFreq(GenInfo.fm_vfo_freq);
		List<string> list = param_string.gen_fm_mode_Items();
		CpsFm.mr_vfo_flag = (byte)list.IndexOf(GenInfo.fm_mode);
		CpsFm.mr_idx = Convert.ToByte(GenInfo.fm_chn_idx);
		CpsFm.mr_idx--;
		CpsFm.freq = new ushort[32];
		for (int i = 0; i < 32; i++)
		{
			CpsFm.freq[i] = ConvertFmFreq(FmInfo[i].freq);
		}
	}

	public ushort ConvertFmFreq(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return ushort.MaxValue;
		}
		double num = Convert.ToDouble(s);
		return (ushort)(num * 10.0);
	}

	public void ConvertVfoParam()
	{
		for (int i = 0; i < 13; i++)
		{
			ref CPS_VFO_INFO reference = ref CpsVfoInfo[0, i];
			reference = cps_convert.convert_data(VfoInfo[0, i]);
			ref CPS_VFO_INFO reference2 = ref CpsVfoInfo[1, i];
			reference2 = cps_convert.convert_data(VfoInfo[1, i]);
		}
	}

	public void ConvertChannelParam()
	{
		List<string> list = param_string.chn_freq_rang_Items();
		CpsChannelFlagInfo.flag = new byte[999];
		for (int i = 0; i < 999; i++)
		{
			ref CPS_CHANNEL_INFO reference = ref CpsChannelInfo[i];
			reference = cps_convert.convert_data(ChannelInfo[i]);
			if (CpsChannelInfo[i].rx_freq != 0)
			{
				CpsChannelFlagInfo.flag[i] = GetChnFreqRang(CpsChannelInfo[i].rx_freq);
			}
			else
			{
				CpsChannelFlagInfo.flag[i] = byte.MaxValue;
			}
		}
	}

	public byte GetChnFreqRang(uint freq)
	{
		byte b = 0;
		for (int i = 0; i < 12; i++)
		{
			uint num = (uint)(param_string.freq_rang[i * 2] * 100000.0);
			uint num2 = (uint)(param_string.freq_rang[i * 2 + 1] * 100000.0);
			if (num <= freq && freq <= num2)
			{
				break;
			}
			b++;
		}
		return b;
	}

	public void GetChannelParam()
	{
		int structSizeof = Iparse.GetStructSizeof(default(CPS_CHANNEL_INFO));
		int num = 0;
		for (int i = 0; i < 999; i++)
		{
			if (CpsChannelInfo[i].rx_freq != 0)
			{
				byte[] sourceArray = Iparse.StructToBytes(CpsChannelInfo[i], structSizeof);
				Array.Copy(sourceArray, 0, CpsData, num, structSizeof);
			}
			num += structSizeof;
		}
	}

	public void GetVfoParam()
	{
		int structSizeof = Iparse.GetStructSizeof(default(CPS_VFO_INFO));
		int num = 65536;
		for (int i = 0; i < 13; i++)
		{
			byte[] sourceArray = Iparse.StructToBytes(CpsVfoInfo[0, i], structSizeof);
			Array.Copy(sourceArray, 0, CpsData, num, structSizeof);
			num += structSizeof;
			sourceArray = Iparse.StructToBytes(CpsVfoInfo[1, i], structSizeof);
			Array.Copy(sourceArray, 0, CpsData, num, structSizeof);
			num += structSizeof;
		}
	}

	public void GetChannelFlagParam()
	{
		int structSizeof = Iparse.GetStructSizeof(default(CPS_CHANNEL_FLAG_INFO));
		int destinationIndex = 69632;
		byte[] sourceArray = Iparse.StructToBytes(CpsChannelFlagInfo, structSizeof);
		Array.Copy(sourceArray, 0, CpsData, destinationIndex, structSizeof);
	}

	public void GetFmParam()
	{
		int structSizeof = Iparse.GetStructSizeof(default(CPS_FM_INFO));
		int destinationIndex = 73728;
		byte[] sourceArray = Iparse.StructToBytes(CpsFm, structSizeof);
		Array.Copy(sourceArray, 0, CpsData, destinationIndex, structSizeof);
	}

	public void GetGen1Param()
	{
		int structSizeof = Iparse.GetStructSizeof(default(CPS_GEN_INFO));
		int destinationIndex = 77824;
		byte[] sourceArray = Iparse.StructToBytes(CpsGenInfo, structSizeof);
		Array.Copy(sourceArray, 0, CpsData, destinationIndex, structSizeof);
	}

	public void GetGen2Param()
	{
		int structSizeof = Iparse.GetStructSizeof(default(CPS_GEN2_INFO));
		int destinationIndex = 81920;
		byte[] sourceArray = Iparse.StructToBytes(CpsGen2Info, structSizeof);
		Array.Copy(sourceArray, 0, CpsData, destinationIndex, structSizeof);
	}

	public void GetChannelIndexParam()
	{
		int structSizeof = Iparse.GetStructSizeof(default(CPS_CHANNEL_IDX_INFO));
		int destinationIndex = 86016;
		List<string> list = param_string.gen_A_MR_VFO_Items();
		CpsChnIndex.A_idx = (ushort)list.IndexOf(GenInfo.A_vfo_mr_mode);
		list = param_string.gen_B_MR_VFO_Items();
		CpsChnIndex.B_idx = (ushort)list.IndexOf(GenInfo.B_vfo_mr_mode);
		if (CpsChnIndex.A_idx < 999)
		{
			CpsChnIndex.chn_A_idx = CpsChnIndex.A_idx;
			CpsChnIndex.freq_A_idx = 1007;
		}
		else
		{
			CpsChnIndex.freq_A_idx = CpsChnIndex.A_idx;
			CpsChnIndex.chn_A_idx = 0;
		}
		if (CpsChnIndex.B_idx < 999)
		{
			CpsChnIndex.chn_B_idx = CpsChnIndex.A_idx;
			CpsChnIndex.freq_B_idx = 1007;
		}
		else
		{
			CpsChnIndex.freq_B_idx = CpsChnIndex.A_idx;
			CpsChnIndex.chn_B_idx = 0;
		}
		CpsChnIndex.noaa_A_idx = 1012;
		CpsChnIndex.noaa_B_idx = 1012;
		byte[] sourceArray = Iparse.StructToBytes(CpsChnIndex, structSizeof);
		Array.Copy(sourceArray, 0, CpsData, destinationIndex, structSizeof);
	}

	public void GetScanlistParam()
	{
		int structSizeof = Iparse.GetStructSizeof(default(CPS_SCAN_INFO));
		int num = 90112;
		for (int i = 0; i < 32; i++)
		{
			byte[] sourceArray = Iparse.StructToBytes(CpsScanInfo[i], structSizeof);
			Array.Copy(sourceArray, 0, CpsData, num, structSizeof);
			num += 128;
		}
	}

	public void GetHideParam()
	{
		int structSizeof = Iparse.GetStructSizeof(default(CPS_HIDE_PARAM_INFO));
		int destinationIndex = 102400;
		byte[] sourceArray = Iparse.StructToBytes(CpsHideParamInfo, structSizeof);
		Array.Copy(sourceArray, 0, CpsData, destinationIndex, structSizeof);
	}

	public void GetDtmfContactParam()
	{
		int structSizeof = Iparse.GetStructSizeof(default(CPS_DTMF_CONTACT_INFO));
		int num = 106496;
		for (int i = 0; i < CpsDtmfContactInfo.GetLength(0); i++)
		{
			byte[] sourceArray = Iparse.StructToBytes(CpsDtmfContactInfo[i], structSizeof);
			Array.Copy(sourceArray, 0, CpsData, num, structSizeof);
			num += structSizeof;
		}
	}

	public void Get5toneContactParam()
	{
		int structSizeof = Iparse.GetStructSizeof(default(CPS_5TONE_CONTACT_INFO));
		int num = 108544;
		for (int i = 0; i < Cps5toneContactInfo.GetLength(0); i++)
		{
			byte[] sourceArray = Iparse.StructToBytes(Cps5toneContactInfo[i], structSizeof);
			Array.Copy(sourceArray, 0, CpsData, num, structSizeof);
			num += structSizeof;
		}
	}

	private void 打开OToolStripButton_Click(object sender, EventArgs e)
	{
		string text = Iparse.getchart("path", "path");
		if (!Directory.Exists(text))
		{
			text = Application.StartupPath;
		}
		openFileDialog1.Filter = "(*.dat)|*.dat";
		openFileDialog1.FileName = GetLang("model");
		openFileDialog1.InitialDirectory = text;
		openFileDialog1.ShowDialog();
	}

	private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
	{
		string path = openFileDialog1.FileName.ToString();
		Iparse.setchart("path", "path", Path.GetDirectoryName(path));
		OpenFile(path);
	}

	public void OpenFile(string path)
	{
		try
		{
			FileStream fileStream = File.OpenRead(path);
			CpsData = new byte[fileStream.Length];
			fileStream.Read(CpsData, 0, CpsData.Length);
			fileStream.Close();
			PareCpsData("file");
			MessageBox.Show(GetLang("open_success"));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void dgv_5tone_contacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void dgv_5tone_contacts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			contact_Index = e.RowIndex;
			contact contact2 = new contact();
			click_item = "5tone";
			contact2.ShowDialog();
			Load5toneContactParam(dgv_5tone_contacts, contact_Index);
		}
	}

	public static void Load5toneContactParam(DataGridView dgv, int i)
	{
		int num = 0;
		_5TONE_CONTACT_INFO _5TONE_CONTACT_INFO2 = _5toneContactInfo[i];
		dgv.Rows[i].Cells[num++].Value = (i + 1).ToString();
		dgv.Rows[i].Cells[num++].Value = _5TONE_CONTACT_INFO2.name;
		dgv.Rows[i].Cells[num++].Value = _5TONE_CONTACT_INFO2.id;
	}

	private void toolStripButton4_Click(object sender, EventArgs e)
	{
		login login2 = new login();
		password_mode = "eng_mode";
		login2.ShowDialog();
		if (gEngineerMode && !IsHideParamTree)
		{
			IsHideParamTree = true;
			tn.Nodes.Add(GetLang("Hide_param"), GetLang("Hide_param"), 2, 2);
		}
	}

	private void dgv_noaa_decode_addr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			noaa_decode_addr_index = e.RowIndex;
			Noaa_addr noaa_addr = new Noaa_addr();
			noaa_addr.ShowDialog();
			LoadNoaaDecodeAddrParam(dgv_noaa_decode_addr, noaa_decode_addr_index);
		}
	}

	public static void LoadNoaaDecodeAddrParam(DataGridView dgv, int i)
	{
		int num = 0;
		NOAA_DECODE_ADDR nOAA_DECODE_ADDR = NoaaDecodeAddrInfo[i];
		dgv.Rows[i].Cells[num++].Value = (i + 1).ToString();
		dgv.Rows[i].Cells[num++].Value = nOAA_DECODE_ADDR.addr;
		dgv.Rows[i].Cells[num++].Value = nOAA_DECODE_ADDR.info;
	}

	private void dgv_noaa_event_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	public static void LoadNoaaEventParam(DataGridView dgv, int i)
	{
		int num = 0;
		NOAA_EVENT nOAA_EVENT = NoaaEventInfo[i];
		dgv.Rows[i].Cells[num++].Value = (i + 1).ToString();
		dgv.Rows[i].Cells[num++].Value = nOAA_EVENT.even_number;
		dgv.Rows[i].Cells[num++].Value = nOAA_EVENT.duration;
		dgv.Rows[i].Cells[num++].Value = nOAA_EVENT.date;
		dgv.Rows[i].Cells[num++].Value = nOAA_EVENT.event_befor_org;
		dgv.Rows[i].Cells[num++].Value = nOAA_EVENT.event_current_org;
	}

	private void toolStripButton5_Click(object sender, EventArgs e)
	{
		wfm_firmware wfm_firmware2 = new wfm_firmware();
		wfm_firmware2.ShowDialog();
	}

	private void tsm_export_ch_csv_Click(object sender, EventArgs e)
	{
		using SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "CSV Files|*.csv";
		saveFileDialog.Title = "Save CSV File";
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			ExportDataGridViewToCsv(dgv_ch, saveFileDialog.FileName);
			MessageBox.Show(GetLang("success"));
		}
	}

	private void ExportDataGridViewToCsv(DataGridView dgv, string filePath)
	{
		using StreamWriter writer = new StreamWriter(filePath, append: false, Encoding.Default);
		using CsvWriter csvWriter = new CsvWriter(writer, new CsvConfiguration());
		foreach (DataGridViewColumn column in dgv.Columns)
		{
			csvWriter.WriteField(column.HeaderText);
		}
		csvWriter.NextRecord();
		foreach (DataGridViewRow item in (IEnumerable)dgv.Rows)
		{
			if (item.IsNewRow)
			{
				continue;
			}
			foreach (DataGridViewCell cell in item.Cells)
			{
				csvWriter.WriteField((cell.Value != null) ? cell.Value.ToString() : "");
			}
			csvWriter.NextRecord();
		}
	}

	private void tsm_import_ch_csv_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "CSV Files|*.csv";
		openFileDialog.Title = "Select CSV File";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			dgv_ch.Rows.Clear();
			try
			{
				ImportCsvToDataGridView(openFileDialog.FileName, dgv_ch);
				return;
			}
			catch (Exception ex)
			{
				dgv_ch.Columns.Clear();
				dgv_ch.Rows.Clear();
				GridViewChannelInit();
				MessageBox.Show(ex.ToString());
				return;
			}
		}
	}

	public bool CheckFreq(int seq, string title, string freq)
	{
		double num = 0.153;
		int num2 = 600;
		bool flag = true;
		if (string.IsNullOrEmpty(freq))
		{
			return true;
		}
		try
		{
			double num3 = Convert.ToDouble(freq);
			if (num3 > (double)num2)
			{
				flag = false;
			}
			else if (num3 < num)
			{
				flag = false;
			}
		}
		catch (Exception)
		{
			flag = false;
		}
		if (!flag)
		{
			string text = GetLang("行号") + "     " + (seq + 1) + "     " + title + "\r\n" + GetLang("错误字符串") + "          " + freq;
			MessageBox.Show(text);
		}
		return flag;
	}

	private void ImportCsvToDataGridView(string filePath, DataGridView dgv)
	{
		ChannelInfo = new CHANNEL_INFO[999];
		int i = 0;
		int num = 0;
		bool flag = true;
		Encoding encoding = Encoding.Default;
		using (FileStream stream = File.Open(filePath, FileMode.Open))
		{
			CharsetDetector charsetDetector = new CharsetDetector();
			charsetDetector.Feed(stream);
			charsetDetector.DataEnd();
			if (charsetDetector.Charset != null)
			{
				encoding = Encoding.GetEncoding(charsetDetector.Charset);
			}
		}
		using (StreamReader reader = new StreamReader(filePath, encoding))
		{
			using CsvReader csvReader = new CsvReader(reader, new CsvConfiguration());
			while (csvReader.Read())
			{
				List<string> list = new List<string>();
				string[] fieldHeaders = csvReader.FieldHeaders;
				foreach (string name in fieldHeaders)
				{
					list.Add(csvReader.GetField(name) ?? "");
				}
				num = 1;
				ChannelInfo[i].name = list[num++];
				if (!CheckFreq(i, csvReader.FieldHeaders[num], list[num]))
				{
					break;
				}
				ChannelInfo[i].rx_freq = list[num++];
				if (!CheckFreq(i, csvReader.FieldHeaders[num], list[num]))
				{
					break;
				}
				ChannelInfo[i].tx_freq = list[num++];
				ChannelInfo[i].rx_qt_type = GetLang("_null");
				ChannelInfo[i].tx_qt_type = GetLang("_null");
				ChannelInfo[i].qt_rx_null = GetLang("_null");
				ChannelInfo[i].qt_rx_ctc = param_string.CtcssString[0];
				ChannelInfo[i].qt_rx_dcs = param_string.DcsString[0];
				ChannelInfo[i].qt_tx_null = GetLang("_null");
				ChannelInfo[i].qt_tx_ctc = param_string.CtcssString[0];
				ChannelInfo[i].qt_tx_dcs = param_string.DcsString[0];
				List<string> list2 = param_string.chn_qttype_Items();
				list2 = param_string.chn_qttype_Items();
				if (Check_Contains(list2, i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].tx_qt_type = list[num++];
				string text = list[num++];
				switch (list2.IndexOf(ChannelInfo[i].tx_qt_type))
				{
				case 0:
					ChannelInfo[i].qt_tx_null = text;
					break;
				case 1:
					try
					{
						double num2 = Convert.ToDouble(text);
						if (num2 <= 300.0)
						{
							ChannelInfo[i].qt_tx_ctc = text;
							break;
						}
						Check_Contains(list2, i, csvReader.FieldHeaders[num - 1], text);
						flag = false;
					}
					catch (Exception)
					{
						Check_Contains(list2, i, csvReader.FieldHeaders[num - 1], text);
						flag = false;
					}
					goto end_IL_0849;
				default:
					ChannelInfo[i].qt_tx_dcs = text;
					break;
				}
				list2 = param_string.chn_qttype_Items();
				if (Check_Contains(list2, i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].rx_qt_type = list[num++];
				text = list[num++];
				switch (list2.IndexOf(ChannelInfo[i].rx_qt_type))
				{
				case 0:
					ChannelInfo[i].qt_rx_null = text;
					break;
				case 1:
					try
					{
						double num2 = Convert.ToDouble(text);
						if (num2 <= 300.0)
						{
							ChannelInfo[i].qt_rx_ctc = text;
							break;
						}
						Check_Contains(list2, i, csvReader.FieldHeaders[num - 1], text);
						flag = false;
					}
					catch (Exception)
					{
						Check_Contains(list2, i, csvReader.FieldHeaders[num - 1], text);
						flag = false;
					}
					goto end_IL_0849;
				default:
					ChannelInfo[i].qt_rx_dcs = text;
					break;
				}
				if (Check_Contains(param_string.chn_MSW_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].msw = list[num++];
				if (Check_Contains(param_string.chn_band_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].band = list[num++];
				if (Check_Contains(param_string.chn_power_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].power = list[num++];
				if (Check_Contains(param_string.chn_on_off_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].busy = list[num++];
				if (Check_Contains(param_string.chn_scanlist_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].scanlist = list[num++];
				if (Check_Contains(param_string.chn_demode_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].am = list[num++];
				if (Check_Contains(param_string.chn_on_off_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].reverse = list[num++];
				if (Check_Contains(param_string.gen_sq_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].sq = list[num++];
				if (Check_Contains(param_string.chn_encypt_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].encypt = list[num++];
				if (Check_Contains(param_string.chn_on_off_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].dtmf_decdoe_flag = list[num++];
				if (Check_Contains(param_string.chn_pttid_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].pttid = list[num++];
				if (Check_Contains(param_string.gen_signal_Items(), i, csvReader.FieldHeaders[num], list[num]))
				{
					flag = false;
					break;
				}
				ChannelInfo[i].signal = list[num++];
				i++;
				dgv.Rows.Add(list.ToArray());
				continue;
				end_IL_0849:
				break;
			}
		}
		if (i < 999)
		{
			dgv.Rows.Add(999 - i);
			for (; i < 999; i++)
			{
				dgv.Rows[i].Cells[0].Value = (i + 1).ToString();
			}
		}
		if (flag)
		{
			MessageBox.Show(GetLang("success"));
		}
		else
		{
			MessageBox.Show(GetLang("fail"));
		}
	}

	public bool Check_Contains(List<string> item, int seq, string title, string content)
	{
		if (string.IsNullOrEmpty(content))
		{
			return false;
		}
		if (!item.Contains(content))
		{
			string text = GetLang("行号") + "     " + (seq + 1) + "     " + title + "\r\n" + GetLang("错误字符串") + "          " + content;
			MessageBox.Show(text);
			return true;
		}
		return false;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(K7.main));
		this.toolStrip1 = new System.Windows.Forms.ToolStrip();
		this.打开OToolStripButton = new System.Windows.Forms.ToolStripButton();
		this.保存SToolStripButton = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
		this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
		this.tscmb_lang = new System.Windows.Forms.ToolStripComboBox();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
		this.tssbt_csv = new System.Windows.Forms.ToolStripSplitButton();
		this.tsm_export_ch_csv = new System.Windows.Forms.ToolStripMenuItem();
		this.tsm_import_ch_csv = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
		this.treeView1 = new System.Windows.Forms.TreeView();
		this.dgv_ch = new System.Windows.Forms.DataGridView();
		this.dgv_fm = new System.Windows.Forms.DataGridView();
		this.dgv_dtmf_contact = new System.Windows.Forms.DataGridView();
		this.dgv_scan = new System.Windows.Forms.DataGridView();
		this.dgv_vfo = new System.Windows.Forms.DataGridView();
		this.dgv_5tone_contacts = new System.Windows.Forms.DataGridView();
		this.dgv_noaa_decode_addr = new System.Windows.Forms.DataGridView();
		this.dgv_noaa_event = new System.Windows.Forms.DataGridView();
		this.toolStrip1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgv_ch).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_fm).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_dtmf_contact).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_scan).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_vfo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_5tone_contacts).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_noaa_decode_addr).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_noaa_event).BeginInit();
		base.SuspendLayout();
		this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[18]
		{
			this.打开OToolStripButton, this.保存SToolStripButton, this.toolStripSeparator6, this.toolStripButton1, this.toolStripSeparator3, this.toolStripButton2, this.toolStripSeparator4, this.toolStripComboBox1, this.toolStripSeparator5, this.tscmb_lang,
			this.toolStripSeparator1, this.toolStripButton4, this.toolStripSeparator7, this.toolStripButton3, this.toolStripSeparator2, this.toolStripButton5, this.tssbt_csv, this.toolStripLabel1
		});
		this.toolStrip1.Location = new System.Drawing.Point(0, 0);
		this.toolStrip1.Name = "toolStrip1";
		this.toolStrip1.Size = new System.Drawing.Size(1235, 28);
		this.toolStrip1.TabIndex = 2;
		this.toolStrip1.Text = "toolStrip1";
		this.打开OToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.打开OToolStripButton.Image = (System.Drawing.Image)resources.GetObject("打开OToolStripButton.Image");
		this.打开OToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.打开OToolStripButton.Name = "打开OToolStripButton";
		this.打开OToolStripButton.Size = new System.Drawing.Size(24, 25);
		this.打开OToolStripButton.Text = "Open(&O)";
		this.打开OToolStripButton.Click += new System.EventHandler(打开OToolStripButton_Click);
		this.保存SToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.保存SToolStripButton.Image = (System.Drawing.Image)resources.GetObject("保存SToolStripButton.Image");
		this.保存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.保存SToolStripButton.Name = "保存SToolStripButton";
		this.保存SToolStripButton.Size = new System.Drawing.Size(24, 25);
		this.保存SToolStripButton.Text = "Save(&S)";
		this.保存SToolStripButton.Click += new System.EventHandler(保存SToolStripButton_Click);
		this.toolStripSeparator6.Name = "toolStripSeparator6";
		this.toolStripSeparator6.Size = new System.Drawing.Size(6, 28);
		this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.toolStripButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripButton1.Image");
		this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton1.Name = "toolStripButton1";
		this.toolStripButton1.Size = new System.Drawing.Size(24, 25);
		this.toolStripButton1.Text = "Read";
		this.toolStripButton1.Click += new System.EventHandler(toolStripButton1_Click);
		this.toolStripSeparator3.Name = "toolStripSeparator3";
		this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
		this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.toolStripButton2.Image = (System.Drawing.Image)resources.GetObject("toolStripButton2.Image");
		this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton2.Name = "toolStripButton2";
		this.toolStripButton2.Size = new System.Drawing.Size(24, 25);
		this.toolStripButton2.Text = "Write";
		this.toolStripButton2.Click += new System.EventHandler(toolStripButton2_Click);
		this.toolStripSeparator4.Name = "toolStripSeparator4";
		this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
		this.toolStripComboBox1.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
		this.toolStripComboBox1.Name = "toolStripComboBox1";
		this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
		this.toolStripComboBox1.DropDown += new System.EventHandler(toolStripComboBox1_DropDown);
		this.toolStripComboBox1.Enter += new System.EventHandler(toolStripComboBox1_Enter);
		this.toolStripSeparator5.Name = "toolStripSeparator5";
		this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
		this.tscmb_lang.Items.AddRange(new object[2] { "中文", "English" });
		this.tscmb_lang.Name = "tscmb_lang";
		this.tscmb_lang.Size = new System.Drawing.Size(121, 28);
		this.tscmb_lang.SelectedIndexChanged += new System.EventHandler(toolStripComboBox2_SelectedIndexChanged);
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
		this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.toolStripButton4.Image = (System.Drawing.Image)resources.GetObject("toolStripButton4.Image");
		this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton4.Name = "toolStripButton4";
		this.toolStripButton4.Size = new System.Drawing.Size(73, 25);
		this.toolStripButton4.Text = "工程模式";
		this.toolStripButton4.Click += new System.EventHandler(toolStripButton4_Click);
		this.toolStripSeparator7.Name = "toolStripSeparator7";
		this.toolStripSeparator7.Size = new System.Drawing.Size(6, 28);
		this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.toolStripButton3.Image = (System.Drawing.Image)resources.GetObject("toolStripButton3.Image");
		this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton3.Name = "toolStripButton3";
		this.toolStripButton3.Size = new System.Drawing.Size(73, 25);
		this.toolStripButton3.Text = "修改密码";
		this.toolStripButton3.Click += new System.EventHandler(toolStripButton3_Click);
		this.toolStripSeparator2.Name = "toolStripSeparator2";
		this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
		this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.toolStripButton5.Image = (System.Drawing.Image)resources.GetObject("toolStripButton5.Image");
		this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton5.Name = "toolStripButton5";
		this.toolStripButton5.Size = new System.Drawing.Size(73, 25);
		this.toolStripButton5.Text = "固件更新";
		this.toolStripButton5.Click += new System.EventHandler(toolStripButton5_Click);
		this.tssbt_csv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.tssbt_csv.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.tsm_export_ch_csv, this.tsm_import_ch_csv });
		this.tssbt_csv.Image = (System.Drawing.Image)resources.GetObject("tssbt_csv.Image");
		this.tssbt_csv.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tssbt_csv.Name = "tssbt_csv";
		this.tssbt_csv.Size = new System.Drawing.Size(87, 25);
		this.tssbt_csv.Text = "CSV操作";
		this.tsm_export_ch_csv.Name = "tsm_export_ch_csv";
		this.tsm_export_ch_csv.Size = new System.Drawing.Size(173, 26);
		this.tsm_export_ch_csv.Text = "导出信道CSV";
		this.tsm_export_ch_csv.Click += new System.EventHandler(tsm_export_ch_csv_Click);
		this.tsm_import_ch_csv.Name = "tsm_import_ch_csv";
		this.tsm_import_ch_csv.Size = new System.Drawing.Size(173, 26);
		this.tsm_import_ch_csv.Text = "导入信道CSV";
		this.tsm_import_ch_csv.Click += new System.EventHandler(tsm_import_ch_csv_Click);
		this.toolStripLabel1.Name = "toolStripLabel1";
		this.toolStripLabel1.Size = new System.Drawing.Size(88, 25);
		this.toolStripLabel1.Text = "version 2.7";
		this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
		this.treeView1.Font = new System.Drawing.Font("宋体", 13.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.treeView1.Location = new System.Drawing.Point(0, 28);
		this.treeView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.treeView1.Name = "treeView1";
		this.treeView1.Size = new System.Drawing.Size(289, 715);
		this.treeView1.TabIndex = 9;
		this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
		this.dgv_ch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv_ch.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgv_ch.Location = new System.Drawing.Point(289, 28);
		this.dgv_ch.Name = "dgv_ch";
		this.dgv_ch.RowTemplate.Height = 27;
		this.dgv_ch.Size = new System.Drawing.Size(946, 715);
		this.dgv_ch.TabIndex = 20;
		this.dgv_ch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(GridViewInfo_CH_CellDoubleClick);
		this.dgv_fm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv_fm.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgv_fm.Location = new System.Drawing.Point(289, 28);
		this.dgv_fm.Name = "dgv_fm";
		this.dgv_fm.RowTemplate.Height = 27;
		this.dgv_fm.Size = new System.Drawing.Size(946, 715);
		this.dgv_fm.TabIndex = 21;
		this.dgv_fm.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dgv_fm_CellMouseDoubleClick);
		this.dgv_dtmf_contact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv_dtmf_contact.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgv_dtmf_contact.Location = new System.Drawing.Point(289, 28);
		this.dgv_dtmf_contact.Name = "dgv_dtmf_contact";
		this.dgv_dtmf_contact.RowTemplate.Height = 27;
		this.dgv_dtmf_contact.Size = new System.Drawing.Size(946, 715);
		this.dgv_dtmf_contact.TabIndex = 22;
		this.dgv_dtmf_contact.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dgv_dtmf_contact_CellMouseDoubleClick);
		this.dgv_scan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv_scan.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgv_scan.Location = new System.Drawing.Point(289, 28);
		this.dgv_scan.Name = "dgv_scan";
		this.dgv_scan.RowTemplate.Height = 27;
		this.dgv_scan.Size = new System.Drawing.Size(946, 715);
		this.dgv_scan.TabIndex = 23;
		this.dgv_scan.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dgv_scan_CellMouseDoubleClick);
		this.dgv_vfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv_vfo.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgv_vfo.Location = new System.Drawing.Point(289, 28);
		this.dgv_vfo.Name = "dgv_vfo";
		this.dgv_vfo.RowTemplate.Height = 27;
		this.dgv_vfo.Size = new System.Drawing.Size(946, 715);
		this.dgv_vfo.TabIndex = 24;
		this.dgv_vfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgv_vfo_CellDoubleClick);
		this.dgv_5tone_contacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv_5tone_contacts.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgv_5tone_contacts.Location = new System.Drawing.Point(289, 28);
		this.dgv_5tone_contacts.Name = "dgv_5tone_contacts";
		this.dgv_5tone_contacts.RowTemplate.Height = 27;
		this.dgv_5tone_contacts.Size = new System.Drawing.Size(946, 715);
		this.dgv_5tone_contacts.TabIndex = 25;
		this.dgv_5tone_contacts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgv_5tone_contacts_CellContentClick);
		this.dgv_5tone_contacts.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dgv_5tone_contacts_CellMouseDoubleClick);
		this.dgv_noaa_decode_addr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv_noaa_decode_addr.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgv_noaa_decode_addr.Location = new System.Drawing.Point(289, 28);
		this.dgv_noaa_decode_addr.Name = "dgv_noaa_decode_addr";
		this.dgv_noaa_decode_addr.RowTemplate.Height = 27;
		this.dgv_noaa_decode_addr.Size = new System.Drawing.Size(946, 715);
		this.dgv_noaa_decode_addr.TabIndex = 26;
		this.dgv_noaa_decode_addr.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgv_noaa_decode_addr_CellDoubleClick);
		this.dgv_noaa_event.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv_noaa_event.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgv_noaa_event.Location = new System.Drawing.Point(289, 28);
		this.dgv_noaa_event.Name = "dgv_noaa_event";
		this.dgv_noaa_event.RowTemplate.Height = 27;
		this.dgv_noaa_event.Size = new System.Drawing.Size(946, 715);
		this.dgv_noaa_event.TabIndex = 27;
		this.dgv_noaa_event.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgv_noaa_event_CellDoubleClick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1235, 743);
		base.Controls.Add(this.dgv_noaa_event);
		base.Controls.Add(this.dgv_noaa_decode_addr);
		base.Controls.Add(this.dgv_5tone_contacts);
		base.Controls.Add(this.dgv_vfo);
		base.Controls.Add(this.dgv_scan);
		base.Controls.Add(this.dgv_dtmf_contact);
		base.Controls.Add(this.dgv_fm);
		base.Controls.Add(this.dgv_ch);
		base.Controls.Add(this.treeView1);
		base.Controls.Add(this.toolStrip1);
		base.Name = "main";
		this.Text = "Form1";
		base.Load += new System.EventHandler(main_Load);
		this.toolStrip1.ResumeLayout(false);
		this.toolStrip1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.dgv_ch).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_fm).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_dtmf_contact).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_scan).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_vfo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_5tone_contacts).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_noaa_decode_addr).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgv_noaa_event).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
