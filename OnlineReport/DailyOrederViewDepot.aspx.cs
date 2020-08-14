using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class OnlineReport_DailyOrederViewDepot : System.Web.UI.Page
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
            //Session["username"] = "MP100362";

        }
        Menu men = (Menu)Master.FindControl("NavigationMenu");
        men.Visible = false;
            
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procmadinvoicegeafbill"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@startdate", txtfrmdate.Text.Trim());
                cmd.Parameters.AddWithValue("@endate", txttodate.Text.Trim());
                cmd.Parameters.AddWithValue("@HQ", DROPDOWNHQ.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@customercode", CCode.Text.Trim());
                cmd.Parameters.AddWithValue("@depoemail", Session["username"].ToString());
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvorder.DataSource = dt;
                        gvorder.DataBind();
                        //Response.Redirect("selectedcode.aspx?Alias=" + customercode);
                    }
                }
            }
        }
    }
    protected void btndownload_Click(object sender, EventArgs e)
    {

        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procmadinvoicegeafbill"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@startdate", txtfrmdate.Text.Trim());
                cmd.Parameters.AddWithValue("@endate", txttodate.Text.Trim());
                cmd.Parameters.AddWithValue("@depoemail", Session["username"].ToString());
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            DateTime now = DateTime.Now;
                            string filename = "ORDER_DETAILS" + now.ToString() + ".xls";
                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                            DataGrid dgGrid = new DataGrid();
                            dgGrid.DataSource = dt;
                            dgGrid.DataBind();

                            //Get the HTML for the control.
                            dgGrid.RenderControl(hw);
                            //Write the HTML back to the browser.
                            //Response.ContentType = application/vnd.ms-excel;
                            Response.ContentType = "application/vnd.ms-excel";
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                            this.EnableViewState = false;
                            Response.Write(tw.ToString());
                            Response.End();
                        }
                        
                    }
                }
            }
        }






    }
}