using ReportRDLC.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static ReportModel;
//using static ReportRDLC.models.ReportModel;


public class Report_DL
    {
        #region -- Lead Time Report --

        #region Bind Drop Down
        public LeadTime_Dropdown GetDropdownData()
        {
            LeadTime_Dropdown ddlData = new LeadTime_Dropdown();
            Common.OpenConnection();
            try
            {
                //--- Party Drop Down ----
                ddlData.lst_PartyName = new List<string>();
                ddlData.lst_PartyName.Add("select");

                String sql = "Select distinct PartyName from TD_Txn_VchHdr where Len(PartyName)>2 order by PartyName ";
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ddlData.lst_PartyName.Add(Common.GetString(rdr["PartyName"]));
                }
                rdr.Close();


                //--- lst_StockItemName Drop Down ----
                ddlData.lst_StockItemName = new List<string>();
                ddlData.lst_StockItemName.Add("select");
                sql = "select distinct StockItemName from TD_Txn_InvLine where Len(StockItemName)>2 order by StockItemName";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ddlData.lst_StockItemName.Add(Common.GetString(rdr["StockItemName"]));
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Common.CloseConnection();
            }

            return ddlData;
        }
        #endregion

        #region Get Report Search Data ---
        public DataSet GetLeadTimeReportData(LeadTime_Search repParamSearch)
        {
            try
            {
                LeadTime_Report_List lstLeadTimeReport = new LeadTime_Report_List();
                Common.OpenConnection();
                String strSQL = "select * from View_Report_LeadTime";
                string WhSQL = "";
                string strconcat = "";

                if (repParamSearch.PartyName != null && repParamSearch.PartyName != "" && repParamSearch.PartyName != "select")
                {
                    WhSQL = WhSQL + strconcat + "popartyname In (" + repParamSearch.PartyName + ")";
                    strconcat = " and ";
                }

                if (repParamSearch.ItemName != null && repParamSearch.ItemName != "" && repParamSearch.ItemName != "select")
                {
                    WhSQL = WhSQL + strconcat + "POStockItemName In (" + repParamSearch.ItemName + ")";
                    strconcat = " and ";
                }
                //--------------- PO Date -------------------
                if (repParamSearch.StartDate_PO != null && repParamSearch.StartDate_PO != "")
                {
                    WhSQL = WhSQL + strconcat + " PODate>='" + repParamSearch.StartDate_PO + "'";
                    strconcat = " and ";
                }
                if (repParamSearch.EndtDate_PO != null && repParamSearch.EndtDate_PO != "")
                {
                    WhSQL = WhSQL + strconcat + " PODate<='" + repParamSearch.EndtDate_PO + "'";
                    strconcat = " and ";
                }
                //--------------- GRN Date -------------------
                if (repParamSearch.StartDate_GRN != null && repParamSearch.StartDate_GRN != "")
                {
                    WhSQL = WhSQL + strconcat + " GRNDate>='" + repParamSearch.StartDate_GRN + "'";
                    strconcat = " and ";
                }
                if (repParamSearch.EndtDate_GRN != null && repParamSearch.EndtDate_GRN != "")
                {
                    WhSQL = WhSQL + strconcat + " GRNDate<='" + repParamSearch.EndtDate_GRN + "'";
                    strconcat = " and ";
                }
                //--------------- Invoice Date -------------------
                if (repParamSearch.StartDate_Invoice != null && repParamSearch.StartDate_Invoice != "")
                {
                    WhSQL = WhSQL + strconcat + " PurchaseDate>='" + repParamSearch.StartDate_Invoice + "'";
                    strconcat = " and ";
                }
                if (repParamSearch.EndtDate_Invoice != null && repParamSearch.EndtDate_Invoice != "")
                {
                    WhSQL = WhSQL + strconcat + " PurchaseDate<='" + repParamSearch.EndtDate_Invoice + "'";
                    strconcat = " and ";
                }

                if (WhSQL != null && WhSQL != "")
                    strSQL = strSQL + " where " + WhSQL;

                strSQL += " Order by podate, popartyname, POStockItemName";

                SqlCommand cmd = new SqlCommand(strSQL, Common.conn);
                DataSet dsLeadTime = new DataSet();
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = cmd;
                    sda.Fill(dsLeadTime, "rpt_LeadTime");
                }
                return dsLeadTime;
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }
        #endregion

        #endregion

        #region -- FinalProductStock --

        #region Bind Drop Down
        public FinalProductStock_Dropdown GetDropdownData_FinalProductStock()
        {
            FinalProductStock_Dropdown ddlData = new FinalProductStock_Dropdown();
            Common.OpenConnection();
            try
            {
                //--- Company Drop Down ----
                ddlData.lst_Company = new List<string>();
                ddlData.lst_Company.Add("select");

                String sql = "Select Distinct CompanyID from TD_Txn_StockDetails order by CompanyID";
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ddlData.lst_Company.Add(Common.GetString(rdr["CompanyID"]));
                }
                rdr.Close();


                //--- lst_StockItemName Drop Down ----
                ddlData.lst_StockItemName = new List<string>();
                ddlData.lst_StockItemName.Add("select");
                sql = "select distinct StockItemName from TD_Txn_InvLine where Len(StockItemName)>2 order by StockItemName";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ddlData.lst_StockItemName.Add(Common.GetString(rdr["StockItemName"]));
                }
                rdr.Close();

                //--- GodownName Drop Down ----
                ddlData.lst_GodownName = new List<string>();
                ddlData.lst_GodownName.Add("select");
                sql = "Select Distinct GodownName from TD_Txn_StockDetails order by GodownName";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ddlData.lst_GodownName.Add(Common.GetString(rdr["GodownName"]));
                }
                rdr.Close();

                //--- StockGroup Drop Down ----
                ddlData.lst_StockGroup = new List<string>();
                ddlData.lst_StockGroup.Add("select");
                sql = "Select Distinct StockGroup from TD_Mst_StockItem order by StockGroup";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ddlData.lst_StockGroup.Add(Common.GetString(rdr["StockGroup"]));
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Common.CloseConnection();
            }

            return ddlData;
        }
        #endregion

        #region Get Report Search Data ---
        public DataSet GetReportData_FinalProductStock(FinalProductStock_Search repParamSearch)
        {
            LeadTime_Report_List lstLeadTimeReport = new LeadTime_Report_List();
            Common.OpenConnection();
            String strSQL = "";

            strSQL += "SELECT Top(1000) sd.CompanyID, sd.StockDate, sd.StockItemName, sd.GodownName, sd.BatchName, sd.Quantity, sd.UOM, sd.Rate, sd.Amount * -1 AS amount, SI.StockGroup ";
            strSQL += "FROM     dbo.TD_Txn_StockDetails AS sd ";
            strSQL += "INNER JOIN dbo.TD_Mst_StockItem AS SI ON sd.CompanyID = SI.CompanyID AND sd.StockItemName = SI.StockItemName ";

            string WhSQL = "";
            string strconcat = "";

            if (repParamSearch.Company != null && repParamSearch.Company != "" && repParamSearch.Company != "select")
            {
                WhSQL = WhSQL + strconcat + " sd.CompanyID In (" + repParamSearch.Company + ")";
                strconcat = " and ";
            }

            if (repParamSearch.StockGroup != null && repParamSearch.StockGroup != "" && repParamSearch.StockGroup != "select")
            {
                WhSQL = WhSQL + strconcat + " SI.StockGroup In (" + repParamSearch.StockGroup + ")";
                strconcat = " and ";
            }

            if (repParamSearch.GodownName != null && repParamSearch.GodownName != "" && repParamSearch.GodownName != "select")
            {
                WhSQL = WhSQL + strconcat + " sd.GodownName In (" + repParamSearch.GodownName + ")";
                strconcat = " and ";
            }

            if (repParamSearch.StartDate_StockDate != null && repParamSearch.StartDate_StockDate != "")
            {
                WhSQL = WhSQL + strconcat + " sd.StockDate>='" + repParamSearch.StartDate_StockDate + "'";
                strconcat = " and ";
            }

            if (repParamSearch.EndDate_StockDate != null && repParamSearch.EndDate_StockDate != "")
            {
                WhSQL = WhSQL + strconcat + " sd.StockDate<='" + repParamSearch.EndDate_StockDate + "'";
                strconcat = " and ";
            }

            if (repParamSearch.ItemName != null && repParamSearch.ItemName != "" && repParamSearch.ItemName != "select")
            {
                WhSQL = WhSQL + strconcat + " sd.StockItemName In (" + repParamSearch.ItemName + ")";
                strconcat = " and ";
            }

            if (WhSQL != null && WhSQL != "")
                strSQL = strSQL + " where " + WhSQL;

            strSQL += " Order by CompanyID, StockDate, StockGroup, GodownName";

            SqlCommand cmd = new SqlCommand(strSQL, Common.conn);
            DataSet dsLeadTime = new DataSet();
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                sda.SelectCommand = cmd;
                sda.Fill(dsLeadTime, "rpt_LeadTime");
            }
            return dsLeadTime;
        }
        #endregion
        #endregion
    }
