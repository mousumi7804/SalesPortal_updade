<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="outstandingreport.aspx.cs" Inherits="OnlineReport_outstandingreport" %>

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
            color: Black;
        }
        .ui-autocomplete
        {
            max-height: 300px;
            overflow-y: auto;
            overflow-x: hidden;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {

            Sys.Application.add_load(function () {

                $('[id*=SKT]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    numberDisplayed: 1



                });

            });

        });



    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            Sys.Application.add_load(function () {

                $('[id*=NPANONNPA]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    numberDisplayed: 1


                });

            });

        });



    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            Sys.Application.add_load(function () {

                $('[id*=Division]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    numberDisplayed: 1


                });

            });

        });



    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            Sys.Application.add_load(function () {

                $('[id*=partytype]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    numberDisplayed: 1



                });

            });

        });



    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            Sys.Application.add_load(function () {

                $('[id*=status]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    numberDisplayed: 1


                });

            });

        });



    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            Sys.Application.add_load(function () {

                $('[id*=HQ]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    numberDisplayed: 1


                });

            });

        });



    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            Sys.Application.add_load(function () {

                $('[id*=ZSM]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    numberDisplayed: 1


                });

            });

        });



    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            Sys.Application.add_load(function () {

                $('[id*=RSM]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    numberDisplayed: 1


                });

            });

        });



    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            Sys.Application.add_load(function () {

                $('[id*=DSO]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    numberDisplayed: 1


                });

            });

        });



    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            Sys.Application.add_load(function () {

                $('[id*=ReferBy]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    numberDisplayed: 1


                });

            });

        });



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="alert alert-info" role="alert">
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
                        <label for="To Date">
                            To Date:</label><br />
                        <asp:TextBox ID="txttodate" runat="server" Width="100%" autocomplete="off" onkeydown="return false;"
                            AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:CalendarExtender ID="txttodate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txttodate" />
                    </div>
                    <div class="col-md-2">
                        <label for="From Date">
                            ZSM/DGM:</label><br />
                        <asp:ListBox ID="ZSM" runat="server" SelectionMode="Multiple" Width="100%" DataSourceID="ZSML"
                            DataTextField="ZSM" DataValueField="ZSM"></asp:ListBox>
                        <asp:SqlDataSource ID="ZSML" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>"
                            SelectCommand="select distinct CASE WHEN ZSM IS NULL THEN 'REST' 
WHEN ZSM ='' THEN 'REST' 
                            ELSE ZSM END ZSM
                            from (SELECT distinct [ZSM NAME] ZSM  FROM [MendineMaster].[dbo].[OutStanding_Hierarchy]
                            union all
                            Select 'REST' ZSM )a ORDER BY ZSM"></asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="From Date">
                            RSM/DRSM:</label><br />
                        <asp:ListBox ID="RSM" runat="server" Width="100%" SelectionMode="Multiple" DataSourceID="RSML"
                            DataTextField="RSM" DataValueField="RSM"></asp:ListBox>
                        <asp:SqlDataSource ID="RSML" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>"
                            SelectCommand="select distinct CASE WHEN RSM IS NULL THEN 'REST' 
WHEN RSM ='' THEN 'REST' 
                            ELSE RSM END RSM
                            from (SELECT distinct [RSM NAME] RSM  FROM [MendineMaster].[dbo].[OutStanding_Hierarchy]
                            union all
                            Select 'REST' RSM
							union all
                            Select 'SANDIPAN SENGUPTA' RSM )a ORDER BY RSM"></asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="From Date">
                            DSO/DSM:</label><br />
                        <asp:ListBox ID="DSO" runat="server" Width="100%" SelectionMode="Multiple" DataSourceID="DSOL"
                            DataTextField="DSO" DataValueField="DSO"></asp:ListBox>
                        <asp:SqlDataSource ID="DSOL" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>"
                            SelectCommand="select distinct CASE WHEN DSO IS NULL THEN 'REST' 
WHEN DSO ='' THEN 'REST' 
                            ELSE DSO END DSO
                            from (SELECT distinct [DSO NAME] DSO  FROM [MendineMaster].[dbo].[OutStanding_Hierarchy]
                            union all
                            Select 'REST' DSO
							union all
                            Select 'DIPANKAR BHATTACHARJEE' DSO
							union all
                            Select 'PRADIP JASH' DSO
							union all
                            Select 'RAHUL DASGUPTA' DSO
							 )a ORDER BY DSO"></asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="From Date">
                            ReferBy:</label><br />
                        <asp:ListBox ID="ReferBy" runat="server" Width="100%" SelectionMode="Multiple" DataSourceID="ReferByl"
                            DataTextField="ReferBy" DataValueField="ReferBy"></asp:ListBox>
                        <asp:SqlDataSource ID="ReferByl" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>"
                            SelectCommand="Select distinct upper([ReferBy]) ReferBy from (SELECT [ReferBy] FROM [behala].[dbo].[tblReferBy_Mas]
