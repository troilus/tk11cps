using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class vfo : Form
{
	private ComboBox cmb_rx_null = new ComboBox();

	private ComboBox cmb_rx_ctc = new ComboBox();

	private ComboBox cmb_rx_dcs = new ComboBox();

	private ComboBox cmb_tx_ctc = new ComboBox();

	private ComboBox cmb_tx_dcs = new ComboBox();

	private ComboBox cmb_tx_null = new ComboBox();

	public int g_ab = 0;

	public int g_index = 0;

	public string non_stand_type1;

	public string non_stand_type2;

	private IContainer components = null;

	private GroupBox groupBox1;

	private ComboBox comboBox7;

	private Label label13;

	private ComboBox comboBox1;

	private Label label10;

	private ComboBox comboBox16;

	private ComboBox comboBox15;

	private Label label23;

	private Label label22;

	private Label label6;

	private ComboBox comboBox6;

	private TextBox textBox1;

	private TextBox textBox3;

	private TextBox textBox2;

	private Label label9;

	private Label label8;

	private Label label7;

	private ComboBox comboBox5;

	private ComboBox comboBox4;

	private ComboBox comboBox3;

	private ComboBox comboBox2;

	private Label label5;

	private Label label4;

	private Label label3;

	private Label label2;

	private Button button6;

	private Button button7;

	private ComboBox comboBox8;

	private Label label1;

	private ComboBox comboBox9;

	private Label label11;

	private ComboBox cmb_FreqRang;

	private Label label12;

	private ComboBox comboBox13;

	private Label label16;

	private ComboBox comboBox12;

	private Label label15;

	private ComboBox comboBox11;

	private Label label14;

	private ComboBox comboBox17;

	private ComboBox comboBox14;

	private ComboBox comboBox19;

	private ComboBox comboBox18;

	private ComboBox comboBox20;

	private Label label17;

	private TextBox textBox4;

	private TextBox textBox5;

	private Label label18;

	private TextBox textBox8;

	private TextBox textBox9;

	private Label label20;

	private TextBox textBox6;

	private TextBox textBox7;

	private Label label19;

	private Label label25;

	private Label label24;

	private Label label21;

	private ComboBox comboBox21;

	private Label label26;

	private ComboBox comboBox22;

	private Label label27;

	private TextBox textBox10;

	private Label label28;

	private ComboBox cmb_msw;

	private Label lab_msw;

	private ComboBox comboBox36;

	private Label label36;

	private BackgroundWorker backgroundWorker1;

	public vfo()
	{
		InitializeComponent();
		cmb_tx_ctc = comboBox12;
		cmb_tx_dcs = comboBox14;
		cmb_rx_ctc = comboBox11;
		cmb_rx_dcs = comboBox17;
		cmb_rx_null = comboBox18;
		cmb_tx_null = comboBox19;
		cmb_tx_ctc.MaxLength = 5;
		cmb_rx_ctc.MaxLength = 5;
		cmb_rx_dcs.MaxLength = 3;
		cmb_tx_dcs.MaxLength = 3;
		comboBox4.Enabled = false;
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

	public void LoadLableString()
	{
		label7.Text = GetLang("chn_name");
		label1.Text = GetLang("chn_name");
		label9.Text = GetLang("chn_rxfreq");
		label8.Text = GetLang("chn_txfreq");
		label2.Text = GetLang("chn_decode");
		label10.Text = GetLang("chn_encode");
		label3.Text = GetLang("chn_power");
		label13.Text = GetLang("chn_band");
		label4.Text = GetLang("chn_scan");
		label1.Text = GetLang("chn_encrpyt");
		label5.Text = GetLang("chn_busy");
		label11.Text = GetLang("chn_dtmf_decode");
		label6.Text = GetLang("chn_pttid");
		label22.Text = GetLang("chn_AM");
		label23.Text = GetLang("chn_freq_revers");
		label12.Text = GetLang("chn_freq_rang");
		label15.Text = GetLang("chn_qt_encode1");
		label16.Text = GetLang("chn_qt_encode2");
		label14.Text = GetLang("chn_qt_decode");
		label17.Text = GetLang("gen_sq");
		label18.Text = GetLang("vfo_scan_rang");
		label19.Text = GetLang("vfo_rx_rang");
		label20.Text = GetLang("vfo_tx_rang");
		label26.Text = GetLang("vfo_direction");
		label27.Text = GetLang("vfo_difference");
		label28.Text = GetLang("vfo_step");
		label36.Text = GetLang("gen_signal");
		button7.Text = GetLang("OK");
		button6.Text = GetLang("cancel");
		lab_msw.Text = "MW/SW-" + GetLang("chn_bw");
		Text = GetLang("chn_edit") + "-" + (main.channel_Index + 1);
	}

	private void channel_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
		if (!main.gEngineerMode)
		{
			textBox6.Enabled = false;
			textBox7.Enabled = false;
			textBox8.Enabled = false;
			textBox9.Enabled = false;
		}
		else
		{
			textBox6.Enabled = true;
			textBox7.Enabled = true;
			textBox8.Enabled = true;
			textBox9.Enabled = true;
		}
		LoadLableString();
		LoadComboBoxString(cmb_msw, param_string.chn_MSW_Items());
		LoadComboBoxString(comboBox3, param_string.chn_power_Items());
		LoadComboBoxString(comboBox7, param_string.chn_band_Items());
		LoadComboBoxString(comboBox5, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox9, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox15, param_string.chn_demode_Items());
		LoadComboBoxString(comboBox16, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox6, param_string.chn_pttid_Items());
		LoadComboBoxString(comboBox8, param_string.chn_encypt_Items());
		LoadComboBoxString(comboBox4, param_string.chn_scanlist_Items());
		LoadComboBoxString(cmb_FreqRang, param_string.chn_freq_rang_Items());
		LoadComboBoxString(comboBox1, param_string.chn_normal_qttype_Items());
		LoadComboBoxString(comboBox2, param_string.chn_normal_qttype_Items());
		LoadComboBoxString(comboBox36, param_string.gen_signal_Items());
		LoadComboBoxString(comboBox20, param_string.gen_sq_Items());
		LoadComboBoxString(comboBox21, param_string.vfo_direction_Items());
		if (main.vfo_index > 2)
		{
			LoadComboBoxString(comboBox22, param_string.vfo_step_Items());
		}
		else
		{
			LoadComboBoxString(comboBox22, param_string.vfo_step1_Items());
		}
		cmb_rx_ctc.Items.AddRange(param_string.CtcssString);
		cmb_rx_dcs.Items.AddRange(param_string.DcsString);
		cmb_tx_ctc.Items.AddRange(param_string.CtcssString);
		cmb_tx_dcs.Items.AddRange(param_string.DcsString);
		cmb_rx_null.Items.Add(GetLang("_null"));
		cmb_rx_null.Enabled = false;
		cmb_tx_null.Items.Add(GetLang("_null"));
		cmb_tx_null.Enabled = false;
		comboBox13.Enabled = false;
		LoadParam();
		ChangeTxQtAttr();
		ChangeRxQtAttr();
	}

	public void ChangeTxQtAttr()
	{
		if (comboBox1.SelectedIndex == 0)
		{
			cmb_tx_null.Visible = true;
			cmb_tx_ctc.Visible = false;
			cmb_tx_dcs.Visible = false;
		}
		else if (comboBox1.SelectedIndex == 1)
		{
			cmb_tx_null.Visible = false;
			cmb_tx_ctc.Visible = true;
			cmb_tx_dcs.Visible = false;
		}
		else if (comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 3)
		{
			cmb_tx_null.Visible = false;
			cmb_tx_ctc.Visible = false;
			cmb_tx_dcs.Visible = true;
		}
	}

	public void ChangeRxQtAttr()
	{
		if (comboBox2.SelectedIndex == 0)
		{
			cmb_rx_null.Visible = true;
			cmb_rx_ctc.Visible = false;
			cmb_rx_dcs.Visible = false;
		}
		else if (comboBox2.SelectedIndex == 1)
		{
			cmb_rx_null.Visible = false;
			cmb_rx_ctc.Visible = true;
			cmb_rx_dcs.Visible = false;
		}
		else if (comboBox2.SelectedIndex == 2 || comboBox2.SelectedIndex == 3)
		{
			cmb_rx_null.Visible = false;
			cmb_rx_ctc.Visible = false;
			cmb_rx_dcs.Visible = true;
		}
	}

	public void LoadParam()
	{
		if (main.vfo_index > 10)
		{
			g_ab = 1;
		}
		else
		{
			g_ab = 0;
		}
		g_index = main.VfoIndexMap[main.vfo_index];
		VFO_INFO vFO_INFO = main.VfoInfo[g_ab, g_index];
		textBox1.Text = vFO_INFO.name;
		textBox3.Text = vFO_INFO.rx_freq;
		textBox2.Text = vFO_INFO.tx_freq;
		comboBox2.Text = vFO_INFO.rx_qt_type;
		comboBox1.Text = vFO_INFO.tx_qt_type;
		comboBox3.Text = vFO_INFO.power;
		comboBox7.Text = vFO_INFO.band;
		comboBox4.Text = vFO_INFO.scanlist;
		comboBox8.Text = vFO_INFO.encypt;
		comboBox5.Text = vFO_INFO.busy;
		comboBox9.Text = vFO_INFO.dtmf_decdoe_flag;
		comboBox6.Text = vFO_INFO.pttid;
		comboBox15.Text = vFO_INFO.am;
		cmb_FreqRang.SelectedIndex = g_index;
		comboBox13.Text = vFO_INFO.qt_encode2;
		comboBox20.Text = vFO_INFO.sq;
		comboBox21.Text = vFO_INFO.freq_dir;
		comboBox22.Text = vFO_INFO.step;
		cmb_rx_null.Text = vFO_INFO.qt_rx_null;
		cmb_tx_null.Text = vFO_INFO.qt_tx_null;
		cmb_rx_ctc.Text = vFO_INFO.qt_rx_ctc;
		cmb_rx_dcs.Text = vFO_INFO.qt_rx_dcs;
		cmb_tx_ctc.Text = vFO_INFO.qt_tx_ctc;
		cmb_tx_dcs.Text = vFO_INFO.qt_tx_dcs;
		comboBox36.Text = vFO_INFO.signal;
		comboBox16.Text = vFO_INFO.reverse;
		textBox4.Text = vFO_INFO.scan_start;
		textBox5.Text = vFO_INFO.scan_end;
		textBox10.Text = vFO_INFO.freq_diff;
		non_stand_type1 = vFO_INFO.non_stand_type1;
		non_stand_type2 = vFO_INFO.non_stand_type2;
		cmb_msw.Text = vFO_INFO.msw;
	}

	private void button7_Click(object sender, EventArgs e)
	{
		SaveParam();
		Close();
	}

	public void SaveParam()
	{
		VFO_INFO vFO_INFO = default(VFO_INFO);
		vFO_INFO.name = textBox1.Text;
		vFO_INFO.rx_freq = textBox3.Text;
		vFO_INFO.rx_qt_type = comboBox2.Text;
		vFO_INFO.qt_rx_null = cmb_rx_null.Text;
		vFO_INFO.qt_rx_ctc = cmb_rx_ctc.Text;
		vFO_INFO.qt_rx_dcs = cmb_rx_dcs.Text;
		vFO_INFO.tx_qt_type = comboBox1.Text;
		vFO_INFO.qt_tx_null = cmb_tx_null.Text;
		vFO_INFO.qt_tx_ctc = cmb_tx_ctc.Text;
		vFO_INFO.qt_tx_dcs = cmb_tx_dcs.Text;
		vFO_INFO.qt_encode2 = comboBox13.Text;
		vFO_INFO.power = comboBox3.Text;
		vFO_INFO.band = comboBox7.Text;
		vFO_INFO.scanlist = comboBox4.Text;
		vFO_INFO.encypt = comboBox8.Text;
		vFO_INFO.signal = comboBox36.Text;
		vFO_INFO.busy = comboBox5.Text;
		vFO_INFO.dtmf_decdoe_flag = comboBox9.Text;
		vFO_INFO.pttid = comboBox6.Text;
		vFO_INFO.am = comboBox15.Text;
		vFO_INFO.sq = comboBox20.Text;
		vFO_INFO.reverse = comboBox16.Text;
		vFO_INFO.freq_rang = cmb_FreqRang.Text;
		vFO_INFO.step = comboBox22.Text;
		vFO_INFO.freq_dir = comboBox21.Text;
		vFO_INFO.freq_diff = textBox10.Text;
		vFO_INFO.msw = cmb_msw.Text;
		if (comboBox21.SelectedIndex == 0)
		{
			vFO_INFO.tx_freq = vFO_INFO.rx_freq;
		}
		else if (comboBox21.SelectedIndex == 1)
		{
			vFO_INFO.tx_freq = (Convert.ToDouble(vFO_INFO.rx_freq) + Convert.ToDouble(vFO_INFO.freq_diff)).ToString("0.00000");
		}
		if (comboBox21.SelectedIndex == 2)
		{
			vFO_INFO.tx_freq = (Convert.ToDouble(vFO_INFO.rx_freq) - Convert.ToDouble(vFO_INFO.freq_diff)).ToString("0.00000");
		}
		vFO_INFO.non_stand_type1 = non_stand_type1;
		vFO_INFO.non_stand_type2 = non_stand_type2;
		vFO_INFO.scan_start = textBox4.Text;
		vFO_INFO.scan_end = textBox5.Text;
		main.VfoInfo[g_ab, g_index] = vFO_INFO;
	}

	private void button6_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		int num = 0;
		string text = textBox1.Text;
		if (e.KeyChar != '\b')
		{
			for (int i = 0; i < text.Length; i++)
			{
				num = ((text[i] < '一' || text[i] > '龥') ? (num + 1) : (num + 2));
			}
			num = ((e.KeyChar < '一' || e.KeyChar > '龥') ? (num + 1) : (num + 2));
			if (num > 10)
			{
				e.Handled = true;
			}
		}
	}

	private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	public static bool IsOtcNum(char c, object sender)
	{
		ComboBox comboBox = sender as ComboBox;
		string text = comboBox.Text;
		if (text.Contains("D") || text.Contains("N") || text.Contains("I"))
		{
			string pattern = "^[0-7]+$";
			Regex regex = new Regex(pattern);
			return regex.IsMatch(c.ToString());
		}
		return true;
	}

	private void comboBox2_Leave(object sender, EventArgs e)
	{
	}

	public static bool IsOtcNum(char c)
	{
		string pattern = "^[0-7]+$";
		Regex regex = new Regex(pattern);
		return regex.IsMatch(c.ToString());
	}

	public bool CheckDcs(string s)
	{
		byte[] bytes = Encoding.Default.GetBytes(s);
		if (bytes[0] != 68)
		{
			return false;
		}
		if (bytes[1] != 78 && bytes[1] != 73)
		{
			return false;
		}
		if (!IsOtcNum((char)bytes[2]))
		{
			return false;
		}
		if (!IsOtcNum((char)bytes[3]))
		{
			return false;
		}
		if (!IsOtcNum((char)bytes[4]))
		{
			return false;
		}
		return true;
	}

	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		ChangeTxQtAttr();
	}

	private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		ChangeRxQtAttr();
	}

	private void comboBox11_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	private void comboBox11_Leave(object sender, EventArgs e)
	{
		ComboBox comboBox = sender as ComboBox;
		try
		{
			double num = Convert.ToDouble(comboBox.Text);
			if (num > 300.0)
			{
				num = 300.0;
			}
			comboBox.Text = num.ToString("0.0");
		}
		catch (Exception)
		{
			comboBox.Text = "63.0";
		}
	}

	private void comboBox14_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\b' && !IsOtcNum(e.KeyChar))
		{
			e.Handled = true;
		}
	}

	private void comboBox14_Leave(object sender, EventArgs e)
	{
		ComboBox comboBox = sender as ComboBox;
		comboBox.Text = Convert.ToInt16(comboBox.Text).ToString("000");
	}

	private void textBox3_Leave(object sender, EventArgs e)
	{
		TextBox textBox = sender as TextBox;
		int selectedIndex = cmb_FreqRang.SelectedIndex;
		double num = param_string.freq_rang[selectedIndex * 2];
		double num2 = param_string.freq_rang[selectedIndex * 2 + 1];
		try
		{
			double num3 = Convert.ToDouble(textBox.Text);
			if (num3 > num2)
			{
				num3 = num2;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
			textBox.Text = num3.ToString("0.00000");
		}
		catch (Exception)
		{
			textBox.Text = num.ToString();
		}
	}

	private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
	{
		int selectedIndex = cmb_FreqRang.SelectedIndex;
		double num = param_string.freq_rang[selectedIndex * 2];
		double num2 = param_string.freq_rang[selectedIndex * 2 + 1];
		try
		{
			double num3 = Convert.ToDouble(textBox3.Text);
			if (num3 > num2)
			{
				num3 = num;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
			textBox3.Text = num3.ToString("0.00000");
		}
		catch (Exception)
		{
			textBox3.Text = num.ToString();
		}
		try
		{
			double num3 = Convert.ToDouble(textBox2.Text);
			if (num3 > num2)
			{
				num3 = num;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
			textBox2.Text = num3.ToString("0.00000");
		}
		catch (Exception)
		{
			textBox2.Text = num.ToString();
		}
	}

	private void button5_Click(object sender, EventArgs e)
	{
		textBox2.Text = textBox3.Text;
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
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
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.comboBox36 = new System.Windows.Forms.ComboBox();
		this.label36 = new System.Windows.Forms.Label();
		this.cmb_msw = new System.Windows.Forms.ComboBox();
		this.lab_msw = new System.Windows.Forms.Label();
		this.textBox10 = new System.Windows.Forms.TextBox();
		this.label28 = new System.Windows.Forms.Label();
		this.comboBox22 = new System.Windows.Forms.ComboBox();
		this.label27 = new System.Windows.Forms.Label();
		this.comboBox21 = new System.Windows.Forms.ComboBox();
		this.label26 = new System.Windows.Forms.Label();
		this.label25 = new System.Windows.Forms.Label();
		this.label24 = new System.Windows.Forms.Label();
		this.label21 = new System.Windows.Forms.Label();
		this.textBox8 = new System.Windows.Forms.TextBox();
		this.textBox9 = new System.Windows.Forms.TextBox();
		this.label20 = new System.Windows.Forms.Label();
		this.textBox6 = new System.Windows.Forms.TextBox();
		this.textBox7 = new System.Windows.Forms.TextBox();
		this.label19 = new System.Windows.Forms.Label();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.label18 = new System.Windows.Forms.Label();
		this.comboBox20 = new System.Windows.Forms.ComboBox();
		this.label17 = new System.Windows.Forms.Label();
		this.comboBox19 = new System.Windows.Forms.ComboBox();
		this.comboBox18 = new System.Windows.Forms.ComboBox();
		this.comboBox17 = new System.Windows.Forms.ComboBox();
		this.comboBox14 = new System.Windows.Forms.ComboBox();
		this.comboBox13 = new System.Windows.Forms.ComboBox();
		this.label16 = new System.Windows.Forms.Label();
		this.comboBox12 = new System.Windows.Forms.ComboBox();
		this.label15 = new System.Windows.Forms.Label();
		this.comboBox11 = new System.Windows.Forms.ComboBox();
		this.label14 = new System.Windows.Forms.Label();
		this.cmb_FreqRang = new System.Windows.Forms.ComboBox();
		this.label12 = new System.Windows.Forms.Label();
		this.comboBox9 = new System.Windows.Forms.ComboBox();
		this.label11 = new System.Windows.Forms.Label();
		this.comboBox8 = new System.Windows.Forms.ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.comboBox7 = new System.Windows.Forms.ComboBox();
		this.label13 = new System.Windows.Forms.Label();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label10 = new System.Windows.Forms.Label();
		this.comboBox16 = new System.Windows.Forms.ComboBox();
		this.comboBox15 = new System.Windows.Forms.ComboBox();
		this.label23 = new System.Windows.Forms.Label();
		this.label22 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.comboBox6 = new System.Windows.Forms.ComboBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.comboBox5 = new System.Windows.Forms.ComboBox();
		this.comboBox4 = new System.Windows.Forms.ComboBox();
		this.comboBox3 = new System.Windows.Forms.ComboBox();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.button6 = new System.Windows.Forms.Button();
		this.button7 = new System.Windows.Forms.Button();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.comboBox36);
		this.groupBox1.Controls.Add(this.label36);
		this.groupBox1.Controls.Add(this.cmb_msw);
		this.groupBox1.Controls.Add(this.lab_msw);
		this.groupBox1.Controls.Add(this.textBox10);
		this.groupBox1.Controls.Add(this.label28);
		this.groupBox1.Controls.Add(this.comboBox22);
		this.groupBox1.Controls.Add(this.label27);
		this.groupBox1.Controls.Add(this.comboBox21);
		this.groupBox1.Controls.Add(this.label26);
		this.groupBox1.Controls.Add(this.label25);
		this.groupBox1.Controls.Add(this.label24);
		this.groupBox1.Controls.Add(this.label21);
		this.groupBox1.Controls.Add(this.textBox8);
		this.groupBox1.Controls.Add(this.textBox9);
		this.groupBox1.Controls.Add(this.label20);
		this.groupBox1.Controls.Add(this.textBox6);
		this.groupBox1.Controls.Add(this.textBox7);
		this.groupBox1.Controls.Add(this.label19);
		this.groupBox1.Controls.Add(this.textBox4);
		this.groupBox1.Controls.Add(this.textBox5);
		this.groupBox1.Controls.Add(this.label18);
		this.groupBox1.Controls.Add(this.comboBox20);
		this.groupBox1.Controls.Add(this.label17);
		this.groupBox1.Controls.Add(this.comboBox19);
		this.groupBox1.Controls.Add(this.comboBox18);
		this.groupBox1.Controls.Add(this.comboBox17);
		this.groupBox1.Controls.Add(this.comboBox14);
		this.groupBox1.Controls.Add(this.comboBox13);
		this.groupBox1.Controls.Add(this.label16);
		this.groupBox1.Controls.Add(this.comboBox12);
		this.groupBox1.Controls.Add(this.label15);
		this.groupBox1.Controls.Add(this.comboBox11);
		this.groupBox1.Controls.Add(this.label14);
		this.groupBox1.Controls.Add(this.cmb_FreqRang);
		this.groupBox1.Controls.Add(this.label12);
		this.groupBox1.Controls.Add(this.comboBox9);
		this.groupBox1.Controls.Add(this.label11);
		this.groupBox1.Controls.Add(this.comboBox8);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.comboBox7);
		this.groupBox1.Controls.Add(this.label13);
		this.groupBox1.Controls.Add(this.comboBox1);
		this.groupBox1.Controls.Add(this.label10);
		this.groupBox1.Controls.Add(this.comboBox16);
		this.groupBox1.Controls.Add(this.comboBox15);
		this.groupBox1.Controls.Add(this.label23);
		this.groupBox1.Controls.Add(this.label22);
		this.groupBox1.Controls.Add(this.label6);
		this.groupBox1.Controls.Add(this.comboBox6);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Controls.Add(this.textBox3);
		this.groupBox1.Controls.Add(this.textBox2);
		this.groupBox1.Controls.Add(this.label9);
		this.groupBox1.Controls.Add(this.label8);
		this.groupBox1.Controls.Add(this.label7);
		this.groupBox1.Controls.Add(this.comboBox5);
		this.groupBox1.Controls.Add(this.comboBox4);
		this.groupBox1.Controls.Add(this.comboBox3);
		this.groupBox1.Controls.Add(this.comboBox2);
		this.groupBox1.Controls.Add(this.label5);
		this.groupBox1.Controls.Add(this.label4);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Location = new System.Drawing.Point(10, -2);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.groupBox1.Size = new System.Drawing.Size(791, 567);
		this.groupBox1.TabIndex = 80;
		this.groupBox1.TabStop = false;
		this.comboBox36.FormattingEnabled = true;
		this.comboBox36.Location = new System.Drawing.Point(197, 464);
		this.comboBox36.Name = "comboBox36";
		this.comboBox36.Size = new System.Drawing.Size(132, 23);
		this.comboBox36.TabIndex = 129;
		this.label36.Location = new System.Drawing.Point(25, 467);
		this.label36.Name = "label36";
		this.label36.Size = new System.Drawing.Size(167, 15);
		this.label36.TabIndex = 128;
		this.label36.Text = "信令系统";
		this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cmb_msw.FormattingEnabled = true;
		this.cmb_msw.Location = new System.Drawing.Point(197, 107);
		this.cmb_msw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.cmb_msw.Name = "cmb_msw";
		this.cmb_msw.Size = new System.Drawing.Size(133, 23);
		this.cmb_msw.TabIndex = 127;
		this.lab_msw.Location = new System.Drawing.Point(-10, 106);
		this.lab_msw.Name = "lab_msw";
		this.lab_msw.Size = new System.Drawing.Size(201, 22);
		this.lab_msw.TabIndex = 126;
		this.lab_msw.Text = "MSW";
		this.lab_msw.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.textBox10.Location = new System.Drawing.Point(597, 425);
		this.textBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox10.MaxLength = 9;
		this.textBox10.Name = "textBox10";
		this.textBox10.Size = new System.Drawing.Size(133, 25);
		this.textBox10.TabIndex = 125;
		this.label28.Location = new System.Drawing.Point(18, 423);
		this.label28.Name = "label28";
		this.label28.Size = new System.Drawing.Size(173, 25);
		this.label28.TabIndex = 124;
		this.label28.Text = "步进";
		this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox22.FormattingEnabled = true;
		this.comboBox22.Location = new System.Drawing.Point(197, 423);
		this.comboBox22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox22.Name = "comboBox22";
		this.comboBox22.Size = new System.Drawing.Size(133, 23);
		this.comboBox22.TabIndex = 123;
		this.label27.Location = new System.Drawing.Point(392, 428);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(197, 22);
		this.label27.TabIndex = 122;
		this.label27.Text = "频差";
		this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox21.FormattingEnabled = true;
		this.comboBox21.Location = new System.Drawing.Point(596, 386);
		this.comboBox21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox21.Name = "comboBox21";
		this.comboBox21.Size = new System.Drawing.Size(133, 23);
		this.comboBox21.TabIndex = 121;
		this.label26.Location = new System.Drawing.Point(389, 385);
		this.label26.Name = "label26";
		this.label26.Size = new System.Drawing.Size(201, 22);
		this.label26.TabIndex = 120;
		this.label26.Text = "频差方向";
		this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label25.Location = new System.Drawing.Point(342, 571);
		this.label25.Name = "label25";
		this.label25.Size = new System.Drawing.Size(15, 22);
		this.label25.TabIndex = 119;
		this.label25.Text = "-";
		this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label25.Visible = false;
		this.label24.Location = new System.Drawing.Point(416, 528);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(15, 22);
		this.label24.TabIndex = 118;
		this.label24.Text = "-";
		this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label24.Visible = false;
		this.label21.Location = new System.Drawing.Point(342, 528);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(15, 22);
		this.label21.TabIndex = 117;
		this.label21.Text = "-";
		this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.textBox8.Location = new System.Drawing.Point(197, 570);
		this.textBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox8.MaxLength = 9;
		this.textBox8.Name = "textBox8";
		this.textBox8.Size = new System.Drawing.Size(133, 25);
		this.textBox8.TabIndex = 116;
		this.textBox8.Visible = false;
		this.textBox9.Location = new System.Drawing.Point(363, 570);
		this.textBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox9.MaxLength = 9;
		this.textBox9.Name = "textBox9";
		this.textBox9.Size = new System.Drawing.Size(132, 25);
		this.textBox9.TabIndex = 115;
		this.textBox9.Visible = false;
		this.label20.Location = new System.Drawing.Point(19, 570);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(173, 25);
		this.label20.TabIndex = 114;
		this.label20.Text = "发射频率范围";
		this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label20.Visible = false;
		this.textBox6.Location = new System.Drawing.Point(271, 525);
		this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox6.MaxLength = 9;
		this.textBox6.Name = "textBox6";
		this.textBox6.Size = new System.Drawing.Size(133, 25);
		this.textBox6.TabIndex = 112;
		this.textBox6.Visible = false;
		this.textBox7.Location = new System.Drawing.Point(437, 525);
		this.textBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox7.MaxLength = 9;
		this.textBox7.Name = "textBox7";
		this.textBox7.Size = new System.Drawing.Size(132, 25);
		this.textBox7.TabIndex = 111;
		this.textBox7.Visible = false;
		this.label19.Location = new System.Drawing.Point(93, 525);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(173, 25);
		this.label19.TabIndex = 110;
		this.label19.Text = "接收频率范围";
		this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label19.Visible = false;
		this.textBox4.Location = new System.Drawing.Point(197, 523);
		this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox4.MaxLength = 9;
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(133, 25);
		this.textBox4.TabIndex = 108;
		this.textBox5.Location = new System.Drawing.Point(363, 523);
		this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox5.MaxLength = 9;
		this.textBox5.Name = "textBox5";
		this.textBox5.Size = new System.Drawing.Size(132, 25);
		this.textBox5.TabIndex = 107;
		this.label18.Location = new System.Drawing.Point(19, 523);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(173, 25);
		this.label18.TabIndex = 106;
		this.label18.Text = "扫描频率范围";
		this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox20.FormattingEnabled = true;
		this.comboBox20.Location = new System.Drawing.Point(197, 385);
		this.comboBox20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox20.MaxLength = 5;
		this.comboBox20.Name = "comboBox20";
		this.comboBox20.Size = new System.Drawing.Size(133, 23);
		this.comboBox20.TabIndex = 105;
		this.label17.Location = new System.Drawing.Point(35, 385);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(157, 22);
		this.label17.TabIndex = 104;
		this.label17.Text = "sq";
		this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox19.FormattingEnabled = true;
		this.comboBox19.Location = new System.Drawing.Point(596, 145);
		this.comboBox19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox19.MaxLength = 5;
		this.comboBox19.Name = "comboBox19";
		this.comboBox19.Size = new System.Drawing.Size(133, 23);
		this.comboBox19.TabIndex = 103;
		this.comboBox18.FormattingEnabled = true;
		this.comboBox18.Location = new System.Drawing.Point(597, 264);
		this.comboBox18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox18.MaxLength = 5;
		this.comboBox18.Name = "comboBox18";
		this.comboBox18.Size = new System.Drawing.Size(133, 23);
		this.comboBox18.TabIndex = 102;
		this.comboBox17.FormattingEnabled = true;
		this.comboBox17.Location = new System.Drawing.Point(597, 264);
		this.comboBox17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox17.MaxLength = 5;
		this.comboBox17.Name = "comboBox17";
		this.comboBox17.Size = new System.Drawing.Size(133, 23);
		this.comboBox17.TabIndex = 101;
		this.comboBox17.KeyPress += new System.Windows.Forms.KeyPressEventHandler(comboBox14_KeyPress);
		this.comboBox17.Leave += new System.EventHandler(comboBox14_Leave);
		this.comboBox14.FormattingEnabled = true;
		this.comboBox14.Location = new System.Drawing.Point(596, 145);
		this.comboBox14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox14.MaxLength = 5;
		this.comboBox14.Name = "comboBox14";
		this.comboBox14.Size = new System.Drawing.Size(133, 23);
		this.comboBox14.TabIndex = 100;
		this.comboBox14.KeyPress += new System.Windows.Forms.KeyPressEventHandler(comboBox14_KeyPress);
		this.comboBox14.Leave += new System.EventHandler(comboBox14_Leave);
		this.comboBox13.FormattingEnabled = true;
		this.comboBox13.Location = new System.Drawing.Point(596, 185);
		this.comboBox13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox13.MaxLength = 5;
		this.comboBox13.Name = "comboBox13";
		this.comboBox13.Size = new System.Drawing.Size(133, 23);
		this.comboBox13.TabIndex = 99;
		this.label16.Location = new System.Drawing.Point(460, 186);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(130, 22);
		this.label16.TabIndex = 98;
		this.label16.Text = "亚音编码2";
		this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox12.FormattingEnabled = true;
		this.comboBox12.Location = new System.Drawing.Point(596, 145);
		this.comboBox12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox12.MaxLength = 5;
		this.comboBox12.Name = "comboBox12";
		this.comboBox12.Size = new System.Drawing.Size(133, 23);
		this.comboBox12.TabIndex = 97;
		this.comboBox12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(comboBox11_KeyPress);
		this.comboBox12.Leave += new System.EventHandler(comboBox11_Leave);
		this.label15.Location = new System.Drawing.Point(460, 146);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(130, 22);
		this.label15.TabIndex = 96;
		this.label15.Text = "亚音编码1";
		this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox11.FormattingEnabled = true;
		this.comboBox11.Location = new System.Drawing.Point(597, 264);
		this.comboBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox11.MaxLength = 5;
		this.comboBox11.Name = "comboBox11";
		this.comboBox11.Size = new System.Drawing.Size(133, 23);
		this.comboBox11.TabIndex = 95;
		this.comboBox11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(comboBox11_KeyPress);
		this.comboBox11.Leave += new System.EventHandler(comboBox11_Leave);
		this.label14.Location = new System.Drawing.Point(462, 264);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(130, 22);
		this.label14.TabIndex = 94;
		this.label14.Text = "亚音解码";
		this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cmb_FreqRang.Enabled = false;
		this.cmb_FreqRang.FormattingEnabled = true;
		this.cmb_FreqRang.Location = new System.Drawing.Point(597, 24);
		this.cmb_FreqRang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.cmb_FreqRang.Name = "cmb_FreqRang";
		this.cmb_FreqRang.Size = new System.Drawing.Size(133, 23);
		this.cmb_FreqRang.TabIndex = 93;
		this.cmb_FreqRang.Visible = false;
		this.cmb_FreqRang.SelectedIndexChanged += new System.EventHandler(comboBox10_SelectedIndexChanged);
		this.label12.Location = new System.Drawing.Point(390, 23);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(201, 22);
		this.label12.TabIndex = 92;
		this.label12.Text = "频段范围";
		this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label12.Visible = false;
		this.comboBox9.FormattingEnabled = true;
		this.comboBox9.Location = new System.Drawing.Point(597, 346);
		this.comboBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox9.Name = "comboBox9";
		this.comboBox9.Size = new System.Drawing.Size(133, 23);
		this.comboBox9.TabIndex = 91;
		this.label11.Location = new System.Drawing.Point(390, 345);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(201, 22);
		this.label11.TabIndex = 90;
		this.label11.Text = "DTMF解码";
		this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox8.FormattingEnabled = true;
		this.comboBox8.Location = new System.Drawing.Point(597, 306);
		this.comboBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox8.Name = "comboBox8";
		this.comboBox8.Size = new System.Drawing.Size(133, 23);
		this.comboBox8.TabIndex = 89;
		this.label1.Location = new System.Drawing.Point(390, 305);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(201, 22);
		this.label1.TabIndex = 88;
		this.label1.Text = "加密";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox7.FormattingEnabled = true;
		this.comboBox7.Location = new System.Drawing.Point(197, 146);
		this.comboBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox7.Name = "comboBox7";
		this.comboBox7.Size = new System.Drawing.Size(133, 23);
		this.comboBox7.TabIndex = 87;
		this.label13.Location = new System.Drawing.Point(-10, 145);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(201, 22);
		this.label13.TabIndex = 86;
		this.label13.Text = "带宽";
		this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Location = new System.Drawing.Point(597, 106);
		this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox1.MaxLength = 5;
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(133, 23);
		this.comboBox1.TabIndex = 85;
		this.comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
		this.label10.Location = new System.Drawing.Point(461, 107);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(130, 22);
		this.label10.TabIndex = 84;
		this.label10.Text = "亚音编码类型";
		this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox16.FormattingEnabled = true;
		this.comboBox16.Location = new System.Drawing.Point(197, 344);
		this.comboBox16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox16.MaxLength = 5;
		this.comboBox16.Name = "comboBox16";
		this.comboBox16.Size = new System.Drawing.Size(133, 23);
		this.comboBox16.TabIndex = 81;
		this.comboBox15.FormattingEnabled = true;
		this.comboBox15.Location = new System.Drawing.Point(197, 304);
		this.comboBox15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox15.MaxLength = 5;
		this.comboBox15.Name = "comboBox15";
		this.comboBox15.Size = new System.Drawing.Size(133, 23);
		this.comboBox15.TabIndex = 80;
		this.label23.Location = new System.Drawing.Point(35, 345);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(157, 22);
		this.label23.TabIndex = 79;
		this.label23.Text = "倒频";
		this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label22.Location = new System.Drawing.Point(35, 304);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(157, 22);
		this.label22.TabIndex = 78;
		this.label22.Text = "AM";
		this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label6.Location = new System.Drawing.Point(35, 263);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(157, 22);
		this.label6.TabIndex = 74;
		this.label6.Text = "PTT ID";
		this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox6.FormattingEnabled = true;
		this.comboBox6.Location = new System.Drawing.Point(197, 264);
		this.comboBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox6.Name = "comboBox6";
		this.comboBox6.Size = new System.Drawing.Size(133, 23);
		this.comboBox6.TabIndex = 75;
		this.textBox1.Enabled = false;
		this.textBox1.Location = new System.Drawing.Point(197, 22);
		this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox1.MaxLength = 10;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(132, 25);
		this.textBox1.TabIndex = 73;
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.textBox3.Location = new System.Drawing.Point(197, 64);
		this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox3.MaxLength = 9;
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(133, 25);
		this.textBox3.TabIndex = 44;
		this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox3_KeyPress);
		this.textBox3.Leave += new System.EventHandler(textBox3_Leave);
		this.textBox2.Enabled = false;
		this.textBox2.Location = new System.Drawing.Point(598, 68);
		this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox2.MaxLength = 9;
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(132, 25);
		this.textBox2.TabIndex = 43;
		this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox3_KeyPress);
		this.textBox2.Leave += new System.EventHandler(textBox3_Leave);
		this.label9.Location = new System.Drawing.Point(19, 64);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(173, 22);
		this.label9.TabIndex = 37;
		this.label9.Text = "接收频率";
		this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label8.Location = new System.Drawing.Point(439, 68);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(154, 22);
		this.label8.TabIndex = 36;
		this.label8.Text = "发射频率";
		this.label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
		this.label7.Location = new System.Drawing.Point(41, 20);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(151, 22);
		this.label7.TabIndex = 35;
		this.label7.Text = "信道名称";
		this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox5.FormattingEnabled = true;
		this.comboBox5.Location = new System.Drawing.Point(197, 224);
		this.comboBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox5.Name = "comboBox5";
		this.comboBox5.Size = new System.Drawing.Size(133, 23);
		this.comboBox5.TabIndex = 33;
		this.comboBox4.FormattingEnabled = true;
		this.comboBox4.Location = new System.Drawing.Point(197, 186);
		this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox4.Name = "comboBox4";
		this.comboBox4.Size = new System.Drawing.Size(133, 23);
		this.comboBox4.TabIndex = 32;
		this.comboBox4.Visible = false;
		this.comboBox3.FormattingEnabled = true;
		this.comboBox3.Location = new System.Drawing.Point(197, 184);
		this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox3.Name = "comboBox3";
		this.comboBox3.Size = new System.Drawing.Size(133, 23);
		this.comboBox3.TabIndex = 31;
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Location = new System.Drawing.Point(596, 226);
		this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox2.MaxLength = 5;
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(133, 23);
		this.comboBox2.TabIndex = 30;
		this.comboBox2.SelectedIndexChanged += new System.EventHandler(comboBox2_SelectedIndexChanged);
		this.label5.Location = new System.Drawing.Point(35, 223);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(157, 22);
		this.label5.TabIndex = 27;
		this.label5.Text = "繁忙禁发";
		this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label4.Location = new System.Drawing.Point(35, 185);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(157, 22);
		this.label4.TabIndex = 26;
		this.label4.Text = "扫描列表";
		this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label4.Visible = false;
		this.label3.Location = new System.Drawing.Point(35, 184);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(157, 22);
		this.label3.TabIndex = 25;
		this.label3.Text = "功率";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label2.Location = new System.Drawing.Point(461, 226);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(130, 22);
		this.label2.TabIndex = 24;
		this.label2.Text = "亚音解码类型";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button6.Location = new System.Drawing.Point(491, 569);
		this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(88, 29);
		this.button6.TabIndex = 83;
		this.button6.Text = "取消";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(button6_Click);
		this.button7.Location = new System.Drawing.Point(273, 569);
		this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(88, 29);
		this.button7.TabIndex = 82;
		this.button7.Text = "确定";
		this.button7.UseVisualStyleBackColor = true;
		this.button7.Click += new System.EventHandler(button7_Click);
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(848, 623);
		base.Controls.Add(this.button6);
		base.Controls.Add(this.button7);
		base.Controls.Add(this.groupBox1);
		base.Name = "vfo";
		this.Text = "channel";
		base.Load += new System.EventHandler(channel_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
	}
}
