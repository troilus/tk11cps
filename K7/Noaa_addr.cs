using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class Noaa_addr : Form
{
	private IContainer components = null;

	private Label label1;

	private Label label2;

	private TextBox textBox1;

	private TextBox textBox2;

	private Button button1;

	private Button button2;

	public Noaa_addr()
	{
		InitializeComponent();
		textBox1.MaxLength = 6;
		textBox2.MaxLength = 31;
	}

	public static string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	private void Noaa_addr_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
		label1.Text = GetLang("NOAA_ADDR");
		label2.Text = GetLang("NOAA_DECODE_ADDR");
		button1.Text = GetLang("OK");
		button2.Text = GetLang("cancel");
		int noaa_decode_addr_index = main.noaa_decode_addr_index;
		textBox1.Text = main.NoaaDecodeAddrInfo[noaa_decode_addr_index].addr;
		textBox2.Text = main.NoaaDecodeAddrInfo[noaa_decode_addr_index].info;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		int noaa_decode_addr_index = main.noaa_decode_addr_index;
		main.NoaaDecodeAddrInfo[noaa_decode_addr_index].addr = textBox1.Text;
		main.NoaaDecodeAddrInfo[noaa_decode_addr_index].info = textBox2.Text;
		Close();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Noaa_addr_KeyPress(object sender, KeyPressEventArgs e)
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
		this.label2 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.label1.Location = new System.Drawing.Point(28, 28);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(124, 25);
		this.label1.TabIndex = 0;
		this.label1.Text = "解码地址";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label2.Location = new System.Drawing.Point(25, 91);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(138, 25);
		this.label2.TabIndex = 1;
		this.label2.Text = "解码地址信息";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.textBox1.Location = new System.Drawing.Point(169, 28);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(126, 25);
		this.textBox1.TabIndex = 2;
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Noaa_addr_KeyPress);
		this.textBox2.Location = new System.Drawing.Point(169, 91);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(423, 25);
		this.textBox2.TabIndex = 3;
		this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Noaa_addr_KeyPress);
		this.button1.Location = new System.Drawing.Point(169, 159);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 30);
		this.button1.TabIndex = 4;
		this.button1.Text = "确定";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button2.Location = new System.Drawing.Point(370, 159);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(75, 30);
		this.button2.TabIndex = 5;
		this.button2.Text = "取消";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(604, 218);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Name = "Noaa_addr";
		this.Text = "Noaa_addr";
		base.Load += new System.EventHandler(Noaa_addr_Load);
		base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Noaa_addr_KeyPress);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
