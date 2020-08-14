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
		
		 if (Session["username"].ToString() == "pradip.sarkar@mendine.co.in")
        {
            Menu mainMenu = (Menu)Page.Master.FindControl("Candidatemeenu");
            mainMenu.Visible=false;
        }
		
				
		
		else
		if(Session["username"].ToString() == "sanjay.mukherjee@mendine.co.in")
		{
			
			 Menu mainMenu = (Menu)Page.Master.FindControl("Candidatemeenu");
            mainMenu.Visible=false;
		}
		else
if(Session["username"].ToString() == "lincon.banerjee@mendine.co.in")
		{
			
			 Menu mainMenu = (Menu)Page.Master.FindControl("Candidatemeenu");
            mainMenu.Visible=false;
			//Ddlselect.Items[3].Enabled = false;
		}
      
	else
	  {
		  Menu mainMenu = (Menu)Page.Master.FindControl("Candidatemeenu");
            mainMenu.Visible=true;
	  }
		
		
		
		
		
        if (Session["username"] == null)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            //or use Response.Redirect to go to a different page
            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/Account/Login.aspx");

        }
        if (!IsPostBack)
        {


           // RetriveStock();
            RetriveStockLocation();
        }
            

    }
    private void RetriveStock()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("ClosingStock_WebPortal"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@deponame", DropDownstocklocation.SelectedValue);

                
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Grid_stockdetails.DataSource = dt;
                        Grid_stockdetails.DataBind();
                        //Calculate Sum and display in Footer Row
                        decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Stock Value"));
                        Grid_stockdetails.FooterRow.Cells[9].Text = "Total";
                        Grid_stockdetails.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                        Grid_stockdetails.FooterRow.Cells[10].Text = total.ToString("N2");
                        
                    }
                }
            }
        }
    }
    private void RetriveStockLocation()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("procgetstocklocation_webportal"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                

                
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        DropDownstocklocation.DataSource=dt;
                        DropDownstocklocation.DataTextField="depo";
                        DropDownstocklocation.DataValueField="depocode";
                        DropDownstocklocation.DataBind();
                        DropDownstocklocation.Items.Insert(0, new ListItem("All", "All"));

                        
                    }
                }
            }
        }
    }
    protected void exportbtn_Click(object sender, EventArgs e)
    {
        if (Grid_stockdetails.Rows.Count != 0)
        {
            Response.Clear();
            Response.Buffer = true;
            //Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AppendHeader("content-disposition", "attachment; filename=GridViewExport.xlsx");

            Response.AddHeader("content-disposition", "attachment;filename=Stock Report " + DateTime.Now.Date + ".xls");
            Response.Charset = "";

            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Grid_stockdetails.RenderControl(hw);
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
     RetriveStock();

 }
}