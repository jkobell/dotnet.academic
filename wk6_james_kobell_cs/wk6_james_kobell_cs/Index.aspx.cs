/********************
Author: James Kobell
Date Created: 04/14/2019
Description: This is ENTD464_Assignment_WK6
Code Behind: Index.aspx.cs
Database: Halloween.mdf - Mike Murach & Associates, Inc - www.murach.com - modified
********************/

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Label9.Text = ""; //clear error message at label9.text
      
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["dropSel"]  = DropDownList1.Text; //Session to hold persistent data - drop down selected value       


        using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString))
        {            
            
            try
            {   //for this query, a DataAdapter and DataSet is used to assign SELECT results to TextBoxes
                string query1 = "SELECT ProductID, Name, ShortDescription, UnitPrice, OnHand FROM Products WHERE ProductID ='" + Session["dropSel"].ToString() + "'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query1, dbConn);
                DataSet products = new DataSet();
                dataAdapter.Fill(products, "Products");

                DataTable dT = new DataTable();
                dT = products.Tables["Products"];

                TextBox2.Text = dT.Rows[0][0].ToString();
                TextBox3.Text = dT.Rows[0][1].ToString();
                TextBox4.Text = dT.Rows[0][2].ToString();
                TextBox5.Text = dT.Rows[0][3].ToString();
                TextBox6.Text = dT.Rows[0][4].ToString();

            }
            catch (Exception ex)
            {
                string excep1 = ex.Message;
                //Label9.Text = ex.Message;
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        bool match = false;
        //checking to see if primary key [ProductID] exists
        foreach (ListItem li in DropDownList1.Items)
        {
            if (li.Value == TextBox2.Text)
            {
                match = true;
            }
        }

        if (match == false)
        {
            Label9.Text = "UPDATE ERROR: "  + TextBox2.Text + " is not a ProductID.";
        }
        else
        {
            using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString))
            {

                try
                {
                    //for this query, a DataBase adapter and DataSet is NOT used. Only SqlConnection, SqlCommand and SqlParameter objects are used.
                    string query2 = "UPDATE Products SET ProductID = @ProductID, Name = @Name, ShortDescription = @ShortDescription, UnitPrice = @UnitPrice, OnHand = @OnHand WHERE ProductID = @ProductID";

                    SqlCommand comm = new SqlCommand();

                    dbConn.Open();
                                        
                    comm.Connection = dbConn;

                    //Parameters are used to mitigate SQL injection risks.
                    SqlParameter prmProdID = new SqlParameter();
                    prmProdID.ParameterName = "@ProductID";
                    prmProdID.SqlDbType = SqlDbType.NVarChar;                    
                    prmProdID.Direction = ParameterDirection.Input;

                    SqlParameter prmName = new SqlParameter();
                    prmName.ParameterName = "@Name";
                    prmName.SqlDbType = SqlDbType.NVarChar;
                    prmName.Direction = ParameterDirection.Input;

                    SqlParameter prmShortD = new SqlParameter();
                    prmShortD.ParameterName = "@ShortDescription";
                    prmShortD.SqlDbType = SqlDbType.NVarChar;
                    prmShortD.Direction = ParameterDirection.Input;

                    SqlParameter prmUnitP = new SqlParameter();
                    prmUnitP.ParameterName = "@UnitPrice";
                    prmUnitP.SqlDbType = SqlDbType.NVarChar;
                    prmUnitP.Direction = ParameterDirection.Input;

                    SqlParameter prmOnH = new SqlParameter();
                    prmOnH.ParameterName = "@OnHand";
                    prmOnH.SqlDbType = SqlDbType.NVarChar;
                    prmOnH.Direction = ParameterDirection.Input;

                    comm.Parameters.Add(prmProdID);
                    comm.Parameters.Add(prmName);
                    comm.Parameters.Add(prmShortD);
                    comm.Parameters.Add(prmUnitP);
                    comm.Parameters.Add(prmOnH);

                    prmProdID.Value = TextBox2.Text;
                    prmName.Value = TextBox3.Text;
                    prmShortD.Value = TextBox4.Text;
                    prmUnitP.Value = TextBox5.Text;
                    prmOnH.Value = TextBox6.Text;

                    comm.CommandText = query2;

                    comm.ExecuteNonQuery();

                    dbConn.Close();

                    Response.Redirect("Index.aspx");

                }
                catch (Exception ex)
                {
                    string excep1 = ex.Message; //trapping exceptions
                    //Label9.Text = ex.Message; //remove comment // to see exceptions in label.text
                }
            }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        bool match = false;

        foreach (ListItem li in DropDownList1.Items)
        {
            if (li.Value == TextBox2.Text)
            {
                match = true;
            }
        }

        if (match == true)
        { Label9.Text = "INSERT ERROR: ProductID " +TextBox2.Text+ " already exists."; }
        else
        {
            using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString))
            {

                try
                {
                    //for this query, a DataBase adapter and DataSet is NOT used. Only SqlConnection, SqlCommand and SqlParameter objects are used.
                    string query2 = "INSERT INTO Products (ProductID, Name, ShortDescription, UnitPrice, OnHand) Values (@ProductID, @Name, @ShortDescription, @UnitPrice, @OnHand)";

                    SqlCommand comm = new SqlCommand();

                    dbConn.Open();
                                       
                    comm.Connection = dbConn;

                    SqlParameter prmProdID = new SqlParameter();
                    prmProdID.ParameterName = "@ProductID";
                    prmProdID.SqlDbType = SqlDbType.NVarChar;
                    prmProdID.Direction = ParameterDirection.Input;

                    SqlParameter prmName = new SqlParameter();
                    prmName.ParameterName = "@Name";
                    prmName.SqlDbType = SqlDbType.NVarChar;
                    prmName.Direction = ParameterDirection.Input;

                    SqlParameter prmShortD = new SqlParameter();
                    prmShortD.ParameterName = "@ShortDescription";
                    prmShortD.SqlDbType = SqlDbType.NVarChar;
                    prmShortD.Direction = ParameterDirection.Input;

                    SqlParameter prmUnitP = new SqlParameter();
                    prmUnitP.ParameterName = "@UnitPrice";
                    prmUnitP.SqlDbType = SqlDbType.NVarChar;
                    prmUnitP.Direction = ParameterDirection.Input;

                    SqlParameter prmOnH = new SqlParameter();
                    prmOnH.ParameterName = "@OnHand";
                    prmOnH.SqlDbType = SqlDbType.NVarChar;
                    prmOnH.Direction = ParameterDirection.Input;

                    comm.Parameters.Add(prmProdID);
                    comm.Parameters.Add(prmName);
                    comm.Parameters.Add(prmShortD);
                    comm.Parameters.Add(prmUnitP);
                    comm.Parameters.Add(prmOnH);

                    prmProdID.Value = TextBox2.Text;
                    prmName.Value = TextBox3.Text;
                    prmShortD.Value = TextBox4.Text;
                    prmUnitP.Value = TextBox5.Text;
                    prmOnH.Value = TextBox6.Text;

                    comm.CommandText = query2;

                    comm.ExecuteNonQuery();

                    dbConn.Close();

                    Response.Redirect("Index.aspx");
                }
                
                catch (Exception ex)
                {
                    string excep1 = ex.Message;
                    //Label9.Text = ex.Message;
                }

            }
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString))
        {            
            
            try
            {
                //for this query, a DataBase adapter and DataSet is NOT used. Only SqlConnection, SqlCommand and SqlParameter objects are used.
                SqlCommand comm;

                dbConn.Open();
                comm = new SqlCommand();
                comm.Connection = dbConn;
               
                SqlParameter prID = new SqlParameter();
                prID.ParameterName = "@ProductID";
                prID.SqlDbType = SqlDbType.NVarChar;
                prID.Direction = ParameterDirection.Input;

                comm.Parameters.Add(prID);

                prID.Value = TextBox2.Text;

                comm.CommandText = "DELETE FROM Products WHERE ProductID = @ProductID";

                comm.ExecuteNonQuery();
                
                Response.Redirect("Index.aspx");
            }
            catch (SqlException ex)
            {
                string excep1 = ex.Message;
                //Label9.Text = ex.Message;

            }
        }
    }    
}
