using Autofac;

using Core.Autofac;
using Core.WebElements;

using Microsoft.Playwright;

using ObjectModel.Pages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Login
{
	public class LoginPage : BasePage
	{
		LoginPageLocator obj;
		public static IPage Driver => ContainerClass.Container.Resolve<IPage>();

		public LoginPage() 
		{
			obj = new();
		}
		public async Task DashboardAction()
		{
			await GoToPage();
		}
		public async Task LoginAction()
		{
			Thread.Sleep(4000);
			await obj.Email.Fill("V.Subashchandiran@PeppTech.onmicrosoft.com");
			await obj.NextButton.Click();
			await obj.Password.Fill("Farm-Run-Importance-Drink-7");
			await obj.SignIn.Click();
			await obj.NoButton.Click();
		}
		public async Task<bool> DashboardsPage()
		{
			bool status = false;
			int attempt = 0;
			while (!status && attempt < 3)
			{
				Thread.Sleep(6000);
				status = await obj.NavMenu.ElementExists();
				attempt++;
			}
			return status;
		}
		public async Task OpenApp(string AppName)
		{
			
			await SwitchToPowerApp(AppName);
			
		}
		public static async Task SwitchToPowerApp(string AppName)
		{
			try
			{
				var frame = Driver.FrameLocator("xpath=//iframe[@id='AppLandingPage']").Locator($"xpath=//div[@title='{AppName}']");
				await frame.WaitForAsync();
				await frame.ClickAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public async Task Navigate(string TabName)
		{
			await obj.DashboardHeader.WaitForElementToVisible();
			await obj.NavButton(TabName).Click();
			
		}

	}
}
