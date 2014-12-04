using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UClickerWeb
{
    public partial class vote : System.Web.UI.Page
    {
        Button btnSubmit;
        Label lblStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["PollID"] == null)
                Response.Redirect("index.aspx");
            if (IsPostBack)
            {
                loadPoll(true);
                return;
            }
            loadPoll(false);
        }

        protected void loadPoll(bool postBack)
        {
            lblQuestion.Text = dbControls.dbQuery("SELECT Question FROM Polls WHERE PollID = " + Session["PollID"].ToString());

            SqlConnection con = new SqlConnection(dbControls.getConnectionString());
            String query = @"SELECT ResponseID, Response FROM Responses WHERE PollID = " + Session["PollID"];
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                RadioResponse rdResponse = new RadioResponse(rdr[0].ToString());
                rdResponse.Text = rdr[1].ToString();
                rdResponse.GroupName = "grpResponses";
                frmResponses.Controls.Add(rdResponse);
                frmResponses.Controls.Add(new LiteralControl("<br />"));
            }
            con.Close();

            frmResponses.Controls.Add(new LiteralControl("<br />"));

            lblStatus = new Label();
            lblStatus.ForeColor = System.Drawing.Color.Red;
            if (postBack)
                lblStatus.Text = "Select a response before submitting.";
            frmResponses.Controls.Add(lblStatus);

            frmResponses.Controls.Add(new LiteralControl("<br />"));

            btnSubmit = new Button();
            btnSubmit.CssClass = "btn btn-primary btn-block";
            btnSubmit.ID = "btnSubmit";
            btnSubmit.Text = "Submit";
            btnSubmit.Click += btnSubmit_Click;
            
            frmResponses.Controls.Add(btnSubmit);

        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            bool rdChecked = false;
            int responseID = 0;
            foreach (RadioResponse rdResponse in frmResponses.Controls.OfType<RadioResponse>())
                if (rdResponse.Checked)
                {
                    rdChecked = true;
                    responseID = rdResponse.ResponseID;
                }
            if (!rdChecked)
                return;

            //If Verified, don't let same UserID answer same poll twice.  Instead, update the answer.
            if (dbControls.dbQuery("SELECT Verified FROM Polls WHERE PollID = " + Session["PollID"].ToString()) == "True")
            {
                if (Convert.ToInt32(dbControls.dbQuery("SELECT COUNT(*) FROM Polls_Responses WHERE PollID = " + Session["PollID"].ToString() + " AND PollerID = '" + Session["UserID"].ToString() + "'")) > 0)
                {
                    dbControls.dbNonQuery("UPDATE Polls_Responses SET ResponseID = " + responseID.ToString() + " WHERE PollID = " + Session["PollID"] + " AND PollerID = '" + Session["UserID"].ToString() + "'");
                    Session["Success"] = "Yay!";
                    Response.Redirect("confirmation.aspx");
                    return;
                }
            }

            dbControls.dbNonQuery("INSERT INTO Polls_Responses (PollID, PollerID, ResponseID) VALUES (" + Session["PollID"].ToString() + 
                    ", '" + Session["UserID"] + "', " + responseID.ToString() + ")");
            Session["Success"] = "Yay!";
            Response.Redirect("confirmation.aspx");
        }

        public class RadioResponse : RadioButton
        {
            public int ResponseID { get; set; }

            public RadioResponse(string id)
            {
                this.ResponseID = Convert.ToInt32(id);
            }

        }
    }
}