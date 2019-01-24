using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Globalization;
using System.Resources;

using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

using System.Configuration;
using System.Web.Configuration;

using GMail.classes;

namespace GMail.Admin
{
	public partial class EditWords : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["loggedin"] != null)
			{
				// Get query string id and prepare record for update
				if (!IsPostBack)
				{
					// Will update this to encoded query strings
					if (Request.QueryString["ID"] != null)
					{
						try
						{
							FillFields();
							
						}

						catch (Exception ex1)
						{
							lblMessage.Text = "Exception occurred: " + ex1.Message.ToString();
						}
					}
				}
			}
		}

		protected void cmdWordUpdate_Click(object sender, EventArgs e)
		{
			if (CheckValidFields())
			{
				// first check to see if any fields changed?
				bool bWordsmithDailyWord = false;
				bool bWordsmithPronounciation = false;
				bool bWordsmithMeaning = false;
				bool bWordsmithEtymology = false;
				bool bWordsmithUsage = false;
				bool bWordsmithThoughtADay = false;
				bool bWordsmithNotes = false;

				string strID = Request.QueryString["ID"];
				string strSchema = WebConfigurationManager.AppSettings["schema"];
				string strLive = WebConfigurationManager.AppSettings["live"];
				string strtblWords = "";
				string strtblWordsThemes = "";

				if (strLive == "test")
				{
					strtblWords = WebConfigurationManager.AppSettings["TestWordsmithWords"].ToString();
					strtblWordsThemes = WebConfigurationManager.AppSettings["TestWordsmithThemes"].ToString();
				}

				else
				{
					strtblWords = WebConfigurationManager.AppSettings["WordsmithWords"].ToString();
					strtblWordsThemes = WebConfigurationManager.AppSettings["WordsmithThemes"].ToString();
				}

				string strConn = DatabaseAccess.DBConnection();
				SqlDataReader read1;

				using (SqlConnection con1 = new SqlConnection(strConn))
				{
					string strQuery = "SELECT TWS.ID AS TWSID, TWS.WordsmithThemeID AS TWSWORDSMITHTHEMEID, ";
					strQuery += " TWST.ID AS TWSTID, TWST.WordThemeName AS TWSTWORDTHEMENAME";
					strQuery += ", TWS.DailyWord AS TWSDAILYWORD, TWS.Pronunciation AS TWSPRONOUNCIATION";
					strQuery += ", TWS.Meaning AS TWSMEANING, TWS.Etymology AS TWSETYMOLOGY";
					strQuery += ", TWS.Usage AS TWSUSAGE, TWS.ThoughtADay AS TWSTHOUGHTADAY";
					strQuery += ", TWS.Notes AS TWSNOTES FROM [" + strSchema + "].[";
					strQuery += strtblWords + "] AS TWS JOIN [" + strSchema + "].[";
					strQuery += strtblWordsThemes + "] AS TWST ";
					strQuery += " ON TWS.WordsmithThemeID = TWST.ID ";
					strQuery += " WHERE TWS.ID = @id;";

					using (SqlCommand cmd1 = new SqlCommand(strQuery, con1))
					{
						con1.Open();

						cmd1.Parameters.AddWithValue("@id", strID);

						read1 = cmd1.ExecuteReader();

						if (read1.Read())
						{

							lblMessage.Text = read1["TWSDAILYWORD"].ToString();
							lblMessage.Text += ": " + read1["TWSMEANING"].ToString();
							ddlWordsmithTheme.SelectedIndex =
									Convert.ToInt16(read1["TWSWORDSMITHTHEMEID"].ToString());

							// compare fields to fill bools
							if (txtWordEditWord.Text != read1["TWSDAILYWORD"].ToString())
							{
								bWordsmithDailyWord = true;
							}

							if (txtWordEditPronounciation.Text != read1["TWSPRONOUNCIATION"].ToString())
							{
								bWordsmithPronounciation = true;
							}

							if (txtWordEditMeaning.Text !=
								StripNewLinesCarriageReturns(read1["TWSMEANING"].ToString()))
							{
								bWordsmithMeaning = true;
							}

							if (txtWordEditEtymology.Text != read1["TWSETYMOLOGY"].ToString())
							{
								bWordsmithEtymology = true;
							}

							if (txtWordEditUsage.Text != read1["TWSUSAGE"].ToString())
							{
								bWordsmithUsage = true;
							}

							if (txtWordEditThoughtADay.Text != read1["TWSTHOUGHTADAY"].ToString())
							{
								bWordsmithThoughtADay = true;
							}

							if (txtWordEditNotes.Text != read1["TWSNOTES"].ToString())
							{
								bWordsmithNotes = true;
							}

						}

						else
						{
							lblMessage.Text = "Record not found.";
						}

						con1.Close();
					}
				}

				// continue only if any bools are true
				if ((bWordsmithDailyWord) || (bWordsmithEtymology) || (bWordsmithMeaning) ||
					(bWordsmithNotes) || (bWordsmithPronounciation) ||
					(bWordsmithThoughtADay) || (bWordsmithUsage) || (chkReviewed.Checked))
				{
					try
					{

						if (strLive == "test")
						{
							strtblWords = WebConfigurationManager.AppSettings["TestWordsmithWords"].ToString();
							strtblWordsThemes = WebConfigurationManager.AppSettings["TestWordsmithThemes"].ToString();
						}

						else
						{
							strtblWords = WebConfigurationManager.AppSettings["WordsmithWords"].ToString();
							strtblWordsThemes = WebConfigurationManager.AppSettings["WordsmithThemes"].ToString();
						}

						string strUpdateConn = DatabaseAccess.DBConnection();

						using (SqlConnection con2 = new SqlConnection(strUpdateConn))
						{
							// update statement
							string strUpdate = "UPDATE [" + strSchema + "].[";
							strUpdate += strtblWords + "] SET ";

							// at least one bool changed, so update changes only
							// as well as update date
							if (bWordsmithDailyWord)
							{
								strUpdate += "[DailyWord]=@dw ";
							}

							if (bWordsmithPronounciation)
							{
								if (bWordsmithDailyWord)
								{
									strUpdate += ", [Pronunciation]=@p ";
								}

								else
								{
									strUpdate += " [Pronunciation]=@p ";
								}
							}

							if (bWordsmithMeaning)
							{
								if ((bWordsmithDailyWord) || (bWordsmithPronounciation))
								{
									strUpdate += ", [Meaning]=@m ";
								}

								else
								{
									strUpdate += " [Meaning]=@m ";
								}
							}

							if (bWordsmithEtymology)
							{
								if ((bWordsmithDailyWord) || (bWordsmithPronounciation)
									|| (bWordsmithMeaning))
								{
									strUpdate += ", [Etymology]=@e ";
								}

								else
								{
									strUpdate += " [Etymology]=@e ";
								}
							}

							if (bWordsmithUsage)
							{
								if ((bWordsmithDailyWord) || (bWordsmithPronounciation)
									|| (bWordsmithMeaning) || (bWordsmithEtymology))
								{
									strUpdate += ", [Usage]=@u ";
								}

								else
								{
									strUpdate += " [Usage]=@u ";
								}
							}

							if (bWordsmithThoughtADay)
							{
								if ((bWordsmithDailyWord) || (bWordsmithPronounciation)
									|| (bWordsmithMeaning) || (bWordsmithEtymology)
									|| (bWordsmithUsage))
								{
									strUpdate += ", [ThoughtADay]=@t ";
								}

								else
								{
									strUpdate += " [ThoughtADay]=@t ";
								}
							}

							if (bWordsmithNotes)
							{
								if ((bWordsmithDailyWord) || (bWordsmithPronounciation)
									|| (bWordsmithMeaning) || (bWordsmithEtymology)
									|| (bWordsmithUsage) || (bWordsmithThoughtADay))
								{
									strUpdate += ", [Notes]=@n ";
								}

								else
								{
									strUpdate += " [Notes]=@n ";
								}
							}

							if (chkReviewed.Checked)
							{
								if ((bWordsmithDailyWord) || (bWordsmithPronounciation)
									|| (bWordsmithMeaning) || (bWordsmithEtymology)
									|| (bWordsmithUsage) || (bWordsmithThoughtADay)
									|| (bWordsmithNotes))
								{
									strUpdate += ", [Reviewed]=@r ";
								}

								else
								{
									strUpdate += " [Reviewed]=@r ";
								}
							}

							strUpdate += ", [UpdateDate]=@ud ";
							strUpdate += " WHERE [ID] = @id ";

							// strUpdate created, ready to execute;
							using (SqlCommand cmd2 = new SqlCommand(strUpdate, con2))
							{
								// add parameters
								if (bWordsmithDailyWord)
								{
									cmd2.Parameters.AddWithValue("@dw", txtWordEditWord.Text);
								}

								if (bWordsmithPronounciation)
								{
									cmd2.Parameters.AddWithValue("@p", txtWordEditPronounciation.Text);
								}

								if (bWordsmithMeaning)
								{
									cmd2.Parameters.AddWithValue("@m", txtWordEditMeaning.Text);
								}

								if (bWordsmithEtymology)
								{
									cmd2.Parameters.AddWithValue("@e", txtWordEditEtymology.Text);
								}

								if (bWordsmithUsage)
								{
									cmd2.Parameters.AddWithValue("@u", txtWordEditUsage.Text);
								}

								if (bWordsmithThoughtADay)
								{
									cmd2.Parameters.AddWithValue("@t", txtWordEditThoughtADay.Text);
								}

								if (bWordsmithNotes)
								{
									cmd2.Parameters.AddWithValue("@n", txtWordEditNotes.Text);
								}

								if (chkReviewed.Checked)
								{
									// If reveiwed is checked
									cmd2.Parameters.AddWithValue("@r", 1);
								}

								else
								{
									cmd2.Parameters.AddWithValue("@r", 0);
								}

								cmd2.Parameters.AddWithValue("@ud", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.mmm"));
								cmd2.Parameters.AddWithValue("@id", Convert.ToInt32(strID));

								// open connection 
								con2.Open();
								// execute update
								cmd2.ExecuteNonQuery();

								// close connection
								con2.Close();
								// redirect back to view page
								Response.Redirect("~/Default.aspx");
							}
						}
					}
					catch (Exception ex1)
					{
						lblMessage.Text = "Exception occurred: " + ex1.Message.ToString();
					}
				}

				else
				{
					lblMessage.Text = "Nothing to update.";
				}
			}

			else
			{
				lblMessage.Text = "Please fill in all required fields.";
			}
		}

		protected bool CheckValidFields()
		{
			if ((ddlWordsmithTheme.SelectedIndex != -1) &&
				(txtWordEditEtymology.Text != "") &&
				(txtWordEditMeaning.Text != "") &&
				(txtWordEditNotes.Text != "") &&
				(txtWordEditPronounciation.Text != "") &&
				(txtWordEditThoughtADay.Text != "") &&
				(txtWordEditUsage.Text != "") &&
				(txtWordEditWord.Text != ""))
			{
				return true;
			}

			else
			{
				return true;
			}
		}

		protected void lbLogout_Click(object sender, EventArgs e)
		{
			Session["loggedin"] = false;
			Session.Clear();
			lblMessage.Text = "User logged out.";
			Response.Redirect("../Default.aspx");
		}

		private void FillFields()
		{
			string strID = Request.QueryString["ID"];
			string strSchema = WebConfigurationManager.AppSettings["schema"];
			string strLive = WebConfigurationManager.AppSettings["live"];
			string strtblWords = "";
			string strtblWordsThemes = "";

			if (strLive == "test")
			{
				strtblWords = WebConfigurationManager.AppSettings["TestWordsmithWords"].ToString();
				strtblWordsThemes = WebConfigurationManager.AppSettings["TestWordsmithThemes"].ToString();
			}

			else
			{
				strtblWords = WebConfigurationManager.AppSettings["WordsmithWords"].ToString();
				strtblWordsThemes = WebConfigurationManager.AppSettings["WordsmithThemes"].ToString();
			}

			string strConn = DatabaseAccess.DBConnection();
			SqlDataReader read1;

			using (SqlConnection con1 = new SqlConnection(strConn))
			{
				string strQuery = "SELECT TWS.ID AS TWSID, TWS.WordsmithThemeID AS TWSWORDSMITHTHEMEID, ";
				strQuery += " TWST.ID AS TWSTID, TWST.WordThemeName AS TWSTWORDTHEMENAME";
				strQuery += ", TWS.DailyWord AS TWSDAILYWORD, TWS.Pronunciation AS TWSPRONOUNCIATION";
				strQuery += ", TWS.Meaning AS TWSMEANING, TWS.Etymology AS TWSETYMOLOGY";
				strQuery += ", TWS.Usage AS TWSUSAGE, TWS.ThoughtADay AS TWSTHOUGHTADAY";
				strQuery += ", TWS.Notes AS TWSNOTES ";
				strQuery += ", TWS.InputDate AS TWSINPUTDATE ";
				strQuery += ", TWS.UpdateDate AS TWSUPDATEDATE, TWS.Reviewed AS TWSREVIEWED ";
				strQuery += "FROM [" + strSchema + "].[";
				strQuery += strtblWords + "] AS TWS JOIN [" + strSchema + "].[";
				strQuery += strtblWordsThemes + "] AS TWST ";
				strQuery += " ON TWS.WordsmithThemeID = TWST.ID ";
				strQuery += " WHERE TWS.ID = @id;";

				using (SqlCommand cmd1 = new SqlCommand(strQuery, con1))
				{
					con1.Open();

					cmd1.Parameters.AddWithValue("@id", strID);

					read1 = cmd1.ExecuteReader();

					if (read1.Read())
					{
						string strConn2 = DatabaseAccess.DBConnection();
						SqlDataReader read2;

						using (SqlConnection con2 = new SqlConnection(strConn))
						{
							string strQuery2 = "SELECT TWST.ID AS TWSTID, TWST.WordThemeName AS ";
							strQuery2 += "TWSTWORDTHEMENAME FROM [" + strSchema + "].[";
							strQuery2 += strtblWordsThemes + "] AS TWST ";
							strQuery2 += "ORDER BY TWST.WordThemeName;";

							// Excute command and fill drop down list
							using (SqlCommand cmd2 = new SqlCommand(strQuery2, con2))
							{
								con2.Open();

								read2 = cmd2.ExecuteReader();

								while (read2.Read())
								{
									ddlWordsmithTheme.Items.Add(new ListItem(read2["TWSTWORDTHEMENAME"].ToString(),
																	read2["TWSTID"].ToString()));
								}

								//ddlWordThemeName.Items.Insert(0, new ListItem(String.Empty,
								//									String.Empty));
								ddlWordsmithTheme.SelectedIndex = -1;
							}
						}
						lblMessage.Text = read1["TWSDAILYWORD"].ToString();
						lblMessage.Text += ": " + read1["TWSMEANING"].ToString();
						ddlWordsmithTheme.SelectedIndex =
								Convert.ToInt16(read1["TWSWORDSMITHTHEMEID"].ToString());

						// Fill remaining fields
						txtWordEditWord.Text = read1["TWSDAILYWORD"].ToString();
						txtWordEditPronounciation.Text = read1["TWSPRONOUNCIATION"].ToString();
						txtWordEditMeaning.Text = read1["TWSMEANING"].ToString();
						txtWordEditEtymology.Text = read1["TWSETYMOLOGY"].ToString();
						txtWordEditUsage.Text = read1["TWSUSAGE"].ToString();
						txtWordEditThoughtADay.Text = read1["TWSTHOUGHTADAY"].ToString();

						lblWordEditNotes.Text = "<a href='" + read1["TWSNOTES"].ToString() +
											"' target=\"_blank\">Notes</a>" ;
						txtWordEditNotes.Text = read1["TWSNOTES"].ToString();
						txtWordEditInputDate.Text = read1["TWSINPUTDATE"].ToString();
						txtWordEditUpdateDate.Text = read1["TWSUPDATEDATE"].ToString();

						if (read1["TWSREVIEWED"].ToString() == "True")
						{
							chkReviewed.Checked = true;
						}
					}

					else
					{
						lblMessage.Text = "Record not found.";
					}

					con1.Close();
				}
			}
		}

		private string StripNewLinesCarriageReturns(string strNewLine)
		{
			try
			{
				return Regex.Replace(strNewLine, @"\r\n", "");
			}

			catch (Exception ex1)
			{
				return String.Empty;
			}
		}
	}
}