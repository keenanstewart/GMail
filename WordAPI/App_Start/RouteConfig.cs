using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WordAPI
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "NextWord",
				url: "Word/NextWord/{WordCount}",
				defaults: new { controller = "Word", action = "NextWord", WordCount = UrlParameter.Optional}
			);

			routes.MapRoute(
			    name: "Default",
			    url: "{controller}/{action}/{id}",
			    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
