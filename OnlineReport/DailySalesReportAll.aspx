<%@ Page Title="Daily Sales Report User Wise" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DailySalesReportAll.aspx.cs" Inherits="OnlineReport_DailySalesReport" EnableEventValidation="false"  %>
<%@ Register Src="~/UserControl/report_viewer.ascx" TagName="reportviewer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    function printDiv(divID) {

        //Get the HTML of div
        var divElements = document.getElementById(divID).innerHTML;
        //Get the HTML of whole page
        var oldPage = document.body.innerHTML;

        //Reset the page's HTML with div's HTML only
        document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";

        //Print Page
        window.print();

        //Restore orignal HTML
        document.body.innerHTML = oldPage;


    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


<div class="row">
                                    <div class="col-md-6">
                                        <asp:Label ID="lbldiv" runat="server" Text="Division:"></asp:Label>
                                       
                                        <asp:DropDownList ID="DropDownstocklocation" runat="server">
                                            <asp:ListItem Value="0">[SELECT]</asp:ListItem>
                                            <asp:ListItem>PHOENIX</asp:ListItem>
                                            <asp:ListItem>EVA</asp:ListItem>
                                            <asp:ListItem>MAD</asp:ListItem>
											 <asp:ListItem>ROD</asp:ListItem>
                                              <asp:ListItem>CONCORD</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp
                                        
                                        
                                        <asp:Button ID="btnstocksearch" runat="server" Text="Submit" CssClass="btn btn-primary btn-sm"
                                            OnClick="btnstocksearch_Click"  />
                                    </div>
									
									  
									
									
									<div class="col-md-6">
                                        <asp:Label ID="lbldiv_emp" runat="server" Text="Employee list:"></asp:Label>
                                       
									 
									   
                                        <asp:DropDownList ID="ddlemp" runat="server" AutoPostBack="True" OnDataBound="ddlemp_DataBound"
										
										OnSelectedIndexChanged="ddlemp_SelectedIndexChanged">
                                         
                                        </asp:DropDownList>
                                        &nbsp
                                        
                                        
                                      
                                    </div>

                                </div>

 

 <asp:UpdatePanel runat="server" ID="pnl_report">
            <ContentTemplate>

			 
                <div style="width:1300px;">
                    <uc1:reportviewer ReportTitle="Default" ReportName="Default Name" runat="server"
                        ID="rpt_daily" visible="false" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

