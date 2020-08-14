using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Security;
public partial class OnlineReport_msrwiseorder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            //or use Response.Redirect to go to a different page
            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/Account/Login.aspx");
            //Session["username"] = "MP100362";

        }
        if (!IsPostBack)
        {
            LoadSubEmp();
        }
        Menu men = (Menu)Master.FindControl("NavigationMenu");
        men.Visible = false;
            
        //if (!this.IsPostBack)
        //{
        //    //this.BindGrid();
        //}
    }
    private void LoadSubEmp()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("Mad_userwise_higher"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                //cmd.Parameters.AddWithValue("@month", DdlMonth.SelectedValue);
                //cmd.Parameters.AddWithValue("@year", Ddlyear.SelectedValue);


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        //lbldiv.Text = dt.Rows[0][0].ToString();

                        DropDownsubemplist.DataSource = dt;
                        DropDownsubemplist.DataTextField = "name";
                        DropDownsubemplist.DataValueField = "empemail";
                        DropDownsubemplist.DataBind();

                    }
                }
            }
        }
    }
    protected void Search(object sender, EventArgs e)
    {
        this.BindGrid();
    }
    protected void BindGrid()
    {
        string ORSvalue = "";
        //foreach (ListItem item3 in OrderStatus.Items)
        //{
        //    if (item3.Selected)
        //    {
        //        ORSvalue += item3.Value + ",";
        //    }
        //}
        string Productvalue = "";
        //foreach (ListItem item1 in PPS.Items)
        //{
        //    if (item1.Selected)
        //    {
        //        Productvalue += item1.Value + ",";
        //    }
        //}
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("salesordertransactionAutomationhierarchy"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@startdate", txtfrmdate.Text.Trim());
                cmd.Parameters.AddWithValue("@endate", txttodate.Text.Trim());
               // cmd.Parameters.AddWithValue("@msremail", "BURDWAN_1@mendine.com");
                cmd.Parameters.AddWithValue("@msremail", DropDownsubemplist.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@orderstatus", ORSvalue);
                cmd.Parameters.AddWithValue("@pps", Productvalue);
                cmd.Parameters.AddWithValue("@Action", "Select");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvCustomers.DataSource = dt;
                        gvCustomers.DataBind();
                        //Response.Redirect("selectedcode.aspx?Alias=" + customercode);
                    }
                }
            }
        }
    }

    //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    //{


    //    string post = "";
    //    string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(constr))
    //    {
    //        using (SqlCommand cmd = new SqlCommand("procmademppost", con))
    //        {
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            cmd.Parameters.AddWithValue("@email", Session["username"].ToString());
    //            cmd.Connection = con;
    //            con.Open();
    //            using (SqlDataReader sdr = cmd.ExecuteReader())
    //            {

    //                sdr.Read();
    //                post = sdr["post"].ToString();
    //            }
    //            con.Close();
    //        }
    //    }
    //    if (post == "MSR")
    //    {
    //        gvCustomers.EditIndex = e.NewEditIndex;
    //        this.BindGrid();
    //    }
    //    else
    //    {
    //        gvCustomers.EditIndex = -1;
    //        this.BindGrid();
    //    }
    //}

    //protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    GridViewRow row1 = gvCustomers.Rows[e.RowIndex];
    //    int fkpid = Convert.ToInt32(gvCustomers.DataKeys[e.RowIndex].Values[0]);
    //    int pkpid = Convert.ToInt32(gvCustomers.DataKeys[e.RowIndex].Values[1]);
    //    int fksid = Convert.ToInt32(gvCustomers.DataKeys[e.RowIndex].Values[2]);
    //   // string osststus = (gvCustomers.DataKeys[e.RowIndex].Values[3]).ToString();
    //    string partycode = (gvCustomers.DataKeys[e.RowIndex].Values[3]).ToString();
    //    DropDownList txtopr = row1.FindControl("txtOPRemarks") as DropDownList;
    //    DropDownList dropdownbillfuturestatus=row1.FindControl("dropdownbillfuturestatus") as DropDownList;
    //    TextBox txtotherrmarks = row1.FindControl("txtOPRemarksone") as TextBox;
    //    string otherremarks = txtotherrmarks.Text.Trim();
    //    string opr = txtopr.SelectedValue.ToString();
    //    string sts = dropdownbillfuturestatus.SelectedValue.ToString();
    //    if (sts == "SELECT")
    //    {
    //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You Have To Select Bill Future Status');", true);
    //    }
    //    else
    //    {
    //        if (sts=="NO" && opr == "SELECT")
    //        {
    //            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You Have To Select OPREMARKS');", true);
    //        }
    //        else
    //        {
    //            if (opr == "OTHER" && otherremarks == "")
    //            {
    //                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Other Remarks');", true);
    //            }
    //            else
    //            {
    //                if (opr == "SELECT")
    //                    opr = "";
    //                string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
    //                using (SqlConnection conn = new SqlConnection(constr))
    //                {

    //                    using (SqlCommand cmd = new SqlCommand("salesordertransactionAutomationhierarchy"))
    //                    {
    //                        cmd.CommandType = CommandType.StoredProcedure;
    //                        cmd.Parameters.AddWithValue("@FKProdID", fkpid);
    //                        cmd.Parameters.AddWithValue("@PKID", pkpid);
    //                        cmd.Parameters.AddWithValue("@FKSeriesID", fksid);
    //                        cmd.Parameters.AddWithValue("@Action", "Update");
    //                        cmd.Parameters.AddWithValue("@os", "Pending");
    //                        cmd.Parameters.AddWithValue("@ccode", partycode);
    //                        cmd.Parameters.AddWithValue("@OPREMARKS", opr);
    //                        cmd.Parameters.AddWithValue("@billfuturestatus", sts);
    //                        cmd.Parameters.AddWithValue("@otherremarks", otherremarks);
    //                        cmd.Connection = conn;
    //                        conn.Open();
    //                        cmd.ExecuteNonQuery();
    //                        conn.Close();

    //                    }
    //                }
    //                gvCustomers.EditIndex = -1;
    //                this.BindGrid();
    //            }
                
    //        }
    //    }
        

    //}
    //protected void OnCancel(object sender, EventArgs e)
    //{
    //    gvCustomers.EditIndex = -1;
    //    this.BindGrid();
    //}
    //protected void OnRowCancelingEdit(object sender, EventArgs e)
    //{
    //    gvCustomers.EditIndex = -1;
    //    this.BindGrid();
    //}
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCustomers.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    //protected void Remarks(object sender, EventArgs e)
    //{
    //    string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
    //    using (SqlConnection conn = new SqlConnection(constr))
    //    {

    //        using (SqlCommand cmd = new SqlCommand("outstandingpaymentgateway"))
    //        {
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.AddWithValue("@customercode", lblId.Text.Trim());
    //            cmd.Parameters.AddWithValue("@action", "behala");


    //            using (SqlDataAdapter sda = new SqlDataAdapter())
    //            {
    //                cmd.Connection = conn;
    //                sda.SelectCommand = cmd;
    //                using (DataTable dt = new DataTable())
    //                {
    //                    sda.Fill(dt);
    //                    if (dt.Rows.Count != 0)
    //                    {
    //                        gvCustomers.DataSource = dt;
    //                        gvCustomers.DataBind();

    //                        //Calculate Sum and display in Footer Row
    //                        decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("PAYABLEAMOUNT"));
    //                        gvCustomers.FooterRow.Cells[10].Text = "Total";
    //                        gvCustomers.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Right;
    //                        gvCustomers.FooterRow.Cells[11].Text = total.ToString();
    //                        Response.Redirect(string.Format("Paymentoption.aspx?Totalamt={0}&Customercode={1}", total.ToString(), lblId.Text.Trim()));
    //                    }


    //                }
    //            }
    //        }
    //    }
    //}

    protected void txtOPRemarks_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList txtOPRemarks = (DropDownList)sender;
        GridViewRow row = (GridViewRow)txtOPRemarks.NamingContainer;
        //DropDownList ddlAddLabTestShortName = (DropDownList)row.FindControl("ddlAddShortname");
        TextBox txtOPRemarksone = (TextBox)row.FindControl("txtOPRemarksone");
        if (txtOPRemarks.SelectedValue.ToString() == "OTHER")
        {
            
            txtOPRemarksone.Visible = true;
        }
        else
        {
            {
                txtOPRemarksone.Text = "";
                txtOPRemarksone.Visible = false;
            }
        }

    }
    protected void editmode_Click(object sender, EventArgs e)
    {
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        string post = "";
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procmademppost", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email", Session["username"].ToString());
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    sdr.Read();
                    post = sdr["post"].ToString();
                }
                con.Close();
            }
        }
        if (post == "MSR")
        {
            LinkButton editmode = (LinkButton)gvCustomers.Rows[row.RowIndex].FindControl("editmode");
            LinkButton updaterow = (LinkButton)gvCustomers.Rows[row.RowIndex].FindControl("updaterow");
            LinkButton cancelupdate = (LinkButton)gvCustomers.Rows[row.RowIndex].FindControl("cancelupdate");

            DropDownList txtOPRemarks = (DropDownList)gvCustomers.Rows[row.RowIndex].FindControl("txtOPRemarks");
            DropDownList dropdownbillfuturestatus = (DropDownList)gvCustomers.Rows[row.RowIndex].FindControl("dropdownbillfuturestatus");
            TextBox txtOPRemarksone = (TextBox)gvCustomers.Rows[row.RowIndex].FindControl("txtOPRemarksone");

            Label lblOPREMARKS = (Label)gvCustomers.Rows[row.RowIndex].FindControl("lblOPREMARKS");
            Label lblOPREMARKSONE = (Label)gvCustomers.Rows[row.RowIndex].FindControl("lblOPREMARKSONE");
            Label lblbillfuturestatus = (Label)gvCustomers.Rows[row.RowIndex].FindControl("lblbillfuturestatus");


            editmode.Visible = false;
            updaterow.Visible = true;
            cancelupdate.Visible = true;

            lblbillfuturestatus.Visible = false;
            lblOPREMARKS.Visible = false;
            lblOPREMARKSONE.Visible = false;

            txtOPRemarks.Visible = true;
            // txtOPRemarksone.Visible = true;
            dropdownbillfuturestatus.Visible = true;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You are not allowed to edit');", true);
        }



    }
    protected void updaterow_Click(object sender, EventArgs e)
    {
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        DropDownList txtOPRemarks = (DropDownList)gvCustomers.Rows[row.RowIndex].FindControl("txtOPRemarks");
        DropDownList dropdownbillfuturestatus = (DropDownList)gvCustomers.Rows[row.RowIndex].FindControl("dropdownbillfuturestatus");
        TextBox txtOPRemarksone = (TextBox)gvCustomers.Rows[row.RowIndex].FindControl("txtOPRemarksone");

        int fkpid = Convert.ToInt32(gvCustomers.DataKeys[row.RowIndex].Values[0]);
        int pkpid = Convert.ToInt32(gvCustomers.DataKeys[row.RowIndex].Values[1]);
        int fksid = Convert.ToInt32(gvCustomers.DataKeys[row.RowIndex].Values[2]);
        // string osststus = (gvCustomers.DataKeys[e.RowIndex].Values[3]).ToString();
        string partycode = (gvCustomers.DataKeys[row.RowIndex].Values[3]).ToString();

        string otherremarks = txtOPRemarksone.Text.Trim();
        string opr = txtOPRemarks.SelectedValue.ToString();
        string sts = dropdownbillfuturestatus.SelectedValue.ToString();

        if (sts == "SELECT")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You Have To Select Bill Future Status');", true);
        }
        else
        {
            if (sts == "NO" && opr == "SELECT")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('You Have To Select OPREMARKS');", true);
            }
            else
            {
                if (opr == "OTHER" && otherremarks == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Other Remarks');", true);
                }
                else
                {
                    if (opr == "SELECT")
                        opr = "";
                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString_master"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(constr))
                    {

                        using (SqlCommand cmd = new SqlCommand("salesordertransactionAutomationhierarchy"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@FKProdID", fkpid);
                            cmd.Parameters.AddWithValue("@PKID", pkpid);
                            cmd.Parameters.AddWithValue("@FKSeriesID", fksid);
                            cmd.Parameters.AddWithValue("@Action", "Update");
                            cmd.Parameters.AddWithValue("@os", "Pending");
                            cmd.Parameters.AddWithValue("@ccode", partycode);
                            cmd.Parameters.AddWithValue("@OPREMARKS", opr);
                            cmd.Parameters.AddWithValue("@billfuturestatus", sts);
                            cmd.Parameters.AddWithValue("@otherremarks", otherremarks);
                            cmd.Connection = conn;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();

                        }
                    }
                    //gvCustomers.EditIndex = -1;
                    this.BindGrid();
                }

            }
        }


    }
    protected void cancelupdate_Click(object sender, EventArgs e)
    {
        this.BindGrid();
    }
}