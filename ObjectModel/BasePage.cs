using Autofac;

using Core.Autofac;
using Core.TestConfig;

using Microsoft.Playwright;

using NUnit.Framework;

using ObjectModel.Autofac;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
	public class BasePage 
	{
		public IPage Driver => DriverClass.Page;
		public async Task GoToPage()
		{
			await Driver.GotoAsync("https://ptl-mattermgmt-test.crm11.dynamics.com");
		}
	}
}
