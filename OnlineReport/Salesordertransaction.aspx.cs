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

public partial class OnlineReport_Salesordertransaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private salesordertransaction GetData()
    {
        string listvalue = "";
        foreach (ListItem item in SKT.Items)
        {
            if (item.Selected)
            {
                listvalue += item.Value + ",";
            }
        }
        string Productvalue = "";
        foreach (ListItem item1 in PPS.Items)
        {
            if (item1.Selected)
            {
                Productvalue += item1.Value + ",";
            }
        }
        string customertypevalue = "";
        foreach (ListItem item2 in customertype.Items)
        {
            if (item2.Selected)
            {
                customertypevalue += item2.Value + ",";
            }
        }
        string ORSvalue = "";
        foreach (ListItem item3 in OrderStatus.Items)
        {
            if (item3.Selected)
            {
                ORSvalue += item3.Value + ",";
            }
        }
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        SqlCommand cmd = new SqlCommand("salesordertransactionAutomation");
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@startdate", txtfrmdate.Text.Trim());
                cmd.Parameters.AddWithValue("@endate", txttodate.Text.Trim());
                cmd.Parameters.AddWithValue("@customercode", Customercode.Text.Trim());
                cmd.Parameters.AddWithValue("@customertype", customertypevalue);
                cmd.Parameters.AddWithValue("@orderstatus", ORSvalue);
                cmd.Parameters.AddWithValue("@Billno", BillNo.Text.Trim());
                cmd.Parameters.AddWithValue("@SKT", listvalue);
                cmd.Parameters.AddWithValue("@HQ", HQ.Text.Trim());
                cmd.Parameters.AddWithValue("@pps", Productvalue);
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 300);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                sda.SelectCommand = cmd;

                using (salesordertransaction dsCustomers = new salesordertransaction())
                {
                    sda.Fill(dsCustomers, "Salesordertransaction");
                    lblstatus.Text = cmd.Parameters["@message"].Value.ToString();
                    return dsCustomers;
                }                
            }
        }
    }
protected void Button1_Click(object sender, EventArgs e)
{
    ReportViewer1.ProcessingMode = ProcessingMode.Local;
    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Salesordertransaction.rdlc");
    salesordertransaction dsCustomers = GetData();
    ReportDataSource datasource = new ReportDataSource("Salesordertransaction", dsCustomers.Tables[0]);
    ReportParameter rp = new ReportParameter("Startdate", txtfrmdate.Text.ToString());
    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
    ReportParameter rp1 = new ReportParameter("Enddate", txttodate.Text.ToString());
    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1 });
    ReportViewer1.LocalReport.DataSources.Clear();
    ReportViewer1.LocalReport.DataSources.Add(datasource);
}
}