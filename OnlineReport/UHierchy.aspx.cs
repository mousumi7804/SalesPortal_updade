using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

public partial class SalesReport_UHierchy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RetriveData();
    }
    private void RetriveData()
    {
        GridViewuhierchy.DataSource = SqlDataSource1;
        GridViewuhierchy.DataBind();
    }
    protected void EditMode_Click(object sender, EventArgs e)
    {
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        row.BackColor = Color.Brown;
        row.Font.Bold = true;
        DropDownList DropDownmfsohq = (DropDownList)GridViewuhierchy.Rows[row.RowIndex].FindControl("DropDownmfsohq");
        DropDownList DropDowndepo = (DropDownList)GridViewuhierchy.Rows[row.RowIndex].FindControl("DropDowndepo");
        DropDownList DropDowndist = (DropDownList)GridViewuhierchy.Rows[row.RowIndex].FindControl("DropDowndist");
        DropDownList DropDownmfsoname = (DropDownList)GridViewuhierchy.Rows[row.RowIndex].FindControl("DropDownmfsoname");
        TextBox mfsohqtxt = (TextBox)GridViewuhierchy.Rows[row.RowIndex].FindControl("grdtxtmfsohq");
        TextBox grdtxtmfsodoj = (TextBox)GridViewuhierchy.Rows[row.RowIndex].FindControl("grdtxtmfsodoj");
        TextBox grdtxtdepo = (TextBox)GridViewuhierchy.Rows[row.RowIndex].FindControl("grdtxtdepo");
        TextBox grdtxtdist = (TextBox)GridViewuhierchy.Rows[row.RowIndex].FindControl("grdtxtdist");
        TextBox grdtxtmfsoname = (TextBox)GridViewuhierchy.Rows[row.RowIndex].FindControl("grdtxtmfsoname");
        CalendarExtender grdtxtmfsodoj_CalendarExtender = (CalendarExtender)GridViewuhierchy.Rows[row.RowIndex].FindControl("grdtxtmfsodoj_CalendarExtender");
        mfsohqtxt.Visible = false;
        grdtxtdepo.Visible = false;
        grdtxtdist.Visible =false;
        grdtxtmfsoname.Visible = false;
        DropDownmfsohq.Visible = true;
        DropDowndepo.Visible = true;
        DropDowndist.Visible = true;
        DropDownmfsoname.Visible = true;
        grdtxtmfsodoj_CalendarExtender.Enabled = true;
        grdtxtmfsodoj.Enabled = true;
      
        

        //SqlDataSource sqlsource = new SqlDataSource();
        //sqlsource.ID = "SqlDataSource2";
        DropDownmfsohq.DataSource = SqlDataSource2;
        DropDownmfsohq.DataBind();
        DropDownmfsohq.DataValueField = "MSR-MFSO HQ";
        DropDownmfsohq.DataTextField = "MSR-MFSO HQ";

        DropDownmfsohq.DataBind();
        DropDownmfsohq.SelectedValue = mfsohqtxt.Text.Trim();

        DropDowndepo.DataSource = SqlDataSourcedepo;
        DropDowndepo.DataTextField = "Depot";
        DropDowndepo.DataValueField = "Depot";
        DropDowndepo.DataBind();
        DropDowndepo.SelectedValue = grdtxtdepo.Text.Trim();

        DropDowndist.DataSource = SqlDataSourcedist;
        DropDowndist.DataTextField = "Dist";
        DropDowndist.DataValueField = "Dist";
        DropDowndist.DataBind();
        DropDowndist.SelectedValue = grdtxtdist.Text.Trim();

        DropDownmfsoname.DataSource = SqlDataSourcemfsoname;
        DropDownmfsoname.DataTextField = "MSR-MFSO Name";
        DropDownmfsoname.DataValueField = "MSR-MFSO Name";
       DropDownmfsoname.DataBind();
       DropDownmfsoname.SelectedValue = grdtxtmfsoname.Text.Trim();

        LinkButton editrow = (LinkButton)GridViewuhierchy.Rows[row.RowIndex].FindControl("editmode");
        LinkButton cancelrow = (LinkButton)GridViewuhierchy.Rows[row.RowIndex].FindControl("cancelrow");
        LinkButton updaterow = (LinkButton)GridViewuhierchy.Rows[row.RowIndex].FindControl("updaterow");
        editrow.Visible = false;
        updaterow.Visible = true;
        cancelrow.Visible = true;
       
        
       
    }
    protected void UpdateRow_Click(object sender, EventArgs e)
    {
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        DropDownList DropDownmfsohq = (DropDownList)GridViewuhierchy.Rows[row.RowIndex].FindControl("DropDownmfsohq");
        TextBox mfsohqtxt = (TextBox)GridViewuhierchy.Rows[row.RowIndex].FindControl("grdtxtmfsohq");
        TextBox grdtxtmfsodoj = (TextBox)GridViewuhierchy.Rows[row.RowIndex].FindControl("grdtxtmfsodoj");
        CalendarExtender grdtxtmfsodoj_CalendarExtender = (CalendarExtender)GridViewuhierchy.Rows[row.RowIndex].FindControl("grdtxtmfsodoj_CalendarExtender");

        DropDownList DropDowndepo = (DropDownList)GridViewuhierchy.Rows[row.RowIndex].FindControl("DropDowndepo");
        DropDownList DropDowndist = (DropDownList)GridViewuhierchy.Rows[row.RowIndex].FindControl("DropDowndist");
        DropDownList DropDownmfsoname = (DropDownList)GridViewuhierchy.Rows[row.RowIndex].FindControl("DropDownmfsoname");

        grdtxtmfsodoj_CalendarExtender.Enabled = true;
        grdtxtmfsodoj.Enabled = true;
        mfsohqtxt.Visible = false;
        DropDownmfsohq.Visible = true;

        //SqlDataSource sqlsource = new SqlDataSource();
        //sqlsource.ID = "SqlDataSource2";
       // DropDownmfsohq.DataSource = SqlDataSource2;
        //DropDownmfsohq.DataBind();
       // DropDownmfsohq.DataValueField = "MSR-MFSO HQ";
        //DropDownmfsohq.DataTextField = "MSR-MFSO HQ";

        //DropDownmfsohq.DataBind();
        //DropDownmfsohq.SelectedValue = mfsohqtxt.Text.Trim();
        string mfsohq = DropDownmfsohq.SelectedValue;
        string mfsodoj = grdtxtmfsodoj.Text.Trim();
        int id = Convert.ToInt32( (sender as LinkButton).CommandArgument);



        string esspconnection = ConfigurationManager.ConnectionStrings["esspconnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(esspconnection))
        {
            using (SqlCommand cmd = new SqlCommand("[procupdateuhierchy]"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@mfsohq", mfsohq);
                cmd.Parameters.AddWithValue("@dist", DropDowndist.SelectedValue);
                cmd.Parameters.AddWithValue("@depot",DropDowndepo.SelectedValue);
                cmd.Parameters.AddWithValue("@mfsoname", DropDownmfsoname.SelectedValue);





                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        Response.Redirect(Request.RawUrl);



    }
    protected void CancelRow_Click(object sender, EventArgs e)
    {
       // Response.Redirect(Request.RawUrl);

        GridViewuhierchy.DataBind();
    }


    protected void GridViewuhierchy_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
}