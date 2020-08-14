<%@ Page Title="Solution" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ToutSolution.aspx.cs" Inherits="ToutSolution" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
                <label for="info">
                    Choose Date:</label>
                <asp:TextBox ID="txtdate" runat="server" autocomplete="off"
                                                            onkeydown="return false;" onpaste="return false" oncut="return false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Date Required" ControlToValidate="txtdate" ForeColor="Red" ValidationGroup="req"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender_frmdate_txt" runat="server" Format="yyyy-MM-dd"
                    TargetControlID="txtdate" />
                    &nbsp
                <asp:Button ID="btnselect" runat="server" Text="Select" ValidationGroup="req" 
                    onclick="btnselect_Click" />

                     &nbsp
                <asp:Button ID="btndelect" runat="server" Text="Delete" onclick="btndelect_Click"  ValidationGroup="req" OnClientClick="return confirm('Are You Sure You Want To Delete?');"
                     /><br />
                     &nbsp
                <asp:Label ID="Showstatus_lbl" runat="server" ForeColor="Green"></asp:Label><br />
                <asp:HyperLink ID="HLuploadpage" runat="server" NavigateUrl="~/Default.aspx">Back To Order Upload Page</asp:HyperLink>

            </div>
            <br />
            <div>
                <asp:GridView ID="GridViewresult" runat="server">
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
