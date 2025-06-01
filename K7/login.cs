using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class login : Form
{
	private IContainer components = null;

	private TextBox textBox1;

	private Label label7;

	private Button btn_cancel;

	private Button btn_ok;

	public login()
	{
		InitializeComponent();
		base.StartPosition = FormStartPosition.CenterScreen;
	}

	public string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	private void button7_Click(object sender, EventArgs e)
	{
		if (main.password_mode == "cps")
		{
			main.login = verify_password();
			Close();
			if (!main.login)
			{
				MessageBox.Show(GetLang("password_fail"));
			}
		}
		else if (textBox1.Text == "tk11" || textBox1.Text == "unlock")
		{
			main.gEngineerMode = true;
			MessageBox.Show(GetLang("passwrod_success"));
			Close();
		}
		else
		{
			main.gEngineerMode = false;
			MessageBox.Show(GetLang("password_fail"));
		}
	}

	public bool verify_password()
	{
		bool flag = false;
		byte[] array = new byte[32];
		byte[] array2 = new byte[16];
		byte[] array3 = new byte[16];
		uint[] array4 = new uint[4];
		uint[] iv = new uint[4];
		string s = textBox1.Text.Trim();
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
		return protocol_struct.AuthReq(array4);
	}

	private void button6_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void login_Load(object sender, EventArgs e)
	{
		btn_ok.Text = GetLang("OK");
		btn_cancel.Text = GetLang("cancel");
		label7.Text = GetLang("密码");
		base.Icon = Resources.标题;
		main.login = false;
	}

	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
		this.label7 = new System.Windows.Forms.Label();
		this.btn_cancel = new System.Windows.Forms.Button();
		this.btn_ok = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.textBox1.Location = new System.Drawing.Point(201, 33);
		this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox1.MaxLength = 10;
		this.textBox1.Name = "textBox1";
		this.textBox1.PasswordChar = '*';
		this.textBox1.Size = new System.Drawing.Size(132, 25);
		this.textBox1.TabIndex = 75;
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.label7.Location = new System.Drawing.Point(44, 36);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(151, 22);
		this.label7.TabIndex = 74;
		this.label7.Text = "密码";
		this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btn_cancel.Location = new System.Drawing.Point(311, 109);
		this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.btn_cancel.Name = "btn_cancel";
		this.btn_cancel.Size = new System.Drawing.Size(88, 29);
		this.btn_cancel.TabIndex = 85;
		this.btn_cancel.Text = "取消";
		this.btn_cancel.UseVisualStyleBackColor = true;
		this.btn_cancel.Click += new System.EventHandler(button6_Click);
		this.btn_ok.Location = new System.Drawing.Point(93, 109);
		this.btn_ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.btn_ok.Name = "btn_ok";
		this.btn_ok.Size = new System.Drawing.Size(88, 29);
		this.btn_ok.TabIndex = 84;
		this.btn_ok.Text = "确定";
		this.btn_ok.UseVisualStyleBackColor = true;
		this.btn_ok.Click += new System.EventHandler(button7_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(486, 176);
		base.Controls.Add(this.btn_cancel);
		base.Controls.Add(this.btn_ok);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label7);
		base.Name = "login";
		this.Text = "login";
		base.Load += new System.EventHandler(login_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
