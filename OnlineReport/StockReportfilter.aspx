<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineReport/MasterPage.master" AutoEventWireup="true" CodeFile="StockReportfilter.aspx.cs" Inherits="OnlineReport_rpt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="IdeaSparx.CoolControls.Web" Namespace="IdeaSparx.CoolControls.Web"
    TagPrefix="cc1" %>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        }
        
        .myGridStyle tr:last-child td
        {
        }
    </style>
     <style>
        .cal_Theme1 .ajax__calendar_container 

{ 

background-color: #e2e2e2; border:solid 1px #cccccc; 
} 

  

  


.cal_Theme1 .ajax__calendar_header 

{ 

background-color: #ffffff; margin-bottom: 4px; 
} 

  

  


.cal_Theme1 .ajax__calendar_title, 

.cal_Theme1 .ajax__calendar_next, 

.cal_Theme1 .ajax__calendar_prev 

{ 

color: #004080; padding-top: 3px; 
} 

  

  


.cal_Theme1 .ajax__calendar_body 

{ 

background-color: #e9e9e9; border: solid 1px #cccccc; 
} 

  

  


.cal_Theme1 .ajax__calendar_dayname 

{ 

text-align:center; font-weight:bold; margin-bottom: 4px; margin-top: 2px; 
} 

  

  


.cal_Theme1 .ajax__calendar_day 

{ 

text-align:center; 
} 

  

  


.cal_Theme1 .ajax__calendar_hover .ajax__calendar_day, 

.cal_Theme1 .ajax__calendar_hover .ajax__calendar_month, 

.cal_Theme1 .ajax__calendar_hover .ajax__calendar_year, 

.cal_Theme1 .ajax__calendar_active 

{ 

color: #004080; font-weight:bold; background-color: #ffffff; 
} 

  

  


.cal_Theme1 .ajax__calendar_today 

{ 

font-weight:bold; 
} 

  

  


.cal_Theme1 .ajax__calendar_other, 

.cal_Theme1 .ajax__calendar_hover .ajax__calendar_today, 

.cal_Theme1 .ajax__calendar_hover .ajax__calendar_title 

