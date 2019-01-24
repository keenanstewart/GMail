using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

using GMail.classes;

namespace GMail.Admin
{
	public partial class InputWordsTheme : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if ((Session["loggedin"] == null) || (Session["loggedin"].ToString() == "false"))
			{
				Response.Redirect("../Default.aspx");
			}

			if (!IsPostBack)
			{
				try
				{
					string strSchema = WebConfigurationManager.AppSettings["schema"];
					string strLive = WebConfigurationManager.AppSettings["live"];
					string strtblWords = "";
					string strtblWordsTheme = "";

					if (strLive == "test")
					{
						strtblWords = WebConfigurationManager.AppSettings["TestWordsmithWords"].ToString();
						strtblWordsTheme = WebConfigurationManager.AppSettings["TestWordsmithThemes"].ToString();
					}

					else
					{
						strtblWords = WebConfigurationManager.AppSettings["WordsmithWords"].ToString();
						strtblWordsTheme = WebConfigurationManager.AppSettings["WordsmithThemes"].ToString();
					}

					string strConn = DatabaseAccess.DBConnection();
					SqlDataReader read1;

					using (SqlConnection con1 = new SqlConnection(strConn))
					{
						string strQuery = "SELECT TWT.ID, TWT.WordThemeName ";
						strQuery += "FROM [" + strSchema + "].[";
						strQuery += strtblWordsTheme + "] as TWT ";
						strQuery += "ORDER BY TWT.WordThemeName;";

						// Excute command and fill drop down list
						using (SqlCommand cmd1 = new SqlCommand(strQuery, con1))
						{
							con1.Open();

							read1 = cmd1.ExecuteReader();

							while (read1.Read())
							{
								ddlWordThemeName.Items.Add(new ListItem(read1[1].ToString(),
																read1[0].ToString()));
							}

							//ddlWordThemeName.Items.Insert(0, new ListItem(String.Empty,
							//									String.Empty));
							ddlWordThemeName.SelectedIndex = -1;
						}
					}
				}

				catch (Exception ex)
				{
					lblMessage.Text = "Exception occurred: " + ex.Message.ToString();
				}
			}
		}

		protected void cmdWordCreate_Click(object sender, EventArgs e)
		{
			// Check if all fields are not empty
			if (CheckValidFields())
			{
				
			}

			else
			{
				lblMessage.Text = "Please fill in all required fields.";
			}
		}

		protected bool CheckValidFields()
		{
			if ((ddlWordThemeName.SelectedIndex != -1) &&
				(txtWordInputEtymology.Text != "") &&
				(txtWordInputMeaning.Text != "") &&
				(txtWordInputNotes.Text != "") &&
				(txtWordInputPronounciation.Text != "") &&
				(txtWordInputThoughtADay.Text != "") &&
				(txtWordInputUsage.Text != "") &&
				(txtWordInputWord.Text != ""))
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		protected void lbLogout_Click(object sender, EventArgs e)
		{
			Session["loggedin"] = false;
			Session.Clear();
			lblMessage.Text = "User logged out.";
			Response.Redirect("../Default.aspx");
		}
	}
}
