
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

public partial class Country_View : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
                bindGrid(gvCountries);
        }
        else
        {
            Response.Redirect("~/AdminPanel/Login");
        }
    }
    #endregion

    #region Grid View Row Command Event
    protected void gvCountries_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deleteCountry")
        {
            if (e.CommandArgument.ToString() != "")
            {
                deleteCurrentRow(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion

    #region Grid Binding Function
    private void bindGrid(GridView gv)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();
        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Country_SelectAll";
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
            gv.DataSource = tbl;
            gv.DataBind();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to load data.')", true);
        }
        finally
        {
            con.Close();
        }
    }
    #endregion

    #region Current Row Delete Function
    private void deleteCurrentRow(Int32 id)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();
        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Country_DeleteRowByPK";
            cmd.Parameters.AddWithValue("@CID", id);
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
            cmd.ExecuteNonQuery();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);

            bindGrid(gvCountries);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Make sure this country is not linked anywere.')", true);
        }
        finally
        {
            con.Close();
        }
    }
    #endregion

}