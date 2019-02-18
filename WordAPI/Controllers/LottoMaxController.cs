using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WordAPI.Controllers
{
	public class LottoMaxController : ApiController
	{
		public string Get()
		{
			return "Welcome to LottoMax API controller";
		}

		[HttpGet]
		//[Route("api/LottoMax/WinningNumbers")]
		public string WinningNumbers()
		{
			Random r = new Random();

			// TODO: Put numbers in list to sort
			// TODO: Make eigth random number for bonus number
			return "LottoMax number is: " + r.Next(1, 49) + 
						":" + r.Next(1, 49) +
						":" + r.Next(1, 49) +
						":" + r.Next(1, 49) +
						":" + r.Next(1, 49) +
						":" + r.Next(1, 49) +
						":" + r.Next(1, 49) +
						":" + r.Next(1, 49);
		}

		[HttpGet]
		public List<int> WinningNumbersList()
		{
			Random r = new Random();
			List<int> lst = new List<int>();

			lst.Add(r.Next(1, 49));
			lst.Add(r.Next(1, 49));
			lst.Add(r.Next(1, 49));
			lst.Add(r.Next(1, 49));
			lst.Add(r.Next(1, 49));
			lst.Add(r.Next(1, 49));
			lst.Add(r.Next(1, 49));

			lst.Sort();

			lst.Add(r.Next(1, 49));

			return lst;
		}
	}
}
