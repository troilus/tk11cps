using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using K7.Properties;

namespace K7;

public class scan : Form
{
	private IContainer components = null;

	private TextBox textBox1;

	private ComboBox cmb_prio2;

	private Label label7;

	private ComboBox cmb_prio1;

	private Label label4;

	private Button button2;

	private Button button1;

	private ListBox listBox2;

	private ListBox listBox1;

	private Label label1;

	private Button button4;

	private Button button3;

	public scan()
	{
		InitializeComponent();
	}

	public static string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	public void LoadComboBoxString(ComboBox cmb, List<string> list)
	{
		cmb.Items.Clear();
		for (int i = 0; i < list.Count; i++)
		{
			cmb.Items.Add(list[i]);
		}
		cmb.DropDownStyle = ComboBoxStyle.DropDownList;
	}

	private void scan_Load(object sender, EventArgs e)
	{
		base.Icon = Resources.标题;
		label1.Text = GetLang("chn_name");
		label4.Text = GetLang("prio_1");
		label7.Text = GetLang("prio_2");
		button3.Text = GetLang("OK");
		button4.Text = GetLang("cancel");
		Text = GetLang("scan_edit") + "-" + (main.scan_Index + 1);
		LoadParam();
	}

	public void LoadLang()
	{
		LoadComboBoxString(cmb_prio1, GetPrioChnString());
		LoadComboBoxString(cmb_prio2, GetPrioChnString());
	}

	public List<string> GetPrioChnString()
	{
		List<string> list = new List<string>();
		list.Add(GetLang("_null"));
		foreach (object item in listBox2.Items)
		{
			list.Add(item.ToString());
		}
		return list;
	}

	public void LoadParam()
	{
		SCAN_INFO sCAN_INFO = main.ScanInfo[main.scan_Index];
		if (string.IsNullOrEmpty(sCAN_INFO.name))
		{
			sCAN_INFO.name = GetLang("scan_list") + (main.scan_Index + 1);
			sCAN_INFO.prio_1 = GetLang("_null");
			sCAN_INFO.prio_2 = sCAN_INFO.prio_1;
			sCAN_INFO.member = new string[48];
		}
		textBox1.Text = sCAN_INFO.name;
		listBox2.Items.Add(GetLang("scan_current_ch"));
		string[] channelName = main.GetChannelName();
		if (channelName.Length > 0)
		{
			string[] array = channelName;
			foreach (string text in array)
			{
				if (!sCAN_INFO.member.Contains(text))
				{
					listBox1.Items.Add(text);
				}
				else
				{
					listBox2.Items.Add(text);
				}
			}
		}
		LoadLang();
		cmb_prio1.Text = sCAN_INFO.prio_1;
		cmb_prio2.Text = sCAN_INFO.prio_2;
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
			if (num > 10)
			{
				e.Handled = true;
			}
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		SCAN_INFO sCAN_INFO = default(SCAN_INFO);
		sCAN_INFO.name = textBox1.Text;
		sCAN_INFO.member = new string[49];
		sCAN_INFO.prio_1 = cmb_prio1.Text;
		sCAN_INFO.prio_2 = cmb_prio2.Text;
		int num = 0;
		foreach (object item in listBox2.Items)
		{
			sCAN_INFO.member[num++] = (string)item;
		}
		main.ScanInfo[main.scan_Index] = sCAN_INFO;
		Close();
	}

	private void button4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		int num = 0;
		if (listBox1.Items.Count > 0 && listBox2.Items.Count < 49 && listBox1.SelectedItem != null)
		{
			num = listBox1.SelectedIndex;
			listBox2.Items.Add(listBox1.SelectedItem);
			listBox1.Items.Remove(listBox1.SelectedItem);
			if (num < listBox1.Items.Count)
			{
				listBox1.SelectedIndex = num;
			}
			else
			{
				listBox1.SelectedIndex = listBox1.Items.Count - 1;
			}
			if (listBox2.Items.Count == 1)
			{
				listBox2.SelectedIndex = 0;
			}
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		int num = 0;
		if (listBox2.SelectedIndex != 0 && listBox2.Items.Count > 0 && listBox2.SelectedItem != null)
		{
			num = listBox2.SelectedIndex;
			DeletePrioCh(listBox2.SelectedItem.ToString());
			listBox1.Items.Add(listBox2.SelectedItem);
			listBox2.Items.Remove(listBox2.SelectedItem);
			if (num < listBox2.Items.Count)
			{
				listBox2.SelectedIndex = num;
			}
			else
			{
				listBox2.SelectedIndex = listBox2.Items.Count - 1;
			}
			if (listBox1.Items.Count == 1)
			{
				listBox1.SelectedIndex = 0;
			}
		}
	}

