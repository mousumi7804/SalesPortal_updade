using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



    public class ReportModel
    {
        #region -- Lead Time Report --
        public class LeadTime_Dropdown
        {
            public List<String> lst_PartyName { get; set; }
            public List<String> lst_StockItemName { get; set; }
        }

        public class LeadTime_Search
        {
            public string StartDate_PO { get; set; }
            public string EndtDate_PO { get; set; }
            public string PartyName { get; set; }
            public string ItemName { get; set; }
            public string StartDate_GRN { get; set; }
            public string EndtDate_GRN { get; set; }
            public string StartDate_Invoice { get; set; }
            public string EndtDate_Invoice { get; set; }
        }

        public class LeadTime_Report
        {
            public string PODate { get; set; }
            public string PartyName { get; set; }
            public string StoreItemName { get; set; }
            public string POQTY { get; set; }
            public string PORate { get; set; }
            public string POUOM { get; set; }
            public string POAmount { get; set; }
            public string GRNDate { get; set; }
            public string GRNReference { get; set; }
            public string GRNQuantity { get; set; }
            public string GRNRate { get; set; }
            public string GRNUOM { get; set; }
            public string GRNAmount { get; set; }
            public string InvoiceDate { get; set; }
            public string InvoiceReference { get; set; }
            public string InvoiceActualQuantity { get; set; }
            public string InvoiceRate { get; set; }
            public string InvoiceRateUOM { get; set; }
            public string InvoiceAmount { get; set; }
        }

        public class LeadTime_Report_List : List<LeadTime_Report>
        {

        }
        #endregion

        #region -- Final Product Stock Report --
        public class FinalProductStock_Dropdown
        {
            public List<String> lst_Company { get; set; }
            public List<String> lst_StockItemName { get; set; }
            public List<String> lst_GodownName { get; set; }
            public List<String> lst_StockGroup { get; set; }
        }
        public class FinalProductStock_Search
        {
            public string Company { get; set; }
            public string ItemName { get; set; }
            public string GodownName { get; set; }
            public string StockGroup { get; set; }
            public string StartDate_StockDate { get; set; }
            public string EndDate_StockDate { get; set; }
        }

        public class FinalProductStock_Report
        {
            public string CompanyID { get; set; }
            public string StockDate { get; set; }
            public string StockItemName { get; set; }
            public string GodownName { get; set; }
            public string BatchName { get; set; }
            public string Quantity { get; set; }
            public string UOM { get; set; }
            public string Rate { get; set; }
            public string Amount { get; set; }
            public string StockGroup { get; set; }
        }

        public class FinalProductStock_Report_List : List<FinalProductStock_Report>
        {

        }

        #endregion
    }
