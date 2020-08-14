<%@ Page Title="Universal Hierchy-MAD" Language="C#" MasterPageFile="~/OnlineReport/OReport.master" AutoEventWireup="true" CodeFile="UHierchyMad.aspx.cs" Inherits="OnlineReport_UHierchyMad" %>
<%@ Register Assembly="IdeaSparx.CoolControls.Web" Namespace="IdeaSparx.CoolControls.Web"
    TagPrefix="cc1" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
            width:400px;
        }
        
        .myGridStyle tr:last-child td
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;&nbsp;
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
                           
                           

                             <cc1:CoolGridView ID="GridViewuhierchymad" runat="server" Height="400px" CssClass="myGridStyle"    
                                 AutoGenerateColumns="False"   
                                  
                                  
                                  DefaultColumnWidth="200px">
                                 <BoundaryStyle BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" />
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
                                            <asp:LinkButton ID="editmode" runat="server" OnClick="EditMode_Click" CssClass="btn btn-primary btn-xs" ForeColor="White">Edit</asp:LinkButton>
                                            <asp:LinkButton ID="updaterow" runat="server" OnClick="UpdateRow_Click" Visible="false"  CssClass="btn btn-primary btn-xs" ForeColor="White"
                                                CommandArgument='<%# Eval("[Id]") %>'>Update</asp:LinkButton>
                                            <asp:LinkButton ID="cancelrow" runat="server" OnClick="CancelRow_Click" Visible="false"  CssClass="btn btn-primary btn-xs" ForeColor="White">Cancel</asp:LinkButton>
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
                                    <asp:TemplateField HeaderText="STK">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtstk" runat="server" ReadOnly="true" Text='<%# Eval("[STK]") %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:DropDownList ID="DropDownstk" runat="server" Visible="false">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MSR_HQ">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtmsrhq" runat="server" ReadOnly="true" Text='<%# Eval("[MSR_HQ]") %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:DropDownList ID="DropDownmsrhq" runat="server" Visible="false">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MSR_NAME">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtmsrname" runat="server" ReadOnly="true" Text='<%# Eval("[MSR_NAME]") %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:DropDownList ID="DropDownmsrname" runat="server" Visible="false">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="MSR_DOJ"   >
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtmsrdoj" runat="server" ReadOnly="true" Text='<%# Eval("[MSR_DOJ]","{0:M-dd-yyyy}")  %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtmsrdoj_CalendarExtender" runat="server" Enabled="false" 
                                                Format="MM-dd-yyyy" TargetControlID="grdtxtmsrdoj" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DSO HQ">
                                    <ItemTemplate>
                                    <asp:Label ID="lbldsohq" runat="server" Text='<%# Eval("[DSO-HQ]") %>'></asp:Label>
                                     <asp:DropDownList ID="DropDowndsohq" runat="server" Visible="false">
                                      </asp:DropDownList>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="DSO-HQ" HeaderText="DSO-HQ" SortExpression="DSO-HQ" />--%>
                                    <asp:TemplateField HeaderText="DSO">
                                    <ItemTemplate>
                                    <asp:Label ID="lbldso" runat="server" Text='<%# Eval("[DSO]") %>'></asp:Label>
                                     <asp:DropDownList ID="DropDowndso" runat="server" Visible="false">
                                      </asp:DropDownList>
                                    </ItemTemplate>
                                    </asp:TemplateField>

                                   <%-- <asp:BoundField HeaderText="DSO " DataField="DSO" SortExpression="DSO" />--%>
                                    <%--<asp:BoundField HeaderText="DSO DOJ" DataField="DSO DOJ" SortExpression="DSO DOJ" />--%>

                                    <asp:TemplateField HeaderText="DSO DOJ"   >
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtdsodoj" runat="server" ReadOnly="true" Text='<%# Eval("[DSO DOJ]","{0:M-dd-yyyy}")  %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtdsodoj_CalendarExtender" runat="server" Enabled="false" 
                                                Format="MM-dd-yyyy" TargetControlID="grdtxtdsodoj" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:BoundField DataField="DRSM HQ" HeaderText="DRSM HQ" SortExpression="DRSM HQ" />--%>

                                    <asp:TemplateField HeaderText="DRSM HQ">
                                    <ItemTemplate>
                                    <asp:Label ID="lbldrsmhq" runat="server" Text='<%# Eval("[DRSM HQ]") %>'></asp:Label>
                                     <asp:DropDownList ID="DropDowndrsmhq" runat="server" Visible="false">
                                      </asp:DropDownList>
                                    </ItemTemplate>
                                    </asp:TemplateField>

                                   <%-- <asp:BoundField DataField="DRSM" HeaderText="DRSM" SortExpression="DRSM" />--%>
                                    <asp:TemplateField HeaderText="DRSM">
                                    <ItemTemplate>
                                    <asp:Label ID="lbldrsm" runat="server" Text='<%# Eval("[DRSM]") %>'></asp:Label>
                                     <asp:DropDownList ID="DropDowndrsm" runat="server" Visible="false">
                                      </asp:DropDownList>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="DRSM DOJ" HeaderText="DRSM DOJ" SortExpression="DRSM DOJ" />--%>

                                    <asp:TemplateField HeaderText="DRSM DOJ"   >
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtdrsmodoj" runat="server" ReadOnly="true" Text='<%# Eval("[DRSM DOJ]","{0:M-dd-yyyy}")  %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtdrsmodoj_CalendarExtender" runat="server" Enabled="false" 
                                                Format="MM-dd-yyyy" TargetControlID="grdtxtdrsmodoj" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                   <%-- <asp:BoundField DataField="DSRSM HQ" HeaderText="DSRSM HQ" SortExpression="DSRSM HQ" />--%>
                                    <asp:TemplateField HeaderText="DSRSM HQ">
                                    <ItemTemplate>
                                    <asp:Label ID="lbldsrsmhq" runat="server" Text='<%# Eval("[DSRSM HQ]") %>'></asp:Label>
                                     <asp:DropDownList ID="DropDowndsrsmhq" runat="server" Visible="false">
                                      </asp:DropDownList>
                                    </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:BoundField DataField="DSRSM" HeaderText="DSRSM" SortExpression="DSRSM" />--%>

                                    <asp:TemplateField HeaderText="DSRSM">
                                    <ItemTemplate>
                                    <asp:Label ID="lbldsrsm" runat="server" Text='<%# Eval("[DSRSM]") %>'></asp:Label>
                                     <asp:DropDownList ID="DropDowndsrsm" runat="server" Visible="false">
                                      </asp:DropDownList>
                                    </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:BoundField DataField="DSRSM DOJ" HeaderText="DSRSM DOJ" SortExpression="DSRSM DOJ" />--%>

                                    <asp:TemplateField HeaderText="DSRSM DOJ"   >
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="grdtxtdsrsmodoj" runat="server" ReadOnly="true" Text='<%# Eval("[DSRSM DOJ]","{0:M-dd-yyyy}")  %>'
                                                autocomplete="off"></asp:TextBox>
                                            <asp:CalendarExtender ID="grdtxtdsrsmodoj_CalendarExtender" runat="server" Enabled="false" 
                                                Format="MM-dd-yyyy" TargetControlID="grdtxtdsrsmodoj" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:BoundField DataField="DISTRIBUTION HEAD" HeaderText="DISTRIBUTION HEAD" SortExpression="DISTRIBUTION HEAD" />--%>
                                    
                                    <asp:TemplateField HeaderText="DISTRIBUTION HEAD">
                                    <ItemTemplate>
                                    <asp:Label ID="lbldistributionhead" runat="server" Text='<%# Eval("[DISTRIBUTION HEAD]") %>'></asp:Label>
                                     <asp:DropDownList ID="DropDownddistributionhead" runat="server" Visible="false">
                                      </asp:DropDownList>
                                    </ItemTemplate>
                                    </asp:TemplateField>

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
            <asp:SqlDataSource ID="SqlDataSourcegridvalue" runat="server" 
                ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT Id,DIVISION, DEPOT, STK, MSR_HQ, MSR_NAME, MSR_DOJ, [DSO-HQ], [DSO], [DSO DOJ], [DRSM HQ], [DRSM], [DRSM DOJ], [DSRSM HQ], [DSRSM], [DSRSM DOJ], [DISTRIBUTION HEAD] FROM MADhierchy$"></asp:SqlDataSource>
        <br />
        <asp:SqlDataSource ID="SqlDataSourcedepo" runat="server" 
            ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT DISTINCT DEPOT FROM MADhierchy$">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSourcestk" runat="server" 
            ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT DISTINCT STK FROM MADhierchy$">
        </asp:SqlDataSource>
        <br />
        <asp:SqlDataSource ID="SqlDataSourcemsrhq" runat="server" 
            ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT DISTINCT MSR_HQ FROM MADhierchy$"></asp:SqlDataSource>
        <br />
        <asp:SqlDataSource ID="SqlDataSourcemsrname" runat="server" 
            ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT DISTINCT MSR_NAME FROM MADhierchy$"></asp:SqlDataSource>
        <br />
        <asp:SqlDataSource ID="SqlDataSourcedsohq" runat="server" 
            ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT DISTINCT [DSO-HQ] FROM MADhierchy$"></asp:SqlDataSource>
        <br />
        <asp:SqlDataSource ID="SqlDataSourcedso" runat="server" 
            ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT DISTINCT [DSO] FROM MADhierchy$"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourcedrsmhq" runat="server" 
            ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT DISTINCT [DRSM HQ] FROM MADhierchy$"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSourcedrsm" runat="server" 
            ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT DISTINCT [DRSM] FROM MADhierchy$"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSourcedsrsmhq" runat="server" 
            ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT DISTINCT [DSRSM HQ] FROM MADhierchy$"></asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSourcedsrsm" runat="server" 
            ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT DISTINCT [DSRSM] FROM MADhierchy$"></asp:SqlDataSource>

         <asp:SqlDataSource ID="SqlDataSourcedistributionhead" runat="server" 
            ConnectionString="<%$ ConnectionStrings:esspconnection %>" 
            SelectCommand="SELECT DISTINCT [DISTRIBUTION HEAD] FROM MADhierchy$"></asp:SqlDataSource>

    </ContentTemplate>
     <Triggers>
            <asp:PostBackTrigger ControlID="exportbtn" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