{ 

color: #bbbbbb; 
} 
    </style>
   <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <link href="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
            rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
        <link href="//cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
            rel="stylesheet" type="text/css" />
        <script src="//cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
            type="text/javascript"></script>
        <script type="text/javascript">  


            function pageLoad(sender, args) {
                $(document).ready(function () {

                    $('[id*=lstDivision]').multiselect({
                        includeSelectAllOption: true
                    });
                    $('[id*=lstDepot]').multiselect({
                        includeSelectAllOption: true
                    });
                    $('[id*=lstStk]').multiselect({
                        includeSelectAllOption: true
                    });
                    $('[id*=lstProduct]').multiselect({
                        includeSelectAllOption: true
                    });
                    $('[id*=lstCtype]').multiselect({
                        includeSelectAllOption: true
                    });
                    setTimeout(function () {
                        window.document.getElementById('wp').style.display = 'none';
                        window.document.getElementById('searchp').style.display = '';


                    }, 100);


                });
            }
            function ShowProgress() {
                setTimeout(function () {
                    var modal = $('<div />');
                    modal.addClass("modal");
                    $('body').append(modal);
                    var loading = $(".loading");
                    loading.show();
                    var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                    var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                    loading.css({ top: top, left: left });
                }, 100);
            }
            $('form').live("submit", function () {
                //ShowProgress();
            });
        </script>
 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
       
       <div class="row">
                    <div class="col-md-11">
                        <h3>
                            Stock Closing History Report</h3>
                    </div>
                </div>
         <div class="panel panel-default">
                            <div class="panel-body">
                                 <div id="wp" style="display : none; min-height : 200px; text-align : center; font-size : 22px; font-weight : bold;"> Please wait</div>
                                <div id="searchp" style="display : none;">

        <div class="row">
            <div class="col-sm-4">
                <b>Division</b> <br />
                <asp:ListBox ID="lstDivision" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </div>
            <div class="col-sm-4">
               <b> Depot</b> <br />
                <asp:ListBox ID="lstDepot" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </div>
            <div class="col-sm-4">
               <b> Stock Location</b> <br />
                 <asp:ListBox ID="lstStk" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </div>
        </div>
         <div class="row">
            <div class="col-sm-4">
               <b> Product</b> <br />
                 <asp:ListBox ID="lstProduct" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </div>
            <div class="col-sm-4">
               <b> Type</b> <br />
                <asp:ListBox ID="lstCtype" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </div>
            <div class="col-sm-4">
               <b> Date </b><br />
                <asp:TextBox ID="txtDate" runat="server" CssClass="datepicker"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1"
                                            Enabled="True" Format="dd-MMM-yyyy" PopupButtonID="ImageButton2" PopupPosition="Right"
                                            TargetControlID="txtDate"></cc1:CalendarExtender>
                                        <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Click here to display calendar"
                                            ImageUrl="datePickerPopup.gif" Width="17px" />
            </div>
        </div>
         <div class="row" style="padding : 5px; margin : 0px;">
             <div class="col-sm-4">
               
            </div>
             <div class="col-sm-4">
            <asp:Button Text="Search" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click1" CssClass="btn btn-primary btn-sm"  OnClientClick="fnc();" />
              <asp:Button ID="Button1" runat="server" Text="Excel" OnClick="Button1_Click1" CssClass="btn btn-primary btn-sm"  />
            </div>
             </div>
      </div>
        <div class="row" style="padding : 5px; margin : 0px;">
            <div class="col-md-12 table-responsive">

              

           <cc1:CoolGridView ID="gvData1" runat="server"  FixHeaders="true"
                            AutoGenerateColumns="True"  CssClass="myGridStyle"  Height="400px" >
             </cc1:CoolGridView>
                <asp:GridView ID="gvData" runat="server" AllowSorting="False" AllowPaging="true"  Visible="false"
                            AutoGenerateColumns="True" AutoGenerateEditButton="False" BorderStyle="None"
                            CellPadding="4"  Width="100%" PageSize="1000" CssClass="myGridStyle"  Height="400px" ShowFooter="true"></asp:GridView>
                </div>
        </div>
                                </div>
             </div>
      <script>
          function fnc() {
              window.document.getElementById('searchp').style.display = 'none';
              window.document.getElementById('wp').style.display = '';

          }
      </script>

              </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        }
        
        .myGridStyle tr:last-child td
        {
        }
    </style>
     <style>
        .cal_Theme1 .ajax__calendar_container 

{ 

background-color: #e2e2e2; border:solid 1px #cccccc; 
} 

  

  


.cal_Theme1 .ajax__calendar_header 

{ 

background-color: #ffffff; margin-bottom: 4px; 
} 

  

  


.cal_Theme1 .ajax__calendar_title, 

.cal_Theme1 .ajax__calendar_next, 

.cal_Theme1 .ajax__calendar_prev 

{ 

color: #004080; padding-top: 3px; 
} 

  

  


.cal_Theme1 .ajax__calendar_body 

{ 

background-color: #e9e9e9; border: solid 1px #cccccc; 
} 

  

  


.cal_Theme1 .ajax__calendar_dayname 

{ 

text-align:center; font-weight:bold; margin-bottom: 4px; margin-top: 2px; 
} 

  

  


.cal_Theme1 .ajax__calendar_day 

{ 

text-align:center; 
} 

  

  


.cal_Theme1 .ajax__calendar_hover .ajax__calendar_day, 

.cal_Theme1 .ajax__calendar_hover .ajax__calendar_month, 

.cal_Theme1 .ajax__calendar_hover .ajax__calendar_year, 

.cal_Theme1 .ajax__calendar_active 

{ 

color: #004080; font-weight:bold; background-color: #ffffff; 
} 

  

  


.cal_Theme1 .ajax__calendar_today 

{ 

font-weight:bold; 
} 

  

  


.cal_Theme1 .ajax__calendar_other, 

.cal_Theme1 .ajax__calendar_hover .ajax__calendar_today, 

.cal_Theme1 .ajax__calendar_hover .ajax__calendar_title 

