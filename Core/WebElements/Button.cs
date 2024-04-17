using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.WebElements
{
	public class Button : PmElementBase
	{
		public Button(string Selector = null, string SelectorValue = null) : base(Selector: Selector, SelectorValue: SelectorValue)
		{
		}
		public new async Task Click()
		{
			try
			{
				//await pmBrowserService.WaitForPageLoad();
				await GetWebElement().ClickAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}
		public async Task Fill(string value)
		{
			var element = GetWebElement();
			await element.FillAsync(value);
		}
	}
}
