/// <summary> </summary>
using System;
using System.Security.Cryptography;
namespace Tamir.IPLib.Util
{
	

	/// <author>Tamir Gal</author>
	/// <version>  $Revision$ </version>
	/// <lastModifiedBy>  $Author$ </lastModifiedBy>
	/// <lastModifiedAt>  $Date$ </lastModifiedAt>
	public class Rand
	{
		RNGCryptoServiceProvider generator = new RNGCryptoServiceProvider();

		public static Rand CreateInstance()
		{
			Rand r = new Rand();
			return r;			
		}
		private static Rand singleton = CreateInstance();

		public static Rand Instance
		{
			get
			{
				return singleton;
			}
		}

		/// <summary>
		/// Returns the given number of seed bytes generated for the first running of a new instance 
		/// of the random number generator.
		/// </summary>
		/// <param name="numberOfBytes">Number of seed bytes to generate.</param>
		/// <returns>Seed bytes generated</returns>
		public static byte[] GetSeed(int numberOfBytes)
		{
			RNGCryptoServiceProvider generatedSeed = new RNGCryptoServiceProvider();
			byte[] seeds = new byte[numberOfBytes];
			generatedSeed.GetBytes(seeds);
			return seeds;
		}

		public byte[] GetBytes(byte[] bytes)
		{
			generator.GetBytes(bytes);
			return bytes;
		}

		public byte[] GetBytes(int size)
		{
			byte[] bytes = new byte[size];
			generator.GetBytes(bytes);
			return bytes;
		}

		public double GetDouble()
		{
			byte[] bytes = GetBytes(8);
			double d = System.BitConverter.ToDouble(bytes, 0);
			return d;
		}

		public int GetInt()
		{
			byte[] bytes = GetBytes(4);
			int i = System.BitConverter.ToInt32(bytes, 0);
			return i;
		}
	}
}