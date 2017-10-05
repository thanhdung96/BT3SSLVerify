using System;
using System.Text;

namespace BT3SSL_UDP_Server
{
	class Program
	{
		static void Main(string[] args)
		{
			Encrypting en = new Encrypting();

			Console.WriteLine(Encoding.ASCII.GetString(en.decrypt(en.encrypt("vpdoan", "duongthanhdung96"), Encoding.ASCII.GetBytes("duongthanhdung96"))));
		}
	}
}
