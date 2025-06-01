using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace K7;

public static class Util
{
	public static byte[,] updatakey = new byte[16, 32]
	{
		{
			225, 110, 13, 41, 224, 200, 52, 24, 152, 127,
			148, 51, 245, 255, 98, 14, 20, 183, 162, 190,
			2, 35, 226, 89, 178, 6, 109, 136, 134, 151,
			126, 54
		},
		{
			168, 239, 79, 145, 118, 136, 197, 193, 72, 127,
			42, 106, 129, 30, 85, 77, 50, 200, 96, 223,
			206, 101, 202, 48, 46, 197, 52, 170, 95, 136,
			136, 75
		},
		{
			19, 87, 204, 36, 209, 56, 165, 119, 153, 221,
			14, 236, 91, 154, 24, 249, 251, 20, 157, 76,
			69, 231, 215, 169, 90, 166, 75, 194, 39, 101,
			168, 192
		},
		{
			103, 236, 124, 56, 206, 250, 158, 219, 56, 187,
			137, 181, 137, 134, 235, 26, 47, 154, 52, 188,
			236, 48, 43, 198, 197, 182, 188, 85, 44, 22,
			109, 201
		},
		{
			115, 77, 216, 172, 132, 192, 196, 34, 203, 202,
			40, 254, 200, 133, 100, 115, 75, 254, 53, 88,
			36, 54, 87, 128, 20, 233, 112, 237, 141, 171,
			158, 160
		},
		{
			151, 163, 135, 86, 123, 35, 75, 85, 201, 33,
			205, 130, 246, 95, 0, 135, 232, 171, 78, 14,
			52, 76, 181, 160, 177, 231, 219, 122, 5, 212,
			104, 195
		},
		{
			8, 234, 58, 125, 200, 166, 233, 97, 183, 6,
			31, 126, 82, 236, 142, 109, 95, 111, 46, 205,
			131, 93, 118, 11, 92, 30, 120, 240, 190, 26,
			135, 135
		},
		{
			79, 217, 215, 36, 57, 22, 84, 60, 35, 173,
			153, 89, 55, 228, 187, 124, 161, 11, 231, 3,
			41, 96, 198, 213, 220, 189, 198, 180, 236, 251,
			227, 26
		},
		{
			127, 103, 72, 5, 112, 186, 82, 84, 215, 206,
			229, 156, 162, 164, 131, 181, 150, 133, 140, 223,
			89, 69, 74, 95, 168, 79, 170, 54, 99, 116,
			139, 141
		},
		{
			78, 50, 76, 86, 94, 50, 190, 138, 106, 175,
			38, 217, 255, 55, 238, 135, 61, 104, 11, 21,
			166, 39, 76, 114, 188, 51, 19, 161, 131, 241,
			55, 43
		},
		{
			161, 214, 198, 28, 140, 92, 34, 129, 220, 126,
			55, 28, 163, 195, 241, 104, 146, 94, 183, 120,
			35, 46, 139, 75, 31, 6, 165, 130, 73, 139,
			33, 73
		},
		{
			17, 224, 101, 237, 63, 158, 139, 150, 186, 230,
			31, 121, 167, 216, 163, 23, 139, 103, 151, 132,
			113, 251, 211, 113, 220, 244, 78, 217, 47, 86,
			86, 45
		},
		{
			240, 36, 14, 2, 237, 93, 169, 101, 83, 157,
			129, 83, 6, 242, 211, 75, 198, 17, 107, 213,
			190, 163, 134, 115, 116, 98, 5, 238, 83, 77,
			88, 159
		},
		{
			196, 99, 105, 88, 225, 131, 15, 35, 198, 217,
			206, 21, 178, 221, 195, 90, 91, 114, 55, 221,
			185, 197, 41, 14, 21, 81, 144, 24, 206, 172,
			186, 118
		},
		{
			191, 152, 98, 214, 128, 249, 72, 25, 95, 92,
			144, 84, 94, 29, 133, 120, 129, 114, 234, 20,
			145, 107, 96, 104, 85, 255, 42, 171, 229, 46,
			153, 60
		},
		{
			176, 217, 58, 247, 118, 26, 80, 202, 203, 150,
			110, 184, 168, 5, 188, 187, 145, 108, 80, 251,
			158, 72, 6, 147, 177, 85, 178, 229, 85, 203,
			120, 10
		}
	};