union all
SELECT [ReferBy] FROM [DUMDUM].[dbo].[tblReferBy_Mas]
union all
SELECT [ReferBy] FROM [Lifecare].[dbo].[tblReferBy_Mas]
union all
SELECT [ReferBy] FROM [Malda].[dbo].[tblReferBy_Mas]
union all
SELECT [ReferBy] FROM [Midnapur].[dbo].[tblReferBy_Mas]
union all
SELECT [ReferBy] FROM [NewAlipore].[dbo].[tblReferBy_Mas]
union all
SELECT [MSR_MFSO Name] [ReferByLocality] FROM [MendineMaster].[dbo].[kolkata_outstanding]
union all
Select '(AZAMGARH)'
union all
Select '(DARBHANGA)'
union all
Select '(KOLKATA)'
union all
Select '(PATNA)'
union all
Select '(SILDA)'
union all
Select '(VARANASI_3)'
union all
Select 'RAVI PRAKASH DUBEY/PUNIT SINGH')a"></asp:SqlDataSource>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label for="From Date">
                            Customer Code:</label><br />
                        <asp:TextBox ID="Customercode" runat="server" Width="100%" onClick="this.value=''"></asp:TextBox>
                        <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
                        <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
                        <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
                            rel="Stylesheet" type="text/css" />
                        <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
                            rel="stylesheet" type="text/css" />
                        <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
                            type="text/javascript"></script>
                        <script type="text/javascript">



                            $(document).ready(function () {
                                var prm = Sys.WebForms.PageRequestManager.getInstance();
                                prm.add_initializeRequest(InitializeRequest);
                                prm.add_endRequest(EndRequest);

                                // Place here the first init of the autocomplete
                                filldata1();
                            });
                            function InitializeRequest(sender, args) {
                            }

                            function EndRequest(sender, args) {
                                // after update occur on UpdatePanel re-init the Autocomplete
                                filldata1();
                            }

                            function filldata1() {
                                $("#<%=Customercode.ClientID %>").autocomplete({
                                    source: function (request, response) {
                                        $.ajax({
                                            url: '<%=ResolveUrl("~/GetInvoiceWebService.asmx/Getcustomer") %>',
                                            data: "{ 'searchTerm': '" + request.term + "'}",
                                            dataType: "json",
                                            type: "POST",
                                            contentType: "application/json; charset=utf-8",
                                            success: function (data) {
                                                response($.map(data.d, function (item) {
                                                    return {
                                                        label: item,
                                                        val: item
                                                    }
                                                }))
                                            },
                                            error: function (response) {
                                                alert(response.responseText);
                                            },
                                            failure: function (response) {
                                                alert(response.responseText);
                                            }
                                        });
                                    },
                                    select: function (e, i) {



                                        $("#<%=Customercode.ClientID %>").val(i.item.val);

                                    },
                                    minLength: 1
                                });
                            }

        
                        </script>
                    </div>
                    <div class="col-md-2">
                        <label for="From Date">
                            Invoice No:</label><br />
                        <asp:TextBox ID="BillNo" Width="100%" runat="server" onClick="this.value=''"></asp:TextBox>
                        <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
                        <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
                        <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
                            rel="Stylesheet" type="text/css" />
                        <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
                            rel="stylesheet" type="text/css" />
                        <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
                            type="text/javascript"></script>
                        <script type="text/javascript">



                            $(document).ready(function () {
                                var prm = Sys.WebForms.PageRequestManager.getInstance();
                                prm.add_initializeRequest(InitializeRequest);
                                prm.add_endRequest(EndRequest);

                                // Place here the first init of the autocomplete
                                filldata();
                            });
                            function InitializeRequest(sender, args) {
                            }

                            function EndRequest(sender, args) {
                                // after update occur on UpdatePanel re-init the Autocomplete
                                filldata();
                            }

                            function filldata() {
                                $("#<%=BillNo.ClientID %>").autocomplete({
                                    source: function (request, response) {
                                        $.ajax({
                                            url: '<%=ResolveUrl("~/GetInvoiceWebService.asmx/GetInvoice") %>',
                                            data: "{ 'searchTerm': '" + request.term + "'}",
                                            dataType: "json",
                                            type: "POST",
                                            contentType: "application/json; charset=utf-8",
                                            success: function (data) {
                                                response($.map(data.d, function (item) {
                                                    return {
                                                        label: item,
                                                        val: item
                                                    }
                                                }))
                                            },
                                            error: function (response) {
                                                alert(response.responseText);
                                            },
                                            failure: function (response) {
                                                alert(response.responseText);
                                            }
                                        });
                                    },
                                    select: function (e, i) {



                                        $("#<%=BillNo.ClientID %>").val(i.item.val);

                                    },
                                    minLength: 1
                                });
                            }

        
                        </script>
                    </div>
                    <div class="col-md-2">
                        <label for="Stock">
                            Stock location:</label><br />
                        <asp:ListBox ID="SKT" runat="server" SelectionMode="Multiple" DataSourceID="Stocklocation"
                            DataTextField="STOCKLOCATION" DataValueField="STOCKLOCATION"></asp:ListBox>
                        <asp:SqlDataSource ID="Stocklocation" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>"
                            SelectCommand="Select Depo STOCKLOCATION from vw_outsrandingdepo order by depo">
                        </asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="From Date">
                            HQ:</label><br />
                        <asp:ListBox ID="HQ" runat="server" SelectionMode="Multiple" DataSourceID="HQL" DataTextField="HQ"
                            DataValueField="HQ"></asp:ListBox>
                        <asp:SqlDataSource ID="HQL" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>"
                            SelectCommand="Select distinct upper([Locality]) HQ from (SELECT [Locality] FROM [MendineMaster].[dbo].[vw_allcustomerlocality]
