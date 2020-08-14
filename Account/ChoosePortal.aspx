<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChoosePortal.aspx.cs" Inherits="Account_ChoosePortal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Choose Portal..</title>
        <link href="../Styles/Customstyle1.css" rel="stylesheet" type="text/css" />
   
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
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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

    <div class= "container1">
     <div class="row">
            <div class="col-md-12">
            <h3>Choose Your Portal Here</h3>
            </div>

  </div>    
  <div class="row">
            <div class="col-md-12">
            <div class=" panel panel-default">
            <div class=" panel-body">
                <asp:LinkButton ID="LBhrms" runat="server" onclick="LBhrms_Click">Click Here For HRMS Portal</asp:LinkButton><br /><br />
                <asp:LinkButton ID="LBonlinereport" runat="server" Visible="false" 
                    onclick="LBonlinereport_Click">Click Here For Online Report Portal</asp:LinkButton><br /><br />

            </div>
            </div>
            </div>
    </div>
    </div>
    </form>
</body>
</html>
