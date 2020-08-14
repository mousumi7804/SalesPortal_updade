using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class RptAgeing
    {
        public int rptageingID { get; set; }
        public string month { get; set; }
        public string division { get; set; }
        public string ZsmHQ { get; set; }
        public string RsmHQ { get; set; }
        public string AsmHQ { get; set; }
        public string MfsoHQ { get; set; }
        public string Area { get; set; }
        public string AreaType { get; set; }
        public string EmployeeName { get; set; }
        public string Usertype { get; set; }
        public string ClientUid { get; set; }
        public string DoctorName { get; set; }
        public string Status { get; set; }
        public string Qualification { get; set; }
        public string Class { get; set; }
        public string Prescription1 { get; set; }
        public string PrescriptionDate1 { get; set; }
        public string NoofVisitRx1 { get; set; }
        public string Prescription2 { get; set; }
        public string PrescriptionDate2 { get; set; }
        public string NoofVisitRx2 { get; set; }
        public string Prescription3 { get; set; }
        public string PrescriptionDate3 { get; set; }
        public string NoofVisitRx3 { get; set; }
        public string Prescription4 { get; set; }
        public string PrescriptionDate4 { get; set; }
        public string NoofVisitRx4 { get; set; }
        public string Promotion1 { get; set; }
        public string PromitionDate1 { get; set; }
        public int NoofVisitPromo1 { get; set; }
        public string Promotion2 { get; set; }
        public string PromitionDate2 { get; set; }
        public int NoofVisitPromo2 { get; set; }
        public string Promotion3 { get; set; }
        public string PromitionDate3 { get; set; }
        public int NoofVisitPromo3 { get; set; }
        public string Promotion4 { get; set; }
        public string PromitionDate4 { get; set; }
        public int NoofVisitPromo4 { get; set; }
        public string MfsoVisitPlan { get; set; }
        public string MfsoVisitDays { get; set; }
        public string AsmVisitPlan { get; set; }
        public string AsmVisitDays { get; set; }
        public string RsmVisitPlan { get; set; }
        public string RsmVisitDays { get; set; }
        public string ZsmVisitPlan { get; set; }
        public string ZsmVisitDays { get; set; }
        public string ManagerRemark { get; set; }
        public string MsrRemark { get; set; }
    }

    public class RptAgeingList: List<RptAgeing>
    {

    }

    public class StaticData
    {
        public List<String> lstrsm { get; set; }
        public List<String> lstasm { get; set; }
        public List<String> lstarea { get; set; }
        public List<String> lstdoctor { get; set; }
        public List<String> lstmsr { get; set; }

    }
