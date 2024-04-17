using Core.WebElements;

using ObjectModel.Login;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Pages
{
	public class ConflictPage
	{
		BrowserActions B1 = new();
		LoginPageLocator obj;
		public ConflictPage()
		{
			obj = new LoginPageLocator();
		}
		public async Task CreateConflictSearch()
		{
			await B1.SwitchToWindowLastopen();
			await obj.NewSearchButton.Click();
			await this.obj.SearchName.Fill("viki");
			await this.obj.NewConflictSearchSaveBtn.Click();
		}
		public async Task HomePage()
		{
			await B1.SwitchToParentWindow();
		}
	}
}
