using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Drawing;

public partial class Pages_AllApplicationTracker : System.Web.UI.Page
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
        //if (!IsPostBack)
        //{
        //    RetriveData();
        //}

    }
    protected void RetriveData()
    {
        string constr = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd1 = new SqlCommand("[procallcandidatestracker]", con))
            {
                cmd1.CommandType = CommandType.StoredProcedure;
                
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd1.Connection = con;
                    sda.SelectCommand = cmd1;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView_applications.DataSource = dt;
                        GridView_applications.DataBind();
                    }
                }
            }
        }
    }
    protected void DownloadResume(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        byte[] bytes;
        string fileName, contentType;
        string constr = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("proccanresume", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@registrationno", id);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    sdr.Read();
                    bytes = (byte[])sdr["resumefile"];
                    contentType = sdr["ContentType"].ToString();
                    fileName = sdr["Name"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();

    }
    protected void GridView_applications_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Reportview(object sender, EventArgs e)
    {
        string id = (sender as ImageButton).CommandArgument;
       // Response.Redirect("profilereportt.aspx?name=" + id + "&postcode=" + DropDown_post.SelectedValue);
    }
    protected void EditMode_Click(object sender, EventArgs e)
    {
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        ////TextBox grdtxtrefno = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtrefno");
        ////TextBox grdtxtdept = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtdept");
        //// TextBox grdtxtpostname = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtpostname");
        //// TextBox grdtxtsource = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtsource");
        //TextBox grdtxtstartdate = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtstartdate");
        //TextBox grdtxtidater1 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidater1");
        //TextBox grdtxtinamer1i1 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer1i1");
        //TextBox grdtxtinamer1i2 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer1i2");
        //CalendarExtender grdtxtstartdate_CalendarExtender = (CalendarExtender)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtstartdate_CalendarExtender");
        //CalendarExtender grdtxtidater1_CalendarExtender = (CalendarExtender)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidater1_CalendarExtender");
        //TextBox grdtxthq = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxthq");
        //DropDownList cvstatus = (DropDownList)GridView_applications.Rows[row.RowIndex].FindControl("DropDowncv");
        //FileUpload remarks1r1_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark1r1");
        //FileUpload remarks2r1_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark2r1");
        //LinkButton rowupdate = (LinkButton)GridView_applications.Rows[row.RowIndex].FindControl("updaterow");
        //LinkButton editmode = (LinkButton)GridView_applications.Rows[row.RowIndex].FindControl("editmode");
        // DropDownList DropDownselected_r1 = (DropDownList)GridView_applications.Rows[row.RowIndex].FindControl("DropDownselected_r1");
        ////-----------round_02---------------------------------------
        //TextBox grdtxtidater2 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidater2");
        //CalendarExtender grdtxtidater2_CalendarExtender = (CalendarExtender)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidater2_CalendarExtender");
        //TextBox grdtxtinamer2i1 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer2i1");
        //TextBox grdtxtinamer2i2 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer2i2");
        //FileUpload remark1r2_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark1r2");
        //FileUpload remark2r2_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark2r2");
        //DropDownList DropDownselected_r2 = (DropDownList)GridView_applications.Rows[row.RowIndex].FindControl("DropDownselected_r2");
        ////----------------------------------------------------------
        ////------------------------round 03--------------------------
        //TextBox grdtxtidater3 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidater3");
        //CalendarExtender grdtxtidater3_CalendarExtender = (CalendarExtender)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidater3_CalendarExtender");
        //TextBox grdtxtinamer3i1 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer3i1");
        //TextBox grdtxtinamer3i2 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer3i2");
        //FileUpload remark1r3_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark1r3");
        //FileUpload remark2r3_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark2r3");
        //DropDownList DropDownselected_r3 = (DropDownList)GridView_applications.Rows[row.RowIndex].FindControl("DropDownselected_r3");
        ////----------------------------------------------------------
        ////-------------------------final round ------------------------------------
        //TextBox grdtxtidatefinal = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidatefinal");
        //CalendarExtender grdtxtidatefinal_CalendarExtender = (CalendarExtender)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidatefinal_CalendarExtender");
        //TextBox grdtxtinamerfinali1 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamerfinali1");
        //TextBox grdtxtinamerfinali2 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamerfinali2");
        //FileUpload remark1rfinal_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark1rfinal");
        //FileUpload remark2rfinal_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark2rfinal");
        //DropDownList DropDownselected_rfinal = (DropDownList)GridView_applications.Rows[row.RowIndex].FindControl("DropDownselected_rfinal");
        ////----Additional fields----------------------------------
        //TextBox grdtxtdoo = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtdoo");
        //CalendarExtender grdtxtdoo_CalendarExtender = (CalendarExtender)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtdoo_CalendarExtender");
        //TextBox grdtxtdoj = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtdoj");
        //CalendarExtender grdtxtdoj_CalendarExtender = (CalendarExtender)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtdoj_CalendarExtender");
        //TextBox grdtxtempcode = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtempcode");
        //TextBox grdtxtremark = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtremark");




        //grdtxtstartdate.ReadOnly = false;
        //grdtxtstartdate_CalendarExtender.Enabled = true;
        //grdtxtidater1.ReadOnly = false;
        //grdtxtinamer1i1.ReadOnly = false;
        //grdtxtinamer1i2.ReadOnly = false;
        //grdtxthq.ReadOnly = false;
        //cvstatus.Enabled = true;
        //grdtxtidater1_CalendarExtender.Enabled = true;
        //remarks1r1_upload.Enabled = true;
        //remarks2r1_upload.Enabled = true;
        //rowupdate.Visible = true;
        //editmode.Visible = false;

        //grdtxtidater2.ReadOnly = false;
        //grdtxtidater2_CalendarExtender.Enabled = true;
        //grdtxtinamer2i1.ReadOnly = false;
        //grdtxtinamer2i2.ReadOnly = false;
        //remark1r2_upload.Enabled = true;
        //remark2r2_upload.Enabled = true;
        //DropDownselected_r1.Enabled=true;

        //grdtxtidater3.ReadOnly = false;
        //grdtxtidater3_CalendarExtender.Enabled = true;
        //grdtxtinamer3i1.ReadOnly = false;
        //grdtxtinamer3i2.ReadOnly = false;
        //remark1r3_upload.Enabled = true;
        //remark2r3_upload.Enabled = true;
        //DropDownselected_r2.Enabled = true;
        //DropDownselected_r3.Enabled = true;

        //grdtxtidatefinal.ReadOnly = false;
        //grdtxtidatefinal_CalendarExtender.Enabled = true;
        //grdtxtinamerfinali1.ReadOnly = false;
        //grdtxtinamerfinali2.ReadOnly = false;
        //remark1rfinal_upload.Enabled = true;
        //remark2rfinal_upload.Enabled = true;
        //DropDownselected_rfinal.Enabled = true;

        //grdtxtdoo.ReadOnly = false;
        //grdtxtdoo_CalendarExtender.Enabled = true;
        //grdtxtdoj.ReadOnly = false;
        //grdtxtdoj_CalendarExtender.Enabled = true;
        //grdtxtempcode.ReadOnly = false;
        //grdtxtremark.ReadOnly = false;
        TextBox grdtxtuploadby = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtuploadby");
        string uploadby = grdtxtuploadby.Text.Trim();
        string regno = GridView_applications.DataKeys[row.RowIndex]["registrationnumber"].ToString();
        string postname = GridView_applications.DataKeys[row.RowIndex]["postname"].ToString();
        if (uploadby == "Online")
        {
            Response.Redirect("InterviewDetailsInput.aspx?regno=" + regno + "&postname=" + postname);
        }
        else
        {
            Response.Redirect("InterviewDetailsInputManual.aspx?regno=" + regno + "&postname=" + postname);
        }

    }
    protected void UpdateRow_Click(object sender, EventArgs e)
    {
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        string regno = GridView_applications.DataKeys[row.RowIndex]["registrationnumber"].ToString();
        string deptname = GridView_applications.DataKeys[row.RowIndex]["deptdivision"].ToString();
        string postname = GridView_applications.DataKeys[row.RowIndex]["postname"].ToString();
        string candidatename = GridView_applications.DataKeys[row.RowIndex]["CandidateName"].ToString();
        string source = GridView_applications.DataKeys[row.RowIndex]["referredus"].ToString();

        TextBox grdtxtstartdate = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtstartdate");
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        // DateTime grdstartdate = Convert.ToDateTime(grdtxtstartdate.Text);
        TextBox grdtxtidater1 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidater1");
        //DateTime grdidater1 = Convert.ToDateTime(grdtxtidater1.Text);
        TextBox grdtxtinamer1i1 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer1i1");
        TextBox grdtxtinamer1i2 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer1i2");
        TextBox grdtxthq = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxthq");
        DropDownList cvstatus = (DropDownList)GridView_applications.Rows[row.RowIndex].FindControl("DropDowncv");
        FileUpload remarks1r1_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark1r1");
        FileUpload remarks2r1_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark2r1");
        //------round_02----------------------------------------------------
        TextBox grdtxtidater2 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidater2");
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        // DateTime grdidater2 = Convert.ToDateTime(grdtxtidater2.Text);
        TextBox grdtxtinamer2i1 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer2i1");
        TextBox grdtxtinamer2i2 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer2i2");
        FileUpload remark1r2_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark1r2");
        FileUpload remark2r2_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark2r2");
        DropDownList DropDownselected_r1 = (DropDownList)GridView_applications.Rows[row.RowIndex].FindControl("DropDownselected_r1");
        //---------------------round_03------------------------------------------------
        TextBox grdtxtidater3 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidater3");
        TextBox grdtxtinamer3i1 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer3i1");
        TextBox grdtxtinamer3i2 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamer3i2");
        FileUpload remark1r3_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark1r3");
        FileUpload remark2r3_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark2r3");
        DropDownList DropDownselected_r2 = (DropDownList)GridView_applications.Rows[row.RowIndex].FindControl("DropDownselected_r2");
        //-------------------------final_round ------------------------------------
        TextBox grdtxtidaterfinal = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtidatefinal");
        TextBox grdtxtinamerfinali1 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamerfinali1");
        TextBox grdtxtinamerfinali2 = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtinamerfinali2");
        FileUpload remark1rfinal_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark1rfinal");
        FileUpload remark2rfinal_upload = (FileUpload)GridView_applications.Rows[row.RowIndex].FindControl("remark2rfinal");
        DropDownList DropDownselected_r3 = (DropDownList)GridView_applications.Rows[row.RowIndex].FindControl("DropDownselected_r3");
        DropDownList DropDownselected_rfinal = (DropDownList)GridView_applications.Rows[row.RowIndex].FindControl("DropDownselected_rfinal");
        //----Additional fields----------------------------------
        TextBox grdtxtdoo = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtdoo");
        TextBox grdtxtdoj = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtdoj");
        TextBox grdtxtempcode = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtempcode");
        TextBox grdtxtremark = (TextBox)GridView_applications.Rows[row.RowIndex].FindControl("grdtxtremark");

        //----round 01----------------------------------
        string timetaken = null;
        if (grdtxtdoj.Text != "" && grdtxtstartdate.Text != "")
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            DateTime startdate = Convert.ToDateTime(grdtxtstartdate.Text.Trim());
            DateTime doj = Convert.ToDateTime(grdtxtdoj.Text.Trim());
            TimeSpan t = doj - startdate;
            double t_taken = t.TotalDays;
            timetaken = t_taken.ToString();

        }

        string remarks1r1_upload_data_name = "";
        byte[] remarks1r1_upload_data = null;
        string remarks1r1_upload_data_contenttype = "";
        if (remarks1r1_upload.PostedFile.FileName.ToString() != "")
        {
            byte[] bytes1;

            using (BinaryReader br = new BinaryReader(remarks1r1_upload.PostedFile.InputStream))
            {
                bytes1 = br.ReadBytes(remarks1r1_upload.PostedFile.ContentLength);

                remarks1r1_upload_data = bytes1;
                remarks1r1_upload_data_name = Path.GetFileName(remarks1r1_upload.PostedFile.FileName);
                remarks1r1_upload_data_contenttype = remarks1r1_upload.PostedFile.ContentType;
            }
        }
        else
        {
            remarks1r1_upload_data_name = null;
            remarks1r1_upload_data_contenttype = null;
        }
        string remarks2r1_upload_data_name = "";
        byte[] remarks2r1_upload_data = null;
        string remarks2r1_upload_data_contenttype = "";
        if (remarks2r1_upload.PostedFile.FileName.ToString() != "")
        {
            byte[] bytes2;
            using (BinaryReader br = new BinaryReader(remarks2r1_upload.PostedFile.InputStream))
            {
                bytes2 = br.ReadBytes(remarks2r1_upload.PostedFile.ContentLength);
            }
            remarks2r1_upload_data = bytes2;
            remarks2r1_upload_data_name = Path.GetFileName(remarks2r1_upload.PostedFile.FileName);
            remarks2r1_upload_data_contenttype = remarks2r1_upload.PostedFile.ContentType;
        }
        else
        {
            remarks2r1_upload_data_name = null;
            remarks2r1_upload_data_contenttype = null;

        }
        //-------round 02----------------------------------------------
        string remark1r2_upload_data_name = "";
        byte[] remark1r2_upload_data = null;
        string remark1r2_upload_data_contenttype = "";
        if (remark1r2_upload.PostedFile.FileName.ToString() != "")
        {
            byte[] bytes3;
            using (BinaryReader br = new BinaryReader(remark1r2_upload.PostedFile.InputStream))
            {
                bytes3 = br.ReadBytes(remark1r2_upload.PostedFile.ContentLength);
            }
            remark1r2_upload_data = bytes3;
            remark1r2_upload_data_name = Path.GetFileName(remark1r2_upload.PostedFile.FileName);
            remark1r2_upload_data_contenttype = remark1r2_upload.PostedFile.ContentType;
        }
        else
        {
            remark1r2_upload_data_name = null;
            remark1r2_upload_data_contenttype = null;
        }
        string remark2r2_upload_data_name = "";
        byte[] remark2r2_upload_data = null;
        string remark2r2_upload_data_contenttype = "";
        if (remark2r2_upload.PostedFile.FileName.ToString() != "")
        {
            byte[] bytes4;
            using (BinaryReader br = new BinaryReader(remark2r2_upload.PostedFile.InputStream))
            {
                bytes4 = br.ReadBytes(remark2r2_upload.PostedFile.ContentLength);
            }
            remark2r2_upload_data = bytes4;
            remark2r2_upload_data_name = Path.GetFileName(remark2r2_upload.PostedFile.FileName);
            remark2r2_upload_data_contenttype = remark2r2_upload.PostedFile.ContentType;
        }
        else
        {
            remark2r2_upload_data_name = null;
            remark2r2_upload_data_contenttype = null;

        }
        //----------round 03--------------------------------------------------------
        string remark1r3upload_data_name = "";
        byte[] remark1r3_upload_data = null;
        string remark1r3_upload_data_contenttype = "";
        if (remark1r3_upload.PostedFile.FileName.ToString() != "")
        {
            byte[] bytes5;
            using (BinaryReader br = new BinaryReader(remark1r3_upload.PostedFile.InputStream))
            {
                bytes5 = br.ReadBytes(remark1r3_upload.PostedFile.ContentLength);
            }
            remark1r3_upload_data = bytes5;
            remark1r3upload_data_name = Path.GetFileName(remark1r3_upload.PostedFile.FileName);
            remark1r3_upload_data_contenttype = remark1r3_upload.PostedFile.ContentType;
        }
        else
        {
            remark1r3upload_data_name = null;
            remark1r3_upload_data_contenttype = null;
        }
        string remark2r3_upload_data_name = "";
        byte[] remark2r3_upload_data = null;
        string remark2r3_upload_data_contenttype = "";
        if (remark2r3_upload.PostedFile.FileName.ToString() != "")
        {
            byte[] bytes6;
            using (BinaryReader br = new BinaryReader(remark2r3_upload.PostedFile.InputStream))
            {
                bytes6 = br.ReadBytes(remark2r3_upload.PostedFile.ContentLength);
            }
            remark2r3_upload_data = bytes6;
            remark2r3_upload_data_name = Path.GetFileName(remark2r3_upload.PostedFile.FileName);
            remark2r3_upload_data_contenttype = remark2r3_upload.PostedFile.ContentType;
        }
        else
        {
            remark2r3_upload_data_name = null;
            remark2r3_upload_data_contenttype = null;

        }
        //----------------------Final round------------------------------
        string remark1rfinal_upload_data_name = "";
        byte[] remark1rfinal_upload_data = null;
        string remark1rfinal_upload_data_contenttype = "";
        if (remark1rfinal_upload.PostedFile.FileName.ToString() != "")
        {
            byte[] bytes7;
            using (BinaryReader br = new BinaryReader(remark1rfinal_upload.PostedFile.InputStream))
            {
                bytes7 = br.ReadBytes(remark1rfinal_upload.PostedFile.ContentLength);
            }
            remark1rfinal_upload_data = bytes7;
            remark1rfinal_upload_data_name = Path.GetFileName(remark1rfinal_upload.PostedFile.FileName);
            remark1rfinal_upload_data_contenttype = remark1rfinal_upload.PostedFile.ContentType;
        }
        else
        {
            remark1rfinal_upload_data_name = null;
            remark1rfinal_upload_data_contenttype = null;
        }
        string remark2rfinal_upload_data_name = "";
        byte[] remark2rfinal_upload_data = null;
        string remark2rfinal_upload_data_contenttype = "";
        if (remark2rfinal_upload.PostedFile.FileName.ToString() != "")
        {
            byte[] bytes8;
            using (BinaryReader br = new BinaryReader(remark2rfinal_upload.PostedFile.InputStream))
            {
                bytes8 = br.ReadBytes(remark2rfinal_upload.PostedFile.ContentLength);
            }
            remark2rfinal_upload_data = bytes8;
            remark2rfinal_upload_data_name = Path.GetFileName(remark2rfinal_upload.PostedFile.FileName);
            remark2rfinal_upload_data_contenttype = remark2rfinal_upload.PostedFile.ContentType;
        }
        else
        {
            remark2rfinal_upload_data_name = null;
            remark2rfinal_upload_data_contenttype = null;

        }



        string RecruitmentConnectionString = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(RecruitmentConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("[procinserttraker]"))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@candidateno", regno);
                cmd.Parameters.AddWithValue("@Departmentdivision", deptname);
                cmd.Parameters.AddWithValue("@postname", postname);
                // cmd.Parameters.AddWithValue("@x",subInd.ToString());
                cmd.Parameters.AddWithValue("@candidatename", candidatename);
                cmd.Parameters.AddWithValue("@source", source);
                cmd.Parameters.AddWithValue("@STARTDATE", grdtxtstartdate.Text.Trim());
                cmd.Parameters.AddWithValue("@HeadQ", grdtxthq.Text.Trim());
                cmd.Parameters.AddWithValue("@roneinterviewdate", grdtxtidater1.Text.Trim());
                cmd.Parameters.AddWithValue("@roneinterviewernameone", grdtxtinamer1i1.Text.Trim());
                cmd.Parameters.AddWithValue("@roneinterviewernametwo", grdtxtinamer1i2.Text.Trim());
                cmd.Parameters.AddWithValue("@CVSelected", cvstatus.SelectedValue);
                cmd.Parameters.AddWithValue("@frintervieweronerfile", remarks1r1_upload_data);
                cmd.Parameters.AddWithValue("@frintervieweronefilename", remarks1r1_upload_data_name);
                cmd.Parameters.AddWithValue("@frintervieweroneContentType", remarks1r1_upload_data_contenttype);
                cmd.Parameters.AddWithValue("@frinterviewertworfile", remarks2r1_upload_data);
                cmd.Parameters.AddWithValue("@frinterviewertwofilename", remarks2r1_upload_data_name);
                cmd.Parameters.AddWithValue("@frinterviewertwoContentType", remarks2r1_upload_data_contenttype);

                cmd.Parameters.AddWithValue("@roneselect", DropDownselected_r1.SelectedValue);
                cmd.Parameters.AddWithValue("@rtwointerviewdate", grdtxtidater2.Text.Trim());
                cmd.Parameters.AddWithValue("@rtwointerviewernameone", grdtxtinamer2i1.Text.Trim());
                cmd.Parameters.AddWithValue("@rtwointerviewernametwo", grdtxtinamer2i2.Text.Trim());
                cmd.Parameters.AddWithValue("@srintervieweronerfile", remark1r2_upload_data);
                cmd.Parameters.AddWithValue("@srintervieweronefilename", remark1r2_upload_data_name);
                cmd.Parameters.AddWithValue("@srintervieweroneContentType", remark1r2_upload_data_contenttype);
                cmd.Parameters.AddWithValue("@srinterviewertworfile", remark2r2_upload_data);
                cmd.Parameters.AddWithValue("@srinterviewertwofilename", remark2r2_upload_data_name);
                cmd.Parameters.AddWithValue("@srinterviewertwoContentType", remark2r2_upload_data_contenttype);

                cmd.Parameters.AddWithValue("@rtwoselect", DropDownselected_r2.SelectedValue);
                cmd.Parameters.AddWithValue("@rthreeinterviewdate", grdtxtidater3.Text.Trim());
                cmd.Parameters.AddWithValue("@rthreeinterviewernameone", grdtxtinamer3i1.Text.Trim());
                cmd.Parameters.AddWithValue("@rthreeinterviewernametwo", grdtxtinamer3i2.Text.Trim());
                cmd.Parameters.AddWithValue("@trintervieweronerfile", remark1r3_upload_data);
                cmd.Parameters.AddWithValue("@trintervieweronefilename", remark1r3upload_data_name);
                cmd.Parameters.AddWithValue("@trintervieweroneContentType", remark1r3_upload_data_contenttype);
                cmd.Parameters.AddWithValue("@trinterviewertworfile", remark2r3_upload_data);
                cmd.Parameters.AddWithValue("@trinterviewertwofilename", remark2r3_upload_data_name);
                cmd.Parameters.AddWithValue("@trinterviewertwoContentType", remark2r3_upload_data_contenttype);


                cmd.Parameters.AddWithValue("@rthreeselect", DropDownselected_r3.SelectedValue);
                cmd.Parameters.AddWithValue("@rfinalinterviewdate", grdtxtidaterfinal.Text.Trim());
                cmd.Parameters.AddWithValue("@rfinalinterviewernameone", grdtxtinamerfinali1.Text.Trim());
                cmd.Parameters.AddWithValue("@rfinalinterviewernametwo", grdtxtinamerfinali2.Text.Trim());
                cmd.Parameters.AddWithValue("@firintervieweronerfile", remark1rfinal_upload_data);
                cmd.Parameters.AddWithValue("@firintervieweronefilename", remark1rfinal_upload_data_name);
                cmd.Parameters.AddWithValue("@firintervieweroneContentType", remark1rfinal_upload_data_contenttype);
                cmd.Parameters.AddWithValue("@firinterviewertworfile", remark2rfinal_upload_data);
                cmd.Parameters.AddWithValue("@firinterviewertwofilename", remark2rfinal_upload_data_name);
                cmd.Parameters.AddWithValue("@firinterviewertwoContentType", remark2rfinal_upload_data_contenttype);
                cmd.Parameters.AddWithValue("@firselect", DropDownselected_rfinal.SelectedValue);

                cmd.Parameters.AddWithValue("@DOO", grdtxtdoo.Text.Trim());
                cmd.Parameters.AddWithValue("@DOJ", grdtxtdoj.Text.Trim());
                cmd.Parameters.AddWithValue("@EmployeeCode", grdtxtempcode.Text.Trim());
                cmd.Parameters.AddWithValue("@Remarks", grdtxtremark.Text.Trim());
                cmd.Parameters.AddWithValue("@timetaken", timetaken);




                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        //DesableAll(sender);
        //search_btn_Click(sender, e);
        //  Label3.Text = regno + postname + deptname + candidatename + source + grdtxtstartdate.Text + grdtxtidater1.Text + grdtxtinamer1i1.Text + grdtxtinamer1i2.Text+cvstatus.SelectedValue;
        // Label3.Text = grdtxtrefno.Text + grdtxtdept.Text + grdtxtpostname.Text + grdtxtsource.Text + grdtxtstartdate.Text + grdtxtidater1.Text + grdtxtinamer1i1.Text + grdtxtinamer1i2.Text;
    }
    protected void Download_remark1R1(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        byte[] bytes;
        string fileName, contentType;
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        string postname = GridView_applications.DataKeys[row.RowIndex]["postname"].ToString();

        string constr = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procdlroneintremarks", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Remarks1_R1");
                cmd.Parameters.AddWithValue("@registrationno", id);
                cmd.Parameters.AddWithValue("@postname", postname);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    sdr.Read();
                    bytes = (byte[])sdr["fresumefile"];
                    contentType = sdr["fContentType"].ToString();
                    fileName = sdr["fName"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }
    protected void Download_remark2R1(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        byte[] bytes;
        string fileName, contentType;
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        string postname = GridView_applications.DataKeys[row.RowIndex]["postname"].ToString();
        string constr = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procdlroneintremarks", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Remarks2_R1");
                cmd.Parameters.AddWithValue("@registrationno", id);
                cmd.Parameters.AddWithValue("@postname", postname);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    sdr.Read();
                    bytes = (byte[])sdr["sresumefile"];
                    contentType = sdr["sContentType"].ToString();
                    fileName = sdr["sName"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();

    }
    protected void Download_remark1R2(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        byte[] bytes;
        string fileName, contentType;
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        string postname = GridView_applications.DataKeys[row.RowIndex]["postname"].ToString();
        string constr = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procdlroneintremarks", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Remarks1_R2");
                cmd.Parameters.AddWithValue("@registrationno", id);
                cmd.Parameters.AddWithValue("@postname", postname);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    sdr.Read();
                    bytes = (byte[])sdr["fresumefile"];
                    contentType = sdr["fContentType"].ToString();
                    fileName = sdr["fName"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();

    }
    protected void Download_remark2R2(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        byte[] bytes;
        string fileName, contentType;
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        string postname = GridView_applications.DataKeys[row.RowIndex]["postname"].ToString();
        string constr = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procdlroneintremarks", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Remarks2_R2");
                cmd.Parameters.AddWithValue("@registrationno", id);
                cmd.Parameters.AddWithValue("@postname", postname);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    sdr.Read();
                    bytes = (byte[])sdr["sresumefile"];
                    contentType = sdr["sContentType"].ToString();
                    fileName = sdr["sName"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();

    }
    protected void Download_remark1R3(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        byte[] bytes;
        string fileName, contentType;
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        string postname = GridView_applications.DataKeys[row.RowIndex]["postname"].ToString();
        string constr = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procdlroneintremarks", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Remarks3_R1");
                cmd.Parameters.AddWithValue("@registrationno", id);
                cmd.Parameters.AddWithValue("@postname", postname);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    sdr.Read();
                    bytes = (byte[])sdr["fresumefile"];
                    contentType = sdr["fContentType"].ToString();
                    fileName = sdr["fName"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();

    }
    protected void Download_remark2R3(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        byte[] bytes;
        string fileName, contentType;
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        string postname = GridView_applications.DataKeys[row.RowIndex]["postname"].ToString();
        string constr = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procdlroneintremarks", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Remarks3_R2");
                cmd.Parameters.AddWithValue("@registrationno", id);
                cmd.Parameters.AddWithValue("@postname", postname);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    sdr.Read();
                    bytes = (byte[])sdr["sresumefile"];
                    contentType = sdr["sContentType"].ToString();
                    fileName = sdr["sName"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();

    }
    protected void Download_remark1RF(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        byte[] bytes;
        string fileName, contentType;
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        string postname = GridView_applications.DataKeys[row.RowIndex]["postname"].ToString();
        string constr = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procdlroneintremarks", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Remarksf_R1");
                cmd.Parameters.AddWithValue("@registrationno", id);
                cmd.Parameters.AddWithValue("@postname", postname);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    sdr.Read();
                    bytes = (byte[])sdr["fresumefile"];
                    contentType = sdr["fContentType"].ToString();
                    fileName = sdr["fName"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();

    }
    protected void Download_remark2RF(object sender, EventArgs e)
    {
        string id = (sender as LinkButton).CommandArgument;
        byte[] bytes;
        string fileName, contentType;
        LinkButton ltxt = (LinkButton)sender;
        GridViewRow row = (GridViewRow)ltxt.NamingContainer;
        string postname = GridView_applications.DataKeys[row.RowIndex]["postname"].ToString();
        string constr = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("procdlroneintremarks", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Remarksf_R2");
                cmd.Parameters.AddWithValue("@registrationno", id);
                cmd.Parameters.AddWithValue("@postname", postname);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    sdr.Read();
                    bytes = (byte[])sdr["sresumefile"];
                    contentType = sdr["sContentType"].ToString();
                    fileName = sdr["sName"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //
    }
    protected void export_excel_Click(object sender, EventArgs e)
    {
        if (GridView_applications.Rows.Count != 0)
        {
            Response.Clear();
            Response.Buffer = true;
            //Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AppendHeader("content-disposition", "attachment; filename=GridViewExport.xlsx");

            Response.AddHeader("content-disposition", "attachment;filename=RecruitmentTracker" + DateTime.Now.Date + ".xls");
            Response.Charset = "";

            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView_applications.AllowPaging = false;
                //this.search_btn_Click(sender, e);

              //  GridView_applications.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView_applications.HeaderRow.Cells)
                {
                    cell.BackColor = GridView_applications.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView_applications.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView_applications.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView_applications.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
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

                GridView_applications.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }
    protected void srch_btn_Click(object sender, EventArgs e)
    {

        string startdate = txtfrmdate.Text.Trim();
        string endate = txttodate.Text.Trim();
        GetpageWiseData(startdate, endate, 1);
        //string constr = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    using (SqlCommand cmd = new SqlCommand("[procallcandidatestrackerdates]", con))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@startdate",txtfrmdate.Text.Trim());
        //        cmd.Parameters.AddWithValue("@enddate",txttodate.Text.Trim());

        //        using (SqlDataAdapter sda = new SqlDataAdapter())
        //        {
        //            cmd.Connection = con;
        //            sda.SelectCommand = cmd;
        //            using (DataTable dt = new DataTable())
        //            {
        //                sda.Fill(dt);
        //                GridView_applications.DataSource = dt;
        //                GridView_applications.DataBind();
        //            }
        //        }
        //    }
        //}
    }
    protected void GetpageWiseData(string startdate, string enddate, int pageindex)
    {
        string constring = ConfigurationManager.ConnectionStrings["RecruitmentConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("GetCustomersPageWisetest", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageIndex", pageindex);
                cmd.Parameters.AddWithValue("@startdate", startdate);
                cmd.Parameters.AddWithValue("@enddate", enddate);
                
                cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                con.Open();
                IDataReader idr = cmd.ExecuteReader();
                GridView_applications.DataSource = idr;
                GridView_applications.DataBind();
                idr.Close();
                con.Close();
                int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                this.PopulatePager(recordCount, pageindex);
            }
        }
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        double dblPageCount = (double)((decimal)recordCount / 2);
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("First", "1", currentPage > 1));
            for (int i = 1; i <= pageCount; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }
            pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        string startdate = txtfrmdate.Text.Trim();
        string endate = txttodate.Text.Trim();
        this.GetpageWiseData(startdate, endate,pageIndex);
    }
}