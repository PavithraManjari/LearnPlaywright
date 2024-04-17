using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TestConfig
{
	public interface ITestConfiguration
	{
		string Url { get; set; }

		string Browser { get; set; }
	}
}
