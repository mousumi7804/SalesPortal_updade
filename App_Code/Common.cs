using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ReportRDLC.models
{
    public class Common
    {
        public static SqlConnection conn;
        public static string[] monthlist = new string[] { "Select", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public static void OpenConnection()
        {
            try
            {
                String strconn = ConfigurationManager.ConnectionStrings["MendineMasterdummyConnectionString"].ConnectionString;
                conn = new SqlConnection(strconn);
                conn.Open();
            }
            catch(Exception ex)
            { 
            }
        }

        public static void CloseConnection()
        {
            conn.Close();
        }

        public static int GetPositionof(string value)
        {
            int ret = 0;

            ret = Array.FindIndex(monthlist, m => m == value);

            return ret;
        }

        public static int GetInt(object value)
        {
            int retVal = 0;
            string val = Convert.ToString(value);

            if (val != null && val != "")
            {
                bool found = false;
                for (int i = 0; i < val.Length && (!found); i++)
                {
                    char ch = val[i];
                    if (char.IsDigit(ch) == false)
                        found = true;
                }

                if (!found)
                    retVal = Convert.ToInt32(value);
            }

            return retVal;
        }

        public static string GetString(object value)
        {
            string retVal = "";
            if (value != null && value != "")
                retVal = Convert.ToString(value);

            return retVal;
        }

        public static bool GetBool(object value)
        {
            bool retValue = false;

            if (value != null && value != "")
            {
                try
                {
                    retValue = Convert.ToBoolean(value);
                }
                catch (Exception ex)
                {
                    retValue = false;
                }
            }
            return retValue;
        }

        public static string GetTrimmedString(string value)
        {
            string retval = "";

            if (value != null)
                retval = value.Trim();

            return retval;
        }
    }
}