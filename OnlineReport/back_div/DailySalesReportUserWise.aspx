<%@ Page Title="Daily Sales Report User Wise" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DailySalesReportUserWise.aspx.cs" Inherits="OnlineReport_DailySalesReport" EnableEventValidation="false"  %>
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
 <asp:UpdatePanel runat="server" ID="pnl_report">
            <ContentTemplate>
			
			 <div class="col-md-6">
                                        <asp:Label ID="lbldiv" runat="server" Text="Employee list:"></asp:Label>
                                       
									 
									   
                                        <asp:DropDownList ID="DropDownstocklocation" runat="server" AutoPostBack="True" OnDataBound="DropDownstocklocation_DataBound"
										
										OnSelectedIndexChanged="DropDownstocklocation_SelectedIndexChanged">
                                         
                                        </asp:DropDownList>
                                        &nbsp
                                        
                                        
                                      
                                    </div>
			 <br />
                 <br />
		
			 </div>
                <div style="width:1300px;">
                    <uc1:reportviewer ReportTitle="Default" ReportName="Default Name" runat="server"
                        ID="rpt_daily" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
	
</asp:Content>

