using System;
using System.Text;

namespace WordDroid
{
	public static class LoginValidator
	{
		public static string Combine(string raw, string raw2)
		{
			if (string.IsNullOrWhiteSpace(raw))
			{
				return "";
			}

			else
			{
				raw = raw + raw2;
			}



			return raw;

		}
	}
}
