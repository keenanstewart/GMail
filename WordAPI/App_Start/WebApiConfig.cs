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
				routeTemplate: "api/{controller}/{action}/{strUsername}/{strPassword}",
				//routeTemplate: "api/Word/login/{strUsername}/{strPassword}"
				defaults: new { strUsername = RouteParameter.Optional }
			);

			/*
			config.Routes.MapHttpRoute(
				name: "wordRandomness",
				routeTemplate: "api/{controller}/{action}/",
				//routeTemplate: "api/Word/login/{strUsername}/{strPassword}"
				defaults: new { strUsername = RouteParameter.Optional }
			); /* */

			config.Routes.MapHttpRoute(
				name: "WinningNumbers",
				//routeTemplate: "api/LottoMax/WinningNumbers",
				routeTemplate: "api/LottoMax/WinningNumbers/",
				defaults: new
				{
					controller = "LottoMax",
					action = "WinningNumbers"
				}
			);

			config.Routes.MapHttpRoute(
				name: "LottoMax",
				//routeTemplate: "api/LottoMax/WinningNumbers",
				routeTemplate: "api/{controller}/{action}/",
				defaults: new 
				{
					action = "Get", 
					id = RouteParameter.Optional ,
					controller = "LottoMax"
				}
			);

			config.Routes.MapHttpRoute(
			    name: "DefaultApi",
			    routeTemplate: "api/{controller}/{id}",
			    defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
