using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UClickerWeb
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_PollCodeSubmit(object sender, EventArgs e)
        {
            Session["PollID"] = dbControls.dbQuery("SELECT PollID FROM Polls WHERE PollCode = '" + tbPollCode.Text.ToString() + "' AND Active = 1");
            if (Session["PollID"].ToString() == "")
            {
                lblStatus.Text = "Poll not found.  Double check the poll code.";
                return;
            }
            else
            {
                Session["UserID"] = tbUserID.Text.ToString();
                Response.Redirect("vote.aspx");
            }
        }
    }
}