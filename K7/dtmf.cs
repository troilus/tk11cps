using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class dtmf : Form
{
	private IContainer components = null;

	private ComboBox comboBox9;

	private ComboBox comboBox10;

	private Label label16;

	private Label label17;

	private ComboBox comboBox8;

	private Label label14;

	private ComboBox comboBox7;

	private ComboBox comboBox6;

	private ComboBox comboBox5;

	private TextBox textBox5;

	private TextBox textBox4;

	private TextBox textBox3;

	private TextBox textBox2;

	private TextBox textBox1;

	private Label label13;

	private Label label12;

	private Label label11;

	private Label label10;

	private Label label9;

	private Label label8;

	private Label label7;

	private Label label6;

	private ComboBox comboBox4;

	private ComboBox comboBox3;

	private ComboBox comboBox2;

	private ComboBox comboBox1;

	private Label label5;

	private Label label4;

	private Label label3;

	private Label label2;

	private Label label1;

	private ComboBox comboBox11;

	private Button button4;

	private Button button3;

	public dtmf()
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

	private void button3_Click(object sender, EventArgs e)
	{
		SaveParam();
		Close();
	}

	private void SaveParam()
	{
		DTMF_INFO dtmfInfo = default(DTMF_INFO);
		dtmfInfo.id = textBox1.Text;
		dtmfInfo.kill = textBox2.Text;
		dtmfInfo.wakeup = textBox3.Text;
		dtmfInfo.UpCode = textBox4.Text;
		dtmfInfo.DnCode = textBox5.Text;
		dtmfInfo.separator = comboBox1.Text;
		dtmfInfo.group_code = comboBox2.Text;
		dtmfInfo.decode_rsn = comboBox3.Text;
		dtmfInfo.reset_time = comboBox4.Text;
		dtmfInfo.wakeup_kill_flag = comboBox7.Text;
		dtmfInfo.carry_time = comboBox8.Text;
		dtmfInfo.first_code_time = comboBox5.Text;
		dtmfInfo.D_code_time = comboBox6.Text;
		dtmfInfo.single_continue_time = comboBox10.Text;
		dtmfInfo.single_interval_time = comboBox9.Text;
		dtmfInfo.tone = comboBox11.Text;
		main.DtmfInfo = dtmfInfo;
	}

	private void button4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void dtmf_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
		LoadLang();
		LoadComboBoxString(comboBox1, param_string.dtmf_split_Items());
		LoadComboBoxString(comboBox2, param_string.dtmf_groupcode_Items());
		LoadComboBoxString(comboBox3, param_string.dtmf_rsp_Items());
		LoadComboBoxString(comboBox4, param_string.dtmf_reset_Items());
		LoadComboBoxString(comboBox7, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox11, param_string.chn_on_off_Items());
		LoadComboBoxString(comboBox5, param_string.dtmf_Preload_Items());
		LoadComboBoxString(comboBox6, param_string.dtmf_Preload_Items());
		LoadComboBoxString(comboBox8, param_string.dtmf_Preload_Items());
		LoadComboBoxString(comboBox9, param_string.dtmf_Preload_Items());
		LoadComboBoxString(comboBox10, param_string.dtmf_Preload_Items());
		LoadParam();
	}

	public static DTMF_INFO InitStructInfo()
	{
		DTMF_INFO result = default(DTMF_INFO);
		result.id = "123";
		result.kill = "456";
		result.wakeup = "789";
		result.UpCode = "12345";
		result.DnCode = "54321";
		result.separator = "*";
		result.group_code = "#";
		result.tone = GetLang("on");
		result.decode_rsn = GetLang("off");
		result.wakeup_kill_flag = GetLang("on");
		result.reset_time = "5";
		result.carry_time = "300";
		result.D_code_time = "100";
		result.first_code_time = "100";
		result.single_interval_time = "100";
		result.single_continue_time = "100";
		return result;
	}

	private void LoadParam()
	{
		DTMF_INFO dTMF_INFO = main.DtmfInfo;
		if (string.IsNullOrEmpty(dTMF_INFO.separator))
		{
			dTMF_INFO = InitStructInfo();
		}
		textBox1.Text = dTMF_INFO.id;
		textBox2.Text = dTMF_INFO.kill;
		textBox3.Text = dTMF_INFO.wakeup;
		textBox4.Text = dTMF_INFO.UpCode;
		textBox5.Text = dTMF_INFO.DnCode;
		comboBox1.Text = dTMF_INFO.separator;
		comboBox2.Text = dTMF_INFO.group_code;
		comboBox3.Text = dTMF_INFO.decode_rsn;
		comboBox4.Text = dTMF_INFO.reset_time;
		comboBox7.Text = dTMF_INFO.wakeup_kill_flag;
		comboBox8.Text = dTMF_INFO.carry_time;
		comboBox5.Text = dTMF_INFO.first_code_time;
		comboBox6.Text = dTMF_INFO.D_code_time;
		comboBox10.Text = dTMF_INFO.single_continue_time;
		comboBox9.Text = dTMF_INFO.single_interval_time;
		comboBox11.Text = dTMF_INFO.tone;
	}

	private void LoadLang()
	{
		label6.Text = GetLang("dtmf_id");
		label7.Text = GetLang("dtmf_kill");
		label8.Text = GetLang("dtmf_revive");
		label2.Text = GetLang("dtmf_upcode");
		label3.Text = GetLang("dtmf_dncode");
		label9.Text = GetLang("dtmf_split");
		label10.Text = GetLang("dtmf_group");
		label11.Text = GetLang("dtmf_rsp");
		label12.Text = GetLang("dtmf_reset");
		label13.Text = GetLang("dtmf_kill_switch");
		label14.Text = GetLang("dtmf_carrier");
		label4.Text = GetLang("dtmf_1st_code");
		label5.Text = GetLang("dtmf_star");
		label17.Text = GetLang("dtmf_continue");
		label16.Text = GetLang("dtmf_interval");
		label1.Text = GetLang("dtmf_tone");
		button3.Text = GetLang("OK");
		button4.Text = GetLang("cancel");
	}

	public void LoadComboBoxString(ComboBox cmb, List<string> list)
	{
		for (int i = 0; i < list.Count; i++)
		{
			cmb.Items.Add(list[i]);
		}
		cmb.DropDownStyle = ComboBoxStyle.DropDownList;
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
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
		c = char.ToUpper(c);
		if (('A' <= c && c <= 'D') || c == '*' || c == '#')
		{
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
		this.comboBox9 = new System.Windows.Forms.ComboBox();
		this.comboBox10 = new System.Windows.Forms.ComboBox();
		this.label16 = new System.Windows.Forms.Label();
		this.label17 = new System.Windows.Forms.Label();
		this.comboBox8 = new System.Windows.Forms.ComboBox();
		this.label14 = new System.Windows.Forms.Label();
		this.comboBox7 = new System.Windows.Forms.ComboBox();
		this.comboBox6 = new System.Windows.Forms.ComboBox();
		this.comboBox5 = new System.Windows.Forms.ComboBox();
		this.textBox5 = new System.Windows.Forms.TextBox();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label13 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.comboBox4 = new System.Windows.Forms.ComboBox();
		this.comboBox3 = new System.Windows.Forms.ComboBox();
		this.comboBox2 = new System.Windows.Forms.ComboBox();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.comboBox11 = new System.Windows.Forms.ComboBox();
		this.button4 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.comboBox9.FormattingEnabled = true;
		this.comboBox9.Location = new System.Drawing.Point(554, 302);
		this.comboBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox9.Name = "comboBox9";
		this.comboBox9.Size = new System.Drawing.Size(133, 23);
		this.comboBox9.TabIndex = 154;
		this.comboBox10.FormattingEnabled = true;
		this.comboBox10.Location = new System.Drawing.Point(554, 262);
		this.comboBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox10.Name = "comboBox10";
		this.comboBox10.Size = new System.Drawing.Size(133, 23);
		this.comboBox10.TabIndex = 153;
		this.label16.Location = new System.Drawing.Point(391, 305);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(157, 22);
		this.label16.TabIndex = 152;
		this.label16.Text = "单码间隔时间";
		this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label17.Location = new System.Drawing.Point(391, 266);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(157, 22);
		this.label17.TabIndex = 151;
		this.label17.Text = "单码持续时间";
		this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox8.FormattingEnabled = true;
		this.comboBox8.Location = new System.Drawing.Point(554, 142);
		this.comboBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox8.Name = "comboBox8";
		this.comboBox8.Size = new System.Drawing.Size(133, 23);
		this.comboBox8.TabIndex = 150;
		this.label14.Location = new System.Drawing.Point(391, 142);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(157, 22);
		this.label14.TabIndex = 149;
		this.label14.Text = "预载波时间";
		this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox7.FormattingEnabled = true;
		this.comboBox7.Location = new System.Drawing.Point(226, 339);
		this.comboBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox7.Name = "comboBox7";
		this.comboBox7.Size = new System.Drawing.Size(133, 23);
		this.comboBox7.TabIndex = 148;
		this.comboBox7.Visible = false;
		this.comboBox6.FormattingEnabled = true;
		this.comboBox6.Location = new System.Drawing.Point(554, 222);
		this.comboBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox6.Name = "comboBox6";
		this.comboBox6.Size = new System.Drawing.Size(133, 23);
		this.comboBox6.TabIndex = 147;
		this.comboBox5.FormattingEnabled = true;
		this.comboBox5.Location = new System.Drawing.Point(554, 182);
		this.comboBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox5.Name = "comboBox5";
		this.comboBox5.Size = new System.Drawing.Size(133, 23);
		this.comboBox5.TabIndex = 146;
		this.textBox5.Location = new System.Drawing.Point(554, 99);
		this.textBox5.MaxLength = 14;
		this.textBox5.Name = "textBox5";
		this.textBox5.Size = new System.Drawing.Size(133, 25);
		this.textBox5.TabIndex = 145;
		this.textBox5.Text = "789123";
		this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.textBox4.Location = new System.Drawing.Point(554, 56);
		this.textBox4.MaxLength = 14;
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(133, 25);
		this.textBox4.TabIndex = 144;
		this.textBox4.Text = "123456";
		this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.textBox3.Location = new System.Drawing.Point(226, 137);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(133, 25);
		this.textBox3.TabIndex = 143;
		this.textBox3.Text = "112";
		this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.textBox2.Location = new System.Drawing.Point(226, 95);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(133, 25);
		this.textBox2.TabIndex = 142;
		this.textBox2.Text = "111";
		this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.textBox1.Location = new System.Drawing.Point(226, 53);
		this.textBox1.MaxLength = 3;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(133, 25);
		this.textBox1.TabIndex = 141;
		this.textBox1.Text = "123";
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label13.Location = new System.Drawing.Point(63, 340);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(157, 22);
		this.label13.TabIndex = 140;
		this.label13.Text = "摇毙/激活解码";
		this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label13.Visible = false;
		this.label12.Location = new System.Drawing.Point(63, 268);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(157, 22);
		this.label12.TabIndex = 139;
		this.label12.Text = "复位时间";
		this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label11.Location = new System.Drawing.Point(63, 377);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(157, 22);
		this.label11.TabIndex = 138;
		this.label11.Text = "解码响应";
		this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label11.Visible = false;
		this.label10.Location = new System.Drawing.Point(63, 221);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(157, 22);
		this.label10.TabIndex = 137;
		this.label10.Text = "组呼码";
		this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label9.Location = new System.Drawing.Point(63, 181);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(157, 22);
		this.label9.TabIndex = 136;
		this.label9.Text = "分隔符";
		this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label8.Location = new System.Drawing.Point(63, 139);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(157, 22);
		this.label8.TabIndex = 135;
		this.label8.Text = "唤醒码";
		this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label7.Location = new System.Drawing.Point(63, 97);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(157, 22);
		this.label7.TabIndex = 134;
		this.label7.Text = "遥毙码";
		this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label6.Location = new System.Drawing.Point(63, 55);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(157, 22);
		this.label6.TabIndex = 133;
		this.label6.Text = "个人ID码";
		this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.comboBox4.FormattingEnabled = true;
		this.comboBox4.Location = new System.Drawing.Point(226, 267);
		this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox4.Name = "comboBox4";
		this.comboBox4.Size = new System.Drawing.Size(133, 23);
		this.comboBox4.TabIndex = 132;
		this.comboBox3.FormattingEnabled = true;
		this.comboBox3.Location = new System.Drawing.Point(226, 376);
		this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox3.Name = "comboBox3";
		this.comboBox3.Size = new System.Drawing.Size(133, 23);
		this.comboBox3.TabIndex = 131;
		this.comboBox3.Visible = false;
		this.comboBox2.FormattingEnabled = true;
		this.comboBox2.Location = new System.Drawing.Point(226, 219);
		this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox2.Name = "comboBox2";
		this.comboBox2.Size = new System.Drawing.Size(133, 23);
		this.comboBox2.TabIndex = 130;
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Location = new System.Drawing.Point(226, 179);
		this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(133, 23);
		this.comboBox1.TabIndex = 129;
		this.label5.Location = new System.Drawing.Point(391, 224);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(157, 22);
		this.label5.TabIndex = 127;
		this.label5.Text = "D码持续时间";
		this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label4.Location = new System.Drawing.Point(391, 182);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(157, 22);
		this.label4.TabIndex = 126;
		this.label4.Text = "首码持续时间";
		this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label3.Location = new System.Drawing.Point(391, 98);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(157, 22);
		this.label3.TabIndex = 125;
		this.label3.Text = "PTT ID下线码";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label2.Location = new System.Drawing.Point(391, 56);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(157, 22);
		this.label2.TabIndex = 124;
		this.label2.Text = "PTT ID上线码";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label1.Location = new System.Drawing.Point(391, 344);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(157, 22);
		this.label1.TabIndex = 123;
		this.label1.Text = "侧音";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label1.Visible = false;
		this.comboBox11.FormattingEnabled = true;
		this.comboBox11.Location = new System.Drawing.Point(554, 342);
		this.comboBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.comboBox11.Name = "comboBox11";
		this.comboBox11.Size = new System.Drawing.Size(133, 23);
		this.comboBox11.TabIndex = 155;
		this.comboBox11.Visible = false;
		this.button4.Location = new System.Drawing.Point(554, 414);
		this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(88, 29);
		this.button4.TabIndex = 157;
		this.button4.Text = "取消";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click);
		this.button3.Location = new System.Drawing.Point(195, 414);
		this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(88, 29);
		this.button3.TabIndex = 156;
		this.button3.Text = "确定";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(824, 467);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.comboBox11);
		base.Controls.Add(this.comboBox9);
		base.Controls.Add(this.comboBox10);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.label17);
		base.Controls.Add(this.comboBox8);
		base.Controls.Add(this.label14);
		base.Controls.Add(this.comboBox7);
		base.Controls.Add(this.comboBox6);
		base.Controls.Add(this.comboBox5);
		base.Controls.Add(this.textBox5);
		base.Controls.Add(this.textBox4);
		base.Controls.Add(this.textBox3);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.comboBox4);
		base.Controls.Add(this.comboBox3);
		base.Controls.Add(this.comboBox2);
		base.Controls.Add(this.comboBox1);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Name = "dtmf";
		this.Text = "dtmf";
		base.Load += new System.EventHandler(dtmf_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
