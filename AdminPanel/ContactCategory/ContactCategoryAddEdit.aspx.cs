
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


public partial class ContactCategory_Add : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && Page.RouteData.Values["ContactCategoryID"] != null)
        {
            FillControls();
        }
    }
    #endregion

    #region Insert Button Click
    protected void btnContactCategoryAdd_Click(object sender, EventArgs e)
    {
        if (Page.RouteData.Values["ContactCategoryID"] != null)
        {
            AddEditCCategory(true, Convert.ToInt32(Page.RouteData.Values["ContactCategoryID"].ToString().Trim()));
        }
        else
        {
            AddEditCCategory();
        }
    }
    #endregion

    #region Cancel Button Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Insert";
        
        txtCategory.Text = "";

        Response.Redirect("~/AdminPanel/ContactCategory/List");
    }
    #endregion

    #region Add/Edit Contact Category
    private void AddEditCCategory(bool opModeUpdate = false, int ccid = -1)
    {
        if (txtCategory.Text.Trim() != "")
        {
            string cc = new CultureInfo("en-US").TextInfo.ToTitleCase(txtCategory.Text.Trim());

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
            con.Open();

            #region Update Contact Category
            if (opModeUpdate && ccid > 0)
            {
                try
                {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_ContactCategory_UpdateByPK";
                    cmd.Parameters.AddWithValue("@CcID", ccid);
                    cmd.Parameters.AddWithValue("@CcName", cc);
                    cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
                    cmd.ExecuteNonQuery();

                    Response.Redirect("~/AdminPanel/ContactCategory/List");
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data update failed!');", true);
                }
                finally
                {
                    con.Close();

                    txtCategory.Text = "";
                    txtCategory.Focus();
                    btnAdd.Text = "Insert";
                    
                }
            }
            #endregion

            #region Insert Contact Category
            else
            {
                try
                {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_ContactCategory_InsertByUserID";
                    cmd.Parameters.AddWithValue("@CcN", cc);
                    cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
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

                    txtCategory.Text = "";
                    txtCategory.Focus();
                }
            }
            #endregion
        }
    }
    #endregion

    #region Fill Page Controls
    private void FillControls()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();

        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_ContactCategory_SelectByPK";
            cmd.Parameters.AddWithValue("@CcID", Convert.ToInt32(CommonDropDownFillMethods.Base64Decode(Convert.ToString(Page.RouteData.Values["ContactCategoryID"].ToString()))));
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtCategory.Text = dr["ContactCategoryName"].ToString();
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong.');", true);
        }
        finally
        {
            con.Close();

            btnAdd.Text = "Change";
            btnCancel.Visible = true;
        }
    }

    #endregion

}