<%@ Page Title="Out Standings Report" Language="C#" MasterPageFile="~/OnlineReport/OReport.master" AutoEventWireup="true" CodeFile="OutStandingsReport.aspx.cs" Inherits="OnlineReport_OutStandingsReport" %>
<%@ Register Assembly="IdeaSparx.CoolControls.Web" Namespace="IdeaSparx.CoolControls.Web"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../Styles/Customstyle1.css" rel="stylesheet" type="text/css" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="container1">
    <div class="row">
    <div  class="col-md-12">
    <div class="panel panel-default">
    <div class="panel-body">
    <div class="row">
    <div  class="col-md-12 table-responsive">
   <cc1:CoolGridView ID="Grid_osreport"  runat="server"  CssClass="myGridStyle" AutoGenerateColumns="False" FixHeaders="true" Height="400px"
                                            >
                                            <AlternatingRowStyle Wrap="False" />
                                            <Columns>
                                                <asp:BoundField HeaderText="SalesInvNo" DataField="SalesInvNo" />
                                                <asp:BoundField HeaderText="SalesInvDate" DataField="SalesInvDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField HeaderText="NetAmt" DataField="NetAmt" />
                                                <asp:BoundField HeaderText="ReceivedAmt" DataField="ReceivedAmt" />
                                                <asp:BoundField HeaderText="DueAmt" DataField="DueAmt" />
                                                <asp:BoundField HeaderText="PDCAmt" DataField="PDCAmt" />
                                                <asp:BoundField HeaderText="Locality" DataField="Locality" />
                                                <asp:BoundField HeaderText="StockLocation" DataField="StockLocation" />
                                                <asp:BoundField HeaderText="ReferBy" DataField="ReferBy" />
                                                <asp:BoundField HeaderText="Description" DataField="Description" />
                                                <asp:BoundField HeaderText="Series" DataField="Series"  />
                                                <asp:BoundField HeaderText="Description" DataField="SeriesDescription" />
                                                <asp:BoundField HeaderText="Remarks" DataField="Remarks" />
                                                
                                            </Columns>
                                            <HeaderStyle Wrap="true" />
                                            <RowStyle Wrap="False" />
                                            <FooterStyle Font-Bold="true" />
                                        </cc1:CoolGridView>
    </div>
    </div>
      <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="exportbtn" runat="server" Text="Export to Excel" CssClass="btn btn-primary"
                                            OnClick="exportbtn_Click" />
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

