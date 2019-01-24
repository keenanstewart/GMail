using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;

using System.Data;
using System.Data.SqlClient;

using System.Configuration;
using System.Web.Configuration;

using System.Text;
using System.IO;
using System.Security.Cryptography;

using GMail.classes;

namespace GMail.Admin
{
    public partial class ViewWords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["loggedin"] == null) || (Session["loggedin"].ToString() == "false"))
            {
                Response.Redirect("../Default.aspx");
            }

            if (!IsPostBack)
            {
				DataTable wordTable = new DataTable("WordTable");

				// Create the columns
				wordTable.Columns.Add("Id", typeof(int));
				wordTable.Columns.Add("WordsmithThemeId", typeof(int));
				wordTable.Columns.Add("WordsmithThemeName", typeof(string));
				wordTable.Columns.Add("DailyWord", typeof(string));
				wordTable.Columns.Add("Pronounciation", typeof(string));
				wordTable.Columns.Add("Meaning", typeof(string));
				wordTable.Columns.Add("Etymology", typeof(string));
				wordTable.Columns.Add("Usage", typeof(string));
				wordTable.Columns.Add("ThoughtADay", typeof(string));
				wordTable.Columns.Add("Notes", typeof(string));

				Session["WordsTable"] = wordTable;
				grdBind();

                // Check if query string exists
                if (Request.QueryString["Data"] != null)
                {
                    lblMessage.Text += "Word " +
                        DatabaseAccess.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Data"])) +
                        " successfully inserted!";
                }
            }
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session["loggedin"] = false;
            Session.Clear();
            lblMessage.Text = "User logged out.";
            Response.Redirect("../Default.aspx");
        }


        protected void grdBind()
        {
            // now use this file to write to my table, only unique links
            string strSchema = WebConfigurationManager.AppSettings["schema"];
            string strTest = WebConfigurationManager.AppSettings["connect"];
            string strtblWords = DatabaseAccess.DBTable();

            // Load the panResults with what is in the database
            using (SqlConnection con3 = new SqlConnection(DatabaseAccess.DBConnection()))
            {
				string strQuery = "SELECT TWS.ID AS ID, TWST.ID AS WordsmithThemeID";
				strQuery += ", TWST.WordThemeName AS WordsmithThemeName";
				strQuery += ", TWS.DailyWord AS DailyWord, TWS.Pronunciation AS Pronunciation";
				strQuery += ", TWS.Meaning AS Meaning, TWS.Etymology AS ETymology";
				strQuery += ", TWS.Usage AS Usage, TWS.ThoughtADay AS ThoughtADay";
				strQuery += ", TWS.Notes AS Notes ";
				strQuery += " FROM [" + strSchema + "].[" + strtblWords.Split(';')[0] + "] ";
				strQuery += " AS TWS JOIN Word.TestWordsmithThemes AS TWST ";
				strQuery += " ON TWS.WordsmithThemeID = TWST.ID ";

				int iSubName = Convert.ToInt32(WebConfigurationManager.AppSettings["intURLLength"]);

                using (SqlCommand cmd3 = new SqlCommand(strQuery, con3))
                {
                    using (SqlDataAdapter adpt3 = new SqlDataAdapter())
                    {
                        cmd3.Connection = con3;
                        adpt3.SelectCommand = cmd3;

                        using (DataSet ds3 = new DataSet())
                        {
                            adpt3.Fill(ds3);
                            grdWords.DataSource = ds3.Tables[0];
                            grdWords.DataBind();

                            Session["WordsTable"] = ds3.Tables[0];
                        }
                    }
                }

                con3.Open();
                /*
                string str = "SELECT COUNT(*) FROM [" + strSchema + "].[" + strtblWords + "] ";
                str += "WHERE Reviewed = 0;";
                string str2 = "SELECT COUNT(*) FROM [" + strSchema + "].[" + strtblWords + "];";
                string strCountA = "";
                string strCountB = "";

                using (SqlCommand cmd4 = new SqlCommand(str, con3))
                {
                    SqlDataReader read4 = cmd4.ExecuteReader();

                    if (read4.Read())
                    {
                        strCountA = read4[0].ToString();
                    }
                }

                //con3.Open();
                using (SqlCommand cmd5 = new SqlCommand(str2, con3))
                {
                    SqlDataReader read5 = cmd5.ExecuteReader();

                    if (read5.Read())
                    {
                        strCountB = read5[0].ToString();
                    }
                }


                lblRecords.Text = "Unreviewed " + strCountA + " of ";
                lblRecords.Text += strCountB + " total records.";
                */
                con3.Close();
            }
        }

        protected void txtSearchLinks_TextChanged(object sender, EventArgs e)
        {
            //lblMessage.Text = "now to call LinkEdit.aspx with id once we figure out how.";

            string strSchema = WebConfigurationManager.AppSettings["schema"];
            string strtblLinks = DatabaseAccess.DBTable();
            string strSearch = txtSearchWords.Text;
            string strConn = DatabaseAccess.DBConnection();

            string query = "SELECT * FROM [" + strSchema + "].[" + strtblLinks + "] ";
            query += "WHERE LinkURL LIKE @p and Reviewed = 0;";

            using (SqlConnection con4 = new SqlConnection(strConn))
            {
                using (SqlCommand cmd4 = new SqlCommand(query, con4))
                {
                    try
                    {
                        con4.Open();

                        cmd4.Parameters.AddWithValue("@p", strSearch);

                        SqlDataReader read3 = cmd4.ExecuteReader();

                        if (read3.Read())
                        {
                            //Response.Redirect(read3["LinkURL"].ToString());
                            Response.Write("<script>");
                            Response.Write("window.open('" + read3["LinkURL"].ToString() + "', '_blank')");
                            Response.Write("</script>");
                        }

                        read3.Close();

                        using (SqlDataAdapter adapt4 = new SqlDataAdapter())
                        {
                            cmd4.Connection = con4;
                            adapt4.SelectCommand = cmd4;

                            using (DataSet ds4 = new DataSet())
                            {
                                adapt4.Fill(ds4);
                                grdWords.DataSource = ds4.Tables[0];
                                grdWords.DataBind();
                            }
                        }

                        con4.Close();
                    }

                    catch (Exception ex4)
                    {
                        lblMessage.Text += "Exception in getting record: " + ex4.Message.ToString();
                    }
                }
            }
        }

        [WebMethod]
        public static List<string> GetWords(string strStart)
        {
            List<string> LinkSites = new List<string>();

            string strSchema = WebConfigurationManager.AppSettings["schema"];
            string strtblWords = DatabaseAccess.DBTable().Split(';')[0];
            string strConn = DatabaseAccess.DBConnection();

            string query = "SELECT DailyWord FROM [" + strSchema + "].[" + strtblWords + "] ";
            query += " WHERE DailyWord LIKE @dw;";

            using (SqlConnection con2 = new SqlConnection(strConn))
            {
                using (SqlCommand cmd2 = new SqlCommand(query, con2))
                {
                    try
                    {
                        con2.Open();

                        cmd2.Parameters.AddWithValue("@dw", "%" + strStart + "%");

                        SqlDataReader read2 = cmd2.ExecuteReader();

                        while (read2.Read())
                        {
                            LinkSites.Add(read2["DailyWord"].ToString());
                        }

                        con2.Close();
                    }

                    catch (Exception)
                    {
                        
                    }
                }
            }

            return LinkSites;
        }

        protected void grdWords_Sorting(object sender, GridViewSortEventArgs e)
        {
            //lblMessage.Text = "In grdWords_Sorting";
            //grdWords.DataSource = GetData
        }

        protected void txtSearchWords_TextChanged(object sender, EventArgs e)
        {
            string strSchema = WebConfigurationManager.AppSettings["schema"];
            string strLive = WebConfigurationManager.AppSettings["live"];
            string strtblWords = "";

            if (strLive == "test")
            {
                strtblWords = WebConfigurationManager.AppSettings["TestWordsmithWords"].ToString();
            }

            else
            {
                strtblWords = WebConfigurationManager.AppSettings["WordsmithWords"].ToString();
            }
            
            string strSearch = txtSearchWords.Text;
            string strConn = DatabaseAccess.DBConnection();

            string query = "SELECT * FROM [" + strSchema + "].[" + strtblWords + "] ";
            query += "WHERE DailyWord LIKE @p;";

            using (SqlConnection con3 = new SqlConnection(strConn))
            {
                using (SqlCommand cmd3 = new SqlCommand(query, con3))
                {
                    try
                    {
                        con3.Open();

                        cmd3.Parameters.AddWithValue("@p", strSearch);

                        SqlDataReader read3 = cmd3.ExecuteReader();

                        if (read3.Read())
                        {
                            Response.Redirect("EditWords.aspx?ID=" + read3["ID"].ToString(), false);
                        }

                        con3.Close();
                    }

                    catch (Exception)
                    {

                    }
                }
            }
        }

		protected void grdWords_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			//lblMessage.Text = "InGrdWordPageIndexChanging";
			grdWords.PageIndex = e.NewPageIndex;
			grdBind();
		}

		protected void grdWords_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			//lblMessage.Text = "InGrdWordCanceling";
			grdWords.EditIndex = -1;
			// Bind data to the GridView Control
			grdBind();
		}

		protected void grdWords_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				if (this.grdWords.EditIndex != -1)
				{
					if (e.Row.RowIndex == this.grdWords.EditIndex)
					{
						string value = e.Row.Cells[1].Text;
						string valu2 = e.Row.Cells[0].Text;
						string valu3 = e.Row.Cells[2].Text;
						string valu4 = e.Row.Cells[3].Text;
						string valu5 = e.Row.Cells[4].Text;
						string valu6 = e.Row.ToString();
						Label lblDailyWord = (Label) e.Row.Cells[3].FindControl("lblDailyWord");
						Label lblWordId = (Label)e.Row.Cells[1].FindControl("lblID");

						// Now to call EditWord.aspx with the WordId and WordName
						Response.Redirect("EditWords.aspx?ID=" + lblWordId.Text +
									"&DailyWord=" + lblDailyWord.Text, false);
					}
				}
			}
		}

		protected void grdWords_RowEditing(object sender, GridViewEditEventArgs e)
		{
			//lblMessage.Text = "InGrdWordEditing";
			grdWords.EditIndex = e.NewEditIndex;
			// Bind data to the GridView control
			grdBind();
			//string strSelectedID;
			//string strSelectedWord;
			//strSelectedID = grdWords.Rows[e.NewEditIndex].Cells[0].Text;
			//strSelectedWord = grdWords.Rows[e.NewEditIndex].Cells[2].Text;
		}

		protected void grdWords_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			//lblMessage.Text = "InGrdWordUpdating";
			DataTable dt = (DataTable)Session["WordsTable"];
			grdWords.EditIndex = -1;
			// Bind data to the GridView Control
			grdBind();
		}
	}
}
