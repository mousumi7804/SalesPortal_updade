using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Services;

/// <summary>
/// Summary description for GetInvoiceWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class GetcustomerWebService : System.Web.Services.WebService
{

    //public GetInvoiceWebService () {

    //    //Uncomment the following line if using designed components 
    //    //InitializeComponent(); 
    //}

    //[WebMethod]
    //public string HelloWorld() {
    //    return "Hello World";
    //}
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] Getcustomer(string searchTerm)
    {
        List<string> invoice = new List<string>();
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("proccustomersearch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@customer", searchTerm);
            cmd.Parameters.Add(parameter);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                //interviewerName.Add(rdr["empName"].ToString());
                //interviewerName.Add(rdr["empName"].ToString());
               // interviewerName.Add(string.Format("{0}-{1}", rdr["empName"], rdr["empCode"].ToString()));
                invoice.Add(string.Format("{0}", rdr["customer"].ToString()));
            }
        }

        return invoice.ToArray();
        
    }
    
}
