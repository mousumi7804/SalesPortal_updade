<%@ Page Title="Sales Report" Language="C#" MasterPageFile="~/OnlineReport/OReport.master"
    AutoEventWireup="true" CodeFile="MonthlyReport.aspx.cs" Inherits="OnlineReport_StockReport" %>

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
                            Sales&nbsp; Report</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 table-responsive">
                        <div class="panel panel-default">
                            <div class=" panel-body">
                                <%--<div class="row">
                                    <div class="col-md-6">
                                       
                                        <label for="Info" id="lbldiv">
                                            Division:</label>
                                        <asp:DropDownList ID="DropDownstocklocation" runat="server">
                                            <asp:ListItem Value="0">[SELECT]</asp:ListItem>
                                            <asp:ListItem>PHOENIX</asp:ListItem>
                                            <asp:ListItem>EVA</asp:ListItem>
                                            <asp:ListItem>MAD</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp
                                         <label for="Info1">
                                            Month:</label>
                                        <asp:DropDownList ID="DdlMonth" runat="server">
                                            <asp:ListItem Value="0">[SELECT]</asp:ListItem>
                                            <asp:ListItem Value="January">JAN</asp:ListItem>
                                            <asp:ListItem Value="February">FEB</asp:ListItem>
                                            <asp:ListItem Value="March">MAR</asp:ListItem>
                                            <asp:ListItem Value="April">APR</asp:ListItem>
                                            <asp:ListItem Value="May">MAY</asp:ListItem>
                                            <asp:ListItem Value="June">JUN</asp:ListItem>
                                            <asp:ListItem Value="July">JUL</asp:ListItem>
                                            <asp:ListItem Value="August">AUG</asp:ListItem>
                                            <asp:ListItem Value="September">SEP</asp:ListItem>
                                            <asp:ListItem Value="October">OCT</asp:ListItem>
                                            <asp:ListItem Value="November">NOV</asp:ListItem>
                                            <asp:ListItem Value="December">DEC</asp:ListItem>
                                        </asp:DropDownList>
                                         &nbsp
                                         <label for="Info1">
                                            Year:</label>
                                         <asp:DropDownList ID="Ddlyear" runat="server">
                                            <asp:ListItem Value="0">[SELECT]</asp:ListItem>
                                            <asp:ListItem>2019</asp:ListItem>
                                            <asp:ListItem>2018</asp:ListItem>
                                            <asp:ListItem>2017</asp:ListItem>
                                          
                                        </asp:DropDownList>
                                        <asp:Button ID="btnstocksearch" runat="server" Text="Search" CssClass="btn btn-primary btn-sm"
                                            OnClick="btnstocksearch_Click" />
                                    </div>
                                </div>--%>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 table-responsive">
                                        <cc1:CoolGridView ID="GridView1" runat="server" FixHeaders="True" Height="400px"  CssClass="myGridStyle" ShowFooter="true"> </cc1:CoolGridView>
                                        

                                       <%-- <cc1:CoolGridView ID="Grid_sales" runat="server" CssClass="myGridStyle"
                                            FixHeaders="True" Height="400px" ShowFooter="True">
                                            
                                            <AlternatingRowStyle Wrap="False" />
                                           
                                        </cc1:CoolGridView>--%>
                                        <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
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