{ 

color: #bbbbbb; 
} 
    </style>
   <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <link href="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
            rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
        <link href="//cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
            rel="stylesheet" type="text/css" />
        <script src="//cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
            type="text/javascript"></script>
        <script type="text/javascript">  


            function pageLoad(sender, args) {
                $(document).ready(function () {

                    $('[id*=lstDivision]').multiselect({
                        includeSelectAllOption: true
                    });
                    $('[id*=lstDepot]').multiselect({
                        includeSelectAllOption: true
                    });
                    $('[id*=lstStk]').multiselect({
                        includeSelectAllOption: true,
						maxHeight: 250
                    });
                    $('[id*=lstProduct]').multiselect({
                        includeSelectAllOption: true,
                        maxHeight: 250
                    });
                    $('[id*=lstCtype]').multiselect({
                        includeSelectAllOption: true
                    });
                    setTimeout(function () {
                        window.document.getElementById('wp').style.display = 'none';
                        window.document.getElementById('searchp').style.display = '';


                    }, 100);


                });
            }
            function ShowProgress() {
                setTimeout(function () {
                    var modal = $('<div />');
                    modal.addClass("modal");
                    $('body').append(modal);
                    var loading = $(".loading");
                    loading.show();
                    var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                    var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                    loading.css({ top: top, left: left });
                }, 100);
            }
            $('form').live("submit", function () {
                //ShowProgress();
            });
        </script>
 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
       
       <div class="row">
                    <div class="col-md-11">
                        <h3>
                            Stock Closing History Report</h3>
                    </div>
                </div>
         <div class="panel panel-default">
                            <div class="panel-body">
                                 <div id="wp" style="display : none; min-height : 200px; text-align : center; font-size : 22px; font-weight : bold;"> Please wait</div>
                                <div id="searchp" style="display : none;">

        <div class="row">
            <div class="col-sm-4">
                <b>Division</b> <br />
                <asp:ListBox ID="lstDivision" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </div>
           
              <div class="col-sm-4">
               <b> Type</b> <br />
                <asp:ListBox ID="lstCtype" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </div>
            <div class="col-sm-4">
               <b> Depot</b> <br />
                 <asp:ListBox ID="lstStk" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </div>
        </div>
         <div class="row">
            <div class="col-sm-4">
               <b> Product</b> <br />
                 <asp:ListBox ID="lstProduct" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </div>
          
            <div class="col-sm-4">
               <b> Date </b><br />
                <asp:TextBox ID="txtDate" runat="server" CssClass="datepicker"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1"
                                            Enabled="True" Format="dd-MMM-yyyy" PopupButtonID="ImageButton2" PopupPosition="Right"
                                            TargetControlID="txtDate"></cc1:CalendarExtender>
                                        <asp:ImageButton ID="ImageButton2" runat="server" AlternateText="Click here to display calendar"
                                            ImageUrl="datePickerPopup.gif" Width="17px" />
            </div>
              <div class="col-sm-4" style="display : none;">
               <b> Location</b> <br />
                <asp:ListBox ID="lstDepot" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </div>
             
        </div>
         <div class="row" style="padding : 5px; margin : 0px;">
             <div class="col-sm-4">
               
            </div>
             <div class="col-sm-4">
            <asp:Button Text="Search" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click1" CssClass="btn btn-primary btn-sm"  OnClientClick="fnc();" />
              <asp:Button ID="Button1" runat="server" Text="Excel" OnClick="Button1_Click1" CssClass="btn btn-primary btn-sm"  />
            </div>
             </div>
      </div>
        <div class="row" style="padding : 5px; margin : 0px;">
            <div class="col-md-12 table-responsive">
          <cc1:CoolGridView ID="gvData1" runat="server"  FixHeaders="true"
                            AutoGenerateColumns="True"  CssClass="myGridStyle"  Height="400px" >
             </cc1:CoolGridView>
                <asp:GridView ID="gvData" runat="server" AllowSorting="False" AllowPaging="true"  Visible="false"
                            AutoGenerateColumns="True" AutoGenerateEditButton="False" BorderStyle="None"
                            CellPadding="4"  Width="100%" PageSize="1000" CssClass="myGridStyle"  Height="400px" ShowFooter="false"></asp:GridView>
                </div>
        </div>
                                </div>
             </div>
      <script>
          function fnc() {
              window.document.getElementById('searchp').style.display = 'none';
              window.document.getElementById('wp').style.display = '';

          }
      </script>

              </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>



