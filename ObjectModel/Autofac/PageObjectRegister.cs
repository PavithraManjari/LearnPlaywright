using Autofac;

using ObjectModel.Login;
using ObjectModel.Pages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Autofac
{
    public class PageObjectRegister
    {
		private readonly IComponentContext _context;

		public PageObjectRegister(IComponentContext context) 
		{
			_context = context;
		}
		public LoginPage LoginPage => _context.Resolve<LoginPage>();
		public ConflictPage ConflictPage => _context.Resolve<ConflictPage>();
	}
}
