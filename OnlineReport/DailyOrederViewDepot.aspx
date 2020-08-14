<%@ Page Title="View Daily Order For Depot End" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeFile="DailyOrederViewDepot.aspx.cs" Inherits="OnlineReport_DailyOrederViewDepot" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../Styles/Customstyle1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        label
        {
            color: Black;
        }
    </style>
    <script type="text/javascript">
        function CheckValidate() {
            var datefrm = document.getElementById('<%=txtfrmdate.ClientID%>').value;
            var dateto = document.getElementById('<%=txttodate.ClientID%>').value;
            var dateParts = datefrm.split("/");
            var dateParts1 = dateto.split("/");

            // month is 0-based, that's why we need dataParts[1] - 1
            var dateObject = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);
            var dateObject1 = new Date(+dateParts1[2], dateParts1[1] - 1, +dateParts1[0]);
            var d = new Date(dateObject);
            var d2 = new Date(dateObject1);

            var datediff = Math.floor((Date.parse(d2) - Date.parse(d)) / 86400000);




            if (datediff < 0) {
                alert("TO Date Cannot Be Less Than From Date");

                document.getElementById('<%=txttodate.ClientID%>').value = null;

            }
            if (datediff > 15) {
                alert("Maximum 15 Days allowed");

                document.getElementById('<%=txttodate.ClientID%>').value = null;

            }




        }

        function CheckValidateone() {
            var datefrm = document.getElementById('<%=txtfrmdate.ClientID%>').value;
            var dateto = document.getElementById('<%=txttodate.ClientID%>').value;
            var dateParts = datefrm.split("/");
            var dateParts1 = dateto.split("/");

            // month is 0-based, that's why we need dataParts[1] - 1
            var dateObject = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);
            var dateObject1 = new Date(+dateParts1[2], dateParts[1] - 1, +dateParts1[0]);
            var d = new Date(dateObject);
            var d2 = new Date(dateObject1);

            var datediff = Math.floor((Date.parse(d2) - Date.parse(d)) / 86400000);


            if (datediff < 0) {
                alert("From Date Cannot Be Greater Than To Date");
                document.getElementById('<%=txtfrmdate.ClientID%>').value = null;


            }
            if (datediff > 15) {
                alert("Maximum 15 Days allowed");
                document.getElementById('<%=txtfrmdate.ClientID%>').value = null;


            }




        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="container1">
        <div class="row">
            <div class="col-md-2">
                <label for="info">
                    From Date:</label><br />
                <asp:TextBox ID="txtfrmdate" placeholder="Start" runat="server" autocomplete="off"
                    onkeydown="return false;" AutoCompleteType="Disabled"></asp:TextBox>
                <asp:RequiredFieldValidator ID="req" runat="server" ErrorMessage="*Required" ControlToValidate="txtfrmdate"
                    CssClass="req_css" ValidationGroup="req"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="txtfrmdate_CalendarExtender" OnClientDateSelectionChanged="CheckValidateone"
                    runat="server" Format="dd/MM/yyyy" TargetControlID="txtfrmdate" />
            </div>
            <div class="col-md-2">
                <label for="info">
                    To Date:</label><br />
                <asp:TextBox ID="txttodate" runat="server" placeholder="End" autocomplete="off" onkeydown="return false;"
                    AutoCompleteType="Disabled"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required"
                    ControlToValidate="txttodate" CssClass="req_css" ValidationGroup="req"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="txttodate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                    TargetControlID="txttodate" OnClientDateSelectionChanged="CheckValidate" />
            </div>
            <div class="col-md-2">
                <label for="info">
                    HQ:</label><br />
                <asp:DropDownList ID="DROPDOWNHQ" runat="server" DataSourceID="SqlDataHQ" 
                    DataTextField="Locality" DataValueField="Locality">
            </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataHQ" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>" 
                    SelectCommand="Select 'select' Locality union all SELECT distinct [Locality] FROM [vw_allcustomerlocality]">
                </asp:SqlDataSource>
            </div>
            
            <div class="col-md-2">
                <label for="info">
                    Customer Code:</label><br />
                <asp:TextBox ID="CCode" runat="server"></asp:TextBox>
            </div>
            
            <%--<div class="col-md-2">
                <label for="info">
                    Employee List:</label><br />
                <asp:DropDownList ID="DropDownsubemplist" runat="server">
                </asp:DropDownList>
            </div>--%>
            <div class="col-md-1">
                <br />
                <asp:Button ID="btnsearch" Text="Search" class="btn btn-primary center-block" runat="server"
                    ValidationGroup="req" OnClick="btnsearch_Click" />
                    &nbsp
                
            </div>
            <div class="col-md-1">
            <br />
            <asp:Button ID="btndownload" Text="Download" 
                    class="btn btn-primary center-block" runat="server"
                    ValidationGroup="req" onclick="btndownload_Click"  />
</div>
        </div>
        <div class="row">
            <div class=" col-md-11">
                <asp:GridView ID="gvorder" runat="server" Width="100%" AutoGenerateColumns="false"
                    CssClass="grid_css" >
                    <Columns>
                        <asp:BoundField DataField="ORDERPERSON" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="ORDERPERSON" ReadOnly="true" />
                        <asp:BoundField DataField="HQ" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="HQ" ReadOnly="true" />
                        <asp:BoundField DataField="CUSTOMERNAME" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="CUSTOMERNAME" ReadOnly="true" />
                            <asp:BoundField DataField="CUSTOMERCODE" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="CUSTOMERCODE" ReadOnly="true" />
                        <asp:BoundField DataField="PRODUCTNAME" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="PRODUCTNAME" ReadOnly="true" />
                        <asp:BoundField DataField="QTYMADE" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="QTYMADE" ReadOnly="true" />
                        <asp:BoundField DataField="GROSSAMT" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="GROSSAMT" ReadOnly="true" />
                        <asp:BoundField DataField="REMARKS" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="REMARKS" ReadOnly="true" />
                        <asp:BoundField DataField="OTHERREMARKS" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="OTHERREMARKS" ReadOnly="true" />
                        <asp:BoundField DataField="BILLING" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="BILLING" ReadOnly="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    </ContentTemplate>
     <Triggers>
            <asp:PostBackTrigger ControlID="btndownload" />

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
