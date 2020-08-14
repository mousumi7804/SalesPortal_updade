using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OnlineReport_Paymentoption : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            lblId.Text = HttpUtility.UrlDecode(Request.QueryString["Totalamt"]);
            Labecode.Text = HttpUtility.UrlDecode(Request.QueryString["Customercode"]);
           
        }

    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Dictionary<String, String> paytmParams = new Dictionary<String, String>();
    //    paytmParams.Add("MID", "");

    //    /* Find your WEBSITE in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys */
    //    paytmParams.Add("WEBSITE", "");

    //    /* Find your INDUSTRY_TYPE_ID in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys */
    //    paytmParams.Add("INDUSTRY_TYPE_ID", "");

    //    /* WEB for website and WAP for Mobile-websites or App */
    //    paytmParams.Add("CHANNEL_ID", "");

    //    /* Enter your unique order id */
    //    paytmParams.Add("ORDER_ID", "");

    //    /* unique id that belongs to your customer */
    //    paytmParams.Add("CUST_ID", "");

    //    /* customer's mobile number */
    //    paytmParams.Add("MOBILE_NO", "");

    //    /* customer's email */
    //    paytmParams.Add("EMAIL", "");

    //    /**
    //    * Amount in INR that is payble by customer
    //    * this should be numeric with optionally having two decimal points
    //    */
    //    paytmParams.Add("TXN_AMOUNT", "");

    //    /* on completion of transaction, we will send you the response on this URL */
    //    paytmParams.Add("CALLBACK_URL", "");

    //    /**
    //    * Generate checksum for parameters we have
    //    * You can get Checksum DLL from https://developer.paytm.com/docs/checksum/
    //    * Find your Merchant Key in your Paytm Dashboard at https://dashboard.paytm.com/next/apikeys 
    //    */
    //    String checksum = paytm.CheckSum.generateCheckSum("k84hF1mmoQM#kBIu", paytmParams);

    //    /* for Staging */
    //    String url = "https://securegw-stage.paytm.in/order/process";

    //    /* for Production */
    //    // String url = "https://securegw.paytm.in/order/process";

    //    /* Prepare HTML Form and Submit to Paytm */
    //    String outputHtml = "";
    //    outputHtml += "<html>";
    //    outputHtml += "<head>";
    //    outputHtml += "<title>Merchant Checkout Page</title>";
    //    outputHtml += "</head>";
    //    outputHtml += "<body>";
    //    outputHtml += "<center><h1>Please do not refresh this page...</h1></center>";
    //    outputHtml += "<form method='post' action='" + url + "' name='paytm_form'>";
    //    foreach (string key in paytmParams.Keys)
    //    {
    //        outputHtml += "<input type='hidden' name='" + key + "' value='" + paytmParams[key] + "'>";
    //    }
    //    outputHtml += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
    //    outputHtml += "</form>";
    //    outputHtml += "<script type='text/javascript'>";
    //    outputHtml += "document.paytm_form.submit();";
    //    outputHtml += "</script>";
    //    outputHtml += "</body>";
    //    outputHtml += "</html>";

    //}
}