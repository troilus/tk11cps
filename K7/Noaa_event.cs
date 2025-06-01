using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class Noaa_event : Form
{
	private IContainer components = null;

	private Label label1;

	private TextBox txt_num;

	private TextBox txt_duration;

	private Label label2;

	private TextBox txt_date;

	private Label label3;

	private Label label4;

	private Label label5;

	private Button button1;

	private Button button2;

	private TextBox txt_befor_org;

	private TextBox txt_current_org;

	public Noaa_event()
	{
		InitializeComponent();
		txt_num.MaxLength = 8;
		txt_duration.MaxLength = 8;
		txt_date.MaxLength = 8;
		txt_befor_org.MaxLength = 8;
		txt_current_org.MaxLength = 8;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		int noaa_event_index = main.noaa_event_index;
		main.NoaaEventInfo[noaa_event_index].even_number = txt_num.Text;
		main.NoaaEventInfo[noaa_event_index].duration = txt_duration.Text;
		main.NoaaEventInfo[noaa_event_index].date = txt_date.Text;
		main.NoaaEventInfo[noaa_event_index].event_befor_org = txt_befor_org.Text;
		main.NoaaEventInfo[noaa_event_index].event_current_org = txt_current_org.Text;
		Close();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Noaa_event_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
		int noaa_event_index = main.noaa_event_index;
		txt_num.Text = main.NoaaEventInfo[noaa_event_index].even_number;
		txt_duration.Text = main.NoaaEventInfo[noaa_event_index].duration;
		txt_date.Text = main.NoaaEventInfo[noaa_event_index].date;
		txt_befor_org.Text = main.NoaaEventInfo[noaa_event_index].event_befor_org;
		txt_current_org.Text = main.NoaaEventInfo[noaa_event_index].event_current_org;
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar >= '\u007f')
		{
			e.Handled = true;
		}
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
		this.label1 = new System.Windows.Forms.Label();
		this.txt_num = new System.Windows.Forms.TextBox();
		this.txt_duration = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.txt_date = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.txt_befor_org = new System.Windows.Forms.TextBox();
		this.txt_current_org = new System.Windows.Forms.TextBox();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(124, 28);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(67, 15);
		this.label1.TabIndex = 0;
		this.label1.Text = "事件编号";
		this.txt_num.Location = new System.Drawing.Point(197, 25);
		this.txt_num.Name = "txt_num";
		this.txt_num.Size = new System.Drawing.Size(283, 25);
		this.txt_num.TabIndex = 1;
		this.txt_num.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.txt_duration.Location = new System.Drawing.Point(197, 73);
		this.txt_duration.Name = "txt_duration";
		this.txt_duration.Size = new System.Drawing.Size(283, 25);
		this.txt_duration.TabIndex = 3;
		this.txt_duration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(94, 76);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(97, 15);
		this.label2.TabIndex = 2;
		this.label2.Text = "事件持续时长";
		this.txt_date.Location = new System.Drawing.Point(197, 121);
		this.txt_date.Name = "txt_date";
		this.txt_date.Size = new System.Drawing.Size(283, 25);
		this.txt_date.TabIndex = 5;
		this.txt_date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(94, 124);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(97, 15);
		this.label3.TabIndex = 4;
		this.label3.Text = "事件发布时间";
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(64, 172);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(127, 15);
		this.label4.TabIndex = 6;
		this.label4.Text = "事件初始发布组织";
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(64, 220);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(127, 15);
		this.label5.TabIndex = 7;
		this.label5.Text = "事件当前发布组织";
		this.button1.Location = new System.Drawing.Point(140, 291);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 32);
		this.button1.TabIndex = 10;
		this.button1.Text = "确定";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button2.Location = new System.Drawing.Point(374, 291);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(75, 32);
		this.button2.TabIndex = 11;
		this.button2.Text = "取消";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.txt_befor_org.Location = new System.Drawing.Point(197, 169);
		this.txt_befor_org.Name = "txt_befor_org";
		this.txt_befor_org.Size = new System.Drawing.Size(283, 25);
		this.txt_befor_org.TabIndex = 12;
		this.txt_befor_org.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.txt_current_org.Location = new System.Drawing.Point(197, 217);
		this.txt_current_org.Name = "txt_current_org";
		this.txt_current_org.Size = new System.Drawing.Size(283, 25);
		this.txt_current_org.TabIndex = 13;
		this.txt_current_org.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(555, 376);
		base.Controls.Add(this.txt_current_org);
		base.Controls.Add(this.txt_befor_org);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.txt_date);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.txt_duration);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.txt_num);
		base.Controls.Add(this.label1);
		base.Name = "Noaa_event";
		this.Text = "Noaa_event";
		base.Load += new System.EventHandler(Noaa_event_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
public struct NOAA_EVENT
{
	public string even_seq;

	public string even_number;

	public string duration;

	public string date;

	public string event_befor_org;

	public string event_current_org;
}
