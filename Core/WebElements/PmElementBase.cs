using Autofac;

using Core.Autofac;

using Microsoft.Playwright;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.WebElements
{
	public class PmElementBase 
	{
		public IPage Driver => ContainerClass.Container.Resolve<IPage>();
		public static IBrowserContext BrowserContext = ContainerClass.Container.Resolve<IBrowserContext>();
		public ILocator WebElement { get; set; }
		public string _cssSelector;
		public string _xpathSelector;
		public string Selector { get; set; }
		public PmElementBase(string? Selector = null, string? SelectorValue = null)
		{
			if (Selector != null && SelectorValue != null)
			{
				if (Selector == "Xpath")
				{
					this.Selector = SelectorValue;
				}
				else if (Selector == "CSS")
				{
					this.Selector = SelectorValue;
				}
				else if (Selector == "Id")
				{
					this.Selector = SelectorValue;
				}

				else
				{
					throw new NotImplementedException($"Selector: {Selector} not handled in Implementation");
				}
			}
			else
			{
				throw new ArgumentNullException($"Selector: {Selector} and SelectorValue: {SelectorValue} shouldn't null");

			}

		}
		public ILocator GetWebElement()
		{
			return GetWebElement(this.Selector);
		}
		protected ILocator GetWebElement(string Selector)
		{
			Driver.WaitForSelectorAsync(Selector);
			WebElement = Driver.Locator(Selector);
			return WebElement;
		}
		public async Task<bool> ElementExists()
		{
			return await Driver.Locator(Selector).CountAsync() > 0;
		}
		public async Task WaitForElementToVisible()
		{
			await Driver.WaitForTimeoutAsync(8000);
			await Driver.WaitForSelectorAsync(Selector);
			try
			{
				var element = GetWebElement(Selector);
				await element.WaitForAsync();
				await element.IsVisibleAsync();
			}
			catch (Exception)
			{
				Assert.Fail($"Expected element {Selector?.ToString()} failed to be visible after waiting 60 seconds on {this.Driver.Url}");
			}
		}
		
	}
}
