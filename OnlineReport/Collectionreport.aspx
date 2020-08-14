<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Collectionreport.aspx.cs" Inherits="OnlineReport_Collectionreport" %>

  <%@Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" 
      namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb"%>

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

            $('[id*=SKT]').multiselect({
                includeSelectAllOption: true,
                maxHeight: 300



            });

        });

    });



</script>
<script type="text/javascript">

    $(document).ready(function () {

        Sys.Application.add_load(function () {

            $('[id*=CollectionType]').multiselect({
                includeSelectAllOption: true,
                maxHeight: 300



            });

        });

    });



</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
    <div class="row">
    <div class="col-md-12">
    <div class="alert alert-info" role="alert">
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
            <div class="col-md-2">
                <label for="To Date">
                    To Date:</label><br />
                <asp:TextBox ID="txttodate" runat="server" autocomplete="off" onkeydown="return false;"
                    AutoCompleteType="Disabled"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txttodate" CssClass="req_css" ValidationGroup="req"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="txttodate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                    TargetControlID="txttodate" />
            </div>
            <div class="col-md-2">
                <label for="From Date">
                    Customer Code:</label><br />
                <asp:TextBox ID="Customercode" autocomplete="off" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <label for="From Date">
                    Bill No:</label><br />
                <asp:TextBox ID="BillNo" autocomplete="off" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <label for="From Date">
                    Stock location</label><br />
              <%--  <asp:DropDownList ID="SKT" runat="server" DataSourceID="Stocklocation" 
                    DataTextField="STOCKLOCATION" DataValueField="STOCKLOCATION">
                </asp:DropDownList>--%>
                 <asp:ListBox ID="SKT" runat="server" SelectionMode="Multiple" 
            DataSourceID="Stocklocation" DataTextField="STOCKLOCATION" 
            DataValueField="STOCKLOCATION"></asp:ListBox>
                <asp:SqlDataSource ID="Stocklocation" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>" 
                    SelectCommand="Select [STOCKLOCATION] from (SELECT [STOCKLOCATION] FROM [vw_stocklocation] 
                    )a
                    order by STOCKLOCATION">
                </asp:SqlDataSource>
            </div>
            <div class="col-md-2">
                <label for="From Date">
                    HQ:</label><br />
                <asp:TextBox ID="HQ" autocomplete="off" runat="server"></asp:TextBox>
            </div>
            
                 </div>
        <div class="row">
        <div class="col-md-2">
                <label for="From Date">
                    Collection Type:</label><br />
                 <asp:ListBox ID="CollectionType" runat="server" SelectionMode="Multiple" 
            >
                    <asp:ListItem>CHEQUE</asp:ListItem>
                    <asp:ListItem>CASH</asp:ListItem>
					<asp:ListItem>CCAV</asp:ListItem>
                   
                </asp:ListBox>
            </div>
                 <div class="col-md-3">
                <label for="From Date">
                   </label><br />
                <asp:DropDownList ID="PPS" runat="server" DataSourceID="mendinemaster" 
                    DataTextField="Mpharm_Pd_Name" DataValueField="Mpharm_Pd_Name" Visible="false"> 
                </asp:DropDownList>
                <asp:SqlDataSource ID="mendinemaster" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>" 
                    SelectCommand="select Mpharm_Pd_Name from (SELECT mpharm_pd_name+'---'+cast(pack as varchar) Mpharm_Pd_Name 
                    FROM [ProductTransform] 
                    union
                    select '')a order by case when Mpharm_Pd_Name='' then 0
					else 1 end">
                </asp:SqlDataSource>
            </div>
            <div class="col-md-2">
            <br />
            <asp:Button ID="Button1" Text="Show Report" runat="server" CssClass="btn btn-primary" ValidationGroup="req"
             OnClick="Button1_Click" />
            </div>
            <div class="col-md-5">
             <asp:Label ID="lblstatus" runat="server"></asp:Label>
            </div>

                 </div>
    </div>
    </div>
    </div>
       
            

   
    
   
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1100px">
    </rsweb:ReportViewer>
</asp:Content>