	public void DeletePrioCh(string name)
	{
		if (cmb_prio1.Text == name)
		{
			cmb_prio1.Text = GetLang("_null");
		}
		if (cmb_prio2.Text == name)
		{
			cmb_prio2.Text = GetLang("_null");
		}
	}

	private void cmb_prio1_Click(object sender, EventArgs e)
	{
	}

	private void cmb_prio1_Enter(object sender, EventArgs e)
	{
		ComboBox comboBox = sender as ComboBox;
		string text = comboBox.Text;
		LoadComboBoxString(comboBox, GetPrioChnString());
		comboBox.Text = text;
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
		this.cmb_prio2 = new System.Windows.Forms.ComboBox();
		this.label7 = new System.Windows.Forms.Label();
		this.cmb_prio1 = new System.Windows.Forms.ComboBox();
		this.label4 = new System.Windows.Forms.Label();
		this.button2 = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.listBox2 = new System.Windows.Forms.ListBox();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.label1 = new System.Windows.Forms.Label();
		this.button4 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.textBox1.Location = new System.Drawing.Point(293, 19);
		this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.textBox1.MaxLength = 10;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(182, 25);
		this.textBox1.TabIndex = 105;
		this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox1_KeyPress);
		this.cmb_prio2.FormattingEnabled = true;
		this.cmb_prio2.Location = new System.Drawing.Point(338, 422);
		this.cmb_prio2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.cmb_prio2.Name = "cmb_prio2";
		this.cmb_prio2.Size = new System.Drawing.Size(129, 23);
		this.cmb_prio2.TabIndex = 104;
		this.cmb_prio2.Enter += new System.EventHandler(cmb_prio1_Enter);
		this.label7.Location = new System.Drawing.Point(171, 422);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(162, 22);
		this.label7.TabIndex = 103;
		this.label7.Text = "优先2模式";
		this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.cmb_prio1.FormattingEnabled = true;
		this.cmb_prio1.Location = new System.Drawing.Point(338, 382);
		this.cmb_prio1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.cmb_prio1.Name = "cmb_prio1";
		this.cmb_prio1.Size = new System.Drawing.Size(129, 23);
		this.cmb_prio1.TabIndex = 102;
		this.cmb_prio1.Click += new System.EventHandler(cmb_prio1_Click);
		this.cmb_prio1.Enter += new System.EventHandler(cmb_prio1_Enter);
		this.label4.Location = new System.Drawing.Point(174, 382);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(159, 22);
		this.label4.TabIndex = 101;
		this.label4.Text = "优先1模式";
		this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button2.Location = new System.Drawing.Point(338, 169);
		this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(88, 33);
		this.button2.TabIndex = 100;
		this.button2.Text = "<<";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button1.Location = new System.Drawing.Point(338, 113);
		this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(88, 33);
		this.button1.TabIndex = 99;
		this.button1.Text = ">>";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.listBox2.FormattingEnabled = true;
		this.listBox2.ItemHeight = 15;
		this.listBox2.Location = new System.Drawing.Point(452, 90);
		this.listBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.listBox2.Name = "listBox2";
		this.listBox2.Size = new System.Drawing.Size(232, 274);
		this.listBox2.TabIndex = 98;
		this.listBox1.FormattingEnabled = true;
		this.listBox1.ItemHeight = 15;
		this.listBox1.Location = new System.Drawing.Point(81, 90);
		this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(232, 274);
		this.listBox1.TabIndex = 97;
		this.label1.Location = new System.Drawing.Point(130, 20);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(157, 22);
		this.label1.TabIndex = 96;
		this.label1.Text = "扫描列表别名";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button4.Location = new System.Drawing.Point(533, 479);
		this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(88, 29);
		this.button4.TabIndex = 159;
		this.button4.Text = "取消";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click);
		this.button3.Location = new System.Drawing.Point(174, 479);
		this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(88, 29);
		this.button3.TabIndex = 158;
		this.button3.Text = "确定";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(834, 533);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.cmb_prio2);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.cmb_prio1);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.listBox2);
		base.Controls.Add(this.listBox1);
		base.Controls.Add(this.label1);
		base.Name = "scan";
		this.Text = "scan";
		base.Load += new System.EventHandler(scan_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
