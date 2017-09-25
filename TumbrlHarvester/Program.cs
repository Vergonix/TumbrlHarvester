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
using System.Collections.Generic;

namespace TumbrlHarvester
{
	class Program
	{	
		//public static string urls;
		public static List <string> pages = new List <string>();
		
		
		public static void Main(string[] args)
		{
			// TODO: Implement Functionality Here
			
			HttpStatusCode resp = new HttpStatusCode();
			int counter = 1;

				Harvester har = new Harvester();
				Reaper rep = new Reaper();
				
				rep.prepareUsersPageList();
				File.WriteAllText(@"C:\Users\pawel.pietralik\Desktop\request.txt", string.Empty);
				File.WriteAllText(@"C:\Users\pawel.pietralik\Desktop\glupota.txt", string.Empty);
				
				foreach (string page in pages) {
					try {
						resp = har.GetHeaders(page);
						Console.WriteLine(counter +  " >> " + resp);
						counter++;
						File.AppendAllText(@"C:\Users\pawel.pietralik\Desktop\request.txt", counter + " >> " + page + Environment.NewLine);
					} catch(Exception) {
						Console.WriteLine(counter +  " >> 404 Page not Found");
						counter++;
						File.AppendAllText(@"C:\Users\pawel.pietralik\Desktop\glupota.txt", counter + " >> " + page + Environment.NewLine);
					}
				}
				
				
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}