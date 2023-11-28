
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


public partial class City_View : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                bindGrid(gvCities);
            }
        }
        else
        {
            Response.Redirect("~/AdminPanel/Login");
        }
    }
    #endregion

    #region Grid Row Command Event
    protected void gvCities_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteCity")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion

    #region Grind Binding Function
    private void bindGrid(GridView gv)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();
        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_City_SelectAll";
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
            gv.DataSource = tbl;
            gv.DataBind();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to load data!')", true);
        }
        finally
        {
            con.Close();
        }
    }
    #endregion

    #region Delete City Record
    private void DeleteRecord(int id)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();

        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_City_DeleteRowByPK";
            cmd.Parameters.AddWithValue("@CtID", id);
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
            cmd.ExecuteNonQuery();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record deleted successfully!')", true);

            bindGrid(gvCities);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Plaese make sure this record is not linked anywhere.')", true);
        }
        finally
        {
            con.Close();
        }
    }
    #endregion
}