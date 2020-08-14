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

public partial class OnlineReport_FinalProductStock : System.Web.UI.Page
{
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSearchDropdowns();
                //applyrole();
                //generate report
                FinalProductStock_Search repParamSearch = new FinalProductStock_Search();

                GenerateRDLCReport(repParamSearch);
            }
        }
        private void PopulateSearchDropdowns()
        {
            FinalProductStock_Dropdown objData = (new Report_DL()).GetDropdownData_FinalProductStock();
            lbCompany.DataSource = objData.lst_Company;
            lbCompany.DataBind();

            lbItemName.DataSource = objData.lst_StockItemName;
            lbItemName.DataBind();

            lbGodownName.DataSource = objData.lst_GodownName;
            lbGodownName.DataBind();

            lbStockGroup.DataSource = objData.lst_StockGroup;
            lbStockGroup.DataBind();
        }

        private void GenerateRDLCReport(FinalProductStock_Search repParamSearch)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rdlcs/Report_FinalProductStock.rdlc");

            DataSet dt = (new Report_DL()).GetReportData_FinalProductStock(repParamSearch);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
            {
                Name = "dsFinalProductStock",
                Value = dt.Tables[0]
            });

            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            FinalProductStock_Search repParamSearch = new FinalProductStock_Search();
            //--- Company:: Multi Select List Box Values --
            string strCompany = string.Empty;
            foreach (ListItem item in lbCompany.Items)
            {
                if (item.Selected)
                {
                    strCompany += "'" + item.Text + "'";
                    strCompany += ",";
                }
            }
            if (lbCompany.SelectedIndex != -1)
            {
                repParamSearch.Company = strCompany.Remove(strCompany.Length - 1, 1);// Remove last ,lbCompany.SelectedItem.Text;
            }

            //--- ItemName::  Multi Select List Box Values  ItemName--
            string strItemName = string.Empty;
            foreach (ListItem item in lbItemName.Items)
            {
                if (item.Selected)
                {
                    strItemName += "'" + item.Text + "'";
                    strItemName += ",";
                }
            }
            if (lbItemName.SelectedIndex != -1)
            {
                repParamSearch.ItemName = strItemName.Remove(strItemName.Length - 1, 1);// Remove last , lbItemName.SelectedItem.Text;
            }
            //--- GodownName:: Multi Select List Box Values  ItemName--
            string strGodownName = string.Empty;
            foreach (ListItem item in lbGodownName.Items)
            {
                if (item.Selected)
                {
                    strGodownName += "'" + item.Text + "'";
                    strGodownName += ",";
                }
            }
            if (lbGodownName.SelectedIndex != -1)
            {
                repParamSearch.GodownName = strGodownName.Remove(strGodownName.Length - 1, 1);// lbGodownName.SelectedItem.Text;
            }

            //--- StockGroup:: Multi Select List Box Values  ItemName--
            string strStockGroup = string.Empty;
            foreach (ListItem item in lbStockGroup.Items)
            {
                if (item.Selected)
                {
                    strStockGroup += "'" + item.Text + "'";
                    strStockGroup += ",";
                }
            }
            if (lbStockGroup.SelectedIndex != -1)
            {
                repParamSearch.StockGroup = strStockGroup.Remove(strStockGroup.Length - 1, 1);// lbStockGroup.SelectedItem.Text;
            }

            repParamSearch.StartDate_StockDate = Page.Request.Form["_dtFromDate_StockDate"].ToString();
            repParamSearch.EndDate_StockDate = Page.Request.Form["_dtToDate_StockDate"].ToString();

            bool blncontinue = true;

            if (blncontinue)
            {
                GenerateRDLCReport(repParamSearch);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            FinalProductStock_Search repParamSearch = new FinalProductStock_Search();

            GenerateRDLCReport(repParamSearch);
            string FromDate_StockDate = Request.Form["_dtFromDate_StockDate"];

            lbItemName.SelectedIndex = -1;
            lbCompany.SelectedIndex = -1;
            lbGodownName.SelectedIndex = -1;
            lbStockGroup.SelectedIndex = -1;
            //--- Set Current Date in Date Fileds Input Box

            lblmsg.Text = "";
        }

        protected void btnExporttoCSV_Click(object sender, EventArgs e)
        {
            ExportCSVReport();
        }

        protected void ExportCSVReport()
        {
            ReportDataSource ds = ReportViewer1.LocalReport.DataSources["dsFinalProductStock"];
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
            Response.AddHeader("content-disposition", "attachment; filename=FinalProductStockReport.csv");
            Response.Write(sb.ToString());
            Response.End();
        }
    }
