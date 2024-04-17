using Autofac;

using Core.TestConfig;

using Microsoft.Playwright;

using NUnit.Framework;
using NUnit.Framework.Internal;

using ObjectModel.Login;
using ObjectModel.Pages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Module = Autofac.Module;

namespace ObjectModel.Autofac
{
	public class PageObjectWebTestModule : Module
	{
		private readonly ITestConfiguration _configuration;
		public PageObjectWebTestModule(ITestConfiguration configuration)
		{
			_configuration = configuration;
		}
		protected override void Load(ContainerBuilder builder)
		{
			var testAssembly = Assembly.GetAssembly(typeof(PageObjectRegister));
			builder.RegisterAssemblyTypes(testAssembly!).AsSelf();
		}
	}
}
