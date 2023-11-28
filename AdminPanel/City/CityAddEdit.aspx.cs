
#region Libraries

using System;
//using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
//using System.Linq;
//using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#endregion


public partial class Contact_Add : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                CommonDropDownFillMethods.FillDropDownCountry(ddlCountries, Convert.ToInt32(Session["UserID"].ToString().Trim()));

                if (Page.RouteData.Values["CityID"] != null)
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

    #region Insert Button Click
    protected void btnCityAdd_Click(object sender, EventArgs e)
    {
        if (Page.RouteData.Values["CityID"] != null)
        {
            AddEditCity(true, Convert.ToInt32(Page.RouteData.Values["CityID"].ToString().Trim()));
        }
        else
        {
            AddEditCity();
        }
    }
    #endregion

    #region Countries Index Change
    protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountries.SelectedIndex == 0)
        {
            ListItem li = new ListItem("Select a country first", "-1");
            ddlStates.Items.Clear();
            ddlStates.Items.Insert(0, li);
            ddlStates.Enabled = false;
        }
        else
        {
            CommonDropDownFillMethods.FillDropDownStates(ddlStates, ddlCountries, Convert.ToInt32(Session["UserID"].ToString().Trim()));
        }
    }
    #endregion

    #region Cancel Button Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        btnAdd.Text = "Insert";
        ddlCountries.SelectedIndex = 0;
        ddlStates.Items.Clear();
        ddlStates.Items.Add(new ListItem("Select a country first", "-1"));
        txtCity.Text = "";
        txtSTD.Text = "";
        txtZIP.Text = "";

        Response.Redirect("~/AdminPanel/City/List");
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

    //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        adapter.Fill(dt);
    //        ddl.DataSource = dt;
    //        ddl.DataBind();
    //        ddl.DataTextField = "CountryName";
    //        ddl.DataValueField = "CountryID";
    //        ddl.DataBind();
    //    }
    //    catch
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong.');", true);
    //    }
    //    finally
    //    {
    //        conn.Close();
    //        ListItem li = new ListItem("------Select Country------", "-1");
    //        ddl.Items.Insert(0, li);
    //    }
    //}
    #endregion

    #region Fill States Drop Down
    //private void FillDropDownStates(DropDownList ddl)
    //{
    //    ddl.Enabled = true;
    //    ddl.Items.Clear();
    //    Boolean isEmpty = false;
    //    try
    //    {
    //        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
    //        conn.Open();

    //        SqlCommand command = conn.CreateCommand();
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.CommandText = "PR_State_SelectByCountryID";
    //        command.Parameters.AddWithValue("@CID", ddlCountries.SelectedValue);
    //        command.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));

    //        SqlDataAdapter adapter = new SqlDataAdapter(command);
    //        DataTable dt = new DataTable();
    //        adapter.Fill(dt);
    //        if (dt.Rows.Count < 1)
    //        {
    //            isEmpty = true;
    //        }
    //        else
    //        {
    //            ddl.DataSource = dt;
    //            ddl.DataBind();
    //            ddl.DataTextField = "StateName";
    //            ddl.DataValueField = "StateID";
    //            ddl.DataBind();
    //        }

    //        conn.Close();
    //    }
    //    catch
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong.');", true);
    //    }
    //    finally
    //    {
    //        if (isEmpty != true)
    //        {
    //            ListItem li = new ListItem("--------Select State--------", "-1");
    //            ddl.Items.Insert(0, li);
    //        }
    //        else
    //        {
    //            ListItem li = new ListItem("No States Available", "-1");
    //            ddl.Items.Insert(0, li);
    //            ddl.Enabled = false;
    //        }
    //    }
    //}
    #endregion

    #region Add/Edit City
    private void AddEditCity(bool opModeUpdate = false, int ctid = -1)
    {
        if (ddlCountries.SelectedValue != "-1" && ddlStates.SelectedValue != "-1" && txtCity.Text.Trim() != "" && txtSTD.Text.Trim() != "" && txtZIP.Text.Trim() != "")
        {
            string c = new CultureInfo("en-US").TextInfo.ToTitleCase(txtCity.Text.Trim());
            string s = new CultureInfo("en-US").TextInfo.ToTitleCase(txtSTD.Text.Trim());
            string z = new CultureInfo("en-US").TextInfo.ToTitleCase(txtZIP.Text.Trim());

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
            conn.Open();

            #region Update Operation
            if (opModeUpdate && ctid > 0)
            {
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_City_UpdateByPK";
                    cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
                    cmd.Parameters.AddWithValue("@Ctid", ctid);
                    cmd.Parameters.AddWithValue("@SID", Convert.ToInt32(ddlStates.SelectedValue.Trim()));
                    cmd.Parameters.AddWithValue("@CtName", c);
                    cmd.Parameters.AddWithValue("@StCode", s);
                    cmd.Parameters.AddWithValue("@PCode", z);
                    cmd.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Updated Successfully.');", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to update data.');", true);
                }
                finally
                {
                    conn.Close();

                    
                    btnAdd.Text = "Insert";
                    ddlCountries.SelectedIndex = 0;
                    ddlStates.Items.Clear();
                    ddlStates.Items.Add(new ListItem("Select a country first", "-1"));
                    ddlStates.Enabled = false;
                    txtCity.Text = "";
                    txtSTD.Text = "";
                    txtZIP.Text = "";

                    Response.Redirect("~/AdminPanel/City/List");
                }
            }
            #endregion

            #region Insert Operation
            else
            {
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_City_InsertByUserID";
                    cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
                    cmd.Parameters.AddWithValue("@SID", Convert.ToInt32(ddlStates.SelectedValue));
                    cmd.Parameters.AddWithValue("@CtName", c);
                    cmd.Parameters.AddWithValue("@StCode", s);
                    cmd.Parameters.AddWithValue("@PCode", z);
                    cmd.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data inserted successfully.')", true);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to insert data.May be check the values?.')", true);
                }
                finally
                {
                    conn.Close();

                    txtCity.Text = "";
                    txtSTD.Text = "";
                    txtZIP.Text = "";
                    ddlCountries.SelectedIndex = 0;
                    ddlStates.Items.Clear();
                    ddlStates.Items.Add(new ListItem("Select a country first", "-1"));
                    ddlStates.Enabled = false;
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
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        con.Open();
        SqlConnection con2 = null;

        try
        {
            string cou = "-1";
            string sta = "-1";

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_City_SelectByPK";
            cmd.Parameters.AddWithValue("@CtID", Convert.ToInt32(CommonDropDownFillMethods.Base64Decode(Convert.ToString(Page.RouteData.Values["CityID"].ToString().Trim()))));
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
            cmd.ExecuteNonQuery();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sta = dr["StateID"].ToString().Trim();

                txtCity.Text = dr["CityName"].ToString().Trim();
                txtSTD.Text = dr["STDCode"].ToString().Trim();
                txtZIP.Text = dr["PinCode"].ToString().Trim();
            }

            con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
            con2.Open();
            SqlCommand cmd2 = con2.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "PR_State_SelectByPK";
            cmd2.Parameters.AddWithValue("@SID", Convert.ToInt32(sta));
            cmd2.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"].ToString().Trim()));
            cmd2.ExecuteNonQuery();

            SqlDataReader sdr = cmd2.ExecuteReader();
            while (sdr.Read())
            {
                cou = sdr["CountryID"].ToString().Trim();
            }
            con2.Close();

            ddlCountries.SelectedValue = cou;
            CommonDropDownFillMethods.FillDropDownStates(ddlStates, ddlCountries, Convert.ToInt32(Session["UserID"].ToString().Trim()));
            ddlStates.SelectedValue = sta;
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