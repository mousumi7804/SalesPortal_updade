<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       <asp:Image ID="Image1" runat="server" Height="67px" Width="167px"
            ImageUrl="http://mendine.com/wp-content/themes/mendine/images/logo.jpg" 
            style="text-align: center; margin-left: 35px; margin-top: 0px" 
            ViewStateMode="Enabled"/>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <font size="5">Welcome to Mendine Pharmaceuticals Private Limited</font>
       </h2>
    <p>
        To Sign Up visit &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="~/CandidateSignUpPage.aspx">Sign Up</asp:LinkButton>
        </p>
</asp:Content>
