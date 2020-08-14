<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UHierchy.aspx.cs" Inherits="SalesReport_UHierchy" %>

<%@ Register Assembly="IdeaSparx.CoolControls.Web" Namespace="IdeaSparx.CoolControls.Web"
    TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Styles/Customstyle1.css" rel="stylesheet" type="text/css" />
    <title>Universal Hierchy...</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,height=device-height, initial-scale=1.0" />
    <link rel="shortcut icon" href="favicon.ico" type="image/x-icon" />
    <link rel="icon" href="favicon.ico" type="image/ico" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <meta name="viewport" content="width=device-width,height=device-height, initial-scale=1.0" />
    <link rel="shortcut icon" href="favicon.ico" type="image/x-icon" />
    <link rel="icon" href="favicon.ico" type="image/ico" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link type="text/css" rel='stylesheet' href='https://use.fontawesome.com/releases/v5.7.0/css/all.css'
        integrity='sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ'
        crossorigin='anonymous' />
    <script type="text/javascript" src="https://apis.google.com/js/plusone.js"></script>
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0)" />
    <script type="text/javascript">
        $(function () {
            $("[id*=GridViewuhierchy] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
</script>
    <style type="text/css">
        .lbltimecss
        {
            font-size: 20px;
        }
        
        .divcss
        {
            text-align: right;
        }
        
        .lblcss
        {
            font-weight: bold;
            color: black;
        }
        
        .lblcss1
        {
            color: black;
        }
        
        .btncss1
        {
            margin-top: 40px;
        }
        
        .divcss1
        {
            height: 230px;
        }
        
        .btncss
        {
            float: left;
            margin-top: 5px;
            margin-left: 5px;
        }
    </style>
    <style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    td
    {
        cursor: pointer;
    }
    .hover_row
    {
        background-color: #b3cbf2;
    }
    
      .grid_css3
        {
            background-color: #fff;
            
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Calibri;
            color: #474747;
           
        }
        .grid_css3 td
        {
            padding: 2px;
            border: solid 1px black;
            color: Black;
            font-size: 1em;
            width:500 px;
        }
        .grid_css3 th
        {
            padding: 4px 2px;
            background-color: #78c2db;
            color: Black;
            font-size: 1em;
            text-decoration: bold;
               width:500 px;
        }
</style>
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
            width:400px;
        }
        
        .myGridStyle tr:last-child td
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <%-- <cc1:CoolGridView ID="CoolGridView1" Height="300px"  runat="server"  AutoGenerateColumns="true" DataSourceID="SqlDataSource1" FixHeaders="True">
                            </cc1:CoolGridView>--%>



    <div class="row" style="color: #FFFFFF; background-color: #e8e8ef; height: 60px;">
        <div class="col-md-6">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/logo.png" Width="100px" Height="50px" />
            <label style="color: #000000">
                Recruitment</label>
        </div>
        <div class="col-md-3">
        </div>
        <div class="col-md-3">
            <div class="loginDisplay">
                <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                    <AnonymousTemplate>
                        [ <a href="~/Account/Login.aspx" id="HeadLoginStatus1" runat="server" style="color: Black">
                            Log In</a> ]
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <p style="color: Black">
                            Welcome <span class="bold" style="color: Black">
                                <asp:LoginName ID="HeadLoginName" runat="server" />
                            </span>! [
                            <asp:LoginStatus ID="HeadLoginStatus1" Style="color: Black" runat="server" LogoutAction="Redirect"
                                LogoutText="Log Out" LogoutPageUrl="~/" />
                            ]
                        </p>
                    </LoggedInTemplate>
                </asp:LoginView>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container1">
            <div class="row">
            <div class="col-md-12">
            <div class=" panel panel-default">
            <div class=" panel-body">
                   <div class="row">
                    <div class="col-md-12" >
                        <div class="table-responsive" >
                           
                           

                             <cc1:CoolGridView ID="GridViewuhierchy" runat="server" Height="500px" CssClass="myGridStyle"    
                                 AutoGenerateColumns="false"   
                                  
                                  
                                 onrowdatabound="GridViewuhierchy_RowDataBound" DefaultColumnWidth="200px">
                                <Columns>
                                    <%--<asp:TemplateField>
                                <ItemTemplate>

                                        <asp:CheckBox ID="CheckBox1" runat="server" onclick = "Check_Click(this)" />

                                </ItemTemplate>
                                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Action" >
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                Text="Update"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="editmode" runat="server" OnClick="EditMode_Click" CssClass="btn btn-primary btn-xs">Edit</asp:LinkButton>
                                            <asp:LinkButton ID="updaterow" runat="server" OnClick="UpdateRow_Click" Visible="false"  CssClass="btn btn-primary btn-xs"
                                                CommandArgument='<%# Eval("[Id]") %>'>Update</asp:LinkButton>
                                            <asp:LinkButton ID="cancelrow" runat="server" OnClick="CancelRow_Click" Visible="false"  CssClass="btn btn-primary btn-xs">Cancel</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Id" HeaderText="id" Visible="false" />
                                    <asp:BoundField HeaderText="Division" DataField="Division" SortExpression="Division" />
                                    <asp:TemplateField HeaderText="Depot">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtdepo" runat="server" ReadOnly="true" Text='<%# Eval("[Depot]") %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:DropDownList ID="DropDowndepo" runat="server" Visible="false">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dist">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtdist" runat="server" ReadOnly="true" Text='<%# Eval("[Dist]") %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:DropDownList ID="DropDowndist" runat="server" Visible="false">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MSR-MFSO HQ"   >
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtmfsohq" runat="server" ReadOnly="true" Text='<%# Eval("[MSR-MFSO HQ]") %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:DropDownList ID="DropDownmfsohq" runat="server" Visible="false">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MSR-MFSO Name">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtmfsoname" runat="server" ReadOnly="true" Text='<%# Eval("[MSR-MFSO Name]") %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:DropDownList ID="DropDownmfsoname" runat="server" Visible="false">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="MFSO DOJ"   >
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtmfsodoj" runat="server" ReadOnly="true" Text='<%# Eval("[MFSO DOJ]","{0:M-dd-yyyy}")  %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtmfsodoj_CalendarExtender" runat="server" Enabled="false" 
                                                Format="MM-dd-yyyy" TargetControlID="grdtxtmfsodoj" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DSO-ASM_HQ" HeaderText="DSO-ASM_HQ" SortExpression="DSO-ASM_HQ" />
                                    <asp:BoundField HeaderText="DSO-ASM" DataField="DSO-ASM" SortExpression="DSO-ASM" />
                                    <asp:BoundField HeaderText="DSO-ASM DOJ" DataField="DSO-ASM DOJ" SortExpression="DSO-ASM DOJ" />
                                    <asp:BoundField DataField="RSM_HQ" HeaderText="RSM_HQ" SortExpression="RSM_HQ" />
                                    <asp:BoundField DataField="RSM" HeaderText="RSM" SortExpression="RSM" />
                                    <asp:BoundField DataField="RSM DOJ" HeaderText="RSM DOJ" SortExpression="RSM DOJ" />
                                    <asp:BoundField DataField="ZSM_HQ" HeaderText="ZSM_HQ" SortExpression="ZSM_HQ" />
                                    <asp:BoundField DataField="ZSM" HeaderText="ZSM" SortExpression="ZSM" />
                                    <asp:BoundField DataField="ZSM DOJ" HeaderText="ZSM DOJ" SortExpression="ZSM DOJ" />
                                    <asp:BoundField DataField="GM_HQ" HeaderText="GM_HQ" SortExpression="GM_HQ" />
                                    <asp:BoundField DataField="GM" HeaderText="GM" SortExpression="GM" />
                                    <asp:BoundField DataField="GM DOJ" HeaderText="GM DOJ" SortExpression="GM DOJ" />
                                </Columns>
                                
                                <HeaderStyle HorizontalAlign="Left"  Wrap="false"    />
                                <RowStyle HorizontalAlign="Left"     Wrap="false"/>
                                
                            </cc1:CoolGridView>
                        </div>
                        <div>
                            <%--<asp:Repeater ID="rptPager" runat="server" >
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPage" runat="server" Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' Enabled = '<%# Eval("Enabled") %>' OnClick = "Page_Changed" CssClass="btn-sm btn-primary" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                            </ItemTemplate>
                           </asp:Repeater>--%>
                        </div>
                        <br />
                        <asp:Label ID="lblpageno" runat="server" Text="" BackColor="Yellow"></asp:Label><br />
                        <%--<asp:Button ID="export_excel" runat="server" Text="Export To Excel"  CssClass=" btn btn-primary"
                            onclick="export_excel_Click" />--%>
                    </div>
                </div>
            </div>
            </div>
            </div>
            </div>
                
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:esspconnection %>"
                
                
                SelectCommand="SELECT Id, Division, Depot, Dist, [MSR-MFSO HQ], [MSR-MFSO Name], [MFSO DOJ], [DSO-ASM_HQ], [DSO-ASM], [DSO-ASM DOJ], RSM_HQ, RSM, [RSM DOJ], ZSM_HQ, ZSM, [ZSM DOJ], GM_HQ, GM, [GM DOJ] FROM EVA$">
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:esspconnection %>"
                SelectCommand="SELECT [MSR-MFSO HQ] FROM EVA$"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourcedepo" runat="server" 
                ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
                SelectCommand="SELECT DISTINCT Depot FROM EVA$"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourcedist" runat="server" 
                ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
                SelectCommand="SELECT DISTINCT Dist FROM EVA$"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSourcemfsoname" runat="server" 
                ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
                SelectCommand="SELECT DISTINCT [MSR-MFSO Name] FROM EVA$"></asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
