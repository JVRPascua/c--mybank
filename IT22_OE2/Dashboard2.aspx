<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard2.aspx.cs" Inherits="IT22_OE2.Dashboard2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Welcome to your Account!</h1>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>Account Number</td>
                    <td>Account Name</td>
                    <td>Available Balance</td>
                </tr>
                <tr>
                    <td id="lblAccountNumber">&nbsp;</td>
                    <td id="lblAccountName">&nbsp;</td>
                    <td id="lblAvailableBalance">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
