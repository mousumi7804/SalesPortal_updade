using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class OnlineReport_Collectionreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private Collectionreport GetData()
    {
        string listvalue = "";
        foreach (ListItem item in SKT.Items)
        {
            if (item.Selected)
            {
                listvalue += item.Value + ",";
            }
        }
        string ctypevalue = "";
        foreach (ListItem item in CollectionType.Items)
        {
            if (item.Selected)
            {
                ctypevalue += item.Value + ",";
            }
        }
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        SqlCommand cmd = new SqlCommand("Collectionreportautomation_test");
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@startdate", txtfrmdate.Text.Trim());
                cmd.Parameters.AddWithValue("@endate", txttodate.Text.Trim());
                cmd.Parameters.AddWithValue("@customercode", Customercode.Text.Trim());
                cmd.Parameters.AddWithValue("@Billno", BillNo.Text.Trim());
                cmd.Parameters.AddWithValue("@SKT", listvalue);
                cmd.Parameters.AddWithValue("@CollectionType", ctypevalue);
                cmd.Parameters.AddWithValue("@HQ", HQ.Text.Trim());              
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 300);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                sda.SelectCommand = cmd;

                using (Collectionreport dsCustomers = new Collectionreport())
                {
                    sda.Fill(dsCustomers, "collectionreport");
                    lblstatus.Text = cmd.Parameters["@message"].Value.ToString();
                    return dsCustomers;
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Collectionreport.rdlc");
        Collectionreport dsCustomers = GetData();
        ReportDataSource datasource = new ReportDataSource("Collectionreport", dsCustomers.Tables[0]);
        ReportParameter rp = new ReportParameter("Startdate", txtfrmdate.Text.ToString());
        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
        ReportParameter rp1 = new ReportParameter("Enddate", txttodate.Text.ToString());
        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1 });
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(datasource);
    }
}