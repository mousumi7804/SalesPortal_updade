<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="concordsecondarysalestatement.aspx.cs" Inherits="OnlineReport_concordsecondarysalestatement" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="IdeaSparx.CoolControls.Web" Namespace="IdeaSparx.CoolControls.Web"
    TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     
    <div class="page-header">
  <div class="pull-left">
  <h4>CONCORD SECONDARY SALES STATEMENT</h4>
  </div>
  <div class="pull-right">
  <h3 class="text-right"></h3>
  </div>
  <div class="clearfix"></div>
</div>

    <%--<asp:Label ID="Label1" runat="server" CssClass="control-label" AssociatedControlID="DropDownList1">FINANCIAL YEAR</asp:Label>--%>
    <div class="input-group">
    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" 
        DataSourceID="SqlDatafiscalyear" DataTextField="FinancialYear" 
        DataValueField="FinancialYear" >
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDatafiscalyear" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>" 
        SelectCommand="SELECT (CASE WHEN (MONTH(GETDATE())) &lt;= 3 THEN convert(varchar(4), YEAR(GETDATE())-1) + '-' + convert(varchar(4), YEAR(GETDATE())%100)    
                        ELSE convert(varchar(4),YEAR(GETDATE()))+ '-' + convert(varchar(4),(YEAR(GETDATE())%100)+1)END) FinancialYear  ">
    </asp:SqlDataSource>
     <span class="input-group-addon">-</span>
    <%-- <asp:Label ID="Label2" runat="server" CssClass="control-label" AssociatedControlID="DropDownList1">SELECT MONTH</asp:Label>--%>
    <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server">
        <asp:ListItem>JANUARY</asp:ListItem>
        <asp:ListItem>FEBRUARY</asp:ListItem>
        <asp:ListItem>MARCH</asp:ListItem>
        <asp:ListItem>APRIL</asp:ListItem>
        <asp:ListItem>MAY</asp:ListItem>
        <asp:ListItem>JUNE</asp:ListItem>
        <asp:ListItem>JULY</asp:ListItem>
        <asp:ListItem>AUGUST</asp:ListItem>
        <asp:ListItem>SEPTEMBER</asp:ListItem>
        <asp:ListItem>OCTOBER</asp:ListItem>
        <asp:ListItem>NOVEMBER</asp:ListItem>
        <asp:ListItem>DECEMBER</asp:ListItem>

    </asp:DropDownList>
    </div>
<asp:Button ID="Button1" style="margin-top:10px" Text="Show Report" class="btn btn-primary btn-sm"  runat="server" 
             OnClick="Button1_Click" />
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1300px">
    </rsweb:ReportViewer>
</asp:Content>