	public static bool IsOnlyNumber(string value)
	{
		Regex regex = new Regex("^[0-9]+$");
		return regex.Match(value).Success;
	}

	public static bool IsOnlyWord(string value)
	{
		Regex regex = new Regex("^[a-zA-Z]+$");
		return regex.Match(value).Success;
	}

	public static bool IsNumberAndWord(string value)
	{
		Regex regex = new Regex("^[a-zA-Z0-9]+$");
		return regex.Match(value).Success;
	}

	public static bool IsIllegalHexadecimal(string value)
	{
		Regex regex = new Regex("([^A-Fa-f0-9]|\\s+?)+");
		return regex.Match(value).Success;
	}

	public static bool ContentNorOr(ref byte[] content)
	{
		byte[] array = new byte[16]
		{
			22, 108, 20, 230, 46, 145, 13, 64, 33, 53,
			213, 64, 19, 3, 233, 128
		};
		for (int i = 0; i < content.Length; i++)
		{
			content[i] ^= array[i % array.Length];
		}
		return true;
	}

	public static bool ContentNorOrEx(ref byte[] content, int flag)
	{
		byte[] array = new byte[16]
		{
			15, 43, 241, 184, 147, 35, 236, 72, 186, 116,
			149, 124, 157, 110, 221, 175
		};
		byte[] array2 = new byte[16]
		{
			214, 198, 130, 220, 124, 89, 226, 65, 184, 31,
			150, 231, 138, 25, 128, 2
		};
		if (flag == 1)
		{
			for (int i = 0; i < content.Length; i++)
			{
				content[i] ^= array[i % array.Length];
			}
		}
		else
		{
			for (int i = 0; i < content.Length; i++)
			{
				content[i] ^= array2[i % array2.Length];
			}
		}
		return true;
	}

	public static byte[] GetByteRandom(int num)
	{
		int num2 = 0;
		int num3 = 0;
		byte[] array = new byte[num];
		num2 = (num + 15) / 16;
		for (int i = 0; i < num2; i++)
		{
			num3 = num - i * 16;
			if (num3 >= 16)
			{
				Guid.NewGuid().ToByteArray().CopyTo(array, i * 16);
			}
			else
			{
				Array.Copy(Guid.NewGuid().ToByteArray(), 0, array, i * 16, num3);
			}
		}
		return array;
	}

	public static byte[] KeyNorOr(byte[] content)
	{
		byte[] array = new byte[content.Length];
		byte[] array2 = new byte[32]
		{
			127, 32, 24, 125, 238, 65, 209, 14, 46, 41,
			77, 163, 113, 168, 242, 132, 114, 202, 67, 72,
			118, 11, 99, 15, 29, 73, 168, 105, 191, 5,
			135, 181
		};
		for (int i = 0; i < content.Length; i++)
		{
			array[i] = (byte)(content[i] ^ array2[i % array2.Length]);
		}
		return array;
	}

	public static uint UintNorOr(byte[] content)
	{
		uint num = 0u;
		byte[] array = new byte[32]
		{
			127, 32, 24, 125, 238, 65, 209, 14, 46, 41,
			77, 163, 113, 168, 242, 132, 114, 202, 67, 72,
			118, 11, 99, 15, 29, 73, 168, 105, 191, 5,
			135, 181
		};
		byte[] array2 = null;
		if (content.Length % 4 != 0)
		{
			return 0u;
		}
		array2 = new byte[array.Length + content.Length];
		array.CopyTo(array2, 0);
		content.CopyTo(array2, array.Length);
		for (int i = 0; i < array2.Length / 4; i++)
		{
			num ^= BitConverter.ToUInt32(array2, i * 4);
		}
		return num;
	}

