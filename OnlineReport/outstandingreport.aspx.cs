using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class OnlineReport_outstandingreport : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private outstandingamount GetData()
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
        foreach (ListItem item1 in NPANONNPA.Items)
        {
            if (item1.Selected)
            {
                Productvalue += item1.Value + ",";
            }
        }
        string Returntypevalue = "";
        foreach (ListItem item2 in Division.Items)
        {
            if (item2.Selected)
            {
                Returntypevalue += item2.Value + ",";
            }
        }
        string partytypevalue = "";
        foreach (ListItem item3 in partytype.Items)
        {
            if (item3.Selected)
            {
                partytypevalue += item3.Value + ",";
            }
        }
        string statusvalue = "";
        foreach (ListItem item4 in status.Items)
        {
            if (item4.Selected)
            {
                statusvalue += item4.Value + ",";
            }
        }
        string HQvalue = "";
        foreach (ListItem item5 in HQ.Items)
        {
            if (item5.Selected)
            {
                HQvalue += item5.Value + ",";
            }
        }

        string ZSMvalue = "";
        foreach (ListItem item6 in ZSM.Items)
        {
            if (item6.Selected)
            {
                ZSMvalue += item6.Value + ",";
            }
        }

        string RSMvalue = "";
        foreach (ListItem item7 in RSM.Items)
        {
            if (item7.Selected)
            {
                RSMvalue += item7.Value + ",";
            }
        }

        string DSOvalue = "";
        foreach (ListItem item8 in DSO.Items)
        {
            if (item8.Selected)
            {
                DSOvalue += item8.Value + ",";
            }
        }

        string REFERBYvalue = "";
        foreach (ListItem item9 in ReferBy.Items)
        {
            if (item9.Selected)
            {
                REFERBYvalue += item9.Value + ",";
            }
        }
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        SqlCommand cmd = new SqlCommand("outstandingautomationafterprocess");
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
                cmd.Parameters.AddWithValue("@HQ", HQvalue);
                cmd.Parameters.AddWithValue("@ZSM", ZSMvalue);
                cmd.Parameters.AddWithValue("@RSM", RSMvalue);
                cmd.Parameters.AddWithValue("@DSO", DSOvalue);
                cmd.Parameters.AddWithValue("@REFERBY", REFERBYvalue);
                cmd.Parameters.AddWithValue("@NPANONNPA", Productvalue);
                cmd.Parameters.AddWithValue("@division", Returntypevalue);
                cmd.Parameters.AddWithValue("@partytype", partytypevalue);
                cmd.Parameters.AddWithValue("@status", statusvalue);
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 300);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                sda.SelectCommand = cmd;

                using (outstandingamount dsCustomers = new outstandingamount())
                {
                    sda.Fill(dsCustomers, "outstandingamount");
                    lblmsg.Text = cmd.Parameters["@message"].Value.ToString();
                    return dsCustomers;
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/outstandingamount.rdlc");
        outstandingamount dsCustomers = GetData();
        ReportDataSource datasource = new ReportDataSource("outstandingamount", dsCustomers.Tables[0]);
        //ReportParameter rp = new ReportParameter("Startdate", txtfrmdate.Text.ToString());
        //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
        //ReportParameter rp1 = new ReportParameter("Enddate", txttodate.Text.ToString());
        //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1 });
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(datasource);
    }
}