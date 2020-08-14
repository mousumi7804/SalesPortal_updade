<%@ Page Title="Daily Sales Order" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="msrwiseorder.aspx.cs" Inherits="OnlineReport_msrwiseorder" %>

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
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.css" rel="stylesheet" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            Sys.Application.add_load(function () {

                $('[id*=OrderStatus]').multiselect({
                    includeSelectAllOption: true,
                    maxHeight: 300,
                    maxWidth: 200



                });

            });

        });



    </script>
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
            <%--
<div class="col-md-2">
<label for="info">Order Status:</label><br />
<asp:ListBox ID="OrderStatus" class="form-control" runat="server" SelectionMode="Multiple">
            <asp:ListItem>Pending</asp:ListItem>
            <asp:ListItem>Execute</asp:ListItem>
            <asp:ListItem>Cancel</asp:ListItem>
        </asp:ListBox>
</div>
<div class="col-md-2">
<label for="info">Product Name:</label><br />
<asp:ListBox ID="PPS" runat="server" class="form-control" SelectionMode="Multiple"
            DataSourceID="mendinemaster" DataTextField="Mpharm_Pd_Name" DataValueField="Mpharm_Pd_Name">
        </asp:ListBox>
</div>
            --%>
            <div class="col-md-2">
                <label for="info">
                    Employee List:</label><br />
                <asp:DropDownList ID="DropDownsubemplist" runat="server">
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="Button1" Text="Search" class="btn btn-primary center-block" runat="server"
                    ValidationGroup="req" OnClick="Search" />
            </div>
        </div>
        <br />
        <div class="row table-responsive">
            <div class="col-md-11">
                <asp:GridView ID="gvCustomers" runat="server" Width="100%" AutoGenerateColumns="false" 
                    CssClass="grid_css"  DataKeyNames="FKProdID,PKID,FKSeriesID,Customercode"
                      ShowFooter="true"
                     AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging"
                    >
                    <Columns>
                    <asp:TemplateField HeaderText="Action">
                                        
                                        <ItemTemplate>
                                            <asp:LinkButton ID="editmode" runat="server" onclick="editmode_Click" >Edit</asp:LinkButton>
                                            <asp:LinkButton ID="updaterow" runat="server" Visible="false" 
                                                onclick="updaterow_Click">Update</asp:LinkButton>
                                            <asp:LinkButton ID="cancelupdate" runat="server"  Visible="false" 
                                                onclick="cancelupdate_Click">Cancel</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                        <asp:BoundField DataField="FKProdID" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="FKProdID" Visible="false" ReadOnly="true" >
<HeaderStyle ForeColor="Black"></HeaderStyle>

<ItemStyle ForeColor="Black"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PKID" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="PKID" Visible="false" ReadOnly="true" >
<HeaderStyle ForeColor="Black"></HeaderStyle>

<ItemStyle ForeColor="Black"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="FKSeriesID" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="FKSeriesID" Visible="false" ReadOnly="true" >
<HeaderStyle ForeColor="Black"></HeaderStyle>

<ItemStyle ForeColor="Black"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="REMARKS">
                            <ItemTemplate>
                                <asp:Label ID="lblOPREMARKS" runat="server" Text='<%# Eval("Opremarks") %>'></asp:Label>
                                <asp:DropDownList ID="txtOPRemarks" Visible="false" DataSourceID="SqlDataSourceremarks" DataTextField="redescription"
                                    DataValueField="redescription" runat="server" AutoPostBack="true" OnSelectedIndexChanged="txtOPRemarks_SelectedIndexChanged">
                                </asp:DropDownList>

                                <asp:SqlDataSource ID="SqlDataSourceremarks" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>"
                                    SelectCommand="SELECT [redescription] FROM [orderremarks]"></asp:SqlDataSource>
                            </ItemTemplate>
                            <EditItemTemplate>
                                
                                
                                <%--<asp:TextBox ID="txtOPRemarks" runat="server" Text='<%# Eval("Opremarks") %>'></asp:TextBox>--%>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OTHER REMARKS">
                            <ItemTemplate>
                                <asp:Label ID="lblOPREMARKSONE" runat="server" Text='<%# Eval("otherremarks") %>'></asp:Label>
                                 <asp:TextBox ID="txtOPRemarksone" Visible="false" runat="server" placeholder="Enter Other Remarks"  Text='<%# Eval("otherremarks") %>'></asp:TextBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                               
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="BILLING">
                            <EditItemTemplate>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblbillfuturestatus" runat="server" Text='<%# Eval("billfuturestatus") %>'></asp:Label>
                                <asp:DropDownList ID="dropdownbillfuturestatus" runat="server" Visible="false" >
                                    <asp:ListItem>SELECT</asp:ListItem>
                                    <asp:ListItem>YES</asp:ListItem>
                                    <asp:ListItem>NO</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="Stocklocation" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="STOCK LOCATION" ReadOnly="true" />
                        <asp:BoundField DataField="OrderNo" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="ORDER NO" ReadOnly="true" />
                        <asp:BoundField DataField="EntryDate" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="ENTRYDATE" ReadOnly="true" />--%>
                        <asp:BoundField DataField="OrderPerson" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="ORDERPERSON" ReadOnly="true" >
<HeaderStyle ForeColor="Black"></HeaderStyle>

<ItemStyle ForeColor="Black"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="HQ" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="HQ" ReadOnly="true" />--%>
                        <asp:BoundField DataField="Customer" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="CUSTOMER" ReadOnly="true" >
<HeaderStyle ForeColor="Black"></HeaderStyle>

<ItemStyle ForeColor="Black"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="Customercode" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="CUSTOMER CODE" ReadOnly="true" />--%>
                        <%--<asp:BoundField DataField="ReferBy" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="REFERBY" ReadOnly="true" />
                        <asp:BoundField DataField="OrderStatus" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="ORDER STATUS" ReadOnly="true" />--%>
                        <asp:BoundField DataField="Productname" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="PRODUCT NAME" ReadOnly="true" >
<HeaderStyle ForeColor="Black"></HeaderStyle>

<ItemStyle ForeColor="Black"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="Packsize" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="PACK SIZE" ReadOnly="true" />--%>
                        <asp:BoundField DataField="Qtymade" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="QTYMADE" ReadOnly="true" >
<HeaderStyle ForeColor="Black"></HeaderStyle>

<ItemStyle ForeColor="Black"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="FreeQty" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="FREEQTY" ReadOnly="true" />--%>
                        <asp:BoundField DataField="GrossAMT" ItemStyle-ForeColor="Black" HeaderStyle-ForeColor="Black"
                            HeaderText="GROSSAMT" ReadOnly="true" >
<HeaderStyle ForeColor="Black"></HeaderStyle>

<ItemStyle ForeColor="Black"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="mendinemaster" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString_master %>"
        SelectCommand="select distinct Mpharm_Pd_Name from (SELECT mpharm_pd_name+'---'+cast(pack as varchar) Mpharm_Pd_Name 
                    FROM [ProductTransform] 
                    )a order by Mpharm_Pd_Name"></asp:SqlDataSource>
</asp:Content>
