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
using System.IO;

public partial class OnlineReport_UHierchyMad : System.Web.UI.Page
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

        }
        if (!IsPostBack)
        {
            RetriveData();
        }
        
    }

    private void RetriveData()
    {
       GridViewuhierchymad.DataSource = SqlDataSourcegridvalue;
        GridViewuhierchymad.DataBind();


        //string constr = ConfigurationManager.ConnectionStrings["esspconnection"].ConnectionString;
        //using (SqlConnection conn = new SqlConnection(constr))
        //{

        //    using (SqlCommand cmd = new SqlCommand("procviewhierchypostwise"))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@username", Session["username"].ToString());


        //        using (SqlDataAdapter sda = new SqlDataAdapter())
        //        {
        //            cmd.Connection = conn;
        //            sda.SelectCommand = cmd;
        //            using (DataTable dt = new DataTable())
        //            {
        //                sda.Fill(dt);
        //                GridViewuhierchymad.DataSource = dt;
        //                GridViewuhierchymad.DataBind();
        //                //Calculate Sum and display in Footer Row
        //                //decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Stock Value"));
        //                //Grid_stockdetails.FooterRow.Cells[9].Text = "Total";
        //               // Grid_stockdetails.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Right;
        //                //Grid_stockdetails.FooterRow.Cells[10].Text = total.ToString("N2");

        //            }
        //        }
        //    }
        //}
    }
    protected void EditMode_Click(object sender, EventArgs e)
    {
       
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        row.BackColor = Color.Brown;
        row.Font.Bold = true;
        DropDownList DropDownstk = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDownstk");
        DropDownList DropDowndepo = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndepo");
        DropDownList DropDownmsrhq = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDownmsrhq");
        DropDownList DropDownmsrname = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDownmsrname");
        DropDownList DropDowndsohq = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndsohq");

        DropDownList DropDowndso = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndso");
        DropDownList DropDowndrsmhq = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndrsmhq");
        DropDownList DropDowndrsm = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndrsm");
        DropDownList DropDowndsrsmhq = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndsrsmhq");
        DropDownList DropDowndsrsm = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndsrsm");
        DropDownList DropDownddistributionhead = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDownddistributionhead");


        TextBox grdtxtstk = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtstk");
        TextBox grdtxtmsrhq = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtmsrhq");
        TextBox grdtxtdepo = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtdepo");
        TextBox grdtxtmsrname = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtmsrname");
        TextBox grdtxtmsrdoj = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtmsrdoj");

        TextBox grdtxtdsodoj = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtdsodoj");
        TextBox grdtxtdrsmodoj = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtdrsmodoj");
        TextBox grdtxtdsrsmodoj = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtdsrsmodoj");
        
        Label lbldsohq = (Label)GridViewuhierchymad.Rows[row.RowIndex].FindControl("lbldsohq");
        Label lbldso = (Label)GridViewuhierchymad.Rows[row.RowIndex].FindControl("lbldso");
        Label lbldrsmhq = (Label)GridViewuhierchymad.Rows[row.RowIndex].FindControl("lbldrsmhq");
        Label lbldrsm = (Label)GridViewuhierchymad.Rows[row.RowIndex].FindControl("lbldrsm");
        Label lbldsrsmhq = (Label)GridViewuhierchymad.Rows[row.RowIndex].FindControl("lbldsrsmhq");
        Label lbldsrsm = (Label)GridViewuhierchymad.Rows[row.RowIndex].FindControl("lbldsrsm");
        Label lbldistributionhead = (Label)GridViewuhierchymad.Rows[row.RowIndex].FindControl("lbldistributionhead");


        CalendarExtender grdtxtmsrdoj_CalendarExtender = (CalendarExtender)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtmsrdoj_CalendarExtender");
        CalendarExtender grdtxtdsodoj_CalendarExtender = (CalendarExtender)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtdsodoj_CalendarExtender");
        CalendarExtender grdtxtdrsmodoj_CalendarExtender = (CalendarExtender)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtdrsmodoj_CalendarExtender");
        CalendarExtender grdtxtdsrsmodoj_CalendarExtender = (CalendarExtender)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtdsrsmodoj_CalendarExtender");


        grdtxtstk.Visible = false;
        grdtxtdepo.Visible = false;
        grdtxtmsrhq.Visible = false;
        grdtxtmsrname.Visible = false;

        lbldsohq.Visible = false;
        lbldso.Visible = false;
        lbldrsmhq.Visible = false;
        lbldrsm.Visible = false;
        lbldsrsmhq.Visible = false;
        lbldsrsm.Visible = false;
        lbldistributionhead.Visible = false;

        DropDownstk.Visible = true;
        DropDowndepo.Visible = true;
        DropDowndsohq.Visible = true;
        DropDownmsrhq.Visible = true;
        DropDownmsrname.Visible = true;

        DropDowndso.Visible = true;
        DropDowndrsmhq.Visible = true;
        DropDowndrsm.Visible = true;
        DropDowndsrsmhq.Visible = true;
        DropDowndsrsm.Visible = true;
        DropDownddistributionhead.Visible = true;

        grdtxtmsrdoj.ReadOnly = false;
        grdtxtdsodoj.ReadOnly = false;
        grdtxtdrsmodoj.ReadOnly = false;
        grdtxtdsrsmodoj.ReadOnly = false;

        grdtxtmsrdoj_CalendarExtender.Enabled = true;
        grdtxtdsodoj_CalendarExtender.Enabled = true;
        grdtxtdrsmodoj_CalendarExtender.Enabled = true;
        grdtxtdsrsmodoj_CalendarExtender.Enabled = true;

        //grdtxtmfsodoj.Enabled = true;



        //SqlDataSource sqlsource = new SqlDataSource();
        //sqlsource.ID = "SqlDataSource2";
        #region dropdown value load
        DropDownstk.DataSource = SqlDataSourcestk;
        
        DropDownstk.DataValueField = "STK";
        DropDownstk.DataTextField = "STK";
        DropDownstk.DataBind();
        DropDownstk.SelectedValue = grdtxtstk.Text.Trim();

        DropDownmsrhq.DataSource = SqlDataSourcemsrhq;
        DropDownmsrhq.DataValueField = "MSR_HQ";
        DropDownmsrhq.DataTextField = "MSR_HQ";
        DropDownmsrhq.DataBind();
        DropDownmsrhq.SelectedValue = grdtxtmsrhq.Text.Trim();

        DropDowndepo.DataSource = SqlDataSourcedepo;
        DropDowndepo.DataTextField = "Depot";
        DropDowndepo.DataValueField = "Depot";
        DropDowndepo.DataBind();
        DropDowndepo.SelectedValue = grdtxtdepo.Text.Trim();

        DropDownmsrname.DataSource = SqlDataSourcemsrname;
        DropDownmsrname.DataTextField = "MSR_NAME";
        DropDownmsrname.DataValueField = "MSR_NAME";
        DropDownmsrname.DataBind();
        DropDownmsrname.SelectedValue = grdtxtmsrname.Text.Trim();

        DropDowndsohq.DataSource = SqlDataSourcedsohq;
        DropDowndsohq.DataTextField = "DSO-HQ";
        DropDowndsohq.DataValueField = "DSO-HQ";
        DropDowndsohq.DataBind();
        DropDowndsohq.SelectedValue = lbldsohq.Text.Trim();
        #endregion

        DropDowndso.DataSource = SqlDataSourcedso;
        DropDowndso.DataTextField = "DSO";
        DropDowndso.DataValueField = "DSO";
        DropDowndso.DataBind();
        DropDowndso.SelectedValue = lbldso.Text.Trim();

        DropDowndrsmhq.DataSource = SqlDataSourcedrsmhq;
        DropDowndrsmhq.DataTextField = "DRSM HQ";
        DropDowndrsmhq.DataValueField = "DRSM HQ";
        DropDowndrsmhq.DataBind();
        DropDowndrsmhq.SelectedValue = lbldrsmhq.Text.Trim();

        DropDowndrsm.DataSource = SqlDataSourcedrsm;
        DropDowndrsm.DataTextField = "DRSM";
        DropDowndrsm.DataValueField = "DRSM";
        DropDowndrsm.DataBind();
        DropDowndrsm.SelectedValue = lbldrsm.Text.Trim();

        DropDowndsrsmhq.DataSource = SqlDataSourcedsrsmhq;
        DropDowndsrsmhq.DataTextField = "DSRSM HQ";
        DropDowndsrsmhq.DataValueField = "DSRSM HQ";
        DropDowndsrsmhq.DataBind();
        DropDowndsrsmhq.SelectedValue = lbldsrsmhq.Text.Trim();

        DropDowndsrsm.DataSource = SqlDataSourcedsrsm;
        DropDowndsrsm.DataTextField = "DSRSM";
        DropDowndsrsm.DataValueField = "DSRSM";
        DropDowndsrsm.DataBind();
        DropDowndsrsm.SelectedValue = lbldsrsm.Text.Trim();

        DropDownddistributionhead.DataSource = SqlDataSourcedistributionhead;
        DropDownddistributionhead.DataTextField = "DISTRIBUTION HEAD";
        DropDownddistributionhead.DataValueField = "DISTRIBUTION HEAD";
        DropDownddistributionhead.DataBind();
        DropDownddistributionhead.SelectedValue = lbldistributionhead.Text.Trim();

        LinkButton editrow = (LinkButton)GridViewuhierchymad.Rows[row.RowIndex].FindControl("editmode");
        LinkButton cancelrow = (LinkButton)GridViewuhierchymad.Rows[row.RowIndex].FindControl("cancelrow");
        LinkButton updaterow = (LinkButton)GridViewuhierchymad.Rows[row.RowIndex].FindControl("updaterow");
        editrow.Visible = false;
        updaterow.Visible = true;
        cancelrow.Visible = true;



    }
    protected void UpdateRow_Click(object sender, EventArgs e)
    {
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        DropDownList DropDownstk = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDownstk");
        DropDownList DropDowndepo = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndepo");
        DropDownList DropDownmsrhq = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDownmsrhq");
        DropDownList DropDownmsrname = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDownmsrname");
        DropDownList DropDowndsohq = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndsohq");

        DropDownList DropDowndso = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndso");
        DropDownList DropDowndrsmhq = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndrsmhq");
        DropDownList DropDowndrsm = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndrsm");
        DropDownList DropDowndsrsmhq = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndsrsmhq");
        DropDownList DropDowndsrsm = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDowndsrsm");
        DropDownList DropDownddistributionhead = (DropDownList)GridViewuhierchymad.Rows[row.RowIndex].FindControl("DropDownddistributionhead");

        TextBox grdtxtmsrdoj = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtmsrdoj");
        TextBox grdtxtdsodoj = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtdsodoj");
        TextBox grdtxtdrsmodoj = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtdrsmodoj");
        TextBox grdtxtdsrsmodoj = (TextBox)GridViewuhierchymad.Rows[row.RowIndex].FindControl("grdtxtdsrsmodoj");

        int id = Convert.ToInt32((sender as LinkButton).CommandArgument);



        string esspconnection = ConfigurationManager.ConnectionStrings["esspconnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(esspconnection))
        {
            using (SqlCommand cmd = new SqlCommand("[procupdatemadhierchy]"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@depo", DropDowndepo.SelectedValue);
                cmd.Parameters.AddWithValue("@stk", DropDownstk.SelectedValue);
                cmd.Parameters.AddWithValue("@msrhq",DropDownmsrhq.SelectedValue);
                cmd.Parameters.AddWithValue("@msrname",DropDownmsrname.SelectedValue);

                cmd.Parameters.AddWithValue("@msrdoj",grdtxtmsrdoj.Text.Trim());
                cmd.Parameters.AddWithValue("@dsohq", DropDowndsohq.SelectedValue);
                cmd.Parameters.AddWithValue("@dso", DropDowndso.SelectedValue);
                cmd.Parameters.AddWithValue("@dsodoj", grdtxtdsodoj.Text.Trim());

                cmd.Parameters.AddWithValue("@drsmhq",DropDowndrsmhq.SelectedValue);
                cmd.Parameters.AddWithValue("@drsm", DropDowndrsm.SelectedValue);
                cmd.Parameters.AddWithValue("@drsmdoj", grdtxtdrsmodoj.Text.Trim());
                cmd.Parameters.AddWithValue("@dsrsmhq", DropDowndsrsmhq.SelectedValue);

                cmd.Parameters.AddWithValue("@dsrsm",DropDowndsrsm.SelectedValue);
                cmd.Parameters.AddWithValue("@dsrsmdoj", grdtxtdsrsmodoj.Text.Trim());
                cmd.Parameters.AddWithValue("@distributionhead", DropDownddistributionhead.Text.Trim());
                





                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        //Response.Redirect(Request.RawUrl);
        RetriveData();



    }
    protected void CancelRow_Click(object sender, EventArgs e)
    {
        // Response.Redirect(Request.RawUrl);
        GridViewuhierchymad.DataSource = SqlDataSourcegridvalue;

        GridViewuhierchymad.DataBind();
    }



    protected void exportbtn_Click(object sender, EventArgs e)
    {
        if (GridViewuhierchymad.Rows.Count != 0)
        {
            Response.Clear();
            Response.Buffer = true;
            //Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AppendHeader("content-disposition", "attachment; filename=GridViewExport.xlsx");

            Response.AddHeader("content-disposition", "attachment;filename=Uiversal_Hierarchy_MAD" + DateTime.Now.Date + ".xls");
            Response.Charset = "";

            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages



                foreach (GridViewRow row in GridViewuhierchymad.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        
                        //cell.CssClass = "textmode";
                        List<Control> controls = new List<Control>();

                        //Add controls to be removed to Generic List
                        foreach (Control control in cell.Controls)
                        {
                            controls.Add(control);
                        }

                        //Loop through the controls to be removed and replace then with Literal
                        foreach (Control control in controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                    break;
                                case "Label":
                                    cell.Controls.Add(new Literal { Text = (control as Label).Text });
                                    break;
                                case "TextBox":
                                    cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                    break;
                                case "LinkButton":
                                    cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                    break;
                                case "CheckBox":
                                    cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                    break;
                                case "RadioButton":
                                    cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                    break;
                                case "FileUpload":
                                    cell.Controls.Add(new Literal { Text = (control as FileUpload).HasFile.ToString() });
                                    break;
                                case "DropDownList":
                                    cell.Controls.Add(new Literal { Text = (control as DropDownList).SelectedValue });
                                    break;
                            }
                            cell.Controls.Remove(control);
                        }
                    }
                }

                GridViewuhierchymad.RenderControl(hw);
                GridViewuhierchymad.Columns.RemoveAt(0);
                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}