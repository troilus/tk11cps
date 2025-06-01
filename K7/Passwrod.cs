using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class Passwrod : Form
{
	private IContainer components = null;

	private TextBox txtbox_old;

	private Label label1;

	private TextBox txtbox_new;

	private Label label2;

	private Button btn_cancel;

	private Button btn_ok;

	private TextBox txtbox_verify;

	private Label label3;

	public Passwrod()
	{
		InitializeComponent();
		base.StartPosition = FormStartPosition.CenterScreen;
	}

	public static string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	private void button4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button3_Click(object sender, EventArgs e)
	{
		if (txtbox_new.Text != txtbox_verify.Text)
		{
			GetLang("password_different");
		}
		else if (ComPort.Instance.Open())
		{
			bool flag = modify_password();
			ComPort.Instance.Close();
			if (flag)
			{
				MessageBox.Show(GetLang("success"));
				Close();
			}
			else
			{
				MessageBox.Show(GetLang("fail"));
			}
		}
	}

	public bool modify_password()
	{
		if (!protocol_struct.Link(5))
		{
			MessageBox.Show(GetLang("link_error"));
			return false;
		}
		if (protocol_struct.Model != main.ModelVersion)
		{
			MessageBox.Show(GetLang("model_error"));
			return false;
		}
		bool flag = false;
		byte[] array = new byte[32];
		byte[] array2 = new byte[16];
		byte[] array3 = new byte[16];
		uint[] array4 = new uint[4];
		uint[] iv = new uint[4];
		string s = txtbox_old.Text.Trim();
		string text = txtbox_new.Text.Trim();
		if (!txtbox_old.Enabled)
		{
			s = "qs975bj";
		}
		if (Encoding.UTF8.GetBytes(text).Length <= 32)
		{
			Encoding.UTF8.GetBytes(s).CopyTo(array, 0);
			SHA256.AuthCompute("xiaoxiao", array, out var computeValue);
			for (int i = 0; i < computeValue.Length / 2; i++)
			{
				array2[i] = (byte)(computeValue[i] ^ computeValue[31 - i]);
			}
			uint[] array5 = new uint[4];
			for (int i = 0; i < array2.Length / 4; i++)
			{
				array5[i] = BitConverter.ToUInt32(array2, i * 4);
			}
			byte[] array6 = Util.AESEncrypt(protocol_struct.ChallengeRand, array5, iv).Take(protocol_struct.ChallengeRand.Length).ToArray();
			for (int i = 0; i < array6.Length / 4; i++)
			{
				array4[i] = BitConverter.ToUInt32(array6.Skip(i * 4).Take(4).Reverse()
					.ToArray(), 0);
			}
			array = new byte[32];
			Encoding.UTF8.GetBytes(text).CopyTo(array, 0);
			SHA256.AuthCompute("xiaoxiao", array, out computeValue);
			for (int i = 0; i < computeValue.Length / 2; i++)
			{
				array3[i] = (byte)(computeValue[i] ^ computeValue[31 - i]);
			}
			flag = protocol_struct.AuthReq(array4);
			if (flag)
			{
				if (string.IsNullOrEmpty(text))
				{
					for (int i = 0; i < array3.Length; i++)
					{
						array3[i] = byte.MaxValue;
					}
				}
				flag = protocol_struct.Write(98304, array3, (ushort)array3.Length);
			}
		}
		return flag;
	}

	public bool check_password(byte[] old_val, byte[] new_val)
	{
		if (old_val.Length != new_val.Length)
		{
			return false;
		}
		for (int i = 0; i < old_val.Length; i++)
		{
			if (old_val[i] != new_val[i])
			{
				return false;
			}
		}
		return true;
	}

	private void Passwrod_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
		label1.Text = GetLang("password_old");
		label2.Text = GetLang("password_new");
		label3.Text = GetLang("password_verify");
		btn_ok.Text = GetLang("OK");
		btn_cancel.Text = GetLang("cancel");
		bool flag = true;
		if (ComPort.Instance.Open())
		{
			if (!protocol_struct.Link(5))
			{
				flag = false;
				MessageBox.Show(GetLang("link_error"));
			}
			if (protocol_struct.Model != main.ModelVersion)
			{
				MessageBox.Show(GetLang("model_error"));
				return;
			}
			ComPort.Instance.Close();
			if (!flag)
			{
				Close();
			}
			else if (protocol_struct.u8PasswordValid == 0)
			{
				txtbox_old.Enabled = false;
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
		this.txtbox_old = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.txtbox_new = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.btn_cancel = new System.Windows.Forms.Button();
		this.btn_ok = new System.Windows.Forms.Button();
		this.txtbox_verify = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.txtbox_old.Location = new System.Drawing.Point(175, 34);
		this.txtbox_old.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.txtbox_old.MaxLength = 10;
		this.txtbox_old.Name = "txtbox_old";
		this.txtbox_old.PasswordChar = '*';
		this.txtbox_old.Size = new System.Drawing.Size(182, 25);
		this.txtbox_old.TabIndex = 107;
		this.label1.Location = new System.Drawing.Point(38, 35);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(131, 22);
		this.label1.TabIndex = 106;
		this.label1.Text = "旧密码";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.txtbox_new.Location = new System.Drawing.Point(175, 89);
		this.txtbox_new.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.txtbox_new.MaxLength = 10;
		this.txtbox_new.Name = "txtbox_new";
		this.txtbox_new.PasswordChar = '*';
		this.txtbox_new.Size = new System.Drawing.Size(182, 25);
		this.txtbox_new.TabIndex = 109;
		this.label2.Location = new System.Drawing.Point(38, 90);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(131, 22);
		this.label2.TabIndex = 108;
		this.label2.Text = "新密码";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_cancel.Location = new System.Drawing.Point(269, 213);
		this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.btn_cancel.Name = "btn_cancel";
		this.btn_cancel.Size = new System.Drawing.Size(88, 29);
		this.btn_cancel.TabIndex = 161;
		this.btn_cancel.Text = "取消";
		this.btn_cancel.UseVisualStyleBackColor = true;
		this.btn_cancel.Click += new System.EventHandler(button4_Click);
		this.btn_ok.Location = new System.Drawing.Point(81, 213);
		this.btn_ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.btn_ok.Name = "btn_ok";
		this.btn_ok.Size = new System.Drawing.Size(88, 29);
		this.btn_ok.TabIndex = 160;
		this.btn_ok.Text = "确定";
		this.btn_ok.UseVisualStyleBackColor = true;
		this.btn_ok.Click += new System.EventHandler(button3_Click);
		this.txtbox_verify.Location = new System.Drawing.Point(175, 143);
		this.txtbox_verify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.txtbox_verify.MaxLength = 10;
		this.txtbox_verify.Name = "txtbox_verify";
		this.txtbox_verify.PasswordChar = '*';
		this.txtbox_verify.Size = new System.Drawing.Size(182, 25);
		this.txtbox_verify.TabIndex = 163;
		this.label3.Location = new System.Drawing.Point(38, 144);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(131, 22);
		this.label3.TabIndex = 162;
		this.label3.Text = "确认密码";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(408, 269);
		base.Controls.Add(this.txtbox_verify);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.btn_cancel);
		base.Controls.Add(this.btn_ok);
		base.Controls.Add(this.txtbox_new);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.txtbox_old);
		base.Controls.Add(this.label1);
		base.Name = "Passwrod";
		this.Text = "Passwrod";
		base.Load += new System.EventHandler(Passwrod_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
