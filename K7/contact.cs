using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class contact : Form
{
	private IContainer components = null;

	private TextBox textBox2;

	private TextBox textBox1;

	private Label label2;

	private Label label1;

	private Button button4;

	private Button button3;

	public contact()
	{
		InitializeComponent();
		textBox2.MaxLength = 3;
	}

	public static string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	private void button3_Click(object sender, EventArgs e)
	{
		if (main.click_item == "dtmf")
		{
			DTMF_CONTACT_INFO dTMF_CONTACT_INFO = default(DTMF_CONTACT_INFO);
			dTMF_CONTACT_INFO.name = textBox1.Text;
			dTMF_CONTACT_INFO.id = textBox2.Text;
			main.DtmfContactInfo[main.contact_Index] = dTMF_CONTACT_INFO;
		}
		else
		{
			_5TONE_CONTACT_INFO _5TONE_CONTACT_INFO2 = default(_5TONE_CONTACT_INFO);
			_5TONE_CONTACT_INFO2.name = textBox1.Text;
			_5TONE_CONTACT_INFO2.id = textBox2.Text;
			main._5toneContactInfo[main.contact_Index] = _5TONE_CONTACT_INFO2;
		}
		Close();
	}

	private void button4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void contact_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
		label1.Text = GetLang("chn_name");
		label2.Text = GetLang("dtmf_code");
		button3.Text = GetLang("OK");
		button4.Text = GetLang("cancel");
		Text = GetLang("contact_edit") + "-" + (main.contact_Index + 1);
		if (main.click_item == "dtmf")
		{
			DTMF_CONTACT_INFO dTMF_CONTACT_INFO = main.DtmfContactInfo[main.contact_Index];
			textBox1.Text = dTMF_CONTACT_INFO.name;
			textBox2.Text = dTMF_CONTACT_INFO.id;
		}
		else
		{
			_5TONE_CONTACT_INFO _5TONE_CONTACT_INFO2 = main._5toneContactInfo[main.contact_Index];
			textBox1.Text = _5TONE_CONTACT_INFO2.name;
			textBox2.Text = _5TONE_CONTACT_INFO2.id;
		}
	}

	private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
	{
		e.KeyChar = char.ToUpper(e.KeyChar);
		if (e.KeyChar != '\b' && !dtmf.IsDtmfCode(e.KeyChar))
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
			if (num > 8)
			{
				e.Handled = true;
			}
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
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.button4 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.textBox2.Location = new System.Drawing.Point(190, 94);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(183, 25);
		this.textBox2.TabIndex = 7;
		this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox2_KeyPress);
		this.textBox1.Location = new System.Drawing.Point(190, 40);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(183, 25);
		this.textBox1.TabIndex = 6;
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label2.Location = new System.Drawing.Point(57, 97);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(115, 15);
		this.label2.TabIndex = 5;
		this.label2.Text = "呼叫ID";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.label1.Location = new System.Drawing.Point(57, 43);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(115, 15);
		this.label1.TabIndex = 4;
		this.label1.Text = "名称";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button4.Location = new System.Drawing.Point(240, 164);
		this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(88, 29);
		this.button4.TabIndex = 89;
		this.button4.Text = "取消";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click);
		this.button3.Location = new System.Drawing.Point(94, 164);
		this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(88, 29);
		this.button3.TabIndex = 88;
		this.button3.Text = "确定";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(429, 231);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Name = "contact";
		this.Text = "contact";
		base.Load += new System.EventHandler(contact_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
