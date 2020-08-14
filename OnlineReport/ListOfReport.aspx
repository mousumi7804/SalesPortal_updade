<%@ Page Title="List Of Report" Language="C#" MasterPageFile="~/OnlineReport/OReport.master" AutoEventWireup="true"
    CodeFile="ListOfReport.aspx.cs" Inherits="OnlineReport_ListOfReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/Customstyle1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #image
        {
            line-height: .5em;
            list-style-position: inside;
            list-style-image: url(../Image/reporticon2.png);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container1">
        <div class="row">
            <div class=" col-md-9">
                <h3>
                    Choose Report Here</h3>
            </div>
        </div>
        <div class="row">
            <div class=" col-md-5">
                <div class="panel panel-default">
                    <div class=" panel-body">
                        <div class="row">
                            <div class="col-md-12">
                               <label for="info">List Of Reports</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <ul>
                                    
                                    <li>
                                       <asp:HyperLink ID="HLstockreport" runat="server" NavigateUrl="~/OnlineReport/StockReport.aspx">Daily Stock Report</asp:HyperLink>
                                    </li>
                                     
                                  
                                     <li>
                                       <asp:HyperLink ID="HldailysaleuserWise" runat="server" NavigateUrl="~/OnlineReport/DailySalesReportAll.aspx">Daily Sales Report </asp:HyperLink>
                                    </li>

                                     <li>
                                       <asp:HyperLink ID="Hlcraditnote" runat="server" NavigateUrl="~/OnlineReport/Craditnote.aspx">Creditnote Report </asp:HyperLink>
                                    </li>
                                     
                                    <li>
                                       <asp:HyperLink ID="Hlsalesordertransaction" runat="server" NavigateUrl="~/OnlineReport/Salesordertransaction.aspx">Sales Order Transaction </asp:HyperLink>
                                    </li>
                                    <li>
                                       <asp:HyperLink ID="HlSalesDelevaryStatus" runat="server" NavigateUrl="~/OnlineReport/SalesDelevaryStatus.aspx">Sales Delivary Status </asp:HyperLink>
                                    </li>
                                     <li>
                                       <asp:HyperLink ID="Hloutstanding" runat="server" NavigateUrl="~/OnlineReport/outstandingreport.aspx">Outstanding Report</asp:HyperLink>
                                    </li>
                                    <li>
                                       <asp:HyperLink ID="HlTransactionbilltrends" runat="server" NavigateUrl="~/OnlineReport/Transactionbilltrends.aspx">Transaction Bill Trends</asp:HyperLink>
                                    </li>
									<li>
                                       <asp:HyperLink ID="HlDepotwiseProductSale" runat="server" NavigateUrl="~/OnlineReport/DepotwiseProductSale.aspx">Depot wise Product Sale</asp:HyperLink>
                                    </li>
                                     <li>
                                       <asp:HyperLink ID="Hltransactionalbilldata" runat="server" NavigateUrl="~/OnlineReport/TransactionBillData.aspx">Transactional Bill Data </asp:HyperLink>
                                    </li>
									<li>
                                       <asp:HyperLink ID="Hlyearlyproductwisesalescomparison" runat="server" NavigateUrl="~/OnlineReport/MonthyearwiseProductSales.aspx">Yearly Product Wise Sales Comparison</asp:HyperLink>
                                    </li>									
									<li>
                                       <asp:HyperLink ID="Hlmadsecondarysalestatement" runat="server" NavigateUrl="~/OnlineReport/Madsecondarysalestatementt.aspx">MAD Secondary Sales Statement</asp:HyperLink>
                                    </li>
									<li>
                                       <asp:HyperLink ID="Hlevasecondarysalestatement" runat="server" NavigateUrl="~/OnlineReport/Secondarysaleeva.aspx">EVA Secondary Sales Statement</asp:HyperLink>
                                    </li>
									<li>
                                       <asp:HyperLink ID="Hlconsecondarysalestatement" runat="server" NavigateUrl="~/OnlineReport/concordsecondarysalestatement.aspx">Concord Secondary Sales Statement</asp:HyperLink>
                                    </li>
									<li>
                                       <asp:HyperLink ID="Hlphoenixsecondarysalestatement" runat="server" NavigateUrl="~/OnlineReport/phoenixsecondarysalestatement.aspx">Phoenix Secondary Sales Statement</asp:HyperLink>
                                    </li>
								<!--	<li>
                                       <asp:HyperLink ID="Contrat_ins" runat="server" NavigateUrl="~/OnlineReport/contractual_ins.aspx">Contractual & Institutional Bill Data </asp:HyperLink>
                                    </li>--!>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
