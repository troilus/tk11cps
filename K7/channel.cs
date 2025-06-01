using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class channel : Form
{
	private ComboBox cmb_rx_null = new ComboBox();

	private ComboBox cmb_rx_ctc = new ComboBox();

	private ComboBox cmb_rx_dcs = new ComboBox();

	private ComboBox cmb_tx_ctc = new ComboBox();

	private ComboBox cmb_tx_dcs = new ComboBox();

	private ComboBox cmb_tx_null = new ComboBox();

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

	private Button button5;

	private TextBox textBox3;

	private TextBox textBox2;

	private Label label9;

	private Label label8;

	private Label label7;

	private ComboBox comboBox5;

	private ComboBox cmb_scan;

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

	private ComboBox comboBox10;

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

	private ComboBox cmb_msw;

	private Label lab_msw;

	private ComboBox comboBox36;

	private Label label36;

	public channel()
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
		lab_msw.Text = "MW/SW-" + GetLang("chn_bw");
		button7.Text = GetLang("OK");
		button6.Text = GetLang("cancel");
		label36.Text = GetLang("gen_signal");
		label7.Text = GetLang("chn_name");
		Text = GetLang("chn_edit") + "-" + (main.channel_Index + 1);
	}

	private void channel_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
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
		LoadComboBoxString(cmb_scan, param_string.chn_scanlist_Items());
		LoadComboBoxString(comboBox10, param_string.chn_freq_rang_Items());
		LoadComboBoxString(comboBox1, param_string.chn_normal_qttype_Items());
		LoadComboBoxString(comboBox2, param_string.chn_normal_qttype_Items());
		comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
		comboBox2.DropDownStyle = ComboBoxStyle.DropDown;
		LoadComboBoxString(comboBox36, param_string.gen_signal_Items());
		LoadComboBoxString(comboBox20, param_string.gen_sq_Items());
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
		CHANNEL_INFO cHANNEL_INFO = main.ChannelInfo[main.channel_Index];
		if (string.IsNullOrEmpty(cHANNEL_INFO.rx_freq))
		{
			cHANNEL_INFO = default(CHANNEL_INFO);
			cHANNEL_INFO.name = "CH-" + (main.channel_Index + 1).ToString("000");
			cHANNEL_INFO.rx_freq = "400.02500";
			cHANNEL_INFO.tx_freq = cHANNEL_INFO.rx_freq;
			cHANNEL_INFO.freq_rang = "400M-470M";
			cHANNEL_INFO.step = "12.5K";
			cHANNEL_INFO.band = "25K";
			cHANNEL_INFO.power = GetLang("high");
			cHANNEL_INFO.scanlist = GetLang("_null");
			cHANNEL_INFO.rx_qt_type = GetLang("_null");
			cHANNEL_INFO.tx_qt_type = GetLang("_null");
			cHANNEL_INFO.qt_rx_null = GetLang("_null");
			cHANNEL_INFO.qt_rx_ctc = param_string.CtcssString[0];
			cHANNEL_INFO.qt_rx_dcs = param_string.DcsString[0];
			cHANNEL_INFO.qt_tx_null = GetLang("_null");
			cHANNEL_INFO.qt_tx_ctc = param_string.CtcssString[0];
			cHANNEL_INFO.qt_tx_dcs = param_string.DcsString[0];
			cHANNEL_INFO.non_stand_type1 = GetLang("_null");
			cHANNEL_INFO.non_stand_type2 = GetLang("_null");
			cHANNEL_INFO.signal = GetLang("gen_dtmf");
			cHANNEL_INFO.qt_encode2 = GetLang("_null");
			cHANNEL_INFO.busy = GetLang("off");
			cHANNEL_INFO.pttid = GetLang("off");
			cHANNEL_INFO.dtmf_decdoe_flag = GetLang("off");
			cHANNEL_INFO.am = "FM";
			cHANNEL_INFO.reverse = GetLang("off");
			cHANNEL_INFO.encypt = GetLang("off");
			cHANNEL_INFO.sq = "4";
			cHANNEL_INFO.msw = "2K";
		}
		textBox1.Text = cHANNEL_INFO.name;
		textBox3.Text = cHANNEL_INFO.rx_freq;
		textBox2.Text = cHANNEL_INFO.tx_freq;
		comboBox2.Text = cHANNEL_INFO.rx_qt_type;
		comboBox1.Text = cHANNEL_INFO.tx_qt_type;
		comboBox3.Text = cHANNEL_INFO.power;
		comboBox7.Text = cHANNEL_INFO.band;
		cmb_scan.Text = cHANNEL_INFO.scanlist;
		comboBox8.Text = cHANNEL_INFO.encypt;
		comboBox5.Text = cHANNEL_INFO.busy;
		comboBox9.Text = cHANNEL_INFO.dtmf_decdoe_flag;
		comboBox6.Text = cHANNEL_INFO.pttid;
		comboBox15.Text = cHANNEL_INFO.am;
		comboBox10.Text = cHANNEL_INFO.freq_rang;
		comboBox36.Text = cHANNEL_INFO.signal;
		comboBox13.Text = cHANNEL_INFO.qt_encode2;
		comboBox20.Text = cHANNEL_INFO.sq;
		cmb_rx_null.Text = cHANNEL_INFO.qt_rx_null;
		cmb_tx_null.Text = cHANNEL_INFO.qt_tx_null;
		cmb_rx_ctc.Text = cHANNEL_INFO.qt_rx_ctc;
		cmb_rx_dcs.Text = cHANNEL_INFO.qt_rx_dcs;
		cmb_tx_ctc.Text = cHANNEL_INFO.qt_tx_ctc;
		cmb_tx_dcs.Text = cHANNEL_INFO.qt_tx_dcs;
		cmb_msw.Text = cHANNEL_INFO.msw;
		comboBox16.Text = cHANNEL_INFO.reverse;
		non_stand_type1 = cHANNEL_INFO.non_stand_type1;
		non_stand_type2 = cHANNEL_INFO.non_stand_type2;
	}

	private void button7_Click(object sender, EventArgs e)
	{
		SaveParam();
		Close();
	}

	public void SaveParam()
	{
		CHANNEL_INFO cHANNEL_INFO = default(CHANNEL_INFO);
		cHANNEL_INFO.name = textBox1.Text;
		cHANNEL_INFO.rx_freq = textBox3.Text;
		cHANNEL_INFO.tx_freq = textBox2.Text;
		cHANNEL_INFO.rx_qt_type = comboBox2.Text;
		cHANNEL_INFO.qt_rx_null = cmb_rx_null.Text;
		cHANNEL_INFO.qt_rx_ctc = cmb_rx_ctc.Text;
		cHANNEL_INFO.qt_rx_dcs = cmb_rx_dcs.Text;
		cHANNEL_INFO.signal = comboBox36.Text;
		cHANNEL_INFO.tx_qt_type = comboBox1.Text;
		cHANNEL_INFO.qt_tx_null = cmb_tx_null.Text;
		cHANNEL_INFO.qt_tx_ctc = cmb_tx_ctc.Text;
		cHANNEL_INFO.qt_tx_dcs = cmb_tx_dcs.Text;
		cHANNEL_INFO.qt_encode2 = comboBox13.Text;
		cHANNEL_INFO.power = comboBox3.Text;
		cHANNEL_INFO.band = comboBox7.Text;
		cHANNEL_INFO.scanlist = cmb_scan.Text;
		cHANNEL_INFO.encypt = comboBox8.Text;
		cHANNEL_INFO.busy = comboBox5.Text;
		cHANNEL_INFO.dtmf_decdoe_flag = comboBox9.Text;
		cHANNEL_INFO.pttid = comboBox6.Text;
		cHANNEL_INFO.am = comboBox15.Text;
		cHANNEL_INFO.reverse = comboBox16.Text;
		cHANNEL_INFO.freq_rang = comboBox10.Text;
		cHANNEL_INFO.sq = comboBox20.Text;
		cHANNEL_INFO.non_stand_type1 = non_stand_type1;
		cHANNEL_INFO.non_stand_type2 = non_stand_type2;
		cHANNEL_INFO.msw = cmb_msw.Text;
		main.ChannelInfo[main.channel_Index] = cHANNEL_INFO;
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
		double num = 0.153;
		int num2 = 600;
		try
		{
			double num3 = Convert.ToDouble(textBox.Text);
			if (num3 > (double)num2)
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
	}

	private void button5_Click(object sender, EventArgs e)
	{
		textBox2.Text = textBox3.Text;
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
		this.comboBox10 = new System.Windows.Forms.ComboBox();
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
		this.button5 = new System.Windows.Forms.Button();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.comboBox5 = new System.Windows.Forms.ComboBox();
		this.cmb_scan = new System.Windows.Forms.ComboBox();
		this.comboBox3 = new System.Windows.Forms.ComboBox();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.button6 = new System.Windows.Forms.Button();
		this.button7 = new System.Windows.Forms.Button();
		this.groupBox1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.comboBox36);
		this.groupBox1.Controls.Add(this.label36);
		this.groupBox1.Controls.Add(this.cmb_msw);
		this.groupBox1.Controls.Add(this.lab_msw);
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
		this.groupBox1.Controls.Add(this.comboBox10);
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
		this.groupBox1.Controls.Add(this.button5);
		this.groupBox1.Controls.Add(this.textBox3);
		this.groupBox1.Controls.Add(this.textBox2);
		this.groupBox1.Controls.Add(this.label9);
		this.groupBox1.Controls.Add(this.label8);
		this.groupBox1.Controls.Add(this.label7);
		this.groupBox1.Controls.Add(this.comboBox5);
		this.groupBox1.Controls.Add(this.cmb_scan);
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
		this.groupBox1.Size = new System.Drawing.Size(791, 487);
		this.groupBox1.TabIndex = 80;
		this.groupBox1.TabStop = false;
		this.comboBox36.FormattingEnabled = true;
		this.comboBox36.Location = new System.Drawing.Point(597, 393);
		this.comboBox36.Name = "comboBox36";
		this.comboBox36.Size = new System.Drawing.Size(133, 23);
		this.comboBox36.TabIndex = 111;
		this.label36.Location = new System.Drawing.Point(435, 396);
		this.label36.Name = "label36";
		this.label36.Size = new System.Drawing.Size(156, 15);
		this.label36.TabIndex = 110;
		this.label36.Text = "信令系统";
		this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cmb_msw.FormattingEnabled = true;
		this.cmb_msw.Location = new System.Drawing.Point(197, 106);
		this.cmb_msw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.cmb_msw.Name = "cmb_msw";
		this.cmb_msw.Size = new System.Drawing.Size(133, 23);
		this.cmb_msw.TabIndex = 109;
		this.lab_msw.Location = new System.Drawing.Point(-10, 105);
		this.lab_msw.Name = "lab_msw";
		this.lab_msw.Size = new System.Drawing.Size(201, 22);
		this.lab_msw.TabIndex = 108;
		this.lab_msw.Text = "MSW";
		this.lab_msw.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox20.FormattingEnabled = true;
		this.comboBox20.Location = new System.Drawing.Point(197, 394);
		this.comboBox20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox20.MaxLength = 5;
		this.comboBox20.Name = "comboBox20";
		this.comboBox20.Size = new System.Drawing.Size(133, 23);
		this.comboBox20.TabIndex = 107;
		this.label17.Location = new System.Drawing.Point(35, 394);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(157, 22);
		this.label17.TabIndex = 106;
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
		this.comboBox10.FormattingEnabled = true;
		this.comboBox10.Location = new System.Drawing.Point(597, 24);
		this.comboBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox10.Name = "comboBox10";
		this.comboBox10.Size = new System.Drawing.Size(133, 23);
		this.comboBox10.TabIndex = 93;
		this.comboBox10.Visible = false;
		this.comboBox10.SelectedIndexChanged += new System.EventHandler(comboBox10_SelectedIndexChanged);
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
		this.comboBox7.Location = new System.Drawing.Point(197, 145);
		this.comboBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox7.Name = "comboBox7";
		this.comboBox7.Size = new System.Drawing.Size(133, 23);
		this.comboBox7.TabIndex = 87;
		this.label13.Location = new System.Drawing.Point(-10, 144);
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
		this.comboBox16.Location = new System.Drawing.Point(197, 346);
		this.comboBox16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox16.MaxLength = 5;
		this.comboBox16.Name = "comboBox16";
		this.comboBox16.Size = new System.Drawing.Size(133, 23);
		this.comboBox16.TabIndex = 81;
		this.comboBox15.FormattingEnabled = true;
		this.comboBox15.Location = new System.Drawing.Point(197, 306);
		this.comboBox15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox15.MaxLength = 5;
		this.comboBox15.Name = "comboBox15";
		this.comboBox15.Size = new System.Drawing.Size(133, 23);
		this.comboBox15.TabIndex = 80;
		this.label23.Location = new System.Drawing.Point(35, 347);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(157, 22);
		this.label23.TabIndex = 79;
		this.label23.Text = "倒频";
		this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label22.Location = new System.Drawing.Point(35, 306);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(157, 22);
		this.label22.TabIndex = 78;
		this.label22.Text = "AM";
		this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label6.Location = new System.Drawing.Point(434, 434);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(157, 22);
		this.label6.TabIndex = 74;
		this.label6.Text = "PTT ID";
		this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox6.FormattingEnabled = true;
		this.comboBox6.Location = new System.Drawing.Point(596, 435);
		this.comboBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox6.Name = "comboBox6";
		this.comboBox6.Size = new System.Drawing.Size(133, 23);
		this.comboBox6.TabIndex = 75;
		this.textBox1.Location = new System.Drawing.Point(197, 22);
		this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox1.MaxLength = 10;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(132, 25);
		this.textBox1.TabIndex = 73;
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.button5.Location = new System.Drawing.Point(356, 70);
		this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(98, 23);
		this.button5.TabIndex = 72;
		this.button5.Text = "->>";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(button5_Click);
		this.textBox3.Location = new System.Drawing.Point(197, 64);
		this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox3.MaxLength = 9;
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(133, 25);
		this.textBox3.TabIndex = 44;
		this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox3_KeyPress);
		this.textBox3.Leave += new System.EventHandler(textBox3_Leave);
		this.textBox2.Location = new System.Drawing.Point(597, 69);
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
		this.label8.Location = new System.Drawing.Point(438, 69);
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
		this.comboBox5.Location = new System.Drawing.Point(197, 265);
		this.comboBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox5.Name = "comboBox5";
		this.comboBox5.Size = new System.Drawing.Size(133, 23);
		this.comboBox5.TabIndex = 33;
		this.cmb_scan.FormattingEnabled = true;
		this.cmb_scan.Location = new System.Drawing.Point(197, 225);
		this.cmb_scan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.cmb_scan.Name = "cmb_scan";
		this.cmb_scan.Size = new System.Drawing.Size(133, 23);
		this.cmb_scan.TabIndex = 32;
		this.comboBox3.FormattingEnabled = true;
		this.comboBox3.Location = new System.Drawing.Point(197, 185);
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
		this.label5.Location = new System.Drawing.Point(35, 264);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(157, 22);
		this.label5.TabIndex = 27;
		this.label5.Text = "繁忙禁发";
		this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label4.Location = new System.Drawing.Point(35, 224);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(157, 22);
		this.label4.TabIndex = 26;
		this.label4.Text = "扫描列表";
		this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label3.Location = new System.Drawing.Point(35, 185);
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
		this.button6.Location = new System.Drawing.Point(501, 502);
		this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(88, 29);
		this.button6.TabIndex = 83;
		this.button6.Text = "取消";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(button6_Click);
		this.button7.Location = new System.Drawing.Point(283, 502);
		this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(88, 29);
		this.button7.TabIndex = 82;
		this.button7.Text = "确定";
		this.button7.UseVisualStyleBackColor = true;
		this.button7.Click += new System.EventHandler(button7_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(862, 552);
		base.Controls.Add(this.button6);
		base.Controls.Add(this.button7);
		base.Controls.Add(this.groupBox1);
		base.Name = "channel";
		this.Text = "channel";
		base.Load += new System.EventHandler(channel_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		base.ResumeLayout(false);
	}
}
