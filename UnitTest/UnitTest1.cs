using ObjectModel.Login;

namespace UnitTest
{
	public class Tests : TestBase
	{
		
		[Test]
		public async Task Test1() 
		{
			var LoginPage = PageObjectReg.LoginPage;
			var ConflictPage = PageObjectReg.ConflictPage;
			/*await LoginPage.DashboardAction();
			await LoginPage.LoginAction();*/
			await LoginPage.OpenApp("Peppermint CX365");
			//await LoginPage.Navigate("Conflict Search");
			/*await ConflictPage.CreateConflictSearch();
			await ConflictPage.HomePage();*/
		}
	}
}