<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

              <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:Timer runat="server" id="UpdateTimer" interval="1000" ontick="UpdateTimer_Tick" />
              <asp:RadioButtonList ID="RadioButtonList1" runat="server" >
                  <asp:ListItem>A</asp:ListItem>
                  <asp:ListItem>B</asp:ListItem>
                  <asp:ListItem>C</asp:ListItem>
                  <asp:ListItem>D</asp:ListItem>
              </asp:RadioButtonList>
        <asp:UpdatePanel runat="server" id="TimedPanel" updatemode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="UpdateTimer" eventname="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label runat="server" id="DateStampLabel" />
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
