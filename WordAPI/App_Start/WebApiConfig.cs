using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WordAPI
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "loginAPI",
				routeTemplate: "api/Word/login/{strUsername}",
				//routeTemplate: "api/Word/login/{strUsername}/{strPassword}"
				defaults: new { strUsername = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
			    name: "DefaultApi",
			    routeTemplate: "api/{controller}/{id}",
			    defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
