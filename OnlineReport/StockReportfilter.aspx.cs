using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class OnlineReport_rpt : System.Web.UI.Page
{
    //public class utility
    //{
    //    public enum CustomCommandType
    //    {
    //        StoredPorcedure = 1,
    //        SQTString = 2
    //    }
    //    public static DataSet ExecQueryDS(string strSQL, CustomCommandType cmdtype, SqlParameter[] param = null)
    //    {
    //        SqlConnection conn = null/* TODO Change to default(_) if this is not a reference type */;
    //        DataSet ds = new DataSet();
    //        try
    //        {
    //            conn = new SqlConnection(GetConnnectionString("ConnectionString_master"));
    //            SqlCommand cmd = new SqlCommand(strSQL, conn);
    //            cmd.CommandTimeout = 500000;
    //            if (cmdtype.ToString() == "StoredPorcedure")
    //                cmd.CommandType = CommandType.StoredProcedure;
    //            if (cmdtype.ToString() == "SQTString")
    //                cmd.CommandType = CommandType.Text;

    //            if (param != null)
    //            {
    //                if (param.Length > 0)
    //                {
    //                    foreach (SqlParameter par in param)
    //                        cmd.Parameters.Add(new SqlParameter(par.ParameterName, par.Value));
    //                }
    //            }

    //            conn.Open();
    //            SqlDataAdapter da = new SqlDataAdapter(cmd);
    //            da.Fill(ds);

    //            conn.Close();
    //            conn.Dispose();
    //            conn = null/* TODO Change to default(_) if this is not a reference type */;
    //        }
    //        catch (Exception ex)
    //        {
    //            conn.Close();
    //            conn.Dispose();
    //            conn = null/* TODO Change to default(_) if this is not a reference type */;
    //        }

    //        return ds;
    //    }
    //    public static string GetConnnectionString(string ConnStringName)
    //    {


    //        return SetBlankIfNull(System.Configuration.ConfigurationManager.ConnectionStrings[ConnStringName]);



    //    }
    //    public static string SetBlankIfNull(Object obj)
    //    {
    //        string rtnStr;
    //        if (obj == null)
    //        {
    //            rtnStr = "";
    //        }
    //        else
    //        {
    //            rtnStr = obj.ToString();
    //        }
    //        return rtnStr;
    //    }
    //}
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!Page.IsPostBack)
    //    {
    //        populatemaster();
    //        populatestk();
    //    }
    //}



    //protected void ExportToExcel()
    //{
    //    try
    //    {
    //        GridView gv1 = new GridView();

    //        // Dim ds1 As New DataSet
    //        // ds1 = invoiceReport()

    //        string msg = "";
    //        if (gvData.Rows.Count == 0)
    //        {
    //            msg = "<script>alert('No Record Found!!');</script>";
    //            Response.Write(msg);
    //            return;
    //        }

    //        Response.ClearContent();
    //        Response.Buffer = true;
    //        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "rpt.xls"));
    //        Response.ContentType = "application/ms-excel";


    //        StringWriter sw = new StringWriter();
    //        HtmlTextWriter htw = new HtmlTextWriter(sw);
    //        // gv1.Columns(0).HeaderText = "Service Invoice  Report"#ffffff 
    //        // Change the Header Row back to white color
    //        Table table = new Table();
    //        TableRow title = new TableRow();
    //        title.BackColor = System.Drawing.Color.White;

    //        TableCell titlecell = new TableCell();
    //        titlecell.ColumnSpan = 3;
    //        // Should span across all columns
    //        Label lbl = new Label();
    //        // lbl.Text = "Daily Sheet Report"
    //        titlecell.Controls.Add(lbl);
    //        title.Cells.Add(titlecell);
    //        table.Rows.Add(title);
    //        if (!(gvData.HeaderRow == null))
    //            table.Rows.Add(gvData.HeaderRow);
    //        foreach (GridViewRow row in gvData.Rows)
    //            table.Rows.Add(row);
    //        gvData.HeaderRow.Style.Add("background-color", "#FFFFFF");
    //        // For i As Integer = 0 To gv1.Columns.Count - 1
    //        // gv1.Columns(2).Visible = False
    //        // gv1.Columns(1).Visible = False
    //        // Next



    //        // Applying stlye to gridview header cells

    //        for (int i = 0; i <= gvData.HeaderRow.Cells.Count - 1; i++)
    //            gvData.HeaderRow.Cells[i].Style.Add("background-color", "#4CAEE3");

    //        int j = 1;

    //        // This loop is used to apply stlye to cells based on   particular Row
    //        foreach (GridViewRow gvrow in gvData.Rows)
    //        {
    //            gvrow.BackColor = System.Drawing.Color.White;
    //            if (j <= gvData.Rows.Count)
    //            {
    //                if (j % 2 != 0)
    //                {
    //                    for (int k = 0; k <= gvrow.Cells.Count - 1; k++)
    //                        gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
    //                }
    //            }
    //            j += 1;
    //        }
    //        table.RenderControl(htw);


    //        Response.Write(sw.ToString());
    //        Response.End();
    //    }
    //    // End If
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //protected void populatestk()
    //{
    //    SqlParameter[] arparam = new SqlParameter[1];
    //    arparam[0] = new SqlParameter("@ctype", "");
    //    DataSet ds = new DataSet();

    //    ds = utility.ExecQueryDS("procgetstocklocation_webportal", utility.CustomCommandType.StoredPorcedure, null);
    //    lstStk.DataSource = ds.Tables[0];
    //    lstStk.DataTextField = "depo";
    //    lstStk.DataValueField = "depocode";
    //    lstStk.DataBind();
    //}

    //private void populatemaster()
    //{
    //    SqlParameter[] arparam = new SqlParameter[1];
    //    arparam[0] = new SqlParameter("@ctype", "");
    //    DataSet ds = new DataSet();

    //    ds = utility.ExecQueryDS("get_Daily_ClosingStock_WebPortal_master", utility.CustomCommandType.StoredPorcedure, arparam);

    //    lstDivision.DataSource = ds.Tables[0];
    //    lstDivision.DataTextField = "DIVISION";
    //    lstDivision.DataValueField = "DIVISION";
    //    lstDivision.DataBind();

    //    lstDepot.DataSource = ds.Tables[1];
    //    lstDepot.DataTextField = "Depot";
    //    lstDepot.DataValueField = "Depot";
    //    lstDepot.DataBind();



    //    lstProduct.DataSource = ds.Tables[4];
    //    lstProduct.DataTextField = "pp";
    //    lstProduct.DataValueField = "pp";
    //    lstProduct.DataBind();


    //    lstCtype.DataSource = ds.Tables[3];
    //    lstCtype.DataTextField = "cType";
    //    lstCtype.DataValueField = "cType";
    //    lstCtype.DataBind();
    //}


    //protected void btnSubmit_Click1(object sender, EventArgs e)
    //{
    //    string message = "";

    //    foreach (ListItem item in lstDivision.Items)
    //    {
    //        if (item.Selected)
    //            // message += item.Text + " " + item.Value + "\n"
    //            message += "" + item.Value + ",";
    //    }

    //    string cdivision = "";
    //    foreach (ListItem item in lstDivision.Items)
    //    {
    //        if (item.Selected)
    //            cdivision += "" + item.Value + ",";
    //    }

    //    string cdrpot = "";
    //    foreach (ListItem item in lstDepot.Items)
    //    {
    //        if (item.Selected)
    //            cdrpot += "" + item.Value + ",";
    //    }

    //    string cstk = "";
    //    foreach (ListItem item in lstStk.Items)
    //    {
    //        if (item.Selected)
    //            cstk += "" + item.Value + ",";
    //    }

    //    string cprod = "";
    //    foreach (ListItem item in lstProduct.Items)
    //    {
    //        if (item.Selected)
    //            cprod += "" + item.Value + ",";
    //    }

    //    string ctypestr = "";
    //    foreach (ListItem item in lstCtype.Items)
    //    {
    //        if (item.Selected)
    //            ctypestr += "" + item.Value + ",";
    //    }

    //    // lientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "alert('" & message & "');", True)

    //    try
    //    {
    //        SqlParameter[] arparam = new SqlParameter[6];
    //        arparam[0] = new SqlParameter("@cdt", txtDate.Text);
    //        arparam[1] = new SqlParameter("@div", cdivision);
    //        arparam[2] = new SqlParameter("@depot", cdrpot);
    //        arparam[3] = new SqlParameter("@stk", cstk);
    //        arparam[4] = new SqlParameter("@prod", cprod);
    //        arparam[5] = new SqlParameter("@ctype", ctypestr);

    //        DataSet ds = new DataSet();
    //        ds = utility.ExecQueryDS("get_Daily_ClosingStock_WebPortal", utility.CustomCommandType.StoredPorcedure, arparam);

    //        gvData1.DataSource = ds;
    //        gvData1.DataBind();

    //        gvData.DataSource = ds;
    //        gvData.DataBind();


    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //protected void Button1_Click1(object sender, EventArgs e)
    //{
    //    ExportToExcel();
    //}

    public class utility
    {
        public enum CustomCommandType
        {
            StoredPorcedure = 1,
            SQTString = 2
        }
        public static DataSet ExecQueryDS(string strSQL, CustomCommandType cmdtype, SqlParameter[] param = null)
        {
            SqlConnection conn = null/* TODO Change to default(_) if this is not a reference type */;
            DataSet ds = new DataSet();
            try
            {
                conn = new SqlConnection(GetConnnectionString("ConnectionString_master"));
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.CommandTimeout = 500000;
                if (cmdtype.ToString() == "StoredPorcedure")
                    cmd.CommandType = CommandType.StoredProcedure;
                if (cmdtype.ToString() == "SQTString")
                    cmd.CommandType = CommandType.Text;

                if (param != null)
                {
                    if (param.Length > 0)
                    {
                        foreach (SqlParameter par in param)
                            cmd.Parameters.Add(new SqlParameter(par.ParameterName, par.Value));
                    }
                }

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                conn.Close();
                conn.Dispose();
                conn = null/* TODO Change to default(_) if this is not a reference type */;
            }
            catch (Exception ex)
            {
                conn.Close();
                conn.Dispose();
                conn = null/* TODO Change to default(_) if this is not a reference type */;
            }

            return ds;
        }
        public static string GetConnnectionString(string ConnStringName)
        {


            return SetBlankIfNull(System.Configuration.ConfigurationManager.ConnectionStrings[ConnStringName]);



        }
        public static string SetBlankIfNull(Object obj)
        {
            string rtnStr;
            if (obj == null)
            {
                rtnStr = "";
            }
            else
            {
                rtnStr = obj.ToString();
            }
            return rtnStr;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            populatemaster();
            populatestk();
            txtDate.Attributes.Add("ReadOnly", "True");
            txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        }
    }



    protected void ExportToExcel()
    {
        try
        {
            GridView gv1 = new GridView();

            // Dim ds1 As New DataSet
            // ds1 = invoiceReport()

            string msg = "";
            if (gvData.Rows.Count == 0)
            {
                msg = "<script>alert('No Record Found!!');</script>";
                Response.Write(msg);
                return;
            }

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "rpt.xls"));
            Response.ContentType = "application/ms-excel";


            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            // gv1.Columns(0).HeaderText = "Service Invoice  Report"#ffffff 
            // Change the Header Row back to white color
            Table table = new Table();
            TableRow title = new TableRow();
            title.BackColor = System.Drawing.Color.White;

            TableCell titlecell = new TableCell();
            titlecell.ColumnSpan = 3;
            // Should span across all columns
            Label lbl = new Label();
            // lbl.Text = "Daily Sheet Report"
            titlecell.Controls.Add(lbl);
            title.Cells.Add(titlecell);
            table.Rows.Add(title);
            if (!(gvData.HeaderRow == null))
                table.Rows.Add(gvData.HeaderRow);
            foreach (GridViewRow row in gvData.Rows)
                table.Rows.Add(row);
            gvData.HeaderRow.Style.Add("background-color", "#FFFFFF");
            // For i As Integer = 0 To gv1.Columns.Count - 1
            // gv1.Columns(2).Visible = False
            // gv1.Columns(1).Visible = False
            // Next



            // Applying stlye to gridview header cells

            for (int i = 0; i <= gvData.HeaderRow.Cells.Count - 1; i++)
                gvData.HeaderRow.Cells[i].Style.Add("background-color", "#4CAEE3");

            int j = 1;

            // This loop is used to apply stlye to cells based on   particular Row
            foreach (GridViewRow gvrow in gvData.Rows)
            {
                gvrow.BackColor = System.Drawing.Color.White;
                if (j <= gvData.Rows.Count)
                {
                    if (j % 2 != 0)
                    {
                        for (int k = 0; k <= gvrow.Cells.Count - 1; k++)
                            gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                    }
                }
                j += 1;
            }
            table.RenderControl(htw);


            Response.Write(sw.ToString());
            Response.End();
        }
        // End If
        catch (Exception ex)
        {
        }
    }

    protected void populatestk()
    {
        SqlParameter[] arparam = new SqlParameter[1];
        arparam[0] = new SqlParameter("@ctype", "");
        DataSet ds = new DataSet();

        ds = utility.ExecQueryDS("procgetstocklocation_webportal", utility.CustomCommandType.StoredPorcedure, null);
        lstStk.DataSource = ds.Tables[0];
        lstStk.DataTextField = "depo";
        lstStk.DataValueField = "depocode";
        lstStk.DataBind();
    }

    private void populatemaster()
    {
        SqlParameter[] arparam = new SqlParameter[1];
        arparam[0] = new SqlParameter("@ctype", "");
        DataSet ds = new DataSet();

        ds = utility.ExecQueryDS("get_Daily_ClosingStock_WebPortal_master", utility.CustomCommandType.StoredPorcedure, arparam);

        lstDivision.DataSource = ds.Tables[0];
        lstDivision.DataTextField = "DIVISION";
        lstDivision.DataValueField = "DIVISION";
        lstDivision.DataBind();

        lstDepot.DataSource = ds.Tables[1];
        lstDepot.DataTextField = "Depot";
        lstDepot.DataValueField = "Depot";
        lstDepot.DataBind();



        lstProduct.DataSource = ds.Tables[4];
        lstProduct.DataTextField = "pp";
        lstProduct.DataValueField = "pp";
		
        lstProduct.DataBind();
        

        lstCtype.DataSource = ds.Tables[3];
        lstCtype.DataTextField = "cType";
        lstCtype.DataValueField = "cType";
        lstCtype.DataBind();
    }


    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string message = "";

        foreach (ListItem item in lstDivision.Items)
        {
            if (item.Selected)
                // message += item.Text + " " + item.Value + "\n"
                message += "" + item.Value + ",";
        }

        string cdivision = "";
        foreach (ListItem item in lstDivision.Items)
        {
            if (item.Selected)
                cdivision += "" + item.Value + ",";
        }

        string cdrpot = "";
        foreach (ListItem item in lstDepot.Items)
        {
            if (item.Selected)
                cdrpot += "" + item.Value + ",";
        }

        string cstk = "";
        foreach (ListItem item in lstStk.Items)
        {
            if (item.Selected)
                cstk += "" + item.Value + ",";
        }

        string cprod = "";
        foreach (ListItem item in lstProduct.Items)
        {
            if (item.Selected)
                cprod += "" + item.Value + ",";
        }

        string ctypestr = "";
        foreach (ListItem item in lstCtype.Items)
        {
            if (item.Selected)
                ctypestr += "" + item.Value + ",";
        }

        // lientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "alert('" & message & "');", True)

        try
        {
            SqlParameter[] arparam = new SqlParameter[6];
            arparam[0] = new SqlParameter("@cdt", txtDate.Text.Trim());
            arparam[1] = new SqlParameter("@div", cdivision);
            arparam[2] = new SqlParameter("@depot", cdrpot);
            arparam[3] = new SqlParameter("@stk", cstk);
            arparam[4] = new SqlParameter("@prod", cprod);
            arparam[5] = new SqlParameter("@ctype", ctypestr);

            DataSet ds = new DataSet();
            ds = utility.ExecQueryDS("get_Daily_ClosingStock_WebPortal", utility.CustomCommandType.StoredPorcedure, arparam);

            gvData1.DataSource = ds;
            gvData1.DataBind();

            gvData.DataSource = ds;
            gvData.DataBind();


        }
        catch (Exception ex)
        {
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
    }


}