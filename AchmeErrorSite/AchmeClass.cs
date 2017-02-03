using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AchmeErrorSite
{
	public class AchmeClass
	{
		public static void ThrowUp()
		{
			string foo = null;
			foo.Split(',');
		}
	}
}