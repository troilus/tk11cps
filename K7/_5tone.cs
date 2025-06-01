using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace K7;

public class _5tone : Form
{
	private IContainer components = null;

	private Label label10;

	private Label lab_repeat_tone;

	private ComboBox comboBox2;

	private ComboBox cmb_repeat_tone;

	private Label label12;

	private Label label11;

	private ComboBox comboBox4;

	private ComboBox comboBox3;

	private ComboBox comboBox11;

	private ComboBox comboBox9;

	private ComboBox comboBox10;

	private Label label16;

	private Label label17;

	private ComboBox comboBox8;

	private Label label14;

	private ComboBox comboBox5;

	private Label label4;

	private Label label1;

	private Label label2;

	private ComboBox comboBox7;

	private TextBox textBox3;

	private TextBox textBox2;

	private Label label8;

	private Label label7;

	private GroupBox groupBox1;

	private GroupBox groupBox2;

	private Label label3;

	private NumericUpDown numericUpDown1;

	private NumericUpDown numericUpDown2;

	private Label label6;

	private NumericUpDown numericUpDown3;

	private Label label13;

	private NumericUpDown numericUpDown4;

	private Label label15;

	private NumericUpDown numericUpDown5;

	private Label label18;

	private NumericUpDown numericUpDown7;

	private Label label20;

	private NumericUpDown numericUpDown6;

	private Label label19;

	private NumericUpDown numericUpDown8;

	private Label label21;

	private NumericUpDown numericUpDown9;

	private Label label22;

	private NumericUpDown numericUpDown10;

	private Label label23;

	private NumericUpDown numericUpDown11;

	private Label label24;

	private NumericUpDown numericUpDown12;

	private Label label25;

	private NumericUpDown numericUpDown13;

	private Label label26;

	private NumericUpDown numericUpDown14;

	private Label label27;

	private TextBox textBox1;

	private Label label28;

	private TextBox textBox4;

	private Label label29;

	private TextBox textBox5;

	private Label label30;

	private Button button4;

	private Button button3;

