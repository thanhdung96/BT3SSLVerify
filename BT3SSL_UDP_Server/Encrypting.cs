using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BT3SSL_UDP_Server
{
	class Encrypting
	{
		public byte[] IV = { 1, 5, 13, 17, 23, 29, 31, 37, 41 };
		public byte[] byteKey;

		public Encrypting()
		{
			byteKey = new byte[] { };		//stream of byte key, 0 count
		}

		public byte[]  encrypt(string strMessage, string strKey)
		{
			byte[] byteMessage = Encoding.ASCII.GetBytes(strMessage);

			TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
			tripleDES.Key = UTF8Encoding.UTF8.GetBytes(strKey);	
			tripleDES.Mode = CipherMode.ECB;
			tripleDES.Padding = PaddingMode.PKCS7;
			ICryptoTransform cTransform = tripleDES.CreateEncryptor();
			byte[] byteEncrypted = cTransform.TransformFinalBlock(byteMessage, 0, byteMessage.Length);
			tripleDES.Clear();
			return byteEncrypted;
		}

		public byte[] decrypt(byte[] byteMessage, byte[] byteKey)
		{
			TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
			tripleDES.Key = byteKey;
			tripleDES.Mode = CipherMode.ECB;
			tripleDES.Padding = PaddingMode.PKCS7;
			ICryptoTransform ic = tripleDES.CreateDecryptor();
			byte[] dec = ic.TransformFinalBlock(byteMessage, 0, 8);
			return dec;
		}
	}
}
