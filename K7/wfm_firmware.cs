using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class wfm_firmware : Form
{
	private IContainer components = null;

	private Button btnBrowseRes;

	private Button btnUpdateRes;

	private TextBox txtResource;

	private Label label5;

	private Button btnBrowse;

	private Button btnUpdate;

	private TextBox txtProgram;

	private Label label3;

	public wfm_firmware()
	{
		InitializeComponent();
	}

	public static string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	private void btnBrowse_Click(object sender, EventArgs e)
	{
		Button button = sender as Button;
		string text = ((button != btnBrowse) ? "resource" : "program");
		OpenFileDialog openFileDialog = new OpenFileDialog();
		string text2 = Iparse.getchart("path", text);
		if (!Directory.Exists(text2))
		{
			text2 = Application.StartupPath;
		}
		openFileDialog.FileName = text;
		if (button == btnBrowse)
		{
			openFileDialog.Filter = "(*.bin)|*.bin";
		}
		else
		{
			openFileDialog.Filter = "(*.ZK)|*.ZK";
		}
		openFileDialog.InitialDirectory = text2;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			text2 = openFileDialog.FileName.ToString();
			if (button == btnBrowse)
			{
				txtProgram.Text = text2;
			}
			else
			{
				txtResource.Text = text2;
			}
			Iparse.setchart("path", text, text2);
		}
	}

	private void wfm_firmware_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
		txtProgram.Text = Iparse.getchart("path", "program");
		txtResource.Text = Iparse.getchart("path", "resource");
		label3.Text = GetLang("program_file");
		label5.Text = GetLang("resource_file");
		btnUpdate.Text = GetLang("Updata");
		btnUpdateRes.Text = GetLang("Updata");
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		Button button = sender as Button;
		if (button == btnUpdate)
		{
			main.m_Progress = "updata";
		}
		else
		{
			main.m_Progress = "resource";
		}
		wfm_progress wfm_progress2 = new wfm_progress();
		wfm_progress2.ShowDialog();
	}

	private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
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
		this.btnBrowseRes = new System.Windows.Forms.Button();
		this.btnUpdateRes = new System.Windows.Forms.Button();
		this.txtResource = new System.Windows.Forms.TextBox();
		this.label5 = new System.Windows.Forms.Label();
		this.btnBrowse = new System.Windows.Forms.Button();
		this.btnUpdate = new System.Windows.Forms.Button();
		this.txtProgram = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.btnBrowseRes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnBrowseRes.Location = new System.Drawing.Point(669, 87);
		this.btnBrowseRes.Margin = new System.Windows.Forms.Padding(4);
		this.btnBrowseRes.Name = "btnBrowseRes";
		this.btnBrowseRes.Size = new System.Drawing.Size(44, 29);
		this.btnBrowseRes.TabIndex = 15;
		this.btnBrowseRes.Text = "...";
		this.btnBrowseRes.UseVisualStyleBackColor = true;
		this.btnBrowseRes.Click += new System.EventHandler(btnBrowse_Click);
		this.btnUpdateRes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnUpdateRes.Location = new System.Drawing.Point(721, 87);
		this.btnUpdateRes.Margin = new System.Windows.Forms.Padding(4);
		this.btnUpdateRes.Name = "btnUpdateRes";
		this.btnUpdateRes.Size = new System.Drawing.Size(100, 29);
		this.btnUpdateRes.TabIndex = 14;
		this.btnUpdateRes.Text = "升级";
		this.btnUpdateRes.UseVisualStyleBackColor = true;
		this.btnUpdateRes.Click += new System.EventHandler(btnUpdate_Click);
		this.txtResource.Location = new System.Drawing.Point(248, 88);
		this.txtResource.Margin = new System.Windows.Forms.Padding(4);
		this.txtResource.MaxLength = 16;
		this.txtResource.Name = "txtResource";
		this.txtResource.ReadOnly = true;
		this.txtResource.Size = new System.Drawing.Size(412, 25);
		this.txtResource.TabIndex = 13;
		this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.label5.Location = new System.Drawing.Point(29, 94);
		this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(211, 15);
		this.label5.TabIndex = 12;
		this.label5.Text = "资源文件：";
		this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btnBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnBrowse.Location = new System.Drawing.Point(669, 41);
		this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
		this.btnBrowse.Name = "btnBrowse";
		this.btnBrowse.Size = new System.Drawing.Size(44, 29);
		this.btnBrowse.TabIndex = 11;
		this.btnBrowse.Text = "...";
		this.btnBrowse.UseVisualStyleBackColor = true;
		this.btnBrowse.Click += new System.EventHandler(btnBrowse_Click);
		this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnUpdate.Location = new System.Drawing.Point(721, 41);
		this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
		this.btnUpdate.Name = "btnUpdate";
		this.btnUpdate.Size = new System.Drawing.Size(100, 29);
		this.btnUpdate.TabIndex = 10;
		this.btnUpdate.Text = "升级";
		this.btnUpdate.UseVisualStyleBackColor = true;
		this.btnUpdate.Click += new System.EventHandler(btnUpdate_Click);
		this.txtProgram.Location = new System.Drawing.Point(248, 43);
		this.txtProgram.Margin = new System.Windows.Forms.Padding(4);
		this.txtProgram.MaxLength = 16;
		this.txtProgram.Name = "txtProgram";
		this.txtProgram.ReadOnly = true;
		this.txtProgram.Size = new System.Drawing.Size(412, 25);
		this.txtProgram.TabIndex = 9;
		this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.label3.Location = new System.Drawing.Point(29, 48);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(211, 15);
		this.label3.TabIndex = 8;
		this.label3.Text = "程序文件：";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1011, 182);
		base.Controls.Add(this.btnBrowseRes);
		base.Controls.Add(this.btnUpdateRes);
		base.Controls.Add(this.txtResource);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.btnBrowse);
		base.Controls.Add(this.btnUpdate);
		base.Controls.Add(this.txtProgram);
		base.Controls.Add(this.label3);
		base.Name = "wfm_firmware";
		this.Text = "wfm_firmware";
		base.Load += new System.EventHandler(wfm_firmware_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
