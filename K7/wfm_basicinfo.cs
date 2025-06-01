using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class wfm_basicinfo : Form
{
	private IContainer components = null;

	private Label label1;

	private TextBox textBox1;

	public wfm_basicinfo()
	{
		InitializeComponent();
		textBox1.Enabled = false;
		Text = GetLang("basic_info");
		label1.Text = GetLang("cps_version");
	}

	public static string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	private void wfm_basicinfo_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
		if (ComPort.Instance.Open())
		{
			if (!protocol_struct.Link(1))
			{
				ComPort.Instance.Close();
				MessageBox.Show(GetLang("link_error"));
				Close();
				return;
			}
			ComPort.Instance.Close();
			if (protocol_struct.Model != main.ModelVersion)
			{
				MessageBox.Show(GetLang("model_error"));
			}
			else
			{
				textBox1.Text = protocol_struct.cps_version;
			}
		}
		else
		{
			Close();
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
		this.textBox1 = new System.Windows.Forms.TextBox();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(73, 88);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(63, 15);
		this.label1.TabIndex = 0;
		this.label1.Text = "version";
		this.textBox1.Location = new System.Drawing.Point(142, 85);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(277, 25);
		this.textBox1.TabIndex = 1;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(495, 238);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label1);
		base.Name = "wfm_basicinfo";
		this.Text = "wfm_basicinfo";
		base.Load += new System.EventHandler(wfm_basicinfo_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
