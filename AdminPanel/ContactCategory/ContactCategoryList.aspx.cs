
#region Libraries
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion


public partial class ContactCategory_View : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                bindGrid(gvContactCategory);
            }
        }
        else
        {
            Response.Redirect("~/AdminPanel/Login");
        }
    }
    #endregion

    #region Grid Row Command Event
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteContactCategory")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecordContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion

    #region Grid Bind Function
    private void bindGrid(GridView gv)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();
        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_ContactCategory_SelectAll";
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));

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

    #region Delete Contact Category Function
    private void DeleteRecordContactCategory(int id)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();

        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_ContactCategory_DeleteRowByPK";
            cmd.Parameters.AddWithValue("@CcID", id);
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
            cmd.ExecuteNonQuery();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record deleted successfully!')", true);

            bindGrid(gvContactCategory);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please make sure this record doesn't have any links.')", true);
        }
        finally
        {
            con.Close();
        }
    }
    #endregion

}