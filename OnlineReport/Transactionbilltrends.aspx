<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Transactionbilltrends.aspx.cs" Inherits="OnlineReport_Transactionbilltrends" %>

<%@ Register Src="~/UserControl/report_viewer.ascx" TagName="reportviewer" TagPrefix="uc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="IdeaSparx.CoolControls.Web" Namespace="IdeaSparx.CoolControls.Web"
    TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
                        <asp:CalendarExtender ID="txtfrmdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtfrmdate" />
                    </div>
                    <div class="col-md-2">
                    <br />
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
