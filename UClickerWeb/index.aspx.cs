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
            string debug = dbControls.dbQuery("SELECT Verified FROM Polls WHERE PollID = " + Session["PollID"].ToString());
            if (dbControls.dbQuery("SELECT Verified FROM Polls WHERE PollID = " + Session["PollID"].ToString()) == "True")
            {
                string verification = dbControls.dbQuery(@"
                SELECT PollerID 
                FROM [uClicker].[dbo].[Polls] P 
	                LEFT JOIN [uClicker].[dbo].[Groups] G
	                ON G.GroupID = P.GroupID
	                LEFT JOIN [uClicker].[dbo].[Groups_Members] GM
	                ON GM.GroupID = G.GroupID
                WHERE Active = 1 AND PollCode = '" + tbPollCode.Text.ToString() + "' AND PollerID = '" + tbUserID.Text.ToString() + @"'
                ");
                if (verification.ToLower() != tbUserID.Text.ToString().ToLower())
                {
                    lblStatus.Text = "You are not authorized to respond to requested poll.";
                    return;
                }
            }                

            Session["UserID"] = tbUserID.Text.ToString();
            Response.Redirect("vote.aspx");

        }
    }
}