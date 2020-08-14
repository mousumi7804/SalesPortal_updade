<%@ Page Title="All Application" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AllApplicationTracker.aspx.cs" Inherits="Pages_AllApplicationTracker" %>

<%@ Register Assembly="IdeaSparx.CoolControls.Web" Namespace="IdeaSparx.CoolControls.Web"
    TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .req_css
        {
            color: Red;
            font-size: x-small;
        }
        h2
        {
            font-family: Arial Rounded MT Bold;
        }
        .grid_css
        {
            background-color: #fff;
            margin: 0 auto;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Calibri;
            color: #474747;
        }
        .grid_css td
        {
            padding: 2px;
            border: solid 1px black;
            color: Black;
            font-size: 1em;
        }
        .grid_css th
        {
            padding: 4px 2px;
            background-color: #78c2db;
            color: Black;
            font-size: 1em;
            text-decoration: bold;
        }
        .lbl_css
        {
            font-size: x-large;
            text-decoration: bold;
            margin-left: 10px;
        }
        .btn_css
        {
            height: 35px;
            width: 90px;
            text-align: center;
            padding: 0px;
        }
        td
        {
            vertical-align: top;
        }
        .container1
        {
            background-color: #f2f2f2;
            margin-top: -10px;
            margin-left: -8px;
            margin-right: -8px;
            padding-left: 5px;
        }
        .divWaiting
        {
            position: absolute;
            background-color: #FAFAFA;
            z-index: 2147483647 !important;
            opacity: 0.8;
            overflow: hidden;
            text-align: center;
            top: 0;
            left: 0;
            height: 100%;
            width: 100%;
            padding-top: 20%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container1">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                 <div class="divWaiting">
                     
                <img alt="ajax-progress" src="../image/wait.gif" height="200px" width="200px"></img>
                </div>
                </ProgressTemplate>
                </asp:UpdateProgress>
                <div class="row">
                    <div class="col-md-7">
                        <h3>
                            All Application
                            </h3>
                    </div>
                    <div class="col-md-3">
                        <asp:HyperLink ID="offlineCV_link" runat="server" Font-Bold="true" NavigateUrl="~/Pages/InterviewDetailsInputManual.aspx?regno=none&postname=none">New Offline Entry</asp:HyperLink>
                    </div>
                   
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <label for="From Date">
                            From Date:</label><br />
                        <asp:TextBox ID="txtfrmdate" runat="server" autocomplete="off" onkeydown="return false;"
                            AutoCompleteType="Disabled"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="req" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="txtfrmdate" CssClass="req_css" ValidationGroup="req"></asp:RequiredFieldValidator>
                        <asp:CalendarExtender ID="txtfrmdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtfrmdate" />
                    </div>
                    <div class="col-md-2">
                        <label for="To Date">
                            To Date:</label><br />
                        <asp:TextBox ID="txttodate" runat="server" autocomplete="off" onkeydown="return false;"
                            AutoCompleteType="Disabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="txttodate" CssClass="req_css" ValidationGroup="req"></asp:RequiredFieldValidator>
                        <asp:CalendarExtender ID="txttodate_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txttodate" />
                    </div>
                    <div class="col-md-2" >
                  <label for="To Date">
                            </label><br />
                    
                        <asp:Button ID="srch_btn" runat="server" CssClass="btn btn-primary" Text="Search"  ValidationGroup="req"
                            onclick="srch_btn_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView_applications" runat="server" AutoGenerateColumns="False"
                                CssClass="grid_css" DataKeyNames="registrationnumber,postname,CandidateName,referredus,deptdivision"
                                OnRowDataBound="GridView_applications_RowDataBound">
                                <Columns>
                                    <asp:BoundField HeaderText="Recruitment Reference No" DataField="registrationnumber" />
                                    <asp:BoundField DataField="deptdivision" HeaderText="Department" />
                                    <asp:BoundField DataField="postname" HeaderText="Post Name" />
                                    <asp:TemplateField HeaderText="HQ(Optional)">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxthq" runat="server" ReadOnly="true" Text='<%# Eval("HeadQ") %>'
                                                autocomplete="off"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="User Name" DataField="username" Visible="false" />
                                    <asp:BoundField HeaderText="Candidate Name" DataField="CandidateName" />
                                    <asp:BoundField DataField="referredus" HeaderText="Source" />
                                    <asp:BoundField DataField="aplicationdate" HeaderText="Application Date" />
                                    <asp:TemplateField HeaderText="Resume">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="DownloadResume" CommandArgument='<%# Eval("registrationnumber") %>'>Download</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" Visible="false">
                                        <ItemTemplate>
                                            <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClick="Reportview" CommandArgument='<%# Eval("username") %>'>Download</asp:LinkButton>--%>
                                            <asp:ImageButton ID="View" runat="server" ImageUrl="~/image/view.png" OnClick="Reportview"
                                                CommandArgument='<%# Eval("username") %>' ToolTip="View Application" Width="20px"
                                                Height="20px" />
                                            <%-- <asp:ImageButton ID="schedule" runat="server" ImageUrl="~/image/calender.jpg" OnClick="InterviewSchedule"
                                                CommandArgument='<%# Eval("username") %>' ToolTip="Interview Schedule" Width="20px"
                                                Height="20px" />
                                            --%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Start Date ">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtstartdate" runat="server" ReadOnly="true" autocomplete="off"
                                                onkeydown="return false;" Text='<%# Eval("STARTDATE") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtstartdate_CalendarExtender" runat="server" Enabled="false"
                                                Format="dd/MM/yyyy" TargetControlID="grdtxtstartdate" />
                                            <%--   <%#(Eval("Data") == null ? "0" : Eval("Data"))%>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CV Selected (Y/N)">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="DropDowncv" runat="server" SelectedValue='<%#Eval("CVSelected")%>'
                                                Enabled="false">
                                                <asp:ListItem Value="">Selecte Option</asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                                <asp:ListItem>On Hold</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Uploade By">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtuploadby" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("manualupdate").ToString()=="Yes"?"Offline":"Online" %>'> </asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- ------Round1 interview---------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText=" Round 1 Interview Date" HeaderStyle-BackColor="SlateGray">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtidater1" runat="server" ReadOnly="true" autocomplete="off"
                                                onkeydown="return false;" Text='<%# Eval("roneinterviewdate") %>'> </asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtidater1_CalendarExtender" runat="server" Enabled="False"
                                                Format="dd/MM/yyyy" TargetControlID="grdtxtidater1" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="SlateGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Round 1 Interviewer 1" HeaderStyle-BackColor="SlateGray">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtinamer1i1" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("roneinterviewernameone") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="SlateGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 1 Remarks Upload" HeaderStyle-BackColor="SlateGray"
                                        Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:FileUpload ID="remark1r1" runat="server" Enabled="false" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="SlateGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 1 Remarks" HeaderStyle-BackColor="SlateGray">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Linkremark1_r1" runat="server" OnClick="Download_remark1R1" Visible='<%#Convert.ToBoolean( Eval("ronerone")) %>'
                                                CommandArgument='<%# Eval("registrationnumber") %>'>Download</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="SlateGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Round 1 Interviewer 2" HeaderStyle-BackColor="SlateGray">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtinamer1i2" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("roneinterviewernametwo") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="SlateGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 2 Remarks Upload" HeaderStyle-BackColor="SlateGray"
                                        Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:FileUpload ID="remark2r1" runat="server" Enabled="false" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="SlateGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 2 Remarks" HeaderStyle-BackColor="SlateGray">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Linkremark2_r1" runat="server" OnClick="Download_remark2R1" Visible='<%#Convert.ToBoolean( Eval("ronertwo")) %>'
                                                CommandArgument='<%# Eval("registrationnumber") %>'>Download</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="SlateGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Round 1 Selected" HeaderStyle-BackColor="SlateGray">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="DropDownselected_r1" runat="server" SelectedValue='<%#Eval("roneselect")%>'
                                                Enabled="false">
                                                <asp:ListItem Value="">Selecte Option</asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                                <asp:ListItem>On Hold</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="SlateGray" />
                                    </asp:TemplateField>
                                    <%-----------------End of Round1 Interview------------------------------------------------------------%>
                                    <%---------------------Round 2 Interview-------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="Round 2 Interview Date" HeaderStyle-BackColor="#FFC1C1">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtidater2" runat="server" ReadOnly="true" autocomplete="off"
                                                onkeydown="return false;" Text='<%# Eval("rtwointerviewdate") %>'> </asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtidater2_CalendarExtender" runat="server" Enabled="False"
                                                Format="dd/MM/yyyy" TargetControlID="grdtxtidater2" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFC1C1" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Round 2 Interviewer 1" HeaderStyle-BackColor="#FFC1C1">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtinamer2i1" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("rtwointerviewernameone") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFC1C1" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 1 Remarks Upload" HeaderStyle-BackColor="#FFC1C1"
                                        Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:FileUpload ID="remark1r2" runat="server" Enabled="false" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFC1C1" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 1 Remarks" HeaderStyle-BackColor="#FFC1C1">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Linkremark1_r2" runat="server" OnClick="Download_remark1R2" Visible='<%#Convert.ToBoolean( Eval("rtworone")) %>'
                                                CommandArgument='<%# Eval("registrationnumber") %>'>Download</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFC1C1" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Round 2 Interviewer 2" HeaderStyle-BackColor="#FFC1C1">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtinamer2i2" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("rtwointerviewernametwo") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFC1C1" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 2 Remarks Upload" HeaderStyle-BackColor="#FFC1C1"
                                        Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:FileUpload ID="remark2r2" runat="server" Enabled="false" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFC1C1" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 2 Remarks" HeaderStyle-BackColor="#FFC1C1">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Linkremark2_r2" runat="server" OnClick="Download_remark2R2" Visible='<%#Convert.ToBoolean( Eval("rtwortwo")) %>'
                                                CommandArgument='<%# Eval("registrationnumber") %>'>Download</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFC1C1" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Round 2 Selected" HeaderStyle-BackColor="#FFC1C1">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="DropDownselected_r2" runat="server" SelectedValue='<%#Eval("rtwoselect")%>'
                                                Enabled="false">
                                                <asp:ListItem Value="">Selecte Option</asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                                <asp:ListItem>On Hold</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFC1C1" />
                                    </asp:TemplateField>
                                    <%-- -------------------------End of Round 2 Interview-------------------------------------------------------------%>
                                    <%-- --------------------------Round 3 Interview----------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="Round 3 Interview Date" HeaderStyle-BackColor="#FFD39B">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtidater3" runat="server" ReadOnly="true" autocomplete="off"
                                                onkeydown="return false;" Text='<%# Eval("rthreeinterviewdate") %>'> </asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtidater3_CalendarExtender" runat="server" Enabled="False"
                                                Format="dd/MM/yyyy" TargetControlID="grdtxtidater3" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFD39B" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Round 3 Interviewer 1" HeaderStyle-BackColor="#FFD39B">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtinamer3i1" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("rthreeinterviewernameone") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFD39B" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 1 Remarks Upload" HeaderStyle-BackColor="#FFD39B"
                                        Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:FileUpload ID="remark1r3" runat="server" Enabled="false" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFD39B" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 1 Remarks" HeaderStyle-BackColor="#FFD39B">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Linkremark1_r3" runat="server" OnClick="Download_remark1R3" Visible='<%#Convert.ToBoolean( Eval("rthworone")) %>'
                                                CommandArgument='<%# Eval("registrationnumber") %>'>Download</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFD39B" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Round 3 Interviewer 2" HeaderStyle-BackColor="#FFD39B">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtinamer3i2" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("rthreeinterviewernametwo") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFD39B" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 2 Remarks Upload" HeaderStyle-BackColor="#FFD39B"
                                        Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:FileUpload ID="remark2r3" runat="server" Enabled="false" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFD39B" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks 2" HeaderStyle-BackColor="#FFD39B">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Linkremark2_r3" runat="server" OnClick="Download_remark2R3" Visible='<%#Convert.ToBoolean( Eval("rthwortwo")) %>'
                                                CommandArgument='<%# Eval("registrationnumber") %>'>Download</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFD39B" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Round 3 Selected" HeaderStyle-BackColor="#FFD39B">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="DropDownselected_r3" runat="server" SelectedValue='<%#Eval("rthreeselect")%>'
                                                Enabled="false">
                                                <asp:ListItem Value="">Selecte Option</asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                                <asp:ListItem>On Hold</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="#FFD39B" />
                                    </asp:TemplateField>
                                    <%----------------------------End of Round 3 Interview----------------------------------------------------------------------------%>
                                    <%-------------------------------------Final round Interview----------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="Final Round Interview Date" HeaderStyle-BackColor="#D3D3D3">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtidatefinal" runat="server" ReadOnly="true" autocomplete="off"
                                                onkeydown="return false;" Text='<%# Eval("frinterviewdate") %>'> </asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtidatefinal_CalendarExtender" runat="server" Enabled="False"
                                                Format="dd/MM/yyyy" TargetControlID="grdtxtidatefinal" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Final Round Interviewer 1" HeaderStyle-BackColor="#D3D3D3">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtinamerfinali1" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("frinterviewernameone") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 1 Remarks Upload" HeaderStyle-BackColor="#D3D3D3"
                                        Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:FileUpload ID="remark1rfinal" runat="server" Enabled="false" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 1 Remarks" HeaderStyle-BackColor="#D3D3D3">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Linkremark1_rfinal" runat="server" OnClick="Download_remark1RF"
                                                Visible='<%#Convert.ToBoolean( Eval("rfworone")) %>' CommandArgument='<%# Eval("registrationnumber") %>'>Download</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Final Round Interviewer 2" HeaderStyle-BackColor="#D3D3D3">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtinamerfinali2" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("frinterviewernametwo") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 2 Remarks Upload" HeaderStyle-BackColor="#D3D3D3"
                                        Visible="false">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:FileUpload ID="remark2rfinal" runat="server" Enabled="false" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer 2 Remarks" HeaderStyle-BackColor="#D3D3D3">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Linkremark2_rfinal" runat="server" OnClick="Download_remark2RF"
                                                Visible='<%#Convert.ToBoolean( Eval("rfwortwo")) %>' CommandArgument='<%# Eval("registrationnumber") %>'>Download</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Final round Selected" HeaderStyle-BackColor="#D3D3D3">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="DropDownselected_rfinal" runat="server" SelectedValue='<%#Eval("frselect")%>'
                                                Enabled="false">
                                                <asp:ListItem Value="">Selecte Option</asp:ListItem>
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                                <asp:ListItem>On Hold</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <%-----------------------------------End Of Final Round Interview-------------------------------------------------------------------------------%>
                                    <%--  ----------------------Additional fields------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="DOO" HeaderStyle-BackColor="#D3D3D3">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtdoo" runat="server" ReadOnly="true" autocomplete="off" onkeydown="return false;"
                                                Text='<%# Eval("DOO") %>'> </asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtdoo_CalendarExtender" runat="server" Enabled="False"
                                                Format="dd/MM/yyyy" TargetControlID="grdtxtdoo" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DOJ" HeaderStyle-BackColor="#D3D3D3">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtdoj" runat="server" ReadOnly="true" autocomplete="off" onkeydown="return false;"
                                                Text='<%# Eval("DOJ") %>'> </asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtdoj_CalendarExtender" runat="server" Enabled="False"
                                                Format="dd/MM/yyyy" TargetControlID="grdtxtdoj" />
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EMP Code" HeaderStyle-BackColor="#D3D3D3">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtempcode" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("Empcode") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-BackColor="#D3D3D3">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtremark" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TAT" HeaderStyle-BackColor="#D3D3D3">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxttimetaken" runat="server" ReadOnly="true" autocomplete="off"
                                                Text='<%# Eval("timetaken") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle BackColor="LightGray" />
                                    </asp:TemplateField>
                                    <%--  ----------------------End of Additional fields------------------------------------------------------------------------------------------------%>
                                    <asp:TemplateField HeaderText="Action">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                Text="Update"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="editmode" runat="server" OnClick="EditMode_Click">Edit</asp:LinkButton>
                                            <asp:LinkButton ID="updaterow" runat="server" OnClick="UpdateRow_Click" Visible="false">Update</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle HorizontalAlign="Left" Width="100%" Wrap="False" />
                                <RowStyle HorizontalAlign="Left" Width="100%" Wrap="False" />
                            </asp:GridView>
                            <asp:Repeater ID="rptPager" runat="server">
                        <ItemTemplate>
                     <asp:LinkButton ID="lnkPage" runat="server" Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' Enabled = '<%# Eval("Enabled") %>' OnClick = "Page_Changed" CssClass="pagination"></asp:LinkButton>
                        </ItemTemplate>
                        </asp:Repeater>
                        </div>
                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                        <asp:Button ID="export_excel" runat="server" Text="Export To Excel" OnClick="export_excel_Click" />
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="export_excel" />
                <asp:PostBackTrigger ControlID="GridView_applications" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