	public _5tone()
	{
		InitializeComponent();
		textBox1.MaxLength = 3;
		textBox2.MaxLength = 5;
		textBox3.MaxLength = 5;
		textBox4.MaxLength = 14;
		textBox5.MaxLength = 14;
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

	private void _5tone_Load(object sender, EventArgs e)
	{
		LoadLang();
		LoadComboBoxString(cmb_repeat_tone, param_string._5tone_RepeatTone_Items());
		LoadComboBoxString(comboBox2, param_string._5tone_GroupCode_Items());
		LoadComboBoxString(comboBox3, param_string.dtmf_rsp_Items());
		LoadComboBoxString(comboBox4, param_string._5tone_reset_Items());
		LoadComboBoxString(comboBox7, param_string._5tone_protocol_Items());
		LoadComboBoxString(comboBox11, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox5, param_string.dtmf_Preload_Items());
		LoadComboBoxString(comboBox8, param_string.dtmf_Preload_Items());
		LoadComboBoxString(comboBox9, param_string._5tone_interval_Items());
		LoadComboBoxString(comboBox10, param_string.dtmf_Preload_Items());
		LoadParam();
	}

	private void LoadLang()
	{
		label28.Text = GetLang("dtmf_id");
		label7.Text = GetLang("dtmf_kill");
		label8.Text = GetLang("dtmf_revive");
		label29.Text = GetLang("dtmf_upcode");
		label30.Text = GetLang("dtmf_dncode");
		lab_repeat_tone.Text = GetLang("RepeatTone");
		label10.Text = GetLang("dtmf_group");
		label11.Text = GetLang("dtmf_rsp");
		label12.Text = GetLang("dtmf_reset");
		label14.Text = GetLang("dtmf_carrier");
		label4.Text = GetLang("dtmf_1st_code");
		label17.Text = GetLang("dtmf_continue");
		label16.Text = GetLang("dtmf_interval");
		label1.Text = GetLang("dtmf_tone");
		label2.Text = GetLang("_5tone_protocol");
		label3.Text = GetLang("_5tone_user") + "1";
		label6.Text = GetLang("_5tone_user") + "2";
		label13.Text = GetLang("_5tone_user") + "3";
		label15.Text = GetLang("_5tone_user") + "4";
		label18.Text = GetLang("_5tone_user") + "5";
		label19.Text = GetLang("_5tone_user") + "6";
		label20.Text = GetLang("_5tone_user") + "7";
		label27.Text = GetLang("_5tone_user") + "8";
		label26.Text = GetLang("_5tone_user") + "9";
		label25.Text = GetLang("_5tone_user") + "A";
		label24.Text = GetLang("_5tone_user") + "B";
		label23.Text = GetLang("_5tone_user") + "C";
		label22.Text = GetLang("_5tone_user") + "D";
		label21.Text = GetLang("_5tone_user") + "E";
		button3.Text = GetLang("OK");
		button4.Text = GetLang("cancel");
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\b' && !IsDtmfCode(e.KeyChar))
		{
			e.Handled = true;
		}
	}

	public static bool IsDtmfCode(char c)
	{
		if (char.IsDigit(c))
		{
			return true;
		}
		if ('A' <= c && c <= 'E')
		{
			return true;
		}
		return false;
	}

	public static _5TONE_INFO InitStructInfo()
	{
		_5TONE_INFO result = default(_5TONE_INFO);
		result.id = "123";
		result.kill = "456";
		result.wakeup = "789";
		result.UpCode = "12345";
		result.DnCode = "54321";
		result.RepeatTone = "A";
		result.group_code = "B";
		result.tone = GetLang("on");
		result.decode_rsn = GetLang("off");
		result.reset_time = "5";
		result.carry_time = "300";
		result.first_code_time = "100";
		result.single_interval_time = "100";
		result.single_continue_time = "100";
		result.protocol = GetLang("_5tone_EIA");
		result.user_freq = new int[15];
		for (int i = 0; i < 15; i++)
		{
			result.user_freq[i] = 350;
		}
		return result;
	}

	private void LoadParam()
	{
		_5TONE_INFO _5TONE_INFO2 = main._5ToneInfo;
		if (string.IsNullOrEmpty(_5TONE_INFO2.RepeatTone))
		{
			_5TONE_INFO2 = InitStructInfo();
		}
		textBox1.Text = _5TONE_INFO2.id;
		textBox2.Text = _5TONE_INFO2.kill;
		textBox3.Text = _5TONE_INFO2.wakeup;
		textBox4.Text = _5TONE_INFO2.UpCode;
		textBox5.Text = _5TONE_INFO2.DnCode;
		cmb_repeat_tone.Text = _5TONE_INFO2.RepeatTone;
		comboBox2.Text = _5TONE_INFO2.group_code;
		comboBox3.Text = _5TONE_INFO2.decode_rsn;
		comboBox4.Text = _5TONE_INFO2.reset_time;
		comboBox7.Text = _5TONE_INFO2.protocol;
		comboBox8.Text = _5TONE_INFO2.carry_time;
		comboBox5.Text = _5TONE_INFO2.first_code_time;
		comboBox10.Text = _5TONE_INFO2.single_continue_time;
		comboBox9.Text = _5TONE_INFO2.single_interval_time;
		comboBox11.Text = _5TONE_INFO2.tone;
		int num = 0;
		numericUpDown1.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown2.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown3.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown4.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown5.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown6.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown7.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown14.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown13.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown12.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown11.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown10.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown9.Value = _5TONE_INFO2.user_freq[num++];
		numericUpDown8.Value = _5TONE_INFO2.user_freq[num++];
	}

	private void button4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button3_Click(object sender, EventArgs e)
	{
		SaveParam();
		Close();
	}

	private void SaveParam()
	{
		_5TONE_INFO _5ToneInfo = default(_5TONE_INFO);
		_5ToneInfo.user_freq = new int[15];
		_5ToneInfo.id = textBox1.Text;
		_5ToneInfo.kill = textBox2.Text;
		_5ToneInfo.wakeup = textBox3.Text;
		_5ToneInfo.UpCode = textBox4.Text;
		_5ToneInfo.DnCode = textBox5.Text;
		_5ToneInfo.RepeatTone = cmb_repeat_tone.Text;
		_5ToneInfo.group_code = comboBox2.Text;
		_5ToneInfo.decode_rsn = comboBox3.Text;
		_5ToneInfo.reset_time = comboBox4.Text;
		_5ToneInfo.carry_time = comboBox8.Text;
		_5ToneInfo.first_code_time = comboBox5.Text;
		_5ToneInfo.single_continue_time = comboBox10.Text;
		_5ToneInfo.single_interval_time = comboBox9.Text;
		_5ToneInfo.tone = comboBox11.Text;
		_5ToneInfo.protocol = comboBox7.Text;
		_5ToneInfo.user_freq[0] = (int)numericUpDown1.Value;
		_5ToneInfo.user_freq[1] = (int)numericUpDown2.Value;
		_5ToneInfo.user_freq[2] = (int)numericUpDown3.Value;
		_5ToneInfo.user_freq[3] = (int)numericUpDown4.Value;
		_5ToneInfo.user_freq[4] = (int)numericUpDown5.Value;
		_5ToneInfo.user_freq[5] = (int)numericUpDown6.Value;
		_5ToneInfo.user_freq[6] = (int)numericUpDown7.Value;
		_5ToneInfo.user_freq[7] = (int)numericUpDown14.Value;
		_5ToneInfo.user_freq[8] = (int)numericUpDown13.Value;
		_5ToneInfo.user_freq[9] = (int)numericUpDown12.Value;
		_5ToneInfo.user_freq[10] = (int)numericUpDown11.Value;
		_5ToneInfo.user_freq[11] = (int)numericUpDown10.Value;
		_5ToneInfo.user_freq[12] = (int)numericUpDown9.Value;
		_5ToneInfo.user_freq[13] = (int)numericUpDown8.Value;
		main._5ToneInfo = _5ToneInfo;
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
		this.label10 = new System.Windows.Forms.Label();
		this.lab_repeat_tone = new System.Windows.Forms.Label();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.cmb_repeat_tone = new System.Windows.Forms.ComboBox();
		this.label12 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.comboBox4 = new System.Windows.Forms.ComboBox();
		this.comboBox3 = new System.Windows.Forms.ComboBox();
		this.comboBox11 = new System.Windows.Forms.ComboBox();
		this.comboBox9 = new System.Windows.Forms.ComboBox();
		this.comboBox10 = new System.Windows.Forms.ComboBox();
		this.label16 = new System.Windows.Forms.Label();
		this.label17 = new System.Windows.Forms.Label();
		this.comboBox8 = new System.Windows.Forms.ComboBox();
		this.label14 = new System.Windows.Forms.Label();
		this.comboBox5 = new System.Windows.Forms.ComboBox();
		this.label4 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.comboBox7 = new System.Windows.Forms.ComboBox();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label8 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.label30 = new System.Windows.Forms.Label();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.label29 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label28 = new System.Windows.Forms.Label();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
		this.label21 = new System.Windows.Forms.Label();
		this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
		this.label22 = new System.Windows.Forms.Label();
		this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
		this.label23 = new System.Windows.Forms.Label();
		this.numericUpDown11 = new System.Windows.Forms.NumericUpDown();
		this.label24 = new System.Windows.Forms.Label();
		this.numericUpDown12 = new System.Windows.Forms.NumericUpDown();
		this.label25 = new System.Windows.Forms.Label();
		this.numericUpDown13 = new System.Windows.Forms.NumericUpDown();
		this.label26 = new System.Windows.Forms.Label();
		this.numericUpDown14 = new System.Windows.Forms.NumericUpDown();
		this.label27 = new System.Windows.Forms.Label();
		this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
		this.label20 = new System.Windows.Forms.Label();
		this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
		this.label19 = new System.Windows.Forms.Label();
		this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
		this.label18 = new System.Windows.Forms.Label();
		this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
		this.label15 = new System.Windows.Forms.Label();
		this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
		this.label13 = new System.Windows.Forms.Label();
		this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
		this.label6 = new System.Windows.Forms.Label();
		this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
		this.label3 = new System.Windows.Forms.Label();
		this.button4 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
		base.SuspendLayout();
		this.label10.Location = new System.Drawing.Point(24, 201);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(157, 22);
		this.label10.TabIndex = 161;
		this.label10.Text = "组呼码";
		this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lab_repeat_tone.Location = new System.Drawing.Point(24, 162);
		this.lab_repeat_tone.Name = "lab_repeat_tone";
		this.lab_repeat_tone.Size = new System.Drawing.Size(157, 22);
		this.lab_repeat_tone.TabIndex = 160;
		this.lab_repeat_tone.Text = "重复音";
		this.lab_repeat_tone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Location = new System.Drawing.Point(187, 202);
		this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(133, 23);
		this.comboBox2.TabIndex = 159;
		this.cmb_repeat_tone.FormattingEnabled = true;
		this.cmb_repeat_tone.Location = new System.Drawing.Point(187, 163);
		this.cmb_repeat_tone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.cmb_repeat_tone.Name = "cmb_repeat_tone";
		this.cmb_repeat_tone.Size = new System.Drawing.Size(133, 23);
		this.cmb_repeat_tone.TabIndex = 158;
		this.label12.Location = new System.Drawing.Point(25, 242);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(157, 22);
		this.label12.TabIndex = 165;
		this.label12.Text = "复位时间";
		this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label11.Location = new System.Drawing.Point(398, 318);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(157, 22);
		this.label11.TabIndex = 164;
		this.label11.Text = "解码响应";
		this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label11.Visible = false;
		this.comboBox4.FormattingEnabled = true;
		this.comboBox4.Location = new System.Drawing.Point(188, 242);
		this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox4.Name = "comboBox4";
		this.comboBox4.Size = new System.Drawing.Size(133, 23);
		this.comboBox4.TabIndex = 163;
		this.comboBox3.FormattingEnabled = true;
		this.comboBox3.Location = new System.Drawing.Point(561, 318);
		this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox3.Name = "comboBox3";
		this.comboBox3.Size = new System.Drawing.Size(133, 23);
		this.comboBox3.TabIndex = 162;
		this.comboBox3.Visible = false;
		this.comboBox11.FormattingEnabled = true;
		this.comboBox11.Location = new System.Drawing.Point(188, 281);
		this.comboBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox11.Name = "comboBox11";
		this.comboBox11.Size = new System.Drawing.Size(133, 23);
		this.comboBox11.TabIndex = 177;
		this.comboBox11.Visible = false;
		this.comboBox9.FormattingEnabled = true;
		this.comboBox9.Location = new System.Drawing.Point(547, 240);
		this.comboBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox9.Name = "comboBox9";
		this.comboBox9.Size = new System.Drawing.Size(133, 23);
		this.comboBox9.TabIndex = 176;
		this.comboBox10.FormattingEnabled = true;
		this.comboBox10.Location = new System.Drawing.Point(547, 201);
		this.comboBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox10.Name = "comboBox10";
		this.comboBox10.Size = new System.Drawing.Size(133, 23);
		this.comboBox10.TabIndex = 175;
		this.label16.Location = new System.Drawing.Point(384, 240);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(157, 22);
		this.label16.TabIndex = 174;
		this.label16.Text = "单码间隔时间";
		this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label17.Location = new System.Drawing.Point(384, 200);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(157, 22);
		this.label17.TabIndex = 173;
		this.label17.Text = "单码持续时间";
		this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox8.FormattingEnabled = true;
		this.comboBox8.Location = new System.Drawing.Point(547, 124);
		this.comboBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox8.Name = "comboBox8";
		this.comboBox8.Size = new System.Drawing.Size(133, 23);
		this.comboBox8.TabIndex = 172;
		this.label14.Location = new System.Drawing.Point(384, 123);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(157, 22);
		this.label14.TabIndex = 171;
		this.label14.Text = "预载波时间";
		this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox5.FormattingEnabled = true;
		this.comboBox5.Location = new System.Drawing.Point(547, 161);
		this.comboBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox5.Name = "comboBox5";
		this.comboBox5.Size = new System.Drawing.Size(133, 23);
		this.comboBox5.TabIndex = 169;
		this.label4.Location = new System.Drawing.Point(384, 160);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(157, 22);
		this.label4.TabIndex = 167;
		this.label4.Text = "首码持续时间";
		this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label1.Location = new System.Drawing.Point(25, 281);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(157, 22);
		this.label1.TabIndex = 166;
		this.label1.Text = "侧音";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label1.Visible = false;
		this.label2.Location = new System.Drawing.Point(384, 280);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(157, 22);
		this.label2.TabIndex = 179;
		this.label2.Text = "5tone协议";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox7.FormattingEnabled = true;
		this.comboBox7.Location = new System.Drawing.Point(547, 279);
		this.comboBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox7.Name = "comboBox7";
		this.comboBox7.Size = new System.Drawing.Size(133, 23);
		this.comboBox7.TabIndex = 178;
		this.textBox3.Location = new System.Drawing.Point(187, 122);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(133, 25);
		this.textBox3.TabIndex = 183;
		this.textBox3.Text = "112";
		this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.textBox2.Location = new System.Drawing.Point(187, 81);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(133, 25);
		this.textBox2.TabIndex = 182;
		this.textBox2.Text = "111";
		this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label8.Location = new System.Drawing.Point(24, 122);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(157, 22);
		this.label8.TabIndex = 181;
		this.label8.Text = "唤醒码";
		this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label7.Location = new System.Drawing.Point(24, 80);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(157, 22);
		this.label7.TabIndex = 180;
		this.label7.Text = "遥毙码";
		this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.groupBox1.Controls.Add(this.textBox5);
		this.groupBox1.Controls.Add(this.label30);
		this.groupBox1.Controls.Add(this.textBox4);
		this.groupBox1.Controls.Add(this.label29);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Controls.Add(this.label28);
		this.groupBox1.Controls.Add(this.textBox3);
		this.groupBox1.Controls.Add(this.textBox2);
		this.groupBox1.Controls.Add(this.label8);
		this.groupBox1.Controls.Add(this.label7);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.comboBox7);
		this.groupBox1.Controls.Add(this.comboBox11);
		this.groupBox1.Controls.Add(this.comboBox9);
		this.groupBox1.Controls.Add(this.comboBox10);
		this.groupBox1.Controls.Add(this.label16);
		this.groupBox1.Controls.Add(this.label17);
		this.groupBox1.Controls.Add(this.comboBox8);
		this.groupBox1.Controls.Add(this.label14);
		this.groupBox1.Controls.Add(this.comboBox5);
		this.groupBox1.Controls.Add(this.label4);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.label12);
		this.groupBox1.Controls.Add(this.label11);
		this.groupBox1.Controls.Add(this.comboBox4);
		this.groupBox1.Controls.Add(this.comboBox3);
		this.groupBox1.Controls.Add(this.label10);
		this.groupBox1.Controls.Add(this.lab_repeat_tone);
		this.groupBox1.Controls.Add(this.comboBox2);
		this.groupBox1.Controls.Add(this.cmb_repeat_tone);
		this.groupBox1.Location = new System.Drawing.Point(12, 11);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(755, 352);
		this.groupBox1.TabIndex = 184;
		this.groupBox1.TabStop = false;
		this.textBox5.Location = new System.Drawing.Point(546, 81);
		this.textBox5.MaxLength = 14;
		this.textBox5.Name = "textBox5";
		this.textBox5.Size = new System.Drawing.Size(133, 25);
		this.textBox5.TabIndex = 189;
		this.textBox5.Text = "123456";
		this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label30.Location = new System.Drawing.Point(383, 79);
		this.label30.Name = "label30";
		this.label30.Size = new System.Drawing.Size(157, 22);
		this.label30.TabIndex = 188;
		this.label30.Text = "PTT ID下线码";
		this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.textBox4.Location = new System.Drawing.Point(547, 39);
		this.textBox4.MaxLength = 14;
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(133, 25);
		this.textBox4.TabIndex = 187;
		this.textBox4.Text = "123456";
		this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label29.Location = new System.Drawing.Point(384, 39);
		this.label29.Name = "label29";
		this.label29.Size = new System.Drawing.Size(157, 22);
		this.label29.TabIndex = 186;
		this.label29.Text = "PTT ID上线码";
		this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.textBox1.Location = new System.Drawing.Point(187, 40);
		this.textBox1.MaxLength = 3;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(133, 25);
		this.textBox1.TabIndex = 185;
		this.textBox1.Text = "123";
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label28.Location = new System.Drawing.Point(24, 42);
		this.label28.Name = "label28";
		this.label28.Size = new System.Drawing.Size(157, 22);
		this.label28.TabIndex = 184;
		this.label28.Text = "个人ID码";
		this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.groupBox2.Controls.Add(this.numericUpDown8);
		this.groupBox2.Controls.Add(this.label21);
		this.groupBox2.Controls.Add(this.numericUpDown9);
		this.groupBox2.Controls.Add(this.label22);
		this.groupBox2.Controls.Add(this.numericUpDown10);
		this.groupBox2.Controls.Add(this.label23);
		this.groupBox2.Controls.Add(this.numericUpDown11);
		this.groupBox2.Controls.Add(this.label24);
		this.groupBox2.Controls.Add(this.numericUpDown12);
		this.groupBox2.Controls.Add(this.label25);
		this.groupBox2.Controls.Add(this.numericUpDown13);
		this.groupBox2.Controls.Add(this.label26);
		this.groupBox2.Controls.Add(this.numericUpDown14);
		this.groupBox2.Controls.Add(this.label27);
		this.groupBox2.Controls.Add(this.numericUpDown7);
		this.groupBox2.Controls.Add(this.label20);
		this.groupBox2.Controls.Add(this.numericUpDown6);
		this.groupBox2.Controls.Add(this.label19);
		this.groupBox2.Controls.Add(this.numericUpDown5);
		this.groupBox2.Controls.Add(this.label18);
		this.groupBox2.Controls.Add(this.numericUpDown4);
		this.groupBox2.Controls.Add(this.label15);
		this.groupBox2.Controls.Add(this.numericUpDown3);
		this.groupBox2.Controls.Add(this.label13);
		this.groupBox2.Controls.Add(this.numericUpDown2);
		this.groupBox2.Controls.Add(this.label6);
		this.groupBox2.Controls.Add(this.numericUpDown1);
		this.groupBox2.Controls.Add(this.label3);
		this.groupBox2.Location = new System.Drawing.Point(12, 369);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(756, 384);
		this.groupBox2.TabIndex = 185;
		this.groupBox2.TabStop = false;
		this.numericUpDown8.Location = new System.Drawing.Point(506, 328);
		this.numericUpDown8.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown8.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown8.Name = "numericUpDown8";
		this.numericUpDown8.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown8.TabIndex = 207;
		this.numericUpDown8.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label21.Location = new System.Drawing.Point(343, 330);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(157, 22);
		this.label21.TabIndex = 206;
		this.label21.Text = "自定义E";
		this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown9.Location = new System.Drawing.Point(506, 274);
		this.numericUpDown9.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown9.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown9.Name = "numericUpDown9";
		this.numericUpDown9.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown9.TabIndex = 205;
		this.numericUpDown9.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label22.Location = new System.Drawing.Point(343, 276);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(157, 22);
		this.label22.TabIndex = 204;
		this.label22.Text = "自定义D";
		this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown10.Location = new System.Drawing.Point(506, 223);
		this.numericUpDown10.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown10.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown10.Name = "numericUpDown10";
		this.numericUpDown10.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown10.TabIndex = 203;
		this.numericUpDown10.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label23.Location = new System.Drawing.Point(343, 225);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(157, 22);
		this.label23.TabIndex = 202;
		this.label23.Text = "自定义C";
		this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown11.Location = new System.Drawing.Point(506, 176);
		this.numericUpDown11.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown11.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown11.Name = "numericUpDown11";
		this.numericUpDown11.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown11.TabIndex = 201;
		this.numericUpDown11.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label24.Location = new System.Drawing.Point(343, 178);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(157, 22);
		this.label24.TabIndex = 200;
		this.label24.Text = "自定义B";
		this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown12.Location = new System.Drawing.Point(506, 128);
		this.numericUpDown12.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown12.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown12.Name = "numericUpDown12";
		this.numericUpDown12.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown12.TabIndex = 199;
		this.numericUpDown12.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label25.Location = new System.Drawing.Point(343, 131);
		this.label25.Name = "label25";
		this.label25.Size = new System.Drawing.Size(157, 22);
		this.label25.TabIndex = 198;
		this.label25.Text = "自定义A";
		this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown13.Location = new System.Drawing.Point(506, 81);
		this.numericUpDown13.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown13.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown13.Name = "numericUpDown13";
		this.numericUpDown13.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown13.TabIndex = 197;
		this.numericUpDown13.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label26.Location = new System.Drawing.Point(343, 84);
		this.label26.Name = "label26";
		this.label26.Size = new System.Drawing.Size(157, 22);
		this.label26.TabIndex = 196;
		this.label26.Text = "自定义9";
		this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown14.Location = new System.Drawing.Point(506, 36);
		this.numericUpDown14.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown14.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown14.Name = "numericUpDown14";
		this.numericUpDown14.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown14.TabIndex = 195;
		this.numericUpDown14.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label27.Location = new System.Drawing.Point(343, 39);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(157, 22);
		this.label27.TabIndex = 194;
		this.label27.Text = "自定义8";
		this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown7.Location = new System.Drawing.Point(188, 328);
		this.numericUpDown7.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown7.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown7.Name = "numericUpDown7";
		this.numericUpDown7.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown7.TabIndex = 193;
		this.numericUpDown7.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label20.Location = new System.Drawing.Point(25, 330);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(157, 22);
		this.label20.TabIndex = 192;
		this.label20.Text = "自定义7";
		this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown6.Location = new System.Drawing.Point(188, 274);
		this.numericUpDown6.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown6.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown6.Name = "numericUpDown6";
		this.numericUpDown6.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown6.TabIndex = 191;
		this.numericUpDown6.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label19.Location = new System.Drawing.Point(25, 276);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(157, 22);
		this.label19.TabIndex = 190;
		this.label19.Text = "自定义6";
		this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown5.Location = new System.Drawing.Point(188, 223);
		this.numericUpDown5.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown5.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown5.Name = "numericUpDown5";
		this.numericUpDown5.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown5.TabIndex = 189;
		this.numericUpDown5.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label18.Location = new System.Drawing.Point(25, 225);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(157, 22);
		this.label18.TabIndex = 188;
		this.label18.Text = "自定义5";
		this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown4.Location = new System.Drawing.Point(188, 176);
		this.numericUpDown4.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown4.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown4.Name = "numericUpDown4";
		this.numericUpDown4.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown4.TabIndex = 187;
		this.numericUpDown4.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label15.Location = new System.Drawing.Point(25, 178);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(157, 22);
		this.label15.TabIndex = 186;
		this.label15.Text = "自定义4";
		this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown3.Location = new System.Drawing.Point(188, 128);
		this.numericUpDown3.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown3.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown3.Name = "numericUpDown3";
		this.numericUpDown3.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown3.TabIndex = 185;
		this.numericUpDown3.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label13.Location = new System.Drawing.Point(25, 131);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(157, 22);
		this.label13.TabIndex = 184;
		this.label13.Text = "自定义3";
		this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown2.Location = new System.Drawing.Point(188, 81);
		this.numericUpDown2.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown2.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown2.Name = "numericUpDown2";
		this.numericUpDown2.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown2.TabIndex = 183;
		this.numericUpDown2.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label6.Location = new System.Drawing.Point(25, 84);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(157, 22);
		this.label6.TabIndex = 182;
		this.label6.Text = "自定义2";
		this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown1.Location = new System.Drawing.Point(188, 36);
		this.numericUpDown1.Maximum = new decimal(new int[4] { 3500, 0, 0, 0 });
		this.numericUpDown1.Minimum = new decimal(new int[4] { 350, 0, 0, 0 });
		this.numericUpDown1.Name = "numericUpDown1";
		this.numericUpDown1.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown1.TabIndex = 181;
		this.numericUpDown1.Value = new decimal(new int[4] { 350, 0, 0, 0 });
		this.label3.Location = new System.Drawing.Point(25, 39);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(157, 22);
		this.label3.TabIndex = 180;
		this.label3.Text = "自定义1";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button4.Location = new System.Drawing.Point(558, 795);
		this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(88, 29);
		this.button4.TabIndex = 187;
		this.button4.Text = "取消";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click);
		this.button3.Location = new System.Drawing.Point(199, 795);
		this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(88, 29);
		this.button3.TabIndex = 186;
		this.button3.Text = "确定";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(819, 857);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		base.Name = "_5tone";
		this.Text = "_5tone";
		base.Load += new System.EventHandler(_5tone_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.numericUpDown8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
		base.ResumeLayout(false);
	}
}
