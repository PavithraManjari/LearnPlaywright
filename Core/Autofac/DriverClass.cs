using Autofac;
using Microsoft.Playwright;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Autofac
{
	public class DriverClass
	{
		
		public static IPage? Page { get; set; }

		public async Task<IPage> DriverAssign()
		{
			Page = ContainerClass.Container.Resolve<IPage>();
			return Page;
		}

	}
}
