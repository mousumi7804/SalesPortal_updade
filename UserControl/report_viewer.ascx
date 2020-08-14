<%@ Control Language="C#" AutoEventWireup="true"  CodeFile="report_viewer.ascx.cs"
    Inherits="demo_UserControl_report_viewer" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title></title>
</head>
<body>

<div style="width:95%;margin: auto; color:Black;" >
  <rsweb:ReportViewer ID="ReportViewer1" ShowBackButton="true"  ShowPrintButton="true" ShowRefreshButton="false" BorderWidth="2px"
        runat="server" Width="100%" Height="500px">
    </rsweb:ReportViewer>
    </div>
</body>
</html>
