using Autofac;
using Core.Autofac;
using Core.TestConfig;

using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;

using NUnit.Framework.Interfaces;

using ObjectModel.Autofac;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
	public class TestBase : ContainerClass
	{
		protected PageObjectRegister PageObjectReg { get; private set; }
		private static readonly string RootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
		private static readonly string ConfigFilePath = Path.Combine(@RootDirectory, "Config.json");
		private static TestConfiguration _testConfig;
		public IPage Driver => ContainerClass.Container.Resolve<IPage>();
		[OneTimeSetUp]
		public async Task BeforeAssembly()
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.AddJsonFile(@ConfigFilePath)
				.Build();

			_testConfig = configuration.GetSection("site").Get<TestConfiguration>()!;
			await SetupAutofac(_testConfig);
		}
		private static async Task SetupAutofac(TestConfiguration testConfig)
		{
			// TODO register / open driver last after setup
			var builder = new ContainerBuilder();
			builder.RegisterInstance(testConfig).As<ITestConfiguration>();
			builder.RegisterModule(new CoreWebTestModule((testConfig)));
			builder.RegisterModule(new PageObjectWebTestModule(testConfig));
			Container = builder.Build();
		}
		[SetUp]
		public async Task BeforeTest()
		{
			PageObjectReg = Container.Resolve<PageObjectRegister>();
			//await OneTimeLogin();
		}

		[TearDown]
		public void AfterTest()
		{
			var browser = Container.Resolve<IBrowserContext>();
			browser.CloseAsync();
		}
		public async Task OneTimeLogin()
		{
			await Driver.GotoAsync("https://ptl-mattermgmt-test.crm11.dynamics.com");
			await Driver.Locator("xpath=//input[@type='email']").FillAsync("V.Subashchandiran@PeppTech.onmicrosoft.com");
			await Driver.Locator("xpath=//input[@value='Next']").ClickAsync();
			await Driver.Locator("xpath=//input[@name='passwd']").FillAsync("Farm-Run-Importance-Drink-7");
			await Driver.Locator("xpath=//input[@value='Sign in']").ClickAsync();
			await Driver.Locator("xpath=//input[@value='No']").ClickAsync();
			BrowserContextStorageStateOptions browserContextStorageStateOptions = new BrowserContextStorageStateOptions()
			{
				Path = "session.json"
			};
			await Driver.Context.StorageStateAsync(browserContextStorageStateOptions);
		}
	}
}
