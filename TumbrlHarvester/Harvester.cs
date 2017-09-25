/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: pawel.pietralik
 * Data: 2017-09-25
 * Godzina: 09:23
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Net;

namespace TumbrlHarvester
{
	/// <summary>
	/// Description of Harvester.
	/// </summary>
	public class Harvester
	{
		public Harvester()
		{
		}
		
		public HttpStatusCode GetHeaders(string url)
	    {
	        HttpStatusCode result = default(HttpStatusCode);
			
	        Program.urls = url;
	        var request = HttpWebRequest.Create(url);
	        request.Method = "HEAD";
	        using (var response = request.GetResponse() as HttpWebResponse)
	        {
	            if (response != null)
	            {
	                result = response.StatusCode;
	                response.Close();
	            }
	        }
	
	        return result;
	    }
	}
}
