using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Configuration;

using OpenPop.Pop3;
using OpenPop.Mime;
using System.Data;

namespace GMail
{
    public partial class GMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string uname = WebConfigurationManager.AppSettings["email"];
                string ppass = WebConfigurationManager.AppSettings["pass"];

                string server = WebConfigurationManager.AppSettings["server"];
                string pServer = WebConfigurationManager.AppSettings["pserver"];
                string iServer = WebConfigurationManager.AppSettings["iserver"];

                if ((uname != "") && (ppass != ""))
                {
                    txtEmail.Text = uname;
                    txtPassword.Text = ppass;

                    if (server == "p")
                    {
                        txtMailServer.Text = pServer;
                    }

                    else if (server == "i")
                    {
                        txtMailServer.Text = iServer;
                    }

                    else
                    {
                        txtMailServer.Text = "pop.google.com";
                    }
                    //Read_Emails(sender, e);
                }
            }
        }

        protected void Read_Emails(object sender, EventArgs e)
        {
            Pop3Client pop3Client;

            if (Session["Pop3Client"] == null)
            {
                pop3Client = new Pop3Client();
                pop3Client.Connect(txtMailServer.Text, int.Parse(txtPort.Text), chkSSL.Checked);
                pop3Client.Authenticate(txtEmail.Text, txtPassword.Text);
                Session["Pop3Client"] = pop3Client;
            }

            else
            {
                pop3Client = (Pop3Client)Session["Pop3Client"];
            }

            int count = pop3Client.GetMessageCount();
            //count = 1000;
            lblMessage.Text = "Count is: " + count;

            //int mail = pop3Client.

            List<string> uids = pop3Client.GetMessageUids();

            lblMessage.Text += "<BR>UIDs are: " + uids.Count;

            DataTable dtMessages = new DataTable();
            dtMessages.Columns.Add("MessageNumber");
            dtMessages.Columns.Add("From");
            dtMessages.Columns.Add("Subject");
            dtMessages.Columns.Add("DateSent");

            int counter = 0;
            int iCount = Convert.ToInt16(WebConfigurationManager.AppSettings["iCount"]);
            string strDisplay = WebConfigurationManager.AppSettings["from"];

            for (int i = count; i >= 1; i--)
            //for (int i = 1; i < count; i++)
            {
                Message message = pop3Client.GetMessage(i);

                //if (message.Headers.From.DisplayName == strDisplay)
                //{
                //if (message.Headers.Subject == "FW: Magnetic Hill/Magic Mountain updates")
                //{
                dtMessages.Rows.Add();

                dtMessages.Rows[dtMessages.Rows.Count - 1]["MessageNumber"] = i;
                dtMessages.Rows[dtMessages.Rows.Count - 1]["From"] = message.Headers.From.Address;
                dtMessages.Rows[dtMessages.Rows.Count - 1]["Subject"] = message.Headers.Subject;
                dtMessages.Rows[dtMessages.Rows.Count - 1]["DateSent"] = message.Headers.DateSent.ToLocalTime();

                counter++;

                ////if (counter > iCount)
                //{
                //    break;
                //}
                //}
                //}
            }

            gvEmails.DataSource = dtMessages;
            gvEmails.DataBind();
        }
    }
}