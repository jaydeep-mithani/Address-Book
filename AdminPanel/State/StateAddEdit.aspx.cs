
#region Libraries
using System;
//using System.Text;
using System.Globalization;
//using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Data;
#endregion


public partial class State_Add : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                CommonDropDownFillMethods.FillDropDownCountry(ddlCountries, Convert.ToInt32(Session["UserID"].ToString().Trim()));

                if (Page.RouteData.Values["StateID"] != null)
                {
                    FillControls();
                }
            }
        }
        else
        {
            Response.Redirect("~/AdminPanel/Login");
        }
    }
    #endregion

    #region Add Button Click
    protected void btnStateAdd_Click(object sender, EventArgs e)
    {
        if (Page.RouteData.Values["StateID"] != null)
        {
            AddEdit(true, Convert.ToInt32(Page.RouteData.Values["StateID"].ToString().Trim()));
        }
        else
        {
            AddEdit();
        }
    }
    #endregion

    #region Cancel Button Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCode.Text = "";
        txtState.Text = "";
        ddlCountries.SelectedIndex = 0;
        
        btnAdd.Text = "Insert";
        Response.Redirect("~/AdminPanel/State/List");
    }
    #endregion

    #region Fill Country Drop Down
    //private void FillDropDownCountry(DropDownList ddl)
    //{
    //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
    //    conn.Open();
    //    try
    //    {
    //        SqlCommand cmd = conn.CreateCommand();
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandText = "PR_Country_SelectAll";
    //        cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
    //        cmd.ExecuteNonQuery();

    //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        adapter.Fill(dt);
    //        ddl.DataSource = dt;
    //        ddl.DataBind();
    //        ddl.DataTextField = "CountryName";
    //        ddl.DataValueField = "CountryID";
    //        ddl.DataBind();

    //        conn.Close();
    //    }
    //    catch
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong.');", true);
    //    }
    //    finally
    //    {
    //        conn.Close();
    //        ListItem li = new ListItem("----Select----", "-1");
    //        ddl.Items.Insert(0, li);
    //    }
    //}
    #endregion

    #region Add/Edit State
    private void AddEdit(bool opModeUpdate = false, int sid = -1)
    {
        SqlConnection conn = null;

        string name = new CultureInfo("en-US").TextInfo.ToTitleCase(txtState.Text.Trim());
        string code = new CultureInfo("en-US").TextInfo.ToTitleCase(txtCode.Text.Trim());

        if (ddlCountries.SelectedValue != "-1" && txtState.Text.Trim() != "" && txtCode.Text.Trim() != "")
        {

            #region Update Mode
            if (opModeUpdate && sid > 0)
            {

                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
                conn.Open();

                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_State_UpdateByPK";
                    cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
                    cmd.Parameters.AddWithValue("@CID", Convert.ToInt32(ddlCountries.SelectedValue));
                    cmd.Parameters.AddWithValue("@SID", sid);
                    cmd.Parameters.AddWithValue("@SName", name);
                    cmd.Parameters.AddWithValue("@SCode", code);
                    cmd.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Updated Successfully')", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to update data.')", true);
                }
                finally
                {
                    conn.Close();

                    btnAdd.Text = "Insert";
                    

                    txtState.Text = "";
                    txtCode.Text = "";
                    ddlCountries.SelectedIndex = 0;

                    Response.Redirect("~/AdminPanel/State/List");
                }
            }
            #endregion

            #region Insert Mode
            else
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
                conn.Open();

                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_State_InsertByUserID";
                    cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
                    cmd.Parameters.AddWithValue("@CID", Convert.ToInt32(ddlCountries.SelectedValue));
                    cmd.Parameters.AddWithValue("@SName", name);
                    cmd.Parameters.AddWithValue("@SCode", code);
                    cmd.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data inserted successfully.')", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong. May be check the values again?');", true);
                }
                finally
                {
                    conn.Close();

                    txtState.Text = "";
                    txtCode.Text = "";
                    ddlCountries.SelectedIndex = 0;
                    ddlCountries.Focus();
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
            cmd.CommandText = "PR_State_SelectByPK";
            cmd.Parameters.AddWithValue("@SID", Convert.ToInt32(CommonDropDownFillMethods.Base64Decode(Convert.ToString((Page.RouteData.Values["StateID"].ToString().Trim())))));
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddlCountries.SelectedValue = dr["CountryID"].ToString();
                txtState.Text = dr["StateName"].ToString();
                txtCode.Text = dr["StateCode"].ToString();
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