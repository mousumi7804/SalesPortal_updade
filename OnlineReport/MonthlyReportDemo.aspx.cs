using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class OnlineReport_StockReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            //or use Response.Redirect to go to a different page
            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/Account/Login.aspx");

        }
       // Retrivesales();
        //if (!IsPostBack)
        //{


        //   // RetriveStock();
        //    RetriveStockLocation();
        //}
            

    }
    private void Retrivesales()
    {
        
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("Mad_designationwise_sale"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", null);
                //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                       
                        sda.Fill(dt);

                        TextBox1.Text = dt.Rows.Count.ToString();
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        TextBox1.Text = dt.Rows.Count.ToString();
                        //Calculate Sum and display in Footer Row
                        //decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Stock Value"));
                        //Grid_sales.FooterRow.Cells[9].Text = "Total";
                        //Grid_sales.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                        //Grid_sales.FooterRow.Cells[10].Text = total.ToString("N2");

                    }
                }
            }
        }
    }
    //private void RetriveStockLocation()
    //{
    //    string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
    //    using (SqlConnection conn = new SqlConnection(constr))
    //    {

    //        using (SqlCommand cmd = new SqlCommand("procgetstocklocation_webportal"))
    //        {
    //            cmd.CommandType = CommandType.StoredProcedure;
                

                
    //            using (SqlDataAdapter sda = new SqlDataAdapter())
    //            {
    //                cmd.Connection = conn;
    //                sda.SelectCommand = cmd;
    //                using (DataTable dt = new DataTable())
    //                {
    //                    sda.Fill(dt);
    //                    DropDownstocklocation.DataSource=dt;
    //                    DropDownstocklocation.DataTextField="depo";
    //                    DropDownstocklocation.DataValueField="depocode";
    //                    DropDownstocklocation.DataBind();
    //                    DropDownstocklocation.Items.Insert(0, new ListItem("All", "All"));

                        
    //                }
    //            }
    //        }
    //    }
    //}
    protected void exportbtn_Click(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count != 0)
        {
            Response.Clear();
            Response.Buffer = true;
            //Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AppendHeader("content-disposition", "attachment; filename=GridViewExport.xlsx");

            Response.AddHeader("content-disposition", "attachment;filename=Sales Report " + DateTime.Now.Date + ".xls");
            Response.Charset = "";

            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();


        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void  btnstocksearch_Click(object sender, EventArgs e)

 {
     Retrivesales();

 }
}