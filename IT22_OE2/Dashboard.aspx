<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="IT22_OE2.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 909px;
        }
        form {
            font-family: sans-serif;
        }
        .footer {
  position: fixed;
  left: 0;
  bottom: 0;
  width: 100%;
  background-color: black;
  color: white;
  text-align: center;
  font-family: sans-serif;
}
   

    </style>
</head>
    <title>Dashboard</title>

    
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Label ID="lblUserDetail" runat="server" Text="User Detail"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" Width="172px" OnClick="btnLogout_Click" style="height: 29px" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
            <h1>Welcome to your Account!</h1>
        </div>
        <div class="footer">
  <p>My Bank 2021</p>
</div>

    </form>
</body>
</html>