	public static ushort CRC16XMODEM(byte[] content)
	{
		int[] array = new int[256]
		{
			0, 4129, 8258, 12387, 16516, 20645, 24774, 28903, 33032, 37161,
			41290, 45419, 49548, 53677, 57806, 61935, 4657, 528, 12915, 8786,
			21173, 17044, 29431, 25302, 37689, 33560, 45947, 41818, 54205, 50076,
			62463, 58334, 9314, 13379, 1056, 5121, 25830, 29895, 17572, 21637,
			42346, 46411, 34088, 38153, 58862, 62927, 50604, 54669, 13907, 9842,
			5649, 1584, 30423, 26358, 22165, 18100, 46939, 42874, 38681, 34616,
			63455, 59390, 55197, 51132, 18628, 22757, 26758, 30887, 2112, 6241,
			10242, 14371, 51660, 55789, 59790, 63919, 35144, 39273, 43274, 47403,
			23285, 19156, 31415, 27286, 6769, 2640, 14899, 10770, 56317, 52188,
			64447, 60318, 39801, 35672, 47931, 43802, 27814, 31879, 19684, 23749,
			11298, 15363, 3168, 7233, 60846, 64911, 52716, 56781, 44330, 48395,
			36200, 40265, 32407, 28342, 24277, 20212, 15891, 11826, 7761, 3696,
			65439, 61374, 57309, 53244, 48923, 44858, 40793, 36728, 37256, 33193,
			45514, 41451, 53516, 49453, 61774, 57711, 4224, 161, 12482, 8419,
			20484, 16421, 28742, 24679, 33721, 37784, 41979, 46042, 49981, 54044,
			58239, 62302, 689, 4752, 8947, 13010, 16949, 21012, 25207, 29270,
			46570, 42443, 38312, 34185, 62830, 58703, 54572, 50445, 13538, 9411,
			5280, 1153, 29798, 25671, 21540, 17413, 42971, 47098, 34713, 38840,
			59231, 63358, 50973, 55100, 9939, 14066, 1681, 5808, 26199, 30326,
			17941, 22068, 55628, 51565, 63758, 59695, 39368, 35305, 47498, 43435,
			22596, 18533, 30726, 26663, 6336, 2273, 14466, 10403, 52093, 56156,
			60223, 64286, 35833, 39896, 43963, 48026, 19061, 23124, 27191, 31254,
			2801, 6864, 10931, 14994, 64814, 60687, 56684, 52557, 48554, 44427,
			40424, 36297, 31782, 27655, 23652, 19525, 15522, 11395, 7392, 3265,
			61215, 65342, 53085, 57212, 44955, 49082, 36825, 40952, 28183, 32310,
			20053, 24180, 11923, 16050, 3793, 7920
		};
		ushort num = 0;
		for (int i = 0; i < content.Length; i++)
		{
			num = (ushort)((num << 8) ^ array[((num >> 8) ^ content[i]) & 0xFF]);
		}
		return num;
	}

