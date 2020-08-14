<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineReport/MasterPage.master" AutoEventWireup="true" CodeFile="LeadTimeReport.aspx.cs" Inherits="OnlineReport_LeadTimeReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


   
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />


    <link href="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />
    <link href="//cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />

        <div style="height: 50px; text-align: center;">
            <h2>Lead Time Report</h2>
        </div>
        <div style="text-align: right; padding-right: 50px; height: 50px;">
            <asp:LinkButton ID="lnklogout" runat="server" Text="Logout" OnClick="lnklogout_Click"></asp:LinkButton>
        </div>


        <div style="padding-top: 10px; padding-bottom: 40px;">
            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
        </div>

        <div id="adminsearch" style="visibility: visible">
            <table style="width: 100%">
                <tr>
                    <td colspan="2" style="text-align: center;">PO Date</td>
                    <td style="width: 15%">Party Name</td>
                    <td style="width: 15%">Item Name</td>
                    <td colspan="2" style="text-align: center;">GRN Date</td>
                    <td colspan="2" style="text-align: center;">Invoice Date</td>
                </tr>
                <tr>
                    <td style="width: 12%">From &nbsp;
                         <input type="text" id="dtFromDate_PO" name="_dtFromDate_PO" />
                    </td>
                    <td style="width: 12%">To &nbsp;
                         <input type="text" id="dtToDate_PO" name="_dtToDate_PO" />
                    </td>

                    <td style="width: 15%">
                        <asp:ListBox ID="lbPartyName" runat="server" SelectionMode="Multiple" Width="75%"></asp:ListBox>
                    </td>
                    <td style="width: 15%">
                        <asp:ListBox ID="lbItemName" runat="server" SelectionMode="Multiple" Width="75%"></asp:ListBox>
                    </td>

                    <td style="width: 12%">From &nbsp;
                         <input type="text" id="dtFromDate_GRN" name="_dtFromDate_GRN" />
                    </td>
                    <td style="width: 12%">To &nbsp;
                         <input type="text" id="dtToDate_GRN" name="_dtToDate_GRN" />
                    </td>

                    <td style="width: 12%">From &nbsp;
                         <input type="text" id="dtFromDate_Invoice" name="_dtFromDate_Invoice" />
                    </td>
                    <td style="width: 12%">To &nbsp;
                         <input type="text" id="dtToDate_Invoice" name="_dtToDate_Invoice" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 40px;" colspan="2"></td>
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Width="90%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnSearch_Click" />
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnReset" runat="server" Text="Reset" Width="90%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnReset_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnExporttoCSV" runat="server" Text="Export to CSV" Width="90%" Height="35px" BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" OnClick="btnExporttoCSV_Click" />
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div style="height: 30px;">
        </div>

     <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1100px">
         <LocalReport ReportPath="rdlcs\Report_FinalProductStock.rdlc">
            </LocalReport>
    </rsweb:ReportViewer>

       <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%" Height="723px" AsyncRendering="False" InteractivityPostBackMode="AlwaysSynchronous" PageCountMode="Actual" ShowBackButton="False" ShowDocumentMapButton="False" ShowExportControls="False" ShowFindControls="False" ShowParameterPrompts="False" ShowPrintButton="False" ShowRefreshButton="False" ShowZoomControl="False">
            <LocalReport ReportPath="rdlcs\Report_FinalProductStock.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>--%>
    </form>
</body>
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

<%--<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
<script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
<script src="//cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
    type="text/javascript"></script>

<script type="text/javascript">  
    $(function () {
        $("#dtFromDate_PO").datepicker();
        $("#dtToDate_PO").datepicker();
        $("#dtFromDate_GRN").datepicker();
        $("#dtToDate_GRN").datepicker();
        $("#dtFromDate_Invoice").datepicker();
        $("#dtToDate_Invoice").datepicker();
    });
</script>

<script type="text/javascript">  
    function pageLoad(sender, args) {
        $(document).ready(function () {
            $('[id*=lbItemName]').multiselect({
                includeSelectAllOption: true,
                maxHeight: 400,
                enableFiltering: true,
                enableCaseInsensitiveFiltering: true
            });
            $('[id*=lbPartyName]').multiselect({
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

