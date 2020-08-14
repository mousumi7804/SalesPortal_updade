using ReportRDLC.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


    public class RptAgeingDL
    {
        public MendineMasterdummyDataSet GetAgeingReportData(SearchAgeing itmsearch)
        {
            RptAgeingList lstAgeing = new RptAgeingList();
            Common.OpenConnection();
            String sql = "select * from rpt_ageing";
            string whsql = "";
            string strconcat = "";
            if (itmsearch.rsm != null && itmsearch.rsm != "" && itmsearch.rsm != "select")
            {
                whsql = whsql + strconcat + " RSMHQ like '%" + itmsearch.rsm + "%'";
                strconcat = " and ";
            }
            if (itmsearch.asm != null && itmsearch.asm != "" && itmsearch.asm != "select")
            {
                whsql = whsql + strconcat + " ASMHQ like '%" + itmsearch.asm + "%'";
                strconcat = " and ";
            }
            if (itmsearch.msr != null && itmsearch.msr != "" && itmsearch.msr != "select")
            {
                whsql = whsql + strconcat + " MSRHQ like '%" + itmsearch.msr + "%'";
                strconcat = " and ";
            }
            if (itmsearch.area != null && itmsearch.area != "" && itmsearch.area != "select")
            {
                whsql = whsql + strconcat + " Area like '%" + itmsearch.area + "%'";
                strconcat = " and ";
            }
            if (itmsearch.doctor != null && itmsearch.doctor != "" && itmsearch.doctor != "select")
            {
                whsql = whsql + strconcat + " DoctorName like '%" + itmsearch.doctor + "%'";
                strconcat = " and ";
            }

            if(itmsearch.intFrom>0 && itmsearch.intTo > 0)
            {
                string months = "";
                string separator = "";
                int count = itmsearch.intFrom;
                while (count <= itmsearch.intTo)
                {
                    months = months + separator + "'" + Common.monthlist.ElementAt(count) + "'";
                    separator = ",";
                    count++;
                }

                whsql = whsql + strconcat + " month in (" + months + ")";
            }

            if (whsql != null && whsql != "")
                sql = sql + " where " + whsql;

            SqlCommand cmd = new SqlCommand(sql, Common.conn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //return dt;

            MendineMasterdummyDataSet dsCustomers = new MendineMasterdummyDataSet();
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                sda.SelectCommand = cmd;
                sda.Fill(dsCustomers, "rpt_ageing");
            }

            return dsCustomers;



            //using (SqlDataReader rdr = cmd.ExecuteReader())
            //{
            //    while (rdr.Read())
            //    {
            //        RptAgeing itmaging = new RptAgeing();
            //        itmaging.ZsmHQ = Common.GetString(rdr["ZsmHQ"]);
            //        itmaging.Area = Common.GetString(rdr["Area"]);
            //        itmaging.AreaType = Common.GetString(rdr["AreaType"]);
            //        itmaging.DoctorName = Common.GetString(rdr["DoctorName"]);
            //        lstAgeing.Add(itmaging);
            //    }
            //}



        }

        public StaticData GetDropdownData()
        {
            StaticData itmstaticdata = new StaticData();
            itmstaticdata.lstrsm = new List<string>();
            itmstaticdata.lstrsm.Add("select");
            itmstaticdata.lstasm = new List<string>();
            itmstaticdata.lstasm.Add("select");
            itmstaticdata.lstarea = new List<string>();
            itmstaticdata.lstarea.Add("select");
            itmstaticdata.lstdoctor = new List<string>();
            itmstaticdata.lstdoctor.Add("select");
            itmstaticdata.lstmsr = new List<string>();
            itmstaticdata.lstmsr.Add("select");

            Common.OpenConnection();
            try
            {
                String sql = "select distinct RsmHQ from rpt_ageing";
                SqlCommand cmd = new SqlCommand(sql, Common.conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstrsm.Add(Common.GetString(rdr["RsmHQ"]));
                }
                rdr.Close();

                sql = "select distinct AsmHQ from rpt_ageing";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstasm.Add(Common.GetString(rdr["AsmHQ"]));
                }
                rdr.Close();

                sql = "select distinct MsrHQ from rpt_ageing";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstmsr.Add(Common.GetString(rdr["MsrHQ"]));
                }
                rdr.Close();

                sql = "select distinct Area from rpt_ageing";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstarea.Add(Common.GetString(rdr["Area"]));
                }
                rdr.Close();

                sql = "select distinct DoctorName from rpt_ageing";
                cmd = new SqlCommand(sql, Common.conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    itmstaticdata.lstdoctor.Add(Common.GetString(rdr["DoctorName"]));
                }
                rdr.Close();
            }
            catch(Exception ex)
            {

            }

            Common.CloseConnection();

            return itmstaticdata;
        }


        public void populateReportFromSP(string div,string mont)
        {
            bool executesp = true;
            Common.OpenConnection();

            string sql = "select count(*) as cnt from rpt_ageing where division='" + div + "' and month='" + mont + "'";
            SqlCommand cmd = new SqlCommand(sql, Common.conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                int tot = Common.GetInt(rdr["cnt"]);
                if (tot > 0)
                    executesp = false;
            }
            rdr.Close();

            if (executesp)
            {
                cmd = new SqlCommand("ageingreport", Common.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@divisin", div);
                cmd.Parameters.AddWithValue("@month", mont);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //foreach (DataRow dr in dt.Rows)
                    //{
                        ////if (div.ToUpper() == "OTX")
                        ////{
                        ////    using (SqlCommand cmd1 = new SqlCommand("SaveReportFromDT"))
                        ////    {
                        ////        cmd1.CommandType = CommandType.StoredProcedure;
                        ////        cmd1.Connection = Common.conn;
                        ////        cmd1.Parameters.AddWithValue("@tblotx", dt);
                        ////        cmd1.Parameters.AddWithValue("@tblmad", new DataTable());
                        ////        cmd1.Parameters.AddWithValue("@tblmfso", new DataTable());
                        ////        cmd1.Parameters.AddWithValue("@div", div);
                        ////        cmd1.Parameters.AddWithValue("@mn", mont);
                        ////        cmd1.ExecuteNonQuery();

                        ////    }


                            //sql = "insert into rpt_ageing(month,division,ZsmHQ,RsmHQ,AsmHQ,MfsoHQ,Area,AreaType,EmployeeName,Usertype,ClientUid," +
                            //            "DoctorName,Status,Qualification,Speciality,Class,Prescription1,PrescriptionDate1,NoofVisitRx1,Prescription2," +
                            //            "PrescriptionDate2,NoofVisitRx2,Prescription3,PrescriptionDate3,NoofVisitRx3,Prescription4,PrescriptionDate4,NoofVisitRx4," +
                            //            "Promotion1,PromitionDate1,NoofVisitPromo1,Promotion2,PromitionDate2,NoofVisitPromo2,Promotion3,PromitionDate3,NoofVisitPromo3," +
                            //            "Promotion4,PromitionDate4,NoofVisitPromo4,MfsoVisitPlan,MfsoVisitDays,AsmVisitPlan,AsmVisitDays,RsmVisitPlan,RsmVisitDays," +
                            //            "ZsmVisitPlan,ZsmVisitDays) values(" +
                            //            "'"+mont+"','"+div+"','" + dr["ZsmHQ"] + "','" + dr["RsmHQ"] + "','" + "NA" + "','" + "NA" + "','" + dr["Area"] + "','" +
                            //            dr["AreaType"] + "','" + dr["Employee Name"] + "','" + dr["Usertype"] + "','" + dr["ClientUid"] + "','" + dr["DoctorName"] + "','" +
                            //            "NA" + "','" + dr["Qualification"] + "','" + dr["Speciality"] + "','" + dr["Class"] + "','" + dr["Prescription1"] + "','" +
                            //            dr["PrescriptionDate1"] + "'," + Common.GetInt(dr["NoofVisitRx1"]) + ",'" + dr["Prescription2"] + "','" + dr["PrescriptionDate2"] + "'," + Common.GetInt(dr["NoofVisitRx2"]) + ",'" +
                            //            dr["Prescription3"] + "','" + dr["PrescriptionDate3"] + "'," + Common.GetInt(dr["NoofVisitRx3"]) + ",'" + dr["Prescription4"] + "','" + dr["PrescriptionDate4"] + "'," +
                            //            Common.GetInt(dr["NoofVisitRx4"]) + ",'" + dr["Promotion1"] + "','" + dr["PromotionDate1"] + "'," + Common.GetInt(dr["NoofVisitPromo1"]) + ",'" + dr["Promotion2"] + "','" +
                            //            dr["PromotionDate2"] + "'," + Common.GetInt(dr["NoofVisitPromo2"]) + ",'" + dr["Promotion3"] + "','" + dr["PromotionDate3"] + "'," + Common.GetInt(dr["NoofVisitPromo3"]) + ",'" +
                            //            dr["Promotion4"] + "','" + dr["PromotionDate4"] + "'," + Common.GetInt(dr["NoofVisitPromo4"]) + ",'" + "NA" + "'," + "0" + ",'" +
                            //            dr["Asm Visit Plan"] + "','" + Common.GetInt(dr["Asm Visit Days"]) + "','" + dr["Rsm Visit Plan"] + "','" + Common.GetInt(dr["Rsm Visit Days"]) + "','" +
                            //            dr["Zsm Visit Plan"] + "','" + Common.GetInt(dr["Zsm Visit Days"]) + "'" +
                            //            ")";
                        ////}
                        ////else if (div.ToUpper() == "MAD")
                        ////{

                            using (SqlCommand cmd1 = new SqlCommand("SaveReportFromDT"))
                            {
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.Connection = Common.conn;
                              //  cmd1.Parameters.AddWithValue("@tblotx", dt);
                                cmd1.Parameters.AddWithValue("@tblmad", dt);
                               // cmd1.Parameters.AddWithValue("@tblmfso", dt);
                                cmd1.Parameters.AddWithValue("@div", div);
                                cmd1.Parameters.AddWithValue("@mn", mont);
                                cmd1.ExecuteNonQuery();

                            }


                            //sql = "insert into rpt_ageing(month,division,ZsmHQ,RsmHQ,DsoHQ,MsrHQ,Area,AreaType,EmployeeName,Usertype,ClientUid," +
                            //            "DoctorName,Status,Qualification,Speciality,Class,Prescription1,PrescriptionDate1,NoofVisitRx1,Prescription2," +
                            //            "PrescriptionDate2,NoofVisitRx2,Prescription3,PrescriptionDate3,NoofVisitRx3,Prescription4,PrescriptionDate4,NoofVisitRx4," +
                            //            "Promotion1,PromitionDate1,NoofVisitPromo1,Promotion2,PromitionDate2,NoofVisitPromo2,Promotion3,PromitionDate3,NoofVisitPromo3," +
                            //            "Promotion4,PromitionDate4,NoofVisitPromo4,DsoVisitPlan,DsoVisitDays,EmsrVisitPlan,EmsrVisitDays,MsrVisitPlan,MsrVisitDays," +
                            //            "RsmVisitPlan,RsmVisitDays,ZsmVisitPlan,ZsmVisitDays) values(" +
                            //            "'"+mont+"','"+div+"','" + dr["ZsmHQ"] + "','" + dr["RsmHQ"] + "','" + dr["DsoHQ"] + "','" + dr["MsrHQ"] + "','" + dr["Area"] + "','" +
                            //            dr["AreaType"] + "','" + dr["Employee Name"] + "','" + dr["Usertype"] + "','" + dr["ClientUid"] + "','" + dr["DoctorName"] + "','" +
                            //            "NA" + "','" + dr["Qualification"] + "','" + dr["Speciality"] + "','" + dr["Class"] + "','" + dr["Prescription1"] + "','" +
                            //            dr["PrescriptionDate1"] + "'," + Common.GetInt(dr["NoofVisitRx1"]) + ",'" + dr["Prescription2"] + "','" + dr["PrescriptionDate2"] + "'," + Common.GetInt(dr["NoofVisitRx2"]) + ",'" +
                            //            dr["Prescription3"] + "','" + dr["PrescriptionDate3"] + "'," + Common.GetInt(dr["NoofVisitRx3"]) + ",'" + dr["Prescription4"] + "','" + dr["PrescriptionDate4"] + "'," +
                            //            Common.GetInt(dr["NoofVisitRx4"]) + ",'" + dr["Promotion1"] + "','" + dr["PromotionDate1"] + "'," + Common.GetInt(dr["NoofVisitPromo1"]) + ",'" + dr["Promotion2"] + "','" +
                            //            dr["PromotionDate2"] + "'," + Common.GetInt(dr["NoofVisitPromo2"]) + ",'" + dr["Promotion3"] + "','" + dr["PromotionDate3"] + "'," + Common.GetInt(dr["NoofVisitPromo3"]) + ",'" +
                            //            dr["Promotion4"] + "','" + dr["PromotionDate4"] + "'," + Common.GetInt(dr["NoofVisitPromo4"]) + ",'" + dr["Dso Visit Plan"] + "','" + dr["Dso Visit Days"] + "','" +
                            //            dr["Emsr Visit Plan"] + "','" + dr["Emsr Visit Days"] + "','" +
                            //            dr["Msr Visit Plan"] + "','" + Common.GetInt(dr["Msr Visit Days"]) + "','" + dr["Rsm Visit Plan"] + "','" + Common.GetInt(dr["Rsm Visit Days"]) + "','" +
                            //            dr["Zsm Visit Plan"] + "','" + Common.GetInt(dr["Zsm Visit Days"]) + "'" +
                            //            ")";
                        ////}
                        ////else if (div.ToUpper() == "MFSO")
                        ////{

                        ////    using (SqlCommand cmd1 = new SqlCommand("SaveReportFromDT"))
                        ////    {
                        ////        cmd1.CommandType = CommandType.StoredProcedure;
                        ////        cmd1.Connection = Common.conn;
                        ////        cmd1.Parameters.AddWithValue("@tblotx", new DataTable());
                        ////        cmd1.Parameters.AddWithValue("@tblmad", new DataTable());
                        ////        cmd1.Parameters.AddWithValue("@tblmfso", dt);
                        ////        cmd1.Parameters.AddWithValue("@div", div);
                        ////        cmd1.Parameters.AddWithValue("@mn", mont);
                        ////        cmd1.ExecuteNonQuery();

                        ////    }

                            //sql = "insert into rpt_ageing(month,division,ZsmHQ,RsmHQ,DsoHQ,MsrHQ,Area,AreaType,EmployeeName,Usertype,ClientUid," +
                            //            "DoctorName,Status,Qualification,Speciality,Class,Prescription1,PrescriptionDate1,NoofVisitRx1,Prescription2," +
                            //            "PrescriptionDate2,NoofVisitRx2,Prescription3,PrescriptionDate3,NoofVisitRx3,Prescription4,PrescriptionDate4,NoofVisitRx4," +
                            //            "Promotion1,PromitionDate1,NoofVisitPromo1,Promotion2,PromitionDate2,NoofVisitPromo2,Promotion3,PromitionDate3,NoofVisitPromo3," +
                            //            "Promotion4,PromitionDate4,NoofVisitPromo4,AsmVisitPlan,AsmVisitDays,SmVisitPlan,SmVisitDays,MfsoVisitPlan,MfsoVisitDays," +
                            //            "RsmVisitPlan,RsmVisitDays,ZsmVisitPlan,ZsmVisitDays) values(" +
                            //            "'"+mont+"','"+div+"','" + dr["ZsmHQ"] + "','" + dr["RsmHQ"] + "','" + dr["DsoHQ"] + "','" + dr["MsrHQ"] + "','" + dr["Area"] + "','" +
                            //            dr["AreaType"] + "','" + dr["Employee Name"] + "','" + dr["Usertype"] + "','" + dr["ClientUid"] + "','" + dr["DoctorName"] + "','" +
                            //            "NA" + "','" + dr["Qualification"] + "','" + dr["Speciality"] + "','" + dr["Class"] + "','" + dr["Prescription1"] + "','" +
                            //            dr["PrescriptionDate1"] + "'," + Common.GetInt(dr["NoofVisitRx1"]) + ",'" + dr["Prescription2"] + "','" + dr["PrescriptionDate2"] + "'," + Common.GetInt(dr["NoofVisitRx2"]) + ",'" +
                            //            dr["Prescription3"] + "','" + dr["PrescriptionDate3"] + "'," + Common.GetInt(dr["NoofVisitRx3"]) + ",'" + dr["Prescription4"] + "','" + dr["PrescriptionDate4"] + "'," +
                            //            Common.GetInt(dr["NoofVisitRx4"]) + ",'" + dr["Promotion1"] + "','" + dr["PromotionDate1"] + "'," + Common.GetInt(dr["NoofVisitPromo1"]) + ",'" + dr["Promotion2"] + "','" +
                            //            dr["PromotionDate2"] + "'," + Common.GetInt(dr["NoofVisitPromo2"]) + ",'" + dr["Promotion3"] + "','" + dr["PromotionDate3"] + "'," + Common.GetInt(dr["NoofVisitPromo3"]) + ",'" +
                            //            dr["Promotion4"] + "','" + dr["PromotionDate4"] + "'," + Common.GetInt(dr["NoofVisitPromo4"]) + ",'" + dr["Asm Visit Plan"] + "','" + dr["Asm Visit Days"] + "','" +
                            //            dr["Sm Visit Plan"] + "','" + dr["Sm Visit Days"] + "','" +
                            //            dr["Mfso Visit Plan"] + "','" + Common.GetInt(dr["Mfso Visit Days"]) + "','" + dr["Rsm Visit Plan"] + "','" + Common.GetInt(dr["Rsm Visit Days"]) + "','" +
                            //            dr["Zsm Visit Plan"] + "','" + Common.GetInt(dr["Zsm Visit Days"]) + "'" +
                            //            ")";
                        ////}

                        //cmd = new SqlCommand(sql, Common.conn);
                        //cmd.ExecuteNonQuery();
                    //}
                }
            }

            Common.CloseConnection();
        }



        public DataSet GetAgeingReportDataDynamic(SearchAgeing itmsearch)
        {
            RptAgeingList lstAgeing = new RptAgeingList();
            Common.OpenConnection();
            String sql = "select * from rpt_ageing";
            string whsql = "";
            string strconcat = "";
            if (itmsearch.rsm != null && itmsearch.rsm != "" && itmsearch.rsm != "select")
            {
                whsql = whsql + strconcat + " RSMHQ like '%" + itmsearch.rsm + "%'";
                strconcat = " and ";
            }
            if (itmsearch.asm != null && itmsearch.asm != "" && itmsearch.asm != "select")
            {
                whsql = whsql + strconcat + " ASMHQ like '%" + itmsearch.asm + "%'";
                strconcat = " and ";
            }
            if (itmsearch.msr != null && itmsearch.msr != "" && itmsearch.msr != "select")
            {
                whsql = whsql + strconcat + " MSRHQ like '%" + itmsearch.msr + "%'";
                strconcat = " and ";
            }
            if (itmsearch.area != null && itmsearch.area != "" && itmsearch.area != "select")
            {
                whsql = whsql + strconcat + " Area like '%" + itmsearch.area + "%'";
                strconcat = " and ";
            }
            if (itmsearch.doctor != null && itmsearch.doctor != "" && itmsearch.doctor != "select")
            {
                whsql = whsql + strconcat + " DoctorName like '%" + itmsearch.doctor + "%'";
                strconcat = " and ";
            }

            if (itmsearch.intFrom > 0 && itmsearch.intTo > 0)
            {
                string months = "";
                string separator = "";
                int count = itmsearch.intFrom;
                while (count <= itmsearch.intTo)
                {
                    months = months + separator + "'" + Common.monthlist.ElementAt(count) + "'";
                    separator = ",";
                    count++;
                }

                whsql = whsql + strconcat + " month in (" + months + ")";
            }

            if (whsql != null && whsql != "")
                sql = sql + " where " + whsql;

            SqlCommand cmd = new SqlCommand(sql, Common.conn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //return dt;

            //MendineMasterdummyDataSet dsCustomers = new MendineMasterdummyDataSet();
            DataSet dsCustomers = new DataSet();
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                sda.SelectCommand = cmd;
                sda.Fill(dsCustomers, "rpt_ageing");
            }

            return dsCustomers;



            //using (SqlDataReader rdr = cmd.ExecuteReader())
            //{
            //    while (rdr.Read())
            //    {
            //        RptAgeing itmaging = new RptAgeing();
            //        itmaging.ZsmHQ = Common.GetString(rdr["ZsmHQ"]);
            //        itmaging.Area = Common.GetString(rdr["Area"]);
            //        itmaging.AreaType = Common.GetString(rdr["AreaType"]);
            //        itmaging.DoctorName = Common.GetString(rdr["DoctorName"]);
            //        lstAgeing.Add(itmaging);
            //    }
            //}



        }
    }
