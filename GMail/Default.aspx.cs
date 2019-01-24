using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GMail.classes;

namespace GMail
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["loggedin"] != null) && (Session["loggedin"].ToString() != "false"))
            {
                divLoginName.Visible = false;
                divPassword.Visible = false;
                divSpacer1.Visible = false;
                divSpacer2.Visible = false;
                divSpacer3.Visible = false;
                lbLogout.Enabled = true;
            }

            else
            {
                divLoginName.Visible = true;
                divPassword.Visible = true;
                divSpacer1.Visible = true;
                divSpacer2.Visible = true;
                divSpacer3.Visible = true;
                lbLogout.Enabled = false;
            }
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            if (DatabaseAccess.VerifyLogin(txtUsername.Text, txtPassword.Text))
            {
                Session["loggedin"] = true;
                lblMessage.Text = "User logged in.  Session logged in is: " + Session["loggedin"].ToString();
                Response.Redirect("Default.aspx");
                lblMessage.Visible = false;
            }

            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Unsuccessful login attempt.  Username and passwords are case sensitive.";
            }
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session["loggedin"] = false;
            Session.Clear();
            lblMessage.Text = "User logged out.";
            Response.Redirect("Default.aspx");
        }
    }
}