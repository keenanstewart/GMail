using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

using GMail.classes;
using WordAPI.Models;

namespace WordAPI.Controllers
{
	public class WordController : ApiController
	{
		public string Get()
		{
			return "Welcome to Word API Controller";
		}

		[HttpGet]
		public string Randomness(string strValue)
		{
			Random r = new Random();

			return "Randomness number is: " + r.Next(5, 10);
		}

		[HttpGet]
		// To call WordOne: http://localhost/KeenAPI/api/Word/WordOne
		public string WordOne()
		{
			return "Word One";
		}

		[HttpGet]
		// To call NextWord: http://localhost/KeenAPI/api/Word/NextWord?WordCount=12
		// http://localhost:14743/api/Word/NextWord?WordCount=12
		//public WordDefinition NextWord(int? id = 1)
		public WordDefinition NextWord(string WordCount)
		{
			int iWordCount = Convert.ToInt32(WordCount);
			WordDefinition wd = new WordDefinition();

			string strLive = WebConfigurationManager.AppSettings["live"];
			string strSchema = WebConfigurationManager.AppSettings["schema"];

			// Get word from database and fill WordDefinition
			using (SqlConnection conn = new SqlConnection(DatabaseAccess.DBConnection()))
			{
				string strNextWord = "SELECT words.*, themes.WordThemeName FROM [";
				strNextWord += strSchema + "].[TestWordsmithWords] as words ";
				strNextWord += "JOIN [" + strSchema + "].[TestWordsmithThemes] AS themes ";
				strNextWord += "ON words.WordsmithThemeID = themes.ID ";
				strNextWord += " WHERE words.ID = @id";

				using (SqlCommand cmd = new SqlCommand(strSchema, conn))
				{
					try
					{
						conn.Open();
						cmd.CommandText = strNextWord;
						cmd.Parameters.AddWithValue("@id", iWordCount);

						SqlDataReader read = cmd.ExecuteReader();

						while (read.Read())
						{
							wd.Id = Convert.ToInt32(read["id"].ToString());
							wd.WordsmithThemeId = Convert.ToInt32(read["WordsmithThemeId"].ToString());
							wd.DailyWord = read["DailyWord"].ToString();
							wd.WordThemeName = read["WordThemeName"].ToString();
							wd.Pronunciation = read["Pronunciation"].ToString();
							wd.Meaning = read["Meaning"].ToString();
							wd.Etymology = read["Etymology"].ToString();
							wd.Usage = read["Usage"].ToString();
							wd.ThoughtADay = read["ThoughtADay"].ToString();
							wd.Notes = read["Notes"].ToString();
							wd.InputDate = Convert.ToDateTime(read["InputDate"].ToString());
							wd.UpdateDate = Convert.ToDateTime(read["UpdateDate"].ToString());
						}
					}

					catch (Exception ex)
					{
					}
				}
			}

			return wd;
		}

		[HttpGet]
		// To call Login http://localhost/KeenApi/api/Word/Login/keenan/Malcolm
		//public string Login(string strUsername, string strPassword)
		public bool Login(string strUsername, string strPassword)
		{
			//return "In login, strUsername is: " + strUsername + strPassword;
			/* */
			// login and get username/password
			try
			{
				/**/
					if (DatabaseAccess.VerifyLogin(strUsername, strPassword))
					{
						return true;
					}

					else
					{
						return false;
					}
				/* */
				//return DatabaseAccess.VerifyLogin(strUsername, strPassword);
			}

			catch (Exception ex)
			{
				//return "Exception is: " + ex.Message.ToString();
				return false;
			}
			/* */
			//return "return from Login" + strUsername + " " + strPassword;
		}
	}
}
