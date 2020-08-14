<%@ Page Title="Daily Sale Report" Language="C#" MasterPageFile="~/OnlineReport/OReport.master" AutoEventWireup="true" CodeFile="DailySalesReport.aspx.cs" Inherits="OnlineReport_DailySalesReport" EnableEventValidation="false"  %>
<%@ Register Src="~/UserControl/report_viewer.ascx" TagName="reportviewer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:UpdatePanel runat="server" ID="pnl_report">
            <ContentTemplate>
            <div class="row">
            <div class="col-md-1">
                <label for="info">Division:</label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="DropDowndiv" runat="server">
                    <asp:ListItem>Choose Division</asp:ListItem>
                    <asp:ListItem>MAD</asp:ListItem>
                    <asp:ListItem>EVA</asp:ListItem>
                    
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DropDowndiv" runat="server" ErrorMessage="*Requerd"  ForeColor="Red" InitialValue="Choose Division" ValidationGroup="req">
                    </asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <asp:Button ID="searchbtn" runat="server" Text="Search" ValidationGroup="req" 
                    CssClass="btn btn-primary" onclick="searchbtn_Click" />
            </div>
            </div>
                <div style="width:1300px;">
                    <uc1:reportviewer ReportTitle="Default" ReportName="Default Name" runat="server"
                        ID="rpt_daily" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