	public static byte[] AESEncrypt(byte[] Data, string Key, string Vector)
	{
		byte[] array = new byte[32];
		Array.Copy(Encoding.UTF8.GetBytes(Key.PadRight(array.Length)), array, array.Length);
		byte[] array2 = new byte[16];
		Array.Copy(Encoding.UTF8.GetBytes(Vector.PadRight(array2.Length)), array2, array2.Length);
		byte[] result = null;
		Rijndael rijndael = Rijndael.Create();
		try
		{
			using MemoryStream memoryStream = new MemoryStream();
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(array, array2), CryptoStreamMode.Write);
			cryptoStream.Write(Data, 0, Data.Length);
			cryptoStream.FlushFinalBlock();
			result = memoryStream.ToArray();
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	public static byte[] AESEncrypt(byte[] Data, byte[] bKey, byte[] bVector)
	{
		byte[] result = null;
		Rijndael rijndael = Rijndael.Create();
		try
		{
			using MemoryStream memoryStream = new MemoryStream();
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(bKey, bVector), CryptoStreamMode.Write);
			cryptoStream.Write(Data, 0, Data.Length);
			cryptoStream.FlushFinalBlock();
			result = memoryStream.ToArray();
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	public static byte[] AESDecrypt(byte[] Data, string Key, string Vector)
	{
		byte[] array = new byte[32];
		Array.Copy(Encoding.UTF8.GetBytes(Key.PadRight(array.Length)), array, array.Length);
		byte[] array2 = new byte[16];
		Array.Copy(Encoding.UTF8.GetBytes(Vector.PadRight(array2.Length)), array2, array2.Length);
		byte[] result = null;
		Rijndael rijndael = Rijndael.Create();
		try
		{
			using MemoryStream stream = new MemoryStream(Data);
			using CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateDecryptor(array, array2), CryptoStreamMode.Read);
			using MemoryStream memoryStream = new MemoryStream();
			byte[] array3 = new byte[1024];
			int num = 0;
			while ((num = cryptoStream.Read(array3, 0, array3.Length)) > 0)
			{
				memoryStream.Write(array3, 0, num);
			}
			result = memoryStream.ToArray();
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	public static byte[] AESEncrypt(byte[] Data, uint[] key, uint[] iv)
	{
		byte[] array = new byte[key.Length * 4];
		for (int i = 0; i < key.Length; i++)
		{
			BitConverter.GetBytes(key[i]).Reverse().ToArray()
				.CopyTo(array, i * 4);
		}
		byte[] array2 = new byte[iv.Length * 4];
		for (int i = 0; i < iv.Length; i++)
		{
			BitConverter.GetBytes(iv[i]).Reverse().ToArray()
				.CopyTo(array2, i * 4);
		}
		byte[] result = null;
		Rijndael rijndael = Rijndael.Create();
		try
		{
			using MemoryStream memoryStream = new MemoryStream();
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(array, array2), CryptoStreamMode.Write);
			cryptoStream.Write(Data, 0, Data.Length);
			cryptoStream.FlushFinalBlock();
			result = memoryStream.ToArray();
		}
		catch (Exception ex)
		{
			result = null;
			MessageBox.Show(ex.ToString());
		}
		return result;
	}

	public static byte[] AESDecrypt(byte[] Data, uint[] key, uint[] iv)
	{
		byte[] array = new byte[key.Length * 4];
		for (int i = 0; i < key.Length; i++)
		{
			BitConverter.GetBytes(key[i]).Reverse().ToArray()
				.CopyTo(array, i * 4);
		}
		byte[] array2 = new byte[iv.Length * 4];
		for (int i = 0; i < iv.Length; i++)
		{
			BitConverter.GetBytes(iv[i]).Reverse().ToArray()
				.CopyTo(array2, i * 4);
		}
		byte[] result = null;
		Rijndael rijndael = Rijndael.Create();
		try
		{
			using MemoryStream stream = new MemoryStream(Data);
			using CryptoStream cryptoStream = new CryptoStream(stream, rijndael.CreateDecryptor(array, array2), CryptoStreamMode.Read);
			using MemoryStream memoryStream = new MemoryStream();
			byte[] array3 = new byte[1024];
			int num = 0;
			while ((num = cryptoStream.Read(array3, 0, array3.Length)) > 0)
			{
				memoryStream.Write(array3, 0, num);
			}
			result = memoryStream.ToArray();
		}
		catch (Exception ex)
		{
			result = null;
			MessageBox.Show(ex.ToString());
		}
		return result;
	}

	public static byte[] DESEncrypt(byte[] plainBytes, byte[] key, byte[] iv)
	{
		using DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
		dESCryptoServiceProvider.Key = key;
		dESCryptoServiceProvider.IV = iv;
		using MemoryStream memoryStream = new MemoryStream();
		using (CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write))
		{
			cryptoStream.Write(plainBytes, 0, plainBytes.Length);
			cryptoStream.FlushFinalBlock();
		}
		return memoryStream.ToArray();
	}

	public static byte[] DESDecrypt(byte[] encryptedBytes, byte[] key, byte[] iv)
	{
		using DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
		dESCryptoServiceProvider.Key = key;
		dESCryptoServiceProvider.IV = iv;
		using MemoryStream memoryStream = new MemoryStream();
		using (CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write))
		{
			cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
			cryptoStream.FlushFinalBlock();
		}
		return memoryStream.ToArray();
	}
}
