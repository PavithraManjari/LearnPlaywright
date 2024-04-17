using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TestConfig
{
	public class TestConfiguration : ITestConfiguration
	{
		public string Url { get; set; }
		public string Browser { get; set; }
	}
}
