<%@ Page Title="Stock Report" Language="C#" MasterPageFile="~/OnlineReport/OReport.master"
    AutoEventWireup="true" CodeFile="StockReport.aspx.cs" Inherits="OnlineReport_StockReport" %>

<%@ Register Assembly="IdeaSparx.CoolControls.Web" Namespace="IdeaSparx.CoolControls.Web"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<link href="../Styles/Customstyle1.css" rel="stylesheet" type="text/css" />--%>
    <style type="text/css">
        body
        {
            font: 12px verdana;
        }
        
        .myGridStyle
        {
            border-collapse: collapse;
        }
        
        .myGridStyle tr th
        {
            padding: 4px;
            color: white;
            border: 1px solid black;
        }
        .myGridStyle th
        {
            background-color: #00C157;
        }
        
        .myGridStyle tr:nth-child(even)
        {
            background-color: white;
        }
        
        .myGridStyle tr:nth-child(odd)
        {
            background-color: #dce5f2;
        }
        
        .myGridStyle td
        {
            border: 1px solid black;
            padding: 8px;
        }
        
        .myGridStyle tr:last-child td
        {
        }
    </style>
    <style type="text/css">
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container1">
                <div class="row">
                    <div class="col-md-11">
                        <h3>
                            Stock Report</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 table-responsive">
                        <div class="panel panel-default">
                            <div class=" panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label for="Info">
                                            Stock Location:</label>
                                        <asp:DropDownList ID="DropDownstocklocation" runat="server">
                                        </asp:DropDownList>
                                        &nbsp
                                        <asp:Button ID="btnstocksearch" runat="server" Text="Search" CssClass="btn btn-primary btn-sm"
                                            OnClick="btnstocksearch_Click" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 table-responsive">
                                        <cc1:CoolGridView ID="Grid_stockdetails" runat="server" CssClass="myGridStyle" AutoGenerateColumns="False"
                                            FixHeaders="true" Height="400px" ShowFooter="true">
                                            <AlternatingRowStyle Wrap="False" />
                                            <Columns>
                                                <asp:BoundField HeaderText="DIVISION" DataField="DIVISION" />
                                                <asp:BoundField HeaderText="Depot" DataField="Depot" />
                                                <asp:BoundField HeaderText="STK" DataField="stk" />
                                                <asp:BoundField HeaderText="Product Name" DataField="ProductName" />
                                                <asp:BoundField HeaderText="Pack" DataField="Pack" />
                                                <asp:BoundField HeaderText="BATCH" DataField="BATCH" />
                                                <asp:BoundField HeaderText="MFG Date" DataField="MFGDate" />
                                                <asp:BoundField HeaderText="EXP Date" DataField="EXPDate" />
                                                <asp:BoundField HeaderText="Closing Balance" DataField="ClosingBalance" />
                                                <asp:BoundField HeaderText="NRV" DataField="NRV" />
                                                <asp:BoundField HeaderText="Stock Value" DataField="Stock Value" DataFormatString="{0:N2}" />
                                                <asp:BoundField HeaderText="Days of Exp" DataField="Days of Exp" />
                                                <asp:BoundField HeaderText="Type" DataField="Type" />
                                                <asp:BoundField HeaderText="Days of from Manufacturing" DataField="Days of from Manufacturing" />
                                                <asp:BoundField HeaderText="Weighted Days of Manufacturing" DataField="Weighted Days of Manufacturing" />
                                            </Columns>
                                            <HeaderStyle Wrap="true" />
                                            <RowStyle Wrap="False" />
                                            <FooterStyle Font-Bold="true" />
                                        </cc1:CoolGridView>
                                    </div>
                                </div>
                                <div class="loading" align="center">
                                    <img src="../Image/wait2.gif" alt="" />
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="exportbtn" runat="server" Text="Export to Excel" CssClass="btn btn-primary"
                                            OnClick="exportbtn_Click" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-11">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="exportbtn" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
