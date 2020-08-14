using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class OnlineReport_Selectedcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            lblId.Text = HttpUtility.UrlDecode(Request.QueryString["Alias"]);
            this.BindGrid();
        }
        
    }
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("outstandingpaymentgateway"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customercode", lblId.Text.Trim());
                cmd.Parameters.AddWithValue("@action", "behala");


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        if (dt.Rows.Count != 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            //Calculate Sum and display in Footer Row
                            decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("PAYABLEAMOUNT"));
                            GridView1.FooterRow.Cells[10].Text = "Total";
                            GridView1.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                            GridView1.FooterRow.Cells[11].Text = total.ToString();
                        }
                     

                    }
                }
            }
        }
    }
   
    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row1 = GridView1.Rows[e.RowIndex];
        int partyId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        string partycode = (GridView1.DataKeys[e.RowIndex].Values[1]).ToString();
        TextBox txtamount = row1.FindControl("txtPAYABLEAMOUNT") as TextBox;
        string AMOUNT = txtamount.Text;      
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("outstandingpaymentgateway"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customercode", partycode);
                cmd.Parameters.AddWithValue("@PAYABLEAMOUNT", AMOUNT);
                cmd.Parameters.AddWithValue("@partyid", partyId);
                cmd.Parameters.AddWithValue("@action", "behalaedit");
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                
            }
        }
        GridView1.EditIndex = -1;
        this.BindGrid();
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row1 = GridView1.Rows[e.RowIndex];
        int partyId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        string partycode = (GridView1.DataKeys[e.RowIndex].Values[1]).ToString();       
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("outstandingpaymentgateway"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customercode", partycode);                
                cmd.Parameters.AddWithValue("@partyid", partyId);
                cmd.Parameters.AddWithValue("@action", "behaladelete");
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        
        this.BindGrid();
    }

    protected void OnCancel(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid();
    }
    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid();
    }

    protected void Paysite(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("outstandingpaymentgateway"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customercode", lblId.Text.Trim());
                cmd.Parameters.AddWithValue("@action", "behala");


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        if (dt.Rows.Count != 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            //Calculate Sum and display in Footer Row
                            decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("PAYABLEAMOUNT"));
                            GridView1.FooterRow.Cells[10].Text = "Total";
                            GridView1.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                            GridView1.FooterRow.Cells[11].Text = total.ToString();
                            Response.Redirect(string.Format("Paymentoption.aspx?Totalamt={0}&Customercode={1}", total.ToString(), lblId.Text.Trim()));
                        }


                    }
                }
            }
        }
    }
}