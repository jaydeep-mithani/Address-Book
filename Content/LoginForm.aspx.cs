
#region Libraries
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class LoginForm : System.Web.UI.Page
{

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Login Button Click
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        bool check = IsValidUser(txtUsrName.Text.Trim(), txtPass.Text);

        if (!check)
        {
            lblErr.Text = "Incorrect username or password. Please try again.";
            lblErr.ForeColor = System.Drawing.Color.Red;
            lblErr.Visible = true;
        }
        else
        {
            CreateSession(txtUsrName.Text.Trim(), txtPass.Text);
        }
    }
    #endregion

    #region Create Session
    private void CreateSession(string un, string pw)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();

        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_MbUsers_SelectByPK";
            cmd.Parameters.AddWithValue("@Uname", un);
            cmd.Parameters.AddWithValue("PW", pw);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session["UserID"] = dr["UserID"].ToString().Trim();
                Session["Name"] = dr["DisplayName"].ToString().Trim();
            }

            Response.Redirect("~/AdminPanel/Country/List");
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to create session!')", true);
        }
        finally
        {
            con.Close();
        }
    }
    #endregion

    #region Validate User
    private bool IsValidUser(string un, string pw)
    {
        bool val = true;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();

        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_MbUsers_SelectByPK";
            cmd.Parameters.AddWithValue("@Uname", un);
            cmd.Parameters.AddWithValue("@PW", pw);

            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                val = false;
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('An Unexpected error occured!')", true);
        }
        finally
        {
            con.Close();
        }
        return val;
    }
    #endregion
}