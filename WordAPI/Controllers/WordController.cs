using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using GMail.classes;

namespace WordAPI.Controllers
{
	public class WordController : ApiController
	{
		public string Get()
		{
			return "Welcome to Word API Controller";
		}

		[HttpGet]
		//public string login(string strUsername, string strPassword)
		public string login(string strUsername)
		{
			return "In login, strUsername is: " + strUsername;
			/*
			// login and get username/password
			if (DatabaseAccess.VerifyLogin(strUsername, strPassword))
			{
				return true;
			}

			else
			{
				return false;
			}
			/* */
		}
	}
}
