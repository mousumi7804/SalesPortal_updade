<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="customerwiseoutstanding.aspx.cs" Inherits="OnlineReport_customerwiseoutstanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:TextBox ID="txtSearch" runat="server" autocomplete="off"/>
<asp:Button ID="Button1" Text="Search" runat="server" OnClick="Search" />
<hr />
                               
<asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="OnPageIndexChanging">
<Columns>   
  
    <asp:BoundField HeaderStyle-Width="150px" DataField="Alias"  ItemStyle-ForeColor ="Black" HeaderStyle-ForeColor="Black"  HeaderText="Customer Code"/> 
    <asp:BoundField HeaderStyle-Width="150px" DataField="Customer"  ItemStyle-ForeColor ="Black" HeaderStyle-ForeColor="Black"  HeaderText="Customer Name"/>
    <asp:BoundField HeaderStyle-Width="150px" DataField="Locality" ItemStyle-ForeColor ="Black" HeaderStyle-ForeColor="Black" HeaderText="Locality" />
    <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="HyperLink2" runat="server" OnClick="BindGriddetails" CommandArgument='<%# Eval("Alias") %>' 
                    Text="View Details" />
            </ItemTemplate>
        </asp:TemplateField>

       
  
</Columns>
</asp:GridView>


    

</asp:Content>

