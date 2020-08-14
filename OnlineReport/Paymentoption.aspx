<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Paymentoption.aspx.cs" Inherits="OnlineReport_Paymentoption" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <table>
    <tr>
        <td>
            <b>Total Amt</b>
        </td>
        <td>
            <asp:Label ID="lblId" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>customer code</b>
        </td>
        <td>
            <asp:Label ID="Labecode" runat="server"></asp:Label>
        </td>
    </tr>  
      
</table>

 <asp:Button ID="Button1" runat="server" Text="Button"  />
</asp:Content>

