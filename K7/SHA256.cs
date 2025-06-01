using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace K7;

public class SHA256
{
	private static byte[] g_u8OmAuthSecret = new byte[32]
	{
		142, 64, 105, 32, 208, 65, 42, 77, 153, 88,
		96, 57, 241, 100, 32, 251, 34, 226, 145, 132,
		152, 251, 42, 182, 101, 80, 116, 255, 241, 184,
		248, 162
	};

	[DllImport("ss.dll", CharSet = CharSet.Ansi)]
	public static extern int set_secret(IntPtr secret);

	[DllImport("ss.dll", CharSet = CharSet.Ansi)]
	public static extern void ComputeMAC256(IntPtr MT, short length, IntPtr MAC);

	public static bool AuthCompute(string challengeRand, byte[] pageData, out byte[] computeValue)
	{
		byte[] array = new byte[128];
		computeValue = new byte[32];
		IntPtr intPtr = Marshal.AllocHGlobal(32);
		Marshal.WriteByte(intPtr, 0);
		IntPtr intPtr2 = ArrayToIntptr(g_u8OmAuthSecret);
		set_secret(intPtr2);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = 90;
		}
		pageData.CopyTo(array, 0);
		Encoding.Default.GetBytes(challengeRand).CopyTo(array, 32);
		IntPtr intPtr3 = ArrayToIntptr(array);
		ComputeMAC256(intPtr3, 119, intPtr);
		Marshal.Copy(intPtr, computeValue, 0, computeValue.Length);
		Marshal.FreeHGlobal(intPtr2);
		Marshal.FreeHGlobal(intPtr3);
		Marshal.FreeHGlobal(intPtr);
		return true;
	}

	public static IntPtr ArrayToIntptr(byte[] source)
	{
		if (source == null)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(source.Length);
		Marshal.Copy(source, 0, intPtr, source.Length);
		return intPtr;
	}

	public static string GetRandomString(int length)
	{
		string text = null;
		string text2 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
		byte[] array = new byte[4];
		RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
		rNGCryptoServiceProvider.GetBytes(array);
		Random random = new Random(BitConverter.ToInt32(array, 0));
		for (int i = 0; i < length; i++)
		{
			text += text2.Substring(random.Next(0, text2.Length - 1), 1);
		}
		return text;
	}
}
