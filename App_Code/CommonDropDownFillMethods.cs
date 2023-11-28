using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownFillMethods
/// </summary>
public static class CommonDropDownFillMethods
{
    #region Fill Countries
    public static void FillDropDownCountry(DropDownList ddl, int uid)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        conn.Open();

        try
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Country_SelectAll";
            cmd.Parameters.AddWithValue("@UID", uid);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            ddl.DataSource = dt;
            ddl.DataBind();
            ddl.DataTextField = "CountryName";
            ddl.DataValueField = "CountryID";
            ddl.DataBind();
        }
        catch //(Exception ex)
        {
            Label lbl = new Label();
            lbl.Text = "Something went wrong.";
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong.');", true);
        }
        finally
        {
            conn.Close();
            ListItem li = new ListItem("--------Select Country--------", "-1");
            ddl.Items.Insert(0, li);
        }
    }
    #endregion

    #region Fill States
    public static void FillDropDownStates(DropDownList ddl, DropDownList ddlC, int uid)
    {
        ddl.Enabled = true;
        ddl.Items.Clear();
        Boolean isEmpty = false;

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
        conn.Open();

        try
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_State_SelectByCountryID";
            command.Parameters.AddWithValue("@CID", ddlC.SelectedValue);
            command.Parameters.AddWithValue("@UID", uid);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                isEmpty = true;
            }
            else
            {
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.DataTextField = "StateName";
                ddl.DataValueField = "StateID";
                ddl.DataBind();
            }
        }
        catch
        {
            Label lbl = new Label();
            lbl.Text = "Something went wrong.";
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong.');", true);
        }
        finally
        {
            if (isEmpty != true)
            {
                ListItem li = new ListItem("----------Select State----------", "-1");
                ddl.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("No States Available", "-1");
                ddl.Items.Insert(0, li);
                ddl.Enabled = false;
            }
            conn.Close();
        }
    }
    #endregion

    #region Fill Cities
    public static void FillDropDownCities(DropDownList ddl, DropDownList ddlS, int uid)
    {
        ddl.Enabled = true;
        ddl.Items.Clear();
        Boolean isEmpty = false;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MBC"].ConnectionString);
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_City_SelectByStateID";
            command.Parameters.AddWithValue("@SID", ddlS.SelectedValue);
            command.Parameters.AddWithValue("@UID", uid);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                isEmpty = true;
            }
            else
            {
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.DataTextField = "CityName";
                ddl.DataValueField = "CityID";
                ddl.DataBind();
            }

            conn.Close();
        }
        catch
        {
            Label lbl = new Label();
            lbl.Text = "Something went wrong.";
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong.');", true);
        }
        finally
        {
            if (isEmpty != true)
            {
                ListItem li = new ListItem("-----------Select City-----------", "-1");
                ddl.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("No City Available", "-1");
                ddl.Items.Insert(0, li);
                ddl.Enabled = false;
            }
        }
    }
    #endregion

    #region Encryption
    public static string Base64Encode(string plainText)
    {
        return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainText));
    }
    #endregion

    #region Decryption
    public static string Base64Decode(string base64EncodedData)
    {
        return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(base64EncodedData));
    }
    #endregion
}