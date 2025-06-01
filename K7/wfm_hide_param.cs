using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class wfm_hide_param : Form
{
	private IContainer components = null;

	private TextBox textBox1;

	private Label label1;

	private Label label2;

	private TextBox textBox2;

	private Label label3;

	private TextBox textBox3;

	private Label label4;

	private TextBox textBox4;

	private GroupBox groupBox1;

	private CheckBox checkBox25;

	private Button btn_cancel;

	private Button btn_ok;

	private GroupBox groupBox2;

	private CheckBox checkBox1;

	private CheckBox checkBox2;

	private CheckBox checkBox3;

	private CheckBox checkBox5;

	private NumericUpDown numericUpDown1;

	private Label label5;

	private Label label6;

	private ComboBox comboBox1;

	private GroupBox groupBox3;

	private Label label7;

	private NumericUpDown nud_period;

	private Label label8;

	private NumericUpDown nud_step;

	private NumericUpDown nud_gain;

	private Label label9;

	private NumericUpDown nud_lowerlimit;

	private Label lab_lowerlimit;

	private NumericUpDown nud_upper;

	private Label lab_upperlimit;

	public wfm_hide_param()
	{
		InitializeComponent();
		groupBox1.Enabled = false;
		groupBox2.Enabled = false;
	}

	public static string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	private void button7_Click(object sender, EventArgs e)
	{
		main.NoaaSendSameInfo.write_flag = checkBox25.Checked;
		main.NoaaSendSameInfo.same[0] = textBox1.Text;
		main.NoaaSendSameInfo.same[1] = textBox2.Text;
		main.NoaaSendSameInfo.same[2] = textBox3.Text;
		main.NoaaSendSameInfo.same[3] = textBox4.Text;
		main.HideParamFlag.write_flag = checkBox1.Checked;
		main.HideParamFlag.lock_freq_flag = checkBox2.Checked;
		main.HideParamFlag.kill_flag = checkBox3.Checked;
		main.HideParamFlag.encrypt_flag = checkBox5.Checked;
		main.HideParamFlag.cps_retry_time = numericUpDown1.Value;
		main.HideParamFlag.noaa_send_type = comboBox1.Text;
		main.HideParamFlag.MwSwAgc_UpperLimit = (short)nud_upper.Value;
		main.HideParamFlag.MwSwAgc_LowerLimit = (short)nud_lowerlimit.Value;
		main.HideParamFlag.MwSwAgc_period = (short)nud_period.Value;
		main.HideParamFlag.MwSwAgc_step = (short)nud_step.Value;
		main.HideParamFlag.MwSwAgc_gain = (short)nud_gain.Value;
		Close();
	}

	private void wfm_noaa_send_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
		Text = GetLang("Hide_param");
		btn_ok.Text = GetLang("OK");
		btn_cancel.Text = GetLang("cancel");
		checkBox1.Text = GetLang("writer_enable");
		checkBox25.Text = GetLang("writer_enable");
		checkBox2.Text = GetLang("lock_freq_flag");
		checkBox3.Text = GetLang("kill_flag");
		checkBox5.Text = GetLang("enc_talk");
		label5.Text = GetLang("cps_tx_times");
		label6.Text = GetLang("noaa_tx_enable");
		if (main.NoaaSendSameInfo.same == null)
		{
			main.NoaaSendSameInfo.same = new string[4];
		}
		groupBox1.Enabled = main.NoaaSendSameInfo.write_flag;
		checkBox25.Checked = main.NoaaSendSameInfo.write_flag;
		textBox1.Text = main.NoaaSendSameInfo.same[0];
		textBox2.Text = main.NoaaSendSameInfo.same[1];
		textBox3.Text = main.NoaaSendSameInfo.same[2];
		textBox4.Text = main.NoaaSendSameInfo.same[3];
		LoadComboBoxString(comboBox1, param_string.noaa_send_type_Items());
		checkBox1.Checked = main.HideParamFlag.write_flag;
		checkBox2.Checked = main.HideParamFlag.lock_freq_flag;
		checkBox3.Checked = main.HideParamFlag.kill_flag;
		checkBox5.Checked = main.HideParamFlag.encrypt_flag;
		try
		{
			numericUpDown1.Value = main.HideParamFlag.cps_retry_time;
		}
		catch (Exception)
		{
			numericUpDown1.Value = 3m;
		}
		comboBox1.Text = main.HideParamFlag.noaa_send_type;
		label7.Text = GetLang("mwsw_period");
		label8.Text = GetLang("mwsw_step");
		label9.Text = GetLang("mwsw_gain");
		lab_upperlimit.Text = GetLang("mwsw_Upperlimit");
		lab_lowerlimit.Text = GetLang("mwsw_lowerlimit");
		try
		{
			nud_period.Value = main.HideParamFlag.MwSwAgc_period;
		}
		catch (Exception)
		{
		}
		try
		{
			nud_step.Value = main.HideParamFlag.MwSwAgc_step;
		}
		catch (Exception)
		{
		}
		try
		{
			nud_gain.Value = main.HideParamFlag.MwSwAgc_gain;
		}
		catch (Exception)
		{
		}
		try
		{
			nud_upper.Value = main.HideParamFlag.MwSwAgc_UpperLimit;
		}
		catch (Exception)
		{
		}
		try
		{
			nud_lowerlimit.Value = main.HideParamFlag.MwSwAgc_LowerLimit;
		}
		catch (Exception)
		{
		}
	}

	public void LoadComboBoxString(ComboBox cmb, List<string> list)
	{
		for (int i = 0; i < list.Count; i++)
		{
			cmb.Items.Add(list[i]);
		}
		cmb.DropDownStyle = ComboBoxStyle.DropDownList;
	}

	private void checkBox25_CheckedChanged(object sender, EventArgs e)
	{
		groupBox1.Enabled = checkBox25.Checked;
	}

	private void button6_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		groupBox2.Enabled = checkBox1.Checked;
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		int num = 0;
		int num2 = 128;
		TextBox textBox = sender as TextBox;
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

	private void numericUpDown4_ValueChanged(object sender, EventArgs e)
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
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.textBox4 = new System.Windows.Forms.TextBox();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.checkBox25 = new System.Windows.Forms.CheckBox();
		this.btn_cancel = new System.Windows.Forms.Button();
		this.btn_ok = new System.Windows.Forms.Button();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.label6 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
		this.checkBox5 = new System.Windows.Forms.CheckBox();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.nud_lowerlimit = new System.Windows.Forms.NumericUpDown();
		this.lab_lowerlimit = new System.Windows.Forms.Label();
		this.nud_upper = new System.Windows.Forms.NumericUpDown();
		this.lab_upperlimit = new System.Windows.Forms.Label();
		this.nud_gain = new System.Windows.Forms.NumericUpDown();
		this.label9 = new System.Windows.Forms.Label();
		this.nud_step = new System.Windows.Forms.NumericUpDown();
		this.label8 = new System.Windows.Forms.Label();
		this.nud_period = new System.Windows.Forms.NumericUpDown();
		this.label7 = new System.Windows.Forms.Label();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown1).BeginInit();
		this.groupBox3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.nud_lowerlimit).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.nud_upper).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.nud_gain).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.nud_step).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.nud_period).BeginInit();
		base.SuspendLayout();
		this.textBox1.Location = new System.Drawing.Point(59, 31);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(577, 25);
		this.textBox1.TabIndex = 0;
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(38, 34);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(15, 15);
		this.label1.TabIndex = 1;
		this.label1.Text = "1";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(38, 92);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(15, 15);
		this.label2.TabIndex = 3;
		this.label2.Text = "2";
		this.textBox2.Location = new System.Drawing.Point(59, 89);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(577, 25);
		this.textBox2.TabIndex = 2;
		this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(38, 148);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(15, 15);
		this.label3.TabIndex = 5;
		this.label3.Text = "3";
		this.textBox3.Location = new System.Drawing.Point(59, 145);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(577, 25);
		this.textBox3.TabIndex = 4;
		this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(38, 207);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(15, 15);
		this.label4.TabIndex = 7;
		this.label4.Text = "4";
		this.textBox4.Location = new System.Drawing.Point(59, 204);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new System.Drawing.Size(577, 25);
		this.textBox4.TabIndex = 6;
		this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.groupBox1.Controls.Add(this.label4);
		this.groupBox1.Controls.Add(this.textBox4);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.textBox3);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.checkBox25);
		this.groupBox1.Controls.Add(this.textBox2);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.textBox1);
		this.groupBox1.Location = new System.Drawing.Point(782, 23);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(677, 251);
		this.groupBox1.TabIndex = 8;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "NOAA SAME";
		this.groupBox1.Visible = false;
		this.checkBox25.AutoSize = true;
		this.checkBox25.Location = new System.Drawing.Point(84, 0);
		this.checkBox25.Name = "checkBox25";
		this.checkBox25.Size = new System.Drawing.Size(121, 19);
		this.checkBox25.TabIndex = 141;
		this.checkBox25.Text = "NOAA写入使能";
		this.checkBox25.UseVisualStyleBackColor = true;
		this.checkBox25.Visible = false;
		this.checkBox25.CheckedChanged += new System.EventHandler(checkBox25_CheckedChanged);
		this.btn_cancel.Location = new System.Drawing.Point(424, 419);
		this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.btn_cancel.Name = "btn_cancel";
		this.btn_cancel.Size = new System.Drawing.Size(70, 29);
		this.btn_cancel.TabIndex = 143;
		this.btn_cancel.Text = "取消";
		this.btn_cancel.UseVisualStyleBackColor = true;
		this.btn_cancel.Click += new System.EventHandler(button6_Click);
		this.btn_ok.Location = new System.Drawing.Point(203, 419);
		this.btn_ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.btn_ok.Name = "btn_ok";
		this.btn_ok.Size = new System.Drawing.Size(70, 29);
		this.btn_ok.TabIndex = 142;
		this.btn_ok.Text = "确定";
		this.btn_ok.UseVisualStyleBackColor = true;
		this.btn_ok.Click += new System.EventHandler(button7_Click);
		this.groupBox2.Controls.Add(this.comboBox1);
		this.groupBox2.Controls.Add(this.label6);
		this.groupBox2.Controls.Add(this.label5);
		this.groupBox2.Controls.Add(this.numericUpDown1);
		this.groupBox2.Controls.Add(this.checkBox5);
		this.groupBox2.Controls.Add(this.checkBox3);
		this.groupBox2.Controls.Add(this.checkBox2);
		this.groupBox2.Location = new System.Drawing.Point(8, 26);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(677, 183);
		this.groupBox2.TabIndex = 144;
		this.groupBox2.TabStop = false;
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Location = new System.Drawing.Point(486, 65);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(172, 23);
		this.comboBox1.TabIndex = 152;
		this.comboBox1.Visible = false;
		this.label6.Location = new System.Drawing.Point(240, 67);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(230, 21);
		this.label6.TabIndex = 151;
		this.label6.Text = "NOAA发射使能";
		this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label6.Visible = false;
		this.label5.Location = new System.Drawing.Point(243, 28);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(226, 21);
		this.label5.TabIndex = 150;
		this.label5.Text = "空口写频发送次数";
		this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.numericUpDown1.Location = new System.Drawing.Point(486, 24);
		this.numericUpDown1.Maximum = new decimal(new int[4] { 4, 0, 0, 0 });
		this.numericUpDown1.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		this.numericUpDown1.Name = "numericUpDown1";
		this.numericUpDown1.Size = new System.Drawing.Size(120, 25);
		this.numericUpDown1.TabIndex = 149;
		this.numericUpDown1.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		this.checkBox5.AutoSize = true;
		this.checkBox5.Location = new System.Drawing.Point(41, 107);
		this.checkBox5.Name = "checkBox5";
		this.checkBox5.Size = new System.Drawing.Size(89, 19);
		this.checkBox5.TabIndex = 148;
		this.checkBox5.Text = "加密通话";
		this.checkBox5.UseVisualStyleBackColor = true;
		this.checkBox3.AutoSize = true;
		this.checkBox3.Location = new System.Drawing.Point(41, 67);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(89, 19);
		this.checkBox3.TabIndex = 147;
		this.checkBox3.Text = "摇毙标志";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox2.AutoSize = true;
		this.checkBox2.Location = new System.Drawing.Point(41, 27);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(89, 19);
		this.checkBox2.TabIndex = 146;
		this.checkBox2.Text = "锁频标志";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(706, 47);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(89, 19);
		this.checkBox1.TabIndex = 145;
		this.checkBox1.Text = "使能标志";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		this.groupBox3.Controls.Add(this.nud_lowerlimit);
		this.groupBox3.Controls.Add(this.lab_lowerlimit);
		this.groupBox3.Controls.Add(this.nud_upper);
		this.groupBox3.Controls.Add(this.lab_upperlimit);
		this.groupBox3.Controls.Add(this.nud_gain);
		this.groupBox3.Controls.Add(this.label9);
		this.groupBox3.Controls.Add(this.nud_step);
		this.groupBox3.Controls.Add(this.label8);
		this.groupBox3.Controls.Add(this.nud_period);
		this.groupBox3.Controls.Add(this.label7);
		this.groupBox3.Location = new System.Drawing.Point(12, 230);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(677, 143);
		this.groupBox3.TabIndex = 146;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "MwSw";
		this.nud_lowerlimit.Location = new System.Drawing.Point(538, 61);
		this.nud_lowerlimit.Maximum = new decimal(new int[4] { 60, 0, 0, -2147483648 });
		this.nud_lowerlimit.Minimum = new decimal(new int[4] { 90, 0, 0, -2147483648 });
		this.nud_lowerlimit.Name = "nud_lowerlimit";
		this.nud_lowerlimit.Size = new System.Drawing.Size(120, 25);
		this.nud_lowerlimit.TabIndex = 160;
		this.nud_lowerlimit.Value = new decimal(new int[4] { 60, 0, 0, -2147483648 });
		this.lab_lowerlimit.Location = new System.Drawing.Point(347, 65);
		this.lab_lowerlimit.Name = "lab_lowerlimit";
		this.lab_lowerlimit.Size = new System.Drawing.Size(185, 16);
		this.lab_lowerlimit.TabIndex = 159;
		this.lab_lowerlimit.Text = "调整下限";
		this.lab_lowerlimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.nud_upper.Location = new System.Drawing.Point(538, 20);
		this.nud_upper.Maximum = new decimal(new int[4] { 60, 0, 0, -2147483648 });
		this.nud_upper.Minimum = new decimal(new int[4] { 90, 0, 0, -2147483648 });
		this.nud_upper.Name = "nud_upper";
		this.nud_upper.Size = new System.Drawing.Size(120, 25);
		this.nud_upper.TabIndex = 158;
		this.nud_upper.Value = new decimal(new int[4] { 60, 0, 0, -2147483648 });
		this.lab_upperlimit.Location = new System.Drawing.Point(347, 25);
		this.lab_upperlimit.Name = "lab_upperlimit";
		this.lab_upperlimit.Size = new System.Drawing.Size(185, 16);
		this.lab_upperlimit.TabIndex = 157;
		this.lab_upperlimit.Text = "调整上限";
		this.lab_upperlimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.nud_gain.Location = new System.Drawing.Point(209, 112);
		this.nud_gain.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
		this.nud_gain.Name = "nud_gain";
		this.nud_gain.Size = new System.Drawing.Size(120, 25);
		this.nud_gain.TabIndex = 156;
		this.nud_gain.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		this.nud_gain.ValueChanged += new System.EventHandler(numericUpDown4_ValueChanged);
		this.label9.Location = new System.Drawing.Point(18, 117);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(185, 16);
		this.label9.TabIndex = 155;
		this.label9.Text = "调整增益";
		this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.nud_step.Location = new System.Drawing.Point(209, 65);
		this.nud_step.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
		this.nud_step.Name = "nud_step";
		this.nud_step.Size = new System.Drawing.Size(120, 25);
		this.nud_step.TabIndex = 154;
		this.nud_step.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		this.label8.Location = new System.Drawing.Point(18, 69);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(185, 16);
		this.label8.TabIndex = 153;
		this.label8.Text = "调整步进";
		this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.nud_period.Location = new System.Drawing.Point(209, 24);
		this.nud_period.Maximum = new decimal(new int[4] { 5000, 0, 0, 0 });
		this.nud_period.Minimum = new decimal(new int[4] { 100, 0, 0, 0 });
		this.nud_period.Name = "nud_period";
		this.nud_period.Size = new System.Drawing.Size(120, 25);
		this.nud_period.TabIndex = 152;
		this.nud_period.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		this.label7.Location = new System.Drawing.Point(18, 29);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(185, 16);
		this.label7.TabIndex = 151;
		this.label7.Text = "调整周期";
		this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(807, 487);
		base.Controls.Add(this.groupBox3);
		base.Controls.Add(this.checkBox1);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.btn_cancel);
		base.Controls.Add(this.btn_ok);
		base.Controls.Add(this.groupBox1);
		base.Name = "wfm_hide_param";
		this.Text = "wfm_noaa_send";
		base.Load += new System.EventHandler(wfm_noaa_send_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown1).EndInit();
		this.groupBox3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.nud_lowerlimit).EndInit();
		((System.ComponentModel.ISupportInitialize)this.nud_upper).EndInit();
		((System.ComponentModel.ISupportInitialize)this.nud_gain).EndInit();
		((System.ComponentModel.ISupportInitialize)this.nud_step).EndInit();
		((System.ComponentModel.ISupportInitialize)this.nud_period).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
