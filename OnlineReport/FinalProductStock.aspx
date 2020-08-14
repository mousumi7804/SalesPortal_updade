<%@ Page Title="Final Product Stock Report" Language="C#" AutoEventWireup="true" MasterPageFile="~/OnlineReport/MasterPage.master" CodeFile="FinalProductStock.aspx.cs" Inherits="OnlineReport_FinalProductStock" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">




   
    
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />


    <link href="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />
    <link href="//cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />


        <div style="height:50px; text-align:center;">
            <h2>Final Product Stock Report</h2>
        </div>
      <%--  <div style="text-align:right; padding-right:50px;height:50px;">
            <asp:LinkButton ID="lnklogout" runat="server" Text="Logout"></asp:LinkButton>
        </div>--%>


        <div style="padding-top:10px; padding-bottom:40px;">
            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
        </div>

        <div id="adminsearch" style="visibility:visible">
            <table style="width:100%">
                <tr>
    
                     <td colspan="2" style="text-align:center; width:20% ">Stock Date</td>
                    <td style="width:20%">Company</td>
                    <td style="width:20%">Item Name</td>
                    <td style="width:20%">Godown Name</td>
                    <td style="width:20%">Stock Group</td>
                </tr>
                <tr>
                     <td style="width:10%">
                       From &nbsp;
                         <input type="text" id="dtFromDate_StockDate" name="_dtFromDate_StockDate" />  
                    </td>
                    <td style="width:10%">
                        To &nbsp;
                         <input type="text" id="dtToDate_StockDate"  name="_dtToDate_StockDate" />
                    </td>
                    <td style="width:20%">
                         <asp:ListBox ID="lbCompany" runat="server" SelectionMode="Multiple"  Width="75%"></asp:ListBox>
                    </td>
                    <td style="width:20%">
                        <asp:ListBox ID="lbItemName" runat="server" SelectionMode="Multiple"  Width="75%"></asp:ListBox>
                    </td>
                    <td style="width:20%">
                         <asp:ListBox ID="lbGodownName" runat="server" SelectionMode="Multiple"  Width="75%"></asp:ListBox>
                    </td>
                    <td style="width:20%">
                        <asp:ListBox ID="lbStockGroup" runat="server" SelectionMode="Multiple"  Width="75%"></asp:ListBox>
                    </td>
                </tr>

                <tr>
                    <td style="text-align:center">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Width="90%" Height="35px"  BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnSearch_Click"  />
                    </td>
                    <td style="text-align:center">
                        <asp:Button ID="btnReset" runat="server" Text="Reset" Width="90%" Height="35px"  BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnReset_Click" />
                    </td>
                    <td >
                        <asp:Button ID="btnExporttoCSV" runat="server" Text="Export to CSV" Width="90%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnExporttoCSV_Click"/>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div style="height:30px;">
        </div>

      
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%" Height="723px" AsyncRendering="False" InteractivityPostBackMode="AlwaysSynchronous" PageCountMode="Actual" ShowBackButton="False" ShowDocumentMapButton="False" ShowExportControls="False" ShowFindControls="False" ShowParameterPrompts="False" ShowPrintButton="False" ShowRefreshButton="False" ShowZoomControl="False">
            <LocalReport ReportPath="rdlcs\Report_FinalProductStock.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
   


<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

<%--<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
<script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <%--https://github.com/davidstutz/bootstrap-multiselect--%>
<script src="//cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
    type="text/javascript"></script>

<script type="text/javascript">  
    $(function () {
        $("#dtFromDate_StockDate").datepicker();
        $("#dtToDate_StockDate").datepicker();
    });
</script>

    <script type="text/javascript">  
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $('[id*=lbCompany]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 400,
                    enableFiltering: true,
                    enableCaseInsensitiveFiltering: true
                });
                $('[id*=lbItemName]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 400,
                    enableFiltering: true,
                    enableCaseInsensitiveFiltering: true
                });
                $('[id*=lbGodownName]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 400,
                    enableFiltering: true,
                    enableCaseInsensitiveFiltering: true
                });
                $('[id*=lbStockGroup]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 400,
                    enableFiltering: true,
                    enableCaseInsensitiveFiltering: true
                });
                setTimeout(function () {
                    window.document.getElementById('wp').style.display = 'none';
                    window.document.getElementById('searchp').style.display = '';
                }, 100);
            });
        }
    </script>



</asp:Content>
