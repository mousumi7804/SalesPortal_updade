using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class OnlineReport_Madsecondarysalestatementt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private Madsecondarystatement GetData()
    {
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        SqlCommand cmd = new SqlCommand("Alldivisionsecondarysalestatement");
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "MAD");
                cmd.Parameters.AddWithValue("@month", DropDownList2.SelectedValue);
                //cmd.Parameters.AddWithValue("@endate", txttodate.Text.Trim());
                //cmd.Parameters.AddWithValue("@customercode", Customercode.Text.Trim());
                //cmd.Parameters.AddWithValue("@Billno", BillNo.Text.Trim());
                //cmd.Parameters.AddWithValue("@SKT", listvalue);
                //cmd.Parameters.AddWithValue("@HQ", HQ.Text.Trim());
                //cmd.Parameters.AddWithValue("@pps", Productvalue);
                //cmd.Parameters.AddWithValue("@RTD", Returntypevalue);
                //cmd.Parameters.Add("@message", SqlDbType.VarChar, 300);
                //cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                sda.SelectCommand = cmd;

                using (Madsecondarystatement dsCustomers = new Madsecondarystatement())
                {
                    sda.Fill(dsCustomers, "Madsecondarystatement");
                    //lblstatus.Text = cmd.Parameters["@message"].Value.ToString();
                    return dsCustomers;
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/madsecondarysalestatement.rdlc");
        Madsecondarystatement dsCustomers = GetData();
        ReportDataSource datasource = new ReportDataSource("DataSet1", dsCustomers.Tables[0]);
        //ReportParameter rp = new ReportParameter("Startdate", txtfrmdate.Text.ToString());
        //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
        //ReportParameter rp1 = new ReportParameter("Enddate", txttodate.Text.ToString());
        //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1 });
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(datasource);
    }
}