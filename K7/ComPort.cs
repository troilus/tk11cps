using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace K7;

internal class ComPort
{
	public static SerialPort serialPorts;

	private static ComPort _instance = null;

	public static ComPort Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new ComPort();
			}
			return _instance;
		}
	}

	public string GetLang(string s)
	{
		string @string = main.RM.GetString(s);
		string[] array = @string.Split('/');
		return array[main.GetLang()];
	}

	private ComPort()
	{
		serialPorts = new SerialPort();
		serialPorts.BaudRate = 38400;
		serialPorts.DataBits = 8;
		serialPorts.StopBits = StopBits.One;
		serialPorts.WriteTimeout = 10000;
		serialPorts.ReadTimeout = 1000;
		serialPorts.RtsEnable = false;
	}

	public bool Open()
	{
		try
		{
			wfm_progress.exit = false;
			serialPorts.PortName = main.GetComName().Trim().ToUpper();
			if (serialPorts.IsOpen)
			{
				return true;
			}
			serialPorts.Open();
			return true;
		}
		catch (Exception)
		{
			MessageBox.Show(GetLang("com_error"));
		}
		return false;
	}

	public bool Close()
	{
		try
		{
			serialPorts.Close();
			return true;
		}
		catch (Exception)
		{
		}
		return false;
	}

	public bool Write(byte[] buf)
	{
		bool result = true;
		serialPorts.Write(buf, 0, buf.Length);
		return result;
	}

	public bool ReadAck()
	{
		bool result = false;
		byte[] array = Read(1000);
		if (array != null && array[0] == 6)
		{
			result = true;
		}
		return result;
	}

	public byte[] Read(int timeout)
	{
		byte[] array = new byte[2000];
		byte[] array2 = null;
		int num = 0;
		for (int i = 0; i < timeout / 10; i++)
		{
			if (wfm_progress.exit)
			{
				break;
			}
			Thread.Sleep(10);
			if (serialPorts.BytesToRead > 0)
			{
				array2 = new byte[serialPorts.BytesToRead];
				serialPorts.Read(array2, 0, array2.Length);
				Array.Copy(array2, 0, array, num, array2.Length);
				num += array2.Length;
				if (array[0] == 171 && array[1] == 205 && array[num - 2] == 220 && array[num - 1] == 186)
				{
					break;
				}
			}
		}
		return array;
	}
}
