using System;
using System.Web;
using Umbraco.Web;

namespace AchmeErrorSite
{
	public class SiteApplication : UmbracoApplication
	{
		protected new void Application_Error(object sender, EventArgs e)
		{
			// This method is triggered twice when an exception occurs.
			// Only do anything if there is actually an error.
			// Otherwise just ignore it.

			Exception lastError = Server.GetLastError();

			if (lastError != null)
			{
				base.Application_Error(sender, e);
			}

			if (Context.IsCustomErrorEnabled)
			{
				if (lastError != null)
				{
					var httpException = lastError as HttpException ?? new HttpException(500, "Internal error");

					var code = httpException.GetHttpCode();
					Response.StatusCode = code;
					Server.ClearError();
					Server.Transfer("/500.html");
				}
			}
		}
	}
}