using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class demo_UserControl_report_viewer : System.Web.UI.UserControl
{

    public String ReportName { get; set; }
    public String ReportTitle { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    /// <summary>
    /// Bind Report With DataTable
    /// </summary>
    /// <param name="dt">DataTable</param>
    public void DataBind(DataTable dt)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        DataBind(ds);
    }

    /// <summary>
    /// Bind Report With DataSet
    /// </summary>
    /// <param name="ds">DataSet</param>
    public void DataBind(DataSet ds)
    {

        int count = 0;
        foreach (DataTable dt in ds.Tables)
        {
            count++;
            var report_name = "Report" + count;
            DataTable dt1 = new DataTable(report_name.ToString());
            dt1 = ds.Tables[count - 1];
            dt1.TableName = report_name.ToString();
        }


        //Report Viewer, Builder and Engine 
        ReportViewer1.Reset();
        for (int i = 0; i < ds.Tables.Count; i++)
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(ds.Tables[i].TableName, ds.Tables[i]));

        ReportBuilder reportBuilder = new ReportBuilder();
        reportBuilder.DataSource = ds;
        
        reportBuilder.Page = new ReportPage();
        ReportSections reportFooter = new ReportSections();
        ReportItems reportFooterItems = new ReportItems();
        ReportTextBoxControl[] footerTxt = new ReportTextBoxControl[3];
        //string footer = string.Format("Copyright {0}         Report Generated On {1}          Page {2}", DateTime.Now.Year, DateTime.Now, ReportGlobalParameters.CurrentPageNumber);
        string footer = string.Format("Copyright  {0}         Report Generated On  {1}          Page  {2}  of {3} ", DateTime.Now.Year, DateTime.Now, ReportGlobalParameters.CurrentPageNumber, ReportGlobalParameters.TotalPages); 
        footerTxt[0] = new ReportTextBoxControl() { Name = "txtCopyright", ValueOrExpression = new string[] { footer } };
    
       

        reportFooterItems.TextBoxControls = footerTxt;
        reportFooter.ReportControlItems = reportFooterItems;
        reportBuilder.Page.ReportFooter = reportFooter;

        ReportSections reportHeader = new ReportSections();
        reportHeader.Size = new ReportScale();
        reportHeader.Size.Height = 0.56849;

        ReportItems reportHeaderItems = new ReportItems();
        
        ReportTextBoxControl[] headerTxt = new ReportTextBoxControl[1];
        headerTxt[0] = new ReportTextBoxControl() { Name = "txtReportTitle", ValueOrExpression = new string[] { "Report Name: "+ReportTitle } };


        reportHeaderItems.TextBoxControls = headerTxt;
        reportHeader.ReportControlItems = reportHeaderItems;
        reportBuilder.Page.ReportHeader = reportHeader;
        
        ReportViewer1.LocalReport.LoadReportDefinition(ReportEngine.GenerateReport(reportBuilder));
        ReportViewer1.LocalReport.DisplayName = ReportName;
       
    }


}