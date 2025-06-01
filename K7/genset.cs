using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using K7.Properties;
using NAudio.Wave;

namespace K7;

public class genset : Form
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BITMAPFILEHEADER
	{
		public ushort bfType;

		public uint bfSize;

		public ushort bfReserved1;

		public ushort bfReserved2;

		public uint bfOffBits;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BITMAPINFOHEADER
	{
		public uint biSize;

		public uint biWidth;

		public uint biHeight;

		public ushort biPlanes;

		public ushort biBitCount;

		public uint biCompression;

		public uint biSizeImage;

		public uint biXPelsPerMeter;

		public uint biYPelsPerMeter;

		public uint biClrUsed;

		public uint biClrImportant;
	}

	public static string pictrue_path = null;

	public CheckBox[] checkbox_band_enable = new CheckBox[13];

	public CheckBox[] checkbox_band_tx_enable = new CheckBox[13];

	public TextBox[,] txtbox_rx_freq = new TextBox[13, 2];

	public TextBox[,] txtbox_tx_freq = new TextBox[13, 2];

	public TextBox[] txtbox_selftone = new TextBox[5];

	public Button[] btn_selftone = new Button[5];

	private OpenFileDialog openFileDialog1 = new OpenFileDialog();

	public BITMAPFILEHEADER bmpfilehead = default(BITMAPFILEHEADER);

	public BITMAPINFOHEADER bmpinfohead = default(BITMAPINFOHEADER);

	private IContainer components = null;

	private Button btn_cancel;

	private Button btn_ok;

	private TabPage tabPage10;

	private GroupBox groupBox5;

	private Button button8;

	private PictureBox pictureBox1;

	private CheckBox checkBox_picture;

	private TabPage tabPage9;

	private GroupBox groupBox4;

	private Button button5;

	private Button button4;

	private Button button3;

	private Button button2;

	private Button button1;

	private TextBox textBox9;

	private Label label55;

	private TextBox textBox8;

	private Label label54;

	private TextBox textBox7;

	private Label label53;

	private TextBox textBox6;

	private Label label52;

	private TextBox textBox5;

	private Label label51;

	private CheckBox checkBox_selftone;

	private TabPage tabPage8;

	private GroupBox groupBox3;

	private Label label58;

	private Label label59;

	private TextBox textBox12;

	private TextBox textBox13;

	private Label label83;

	private Label label84;

	private TextBox textBox36;

	private TextBox textBox37;

	private Label label85;

	private Label label86;

	private TextBox textBox38;

	private TextBox textBox39;

	private Label label87;

	private Label label88;

	private TextBox textBox40;

	private TextBox textBox41;

	private Label label89;

	private Label label90;

	private TextBox textBox42;

	private TextBox textBox43;

	private Label label91;

	private Label label92;

	private TextBox textBox44;

	private TextBox textBox45;

	private Label label93;

	private Label label94;

	private TextBox textBox46;

	private TextBox textBox47;

	private Label label95;

	private Label label96;

	private TextBox textBox48;

	private TextBox textBox49;

	private Label label97;

	private Label label98;

	private TextBox textBox50;

	private TextBox textBox51;

	private Label label99;

	private Label label100;

	private TextBox textBox52;

	private TextBox textBox53;

	private Label label101;

	private Label label102;

	private TextBox textBox54;

	private TextBox textBox55;

	private Label label103;

	private Label label104;

	private TextBox textBox56;

	private TextBox textBox57;

	private Label label105;

	private GroupBox groupBox2;

	private Label label81;

	private Label label82;

	private TextBox textBox34;

	private TextBox textBox35;

	private Label label79;

	private Label label80;

	private TextBox textBox32;

	private TextBox textBox33;

	private Label label77;

	private Label label78;

	private TextBox textBox30;

	private TextBox textBox31;

	private Label label75;

	private Label label76;

	private TextBox textBox28;

	private TextBox textBox29;

	private Label label73;

	private Label label74;

	private TextBox textBox26;

	private TextBox textBox27;

	private Label label71;

	private Label label72;

	private TextBox textBox24;

	private TextBox textBox25;

	private Label label69;

	private Label label70;

	private TextBox textBox22;

	private TextBox textBox23;

	private Label label67;

	private Label label68;

	private TextBox textBox20;

	private TextBox textBox21;

	private Label label65;

	private Label label66;

	private TextBox textBox18;

	private TextBox textBox19;

	private Label label63;

	private Label label64;

	private TextBox textBox16;

	private TextBox textBox17;

	private Label label61;

	private Label label62;

	private TextBox textBox14;

	private TextBox textBox15;

	private Label label60;

	private Label label56;

	private TextBox textBox10;

	private TextBox textBox11;

	private Label label57;

	private GroupBox groupBox1;

	private CheckBox checkBox15;

	private CheckBox checkBox16;

	private CheckBox checkBox17;

	private CheckBox checkBox18;

	private CheckBox checkBox19;

	private CheckBox checkBox20;

	private CheckBox checkBox21;

	private CheckBox checkBox22;

	private CheckBox checkBox23;

	private CheckBox checkBox13;

	private CheckBox checkBox24;

	private CheckBox checkBox14;

	private CheckBox checkBox10;

	private CheckBox checkBox12;

	private CheckBox checkBox11;

	private CheckBox checkBox7;

	private CheckBox checkBox8;

	private CheckBox checkBox9;

	private CheckBox checkBox4;

	private CheckBox checkBox5;

	private CheckBox checkBox6;

	private CheckBox checkBox3;

	private CheckBox checkBox2;

	private CheckBox checkBox1;

	private TabPage tabPage7;

	private ComboBox comboBox43;

	private Label label47;

	private ComboBox comboBox42;

	private Label label46;

	private TextBox textBox4;

	private Label label45;

	private TabPage tabPage6;

	private ComboBox comboBox28;

	private Label label1;

	private Label label28;

	private ComboBox comboBox29;

	private ComboBox comboBox1;

	private Label label29;

	private ComboBox comboBox10;

	private ComboBox comboBox27;

	private Label label27;

	private Label label8;

	private ComboBox comboBox8;

	private ComboBox comboBox25;

	private Label label25;

	private ComboBox comboBox26;

	private Label label26;

	private ComboBox comboBox23;

	private Label label23;

	private Label label9;

	private ComboBox comboBox9;

	private Label label10;

	private ComboBox comboBox24;

	private Label label24;

	private Label label14;

	private ComboBox comboBox12;

	private Label label12;

	private ComboBox comboBox14;

	private TabPage tabPage5;

	private Label label35;

	private ComboBox comboBox35;

	private Label label50;

	private ComboBox comboBox46;

	private ComboBox comboBox45;

	private Label label49;

	private ComboBox comboBox44;

	private Label label48;

	private ComboBox comboBox3;

	private ComboBox comboBox41;

	private Label label44;

	private ComboBox comboBox36;

	private Label label36;

	private ComboBox comboBox20;

	private Label label20;

	private Label label3;

	private ComboBox comboBox13;

	private Label label13;

	private ComboBox comboBox6;

	private ComboBox comboBox11;

	private Label label11;

	private Label label6;

	private Label label7;

	private ComboBox comboBox7;

	private Label label15;

	private ComboBox comboBox15;

	private TabPage tabPage4;

	private ComboBox comboBox37;

	private Label label37;

	private Label label38;

	private ComboBox comboBox38;

	private Label label39;

	private ComboBox comboBox40;

	private ComboBox comboBox39;

	private Label label40;

	private TabPage tabPage3;

	private Label label32;

	private ComboBox comboBox32;

	private Label label33;

	private ComboBox comboBox4;

	private Label label4;

	private ComboBox comboBox2;

	private Label label2;

	private ComboBox comboBox33;

	private Label label34;

	private ComboBox comboBox34;

	private TabPage tabPage2;

	private Label label17;

	private Label label16;

	private ComboBox comboBox16;

	private ComboBox comboBox17;

	private Label label18;

	private ComboBox comboBox18;

	private Label label19;

	private ComboBox comboBox19;

	private ComboBox comboBox5;

	private Label label5;

	private ComboBox comboBox21;

	private Label label21;

	private TabPage tabPage1;

	private TextBox txt_password;

	private TextBox textBox1;

	private TextBox textBox2;

	private TextBox textBox3;

	private Label lab_bootpassword;

	private Label label41;

	private Label label42;

	private Label label43;

	private ComboBox comboBox22;

	private Label lab_bootscreen;

	private ComboBox comboBox31;

	private Label label31;

	private TabControl tabControl1;

	private ComboBox comboBox30;

	private Label label30;

	private CheckBox checkBox25;

	private CheckBox checkBox26;

	private Label label109;

	private Label label110;

	private TextBox textBox60;

	private TextBox textBox61;

	private Label label107;

	private Label label108;

	private TextBox textBox58;

	private TextBox textBox59;

	private Button button9;

	private Button button10;

	private TextBox tb_picture_path;

	private Button button11;

	private Button button12;

	private ComboBox cmb_A_mode;

	private Label lab_A_mode;

	private DataGridView dgv_noaa_event;

	private Label lab_self_noaa_event;

	private ComboBox cmb_MwSw;

	private Label lab_MwSw;

	private ComboBox cmb_B_mode;

	private Label lab_B_mode;

	private ComboBox cmb_brightness;

	private Label lab_brightness;

	private Label lab_cw;

	private NumericUpDown Nud_cw;

	public genset()
	{
		InitializeComponent();
		Dgv_NoaaEventControlInit();
		textBox1.MaxLength = 12;
		textBox2.MaxLength = 15;
		textBox3.MaxLength = 15;
		checkbox_band_enable[0] = checkBox1;
		checkbox_band_enable[1] = checkBox2;
		checkbox_band_enable[2] = checkBox3;
		checkbox_band_enable[3] = checkBox6;
		checkbox_band_enable[4] = checkBox5;
		checkbox_band_enable[5] = checkBox4;
		checkbox_band_enable[6] = checkBox9;
		checkbox_band_enable[7] = checkBox8;
		checkbox_band_enable[8] = checkBox7;
		checkbox_band_enable[9] = checkBox12;
		checkbox_band_enable[10] = checkBox11;
		checkbox_band_enable[11] = checkBox10;
		checkbox_band_enable[12] = checkBox26;
		checkbox_band_tx_enable[0] = checkBox24;
		checkbox_band_tx_enable[1] = checkBox23;
		checkbox_band_tx_enable[2] = checkBox22;
		checkbox_band_tx_enable[3] = checkBox21;
		checkbox_band_tx_enable[4] = checkBox20;
		checkbox_band_tx_enable[5] = checkBox19;
		checkbox_band_tx_enable[6] = checkBox18;
		checkbox_band_tx_enable[7] = checkBox17;
		checkbox_band_tx_enable[8] = checkBox16;
		checkbox_band_tx_enable[9] = checkBox15;
		checkbox_band_tx_enable[10] = checkBox14;
		checkbox_band_tx_enable[11] = checkBox13;
		checkbox_band_tx_enable[12] = checkBox25;
		txtbox_rx_freq[0, 0] = textBox10;
		txtbox_rx_freq[0, 1] = textBox11;
		txtbox_rx_freq[1, 0] = textBox14;
		txtbox_rx_freq[1, 1] = textBox15;
		txtbox_rx_freq[2, 0] = textBox16;
		txtbox_rx_freq[2, 1] = textBox17;
		txtbox_rx_freq[3, 0] = textBox18;
		txtbox_rx_freq[3, 1] = textBox19;
		txtbox_rx_freq[4, 0] = textBox20;
		txtbox_rx_freq[4, 1] = textBox21;
		txtbox_rx_freq[5, 0] = textBox22;
		txtbox_rx_freq[5, 1] = textBox23;
		txtbox_rx_freq[6, 0] = textBox24;
		txtbox_rx_freq[6, 1] = textBox25;
		txtbox_rx_freq[7, 0] = textBox26;
		txtbox_rx_freq[7, 1] = textBox27;
		txtbox_rx_freq[8, 0] = textBox28;
		txtbox_rx_freq[8, 1] = textBox29;
		txtbox_rx_freq[9, 0] = textBox30;
		txtbox_rx_freq[9, 1] = textBox31;
		txtbox_rx_freq[10, 0] = textBox32;
		txtbox_rx_freq[10, 1] = textBox33;
		txtbox_rx_freq[11, 0] = textBox34;
		txtbox_rx_freq[11, 1] = textBox35;
		txtbox_rx_freq[12, 0] = textBox58;
		txtbox_rx_freq[12, 1] = textBox59;
		txtbox_tx_freq[0, 0] = textBox56;
		txtbox_tx_freq[0, 1] = textBox57;
		txtbox_tx_freq[1, 0] = textBox54;
		txtbox_tx_freq[1, 1] = textBox55;
		txtbox_tx_freq[2, 0] = textBox52;
		txtbox_tx_freq[2, 1] = textBox53;
		txtbox_tx_freq[3, 0] = textBox50;
		txtbox_tx_freq[3, 1] = textBox51;
		txtbox_tx_freq[4, 0] = textBox48;
		txtbox_tx_freq[4, 1] = textBox49;
		txtbox_tx_freq[5, 0] = textBox46;
		txtbox_tx_freq[5, 1] = textBox47;
		txtbox_tx_freq[6, 0] = textBox44;
		txtbox_tx_freq[6, 1] = textBox45;
		txtbox_tx_freq[7, 0] = textBox42;
		txtbox_tx_freq[7, 1] = textBox43;
		txtbox_tx_freq[8, 0] = textBox40;
		txtbox_tx_freq[8, 1] = textBox41;
		txtbox_tx_freq[9, 0] = textBox38;
		txtbox_tx_freq[9, 1] = textBox39;
		txtbox_tx_freq[10, 0] = textBox36;
		txtbox_tx_freq[10, 1] = textBox37;
		txtbox_tx_freq[11, 0] = textBox12;
		txtbox_tx_freq[11, 1] = textBox13;
		txtbox_tx_freq[12, 0] = textBox60;
		txtbox_tx_freq[12, 1] = textBox61;
		txtbox_selftone[0] = textBox5;
		txtbox_selftone[1] = textBox6;
		txtbox_selftone[2] = textBox7;
		txtbox_selftone[3] = textBox8;
		txtbox_selftone[4] = textBox9;
		btn_selftone[0] = button1;
		btn_selftone[1] = button2;
		btn_selftone[2] = button3;
		btn_selftone[3] = button4;
		btn_selftone[4] = button5;
		txt_password.MaxLength = 6;
		txt_password.PasswordChar = '*';
	}

	public void set_check_enable(bool enable)
	{
		for (int i = 0; i < checkbox_band_enable.Length; i++)
		{
			checkbox_band_enable[i].Enabled = enable;
			checkbox_band_tx_enable[i].Enabled = enable;
		}
	}

	public static string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	public void LoadComboBoxString(ComboBox cmb, List<string> list)
	{
		for (int i = 0; i < list.Count; i++)
		{
			cmb.Items.Add(list[i]);
		}
		cmb.DropDownStyle = ComboBoxStyle.DropDownList;
	}

	private void label9_Click(object sender, EventArgs e)
	{
	}

	private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	public void Dgv_NoaaEventControlInit()
	{
		DataGridView dataGridView = new DataGridView();
		dataGridView = dgv_noaa_event;
		main.DoubleBuffered(dataGridView);
		dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
		dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridView.RowHeadersVisible = false;
		dataGridView.AllowUserToAddRows = false;
		dataGridView.RowTemplate.Height = 20;
		for (int i = 0; i < 3; i++)
		{
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
			dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
		}
		dataGridView.Columns.Add(new DataGridViewCheckBoxColumn());
		dataGridView.Columns[0].Width = 50;
		dataGridView.Columns[1].Width = 100;
		dataGridView.Columns[2].Width = 200;
		dataGridView.Columns[0].HeaderText = GetLang("fm_no");
		dataGridView.Rows.Add(param_string.NOAA_SAME_EVENT_LIST.Length / 2);
		for (int i = 0; i < param_string.NOAA_SAME_EVENT_LIST.Length / 2; i++)
		{
			dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
			dataGridView.Rows[i].Cells[1].Value = param_string.NOAA_SAME_EVENT_LIST[i * 2];
			dataGridView.Rows[i].Cells[2].Value = param_string.NOAA_SAME_EVENT_LIST[i * 2 + 1];
			dataGridView.Rows[i].Cells[0].ReadOnly = true;
			dataGridView.Rows[i].Cells[1].ReadOnly = true;
			dataGridView.Rows[i].Cells[2].ReadOnly = true;
			dataGridView.Rows[i].Cells[3].ReadOnly = false;
		}
	}

	private void genset_Load(object sender, EventArgs e)
	{
		btn_ok.Text = GetLang("OK");
		btn_cancel.Text = GetLang("cancel");
		base.Icon = Resources.标题;
		tb_picture_path.Text = Iparse.getchart("path", "pictrue");
		if (main.gEngineerMode)
		{
			groupBox1.Enabled = true;
			groupBox2.Enabled = true;
			groupBox3.Enabled = true;
		}
		else
		{
			groupBox1.Enabled = false;
			groupBox2.Enabled = false;
			groupBox3.Enabled = false;
		}
		LoadTableLang();
		LoadComboBoxLang();
		LoadParam();
	}

	public static GEN_INFO InitStructInfo()
	{
		GEN_INFO result = default(GEN_INFO);
		result.auto_lock = GetLang("off");
		result.backlight = "5";
		result.beep = GetLang("on");
		result.call_chn = GetLang("_null");
		result.chn_A_volume = "A_100%-B_100%";
		result.chn_B_volume = "3";
		result.chn_disp_mode = GetLang("gen_disp_freq");
		result.chn_AB = "A";
		result.denoise = GetLang("off");
		result.dual_watch = GetLang("off");
		result.key_lock = GetLang("unlock");
		result.key_long1 = GetLang("_null");
		result.key_long2 = GetLang("_null");
		result.key_short1 = GetLang("_null");
		result.key_short2 = GetLang("_null");
		result.key_tone = GetLang("on");
		result.lang = GetLang("gen_lang_CN");
		result.match_dcs_bit = GetLang("gen_23bit");
		result.match_mode = GetLang("gen_normal");
		result.match_threshold = "100";
		result.match_tot = "8";
		result.mic = "2";
		result.noaa_scan = GetLang("gen_manual_search");
		result.power_save = "1:4";
		result.pwron_disp = GetLang("gen_fullscreen");
		result.repeater_tail = GetLang("off");
		result.same_addr = GetLang("gen_mul_addr");
		result.same_decode = GetLang("gen_same_decode");
		result.same_event = GetLang("gen_all_off");
		result.sbar = GetLang("off");
		result.scan_mode = GetLang("gen_to");
		result.signal = GetLang("gen_dtmf");
		result.Noaa_sq = "4";
		result.tail_tone = GetLang("on");
		result.talk_tail = GetLang("off");
		result.tot = "3";
		result.transpositional = GetLang("off");
		result.tx_chn = GetLang("off");
		result.FreqModeFlag = GetLang("on");
		result.MwSw = GetLang("on");
		result.vox = GetLang("off");
		result.alarm = GetLang("gen_remote_alarm");
		result.fm_chn_idx = "1";
		result.fm_mode = GetLang("gen_mode_freq");
		result.fm_vfo_freq = "87.0";
		result.device_name = GetLang("model");
		result.logo_1 = "welcome";
		result.logo_2 = GetLang("model");
		result.kill = GetLang("on");
		result.side_tone = GetLang("on");
		result.dtmf_decode_rspn = GetLang("off");
		result.A_vfo_mr_mode = "A-F09";
		result.B_vfo_mr_mode = "B-F09";
		result.brightness = "8";
		result.CwPitchFreq = 400m;
		int num = 13;
		result.band_tx_enable = new bool[num];
		result.band_enable = new bool[num];
		result.self_tone_enable = false;
		result.rx_start = new string[num];
		result.rx_end = new string[num];
		result.tx_start = new string[num];
		result.tx_end = new string[num];
		result.self_tone_path = new string[5];
		for (int i = 0; i < num; i++)
		{
			result.band_enable[i] = true;
			result.band_tx_enable[i] = true;
			result.rx_start[i] = param_string.freq_rang[i * 2].ToString("0.00000");
			result.rx_end[i] = param_string.freq_rang[i * 2 + 1].ToString("0.00000");
			result.tx_start[i] = result.rx_start[i];
			result.tx_end[i] = result.rx_end[i];
		}
		result.band_tx_enable[0] = false;
		result.band_tx_enable[1] = false;
		result.band_tx_enable[4] = false;
		result.band_tx_enable[10] = false;
		result.band_tx_enable[11] = false;
		result.band_tx_enable[12] = false;
		result.picture = false;
		result.self_noaa_event = new bool[param_string.NOAA_SAME_EVENT_LIST.Length / 2];
		return result;
	}

	public void LoadParam()
	{
		GEN_INFO gEN_INFO = main.GenInfo;
		if (string.IsNullOrEmpty(gEN_INFO.auto_lock))
		{
			gEN_INFO = InitStructInfo();
		}
		textBox1.Text = gEN_INFO.device_name;
		textBox2.Text = gEN_INFO.logo_1;
		textBox3.Text = gEN_INFO.logo_2;
		comboBox1.Text = gEN_INFO.chn_AB;
		comboBox2.Text = gEN_INFO.Noaa_sq;
		comboBox3.Text = gEN_INFO.tot;
		comboBox4.Text = gEN_INFO.noaa_scan;
		comboBox5.Text = gEN_INFO.key_lock;
		comboBox6.Text = gEN_INFO.vox;
		comboBox7.Text = gEN_INFO.mic;
		comboBox15.Text = gEN_INFO.beep;
		comboBox21.Text = gEN_INFO.auto_lock;
		comboBox24.Text = gEN_INFO.repeater_tail;
		comboBox26.Text = gEN_INFO.denoise;
		comboBox28.Text = gEN_INFO.chn_A_volume;
		comboBox30.Text = gEN_INFO.key_tone;
		comboBox22.Text = gEN_INFO.pwron_disp;
		comboBox8.Text = gEN_INFO.FreqModeFlag;
		comboBox9.Text = gEN_INFO.chn_disp_mode;
		comboBox10.Text = gEN_INFO.tx_chn;
		comboBox11.Text = gEN_INFO.power_save;
		comboBox12.Text = gEN_INFO.dual_watch;
		comboBox13.Text = gEN_INFO.backlight;
		comboBox14.Text = gEN_INFO.call_chn;
		comboBox20.Text = gEN_INFO.scan_mode;
		comboBox23.Text = gEN_INFO.talk_tail;
		comboBox25.Text = gEN_INFO.tail_tone;
		comboBox27.Text = gEN_INFO.transpositional;
		comboBox29.Text = gEN_INFO.chn_B_volume;
		comboBox31.Text = gEN_INFO.lang;
		comboBox41.Text = gEN_INFO.alarm;
		comboBox16.Text = gEN_INFO.key_short1;
		comboBox17.Text = gEN_INFO.key_long1;
		comboBox18.Text = gEN_INFO.key_short2;
		comboBox19.Text = gEN_INFO.key_long2;
		comboBox32.Text = gEN_INFO.same_decode;
		comboBox33.Text = gEN_INFO.same_event;
		comboBox34.Text = gEN_INFO.same_addr;
		comboBox35.Text = gEN_INFO.sbar;
		comboBox36.Text = gEN_INFO.signal;
		comboBox37.Text = gEN_INFO.match_tot;
		comboBox38.Text = gEN_INFO.match_mode;
		comboBox39.Text = gEN_INFO.match_dcs_bit;
		comboBox40.Text = gEN_INFO.match_threshold;
		textBox4.Text = gEN_INFO.fm_vfo_freq;
		comboBox42.Text = gEN_INFO.fm_mode;
		comboBox43.Text = gEN_INFO.fm_chn_idx;
		comboBox44.Text = gEN_INFO.kill;
		comboBox45.Text = gEN_INFO.side_tone;
		comboBox46.Text = gEN_INFO.dtmf_decode_rspn;
		cmb_A_mode.Text = gEN_INFO.A_vfo_mr_mode;
		cmb_B_mode.Text = gEN_INFO.B_vfo_mr_mode;
		cmb_MwSw.Text = gEN_INFO.MwSw;
		cmb_brightness.Text = gEN_INFO.brightness;
		Nud_cw.Value = gEN_INFO.CwPitchFreq;
		for (int i = 0; i < 13; i++)
		{
			checkbox_band_enable[i].Checked = gEN_INFO.band_enable[i];
			checkbox_band_tx_enable[i].Checked = gEN_INFO.band_tx_enable[i];
			txtbox_rx_freq[i, 0].Text = gEN_INFO.rx_start[i];
			txtbox_rx_freq[i, 1].Text = gEN_INFO.rx_end[i];
			txtbox_tx_freq[i, 0].Text = gEN_INFO.tx_start[i];
			txtbox_tx_freq[i, 1].Text = gEN_INFO.tx_end[i];
		}
		for (int i = 0; i < 5; i++)
		{
			txtbox_selftone[i].Text = gEN_INFO.self_tone_path[i];
		}
		checkBox_picture.Checked = gEN_INFO.picture;
		checkBox_selftone.Checked = gEN_INFO.self_tone_enable;
		groupBox4.Enabled = gEN_INFO.self_tone_enable;
		groupBox5.Enabled = gEN_INFO.picture;
		txt_password.Text = gEN_INFO.pass_word;
		for (int i = 0; i < param_string.NOAA_SAME_EVENT_LIST.Length / 2; i++)
		{
			dgv_noaa_event.Rows[i].Cells[3].Value = gEN_INFO.self_noaa_event[i];
		}
	}

	public void LoadComboBoxLang()
	{
		LoadComboBoxString(comboBox1, param_string.gen_main_chn_Items());
		LoadComboBoxString(comboBox2, param_string.gen_sq_Items());
		LoadComboBoxString(comboBox3, param_string.gen_tot_Items());
		LoadComboBoxString(comboBox4, param_string.gen_noaa_scan_Items());
		LoadComboBoxString(comboBox5, param_string.gen_keylock_Items());
		LoadComboBoxString(comboBox6, param_string.gen_vox_Items());
		LoadComboBoxString(comboBox7, param_string.gen_mic_Items());
		LoadComboBoxString(comboBox15, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox21, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox24, param_string.gen_repeater_tail_Items());
		LoadComboBoxString(comboBox26, param_string.gen_denoise_Items());
		LoadComboBoxString(comboBox28, param_string.gen_chn_volume_Items());
		LoadComboBoxString(comboBox30, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox22, param_string.gen_pwron_disp_Items());
		LoadComboBoxString(comboBox8, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox9, param_string.gen_chn_disp_Items());
		LoadComboBoxString(comboBox10, param_string.gen_tx_chn_Items());
		LoadComboBoxString(comboBox11, param_string.gen_power_save_Items());
		LoadComboBoxString(comboBox12, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox13, param_string.gen_autobacklight_Items());
		LoadComboBoxString(comboBox14, param_string.GetChannelName_Items());
		LoadComboBoxString(comboBox20, param_string.gen_scan_mode_Items());
		LoadComboBoxString(comboBox23, param_string.gen_talk_tail_Items());
		LoadComboBoxString(comboBox25, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox27, param_string.gen_transpositional_Items());
		LoadComboBoxString(comboBox29, param_string.gen_chn_volume_Items());
		LoadComboBoxString(comboBox31, param_string.gen_lang_Items());
		LoadComboBoxString(comboBox16, param_string.gen_sidekey_Items());
		LoadComboBoxString(comboBox17, param_string.gen_sidekey_Items());
		LoadComboBoxString(comboBox18, param_string.gen_sidekey_Items());
		LoadComboBoxString(comboBox19, param_string.gen_sidekey_Items());
		LoadComboBoxString(comboBox32, param_string.gen_noaa_decode_Items());
		LoadComboBoxString(comboBox33, param_string.gen_SAME_event_Items());
		LoadComboBoxString(comboBox34, param_string.gen_SAME_address_Items());
		LoadComboBoxString(comboBox35, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox36, param_string.gen_signal_Items());
		LoadComboBoxString(comboBox37, param_string.gen_match_tot_Items());
		LoadComboBoxString(comboBox38, param_string.gen_match_mode_Items());
		LoadComboBoxString(comboBox39, param_string.gen_match_dcs_bit_Items());
		LoadComboBoxString(comboBox40, param_string.gen_match_threshold_Items());
		LoadComboBoxString(comboBox41, param_string.gen_alarm_Items());
		LoadComboBoxString(comboBox42, param_string.gen_fm_mode_Items());
		LoadComboBoxString(comboBox43, param_string.gen_fm_chn_idx_Items());
		LoadComboBoxString(comboBox44, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox45, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox46, param_string.dtmf_rsp_Items());
		LoadComboBoxString(cmb_A_mode, param_string.gen_main_A_MR_VFO_Items());
		LoadComboBoxString(cmb_B_mode, param_string.gen_main_B_MR_VFO_Items());
		LoadComboBoxString(cmb_MwSw, param_string.chn_on_off_Items());
		LoadComboBoxString(cmb_brightness, param_string.GetGen_Brightness_Items());
	}

	public void LoadTableLang()
	{
		lab_MwSw.Text = GetLang("MwSwAgc");
		label57.Text = GetLang("VFO_RxRang");
		label105.Text = GetLang("VFO_TxRang");
		label41.Text = GetLang("gen_device_name");
		label1.Text = GetLang("gen_main_chn");
		label2.Text = GetLang("gen_sq");
		label3.Text = GetLang("gen_tot");
		label4.Text = GetLang("gen_NOAA_scan");
		label5.Text = GetLang("gen_keylock");
		label6.Text = GetLang("gen_vox");
		label7.Text = GetLang("gen_mic");
		label15.Text = GetLang("gen_beep");
		label21.Text = GetLang("gen_autolock");
		label24.Text = GetLang("gen_repeater_tail_tone");
		label26.Text = GetLang("gen_denoise");
		lab_cw.Text = GetLang("CW_PitchFrequency");
		label28.Text = GetLang("gen_volumeA");
		label30.Text = GetLang("gen_keytone");
		label30.Text = GetLang("gen_keytone");
		label42.Text = GetLang("gen_logo1");
		label8.Text = GetLang("gen_vfo_mode");
		label9.Text = GetLang("gen_channel_mode");
		label10.Text = GetLang("gen_tx_chan");
		label11.Text = GetLang("gen_pwron");
		label12.Text = GetLang("gen_dual_watch");
		label13.Text = GetLang("gen_backlight");
		label14.Text = GetLang("gen_call_channel");
		label20.Text = GetLang("gen_scan_mode");
		label23.Text = GetLang("gen_end_talk");
		label27.Text = GetLang("gen_transpositional");
		label29.Text = GetLang("gen_volumeB");
		label31.Text = GetLang("gen_lang");
		lab_brightness.Text = GetLang("brightness");
		label43.Text = GetLang("gen_logo2");
		label16.Text = GetLang("gen_short1");
		label17.Text = GetLang("gen_long1");
		label18.Text = GetLang("gen_short2");
		label19.Text = GetLang("gen_long2");
		label32.Text = GetLang("gen_NOAA_decode");
		label33.Text = GetLang("gen_NOAA_EVENT");
		label34.Text = GetLang("gen_NOAA_ADDR");
		label35.Text = GetLang("gen_sbar");
		label36.Text = GetLang("gen_signal");
		label37.Text = GetLang("gen_freq_meter_tot");
		label38.Text = GetLang("gen_freq_meter_mode");
		label40.Text = GetLang("gen_threshold");
		label44.Text = GetLang("gen_alarm");
		label45.Text = GetLang("gen_fm_vfo_freq");
		label47.Text = GetLang("gen_fm_channel");
		label46.Text = GetLang("gen_fm_mode");
		label48.Text = GetLang("dtmf_kill");
		label49.Text = GetLang("dtmf_tone");
		label50.Text = GetLang("dtmf_rsp");
		lab_A_mode.Text = GetLang("gen_vfo_mr");
		lab_self_noaa_event.Text = GetLang("gen_self_noaa_event_ctrl");
		tabControl1.TabPages[0].Text = GetLang("gen_title_pwron");
		tabControl1.TabPages[1].Text = GetLang("gen_title_buttun");
		tabControl1.TabPages[2].Text = GetLang("gen_title_NoaaSame");
		tabControl1.TabPages[3].Text = GetLang("gen_title_match");
		tabControl1.TabPages[4].Text = GetLang("gen_title_generl");
		tabControl1.TabPages[5].Text = GetLang("gen_title_chn");
		tabControl1.TabPages[6].Text = GetLang("gen_title_fm");
		tabControl1.TabPages[7].Text = GetLang("vfo_band_set");
		tabControl1.TabPages[8].Text = GetLang("self_tone");
		tabControl1.TabPages[9].Text = GetLang("pictrue");
		label39.Text = GetLang("dcs");
		label25.Text = GetLang("tailtone");
		button1.Text = GetLang("path");
		button2.Text = GetLang("path");
		button3.Text = GetLang("path");
		button4.Text = GetLang("path");
		button5.Text = GetLang("path");
		button8.Text = GetLang("path");
		button12.Text = GetLang("path");
		button9.Text = GetLang("write");
		button11.Text = GetLang("write");
		button10.Text = GetLang("read");
		checkBox_selftone.Text = GetLang("writer_enable");
		checkBox_picture.Text = GetLang("writer_enable");
		for (int i = 0; i < 13; i++)
		{
			string text = "band" + (i + 1) + GetLang("band_enable");
			checkbox_band_enable[i].Text = text;
			text = "band" + (i + 1) + GetLang("band_tx_enable");
			checkbox_band_tx_enable[i].Text = text;
		}
		lab_A_mode.Text = GetLang("band_A_disp");
		lab_B_mode.Text = GetLang("band_B_disp");
		lab_bootscreen.Text = GetLang("gen_boot_screen");
		lab_bootpassword.Text = GetLang("gen_boot_password");
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		int num = 0;
		int num2 = 15;
		TextBox textBox = sender as TextBox;
		if (sender == textBox1)
		{
			num2 = 12;
		}
		string text = textBox.Text;
		if (e.KeyChar != '\b')
		{
			for (int i = 0; i < text.Length; i++)
			{
				num = ((text[i] < '一' || text[i] > '龥') ? (num + 1) : (num + 2));
			}
			num = ((e.KeyChar < '一' || e.KeyChar > '龥') ? (num + 1) : (num + 2));
			if (num > num2)
			{
				e.Handled = true;
			}
		}
	}

	private void button7_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(txt_password.Text) && txt_password.TextLength != 6)
		{
			MessageBox.Show(GetLang("power_on_passwrod_length"));
			return;
		}
		SaveParam();
		Close();
	}

	private void button6_Click(object sender, EventArgs e)
	{
		Close();
	}

	public void SaveParam()
	{
		GEN_INFO genInfo = main.GenInfo;
		genInfo.self_tone_path = new string[5];
		int num = 13;
		genInfo.band_tx_enable = new bool[num];
		genInfo.band_enable = new bool[num];
		genInfo.rx_start = new string[num];
		genInfo.rx_end = new string[num];
		genInfo.tx_start = new string[num];
		genInfo.tx_end = new string[num];
		genInfo.device_name = textBox1.Text;
		genInfo.logo_1 = textBox2.Text;
		genInfo.logo_2 = textBox3.Text;
		genInfo.chn_AB = comboBox1.Text;
		genInfo.Noaa_sq = comboBox2.Text;
		genInfo.tot = comboBox3.Text;
		genInfo.noaa_scan = comboBox4.Text;
		genInfo.key_lock = comboBox5.Text;
		genInfo.vox = comboBox6.Text;
		genInfo.mic = comboBox7.Text;
		genInfo.beep = comboBox15.Text;
		genInfo.auto_lock = comboBox21.Text;
		genInfo.repeater_tail = comboBox24.Text;
		genInfo.denoise = comboBox26.Text;
		genInfo.chn_A_volume = comboBox28.Text;
		genInfo.key_tone = comboBox30.Text;
		genInfo.pwron_disp = comboBox22.Text;
		genInfo.FreqModeFlag = comboBox8.Text;
		genInfo.chn_disp_mode = comboBox9.Text;
		genInfo.tx_chn = comboBox10.Text;
		genInfo.power_save = comboBox11.Text;
		genInfo.dual_watch = comboBox12.Text;
		genInfo.backlight = comboBox13.Text;
		genInfo.call_chn = comboBox14.Text;
		genInfo.scan_mode = comboBox20.Text;
		genInfo.talk_tail = comboBox23.Text;
		genInfo.tail_tone = comboBox25.Text;
		genInfo.transpositional = comboBox27.Text;
		genInfo.chn_B_volume = comboBox29.Text;
		genInfo.lang = comboBox31.Text;
		genInfo.alarm = comboBox41.Text;
		genInfo.key_short1 = comboBox16.Text;
		genInfo.key_long1 = comboBox17.Text;
		genInfo.key_short2 = comboBox18.Text;
		genInfo.key_long2 = comboBox19.Text;
		genInfo.same_decode = comboBox32.Text;
		genInfo.same_event = comboBox33.Text;
		genInfo.same_addr = comboBox34.Text;
		genInfo.sbar = comboBox35.Text;
		genInfo.signal = comboBox36.Text;
		genInfo.match_tot = comboBox37.Text;
		genInfo.match_mode = comboBox38.Text;
		genInfo.match_dcs_bit = comboBox39.Text;
		genInfo.match_threshold = comboBox40.Text;
		genInfo.brightness = cmb_brightness.Text;
		genInfo.fm_vfo_freq = textBox4.Text;
		genInfo.fm_mode = comboBox42.Text;
		genInfo.fm_chn_idx = comboBox43.Text;
		genInfo.kill = comboBox44.Text;
		genInfo.side_tone = comboBox45.Text;
		genInfo.dtmf_decode_rspn = comboBox46.Text;
		genInfo.A_vfo_mr_mode = cmb_A_mode.Text;
		genInfo.B_vfo_mr_mode = cmb_B_mode.Text;
		genInfo.CwPitchFreq = CalCwFreq(Nud_cw.Value);
		genInfo.MwSw = cmb_MwSw.Text;
		for (int i = 0; i < 13; i++)
		{
			genInfo.band_enable[i] = checkbox_band_enable[i].Checked;
			genInfo.band_tx_enable[i] = checkbox_band_tx_enable[i].Checked;
			genInfo.rx_start[i] = txtbox_rx_freq[i, 0].Text;
			genInfo.rx_end[i] = txtbox_rx_freq[i, 1].Text;
			genInfo.tx_start[i] = txtbox_tx_freq[i, 0].Text;
			genInfo.tx_end[i] = txtbox_tx_freq[i, 1].Text;
		}
		main.CpsTailToneInfo = new CPS_USER_TAIL_TONE_INFO[5];
		genInfo.self_tone_enable = checkBox_selftone.Checked;
		byte[] array = null;
		if (genInfo.self_tone_enable)
		{
			for (int i = 0; i < 5; i++)
			{
				if (!File.Exists(txtbox_selftone[i].Text))
				{
					continue;
				}
				genInfo.self_tone_path[i] = txtbox_selftone[i].Text;
				main.CpsTailToneInfo[i].pcm_data = new byte[16376];
				if (string.IsNullOrEmpty(txtbox_selftone[i].Text))
				{
					continue;
				}
				main.CpsTailToneInfo[i].flag = 305420890u;
				FileStream fileStream = File.OpenRead(txtbox_selftone[i].Text);
				array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				string text = txtbox_selftone[i].Text;
				byte[] array2 = new byte[4];
				Array.Copy(array, 0, array2, 0, 4);
				string text2 = Iparse.ConvertByteToString(array2, "utf8");
				if (text2 == "RIFF")
				{
					main.CpsTailToneInfo[i].voice_type = 0;
					using WaveFileReader waveFileReader = new WaveFileReader(text);
					double num2 = ((TimeSpan)waveFileReader.TotalTime).TotalMilliseconds / 100.0;
					main.CpsTailToneInfo[i].timer = (byte)Math.Round(num2, MidpointRounding.AwayFromZero);
					array = wavtobyte(txtbox_selftone[i].Text);
				}
				else
				{
					main.CpsTailToneInfo[i].voice_type = 1;
					using Mp3FileReader mp3FileReader = new Mp3FileReader(text);
					double num2 = ((TimeSpan)mp3FileReader.TotalTime).TotalMilliseconds / 100.0;
					main.CpsTailToneInfo[i].timer = (byte)Math.Round(num2, MidpointRounding.AwayFromZero);
				}
				main.CpsTailToneInfo[i].lenght = (ushort)array.Length;
				Array.Copy(array, 0, main.CpsTailToneInfo[i].pcm_data, 0, array.Length);
			}
		}
		genInfo.picture = checkBox_picture.Checked;
		genInfo.pass_word = txt_password.Text;
		genInfo.self_noaa_event = new bool[param_string.NOAA_SAME_EVENT_LIST.Length / 2];
		for (int i = 0; i < param_string.NOAA_SAME_EVENT_LIST.Length / 2; i++)
		{
			genInfo.self_noaa_event[i] = (bool)dgv_noaa_event.Rows[i].Cells[3].Value;
		}
		main.GenInfo = genInfo;
	}

	public decimal CalCwFreq(decimal freq)
	{
		decimal num = freq % 10m;
		int num2 = (int)(freq / 10m);
		return ((num == 0m) ? num2 : (num2 + 1)) * 10;
	}

	private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void comboBox37_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Button button = sender as Button;
		int num = 0;
		for (num = 0; num < txtbox_selftone.Length && button != btn_selftone[num]; num++)
		{
		}
		openFileDialog1.Filter = "(*.wav,*.mp3)|*.wav;*.mp3";
		if (openFileDialog1.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		string text = openFileDialog1.FileName.ToString();
		FileStream fileStream = File.OpenRead(text);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		byte[] array2 = new byte[4];
		Array.Copy(array, 0, array2, 0, 4);
		string text2 = Iparse.ConvertByteToString(array2, "utf8");
		if (text2 == "RIFF")
		{
			using WaveFileReader waveFileReader = new WaveFileReader(text);
			if (((Stream)(object)waveFileReader).Length > 16000)
			{
				MessageBox.Show(GetLang("wave_file_size_too_large"));
				return;
			}
		}
		else
		{
			using Mp3FileReader mp3FileReader = new Mp3FileReader(text);
			double totalSeconds = ((TimeSpan)mp3FileReader.TotalTime).TotalSeconds;
			if (((Stream)(object)mp3FileReader).Length > 16000)
			{
				MessageBox.Show(GetLang("wave_file_size_too_large"));
				return;
			}
		}
		txtbox_selftone[num].Text = text;
	}

	public byte[] wavtobyte(string path)
	{
		byte[] array = null;
		using (WaveFileReader waveFileReader = new WaveFileReader(path))
		{
			WaveFormat waveFormat = waveFileReader.WaveFormat;
			if (waveFormat.SampleRate != 8000 || waveFormat.BitsPerSample != 16 || waveFormat.Channels != 1)
			{
				WaveFormat waveFormat2 = new WaveFormat(8000, 16, 1);
				path = Application.StartupPath + "\\tmp.wav";
				WaveFileWriter.CreateWaveFile(path, waveFileReader);
				using WaveFileReader waveFileReader2 = new WaveFileReader(path);
				array = new byte[((Stream)(object)waveFileReader).Length];
				((Stream)(object)waveFileReader2).Read(array, 0, array.Length);
			}
			else
			{
				array = new byte[((Stream)(object)waveFileReader).Length];
				((Stream)(object)waveFileReader).Read(array, 0, array.Length);
			}
		}
		return array;
	}

	private void checkBox25_CheckedChanged(object sender, EventArgs e)
	{
		groupBox4.Enabled = checkBox_selftone.Checked;
	}

	private void checkBox30_CheckedChanged(object sender, EventArgs e)
	{
		groupBox5.Enabled = checkBox_picture.Checked;
	}

	public void Convert1bppBmp(string path)
	{
		Bitmap bitmap = new Bitmap(path);
		Bitmap bitmap2 = null;
		if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
		{
			bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format32bppArgb);
			bitmap2.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
			using Graphics graphics = Graphics.FromImage(bitmap2);
			graphics.DrawImageUnscaled(bitmap, 0, 0);
		}
		else
		{
			bitmap2 = bitmap;
		}
		BitmapData bitmapData = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		int num = bitmapData.Stride * bitmapData.Height;
		byte[] array = new byte[num];
		Marshal.Copy(bitmapData.Scan0, array, 0, num);
		bitmap2.UnlockBits(bitmapData);
		Bitmap bitmap3 = new Bitmap(bitmap2.Width, bitmap2.Height, PixelFormat.Format1bppIndexed);
		BitmapData bitmapData2 = bitmap3.LockBits(new Rectangle(0, 0, bitmap3.Width, bitmap3.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
		num = bitmapData2.Stride * bitmapData2.Height;
		byte[] array2 = new byte[num];
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		byte b = 0;
		int num5 = 128;
		int num6 = bitmap2.Height;
		int num7 = bitmap2.Width;
		int num8 = 500;
		for (int i = 0; i < num6; i++)
		{
			num2 = i * bitmapData.Stride;
			num3 = i * bitmapData2.Stride;
			b = 0;
			num5 = 128;
			for (int j = 0; j < num7; j++)
			{
				num4 = array[num2 + 1] + array[num2 + 2] + array[num2 + 3];
				if (num4 > num8)
				{
					b += (byte)num5;
				}
				if (num5 == 1)
				{
					array2[num3] = b;
					num3++;
					b = 0;
					num5 = 128;
				}
				else
				{
					num5 >>= 1;
				}
				num2 += 4;
			}
			if (num5 != 128)
			{
				array2[num3] = b;
			}
		}
		Marshal.Copy(array2, 0, bitmapData2.Scan0, num);
		bitmap3.UnlockBits(bitmapData2);
		if (bitmap2 != bitmap)
		{
			bitmap2.Dispose();
		}
		bitmap.Dispose();
		pictureBox1.Load(path);
		bitmap3.Save("tmp.bmp", ImageFormat.Bmp);
	}

	private void button8_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "(*.bmp,*.PNG,*.JPG)|*.bmp;*.jpg;*.png;";
		openFileDialog.ValidateNames = true;
		openFileDialog.CheckPathExists = true;
		openFileDialog.CheckFileExists = true;
		openFileDialog.Multiselect = false;
		main.CpsPictureInfo = default(CPS_PICTURE_INFO);
		main.CpsPictureInfo.bmp_data = new byte[1024];
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		pictrue_path = openFileDialog.FileNames[0];
		Bitmap bitmap = new Bitmap(pictrue_path);
		if (bitmap.Height != 64 || bitmap.Width != 128)
		{
			MessageBox.Show(GetLang("bmp_only128X64"));
			return;
		}
		bitmap.Dispose();
		Convert1bppBmp(pictrue_path);
		byte[] array = Bmptobin(Application.StartupPath + "\\tmp.bmp");
		if (array != null)
		{
			pictureBox1.Load(Application.StartupPath + "\\tmp.bmp");
			main.CpsPictureInfo.flag = 2596035162u;
			main.CpsPictureInfo.lenght = (ushort)array.Length;
			Array.Copy(array, 0, main.CpsPictureInfo.bmp_data, 0, array.Length);
		}
		else
		{
			MessageBox.Show(GetLang("bmp_only128X64"));
		}
	}

	public byte[] Bmptobin(string path)
	{
		int num = 0;
		FileStream fileStream = File.OpenRead(path);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		Bitmap bitmap = new Bitmap(path);
		bool flag = false;
		Color[] entries = bitmap.Palette.Entries;
		if (entries[0].ToArgb() == Color.Black.ToArgb() && entries[1].ToArgb() == Color.White.ToArgb())
		{
			flag = true;
		}
		byte[] array2 = new byte[Iparse.GetStructSizeof(bmpfilehead)];
		num = array2.Length;
		Array.Copy(array, array2, array2.Length);
		bmpfilehead = (BITMAPFILEHEADER)Iparse.ByteToStruct(array2, bmpfilehead.GetType());
		array2 = new byte[Iparse.GetStructSizeof(bmpinfohead)];
		num += array2.Length;
		Array.Copy(array, Iparse.GetStructSizeof(bmpfilehead), array2, 0, array2.Length);
		bmpinfohead = (BITMAPINFOHEADER)Iparse.ByteToStruct(array2, bmpinfohead.GetType());
		int num2 = 0;
		num = (int)(bmpinfohead.biBitCount * bmpinfohead.biWidth + 31) / 32 * 4;
		array2 = new byte[num * bmpinfohead.biHeight];
		byte[] array3 = new byte[array2.Length];
		Array.Copy(array, bmpfilehead.bfOffBits, array3, 0L, array3.Length);
		int num3 = 0;
		if (bmpinfohead.biBitCount == 16)
		{
			return null;
		}
		for (int i = 0; i < (int)bmpinfohead.biHeight; i++)
		{
			num3 = num * i;
			for (int j = 0; j < num; j++)
			{
				array2[num2++] = array3[num3++];
			}
		}
		if (flag)
		{
			for (num3 = 0; num3 < array2.Length; num3++)
			{
				array2[num3] ^= byte.MaxValue;
			}
		}
		return array2;
	}

	private void tabPage6_Click(object sender, EventArgs e)
	{
	}

	private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private void button9_Click(object sender, EventArgs e)
	{
		if (checkBox_picture.Checked && main.CpsPictureInfo.flag == 2596035162u)
		{
			byte[] array = Iparse.StructToBytes(main.CpsPictureInfo, Iparse.GetStructSizeof(main.CpsPictureInfo));
			byte[] array2 = new byte[1280];
			Array.Copy(array, 0, array2, 0, array.Length);
			WritePicture(array2);
		}
		else
		{
			MessageBox.Show(GetLang("write_fail"));
		}
	}

	public void WritePicture(byte[] buf)
	{
		if (!ComPort.Instance.Open())
		{
			return;
		}
		if (!protocol_struct.Link(5))
		{
			MessageBox.Show(GetLang("write_fail"));
		}
		else
		{
			if (protocol_struct.Model != main.ModelVersion)
			{
				MessageBox.Show(GetLang("model_error"));
				return;
			}
			if (CpsWritePicture(buf))
			{
				MessageBox.Show(GetLang("write_success"));
			}
			else
			{
				MessageBox.Show(GetLang("write_fail"));
			}
		}
		ComPort.Instance.Close();
	}

	public bool CpsWritePicture(byte[] buf)
	{
		bool result = true;
		int num = 876544;
		try
		{
			num = 876544;
			for (int i = 0; i < 5; i++)
			{
				byte[] array = new byte[256];
				Array.Copy(buf, i * 256, array, 0, array.Length);
				result = protocol_struct.Write(num, array, (ushort)array.Length);
				num += array.Length;
			}
		}
		catch (Exception)
		{
			result = false;
			MessageBox.Show(GetLang("read_err_fm"));
		}
		return result;
	}

	private void button11_Click(object sender, EventArgs e)
	{
		try
		{
			FileStream fileStream = File.OpenRead(tb_picture_path.Text);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			WritePicture(array);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	private void button10_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		string text = Iparse.getchart("path", "pictrue");
		if (!Directory.Exists(text))
		{
			text = Application.StartupPath;
		}
		saveFileDialog.FileName = "pictrue";
		saveFileDialog.Filter = "(*.dat)|*.dat";
		saveFileDialog.InitialDirectory = text;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			text = saveFileDialog.FileName.ToString();
			Iparse.setchart("path", "pictrue", text);
			byte[] array = ReadPictrue();
			if (array != null)
			{
				FileStream fileStream = new FileStream(text, FileMode.OpenOrCreate);
				fileStream.SetLength(0L);
				BinaryWriter binaryWriter = new BinaryWriter(fileStream, Encoding.Default);
				binaryWriter.Write(array);
				binaryWriter.Close();
				MessageBox.Show(GetLang("read_success"));
			}
			else
			{
				MessageBox.Show(GetLang("read_fail"));
			}
		}
	}

	public byte[] ReadPictrue()
	{
		byte[] array = new byte[1280];
		if (!ComPort.Instance.Open())
		{
			return null;
		}
		if (!protocol_struct.Link(5))
		{
			return null;
		}
		if (protocol_struct.Model != main.ModelVersion)
		{
			MessageBox.Show(GetLang("model_error"));
			return null;
		}
		int num = 876544;
		try
		{
			for (int i = 0; i < 5; i++)
			{
				byte[] sourceArray = protocol_struct.Read(num, 256);
				Array.Copy(sourceArray, 0, array, i * 256, 256);
				num += 256;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
		ComPort.Instance.Close();
		return array;
	}

	private void button12_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		string text = Iparse.getchart("path", "pictrue");
		if (!Directory.Exists(text))
		{
			text = Application.StartupPath;
		}
		openFileDialog.FileName = "pictrue";
		openFileDialog.Filter = "(*.dat)|*.dat";
		openFileDialog.InitialDirectory = text;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			text = openFileDialog.FileName.ToString();
			tb_picture_path.Text = text;
			Iparse.setchart("path", "pictrue", text);
		}
	}

	private void cmb_Vfo_mr_mode_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void lab_vfo_mr_Click(object sender, EventArgs e)
	{
	}

	private void tabPage3_Click(object sender, EventArgs e)
	{
	}

	private void tabPage5_Leave(object sender, EventArgs e)
	{
	}

	private void Nud_cw_Leave(object sender, EventArgs e)
	{
		Nud_cw.Value = CalCwFreq(Nud_cw.Value);
	}

	private void tabPage2_Click(object sender, EventArgs e)
	{
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
		this.btn_cancel = new System.Windows.Forms.Button();
		this.btn_ok = new System.Windows.Forms.Button();
		this.tabPage10 = new System.Windows.Forms.TabPage();
		this.button12 = new System.Windows.Forms.Button();
		this.button11 = new System.Windows.Forms.Button();
		this.button10 = new System.Windows.Forms.Button();
		this.tb_picture_path = new System.Windows.Forms.TextBox();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.button8 = new System.Windows.Forms.Button();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.button9 = new System.Windows.Forms.Button();
		this.checkBox_picture = new System.Windows.Forms.CheckBox();
		this.tabPage9 = new System.Windows.Forms.TabPage();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.button5 = new System.Windows.Forms.Button();
		this.button4 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.textBox9 = new System.Windows.Forms.TextBox();
		this.label55 = new System.Windows.Forms.Label();
		this.textBox8 = new System.Windows.Forms.TextBox();
		this.label54 = new System.Windows.Forms.Label();
		this.textBox7 = new System.Windows.Forms.TextBox();
		this.label53 = new System.Windows.Forms.Label();
		this.textBox6 = new System.Windows.Forms.TextBox();
		this.label52 = new System.Windows.Forms.Label();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.label51 = new System.Windows.Forms.Label();
		this.checkBox_selftone = new System.Windows.Forms.CheckBox();
		this.tabPage8 = new System.Windows.Forms.TabPage();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.label109 = new System.Windows.Forms.Label();
		this.label110 = new System.Windows.Forms.Label();
		this.textBox60 = new System.Windows.Forms.TextBox();
		this.textBox61 = new System.Windows.Forms.TextBox();
		this.label58 = new System.Windows.Forms.Label();
		this.label59 = new System.Windows.Forms.Label();
		this.textBox12 = new System.Windows.Forms.TextBox();
		this.textBox13 = new System.Windows.Forms.TextBox();
		this.label83 = new System.Windows.Forms.Label();
		this.label84 = new System.Windows.Forms.Label();
		this.textBox36 = new System.Windows.Forms.TextBox();
		this.textBox37 = new System.Windows.Forms.TextBox();
		this.label85 = new System.Windows.Forms.Label();
		this.label86 = new System.Windows.Forms.Label();
		this.textBox38 = new System.Windows.Forms.TextBox();
		this.textBox39 = new System.Windows.Forms.TextBox();
		this.label87 = new System.Windows.Forms.Label();
		this.label88 = new System.Windows.Forms.Label();
		this.textBox40 = new System.Windows.Forms.TextBox();
		this.textBox41 = new System.Windows.Forms.TextBox();
		this.label89 = new System.Windows.Forms.Label();
		this.label90 = new System.Windows.Forms.Label();
		this.textBox42 = new System.Windows.Forms.TextBox();
		this.textBox43 = new System.Windows.Forms.TextBox();
		this.label91 = new System.Windows.Forms.Label();
		this.label92 = new System.Windows.Forms.Label();
		this.textBox44 = new System.Windows.Forms.TextBox();
		this.textBox45 = new System.Windows.Forms.TextBox();
		this.label93 = new System.Windows.Forms.Label();
		this.label94 = new System.Windows.Forms.Label();
		this.textBox46 = new System.Windows.Forms.TextBox();
		this.textBox47 = new System.Windows.Forms.TextBox();
		this.label95 = new System.Windows.Forms.Label();
		this.label96 = new System.Windows.Forms.Label();
		this.textBox48 = new System.Windows.Forms.TextBox();
		this.textBox49 = new System.Windows.Forms.TextBox();
		this.label97 = new System.Windows.Forms.Label();
		this.label98 = new System.Windows.Forms.Label();
		this.textBox50 = new System.Windows.Forms.TextBox();
		this.textBox51 = new System.Windows.Forms.TextBox();
		this.label99 = new System.Windows.Forms.Label();
		this.label100 = new System.Windows.Forms.Label();
		this.textBox52 = new System.Windows.Forms.TextBox();
		this.textBox53 = new System.Windows.Forms.TextBox();
		this.label101 = new System.Windows.Forms.Label();
		this.label102 = new System.Windows.Forms.Label();
		this.textBox54 = new System.Windows.Forms.TextBox();
		this.textBox55 = new System.Windows.Forms.TextBox();
		this.label103 = new System.Windows.Forms.Label();
		this.label104 = new System.Windows.Forms.Label();
		this.textBox56 = new System.Windows.Forms.TextBox();
		this.textBox57 = new System.Windows.Forms.TextBox();
		this.label105 = new System.Windows.Forms.Label();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.label107 = new System.Windows.Forms.Label();
		this.label108 = new System.Windows.Forms.Label();
		this.textBox58 = new System.Windows.Forms.TextBox();
		this.textBox59 = new System.Windows.Forms.TextBox();
		this.label81 = new System.Windows.Forms.Label();
		this.label82 = new System.Windows.Forms.Label();
		this.textBox34 = new System.Windows.Forms.TextBox();
		this.textBox35 = new System.Windows.Forms.TextBox();
		this.label79 = new System.Windows.Forms.Label();
		this.label80 = new System.Windows.Forms.Label();
		this.textBox32 = new System.Windows.Forms.TextBox();
		this.textBox33 = new System.Windows.Forms.TextBox();
		this.label77 = new System.Windows.Forms.Label();
		this.label78 = new System.Windows.Forms.Label();
		this.textBox30 = new System.Windows.Forms.TextBox();
		this.textBox31 = new System.Windows.Forms.TextBox();
		this.label75 = new System.Windows.Forms.Label();
		this.label76 = new System.Windows.Forms.Label();
		this.textBox28 = new System.Windows.Forms.TextBox();
		this.textBox29 = new System.Windows.Forms.TextBox();
		this.label73 = new System.Windows.Forms.Label();
		this.label74 = new System.Windows.Forms.Label();
		this.textBox26 = new System.Windows.Forms.TextBox();
		this.textBox27 = new System.Windows.Forms.TextBox();
		this.label71 = new System.Windows.Forms.Label();
		this.label72 = new System.Windows.Forms.Label();
		this.textBox24 = new System.Windows.Forms.TextBox();
		this.textBox25 = new System.Windows.Forms.TextBox();
		this.label69 = new System.Windows.Forms.Label();
		this.label70 = new System.Windows.Forms.Label();
		this.textBox22 = new System.Windows.Forms.TextBox();
		this.textBox23 = new System.Windows.Forms.TextBox();
		this.label67 = new System.Windows.Forms.Label();
		this.label68 = new System.Windows.Forms.Label();
		this.textBox20 = new System.Windows.Forms.TextBox();
		this.textBox21 = new System.Windows.Forms.TextBox();
		this.label65 = new System.Windows.Forms.Label();
		this.label66 = new System.Windows.Forms.Label();
		this.textBox18 = new System.Windows.Forms.TextBox();
		this.textBox19 = new System.Windows.Forms.TextBox();
		this.label63 = new System.Windows.Forms.Label();
		this.label64 = new System.Windows.Forms.Label();
		this.textBox16 = new System.Windows.Forms.TextBox();
		this.textBox17 = new System.Windows.Forms.TextBox();
		this.label61 = new System.Windows.Forms.Label();
		this.label62 = new System.Windows.Forms.Label();
		this.textBox14 = new System.Windows.Forms.TextBox();
		this.textBox15 = new System.Windows.Forms.TextBox();
		this.label60 = new System.Windows.Forms.Label();
		this.label56 = new System.Windows.Forms.Label();
		this.textBox10 = new System.Windows.Forms.TextBox();
		this.textBox11 = new System.Windows.Forms.TextBox();
		this.label57 = new System.Windows.Forms.Label();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.checkBox25 = new System.Windows.Forms.CheckBox();
		this.checkBox26 = new System.Windows.Forms.CheckBox();
		this.checkBox15 = new System.Windows.Forms.CheckBox();
		this.checkBox16 = new System.Windows.Forms.CheckBox();
		this.checkBox17 = new System.Windows.Forms.CheckBox();
		this.checkBox18 = new System.Windows.Forms.CheckBox();
		this.checkBox19 = new System.Windows.Forms.CheckBox();
		this.checkBox20 = new System.Windows.Forms.CheckBox();
		this.checkBox21 = new System.Windows.Forms.CheckBox();
		this.checkBox22 = new System.Windows.Forms.CheckBox();
		this.checkBox23 = new System.Windows.Forms.CheckBox();
		this.checkBox13 = new System.Windows.Forms.CheckBox();
		this.checkBox24 = new System.Windows.Forms.CheckBox();
		this.checkBox14 = new System.Windows.Forms.CheckBox();
		this.checkBox10 = new System.Windows.Forms.CheckBox();
		this.checkBox12 = new System.Windows.Forms.CheckBox();
		this.checkBox11 = new System.Windows.Forms.CheckBox();
		this.checkBox7 = new System.Windows.Forms.CheckBox();
		this.checkBox8 = new System.Windows.Forms.CheckBox();
		this.checkBox9 = new System.Windows.Forms.CheckBox();
		this.checkBox4 = new System.Windows.Forms.CheckBox();
		this.checkBox5 = new System.Windows.Forms.CheckBox();
		this.checkBox6 = new System.Windows.Forms.CheckBox();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.tabPage7 = new System.Windows.Forms.TabPage();
		this.comboBox43 = new System.Windows.Forms.ComboBox();
		this.label47 = new System.Windows.Forms.Label();
		this.comboBox42 = new System.Windows.Forms.ComboBox();
		this.label46 = new System.Windows.Forms.Label();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label45 = new System.Windows.Forms.Label();
		this.tabPage6 = new System.Windows.Forms.TabPage();
		this.comboBox28 = new System.Windows.Forms.ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label28 = new System.Windows.Forms.Label();
		this.comboBox29 = new System.Windows.Forms.ComboBox();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label29 = new System.Windows.Forms.Label();
		this.comboBox10 = new System.Windows.Forms.ComboBox();
		this.comboBox27 = new System.Windows.Forms.ComboBox();
		this.label27 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.comboBox8 = new System.Windows.Forms.ComboBox();
		this.comboBox25 = new System.Windows.Forms.ComboBox();
		this.label25 = new System.Windows.Forms.Label();
		this.comboBox26 = new System.Windows.Forms.ComboBox();
		this.label26 = new System.Windows.Forms.Label();
		this.comboBox23 = new System.Windows.Forms.ComboBox();
		this.label23 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.comboBox9 = new System.Windows.Forms.ComboBox();
		this.label10 = new System.Windows.Forms.Label();
		this.comboBox24 = new System.Windows.Forms.ComboBox();
		this.label24 = new System.Windows.Forms.Label();
		this.label14 = new System.Windows.Forms.Label();
		this.comboBox12 = new System.Windows.Forms.ComboBox();
		this.label12 = new System.Windows.Forms.Label();
		this.comboBox14 = new System.Windows.Forms.ComboBox();
		this.tabPage5 = new System.Windows.Forms.TabPage();
		this.Nud_cw = new System.Windows.Forms.NumericUpDown();
		this.lab_cw = new System.Windows.Forms.Label();
		this.cmb_brightness = new System.Windows.Forms.ComboBox();
		this.lab_brightness = new System.Windows.Forms.Label();
		this.cmb_MwSw = new System.Windows.Forms.ComboBox();
		this.lab_MwSw = new System.Windows.Forms.Label();
		this.comboBox30 = new System.Windows.Forms.ComboBox();
		this.label30 = new System.Windows.Forms.Label();
		this.label35 = new System.Windows.Forms.Label();
		this.comboBox35 = new System.Windows.Forms.ComboBox();
		this.label50 = new System.Windows.Forms.Label();
		this.comboBox46 = new System.Windows.Forms.ComboBox();
		this.comboBox45 = new System.Windows.Forms.ComboBox();
		this.label49 = new System.Windows.Forms.Label();
		this.comboBox44 = new System.Windows.Forms.ComboBox();
		this.label48 = new System.Windows.Forms.Label();
		this.comboBox3 = new System.Windows.Forms.ComboBox();
		this.comboBox41 = new System.Windows.Forms.ComboBox();
		this.label44 = new System.Windows.Forms.Label();
		this.comboBox36 = new System.Windows.Forms.ComboBox();
		this.label36 = new System.Windows.Forms.Label();
		this.comboBox20 = new System.Windows.Forms.ComboBox();
		this.label20 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.comboBox13 = new System.Windows.Forms.ComboBox();
		this.label13 = new System.Windows.Forms.Label();
		this.comboBox6 = new System.Windows.Forms.ComboBox();
		this.comboBox11 = new System.Windows.Forms.ComboBox();
		this.label11 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.comboBox7 = new System.Windows.Forms.ComboBox();
		this.label15 = new System.Windows.Forms.Label();
		this.comboBox15 = new System.Windows.Forms.ComboBox();
		this.tabPage4 = new System.Windows.Forms.TabPage();
		this.comboBox37 = new System.Windows.Forms.ComboBox();
		this.label37 = new System.Windows.Forms.Label();
		this.label38 = new System.Windows.Forms.Label();
		this.comboBox38 = new System.Windows.Forms.ComboBox();
		this.label39 = new System.Windows.Forms.Label();
		this.comboBox40 = new System.Windows.Forms.ComboBox();
		this.comboBox39 = new System.Windows.Forms.ComboBox();
		this.label40 = new System.Windows.Forms.Label();
		this.tabPage3 = new System.Windows.Forms.TabPage();
		this.lab_self_noaa_event = new System.Windows.Forms.Label();
		this.dgv_noaa_event = new System.Windows.Forms.DataGridView();
		this.label32 = new System.Windows.Forms.Label();
		this.comboBox32 = new System.Windows.Forms.ComboBox();
		this.label33 = new System.Windows.Forms.Label();
		this.comboBox4 = new System.Windows.Forms.ComboBox();
		this.label4 = new System.Windows.Forms.Label();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.label2 = new System.Windows.Forms.Label();
		this.comboBox33 = new System.Windows.Forms.ComboBox();
		this.label34 = new System.Windows.Forms.Label();
		this.comboBox34 = new System.Windows.Forms.ComboBox();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.label17 = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		this.comboBox16 = new System.Windows.Forms.ComboBox();
		this.comboBox17 = new System.Windows.Forms.ComboBox();
		this.label18 = new System.Windows.Forms.Label();
		this.comboBox18 = new System.Windows.Forms.ComboBox();
		this.label19 = new System.Windows.Forms.Label();
		this.comboBox19 = new System.Windows.Forms.ComboBox();
		this.comboBox5 = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.comboBox21 = new System.Windows.Forms.ComboBox();
		this.label21 = new System.Windows.Forms.Label();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.cmb_B_mode = new System.Windows.Forms.ComboBox();
		this.lab_B_mode = new System.Windows.Forms.Label();
		this.cmb_A_mode = new System.Windows.Forms.ComboBox();
		this.lab_A_mode = new System.Windows.Forms.Label();
		this.txt_password = new System.Windows.Forms.TextBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.lab_bootpassword = new System.Windows.Forms.Label();
		this.label41 = new System.Windows.Forms.Label();
		this.label42 = new System.Windows.Forms.Label();
		this.label43 = new System.Windows.Forms.Label();
		this.comboBox22 = new System.Windows.Forms.ComboBox();
		this.lab_bootscreen = new System.Windows.Forms.Label();
		this.comboBox31 = new System.Windows.Forms.ComboBox();
		this.label31 = new System.Windows.Forms.Label();
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabPage10.SuspendLayout();
		this.groupBox5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.tabPage9.SuspendLayout();
		this.groupBox4.SuspendLayout();
		this.tabPage8.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.tabPage7.SuspendLayout();
		this.tabPage6.SuspendLayout();
		this.tabPage5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.Nud_cw).BeginInit();
		this.tabPage4.SuspendLayout();
		this.tabPage3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgv_noaa_event).BeginInit();
		this.tabPage2.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.tabControl1.SuspendLayout();
		base.SuspendLayout();
		this.btn_cancel.Location = new System.Drawing.Point(623, 777);
		this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.btn_cancel.Name = "btn_cancel";
		this.btn_cancel.Size = new System.Drawing.Size(88, 29);
		this.btn_cancel.TabIndex = 89;
		this.btn_cancel.Text = "取消";
		this.btn_cancel.UseVisualStyleBackColor = true;
		this.btn_cancel.Click += new System.EventHandler(button6_Click);
		this.btn_ok.Location = new System.Drawing.Point(404, 777);
		this.btn_ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.btn_ok.Name = "btn_ok";
		this.btn_ok.Size = new System.Drawing.Size(88, 29);
		this.btn_ok.TabIndex = 88;
		this.btn_ok.Text = "确定";
		this.btn_ok.UseVisualStyleBackColor = true;
		this.btn_ok.Click += new System.EventHandler(button7_Click);
		this.tabPage10.Controls.Add(this.button12);
		this.tabPage10.Controls.Add(this.button11);
		this.tabPage10.Controls.Add(this.button10);
		this.tabPage10.Controls.Add(this.tb_picture_path);
		this.tabPage10.Controls.Add(this.groupBox5);
		this.tabPage10.Controls.Add(this.checkBox_picture);
		this.tabPage10.Location = new System.Drawing.Point(4, 25);
		this.tabPage10.Name = "tabPage10";
		this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage10.Size = new System.Drawing.Size(1024, 685);
		this.tabPage10.TabIndex = 9;
		this.tabPage10.Text = "开机图片";
		this.tabPage10.UseVisualStyleBackColor = true;
		this.button12.Location = new System.Drawing.Point(396, 200);
		this.button12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button12.Name = "button12";
		this.button12.Size = new System.Drawing.Size(88, 29);
		this.button12.TabIndex = 147;
		this.button12.Text = "选择路径";
		this.button12.UseVisualStyleBackColor = true;
		this.button12.Click += new System.EventHandler(button12_Click);
		this.button11.Location = new System.Drawing.Point(598, 200);
		this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button11.Name = "button11";
		this.button11.Size = new System.Drawing.Size(88, 29);
		this.button11.TabIndex = 146;
		this.button11.Text = "写入";
		this.button11.UseVisualStyleBackColor = true;
		this.button11.Click += new System.EventHandler(button11_Click);
		this.button10.Location = new System.Drawing.Point(492, 200);
		this.button10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button10.Name = "button10";
		this.button10.Size = new System.Drawing.Size(88, 29);
		this.button10.TabIndex = 145;
		this.button10.Text = "读取";
		this.button10.UseVisualStyleBackColor = true;
		this.button10.Click += new System.EventHandler(button10_Click);
		this.tb_picture_path.Location = new System.Drawing.Point(24, 204);
		this.tb_picture_path.Name = "tb_picture_path";
		this.tb_picture_path.Size = new System.Drawing.Size(348, 25);
		this.tb_picture_path.TabIndex = 144;
		this.groupBox5.Controls.Add(this.button8);
		this.groupBox5.Controls.Add(this.pictureBox1);
		this.groupBox5.Controls.Add(this.button9);
		this.groupBox5.Location = new System.Drawing.Point(24, 12);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Size = new System.Drawing.Size(348, 151);
		this.groupBox5.TabIndex = 142;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "图片";
		this.button8.Location = new System.Drawing.Point(222, 36);
		this.button8.Name = "button8";
		this.button8.Size = new System.Drawing.Size(87, 29);
		this.button8.TabIndex = 6;
		this.button8.Text = "路径";
		this.button8.UseVisualStyleBackColor = true;
		this.button8.Click += new System.EventHandler(button8_Click);
		this.pictureBox1.Location = new System.Drawing.Point(45, 36);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(128, 64);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.pictureBox1.TabIndex = 5;
		this.pictureBox1.TabStop = false;
		this.button9.Location = new System.Drawing.Point(222, 85);
		this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button9.Name = "button9";
		this.button9.Size = new System.Drawing.Size(88, 29);
		this.button9.TabIndex = 143;
		this.button9.Text = "写入";
		this.button9.UseVisualStyleBackColor = true;
		this.button9.Click += new System.EventHandler(button9_Click);
		this.checkBox_picture.AutoSize = true;
		this.checkBox_picture.Location = new System.Drawing.Point(396, 55);
		this.checkBox_picture.Name = "checkBox_picture";
		this.checkBox_picture.Size = new System.Drawing.Size(119, 19);
		this.checkBox_picture.TabIndex = 141;
		this.checkBox_picture.Text = "图片写入使能";
		this.checkBox_picture.UseVisualStyleBackColor = true;
		this.checkBox_picture.CheckedChanged += new System.EventHandler(checkBox30_CheckedChanged);
		this.tabPage9.Controls.Add(this.groupBox4);
		this.tabPage9.Controls.Add(this.checkBox_selftone);
		this.tabPage9.Location = new System.Drawing.Point(4, 25);
		this.tabPage9.Name = "tabPage9";
		this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage9.Size = new System.Drawing.Size(1024, 685);
		this.tabPage9.TabIndex = 8;
		this.tabPage9.Text = "自定义尾音";
		this.tabPage9.UseVisualStyleBackColor = true;
		this.groupBox4.Controls.Add(this.button5);
		this.groupBox4.Controls.Add(this.button4);
		this.groupBox4.Controls.Add(this.button3);
		this.groupBox4.Controls.Add(this.button2);
		this.groupBox4.Controls.Add(this.button1);
		this.groupBox4.Controls.Add(this.textBox9);
		this.groupBox4.Controls.Add(this.label55);
		this.groupBox4.Controls.Add(this.textBox8);
		this.groupBox4.Controls.Add(this.label54);
		this.groupBox4.Controls.Add(this.textBox7);
		this.groupBox4.Controls.Add(this.label53);
		this.groupBox4.Controls.Add(this.textBox6);
		this.groupBox4.Controls.Add(this.label52);
		this.groupBox4.Controls.Add(this.textBox5);
		this.groupBox4.Controls.Add(this.label51);
		this.groupBox4.Location = new System.Drawing.Point(65, 16);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new System.Drawing.Size(712, 363);
		this.groupBox4.TabIndex = 141;
		this.groupBox4.TabStop = false;
		this.button5.Location = new System.Drawing.Point(497, 280);
		this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(88, 29);
		this.button5.TabIndex = 96;
		this.button5.Text = "选择路径";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(button1_Click);
		this.button4.Location = new System.Drawing.Point(497, 219);
		this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(88, 29);
		this.button4.TabIndex = 95;
		this.button4.Text = "选择路径";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button1_Click);
		this.button3.Location = new System.Drawing.Point(497, 158);
		this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(88, 29);
		this.button3.TabIndex = 94;
		this.button3.Text = "选择路径";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button1_Click);
		this.button2.Location = new System.Drawing.Point(497, 97);
		this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(88, 29);
		this.button2.TabIndex = 93;
		this.button2.Text = "选择路径";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button1_Click);
		this.button1.Location = new System.Drawing.Point(497, 32);
		this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(88, 29);
		this.button1.TabIndex = 92;
		this.button1.Text = "选择路径";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.textBox9.Location = new System.Drawing.Point(131, 280);
		this.textBox9.Name = "textBox9";
		this.textBox9.Size = new System.Drawing.Size(342, 25);
		this.textBox9.TabIndex = 91;
		this.label55.Location = new System.Drawing.Point(25, 280);
		this.label55.Name = "label55";
		this.label55.Size = new System.Drawing.Size(99, 23);
		this.label55.TabIndex = 90;
		this.label55.Text = "5";
		this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.textBox8.Location = new System.Drawing.Point(131, 219);
		this.textBox8.Name = "textBox8";
		this.textBox8.Size = new System.Drawing.Size(342, 25);
		this.textBox8.TabIndex = 89;
		this.label54.Location = new System.Drawing.Point(25, 219);
		this.label54.Name = "label54";
		this.label54.Size = new System.Drawing.Size(99, 23);
		this.label54.TabIndex = 88;
		this.label54.Text = "4";
		this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.textBox7.Location = new System.Drawing.Point(131, 158);
		this.textBox7.Name = "textBox7";
		this.textBox7.Size = new System.Drawing.Size(342, 25);
		this.textBox7.TabIndex = 87;
		this.label53.Location = new System.Drawing.Point(25, 158);
		this.label53.Name = "label53";
		this.label53.Size = new System.Drawing.Size(99, 23);
		this.label53.TabIndex = 86;
		this.label53.Text = "3";
		this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.textBox6.Location = new System.Drawing.Point(131, 97);
		this.textBox6.Name = "textBox6";
		this.textBox6.Size = new System.Drawing.Size(342, 25);
		this.textBox6.TabIndex = 85;
		this.label52.Location = new System.Drawing.Point(25, 97);
		this.label52.Name = "label52";
		this.label52.Size = new System.Drawing.Size(99, 23);
		this.label52.TabIndex = 84;
		this.label52.Text = "2";
		this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.textBox5.Location = new System.Drawing.Point(131, 36);
		this.textBox5.Name = "textBox5";
		this.textBox5.Size = new System.Drawing.Size(342, 25);
		this.textBox5.TabIndex = 83;
		this.label51.Location = new System.Drawing.Point(25, 36);
		this.label51.Name = "label51";
		this.label51.Size = new System.Drawing.Size(99, 23);
		this.label51.TabIndex = 82;
		this.label51.Text = "1";
		this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_selftone.AutoSize = true;
		this.checkBox_selftone.Location = new System.Drawing.Point(838, 31);
		this.checkBox_selftone.Name = "checkBox_selftone";
		this.checkBox_selftone.Size = new System.Drawing.Size(119, 19);
		this.checkBox_selftone.TabIndex = 140;
		this.checkBox_selftone.Text = "尾音写入使能";
		this.checkBox_selftone.UseVisualStyleBackColor = true;
		this.checkBox_selftone.CheckedChanged += new System.EventHandler(checkBox25_CheckedChanged);
		this.tabPage8.Controls.Add(this.groupBox3);
		this.tabPage8.Controls.Add(this.groupBox2);
		this.tabPage8.Controls.Add(this.groupBox1);
		this.tabPage8.Location = new System.Drawing.Point(4, 25);
		this.tabPage8.Name = "tabPage8";
		this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage8.Size = new System.Drawing.Size(1024, 685);
		this.tabPage8.TabIndex = 7;
		this.tabPage8.Text = "VFO频段设置";
		this.tabPage8.UseVisualStyleBackColor = true;
		this.groupBox3.Controls.Add(this.label109);
		this.groupBox3.Controls.Add(this.label110);
		this.groupBox3.Controls.Add(this.textBox60);
		this.groupBox3.Controls.Add(this.textBox61);
		this.groupBox3.Controls.Add(this.label58);
		this.groupBox3.Controls.Add(this.label59);
		this.groupBox3.Controls.Add(this.textBox12);
		this.groupBox3.Controls.Add(this.textBox13);
		this.groupBox3.Controls.Add(this.label83);
		this.groupBox3.Controls.Add(this.label84);
		this.groupBox3.Controls.Add(this.textBox36);
		this.groupBox3.Controls.Add(this.textBox37);
		this.groupBox3.Controls.Add(this.label85);
		this.groupBox3.Controls.Add(this.label86);
		this.groupBox3.Controls.Add(this.textBox38);
		this.groupBox3.Controls.Add(this.textBox39);
		this.groupBox3.Controls.Add(this.label87);
		this.groupBox3.Controls.Add(this.label88);
		this.groupBox3.Controls.Add(this.textBox40);
		this.groupBox3.Controls.Add(this.textBox41);
		this.groupBox3.Controls.Add(this.label89);
		this.groupBox3.Controls.Add(this.label90);
		this.groupBox3.Controls.Add(this.textBox42);
		this.groupBox3.Controls.Add(this.textBox43);
		this.groupBox3.Controls.Add(this.label91);
		this.groupBox3.Controls.Add(this.label92);
		this.groupBox3.Controls.Add(this.textBox44);
		this.groupBox3.Controls.Add(this.textBox45);
		this.groupBox3.Controls.Add(this.label93);
		this.groupBox3.Controls.Add(this.label94);
		this.groupBox3.Controls.Add(this.textBox46);
		this.groupBox3.Controls.Add(this.textBox47);
		this.groupBox3.Controls.Add(this.label95);
		this.groupBox3.Controls.Add(this.label96);
		this.groupBox3.Controls.Add(this.textBox48);
		this.groupBox3.Controls.Add(this.textBox49);
		this.groupBox3.Controls.Add(this.label97);
		this.groupBox3.Controls.Add(this.label98);
		this.groupBox3.Controls.Add(this.textBox50);
		this.groupBox3.Controls.Add(this.textBox51);
		this.groupBox3.Controls.Add(this.label99);
		this.groupBox3.Controls.Add(this.label100);
		this.groupBox3.Controls.Add(this.textBox52);
		this.groupBox3.Controls.Add(this.textBox53);
		this.groupBox3.Controls.Add(this.label101);
		this.groupBox3.Controls.Add(this.label102);
		this.groupBox3.Controls.Add(this.textBox54);
		this.groupBox3.Controls.Add(this.textBox55);
		this.groupBox3.Controls.Add(this.label103);
		this.groupBox3.Controls.Add(this.label104);
		this.groupBox3.Controls.Add(this.textBox56);
		this.groupBox3.Controls.Add(this.textBox57);
		this.groupBox3.Controls.Add(this.label105);
		this.groupBox3.Location = new System.Drawing.Point(738, 29);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(259, 643);
		this.groupBox3.TabIndex = 200;
		this.groupBox3.TabStop = false;
		this.label109.Location = new System.Drawing.Point(4, 606);
		this.label109.Name = "label109";
		this.label109.Size = new System.Drawing.Size(26, 25);
		this.label109.TabIndex = 203;
		this.label109.Text = "13";
		this.label109.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label110.Location = new System.Drawing.Point(135, 609);
		this.label110.Name = "label110";
		this.label110.Size = new System.Drawing.Size(18, 22);
		this.label110.TabIndex = 202;
		this.label110.Text = "-";
		this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox60.Location = new System.Drawing.Point(37, 604);
		this.textBox60.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox60.MaxLength = 9;
		this.textBox60.Name = "textBox60";
		this.textBox60.Size = new System.Drawing.Size(91, 25);
		this.textBox60.TabIndex = 201;
		this.textBox60.Text = "400.00625";
		this.textBox61.Location = new System.Drawing.Point(162, 604);
		this.textBox61.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox61.MaxLength = 9;
		this.textBox61.Name = "textBox61";
		this.textBox61.Size = new System.Drawing.Size(91, 25);
		this.textBox61.TabIndex = 200;
		this.label58.Location = new System.Drawing.Point(4, 560);
		this.label58.Name = "label58";
		this.label58.Size = new System.Drawing.Size(26, 25);
		this.label58.TabIndex = 199;
		this.label58.Text = "12";
		this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label59.Location = new System.Drawing.Point(135, 563);
		this.label59.Name = "label59";
		this.label59.Size = new System.Drawing.Size(18, 22);
		this.label59.TabIndex = 198;
		this.label59.Text = "-";
		this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox12.Location = new System.Drawing.Point(41, 558);
		this.textBox12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox12.MaxLength = 9;
		this.textBox12.Name = "textBox12";
		this.textBox12.Size = new System.Drawing.Size(91, 25);
		this.textBox12.TabIndex = 197;
		this.textBox12.Text = "400.00625";
		this.textBox13.Location = new System.Drawing.Point(162, 558);
		this.textBox13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox13.MaxLength = 9;
		this.textBox13.Name = "textBox13";
		this.textBox13.Size = new System.Drawing.Size(91, 25);
		this.textBox13.TabIndex = 196;
		this.label83.Location = new System.Drawing.Point(0, 514);
		this.label83.Name = "label83";
		this.label83.Size = new System.Drawing.Size(26, 25);
		this.label83.TabIndex = 195;
		this.label83.Text = "11";
		this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label84.Location = new System.Drawing.Point(135, 514);
		this.label84.Name = "label84";
		this.label84.Size = new System.Drawing.Size(18, 22);
		this.label84.TabIndex = 194;
		this.label84.Text = "-";
		this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox36.Location = new System.Drawing.Point(41, 513);
		this.textBox36.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox36.MaxLength = 9;
		this.textBox36.Name = "textBox36";
		this.textBox36.Size = new System.Drawing.Size(91, 25);
		this.textBox36.TabIndex = 193;
		this.textBox36.Text = "400.00625";
		this.textBox37.Location = new System.Drawing.Point(162, 513);
		this.textBox37.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox37.MaxLength = 9;
		this.textBox37.Name = "textBox37";
		this.textBox37.Size = new System.Drawing.Size(91, 25);
		this.textBox37.TabIndex = 192;
		this.label85.Location = new System.Drawing.Point(0, 466);
		this.label85.Name = "label85";
		this.label85.Size = new System.Drawing.Size(26, 25);
		this.label85.TabIndex = 191;
		this.label85.Text = "10";
		this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label86.Location = new System.Drawing.Point(135, 466);
		this.label86.Name = "label86";
		this.label86.Size = new System.Drawing.Size(18, 22);
		this.label86.TabIndex = 190;
		this.label86.Text = "-";
		this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox38.Location = new System.Drawing.Point(41, 468);
		this.textBox38.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox38.MaxLength = 9;
		this.textBox38.Name = "textBox38";
		this.textBox38.Size = new System.Drawing.Size(91, 25);
		this.textBox38.TabIndex = 189;
		this.textBox38.Text = "400.00625";
		this.textBox39.Location = new System.Drawing.Point(162, 468);
		this.textBox39.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox39.MaxLength = 9;
		this.textBox39.Name = "textBox39";
		this.textBox39.Size = new System.Drawing.Size(91, 25);
		this.textBox39.TabIndex = 188;
		this.label87.Location = new System.Drawing.Point(9, 423);
		this.label87.Name = "label87";
		this.label87.Size = new System.Drawing.Size(17, 25);
		this.label87.TabIndex = 187;
		this.label87.Text = "9";
		this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label88.Location = new System.Drawing.Point(135, 423);
		this.label88.Name = "label88";
		this.label88.Size = new System.Drawing.Size(18, 22);
		this.label88.TabIndex = 186;
		this.label88.Text = "-";
		this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox40.Location = new System.Drawing.Point(41, 423);
		this.textBox40.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox40.MaxLength = 9;
		this.textBox40.Name = "textBox40";
		this.textBox40.Size = new System.Drawing.Size(91, 25);
		this.textBox40.TabIndex = 185;
		this.textBox40.Text = "400.00625";
		this.textBox41.Location = new System.Drawing.Point(162, 423);
		this.textBox41.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox41.MaxLength = 9;
		this.textBox41.Name = "textBox41";
		this.textBox41.Size = new System.Drawing.Size(91, 25);
		this.textBox41.TabIndex = 184;
		this.label89.Location = new System.Drawing.Point(9, 378);
		this.label89.Name = "label89";
		this.label89.Size = new System.Drawing.Size(17, 25);
		this.label89.TabIndex = 183;
		this.label89.Text = "8";
		this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label90.Location = new System.Drawing.Point(135, 378);
		this.label90.Name = "label90";
		this.label90.Size = new System.Drawing.Size(18, 22);
		this.label90.TabIndex = 182;
		this.label90.Text = "-";
		this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox42.Location = new System.Drawing.Point(41, 378);
		this.textBox42.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox42.MaxLength = 9;
		this.textBox42.Name = "textBox42";
		this.textBox42.Size = new System.Drawing.Size(91, 25);
		this.textBox42.TabIndex = 181;
		this.textBox42.Text = "400.00625";
		this.textBox43.Location = new System.Drawing.Point(162, 378);
		this.textBox43.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox43.MaxLength = 9;
		this.textBox43.Name = "textBox43";
		this.textBox43.Size = new System.Drawing.Size(91, 25);
		this.textBox43.TabIndex = 180;
		this.label91.Location = new System.Drawing.Point(9, 333);
		this.label91.Name = "label91";
		this.label91.Size = new System.Drawing.Size(17, 25);
		this.label91.TabIndex = 179;
		this.label91.Text = "7";
		this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label92.Location = new System.Drawing.Point(135, 336);
		this.label92.Name = "label92";
		this.label92.Size = new System.Drawing.Size(18, 22);
		this.label92.TabIndex = 178;
		this.label92.Text = "-";
		this.label92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox44.Location = new System.Drawing.Point(41, 333);
		this.textBox44.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox44.MaxLength = 9;
		this.textBox44.Name = "textBox44";
		this.textBox44.Size = new System.Drawing.Size(91, 25);
		this.textBox44.TabIndex = 177;
		this.textBox44.Text = "400.00625";
		this.textBox45.Location = new System.Drawing.Point(162, 333);
		this.textBox45.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox45.MaxLength = 9;
		this.textBox45.Name = "textBox45";
		this.textBox45.Size = new System.Drawing.Size(91, 25);
		this.textBox45.TabIndex = 176;
		this.label93.Location = new System.Drawing.Point(9, 288);
		this.label93.Name = "label93";
		this.label93.Size = new System.Drawing.Size(17, 25);
		this.label93.TabIndex = 175;
		this.label93.Text = "6";
		this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label94.Location = new System.Drawing.Point(135, 294);
		this.label94.Name = "label94";
		this.label94.Size = new System.Drawing.Size(18, 22);
		this.label94.TabIndex = 174;
		this.label94.Text = "-";
		this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox46.Location = new System.Drawing.Point(41, 288);
		this.textBox46.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox46.MaxLength = 9;
		this.textBox46.Name = "textBox46";
		this.textBox46.Size = new System.Drawing.Size(91, 25);
		this.textBox46.TabIndex = 173;
		this.textBox46.Text = "400.00625";
		this.textBox47.Location = new System.Drawing.Point(162, 288);
		this.textBox47.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox47.MaxLength = 9;
		this.textBox47.Name = "textBox47";
		this.textBox47.Size = new System.Drawing.Size(91, 25);
		this.textBox47.TabIndex = 172;
		this.label95.Location = new System.Drawing.Point(13, 246);
		this.label95.Name = "label95";
		this.label95.Size = new System.Drawing.Size(17, 25);
		this.label95.TabIndex = 171;
		this.label95.Text = "5";
		this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label96.Location = new System.Drawing.Point(139, 254);
		this.label96.Name = "label96";
		this.label96.Size = new System.Drawing.Size(18, 22);
		this.label96.TabIndex = 170;
		this.label96.Text = "-";
		this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox48.Location = new System.Drawing.Point(41, 243);
		this.textBox48.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox48.MaxLength = 9;
		this.textBox48.Name = "textBox48";
		this.textBox48.Size = new System.Drawing.Size(91, 25);
		this.textBox48.TabIndex = 169;
		this.textBox48.Text = "400.00625";
		this.textBox49.Location = new System.Drawing.Point(162, 243);
		this.textBox49.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox49.MaxLength = 9;
		this.textBox49.Name = "textBox49";
		this.textBox49.Size = new System.Drawing.Size(91, 25);
		this.textBox49.TabIndex = 168;
		this.label97.Location = new System.Drawing.Point(13, 205);
		this.label97.Name = "label97";
		this.label97.Size = new System.Drawing.Size(17, 25);
		this.label97.TabIndex = 167;
		this.label97.Text = "4";
		this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label98.Location = new System.Drawing.Point(139, 205);
		this.label98.Name = "label98";
		this.label98.Size = new System.Drawing.Size(18, 22);
		this.label98.TabIndex = 166;
		this.label98.Text = "-";
		this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox50.Location = new System.Drawing.Point(41, 198);
		this.textBox50.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox50.MaxLength = 9;
		this.textBox50.Name = "textBox50";
		this.textBox50.Size = new System.Drawing.Size(91, 25);
		this.textBox50.TabIndex = 165;
		this.textBox50.Text = "400.00625";
		this.textBox51.Location = new System.Drawing.Point(162, 198);
		this.textBox51.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox51.MaxLength = 9;
		this.textBox51.Name = "textBox51";
		this.textBox51.Size = new System.Drawing.Size(91, 25);
		this.textBox51.TabIndex = 164;
		this.label99.Location = new System.Drawing.Point(13, 158);
		this.label99.Name = "label99";
		this.label99.Size = new System.Drawing.Size(17, 25);
		this.label99.TabIndex = 163;
		this.label99.Text = "3";
		this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label100.Location = new System.Drawing.Point(139, 158);
		this.label100.Name = "label100";
		this.label100.Size = new System.Drawing.Size(18, 22);
		this.label100.TabIndex = 162;
		this.label100.Text = "-";
		this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox52.Location = new System.Drawing.Point(41, 153);
		this.textBox52.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox52.MaxLength = 9;
		this.textBox52.Name = "textBox52";
		this.textBox52.Size = new System.Drawing.Size(91, 25);
		this.textBox52.TabIndex = 161;
		this.textBox52.Text = "400.00625";
		this.textBox53.Location = new System.Drawing.Point(162, 153);
		this.textBox53.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox53.MaxLength = 9;
		this.textBox53.Name = "textBox53";
		this.textBox53.Size = new System.Drawing.Size(91, 25);
		this.textBox53.TabIndex = 160;
		this.label101.Location = new System.Drawing.Point(13, 111);
		this.label101.Name = "label101";
		this.label101.Size = new System.Drawing.Size(17, 25);
		this.label101.TabIndex = 159;
		this.label101.Text = "2";
		this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label102.Location = new System.Drawing.Point(139, 111);
		this.label102.Name = "label102";
		this.label102.Size = new System.Drawing.Size(18, 22);
		this.label102.TabIndex = 158;
		this.label102.Text = "-";
		this.label102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox54.Location = new System.Drawing.Point(41, 108);
		this.textBox54.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox54.MaxLength = 9;
		this.textBox54.Name = "textBox54";
		this.textBox54.Size = new System.Drawing.Size(91, 25);
		this.textBox54.TabIndex = 157;
		this.textBox54.Text = "400.00625";
		this.textBox55.Location = new System.Drawing.Point(162, 108);
		this.textBox55.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox55.MaxLength = 9;
		this.textBox55.Name = "textBox55";
		this.textBox55.Size = new System.Drawing.Size(91, 25);
		this.textBox55.TabIndex = 156;
		this.label103.Location = new System.Drawing.Point(13, 64);
		this.label103.Name = "label103";
		this.label103.Size = new System.Drawing.Size(17, 25);
		this.label103.TabIndex = 155;
		this.label103.Text = "1";
		this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label104.Location = new System.Drawing.Point(139, 64);
		this.label104.Name = "label104";
		this.label104.Size = new System.Drawing.Size(18, 22);
		this.label104.TabIndex = 154;
		this.label104.Text = "-";
		this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox56.Location = new System.Drawing.Point(41, 63);
		this.textBox56.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox56.MaxLength = 9;
		this.textBox56.Name = "textBox56";
		this.textBox56.Size = new System.Drawing.Size(91, 25);
		this.textBox56.TabIndex = 153;
		this.textBox56.Text = "400.00625";
		this.textBox57.Location = new System.Drawing.Point(162, 63);
		this.textBox57.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox57.MaxLength = 9;
		this.textBox57.Name = "textBox57";
		this.textBox57.Size = new System.Drawing.Size(91, 25);
		this.textBox57.TabIndex = 152;
		this.label105.Location = new System.Drawing.Point(62, 21);
		this.label105.Name = "label105";
		this.label105.Size = new System.Drawing.Size(130, 25);
		this.label105.TabIndex = 151;
		this.label105.Text = "VFO发射频率范围";
		this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.groupBox2.Controls.Add(this.label107);
		this.groupBox2.Controls.Add(this.label108);
		this.groupBox2.Controls.Add(this.textBox58);
		this.groupBox2.Controls.Add(this.textBox59);
		this.groupBox2.Controls.Add(this.label81);
		this.groupBox2.Controls.Add(this.label82);
		this.groupBox2.Controls.Add(this.textBox34);
		this.groupBox2.Controls.Add(this.textBox35);
		this.groupBox2.Controls.Add(this.label79);
		this.groupBox2.Controls.Add(this.label80);
		this.groupBox2.Controls.Add(this.textBox32);
		this.groupBox2.Controls.Add(this.textBox33);
		this.groupBox2.Controls.Add(this.label77);
		this.groupBox2.Controls.Add(this.label78);
		this.groupBox2.Controls.Add(this.textBox30);
		this.groupBox2.Controls.Add(this.textBox31);
		this.groupBox2.Controls.Add(this.label75);
		this.groupBox2.Controls.Add(this.label76);
		this.groupBox2.Controls.Add(this.textBox28);
		this.groupBox2.Controls.Add(this.textBox29);
		this.groupBox2.Controls.Add(this.label73);
		this.groupBox2.Controls.Add(this.label74);
		this.groupBox2.Controls.Add(this.textBox26);
		this.groupBox2.Controls.Add(this.textBox27);
		this.groupBox2.Controls.Add(this.label71);
		this.groupBox2.Controls.Add(this.label72);
		this.groupBox2.Controls.Add(this.textBox24);
		this.groupBox2.Controls.Add(this.textBox25);
		this.groupBox2.Controls.Add(this.label69);
		this.groupBox2.Controls.Add(this.label70);
		this.groupBox2.Controls.Add(this.textBox22);
		this.groupBox2.Controls.Add(this.textBox23);
		this.groupBox2.Controls.Add(this.label67);
		this.groupBox2.Controls.Add(this.label68);
		this.groupBox2.Controls.Add(this.textBox20);
		this.groupBox2.Controls.Add(this.textBox21);
		this.groupBox2.Controls.Add(this.label65);
		this.groupBox2.Controls.Add(this.label66);
		this.groupBox2.Controls.Add(this.textBox18);
		this.groupBox2.Controls.Add(this.textBox19);
		this.groupBox2.Controls.Add(this.label63);
		this.groupBox2.Controls.Add(this.label64);
		this.groupBox2.Controls.Add(this.textBox16);
		this.groupBox2.Controls.Add(this.textBox17);
		this.groupBox2.Controls.Add(this.label61);
		this.groupBox2.Controls.Add(this.label62);
		this.groupBox2.Controls.Add(this.textBox14);
		this.groupBox2.Controls.Add(this.textBox15);
		this.groupBox2.Controls.Add(this.label60);
		this.groupBox2.Controls.Add(this.label56);
		this.groupBox2.Controls.Add(this.textBox10);
		this.groupBox2.Controls.Add(this.textBox11);
		this.groupBox2.Controls.Add(this.label57);
		this.groupBox2.Location = new System.Drawing.Point(452, 29);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(259, 643);
		this.groupBox2.TabIndex = 160;
		this.groupBox2.TabStop = false;
		this.label107.Location = new System.Drawing.Point(4, 606);
		this.label107.Name = "label107";
		this.label107.Size = new System.Drawing.Size(26, 25);
		this.label107.TabIndex = 203;
		this.label107.Text = "13";
		this.label107.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label108.Location = new System.Drawing.Point(135, 609);
		this.label108.Name = "label108";
		this.label108.Size = new System.Drawing.Size(18, 22);
		this.label108.TabIndex = 202;
		this.label108.Text = "-";
		this.label108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox58.Location = new System.Drawing.Point(37, 604);
		this.textBox58.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox58.MaxLength = 9;
		this.textBox58.Name = "textBox58";
		this.textBox58.Size = new System.Drawing.Size(91, 25);
		this.textBox58.TabIndex = 201;
		this.textBox58.Text = "400.00625";
		this.textBox59.Location = new System.Drawing.Point(162, 604);
		this.textBox59.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox59.MaxLength = 9;
		this.textBox59.Name = "textBox59";
		this.textBox59.Size = new System.Drawing.Size(91, 25);
		this.textBox59.TabIndex = 200;
		this.label81.Location = new System.Drawing.Point(4, 560);
		this.label81.Name = "label81";
		this.label81.Size = new System.Drawing.Size(26, 25);
		this.label81.TabIndex = 199;
		this.label81.Text = "12";
		this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label82.Location = new System.Drawing.Point(135, 563);
		this.label82.Name = "label82";
		this.label82.Size = new System.Drawing.Size(18, 22);
		this.label82.TabIndex = 198;
		this.label82.Text = "-";
		this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox34.Location = new System.Drawing.Point(37, 558);
		this.textBox34.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox34.MaxLength = 9;
		this.textBox34.Name = "textBox34";
		this.textBox34.Size = new System.Drawing.Size(91, 25);
		this.textBox34.TabIndex = 197;
		this.textBox34.Text = "400.00625";
		this.textBox35.Location = new System.Drawing.Point(162, 558);
		this.textBox35.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox35.MaxLength = 9;
		this.textBox35.Name = "textBox35";
		this.textBox35.Size = new System.Drawing.Size(91, 25);
		this.textBox35.TabIndex = 196;
		this.label79.Location = new System.Drawing.Point(0, 514);
		this.label79.Name = "label79";
		this.label79.Size = new System.Drawing.Size(26, 25);
		this.label79.TabIndex = 195;
		this.label79.Text = "11";
		this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label80.Location = new System.Drawing.Point(135, 514);
		this.label80.Name = "label80";
		this.label80.Size = new System.Drawing.Size(18, 22);
		this.label80.TabIndex = 194;
		this.label80.Text = "-";
		this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox32.Location = new System.Drawing.Point(37, 513);
		this.textBox32.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox32.MaxLength = 9;
		this.textBox32.Name = "textBox32";
		this.textBox32.Size = new System.Drawing.Size(91, 25);
		this.textBox32.TabIndex = 193;
		this.textBox32.Text = "400.00625";
		this.textBox33.Location = new System.Drawing.Point(162, 513);
		this.textBox33.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox33.MaxLength = 9;
		this.textBox33.Name = "textBox33";
		this.textBox33.Size = new System.Drawing.Size(91, 25);
		this.textBox33.TabIndex = 192;
		this.label77.Location = new System.Drawing.Point(0, 466);
		this.label77.Name = "label77";
		this.label77.Size = new System.Drawing.Size(26, 25);
		this.label77.TabIndex = 191;
		this.label77.Text = "10";
		this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label78.Location = new System.Drawing.Point(135, 466);
		this.label78.Name = "label78";
		this.label78.Size = new System.Drawing.Size(18, 22);
		this.label78.TabIndex = 190;
		this.label78.Text = "-";
		this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox30.Location = new System.Drawing.Point(37, 468);
		this.textBox30.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox30.MaxLength = 9;
		this.textBox30.Name = "textBox30";
		this.textBox30.Size = new System.Drawing.Size(91, 25);
		this.textBox30.TabIndex = 189;
		this.textBox30.Text = "400.00625";
		this.textBox31.Location = new System.Drawing.Point(162, 468);
		this.textBox31.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox31.MaxLength = 9;
		this.textBox31.Name = "textBox31";
		this.textBox31.Size = new System.Drawing.Size(91, 25);
		this.textBox31.TabIndex = 188;
		this.label75.Location = new System.Drawing.Point(9, 423);
		this.label75.Name = "label75";
		this.label75.Size = new System.Drawing.Size(17, 25);
		this.label75.TabIndex = 187;
		this.label75.Text = "9";
		this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label76.Location = new System.Drawing.Point(135, 423);
		this.label76.Name = "label76";
		this.label76.Size = new System.Drawing.Size(18, 22);
		this.label76.TabIndex = 186;
		this.label76.Text = "-";
		this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox28.Location = new System.Drawing.Point(37, 423);
		this.textBox28.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox28.MaxLength = 9;
		this.textBox28.Name = "textBox28";
		this.textBox28.Size = new System.Drawing.Size(91, 25);
		this.textBox28.TabIndex = 185;
		this.textBox28.Text = "400.00625";
		this.textBox29.Location = new System.Drawing.Point(162, 423);
		this.textBox29.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox29.MaxLength = 9;
		this.textBox29.Name = "textBox29";
		this.textBox29.Size = new System.Drawing.Size(91, 25);
		this.textBox29.TabIndex = 184;
		this.label73.Location = new System.Drawing.Point(9, 378);
		this.label73.Name = "label73";
		this.label73.Size = new System.Drawing.Size(17, 25);
		this.label73.TabIndex = 183;
		this.label73.Text = "8";
		this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label74.Location = new System.Drawing.Point(135, 378);
		this.label74.Name = "label74";
		this.label74.Size = new System.Drawing.Size(18, 22);
		this.label74.TabIndex = 182;
		this.label74.Text = "-";
		this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox26.Location = new System.Drawing.Point(37, 378);
		this.textBox26.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox26.MaxLength = 9;
		this.textBox26.Name = "textBox26";
		this.textBox26.Size = new System.Drawing.Size(91, 25);
		this.textBox26.TabIndex = 181;
		this.textBox26.Text = "400.00625";
		this.textBox27.Location = new System.Drawing.Point(162, 378);
		this.textBox27.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox27.MaxLength = 9;
		this.textBox27.Name = "textBox27";
		this.textBox27.Size = new System.Drawing.Size(91, 25);
		this.textBox27.TabIndex = 180;
		this.label71.Location = new System.Drawing.Point(9, 333);
		this.label71.Name = "label71";
		this.label71.Size = new System.Drawing.Size(17, 25);
		this.label71.TabIndex = 179;
		this.label71.Text = "7";
		this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label72.Location = new System.Drawing.Point(135, 336);
		this.label72.Name = "label72";
		this.label72.Size = new System.Drawing.Size(18, 22);
		this.label72.TabIndex = 178;
		this.label72.Text = "-";
		this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox24.Location = new System.Drawing.Point(37, 333);
		this.textBox24.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox24.MaxLength = 9;
		this.textBox24.Name = "textBox24";
		this.textBox24.Size = new System.Drawing.Size(91, 25);
		this.textBox24.TabIndex = 177;
		this.textBox24.Text = "400.00625";
		this.textBox25.Location = new System.Drawing.Point(162, 333);
		this.textBox25.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox25.MaxLength = 9;
		this.textBox25.Name = "textBox25";
		this.textBox25.Size = new System.Drawing.Size(91, 25);
		this.textBox25.TabIndex = 176;
		this.label69.Location = new System.Drawing.Point(9, 288);
		this.label69.Name = "label69";
		this.label69.Size = new System.Drawing.Size(17, 25);
		this.label69.TabIndex = 175;
		this.label69.Text = "6";
		this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label70.Location = new System.Drawing.Point(135, 294);
		this.label70.Name = "label70";
		this.label70.Size = new System.Drawing.Size(18, 22);
		this.label70.TabIndex = 174;
		this.label70.Text = "-";
		this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox22.Location = new System.Drawing.Point(37, 288);
		this.textBox22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox22.MaxLength = 9;
		this.textBox22.Name = "textBox22";
		this.textBox22.Size = new System.Drawing.Size(91, 25);
		this.textBox22.TabIndex = 173;
		this.textBox22.Text = "400.00625";
		this.textBox23.Location = new System.Drawing.Point(162, 288);
		this.textBox23.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox23.MaxLength = 9;
		this.textBox23.Name = "textBox23";
		this.textBox23.Size = new System.Drawing.Size(91, 25);
		this.textBox23.TabIndex = 172;
		this.label67.Location = new System.Drawing.Point(13, 241);
		this.label67.Name = "label67";
		this.label67.Size = new System.Drawing.Size(17, 25);
		this.label67.TabIndex = 171;
		this.label67.Text = "5";
		this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label68.Location = new System.Drawing.Point(139, 254);
		this.label68.Name = "label68";
		this.label68.Size = new System.Drawing.Size(18, 22);
		this.label68.TabIndex = 170;
		this.label68.Text = "-";
		this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox20.Location = new System.Drawing.Point(37, 243);
		this.textBox20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox20.MaxLength = 9;
		this.textBox20.Name = "textBox20";
		this.textBox20.Size = new System.Drawing.Size(91, 25);
		this.textBox20.TabIndex = 169;
		this.textBox20.Text = "400.00625";
		this.textBox21.Location = new System.Drawing.Point(162, 243);
		this.textBox21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox21.MaxLength = 9;
		this.textBox21.Name = "textBox21";
		this.textBox21.Size = new System.Drawing.Size(91, 25);
		this.textBox21.TabIndex = 168;
		this.label65.Location = new System.Drawing.Point(13, 205);
		this.label65.Name = "label65";
		this.label65.Size = new System.Drawing.Size(17, 25);
		this.label65.TabIndex = 167;
		this.label65.Text = "4";
		this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label66.Location = new System.Drawing.Point(139, 205);
		this.label66.Name = "label66";
		this.label66.Size = new System.Drawing.Size(18, 22);
		this.label66.TabIndex = 166;
		this.label66.Text = "-";
		this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox18.Location = new System.Drawing.Point(37, 198);
		this.textBox18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox18.MaxLength = 9;
		this.textBox18.Name = "textBox18";
		this.textBox18.Size = new System.Drawing.Size(91, 25);
		this.textBox18.TabIndex = 165;
		this.textBox18.Text = "400.00625";
		this.textBox19.Location = new System.Drawing.Point(162, 198);
		this.textBox19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox19.MaxLength = 9;
		this.textBox19.Name = "textBox19";
		this.textBox19.Size = new System.Drawing.Size(91, 25);
		this.textBox19.TabIndex = 164;
		this.label63.Location = new System.Drawing.Point(13, 158);
		this.label63.Name = "label63";
		this.label63.Size = new System.Drawing.Size(17, 25);
		this.label63.TabIndex = 163;
		this.label63.Text = "3";
		this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label64.Location = new System.Drawing.Point(139, 158);
		this.label64.Name = "label64";
		this.label64.Size = new System.Drawing.Size(18, 22);
		this.label64.TabIndex = 162;
		this.label64.Text = "-";
		this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox16.Location = new System.Drawing.Point(37, 153);
		this.textBox16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox16.MaxLength = 9;
		this.textBox16.Name = "textBox16";
		this.textBox16.Size = new System.Drawing.Size(91, 25);
		this.textBox16.TabIndex = 161;
		this.textBox16.Text = "400.00625";
		this.textBox17.Location = new System.Drawing.Point(162, 153);
		this.textBox17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox17.MaxLength = 9;
		this.textBox17.Name = "textBox17";
		this.textBox17.Size = new System.Drawing.Size(91, 25);
		this.textBox17.TabIndex = 160;
		this.label61.Location = new System.Drawing.Point(13, 111);
		this.label61.Name = "label61";
		this.label61.Size = new System.Drawing.Size(17, 25);
		this.label61.TabIndex = 159;
		this.label61.Text = "2";
		this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label62.Location = new System.Drawing.Point(139, 111);
		this.label62.Name = "label62";
		this.label62.Size = new System.Drawing.Size(18, 22);
		this.label62.TabIndex = 158;
		this.label62.Text = "-";
		this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox14.Location = new System.Drawing.Point(37, 108);
		this.textBox14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox14.MaxLength = 9;
		this.textBox14.Name = "textBox14";
		this.textBox14.Size = new System.Drawing.Size(91, 25);
		this.textBox14.TabIndex = 157;
		this.textBox14.Text = "400.00625";
		this.textBox15.Location = new System.Drawing.Point(162, 108);
		this.textBox15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox15.MaxLength = 9;
		this.textBox15.Name = "textBox15";
		this.textBox15.Size = new System.Drawing.Size(91, 25);
		this.textBox15.TabIndex = 156;
		this.label60.Location = new System.Drawing.Point(13, 64);
		this.label60.Name = "label60";
		this.label60.Size = new System.Drawing.Size(17, 25);
		this.label60.TabIndex = 155;
		this.label60.Text = "1";
		this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label56.Location = new System.Drawing.Point(139, 64);
		this.label56.Name = "label56";
		this.label56.Size = new System.Drawing.Size(18, 22);
		this.label56.TabIndex = 154;
		this.label56.Text = "-";
		this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox10.Location = new System.Drawing.Point(37, 63);
		this.textBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox10.MaxLength = 9;
		this.textBox10.Name = "textBox10";
		this.textBox10.Size = new System.Drawing.Size(91, 25);
		this.textBox10.TabIndex = 153;
		this.textBox10.Text = "400.00625";
		this.textBox11.Location = new System.Drawing.Point(162, 63);
		this.textBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox11.MaxLength = 9;
		this.textBox11.Name = "textBox11";
		this.textBox11.Size = new System.Drawing.Size(91, 25);
		this.textBox11.TabIndex = 152;
		this.label57.Location = new System.Drawing.Point(62, 21);
		this.label57.Name = "label57";
		this.label57.Size = new System.Drawing.Size(129, 25);
		this.label57.TabIndex = 151;
		this.label57.Text = "VFO接收频率范围";
		this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.groupBox1.Controls.Add(this.checkBox25);
		this.groupBox1.Controls.Add(this.checkBox26);
		this.groupBox1.Controls.Add(this.checkBox15);
		this.groupBox1.Controls.Add(this.checkBox16);
		this.groupBox1.Controls.Add(this.checkBox17);
		this.groupBox1.Controls.Add(this.checkBox18);
		this.groupBox1.Controls.Add(this.checkBox19);
		this.groupBox1.Controls.Add(this.checkBox20);
		this.groupBox1.Controls.Add(this.checkBox21);
		this.groupBox1.Controls.Add(this.checkBox22);
		this.groupBox1.Controls.Add(this.checkBox23);
		this.groupBox1.Controls.Add(this.checkBox13);
		this.groupBox1.Controls.Add(this.checkBox24);
		this.groupBox1.Controls.Add(this.checkBox14);
		this.groupBox1.Controls.Add(this.checkBox10);
		this.groupBox1.Controls.Add(this.checkBox12);
		this.groupBox1.Controls.Add(this.checkBox11);
		this.groupBox1.Controls.Add(this.checkBox7);
		this.groupBox1.Controls.Add(this.checkBox8);
		this.groupBox1.Controls.Add(this.checkBox9);
		this.groupBox1.Controls.Add(this.checkBox4);
		this.groupBox1.Controls.Add(this.checkBox5);
		this.groupBox1.Controls.Add(this.checkBox6);
		this.groupBox1.Controls.Add(this.checkBox3);
		this.groupBox1.Controls.Add(this.checkBox2);
		this.groupBox1.Controls.Add(this.checkBox1);
		this.groupBox1.Location = new System.Drawing.Point(16, 29);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(408, 643);
		this.groupBox1.TabIndex = 159;
		this.groupBox1.TabStop = false;
		this.checkBox25.AutoSize = true;
		this.checkBox25.Enabled = false;
		this.checkBox25.Location = new System.Drawing.Point(214, 594);
		this.checkBox25.Name = "checkBox25";
		this.checkBox25.Size = new System.Drawing.Size(133, 19);
		this.checkBox25.TabIndex = 152;
		this.checkBox25.Text = "Band13_Enable";
		this.checkBox25.UseVisualStyleBackColor = true;
		this.checkBox26.AutoSize = true;
		this.checkBox26.Location = new System.Drawing.Point(21, 594);
		this.checkBox26.Name = "checkBox26";
		this.checkBox26.Size = new System.Drawing.Size(133, 19);
		this.checkBox26.TabIndex = 151;
		this.checkBox26.Text = "Band13_Enable";
		this.checkBox26.UseVisualStyleBackColor = true;
		this.checkBox15.AutoSize = true;
		this.checkBox15.Location = new System.Drawing.Point(214, 454);
		this.checkBox15.Name = "checkBox15";
		this.checkBox15.Size = new System.Drawing.Size(133, 19);
		this.checkBox15.TabIndex = 148;
		this.checkBox15.Text = "Band10_Enable";
		this.checkBox15.UseVisualStyleBackColor = true;
		this.checkBox16.AutoSize = true;
		this.checkBox16.Location = new System.Drawing.Point(214, 404);
		this.checkBox16.Name = "checkBox16";
		this.checkBox16.Size = new System.Drawing.Size(125, 19);
		this.checkBox16.TabIndex = 147;
		this.checkBox16.Text = "Band9_Enable";
		this.checkBox16.UseVisualStyleBackColor = true;
		this.checkBox17.AutoSize = true;
		this.checkBox17.Location = new System.Drawing.Point(214, 355);
		this.checkBox17.Name = "checkBox17";
		this.checkBox17.Size = new System.Drawing.Size(125, 19);
		this.checkBox17.TabIndex = 146;
		this.checkBox17.Text = "Band8_Enable";
		this.checkBox17.UseVisualStyleBackColor = true;
		this.checkBox18.AutoSize = true;
		this.checkBox18.Location = new System.Drawing.Point(214, 306);
		this.checkBox18.Name = "checkBox18";
		this.checkBox18.Size = new System.Drawing.Size(125, 19);
		this.checkBox18.TabIndex = 145;
		this.checkBox18.Text = "Band6_Enable";
		this.checkBox18.UseVisualStyleBackColor = true;
		this.checkBox19.AutoSize = true;
		this.checkBox19.Location = new System.Drawing.Point(214, 257);
		this.checkBox19.Name = "checkBox19";
		this.checkBox19.Size = new System.Drawing.Size(125, 19);
		this.checkBox19.TabIndex = 144;
		this.checkBox19.Text = "Band6_Enable";
		this.checkBox19.UseVisualStyleBackColor = true;
		this.checkBox20.AutoSize = true;
		this.checkBox20.Location = new System.Drawing.Point(214, 208);
		this.checkBox20.Name = "checkBox20";
		this.checkBox20.Size = new System.Drawing.Size(125, 19);
		this.checkBox20.TabIndex = 143;
		this.checkBox20.Text = "Band5_Enable";
		this.checkBox20.UseVisualStyleBackColor = true;
		this.checkBox21.AutoSize = true;
		this.checkBox21.Location = new System.Drawing.Point(214, 159);
		this.checkBox21.Name = "checkBox21";
		this.checkBox21.Size = new System.Drawing.Size(125, 19);
		this.checkBox21.TabIndex = 142;
		this.checkBox21.Text = "Band4_Enable";
		this.checkBox21.UseVisualStyleBackColor = true;
		this.checkBox22.AutoSize = true;
		this.checkBox22.Location = new System.Drawing.Point(214, 110);
		this.checkBox22.Name = "checkBox22";
		this.checkBox22.Size = new System.Drawing.Size(125, 19);
		this.checkBox22.TabIndex = 141;
		this.checkBox22.Text = "Band3_Enable";
		this.checkBox22.UseVisualStyleBackColor = true;
		this.checkBox23.AutoSize = true;
		this.checkBox23.Enabled = false;
		this.checkBox23.Location = new System.Drawing.Point(214, 61);
		this.checkBox23.Name = "checkBox23";
		this.checkBox23.Size = new System.Drawing.Size(125, 19);
		this.checkBox23.TabIndex = 140;
		this.checkBox23.Text = "Band2_Enable";
		this.checkBox23.UseVisualStyleBackColor = true;
		this.checkBox13.AutoSize = true;
		this.checkBox13.Enabled = false;
		this.checkBox13.Location = new System.Drawing.Point(214, 547);
		this.checkBox13.Name = "checkBox13";
		this.checkBox13.Size = new System.Drawing.Size(133, 19);
		this.checkBox13.TabIndex = 150;
		this.checkBox13.Text = "Band12_Enable";
		this.checkBox13.UseVisualStyleBackColor = true;
		this.checkBox24.AutoSize = true;
		this.checkBox24.Enabled = false;
		this.checkBox24.Location = new System.Drawing.Point(214, 12);
		this.checkBox24.Name = "checkBox24";
		this.checkBox24.Size = new System.Drawing.Size(149, 19);
		this.checkBox24.TabIndex = 139;
		this.checkBox24.Text = "Band1_TX_Enable";
		this.checkBox24.UseVisualStyleBackColor = true;
		this.checkBox14.AutoSize = true;
		this.checkBox14.Enabled = false;
		this.checkBox14.Location = new System.Drawing.Point(214, 498);
		this.checkBox14.Name = "checkBox14";
		this.checkBox14.Size = new System.Drawing.Size(133, 19);
		this.checkBox14.TabIndex = 149;
		this.checkBox14.Text = "Band11_Enable";
		this.checkBox14.UseVisualStyleBackColor = true;
		this.checkBox10.AutoSize = true;
		this.checkBox10.Location = new System.Drawing.Point(21, 547);
		this.checkBox10.Name = "checkBox10";
		this.checkBox10.Size = new System.Drawing.Size(133, 19);
		this.checkBox10.TabIndex = 138;
		this.checkBox10.Text = "Band12_Enable";
		this.checkBox10.UseVisualStyleBackColor = true;
		this.checkBox12.AutoSize = true;
		this.checkBox12.Location = new System.Drawing.Point(21, 454);
		this.checkBox12.Name = "checkBox12";
		this.checkBox12.Size = new System.Drawing.Size(133, 19);
		this.checkBox12.TabIndex = 136;
		this.checkBox12.Text = "Band10_Enable";
		this.checkBox12.UseVisualStyleBackColor = true;
		this.checkBox11.AutoSize = true;
		this.checkBox11.Location = new System.Drawing.Point(21, 498);
		this.checkBox11.Name = "checkBox11";
		this.checkBox11.Size = new System.Drawing.Size(133, 19);
		this.checkBox11.TabIndex = 137;
		this.checkBox11.Text = "Band11_Enable";
		this.checkBox11.UseVisualStyleBackColor = true;
		this.checkBox7.AutoSize = true;
		this.checkBox7.Location = new System.Drawing.Point(21, 404);
		this.checkBox7.Name = "checkBox7";
		this.checkBox7.Size = new System.Drawing.Size(125, 19);
		this.checkBox7.TabIndex = 135;
		this.checkBox7.Text = "Band9_Enable";
		this.checkBox7.UseVisualStyleBackColor = true;
		this.checkBox8.AutoSize = true;
		this.checkBox8.Location = new System.Drawing.Point(21, 355);
		this.checkBox8.Name = "checkBox8";
		this.checkBox8.Size = new System.Drawing.Size(125, 19);
		this.checkBox8.TabIndex = 134;
		this.checkBox8.Text = "Band8_Enable";
		this.checkBox8.UseVisualStyleBackColor = true;
		this.checkBox9.AutoSize = true;
		this.checkBox9.Location = new System.Drawing.Point(21, 306);
		this.checkBox9.Name = "checkBox9";
		this.checkBox9.Size = new System.Drawing.Size(125, 19);
		this.checkBox9.TabIndex = 133;
		this.checkBox9.Text = "Band6_Enable";
		this.checkBox9.UseVisualStyleBackColor = true;
		this.checkBox4.AutoSize = true;
		this.checkBox4.Location = new System.Drawing.Point(21, 257);
		this.checkBox4.Name = "checkBox4";
		this.checkBox4.Size = new System.Drawing.Size(125, 19);
		this.checkBox4.TabIndex = 132;
		this.checkBox4.Text = "Band6_Enable";
		this.checkBox4.UseVisualStyleBackColor = true;
		this.checkBox5.AutoSize = true;
		this.checkBox5.Location = new System.Drawing.Point(21, 208);
		this.checkBox5.Name = "checkBox5";
		this.checkBox5.Size = new System.Drawing.Size(125, 19);
		this.checkBox5.TabIndex = 131;
		this.checkBox5.Text = "Band5_Enable";
		this.checkBox5.UseVisualStyleBackColor = true;
		this.checkBox6.AutoSize = true;
		this.checkBox6.Location = new System.Drawing.Point(21, 159);
		this.checkBox6.Name = "checkBox6";
		this.checkBox6.Size = new System.Drawing.Size(125, 19);
		this.checkBox6.TabIndex = 130;
		this.checkBox6.Text = "Band4_Enable";
		this.checkBox6.UseVisualStyleBackColor = true;
		this.checkBox3.AutoSize = true;
		this.checkBox3.Location = new System.Drawing.Point(21, 110);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(125, 19);
		this.checkBox3.TabIndex = 129;
		this.checkBox3.Text = "Band3_Enable";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox2.AutoSize = true;
		this.checkBox2.Location = new System.Drawing.Point(21, 61);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(125, 19);
		this.checkBox2.TabIndex = 128;
		this.checkBox2.Text = "Band2_Enable";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(21, 12);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(125, 19);
		this.checkBox1.TabIndex = 127;
		this.checkBox1.Text = "Band1_Enable";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.tabPage7.Controls.Add(this.comboBox43);
		this.tabPage7.Controls.Add(this.label47);
		this.tabPage7.Controls.Add(this.comboBox42);
		this.tabPage7.Controls.Add(this.label46);
		this.tabPage7.Controls.Add(this.textBox4);
		this.tabPage7.Controls.Add(this.label45);
		this.tabPage7.Location = new System.Drawing.Point(4, 25);
		this.tabPage7.Name = "tabPage7";
		this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage7.Size = new System.Drawing.Size(1024, 685);
		this.tabPage7.TabIndex = 6;
		this.tabPage7.Text = "收音机";
		this.tabPage7.UseVisualStyleBackColor = true;
		this.comboBox43.FormattingEnabled = true;
		this.comboBox43.Location = new System.Drawing.Point(156, 139);
		this.comboBox43.Name = "comboBox43";
		this.comboBox43.Size = new System.Drawing.Size(121, 23);
		this.comboBox43.TabIndex = 87;
		this.label47.Location = new System.Drawing.Point(13, 137);
		this.label47.Name = "label47";
		this.label47.Size = new System.Drawing.Size(135, 23);
		this.label47.TabIndex = 86;
		this.label47.Text = "信道号";
		this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox42.FormattingEnabled = true;
		this.comboBox42.Location = new System.Drawing.Point(156, 85);
		this.comboBox42.Name = "comboBox42";
		this.comboBox42.Size = new System.Drawing.Size(121, 23);
		this.comboBox42.TabIndex = 85;
		this.label46.Location = new System.Drawing.Point(13, 86);
		this.label46.Name = "label46";
		this.label46.Size = new System.Drawing.Size(135, 23);
		this.label46.TabIndex = 84;
		this.label46.Text = "信道模式";
		this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.textBox4.Location = new System.Drawing.Point(156, 33);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(118, 25);
		this.textBox4.TabIndex = 83;
		this.label45.Location = new System.Drawing.Point(49, 35);
		this.label45.Name = "label45";
		this.label45.Size = new System.Drawing.Size(99, 23);
		this.label45.TabIndex = 82;
		this.label45.Text = "VFO频率";
		this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.tabPage6.Controls.Add(this.comboBox28);
		this.tabPage6.Controls.Add(this.label1);
		this.tabPage6.Controls.Add(this.label28);
		this.tabPage6.Controls.Add(this.comboBox29);
		this.tabPage6.Controls.Add(this.comboBox1);
		this.tabPage6.Controls.Add(this.label29);
		this.tabPage6.Controls.Add(this.comboBox10);
		this.tabPage6.Controls.Add(this.comboBox27);
		this.tabPage6.Controls.Add(this.label27);
		this.tabPage6.Controls.Add(this.label8);
		this.tabPage6.Controls.Add(this.comboBox8);
		this.tabPage6.Controls.Add(this.comboBox25);
		this.tabPage6.Controls.Add(this.label25);
		this.tabPage6.Controls.Add(this.comboBox26);
		this.tabPage6.Controls.Add(this.label26);
		this.tabPage6.Controls.Add(this.comboBox23);
		this.tabPage6.Controls.Add(this.label23);
		this.tabPage6.Controls.Add(this.label9);
		this.tabPage6.Controls.Add(this.comboBox9);
		this.tabPage6.Controls.Add(this.label10);
		this.tabPage6.Controls.Add(this.comboBox24);
		this.tabPage6.Controls.Add(this.label24);
		this.tabPage6.Controls.Add(this.label14);
		this.tabPage6.Controls.Add(this.comboBox12);
		this.tabPage6.Controls.Add(this.label12);
		this.tabPage6.Controls.Add(this.comboBox14);
		this.tabPage6.Location = new System.Drawing.Point(4, 25);
		this.tabPage6.Name = "tabPage6";
		this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage6.Size = new System.Drawing.Size(1024, 685);
		this.tabPage6.TabIndex = 5;
		this.tabPage6.Text = "信道设置";
		this.tabPage6.UseVisualStyleBackColor = true;
		this.tabPage6.Click += new System.EventHandler(tabPage6_Click);
		this.comboBox28.FormattingEnabled = true;
		this.comboBox28.Location = new System.Drawing.Point(266, 56);
		this.comboBox28.Name = "comboBox28";
		this.comboBox28.Size = new System.Drawing.Size(121, 23);
		this.comboBox28.TabIndex = 55;
		this.label1.Location = new System.Drawing.Point(24, 15);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(239, 23);
		this.label1.TabIndex = 0;
		this.label1.Text = "当前信道位置";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label28.Location = new System.Drawing.Point(24, 60);
		this.label28.Name = "label28";
		this.label28.Size = new System.Drawing.Size(239, 23);
		this.label28.TabIndex = 54;
		this.label28.Text = "A信道音量";
		this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox29.FormattingEnabled = true;
		this.comboBox29.Location = new System.Drawing.Point(654, 129);
		this.comboBox29.Name = "comboBox29";
		this.comboBox29.Size = new System.Drawing.Size(121, 23);
		this.comboBox29.TabIndex = 57;
		this.comboBox29.Visible = false;
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Location = new System.Drawing.Point(266, 15);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(121, 23);
		this.comboBox1.TabIndex = 1;
		this.label29.Location = new System.Drawing.Point(514, 133);
		this.label29.Name = "label29";
		this.label29.Size = new System.Drawing.Size(137, 19);
		this.label29.TabIndex = 56;
		this.label29.Text = "B信道音量";
		this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label29.Visible = false;
		this.comboBox10.FormattingEnabled = true;
		this.comboBox10.Location = new System.Drawing.Point(613, 236);
		this.comboBox10.Name = "comboBox10";
		this.comboBox10.Size = new System.Drawing.Size(121, 23);
		this.comboBox10.TabIndex = 19;
		this.comboBox10.Visible = false;
		this.comboBox27.FormattingEnabled = true;
		this.comboBox27.Location = new System.Drawing.Point(266, 454);
		this.comboBox27.Name = "comboBox27";
		this.comboBox27.Size = new System.Drawing.Size(121, 23);
		this.comboBox27.TabIndex = 53;
		this.label27.Location = new System.Drawing.Point(24, 453);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(239, 23);
		this.label27.TabIndex = 52;
		this.label27.Text = "变调开关";
		this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label8.Location = new System.Drawing.Point(24, 103);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(239, 23);
		this.label8.TabIndex = 14;
		this.label8.Text = "VFO开关";
		this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox8.FormattingEnabled = true;
		this.comboBox8.Location = new System.Drawing.Point(266, 103);
		this.comboBox8.Name = "comboBox8";
		this.comboBox8.Size = new System.Drawing.Size(121, 23);
		this.comboBox8.TabIndex = 15;
		this.comboBox25.FormattingEnabled = true;
		this.comboBox25.Location = new System.Drawing.Point(266, 278);
		this.comboBox25.Name = "comboBox25";
		this.comboBox25.Size = new System.Drawing.Size(121, 23);
		this.comboBox25.TabIndex = 49;
		this.label25.Location = new System.Drawing.Point(24, 277);
		this.label25.Name = "label25";
		this.label25.Size = new System.Drawing.Size(239, 23);
		this.label25.TabIndex = 48;
		this.label25.Text = "尾音消除";
		this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox26.FormattingEnabled = true;
		this.comboBox26.Location = new System.Drawing.Point(266, 410);
		this.comboBox26.Name = "comboBox26";
		this.comboBox26.Size = new System.Drawing.Size(121, 23);
		this.comboBox26.TabIndex = 51;
		this.label26.Location = new System.Drawing.Point(24, 407);
		this.label26.Name = "label26";
		this.label26.Size = new System.Drawing.Size(239, 23);
		this.label26.TabIndex = 50;
		this.label26.Text = "降噪开关";
		this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox23.FormattingEnabled = true;
		this.comboBox23.Location = new System.Drawing.Point(266, 366);
		this.comboBox23.Name = "comboBox23";
		this.comboBox23.Size = new System.Drawing.Size(121, 23);
		this.comboBox23.TabIndex = 45;
		this.label23.Location = new System.Drawing.Point(24, 364);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(239, 23);
		this.label23.TabIndex = 44;
		this.label23.Text = "通话结束音";
		this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label9.Location = new System.Drawing.Point(24, 146);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(239, 23);
		this.label9.TabIndex = 16;
		this.label9.Text = "信道显示类型";
		this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label9.Click += new System.EventHandler(label9_Click);
		this.comboBox9.FormattingEnabled = true;
		this.comboBox9.Location = new System.Drawing.Point(266, 147);
		this.comboBox9.Name = "comboBox9";
		this.comboBox9.Size = new System.Drawing.Size(121, 23);
		this.comboBox9.TabIndex = 17;
		this.comboBox9.SelectedIndexChanged += new System.EventHandler(comboBox9_SelectedIndexChanged);
		this.label10.Location = new System.Drawing.Point(473, 236);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(137, 23);
		this.label10.TabIndex = 18;
		this.label10.Text = "发射信道";
		this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label10.Visible = false;
		this.comboBox24.FormattingEnabled = true;
		this.comboBox24.Location = new System.Drawing.Point(266, 190);
		this.comboBox24.Name = "comboBox24";
		this.comboBox24.Size = new System.Drawing.Size(121, 23);
		this.comboBox24.TabIndex = 47;
		this.label24.Location = new System.Drawing.Point(24, 191);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(239, 23);
		this.label24.TabIndex = 46;
		this.label24.Text = "中继尾音消除";
		this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label14.Location = new System.Drawing.Point(24, 234);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(239, 23);
		this.label14.TabIndex = 26;
		this.label14.Text = "即呼信道";
		this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox12.FormattingEnabled = true;
		this.comboBox12.Location = new System.Drawing.Point(266, 322);
		this.comboBox12.Name = "comboBox12";
		this.comboBox12.Size = new System.Drawing.Size(121, 23);
		this.comboBox12.TabIndex = 23;
		this.label12.Location = new System.Drawing.Point(24, 322);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(239, 23);
		this.label12.TabIndex = 22;
		this.label12.Text = "双守候";
		this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox14.FormattingEnabled = true;
		this.comboBox14.Location = new System.Drawing.Point(266, 234);
		this.comboBox14.Name = "comboBox14";
		this.comboBox14.Size = new System.Drawing.Size(121, 23);
		this.comboBox14.TabIndex = 27;
		this.tabPage5.Controls.Add(this.Nud_cw);
		this.tabPage5.Controls.Add(this.lab_cw);
		this.tabPage5.Controls.Add(this.cmb_brightness);
		this.tabPage5.Controls.Add(this.lab_brightness);
		this.tabPage5.Controls.Add(this.cmb_MwSw);
		this.tabPage5.Controls.Add(this.lab_MwSw);
		this.tabPage5.Controls.Add(this.comboBox30);
		this.tabPage5.Controls.Add(this.label30);
		this.tabPage5.Controls.Add(this.label35);
		this.tabPage5.Controls.Add(this.comboBox35);
		this.tabPage5.Controls.Add(this.label50);
		this.tabPage5.Controls.Add(this.comboBox46);
		this.tabPage5.Controls.Add(this.comboBox45);
		this.tabPage5.Controls.Add(this.label49);
		this.tabPage5.Controls.Add(this.comboBox44);
		this.tabPage5.Controls.Add(this.label48);
		this.tabPage5.Controls.Add(this.comboBox3);
		this.tabPage5.Controls.Add(this.comboBox41);
		this.tabPage5.Controls.Add(this.label44);
		this.tabPage5.Controls.Add(this.comboBox36);
		this.tabPage5.Controls.Add(this.label36);
		this.tabPage5.Controls.Add(this.comboBox20);
		this.tabPage5.Controls.Add(this.label20);
		this.tabPage5.Controls.Add(this.label3);
		this.tabPage5.Controls.Add(this.comboBox13);
		this.tabPage5.Controls.Add(this.label13);
		this.tabPage5.Controls.Add(this.comboBox6);
		this.tabPage5.Controls.Add(this.comboBox11);
		this.tabPage5.Controls.Add(this.label11);
		this.tabPage5.Controls.Add(this.label6);
		this.tabPage5.Controls.Add(this.label7);
		this.tabPage5.Controls.Add(this.comboBox7);
		this.tabPage5.Controls.Add(this.label15);
		this.tabPage5.Controls.Add(this.comboBox15);
		this.tabPage5.Location = new System.Drawing.Point(4, 25);
		this.tabPage5.Name = "tabPage5";
		this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage5.Size = new System.Drawing.Size(1024, 685);
		this.tabPage5.TabIndex = 4;
		this.tabPage5.Text = "通用设置";
		this.tabPage5.UseVisualStyleBackColor = true;
		this.tabPage5.Leave += new System.EventHandler(tabPage5_Leave);
		this.Nud_cw.Increment = new decimal(new int[4] { 10, 0, 0, 0 });
		this.Nud_cw.Location = new System.Drawing.Point(486, 56);
		this.Nud_cw.Maximum = new decimal(new int[4] { 1500, 0, 0, 0 });
		this.Nud_cw.Minimum = new decimal(new int[4] { 400, 0, 0, 0 });
		this.Nud_cw.Name = "Nud_cw";
		this.Nud_cw.Size = new System.Drawing.Size(121, 25);
		this.Nud_cw.TabIndex = 169;
		this.Nud_cw.Value = new decimal(new int[4] { 400, 0, 0, 0 });
		this.Nud_cw.Leave += new System.EventHandler(Nud_cw_Leave);
		this.lab_cw.Location = new System.Drawing.Point(307, 59);
		this.lab_cw.Name = "lab_cw";
		this.lab_cw.Size = new System.Drawing.Size(171, 22);
		this.lab_cw.TabIndex = 168;
		this.lab_cw.Text = "CW模式下频率偏移";
		this.lab_cw.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cmb_brightness.FormattingEnabled = true;
		this.cmb_brightness.Location = new System.Drawing.Point(486, 12);
		this.cmb_brightness.Name = "cmb_brightness";
		this.cmb_brightness.Size = new System.Drawing.Size(121, 23);
		this.cmb_brightness.TabIndex = 167;
		this.lab_brightness.Location = new System.Drawing.Point(343, 13);
		this.lab_brightness.Name = "lab_brightness";
		this.lab_brightness.Size = new System.Drawing.Size(135, 22);
		this.lab_brightness.TabIndex = 166;
		this.lab_brightness.Text = "亮屏时长";
		this.lab_brightness.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cmb_MwSw.FormattingEnabled = true;
		this.cmb_MwSw.Location = new System.Drawing.Point(168, 616);
		this.cmb_MwSw.Name = "cmb_MwSw";
		this.cmb_MwSw.Size = new System.Drawing.Size(121, 23);
		this.cmb_MwSw.TabIndex = 165;
		this.lab_MwSw.Location = new System.Drawing.Point(25, 617);
		this.lab_MwSw.Name = "lab_MwSw";
		this.lab_MwSw.Size = new System.Drawing.Size(135, 22);
		this.lab_MwSw.TabIndex = 164;
		this.lab_MwSw.Text = "MwSw AGC控制开关";
		this.lab_MwSw.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox30.FormattingEnabled = true;
		this.comboBox30.Location = new System.Drawing.Point(168, 567);
		this.comboBox30.Name = "comboBox30";
		this.comboBox30.Size = new System.Drawing.Size(121, 23);
		this.comboBox30.TabIndex = 163;
		this.label30.Location = new System.Drawing.Point(25, 568);
		this.label30.Name = "label30";
		this.label30.Size = new System.Drawing.Size(135, 22);
		this.label30.TabIndex = 162;
		this.label30.Text = "按键音";
		this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label35.Location = new System.Drawing.Point(6, 523);
		this.label35.Name = "label35";
		this.label35.Size = new System.Drawing.Size(156, 15);
		this.label35.TabIndex = 160;
		this.label35.Text = "Sbar";
		this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox35.FormattingEnabled = true;
		this.comboBox35.Location = new System.Drawing.Point(168, 518);
		this.comboBox35.Name = "comboBox35";
		this.comboBox35.Size = new System.Drawing.Size(121, 23);
		this.comboBox35.TabIndex = 161;
		this.label50.Location = new System.Drawing.Point(5, 474);
		this.label50.Name = "label50";
		this.label50.Size = new System.Drawing.Size(157, 22);
		this.label50.TabIndex = 159;
		this.label50.Text = "解码响应";
		this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox46.FormattingEnabled = true;
		this.comboBox46.Location = new System.Drawing.Point(168, 474);
		this.comboBox46.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox46.Name = "comboBox46";
		this.comboBox46.Size = new System.Drawing.Size(123, 23);
		this.comboBox46.TabIndex = 158;
		this.comboBox45.FormattingEnabled = true;
		this.comboBox45.Location = new System.Drawing.Point(168, 430);
		this.comboBox45.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox45.Name = "comboBox45";
		this.comboBox45.Size = new System.Drawing.Size(123, 23);
		this.comboBox45.TabIndex = 157;
		this.label49.Location = new System.Drawing.Point(5, 431);
		this.label49.Name = "label49";
		this.label49.Size = new System.Drawing.Size(157, 22);
		this.label49.TabIndex = 156;
		this.label49.Text = "侧音";
		this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox44.FormattingEnabled = true;
		this.comboBox44.Location = new System.Drawing.Point(168, 385);
		this.comboBox44.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox44.Name = "comboBox44";
		this.comboBox44.Size = new System.Drawing.Size(123, 23);
		this.comboBox44.TabIndex = 150;
		this.label48.Location = new System.Drawing.Point(9, 385);
		this.label48.Name = "label48";
		this.label48.Size = new System.Drawing.Size(153, 22);
		this.label48.TabIndex = 149;
		this.label48.Text = "摇毙/激活解码";
		this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox3.FormattingEnabled = true;
		this.comboBox3.Location = new System.Drawing.Point(170, 11);
		this.comboBox3.Name = "comboBox3";
		this.comboBox3.Size = new System.Drawing.Size(121, 23);
		this.comboBox3.TabIndex = 5;
		this.comboBox41.FormattingEnabled = true;
		this.comboBox41.Location = new System.Drawing.Point(168, 337);
		this.comboBox41.Name = "comboBox41";
		this.comboBox41.Size = new System.Drawing.Size(121, 23);
		this.comboBox41.TabIndex = 87;
		this.label44.Location = new System.Drawing.Point(90, 341);
		this.label44.Name = "label44";
		this.label44.Size = new System.Drawing.Size(69, 15);
		this.label44.TabIndex = 86;
		this.label44.Text = "报警方式";
		this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox36.FormattingEnabled = true;
		this.comboBox36.Location = new System.Drawing.Point(715, 414);
		this.comboBox36.Name = "comboBox36";
		this.comboBox36.Size = new System.Drawing.Size(121, 23);
		this.comboBox36.TabIndex = 71;
		this.comboBox36.Visible = false;
		this.label36.Location = new System.Drawing.Point(553, 417);
		this.label36.Name = "label36";
		this.label36.Size = new System.Drawing.Size(156, 15);
		this.label36.TabIndex = 70;
		this.label36.Text = "信令系统";
		this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label36.Visible = false;
		this.comboBox20.FormattingEnabled = true;
		this.comboBox20.Location = new System.Drawing.Point(168, 290);
		this.comboBox20.Name = "comboBox20";
		this.comboBox20.Size = new System.Drawing.Size(121, 23);
		this.comboBox20.TabIndex = 39;
		this.label20.Location = new System.Drawing.Point(72, 295);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(90, 15);
		this.label20.TabIndex = 38;
		this.label20.Text = "扫描方式";
		this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label3.Location = new System.Drawing.Point(30, 11);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(137, 23);
		this.label3.TabIndex = 4;
		this.label3.Text = "TOT";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox13.FormattingEnabled = true;
		this.comboBox13.Location = new System.Drawing.Point(168, 243);
		this.comboBox13.Name = "comboBox13";
		this.comboBox13.Size = new System.Drawing.Size(121, 23);
		this.comboBox13.TabIndex = 25;
		this.label13.Location = new System.Drawing.Point(48, 248);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(114, 15);
		this.label13.TabIndex = 24;
		this.label13.Text = "自动背光模式";
		this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox6.FormattingEnabled = true;
		this.comboBox6.Location = new System.Drawing.Point(168, 55);
		this.comboBox6.Name = "comboBox6";
		this.comboBox6.Size = new System.Drawing.Size(121, 23);
		this.comboBox6.TabIndex = 11;
		this.comboBox11.FormattingEnabled = true;
		this.comboBox11.Location = new System.Drawing.Point(168, 196);
		this.comboBox11.Name = "comboBox11";
		this.comboBox11.Size = new System.Drawing.Size(121, 23);
		this.comboBox11.TabIndex = 21;
		this.label11.Location = new System.Drawing.Point(56, 201);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(106, 15);
		this.label11.TabIndex = 20;
		this.label11.Text = "省电开关";
		this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label6.Location = new System.Drawing.Point(30, 57);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(135, 23);
		this.label6.TabIndex = 10;
		this.label6.Text = "VOX";
		this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label7.Location = new System.Drawing.Point(30, 103);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(135, 23);
		this.label7.TabIndex = 12;
		this.label7.Text = "MIC";
		this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox7.FormattingEnabled = true;
		this.comboBox7.Location = new System.Drawing.Point(168, 102);
		this.comboBox7.Name = "comboBox7";
		this.comboBox7.Size = new System.Drawing.Size(121, 23);
		this.comboBox7.TabIndex = 13;
		this.label15.Location = new System.Drawing.Point(30, 148);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(135, 23);
		this.label15.TabIndex = 28;
		this.label15.Text = "beep";
		this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox15.FormattingEnabled = true;
		this.comboBox15.Location = new System.Drawing.Point(168, 149);
		this.comboBox15.Name = "comboBox15";
		this.comboBox15.Size = new System.Drawing.Size(121, 23);
		this.comboBox15.TabIndex = 29;
		this.tabPage4.Controls.Add(this.comboBox37);
		this.tabPage4.Controls.Add(this.label37);
		this.tabPage4.Controls.Add(this.label38);
		this.tabPage4.Controls.Add(this.comboBox38);
		this.tabPage4.Controls.Add(this.label39);
		this.tabPage4.Controls.Add(this.comboBox40);
		this.tabPage4.Controls.Add(this.comboBox39);
		this.tabPage4.Controls.Add(this.label40);
		this.tabPage4.Location = new System.Drawing.Point(4, 25);
		this.tabPage4.Name = "tabPage4";
		this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage4.Size = new System.Drawing.Size(1024, 685);
		this.tabPage4.TabIndex = 3;
		this.tabPage4.Text = "对频";
		this.tabPage4.UseVisualStyleBackColor = true;
		this.comboBox37.FormattingEnabled = true;
		this.comboBox37.Location = new System.Drawing.Point(162, 22);
		this.comboBox37.Name = "comboBox37";
		this.comboBox37.Size = new System.Drawing.Size(121, 23);
		this.comboBox37.TabIndex = 73;
		this.comboBox37.SelectedIndexChanged += new System.EventHandler(comboBox37_SelectedIndexChanged);
		this.label37.Location = new System.Drawing.Point(6, 30);
		this.label37.Name = "label37";
		this.label37.Size = new System.Drawing.Size(150, 15);
		this.label37.TabIndex = 72;
		this.label37.Text = "对频超时";
		this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label38.Location = new System.Drawing.Point(6, 79);
		this.label38.Name = "label38";
		this.label38.Size = new System.Drawing.Size(150, 15);
		this.label38.TabIndex = 74;
		this.label38.Text = "对频亚音模式";
		this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox38.FormattingEnabled = true;
		this.comboBox38.Location = new System.Drawing.Point(162, 72);
		this.comboBox38.Name = "comboBox38";
		this.comboBox38.Size = new System.Drawing.Size(121, 23);
		this.comboBox38.TabIndex = 75;
		this.label39.Location = new System.Drawing.Point(6, 128);
		this.label39.Name = "label39";
		this.label39.Size = new System.Drawing.Size(150, 15);
		this.label39.TabIndex = 76;
		this.label39.Text = "数字亚音";
		this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox40.FormattingEnabled = true;
		this.comboBox40.Location = new System.Drawing.Point(162, 170);
		this.comboBox40.Name = "comboBox40";
		this.comboBox40.Size = new System.Drawing.Size(121, 23);
		this.comboBox40.TabIndex = 79;
		this.comboBox39.FormattingEnabled = true;
		this.comboBox39.Location = new System.Drawing.Point(162, 121);
		this.comboBox39.Name = "comboBox39";
		this.comboBox39.Size = new System.Drawing.Size(121, 23);
		this.comboBox39.TabIndex = 77;
		this.label40.Location = new System.Drawing.Point(3, 178);
		this.label40.Name = "label40";
		this.label40.Size = new System.Drawing.Size(150, 15);
		this.label40.TabIndex = 78;
		this.label40.Text = "亚音检测门限";
		this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.tabPage3.Controls.Add(this.lab_self_noaa_event);
		this.tabPage3.Controls.Add(this.dgv_noaa_event);
		this.tabPage3.Controls.Add(this.label32);
		this.tabPage3.Controls.Add(this.comboBox32);
		this.tabPage3.Controls.Add(this.label33);
		this.tabPage3.Controls.Add(this.comboBox4);
		this.tabPage3.Controls.Add(this.label4);
		this.tabPage3.Controls.Add(this.comboBox2);
		this.tabPage3.Controls.Add(this.label2);
		this.tabPage3.Controls.Add(this.comboBox33);
		this.tabPage3.Controls.Add(this.label34);
		this.tabPage3.Controls.Add(this.comboBox34);
		this.tabPage3.Location = new System.Drawing.Point(4, 25);
		this.tabPage3.Name = "tabPage3";
		this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage3.Size = new System.Drawing.Size(1024, 685);
		this.tabPage3.TabIndex = 2;
		this.tabPage3.Text = "NOAA SAME";
		this.tabPage3.UseVisualStyleBackColor = true;
		this.tabPage3.Click += new System.EventHandler(tabPage3_Click);
		this.lab_self_noaa_event.Location = new System.Drawing.Point(400, 264);
		this.lab_self_noaa_event.Name = "lab_self_noaa_event";
		this.lab_self_noaa_event.Size = new System.Drawing.Size(232, 39);
		this.lab_self_noaa_event.TabIndex = 69;
		this.lab_self_noaa_event.Text = "自定义NOAA事件开关";
		this.lab_self_noaa_event.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.dgv_noaa_event.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv_noaa_event.Location = new System.Drawing.Point(36, 306);
		this.dgv_noaa_event.Name = "dgv_noaa_event";
		this.dgv_noaa_event.RowTemplate.Height = 27;
		this.dgv_noaa_event.Size = new System.Drawing.Size(956, 364);
		this.dgv_noaa_event.TabIndex = 68;
		this.label32.Location = new System.Drawing.Point(11, 36);
		this.label32.Name = "label32";
		this.label32.Size = new System.Drawing.Size(156, 15);
		this.label32.TabIndex = 62;
		this.label32.Text = "NOAA SAME解码";
		this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox32.FormattingEnabled = true;
		this.comboBox32.Location = new System.Drawing.Point(173, 34);
		this.comboBox32.Name = "comboBox32";
		this.comboBox32.Size = new System.Drawing.Size(121, 23);
		this.comboBox32.TabIndex = 63;
		this.label33.Location = new System.Drawing.Point(11, 86);
		this.label33.Name = "label33";
		this.label33.Size = new System.Drawing.Size(156, 15);
		this.label33.TabIndex = 64;
		this.label33.Text = "NOAA SAME事件";
		this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox4.FormattingEnabled = true;
		this.comboBox4.Location = new System.Drawing.Point(173, 231);
		this.comboBox4.Name = "comboBox4";
		this.comboBox4.Size = new System.Drawing.Size(121, 23);
		this.comboBox4.TabIndex = 7;
		this.label4.Location = new System.Drawing.Point(33, 232);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(137, 23);
		this.label4.TabIndex = 6;
		this.label4.Text = "NOAA扫描";
		this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Location = new System.Drawing.Point(173, 185);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(121, 23);
		this.comboBox2.TabIndex = 3;
		this.label2.Location = new System.Drawing.Point(33, 187);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(137, 23);
		this.label2.TabIndex = 2;
		this.label2.Text = "SQ";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox33.FormattingEnabled = true;
		this.comboBox33.Location = new System.Drawing.Point(173, 83);
		this.comboBox33.Name = "comboBox33";
		this.comboBox33.Size = new System.Drawing.Size(121, 23);
		this.comboBox33.TabIndex = 65;
		this.label34.Location = new System.Drawing.Point(11, 136);
		this.label34.Name = "label34";
		this.label34.Size = new System.Drawing.Size(156, 15);
		this.label34.TabIndex = 66;
		this.label34.Text = "NOAA SAME地址";
		this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox34.FormattingEnabled = true;
		this.comboBox34.Location = new System.Drawing.Point(173, 132);
		this.comboBox34.Name = "comboBox34";
		this.comboBox34.Size = new System.Drawing.Size(121, 23);
		this.comboBox34.TabIndex = 67;
		this.tabPage2.Controls.Add(this.label17);
		this.tabPage2.Controls.Add(this.label16);
		this.tabPage2.Controls.Add(this.comboBox16);
		this.tabPage2.Controls.Add(this.comboBox17);
		this.tabPage2.Controls.Add(this.label18);
		this.tabPage2.Controls.Add(this.comboBox18);
		this.tabPage2.Controls.Add(this.label19);
		this.tabPage2.Controls.Add(this.comboBox19);
		this.tabPage2.Controls.Add(this.comboBox5);
		this.tabPage2.Controls.Add(this.label5);
		this.tabPage2.Controls.Add(this.comboBox21);
		this.tabPage2.Controls.Add(this.label21);
		this.tabPage2.Location = new System.Drawing.Point(4, 25);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(1024, 685);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "按键设置";
		this.tabPage2.UseVisualStyleBackColor = true;
		this.tabPage2.Click += new System.EventHandler(tabPage2_Click);
		this.label17.Location = new System.Drawing.Point(16, 77);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(219, 15);
		this.label17.TabIndex = 32;
		this.label17.Text = "侧键1长按";
		this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label16.Location = new System.Drawing.Point(3, 27);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(231, 15);
		this.label16.TabIndex = 30;
		this.label16.Text = "侧键1短按";
		this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox16.FormattingEnabled = true;
		this.comboBox16.Location = new System.Drawing.Point(243, 24);
		this.comboBox16.Name = "comboBox16";
		this.comboBox16.Size = new System.Drawing.Size(121, 23);
		this.comboBox16.TabIndex = 31;
		this.comboBox17.FormattingEnabled = true;
		this.comboBox17.Location = new System.Drawing.Point(243, 73);
		this.comboBox17.Name = "comboBox17";
		this.comboBox17.Size = new System.Drawing.Size(121, 23);
		this.comboBox17.TabIndex = 33;
		this.label18.Location = new System.Drawing.Point(19, 126);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(216, 15);
		this.label18.TabIndex = 34;
		this.label18.Text = "侧键2短按";
		this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox18.FormattingEnabled = true;
		this.comboBox18.Location = new System.Drawing.Point(243, 122);
		this.comboBox18.Name = "comboBox18";
		this.comboBox18.Size = new System.Drawing.Size(121, 23);
		this.comboBox18.TabIndex = 35;
		this.label19.Location = new System.Drawing.Point(22, 174);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(213, 15);
		this.label19.TabIndex = 36;
		this.label19.Text = "侧键2长按";
		this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox19.FormattingEnabled = true;
		this.comboBox19.Location = new System.Drawing.Point(243, 171);
		this.comboBox19.Name = "comboBox19";
		this.comboBox19.Size = new System.Drawing.Size(121, 23);
		this.comboBox19.TabIndex = 37;
		this.comboBox5.FormattingEnabled = true;
		this.comboBox5.Location = new System.Drawing.Point(243, 221);
		this.comboBox5.Name = "comboBox5";
		this.comboBox5.Size = new System.Drawing.Size(121, 23);
		this.comboBox5.TabIndex = 9;
		this.label5.Location = new System.Drawing.Point(89, 221);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(142, 15);
		this.label5.TabIndex = 8;
		this.label5.Text = "按键锁";
		this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox21.FormattingEnabled = true;
		this.comboBox21.Location = new System.Drawing.Point(243, 270);
		this.comboBox21.Name = "comboBox21";
		this.comboBox21.Size = new System.Drawing.Size(121, 23);
		this.comboBox21.TabIndex = 41;
		this.label21.Location = new System.Drawing.Point(92, 270);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(142, 15);
		this.label21.TabIndex = 40;
		this.label21.Text = "自动上锁";
		this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.tabPage1.Controls.Add(this.cmb_B_mode);
		this.tabPage1.Controls.Add(this.lab_B_mode);
		this.tabPage1.Controls.Add(this.cmb_A_mode);
		this.tabPage1.Controls.Add(this.lab_A_mode);
		this.tabPage1.Controls.Add(this.txt_password);
		this.tabPage1.Controls.Add(this.textBox1);
		this.tabPage1.Controls.Add(this.textBox2);
		this.tabPage1.Controls.Add(this.textBox3);
		this.tabPage1.Controls.Add(this.lab_bootpassword);
		this.tabPage1.Controls.Add(this.label41);
		this.tabPage1.Controls.Add(this.label42);
		this.tabPage1.Controls.Add(this.label43);
		this.tabPage1.Controls.Add(this.comboBox22);
		this.tabPage1.Controls.Add(this.lab_bootscreen);
		this.tabPage1.Controls.Add(this.comboBox31);
		this.tabPage1.Controls.Add(this.label31);
		this.tabPage1.Location = new System.Drawing.Point(4, 25);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(1024, 685);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "开机设置";
		this.tabPage1.UseVisualStyleBackColor = true;
		this.cmb_B_mode.FormattingEnabled = true;
		this.cmb_B_mode.Location = new System.Drawing.Point(139, 329);
		this.cmb_B_mode.Name = "cmb_B_mode";
		this.cmb_B_mode.Size = new System.Drawing.Size(121, 23);
		this.cmb_B_mode.TabIndex = 91;
		this.lab_B_mode.Location = new System.Drawing.Point(-1, 328);
		this.lab_B_mode.Name = "lab_B_mode";
		this.lab_B_mode.Size = new System.Drawing.Size(137, 23);
		this.lab_B_mode.TabIndex = 90;
		this.lab_B_mode.Text = "B段_显示";
		this.lab_B_mode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cmb_A_mode.FormattingEnabled = true;
		this.cmb_A_mode.Location = new System.Drawing.Point(139, 282);
		this.cmb_A_mode.Name = "cmb_A_mode";
		this.cmb_A_mode.Size = new System.Drawing.Size(121, 23);
		this.cmb_A_mode.TabIndex = 89;
		this.lab_A_mode.Location = new System.Drawing.Point(-1, 281);
		this.lab_A_mode.Name = "lab_A_mode";
		this.lab_A_mode.Size = new System.Drawing.Size(137, 23);
		this.lab_A_mode.TabIndex = 88;
		this.lab_A_mode.Text = "A段_显示";
		this.lab_A_mode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.txt_password.Location = new System.Drawing.Point(139, 229);
		this.txt_password.Name = "txt_password";
		this.txt_password.Size = new System.Drawing.Size(118, 25);
		this.txt_password.TabIndex = 87;
		this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_password_KeyPress);
		this.textBox1.Location = new System.Drawing.Point(139, 27);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(118, 25);
		this.textBox1.TabIndex = 81;
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.textBox2.Location = new System.Drawing.Point(139, 78);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(118, 25);
		this.textBox2.TabIndex = 83;
		this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.textBox3.Location = new System.Drawing.Point(139, 128);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(118, 25);
		this.textBox3.TabIndex = 85;
		this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.lab_bootpassword.Location = new System.Drawing.Point(6, 229);
		this.lab_bootpassword.Name = "lab_bootpassword";
		this.lab_bootpassword.Size = new System.Drawing.Size(126, 23);
		this.lab_bootpassword.TabIndex = 86;
		this.lab_bootpassword.Text = "开机密码";
		this.lab_bootpassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label41.Location = new System.Drawing.Point(33, 27);
		this.label41.Name = "label41";
		this.label41.Size = new System.Drawing.Size(99, 23);
		this.label41.TabIndex = 80;
		this.label41.Text = "设备名称";
		this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label42.Location = new System.Drawing.Point(33, 75);
		this.label42.Name = "label42";
		this.label42.Size = new System.Drawing.Size(99, 23);
		this.label42.TabIndex = 82;
		this.label42.Text = "开机字符1";
		this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label43.Location = new System.Drawing.Point(33, 126);
		this.label43.Name = "label43";
		this.label43.Size = new System.Drawing.Size(99, 23);
		this.label43.TabIndex = 84;
		this.label43.Text = "开机字符2";
		this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox22.FormattingEnabled = true;
		this.comboBox22.Location = new System.Drawing.Point(139, 177);
		this.comboBox22.Name = "comboBox22";
		this.comboBox22.Size = new System.Drawing.Size(121, 23);
		this.comboBox22.TabIndex = 43;
		this.lab_bootscreen.Location = new System.Drawing.Point(9, 175);
		this.lab_bootscreen.Name = "lab_bootscreen";
		this.lab_bootscreen.Size = new System.Drawing.Size(123, 23);
		this.lab_bootscreen.TabIndex = 42;
		this.lab_bootscreen.Text = "开机界面";
		this.lab_bootscreen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox31.FormattingEnabled = true;
		this.comboBox31.Location = new System.Drawing.Point(673, 193);
		this.comboBox31.Name = "comboBox31";
		this.comboBox31.Size = new System.Drawing.Size(121, 23);
		this.comboBox31.TabIndex = 61;
		this.comboBox31.Visible = false;
		this.label31.Location = new System.Drawing.Point(567, 194);
		this.label31.Name = "label31";
		this.label31.Size = new System.Drawing.Size(99, 23);
		this.label31.TabIndex = 60;
		this.label31.Text = "语言";
		this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label31.Visible = false;
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage2);
		this.tabControl1.Controls.Add(this.tabPage3);
		this.tabControl1.Controls.Add(this.tabPage4);
		this.tabControl1.Controls.Add(this.tabPage5);
		this.tabControl1.Controls.Add(this.tabPage6);
		this.tabControl1.Controls.Add(this.tabPage7);
		this.tabControl1.Controls.Add(this.tabPage8);
		this.tabControl1.Controls.Add(this.tabPage9);
		this.tabControl1.Controls.Add(this.tabPage10);
		this.tabControl1.Location = new System.Drawing.Point(21, 32);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(1032, 714);
		this.tabControl1.TabIndex = 90;
		this.tabControl1.SelectedIndexChanged += new System.EventHandler(tabControl1_SelectedIndexChanged);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1065, 841);
		base.Controls.Add(this.tabControl1);
		base.Controls.Add(this.btn_cancel);
		base.Controls.Add(this.btn_ok);
		base.Name = "genset";
		this.Text = "genset";
		base.Load += new System.EventHandler(genset_Load);
		this.tabPage10.ResumeLayout(false);
		this.tabPage10.PerformLayout();
		this.groupBox5.ResumeLayout(false);
		this.groupBox5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.tabPage9.ResumeLayout(false);
		this.tabPage9.PerformLayout();
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		this.tabPage8.ResumeLayout(false);
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.tabPage7.ResumeLayout(false);
		this.tabPage7.PerformLayout();
		this.tabPage6.ResumeLayout(false);
		this.tabPage5.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.Nud_cw).EndInit();
		this.tabPage4.ResumeLayout(false);
		this.tabPage3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgv_noaa_event).EndInit();
		this.tabPage2.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.tabPage1.PerformLayout();
		this.tabControl1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
