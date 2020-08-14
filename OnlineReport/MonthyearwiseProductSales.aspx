<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MonthyearwiseProductSales.aspx.cs" Inherits="OnlineReport_MonthyearwiseProductSales" %>

<%@ Register Src="~/UserControl/report_viewer.ascx" TagName="reportviewer" TagPrefix="uc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="IdeaSparx.CoolControls.Web" Namespace="IdeaSparx.CoolControls.Web"
    TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
<link href="../Styles/Customstyle1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        label
        {
            color:Black;
            }
        
    </style>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
<link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
<script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
<%--<script type="text/javascript">

    $(document).ready(function () {

        Sys.Application.add_load(function () {

            $('[id*=PPS]').multiselect({
                includeSelectAllOption: true,
                maxHeight: 300



            });

        });

    });



</script>--%>

  <style type="text/css">
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server" ID="pnl_report">
        <ContentTemplate>
        <div style="float: left; width: 100%; text-align: center;">
    <label for="Title">
    YEARLY PRODUCT SALE REPORT </label><br />
     </div>
            <div class="container">
                <div class="row">
                    <div class="col-md-2">
                        <%--<label for="From Date">
                            From Date:</label><br />
                        <asp:TextBox ID="txtfrmdate" runat="server" autocomplete="off" onkeydown="return false;"
                            AutoCompleteType="Disabled"></asp:TextBox><br />
                        <asp:CalendarExtender ID="txtfrmdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtfrmdate" />--%>
                    </div>
                    
                  

                    <div class="col-md-3">
                <label for="From Date">
                    </label><br />
                <%--<asp:DropDownList ID="PPS" runat="server" DataSourceID="mendinemaster" 
                    DataTextField="Mpharm_Pd_Name" DataValueField="Mpharm_Pd_Name">
                </asp:DropDownList>--%>
                 <%--<asp:ListBox ID="PPS" runat="server" SelectionMode="Multiple" 
            DataSourceID="mendinemaster" DataTextField="Mpharm_Pd_Name" 
            DataValueField="Mpharm_Pd_Name"></asp:ListBox>
                <asp:SqlDataSource ID="mendinemaster" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>" 
                    SelectCommand="select distinct Mpharm_Pd_Name from (SELECT mpharm_pd_name+'---'+cast(pack as varchar) Mpharm_Pd_Name 
                    FROM [ProductTransform] 
                   )a order by Mpharm_Pd_Name">
                </asp:SqlDataSource>--%>
            </div>
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-primary"
                            OnClick="btnsubmit_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-5">
                        <asp:Label ID="lblstatus" runat="server"></asp:Label>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <uc1:reportviewer ReportTitle="Default" ReportName="Default Name" runat="server"
                            ID="rpt_Transactionbilltrends" />
                    </div>
                </div>
                <div class="loading" align="center">
                                    <img src="../Image/wait2.gif" alt="" />
                                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
