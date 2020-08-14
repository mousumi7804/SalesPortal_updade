<%@ Page Title="Daily Sales Report User Wise" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="DailySalesReportUserWise.aspx.cs" Inherits="OnlineReport_DailySalesReport"
    EnableEventValidation="false" %>

<%@ Register Src="~/UserControl/report_viewer.ascx" TagName="reportviewer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function printDiv(divID) {

            //Get the HTML of div
            var divElements = document.getElementById(divID).innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPage;


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server" ID="pnl_report">
        <ContentTemplate>
         <br />

            <div>
                <asp:Label ID="lbldiv_div" runat="server" Text="Division:"></asp:Label>
                <asp:DropDownList ID="ddldivision" runat="server" AutoPostBack="True" OnDataBound="ddldivision_DataBound"
                    OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp
            &nbsp
            
                <asp:Label ID="lbldiv" runat="server" Text="Employee list:"></asp:Label>

                <asp:DropDownList ID="DropDownstocklocation" runat="server" AutoPostBack="True" OnDataBound="DropDownstocklocation_DataBound"
                    OnSelectedIndexChanged="DropDownstocklocation_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp
                  <asp:Label ID="Label1" runat="server" Text="Select Report:"></asp:Label>
            <asp:DropDownList ID="Ddlselect" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Ddlselect_SelectedIndexChanged">
                <asp:ListItem Value="SELECT">-SELECT-</asp:ListItem>
                <asp:ListItem Value="~/OnlineReport/StockReport.aspx">CLOSING STOCK</asp:ListItem>
                <asp:ListItem Value="~/OnlineReport/TransactionBillData.aspx">TRANSACTION BILL</asp:ListItem>
				<asp:ListItem Value="~/OnlineReport/Salesordertransaction.aspx">SALES ORDER TRANSACTION</asp:ListItem>
				 <asp:ListItem Value="~/OnlineReport/Craditnote.aspx">CREDIT NOTE REPORT</asp:ListItem>
				 <asp:ListItem Value="~/OnlineReport/contractual_ins.aspx">CONTRACTUAL & INISTITUTIONAL</asp:ListItem>
                </asp:DropDownList>
                <asp:HyperLink ID="HyperLinkdailyorder" runat="server" NavigateUrl="~/OnlineReport/msrwiseorder.aspx">View Daily Sales Order Report</asp:HyperLink>
               &nbsp
                 
                   
            </div>
            <br />
            <br />
            </div>
            <div style="width: 1300px;">
                <uc1:reportviewer ReportTitle="Default" ReportName="Default Name" runat="server"
                    ID="rpt_daily" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
