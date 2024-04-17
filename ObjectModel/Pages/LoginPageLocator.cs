using Core.WebElements;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Login
{
	public struct LoginPageLocator
	{
		public Button Siginlink => new Button("Xpath", "//li[@class='authorization-link']//a");
		public Button UserName => new Button("Id", "email");
		public Button Password => new Button("Xpath", "//input[@name='passwd']");
		public Button SiginButton => new Button("Id", "send2");
		public Button MessageText => new Button("Xpath", "//span[contains(text(),'Welcome')]");
		public Button Email => new Button("Xpath", "//input[@type='email']");
		public Button NextButton => new Button("Xpath", "xpath=//input[@value='Next']");
		public Button SignIn => new Button("Xpath", "//input[@value='Sign in']");
		public Button NoButton => new Button("Xpath", "//input[@value='No']");
		public Button NavMenu => new Button("Xpath", "//*[@role='navigation']");
		public Button NavButton(string TabName) => new Button("Xpath", $"//li[@aria-label='{TabName}']");
		public PmElementBase DashboardHeader => new PmElementBase("Xpath", "//div[@data-id='DashboardStandardHeader']");
		public Button NewSearchButton => new Button(
			"Xpath", "//span[contains(@class, 'CommandButton') and text()='New Search']/parent::button");
		public Button SearchName => new Button("Xpath", "//input[@id='searchName']");
		public Button NewConflictSearchSaveBtn => new Button("Xpath", "//div[text()='New Conflict Search']/following-sibling::div//span[text()='Save']");
	}
}
