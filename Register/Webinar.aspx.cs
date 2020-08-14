using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Drawing;
using AjaxControlToolkit;
using System.Web.Services;
using System.Web.Script.Services;
using System.Net.Mail;
using System.EnterpriseServices;

public partial class Webinar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (!Page.IsPostBack)
        {

            txtfname.Attributes.Add("autocomplete", "off");
            txtlname.Attributes.Add("autocomplete", "off");


        }
    }

    protected void txtfname_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {







    }

    [WebMethod]
    [ScriptMethod]
    public static String save_rec(String fname, String lname, String email, String place, String spl)
    {
        Service webins = new Service();
        DataIUD[] sqlparam = new DataIUD[5];
        sqlparam[0] = new DataIUD();
        sqlparam[0].Paratype = "SqlDbType.nvarchar";
        sqlparam[0].Paraname = "@fname";
        sqlparam[0].Paravalue = fname;

        sqlparam[1] = new DataIUD();
        sqlparam[1].Paratype = "SqlDbType.nvarchar";
        sqlparam[1].Paraname = "@lname";
        sqlparam[1].Paravalue =lname;

        sqlparam[2] = new DataIUD();
        sqlparam[2].Paratype = "SqlDbType.nvarchar";
        sqlparam[2].Paraname = "@email";
        sqlparam[2].Paravalue = email;

        sqlparam[3] = new DataIUD();
        sqlparam[3].Paratype = "SqlDbType.nvarchar";
        sqlparam[3].Paraname = "@place";
        sqlparam[3].Paravalue = place;
        sqlparam[4] = new DataIUD();
        sqlparam[4].Paratype = "SqlDbType.nvarchar";
        sqlparam[4].Paraname = "@specialization";
        sqlparam[4].Paravalue = spl;
        DataSet dss = webins.GetSelectData("WebinarRegister", sqlparam);
        String msg =  dss.Tables[0].Rows[0][0].ToString();

       // MailMessage Msg = new MailMessage();
        // Sender e-mail address.


        //Msg.From = new MailAddress("mis@mendine.in","MENDINE MARKETING TEAM");
        // Recipient e-mail address.
        
       // Msg.To.Add(email);
       // Msg.Subject = "Webinar Invitation";
       // Msg.IsBodyHtml = true;
       // Msg.Body = "Dear Sir/Ma’am,  <br /> <br />" +
          //  "<b>Greeting from Mendine Pharmaceuticals Pvt. Ltd.!! </b>" +

//" <br /> <br />We would like to invite you to our <b> “Marketing Review Meeting” </b> on 16th July 2020. <br /> <br />" +

//"Timing : 4:00 PM.<br/><br/>" +


//"<table ><tr><td></td><td><a href=https://meet.google.com/red-pcjb-hvt>meet.google.com/red-pcjb-hvt</a></td></tr></table>";

//"<a href='meet.google.com/red-pcjb-hvt'> meet.google.com/red-pcjb-hvt</a>";
        // your remote SMTP server IP.
       // SmtpClient smtp = new SmtpClient();
       // smtp.Host = "smtp.gmail.com";
       // smtp.Port = 587;
       // smtp.Credentials = new System.Net.NetworkCredential("mis@mendine.in", "MIS2020_IECS@#");//("saf.fermion12@gmail.com", "saf@2014");
                                                                                               //  smtp.Credentials = new System.Net.NetworkCredential("saf.erp@saf.in", "KOLKATA700091");//("saf.fermion12@gmail.com", "saf@2014");
       // smtp.EnableSsl = true;
       // smtp.Send(Msg);





        return msg;




    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
      // string s= save_rec(txtfname.Text, txtlname.Text, txtemail.Text, txtplace.Text, txtspl.Text);
        //Label1.Text = s;
    }
}