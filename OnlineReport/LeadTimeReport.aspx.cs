using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using static ReportModel;

public partial class OnlineReport_LeadTimeReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateSearchDropdowns();

            //applyrole();
            //generate report
            LeadTime_Search repParamSearch = new LeadTime_Search();
            //repParamSearch.StartDate_PO = "mad";

            GenerateRDLCReport(repParamSearch);
        }
    }

    private void PopulateSearchDropdowns()
    {
        LeadTime_Dropdown objData = (new Report_DL()).GetDropdownData();
        lbPartyName.DataSource = objData.lst_PartyName;
        lbPartyName.DataBind();

        lbItemName.DataSource = objData.lst_StockItemName;
        lbItemName.DataBind();
    }

    private void GenerateRDLCReport(LeadTime_Search repParamSearch)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rdlcs/Report_LeadTime.rdlc");

        DataSet dt = (new Report_DL()).GetLeadTimeReportData(repParamSearch);
        if (dt != null)
        {
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
            {
                Name = "dsLeadTime",
                Value = dt.Tables[0]
            });
            ReportViewer1.LocalReport.Refresh();
        }

    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //--- Multi Select List Box Values --
        string strPartyName = string.Empty;
        foreach (ListItem item in lbPartyName.Items)
        {
            if (item.Selected)
            {
                strPartyName += "'" + item.Text + "'";
                strPartyName += ",";
            }
        }
        //--- Multi Select List Box Values --
        string strItemName = string.Empty;
        foreach (ListItem item in lbItemName.Items)
        {
            if (item.Selected)
            {
                strItemName += "'" + item.Text + "'";
                strItemName += ",";
            }
        }

        LeadTime_Search repParamSearch = new LeadTime_Search();
        if (lbPartyName.SelectedIndex > 0)
        {
            repParamSearch.PartyName = strPartyName.Remove(strPartyName.Length - 1, 1);// Remove last ,

        }

        if (lbItemName.SelectedIndex > 0)
        {
            repParamSearch.ItemName = strItemName.Remove(strItemName.Length - 1, 1);// Remove last ,// lbItemName.SelectedItem.Text;
        }
        //repParamSearch.ItemName = lbItemName.SelectedItem.Text;

        repParamSearch.StartDate_PO = Page.Request.Form["_dtFromDate_PO"].ToString();
        repParamSearch.EndtDate_PO = Page.Request.Form["_dtToDate_PO"].ToString();

        repParamSearch.StartDate_GRN = Page.Request.Form["_dtFromDate_GRN"].ToString();
        repParamSearch.EndtDate_GRN = Page.Request.Form["_dtToDate_GRN"].ToString();

        repParamSearch.StartDate_Invoice = Page.Request.Form["_dtFromDate_Invoice"].ToString();
        repParamSearch.EndtDate_Invoice = Page.Request.Form["_dtToDate_Invoice"].ToString();

        bool blncontinue = true;

        if (blncontinue)
        {
            GenerateRDLCReport(repParamSearch);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        LeadTime_Search repParamSearch = new LeadTime_Search();

        GenerateRDLCReport(repParamSearch);
        string PODateFrom = Request.Form["dtFromDate_PO"];

        lbItemName.SelectedIndex = -1;
        lbPartyName.SelectedIndex = -1;
        //--- Set Current Date in Date Fileds Input Box

        lblmsg.Text = "";
    }

    protected void btnExporttoCSV_Click(object sender, EventArgs e)
    {
        ExportCSVReport();
    }

    protected void ExportCSVReport()
    {
        ReportDataSource ds = ReportViewer1.LocalReport.DataSources["dsLeadTime"];
        DataTable dt = (DataTable)ds.Value;

        StringBuilder sb = new StringBuilder();
        foreach (DataRow row in dt.Rows)
        {
            foreach (DataColumn column in dt.Columns)
            {
                sb.Append(row[column].ToString());
                sb.Append(",");
            }
            sb.AppendLine("\t");
        }


        Response.Clear();
        Response.ContentType = "text/csv";
        Response.AddHeader("content-disposition", "attachment; filename=LeadTimeReport.csv");
        Response.Write(sb.ToString());
        Response.End();
    }

    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session["loggedrole"] = "";
        Response.Redirect("login.aspx");
    }
}