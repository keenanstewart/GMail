using GMail.classes;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Xml;

namespace GMail
{
	public partial class GetArchive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetPageString();
                //string cSite = WebConfigurationManager.AppSettings["Site1"];

                //GottenWord(cSite);
            }

            else
            {
                if (Session["lblMessage"] != null)
                {
                    lblMessage.Text = Session["lblMessage"].ToString();
                }
            }
            
        }

        protected void cmdGetArchive_Click(object sender, EventArgs e)
        {
            string strArchive = WebConfigurationManager.AppSettings["WordSmithArchive"];

            //lblMessage.Text = GetPageContent(strArchive);
            //GetPageString();
        }

        // Eliminate ascii code quotes
        // Items to remove
        /*
         * &#8220; &#8221; &#8216; &
         */
        private string RemoveQuotes(string strUsage)
        {
            strUsage = Regex.Replace(strUsage, "&#8220;", "\"");
            strUsage = Regex.Replace(strUsage, "&#8221;", "\"");
            strUsage = Regex.Replace(strUsage, "&#8216;", "'");
            strUsage = Regex.Replace(strUsage, "&nbsp", " ");

            return strUsage.Trim() + ' ';
        }

        private void GetPageString()
        {
            string strArchive = WebConfigurationManager.AppSettings["WordSmithArchive"];
            string strSite = WebConfigurationManager.AppSettings["WordSmithWordsSite"];

            try
            {
                using (WebClient client = new WebClient())
                {
                    //WebClient client = new WebClient();
                    Stream s = client.OpenRead(strArchive);

                    using (StreamReader sr = new StreamReader(s))
                    {
                        string line;
                        string strPage = "";
                        string strContains = "<li><a href=\"/words/";
                        string strStart = ".html\">";
                        string strEnd = "</a>";

                        while ((line = sr.ReadLine()) != null)
                        {
                            /*
                            if (line.Contains("Mrs."))
                            {
                                lblError.Text = "Contains";
                            }
                            */
                            // Try to find only lines with words
                            // <li><a href="/words/
                            if (line.Contains(strContains))
                            {
                                int START = line.IndexOf(strStart) + 7;
                                int END = line.IndexOf(strEnd);
                                lbWords.Items.Add(line.Substring(START, END - START));

                                int count = lbWords.Items.Count - 1;
                                lbWords.SelectedIndex = count;

                                // Build on our existing database; 
                                // simply check if word exists already
                                // CheckDoesNotExistInTable returns true if 
                                // the record does not already exist in the table
                                if (CheckDoesNotExistInTable(lbWords.Text))
                                {
                                    lblMessage.Text = GottenWord(strSite + lbWords.Text + ".html");
                                }
                            }

                            strPage += line;
                        }

                        //txtContent.Text = strPage;

                        lbWords.SelectedIndex = 1;

                        lblMessage.Text = "Count for listbox is: " + lbWords.Items.Count;
                        lblMessage.Text += "<br>" + GottenWord(strSite + lbWords.Text + ".html");
                        Session["lblMessage"] = lblMessage.Text;
                    }
                }
            }

            catch (Exception ex1)
            {
                lblMessage.Text = "Error occurred in reading site: " + ex1.Message.ToString();
            }
        }

        private string ReplaceSpace(string strWord)
        {
            string[] a = strWord.Split('/');

            /* 
            if (a.Length < 4)
            {
                strWord = 
            }
            */

            string[] b = a[4].Split(new string[] { ".html" }, StringSplitOptions.None);

            // [4]: "Mrs. Grundy.html"
            strWord = b[0].Replace(".", String.Empty);
            strWord = strWord.Replace(' ', '_');
            strWord = strWord.Replace("'", String.Empty);
            strWord += ".html";
            string start = WebConfigurationManager.AppSettings["WordSmithWordsSite"];
            return start + strWord.ToLower();
        }

        private string GottenWord(string strWord)
        {
            strWord = strWord.ToLower();

            // Replace spaces with underscore
            if (strWord.Contains(' '))
            {
                strWord = ReplaceSpace(strWord);
            }

            try
            {
                //WebClient client = new WebClient();

                using (WebClient client = new WebClient())
                {
                    Stream s = client.OpenRead(strWord);

                    if (strWord.Contains("epigamic"))
                    {
                        lblError.Text = "In epigamic";
                    }

                    using (StreamReader sr = new StreamReader(s))
                    {
                        string line;

                        string divStart = "<div style";
                        string divEnd = "</div>";

                        bool fWord = false;

                        string strWordADay = WebConfigurationManager.AppSettings["WORDADAY"];
                        string strWordADay2 = WebConfigurationManager.AppSettings["AWORDADAY"];

                        string strWordADayTheme = WebConfigurationManager.AppSettings["WORDADAYTHEME"];

                        string strPronouc = WebConfigurationManager.AppSettings["PRONOUNCIATION"];
                        bool fPronouc = false;
                        bool f2Pronouc = false;

                        string strMeaning = WebConfigurationManager.AppSettings["MEANING"];
                        bool fMeaning = false;
                        bool f2Meaning = false;
                        bool fP = false;

                        string strEtymology = WebConfigurationManager.AppSettings["ETYMOLOGY"];
                        bool fEtymology = false;
                        bool f2Etymology = false;
                        bool fMainBody = false;
                        //bool fSquare = false;

                        string strUsage = WebConfigurationManager.AppSettings["USAGE"];
                        bool fUsage = false;

                        string strThoughtDay = WebConfigurationManager.AppSettings["THOUGHTDAY"];
                        bool fThoughtDay = false;

                        string strXBonus = WebConfigurationManager.AppSettings["XBONUS"];
                        bool fXBonus = false;

                        string strWeek = WebConfigurationManager.AppSettings["WEEK"];

                        string strTheme = WebConfigurationManager.AppSettings["THEME"];
                        bool fWeekTheme = false;
                        string strTheme2 = WebConfigurationManager.AppSettings["THEME2"];

                        lblMessage2.Text = "";

                        // Variables used to insert into database
                        string strWordValue = "";
                        string strThemeValue = "";
                        string strPronouncValue = "";
                        string strMeaningValue = "";
                        string strEtymologyValue = "";
                        string strUsageValue = "";
                        string strThoughtDayValue = "";
                        //string strWeekValue = "";

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains("meticulous"))
                            {
                                lblError.Text = "To check";
                            }

                            if (line.Contains("An instrument for holding"))
                            {
                                lblError.Text = "To check";
                            }

                            if ((line.Contains("epigamic")) && (line.Contains("TITLE")))
                            {
                                lblError.Text = "Break;";
                            }

                            // Etymology
                            if ((f2Etymology) && (line.Contains("[")))
                            {
                                f2Meaning = false;
                                strEtymologyValue += RemoveQuotes(RemoveHTMLTags(line));

                                if (line.Contains("]"))
                                {
                                    f2Etymology = false;
                                }
                            }

                            else if ((f2Etymology) && (line.Contains("]")))
                            {
                                strEtymologyValue += RemoveQuotes(RemoveHTMLTags(line));
                                f2Etymology = false;
                            }

                            // Meaning
                            if ((f2Meaning) && (line != "") && (!line.ToLower().Contains("<p>")) &&
                                (!line.Contains("[")) && (!line.Contains("]")))
                            {
                                strMeaningValue += RemoveQuotes(RemoveHTMLTags(line));
                            }

                            else if ((f2Meaning) && (line.ToLower().Contains("<p>")))
                            {
                                if (fP)
                                {
                                    f2Meaning = false;
                                    f2Etymology = true;
                                }

                                else
                                {
                                    fP = true;
                                }
                            }

                            // Pronunciation
                            if ((f2Pronouc) && ((line.Contains(strWordValue))) &&
                                (line.Contains('(') && (line.Contains(')'))))
                            {
                                int a = line.IndexOf('(');
                                int b = line.IndexOf(')');
                                strPronouncValue = line.Substring(a, b + 1 - a);
                                f2Pronouc = false;
                                f2Meaning = true;
                            }

                            // Word
                            if ((line.Contains("<h3>")) && (line.Contains("</h3")) && (!line.Contains("X-Bonus")))
                            {
                                strWordValue = RemoveHTMLTags(line);
                            }

                            else if ((line.Contains(strWordADay2)) && (!line.Contains("Today")))
                            {
                                int a, b;
                                a = line.IndexOf(strWordADay2) + 14;
                                //b = line.Length - a - 5;
                                b = line.Length - a - 8;
                                strWordValue = line.Substring(a, b).Trim();
                                f2Pronouc = true;
                                fMainBody = true;
                                f2Pronouc = true;
                            }

                            // Theme
                            if ((line.Contains(strWeek)) && (line.Contains(strTheme2)))
                            {
                                /*
                                if (line.Contains("A bright patch"))
                                {
                                    lblError.Text = "break;";
                                }
                                */
                                int a, b;
                                a = line.IndexOf(strTheme2) + 7;
                                b = line.Length - a;
                                strThemeValue = RemoveHTMLTags(line.Substring(a, b));
                                fWeekTheme = false;
                            }

                            // X-Bonus
                            if (fXBonus)
                            {
                                strThoughtDayValue += RemoveHTMLTags(line);

                                if (line.Contains("</quote>"))
                                {
                                    fXBonus = false;
                                }
                            }

                            if (line.Contains(strXBonus))
                            {
                                fXBonus = true;
                            }

                            // WORD
                            //if ((line.Contains("<h3>")) && (line.Contains("</h3>")))
                            /*
                            if ((line.Contains("<h3>")) &&
                                (line.Contains("</h3>")) &&
                                (!line.Contains("X-Bonus")))
                            {
                                fWord = true;
                            }

                            if (fWord)
                            {
                                strWordValue += RemoveHTMLTags(line);
                                lblMessage2.Text = strWordValue;
                                fWord = false; 
                            }
                            /*
                            if ((line.Contains("</h3>")) && (!line.Contains("X-Bonus")))
                            {
                                fWord = false;
                            }
                            */

                            // PRONOUNCIATION
                            if (line.Contains(strPronouc))
                            {
                                strPronouncValue += RemoveHTMLTags(line);
                                fPronouc = true;
                            }

                            if ((fPronouc) && (line.Contains('(') && (line.Contains(')'))))
                            {
                                strPronouncValue = RemoveHTMLTags(line);
                                fPronouc = false;
                            }

                            // MEANING
                            if ((fMeaning) && !(line.Contains(divStart)))
                            {
                                strMeaningValue += RemoveHTMLTags(line);
                            }

                            if ((fMeaning) && (line.Contains(divEnd)))
                            {
                                // Line is: "</div><br>"
                                fMeaning = false;
                            }

                            if (line.Contains(strMeaning))
                            {
                                //strMeaningValue += RemoveHTMLTags(line);
                                fMeaning = true;
                            }

                            // ETYMOLOGY
                            //if ((fEtymology) && !(line.Contains(divStart)))
                            if (fEtymology)
                            {
                                strEtymologyValue += RemoveQuotes(RemoveHTMLTags(line));
                            }

                            else if ((fEtymology) && (!line.Contains(divEnd)))
                            {
                                strEtymologyValue += RemoveQuotes(RemoveHTMLTags(line));
                            }

                            if ((fEtymology) && (line.Contains(divEnd)))
                            {
                                fEtymology = false;
                            }

                            if (line.Contains(strEtymology))
                            {
                                //strEtymologyValue += RemoveHTMLTags(line);
                                fEtymology = true;
                            }

                            // USAGE
                            if ((fUsage) && ((line.Contains("</div>")) || (line.Contains("See more usage examples of"))))
                            {
                                fUsage = false;
                            }

                            if ((fUsage) && !(line.Contains(divStart)))
                            {
                                strUsageValue += RemoveQuotes(RemoveHTMLTags(line));
                                //fUsage = false;
                            }

                            if (line.Contains(strUsage))
                            {
                                //strUsageValue = RemoveHTMLTags(line);
                                fUsage = true;
                            }

                            // A THOUGHT FOR TODAY
                            if (fThoughtDay)
                            {
                                if (!line.Contains("<br>"))
                                {
                                    strThoughtDayValue += RemoveHTMLTags(line);
                                }

                                else
                                {
                                    fThoughtDay = false;
                                }
                            }

                            if (line.Contains(strThoughtDay))
                            {
                                //strThoughtDayValue = RemoveHTMLTags(line);
                                fThoughtDay = true;
                            }

                            // WEEKSTHEME
                            if (fWeekTheme)
                            {
                                if ((!line.Contains("<br>") && line != ""))
                                {
                                    strThemeValue += RemoveHTMLTags(line);
                                    fWeekTheme = false;
                                }
                            }
                            /*
                            if ((line.Contains(strWeek)) && (line.Contains(strTheme)))
                            {
                                //strThemeValue += RemoveHTMLTags(line);
                                fWeekTheme = true;
                            }
                            */
                        }

                        if (strPronouncValue == "")
                        {
                            lblError.Text = "Missing pronounciation: " + lbWords.Text;
                            lblError.Text += "Page is: " + strWord;
                        }


                        lblMessage2.Text = "<BR>" + strWordADayTheme;
                        lblMessage2.Text += "<BR>" + strThemeValue;
                        lblMessage2.Text += "<BR><BR>" + strWordADay;
                        lblMessage2.Text += "<BR>" + strWordValue;
                        lblMessage2.Text += "<BR><BR>" + strPronouc;
                        lblMessage2.Text += "<BR>" + strPronouncValue;
                        lblMessage2.Text += "<BR><BR>" + strMeaning;
                        lblMessage2.Text += "<BR>" + strMeaningValue;
                        lblMessage2.Text += "<BR><BR>" + strEtymology;
                        lblMessage2.Text += "<BR>" + strEtymologyValue;
                        lblMessage2.Text += "<BR><BR>" + strUsage;
                        lblMessage2.Text += "<BR>" + strUsageValue;
                        lblMessage2.Text += "<BR><BR>" + strThoughtDay;
                        lblMessage2.Text += "<BR>" + strThoughtDayValue;

                        if (CheckDoesNotExistInTable(strWordValue))
                        {
                            string strSchema = WebConfigurationManager.AppSettings["schema"];
                            string[] tables = DatabaseAccess.DBTable().Split(';');

                            if (strWordValue == "speculum")
                            {
                                lblMessage.Text = "In speculum";
                            }

                            if (strWordValue.Contains("epigamic"))
                            {
                                lblError.Text = "Break;";
                            }

                            int iTheme = GetThemeID(strThemeValue);

                            // If iTheme is 0 (!found), then a function to create a new theme record
                            if (iTheme == 0)
                            {
                                iTheme = InsertTheme(strThemeValue);
                            }

                            using (SqlConnection con2 = new SqlConnection(DatabaseAccess.DBConnection()))
                            {
                                string strInsert = "INSERT INTO [" + strSchema + "].[" + tables[0] + "] ";
                                strInsert += "(WordsmithThemeID, DailyWord, Pronunciation, Meaning, Etymology, ";
                                strInsert += "Usage, ThoughtADay, Notes, InputDate) VALUES ";
                                strInsert += "(@ws, @dw, @p, @m, @e, @u, @t, @n, @i);";

                                using (SqlCommand cmd2 = new SqlCommand(strInsert, con2))
                                {
                                    try
                                    {
                                        con2.Open();

                                        cmd2.Parameters.AddWithValue("@ws", iTheme);
                                        cmd2.Parameters.AddWithValue("@dw", strWordValue);
                                        cmd2.Parameters.AddWithValue("@p", strPronouncValue);
                                        cmd2.Parameters.AddWithValue("@m", strMeaningValue);
                                        cmd2.Parameters.AddWithValue("@e", strEtymologyValue);
                                        cmd2.Parameters.AddWithValue("@u", strUsageValue);
                                        cmd2.Parameters.AddWithValue("@t", strThoughtDayValue);
                                        cmd2.Parameters.AddWithValue("@n", strWord);
                                        cmd2.Parameters.AddWithValue("@i", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                        cmd2.ExecuteNonQuery();

                                        con2.Close();
                                    }

                                    catch (Exception ex2)
                                    {
                                        lblError.Text = "Error inserting word: " + strWordValue + " " +
                                            ex2.Message.ToString();
                                    }
                                }
                            }
                        }

                        else
                        {
                            lblError.Text = "Word already exists: " + strWordValue;
                        }
                    }
                }
            }

            catch (Exception ex1)
            {
                lblMessage.Text = "Error in resolving page: " + ex1.Message.ToString();
            }
            
            return strWord;
        }

        // Insert new theme if existing theme not found
        private int InsertTheme(string strTheme)
        {
            int iValue = 0;
            string strConn = DatabaseAccess.DBConnection();
            string strSchema = WebConfigurationManager.AppSettings["schema"];
            string table = DatabaseAccess.DBTable().Split(';')[1];

            // Already know this is a new theme, so just take it and insert it.
            // Will only have name of theme and Insert date in some cases
            using (SqlConnection con1 = new SqlConnection(strConn))
            {
                string strInsert = "INSERT INTO [" + strSchema + "].[" + table + "] ";
                strInsert += "(WordThemeName, InputDate) OUTPUT Inserted.ID ";
                strInsert += "VALUES (@twn, @id);";

                using (SqlCommand cmd1 = new SqlCommand(strInsert, con1))
                {
                    try
                    {
                        con1.Open();

                        cmd1.Parameters.AddWithValue("@twn", strTheme);
                        cmd1.Parameters.AddWithValue("@id", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        iValue = cmd1.ExecuteNonQuery();

                        con1.Close();
                    }

                    catch (Exception ex1)
                    {
                        lblError.Text = "Error inputting new theme: " + ex1.Message.ToString();
                    }
                }
            }

            return iValue;
        }

        // Return Theme ID
        private int GetThemeID(string strTheme)
        {
            string strConn = DatabaseAccess.DBConnection();
            string strSchema = WebConfigurationManager.AppSettings["schema"];
            string[] tables = DatabaseAccess.DBTable().Split(';');
            int iValue = 0;

            using (SqlConnection con1 = new SqlConnection(strConn))
            {
                //string strinsert = "INSERT INTO [" + strSchema + "].[" + tables[1] + "] ";
                //strinsert += "()"
                string strSelect = "SELECT ID FROM [" + strSchema + "].[" + tables[1] + "] ";
                strSelect += "WHERE WordThemeName LIKE @wtn;";

                using (SqlCommand cmd1 = new SqlCommand(strSelect, con1))
                {
                    try
                    {
                        con1.Open();

                        cmd1.Parameters.AddWithValue("@wtn", strTheme);
                        iValue = Convert.ToInt16(cmd1.ExecuteScalar());

                        /* 
                        if (iValue == 0)
                        {
                            // insert statement for new WordSmithWordThemeName
                            string strInsert = "INSERT INTO [" + strSchema + "].[" + tables[1] + "] ";
                            strInsert += "()";
                            strInsert += "OUTPUT Inserted.ID VALUES ();";
                        }
                        */
                        con1.Close();
                    }

                    catch (Exception ex1)
                    {
                        lblError.Text = "Error in getting count: " + ex1.Message.ToString();
                    }
                }
            }

            return iValue;
        }

        // Make sure the word does not already exist
        private bool CheckDoesNotExistInTable(string tocheck)
        {
            string strConn = DatabaseAccess.DBConnection();
            string strSchema = WebConfigurationManager.AppSettings["schema"];
            string[] tables = DatabaseAccess.DBTable().Split(';');
            int iValue = 0;

            using (SqlConnection con1 = new SqlConnection(strConn))
            {
                //string strinsert = "INSERT INTO [" + strSchema + "].[" + tables[1] + "] ";
                //strinsert += "()"
                string strSelect = "SELECT COUNT(ID) FROM [" + strSchema + "].[" + tables[0] + "] ";
                strSelect += "WHERE DailyWord LIKE @dw;";

                using (SqlCommand cmd1 = new SqlCommand(strSelect, con1))
                {
                    try
                    {
                        con1.Open();

                        cmd1.Parameters.AddWithValue("@dw", tocheck);
                        iValue = Convert.ToInt16(cmd1.ExecuteScalar());

                        con1.Close();
                    }

                    catch (Exception ex1)
                    {
                        lblError.Text = "Error in getting count: " + ex1.Message.ToString();
                    }
                }
            }

            if (iValue > 0)
                return false;
            else
                return true;
        }

        private string RemoveHTMLTags(string str)
        {
            // Sample line: 
            // "<b>This week&#8217;s theme</b><br>"
            // Clean up HTML characters
            // &#8217; @nbsp
            str = str.Replace("&#8217;", "'");
            str = str.Replace("/", String.Empty);

            str = Regex.Replace(str, "<.*?>", String.Empty);

            return str;
        }

        private string GetPageContentXML(string strPage)
        {
            string strContent = String.Empty;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(strPage);
                strContent = doc.InnerText;
            }

            catch (XmlException xml1)
            {
                lblMessage2.Text = "Error in reading XML Document: " + xml1.Message.ToString();
            }

            catch (Exception ex1)
            {
                lblMessage2.Text = "Exception occurred: " + ex1.Message.ToString();
            }

            return strContent;
        }

        private string GetPageContentWC(string strPage)
        {
            string strContent = String.Empty;
            
            WebRequest wr = WebRequest.Create(strPage);
            WebResponse wp = wr.GetResponse();
            Stream data = wp.GetResponseStream();

            using (StreamReader sr = new StreamReader(data))
            {
                strContent = sr.ReadToEnd();
            }

            return strContent;
        }

        private string GetPageContent(string strPage)
        {
            string strContent = String.Empty;

            try
            {
                WebClient wc = new WebClient();
                strContent = wc.DownloadString(strPage);
            }

            catch (Exception ex1)
            {
                lblMessage2.Text = "Error in GetPageContent: " + ex1.Message.ToString();
            }

            return strContent;
        }

        protected void lbWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSite = WebConfigurationManager.AppSettings["WordSmithWordsSite"];

            lblMessage.Text = "Count for listbox is: " + lbWords.Items.Count;
            string strLink = GottenWord(strSite + lbWords.Text + ".html");
            string strCLink = "<a href = '" + strLink + "' target='_blank'>";
            strCLink += strLink + "</a>";
            lblMessage.Text += "<br>" + strCLink;
            Session["lblMessage"] = lblMessage.Text;
        }
    }
}