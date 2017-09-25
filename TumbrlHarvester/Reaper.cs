/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: pawel.pietralik
 * Data: 2017-09-25
 * Godzina: 10:06
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.Generic;


namespace TumbrlHarvester
{
	/// <summary>
	/// Description of Reaper.
	/// </summary>
	public class Reaper
	{
		IWebDriver driver = new ChromeDriver();
		IWebElement elem;
		string js;
		Boolean doExist = true;
		
		
		public void prepareUsersPageList() {
			driver.Navigate().GoToUrl("http://relatablepoetryandquotes.tumblr.com/post/165666772422/via-extramadness");
			Thread.Sleep(3000);
			
			while(doExist) {
				if (IsElementPresent(By.ClassName("more_notes_link")))
	            {
		            elem = driver.FindElement(By.ClassName("more_notes_link"));
					js = "arguments[0].click();";
									
					((IJavaScriptExecutor) driver).ExecuteScript(js, elem);
					Thread.Sleep(3000);
				} else {
					break;
				}
			}
			
	
			for(int i=0; i<driver.FindElements(By.ClassName("action")).Count; i++) {
				elem = driver.FindElements(By.ClassName("action"))[i];
				Program.pages.Add(elem.FindElements(By.TagName("a"))[0].GetAttribute("href"));
			}
		}
		
		bool IsElementPresent(By by)
	    {
	        try
	        {
	            driver.FindElement(by);
	            return true;
	        }
	        catch (NoSuchElementException)
	        {
	            return false;
	        }
	    }
	}
}