using Autofac;

using Core.TestConfig;
using Core.WebElements;

using Microsoft.Playwright;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Module = Autofac.Module;

namespace Core.Autofac
{
	public class CoreWebTestModule : Module
	{
		private readonly ITestConfiguration _configuration;
		public static IPlaywright playwright { get; set; }
		public static IPage Page { get; set; }
		public static IBrowserContext browserContext { get; set; }
		public static IBrowser browser { get; set; }
		protected override void Load(ContainerBuilder builder)
		{
			Task.Run(async () => await RegisterBrowser(builder)).Wait();
			var testSiteAssembly = Assembly.GetAssembly(typeof(PmElementBase));
			builder.RegisterAssemblyTypes(testSiteAssembly).Where(t => typeof(PmElementBase).IsAssignableFrom(t))
				.InstancePerDependency().AsSelf();
		}
		public CoreWebTestModule(ITestConfiguration configuration)
		{
			_configuration = configuration;
		}
		private async Task RegisterBrowser(ContainerBuilder builder)
		{
			playwright = await Playwright.CreateAsync();
			bool _headless = false;
			if (!string.IsNullOrEmpty(_configuration.Browser)
				   && _configuration.Browser.Equals("chrome"))
			{
				browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Channel = _configuration.Browser, Headless = _headless, Args = new[] { "--start-maximized" }, SlowMo = 1000 }).ConfigureAwait(false);
			}
			var contextOptions = new BrowserNewContextOptions()
			{

				ViewportSize = ViewportSize.NoViewport

			};
			browserContext = await browser.NewContextAsync(contextOptions);
			Page = await browserContext.NewPageAsync();
			builder.RegisterInstance<IPage>(Page).AsImplementedInterfaces();
			builder.RegisterInstance<IBrowserContext>(browserContext).AsImplementedInterfaces();
			builder.RegisterInstance(playwright).AsImplementedInterfaces();
		}
	}
}
