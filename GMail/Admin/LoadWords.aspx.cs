using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GMail.Admin
{
	public partial class LoadWords : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if ((Session["loggedin"] == null) || (Session["loggedin"].ToString() == "false"))
			{
				Response.Redirect("../Default.aspx");
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