union all
SELECT [MSR_MFSO HQ] FROM [MendineMaster].[dbo].[kolkata_outstanding])a
order by HQ"></asp:SqlDataSource>
                    </div>
                    <div class="col-md-2">
                        <label for="From Date">
                            NPA/NON NPA:</label><br />
                        <asp:ListBox ID="NPANONNPA" runat="server" SelectionMode="Multiple">
                            <asp:ListItem>NPA</asp:ListItem>
                            <asp:ListItem>NON NPA</asp:ListItem>
                        </asp:ListBox>
                        <asp:SqlDataSource ID="mendinemaster" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>"
                            SelectCommand="select distinct Mpharm_Pd_Name from (SELECT mpharm_pd_name+'---'+cast(pack as varchar) Mpharm_Pd_Name 
                    FROM [ProductTransform] 
                   )a order by Mpharm_Pd_Name"></asp:SqlDataSource>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <label for="From Date">
                            Division:</label><br />
                        <asp:ListBox ID="Division" runat="server" SelectionMode="Multiple">
                            <asp:ListItem>PHOENIX</asp:ListItem>
                            <asp:ListItem>EVA</asp:ListItem>
                            <asp:ListItem>CONCORD</asp:ListItem>
                        </asp:ListBox>
                    </div>
                    <div class="col-md-2">
                        <label for="From Date">
                            Party Type:</label><br />
                        <asp:ListBox ID="partytype" runat="server" SelectionMode="Multiple">
                            <asp:ListItem>RETAILER</asp:ListItem>
                            <asp:ListItem>WHOLESALER</asp:ListItem>
                            <asp:ListItem>INSTITUTION</asp:ListItem>
                        </asp:ListBox>
                    </div>
                    <div class="col-md-2">
                        <label for="From Date">
                            Status:</label><br />
                        <asp:ListBox ID="status" runat="server" SelectionMode="Multiple">
                            <asp:ListItem>DEAD</asp:ListItem>
                            <asp:ListItem>DYING</asp:ListItem>
                            <asp:ListItem>SICK</asp:ListItem>
                            <asp:ListItem>HEALTHY</asp:ListItem>
                        </asp:ListBox>
                    </div>
                    <div class="col-md-2">
                        <br />
                        <asp:HiddenField ID="hfCustomerId" runat="server" />
                        <asp:Button ID="Button1" Text="Show Report" runat="server" CssClass="btn btn-primary"
                            OnClick="Button1_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-5">
                        <asp:Label ID="lblmsg" runat="server" Visible="true"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1370px">
    </rsweb:ReportViewer>
</asp:Content>
