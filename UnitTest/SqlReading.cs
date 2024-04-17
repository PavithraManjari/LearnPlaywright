using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
	public class SqlReading
	{
		[Test]
		public void ReadData()
		{
			string connectionString = "Data Source=2015-SQL.ptl-test-host.co.uk\\SQLTEST2016; Database=SlowAutoCX_MSCRM;User Id=sa;Password=20PTL10!;";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sqlQuery = "SELECT * FROM dbo.AccountBase";

				using (SqlCommand command = new SqlCommand(sqlQuery, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							// Access data using reader["ColumnName"] or reader[index]
							var name = reader["AccountId"];
							// Add more fields as needed

							
						}
					}
				}
			}
		}
	}
}
