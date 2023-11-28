
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

public partial class SignupForm : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region Sign-Up Button Click
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        bool proceed = true;
        if(txtUserName.Text.Trim() != "")
        {
            bool varify = CheckUserName(txtUserName.Text.Trim());
            
            if (varify)
            {
                lblErrUsrName.Text = "Username already in use by someone.";
                lblErrUsrName.ForeColor = System.Drawing.Color.Red;
                proceed = false;
            }
        }
        if(txtPass.Text.Trim() != "" && txtPass.Text != txtConfPass.Text)
        {
            lblErrPass.Text = "Passwords don't match!";
            lblErrPass.ForeColor = System.Drawing.Color.Red;
            proceed = false;
        }
        if (proceed && txtPhone.Text.Trim() != "" && txtEmail.Text.Trim() != "" && txtFirstName.Text.Trim() != "" && txtLastName.Text.Trim() != "")
        {
            AddUser(txtUserName.Text.Trim(), txtPass.Text, txtPhone.Text.Trim(), txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim(), txtEmail.Text.Trim());
        }
    }
    #endregion

    #region Add User Function
    private void AddUser(string un, string pw, string ph, string n, string em)
    { 
        //n = new CultureInfo("en-US").TextInfo.ToTitleCase(txtLastName.Text.Trim());
        em.ToLower();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();

        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_MbUsers_Insert";
            cmd.Parameters.AddWithValue("@UName", un);
            cmd.Parameters.AddWithValue("@UPass", pw);
            cmd.Parameters.AddWithValue("@DName", new CultureInfo("en-US").TextInfo.ToTitleCase(n));
            cmd.Parameters.AddWithValue("@UPhone", ph);
            cmd.Parameters.AddWithValue("@UEm", em.ToLower());
            cmd.ExecuteNonQuery();

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You're now signed up!')", true);

            Response.Redirect("~/AdminPanel/Login");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Yey! You're now signed up!')", true);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('An unknown error occured!')", true);
        }
        finally
        {
            con.Close();

            txtUserName.Text = "";
            txtPass.Text = "";
            txtConfPass.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
        }
    }
    #endregion

    #region Verify Usrname function
    private bool CheckUserName(string un)
    {
        bool invalid = false;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();
        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_MbUsers_SelectAll";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if(un == dr["UserName"].ToString().Trim())
                {
                    invalid = true;
                    break;
                }
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Couldn't retrive the username!')", true);
        }
        finally
        {
            con.Close();
        }
        return invalid;
    }
    #endregion
}