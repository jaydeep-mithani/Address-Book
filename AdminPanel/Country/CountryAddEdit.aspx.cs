
#region Libraries
using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
#endregion


public partial class Country_Add : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
        if (Session["UserID"] != null)
        {
            if (!IsPostBack && Page.RouteData.Values["CountryID"] != null)
            {
                FillControls();
            }
        }
        else
        {
            Response.Redirect("~/AdminPanel/Login");
        }
    }
    #endregion

    #region Add Country Button
    protected void btnCountryAdd_Click(object sender, EventArgs e)
    {
        string name = new CultureInfo("en-US").TextInfo.ToTitleCase(txtCountry.Text.Trim());
        string code = new CultureInfo("en-US").TextInfo.ToTitleCase(txtCode.Text.Trim());

        AddEdit(name, code);
    }
    #endregion

    #region Cancel Button Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCountry.Text = "";
        txtCode.Text = "";
        
        btnAdd.Text = "Insert";

        Response.Redirect("~/AdminPanel/Country/List");
    }
    #endregion

    #region Add/Edit Data Function
    private void AddEdit(string cn, string co)
    {

        if (txtCountry.Text.Trim() != "" && txtCode.Text.Trim() != "")
        {
            #region Data Update
            if (Page.RouteData.Values["CountryID"] != null)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
                con.Open();

                try
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "PR_Country_UpdateByPK";
                    command.Parameters.AddWithValue("@CID", Convert.ToInt32(Page.RouteData.Values["CountryID"].ToString().Trim()));
                    command.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
                    command.Parameters.AddWithValue("@CName", cn);
                    command.Parameters.AddWithValue("@CCode", co);
                    command.ExecuteNonQuery();

                    Response.Redirect("~/AdminPanel/Country/List");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data updated successfully.');", true);

                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to update the data.');", true);
                }
                finally
                {
                    con.Close();
                    txtCountry.Text = "";
                    txtCode.Text = "";
                    
                    btnAdd.Text = "Insert";
                }
            }
            #endregion

            #region Data Insert
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
                con.Open();
                try
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Country_InsertByUserID";
                    cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
                    cmd.Parameters.AddWithValue("@CName", cn);
                    cmd.Parameters.AddWithValue("@CCode", co);
                    cmd.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data inserted successfully.');", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong. Please check the data.');", true);
                }
                finally
                {
                    con.Close();

                    txtCountry.Text = "";
                    txtCode.Text = "";
                    txtCountry.Focus();
                }
            }
            #endregion
        }
    }
    #endregion

    #region Fill Page Controls
    private void FillControls()
    {
        btnAdd.Text = "Change";
        btnCancel.Visible = true;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();

        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Country_SelectByPK";
            cmd.Parameters.AddWithValue("@CID", Convert.ToInt32(CommonDropDownFillMethods.Base64Decode(Convert.ToString(Page.RouteData.Values["CountryID"].ToString().Trim()))));
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtCountry.Text = dr["CountryName"].ToString();
                txtCode.Text = dr["CountryCode"].ToString();
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
        }
        finally
        {
            con.Close();
        }
    }

    #endregion

}