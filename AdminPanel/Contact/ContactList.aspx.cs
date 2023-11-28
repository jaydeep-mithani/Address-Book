
#region Libraries
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion


public partial class Contacts_View : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                bindGrid(gvContacts, "PR_Contact_SelectAll", Convert.ToInt32(Session["UserID"].ToString().Trim()));
                //bindGrid(gvCategories, "PR_ContactWiseContactCategory_SelectContactCategory");
            }
        }
        else{
            Response.Redirect("~/AdminPanel/Login");
        }
    }
    #endregion

    #region Grid Row Command Event
    protected void gvContacts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteContact")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        //if (e.CommandName == "ViewContactCategory")
        //{
        //    if (e.CommandArgument.ToString() != "")
        //    {
        //        FillContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()), blCategoryList);
        //    }
        //}
    }
    #endregion

    #region Grid Bind Function
    private void bindGrid(GridView gv, string PR, int arg = -1)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();

        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = PR;
            if(arg > -1)
                cmd.Parameters.AddWithValue("@UID", arg);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
            gv.DataSource = tbl;
            gv.DataBind();
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

    #region Delete Function
    private bool DeleteRow(int id)
    {
        bool success = true;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();

        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Contact_DeleteRowByPK";
            cmd.Parameters.AddWithValue("@CoID", id);
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "PR_ContactWiseContactCategory_DeleteByContactID";
            cmd2.Parameters.AddWithValue("@CoID", id);
            cmd2.ExecuteNonQuery();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Contact deleted successfully!')", true);
            success = true;
            bindGrid(gvContacts, "PR_Contact_SelectAll", Convert.ToInt32(Session["UserID"].ToString().Trim()));
            //bindGrid(gvCategories, "PR_ContactWiseContactCategory_SelectContactCategory");
        }
        catch
        {
            success = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Make sure this contact is not linked anywere.')", true);
        }
        finally
        {
            con.Close();
        }

        return success;
    }
    #endregion

    #region Delete Image Function
    
    private void DeleteRecord(int R_Id)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();

        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Contact_SelectAll";
            cmd.Parameters.AddWithValue("@UID", Session["UserID"].ToString().Trim());

            SqlDataReader sdr = cmd.ExecuteReader();

            if (DeleteRow(Convert.ToInt32(R_Id)))
            {
                FileInfo file = new FileInfo(Server.MapPath(sdr["FilePath"].ToString().Trim()));

                if (file.Exists)
                    file.Delete();
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to delete the image.')", true);
        }
        finally
        {
            con.Close();
        }
    }

    #endregion

    #region Fill Contact Category
    //private void FillContactCategory(int id, BulletedList CategoryList)
    //{
    //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
    //    con.Open();

    //    try
    //    {
    //        SqlCommand cmd = con.CreateCommand();
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandText = "PR_ContactWiseContactCategory_SelectByContactID";
    //        cmd.Parameters.AddWithValue("@CoID", id);

    //        List<string> cc = new List<string>();

    //        SqlDataReader sdr = cmd.ExecuteReader();
    //        while (sdr.Read())
    //        {
    //            cc.Add(sdr["ContactCategoryID"].ToString());
    //        }

    //        CategoryList.DataSource = cc;
    //        CategoryList.DataBind();
    //    }
    //    catch
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}
    #endregion
}