using Autofac;
using Core.Autofac;
using Microsoft.Playwright;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.WebElements
{
	public class BrowserActions
	{
		public static IBrowserContext BrowserContext = ContainerClass.Container.Resolve<IBrowserContext>();

		public async Task SwitchToWindowLastopen()
		{
			ContainerBuilder builder = new ContainerBuilder();

			var windows = BrowserContext.Pages;

			int attempt = 0;
			int windowsCount = windows.Count;
			while (windowsCount <= 1 && attempt < 3)
			{
				Thread.Sleep(TimeSpan.FromSeconds(2));
				windowsCount = windows.Count;
				attempt++;
			}
			var switchPage = windows[windowsCount - 1];
			await switchPage.WaitForLoadStateAsync();
			DriverClass.Page = switchPage;
			// Build and return a new container from the new scope
			
		}
		public async Task SwitchToParentWindow()
		{
			IPage Driver = ContainerClass.Container.Resolve<IPage>();
			ContainerBuilder builder = new ContainerBuilder();

			var windows = BrowserContext.Pages;
			var Parentwindow = windows[0];
			bool state = false;
			for (int childWindow = windows.Count - 1; childWindow > 0; childWindow--)
			{
				await windows[childWindow].CloseAsync();
				state = true;
			}
			if (state)
			{
				await Parentwindow.WaitForLoadStateAsync();
				builder.RegisterInstance<IPage>(Parentwindow).ExternallyOwned();
				ContainerClass.Container = builder.Build();
			}
		}
	}
}
