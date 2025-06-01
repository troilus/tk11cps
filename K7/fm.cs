using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class fm : Form
{
	private IContainer components = null;

	private TextBox textBox1;

	private Label label1;

	private Button button4;

	private Button button3;

	public fm()
	{
		InitializeComponent();
	}

	public static string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	private void button3_Click(object sender, EventArgs e)
	{
		if (CheckVaildData())
		{
			main.FmInfo[main.fm_Index].freq = textBox1.Text;
			Close();
		}
	}

	private void fm_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
		textBox1.MaxLength = 5;
		label1.Text = GetLang("fm_freq");
		textBox1.Text = main.FmInfo[main.fm_Index].freq;
		button3.Text = GetLang("OK");
		button4.Text = GetLang("cancel");
		Text = GetLang("fm_edit") + "-" + (main.fm_Index + 1);
	}

	private void button4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
		{
			e.Handled = true;
		}
	}

	public bool CheckVaildData()
	{
		double num = 0.0;
		bool result = false;
		try
		{
			if (string.IsNullOrEmpty(textBox1.Text))
			{
				result = true;
			}
			else
			{
				num = Convert.ToDouble(textBox1.Text);
				if (num >= 76.0 && num <= 108.0)
				{
					textBox1.Text = num.ToString("F2");
					result = true;
				}
				else
				{
					MessageBox.Show(GetLang("OutOfRang"));
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		return result;
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
		this.button4 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.textBox1.Location = new System.Drawing.Point(158, 65);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(133, 25);
		this.textBox1.TabIndex = 3;
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label1.Location = new System.Drawing.Point(23, 68);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(129, 18);
		this.label1.TabIndex = 2;
		this.label1.Text = "频率";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button4.Location = new System.Drawing.Point(203, 138);
		this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(88, 29);
		this.button4.TabIndex = 85;
		this.button4.Text = "取消";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click);
		this.button3.Location = new System.Drawing.Point(56, 138);
		this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(88, 29);
		this.button3.TabIndex = 84;
		this.button3.Text = "确定";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(373, 218);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label1);
		base.Name = "fm";
		this.Text = "fm";
		base.Load += new System.EventHandler(fm_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
