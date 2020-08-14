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
using System.IO;

public partial class OnlineReport_OutStandingsReport : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            RetriveOSReport();
        }
    }
    private void RetriveOSReport()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using( SqlConnection con=new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procgetoutstandings_webportal"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Grid_osreport.DataSource = dt;
                        Grid_osreport.DataBind();
                       

                    }
                }
            }
        }
    }
    protected void exportbtn_Click(object sender, EventArgs e)
    {
        if (Grid_osreport.Rows.Count != 0)
        {
            Response.Clear();
            Response.Buffer = true;
            //Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AppendHeader("content-disposition", "attachment; filename=GridViewExport.xlsx");

            Response.AddHeader("content-disposition", "attachment;filename=Out_Standings_Report_ " + DateTime.Now.Date + ".xls");
            Response.Charset = "";

            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Grid_osreport.RenderControl(hw);
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();


        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

}