/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: pawel.pietralik
 * Data: 2017-09-25
 * Godzina: 08:13
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.IO;
using System.Net;

namespace TumbrlHarvester
{
	class Program
	{	
		public static string urls;
		
		public static void Main(string[] args)
		{
			// TODO: Implement Functionality Here
			HttpStatusCode resp = new HttpStatusCode();
			string [] domains = {"http://semahead.pl/asd", "http://semahead.pl/", "http://semahead.pl/fgb",  "http://semahead.pl/ers", "http://semahead.pl/produkty", "https://kraus.tumblr.com/"};
			
			
				Harvester har = new Harvester();
				for(int i=0; i<6; i++) {
					try {
						resp = har.GetHeaders(domains[i]);
						File.AppendAllText(@"C:\Users\pawel.pietralik\Desktop\request.txt", urls + Environment.NewLine);
					} catch(Exception) {
						File.AppendAllText(@"C:\Users\pawel.pietralik\Desktop\glupota.txt", urls + Environment.NewLine);
					}
				}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}