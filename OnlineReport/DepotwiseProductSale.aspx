<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DepotwiseProductSale.aspx.cs" Inherits="OnlineReport_DepotwiseProductSale" %>

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
<script type="text/javascript">

    $(document).ready(function () {

        Sys.Application.add_load(function () {

            $('[id*=PPS]').multiselect({
                includeSelectAllOption: true,
                maxHeight: 300



            });

        });

    });



</script>
<script type="text/javascript">

    $(document).ready(function () {

        Sys.Application.add_load(function () {

            $('[id*=Division]').multiselect({
                includeSelectAllOption: true,
                maxHeight: 300



            });

        });

    });



    </script>

     <script type="text/javascript">

         $(document).ready(function () {

             Sys.Application.add_load(function () {

                 $('[id*=SKT]').multiselect({
                     includeSelectAllOption: true,
                     maxHeight: 300



                 });

             });

         });



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server" ID="pnl_report">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-md-2">
                        <label for="From Date">
                            From Date:</label><br />
                        <asp:TextBox ID="txtfrmdate" runat="server" autocomplete="off" onkeydown="return false;"
                            AutoCompleteType="Disabled"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="req" runat="server" ErrorMessage="*Required" ControlToValidate="txtfrmdate"
                    CssClass="req_css" ValidationGroup="req"></asp:RequiredFieldValidator>
                        <asp:CalendarExtender ID="txtfrmdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtfrmdate" />
                    </div>
                    
                  

                    <div class="col-md-3">
                <label for="From Date">
                    Product name & Pack Size</label><br />
                <%--<asp:DropDownList ID="PPS" runat="server" DataSourceID="mendinemaster" 
                    DataTextField="Mpharm_Pd_Name" DataValueField="Mpharm_Pd_Name">
                </asp:DropDownList>--%>
                 <asp:ListBox ID="PPS" runat="server" SelectionMode="Multiple" 
            DataSourceID="mendinemaster" DataTextField="Mpharm_Pd_Name" 
            DataValueField="Mpharm_Pd_Name" ></asp:ListBox>
                <asp:SqlDataSource ID="mendinemaster" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>" 
                    SelectCommand="select distinct Mpharm_Pd_Name from (SELECT mpharm_pd_name+'---'+cast(pack as varchar) Mpharm_Pd_Name 
                    FROM [ProductTransform] 
                   )a order by Mpharm_Pd_Name">
                </asp:SqlDataSource>
            </div>

            <div class="col-md-3">
                <label for="From Date">
                    Division:</label><br />
                <%--<asp:DropDownList ID="PPS" runat="server" DataSourceID="mendinemaster" 
                    DataTextField="Mpharm_Pd_Name" DataValueField="Mpharm_Pd_Name">
                </asp:DropDownList>--%>
                 <asp:ListBox ID="Division" runat="server" SelectionMode="Multiple">
                            <asp:ListItem>PHOENIX</asp:ListItem>
                            <asp:ListItem>EVA</asp:ListItem>
                            <asp:ListItem>CONCORD</asp:ListItem>
                        </asp:ListBox>
            </div>

             <div class="col-md-3">
                <label for="From Date">
                    Stock location:</label><br />
                <asp:ListBox ID="SKT" runat="server" SelectionMode="Multiple" DataSourceID="Stocklocation"
                            DataTextField="STOCKLOCATION" DataValueField="STOCKLOCATION"></asp:ListBox>
                        <asp:SqlDataSource ID="Stocklocation" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>"
                            SelectCommand="Select Depo STOCKLOCATION from vw_outsrandingdepo order by depo">
                        </asp:SqlDataSource>
            </div>
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="req"
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
