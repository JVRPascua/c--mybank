<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="IT22_OE2.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 245px;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 245px;
            height: 29px;
        }
        .auto-style4 {
            height: 29px;
        }
        form {
  text-align: center;
  font-family: sans-serif;
}
        table {
            text-align:center;
            font-family: sans-serif;
        }
        h1 {
            text-align: center;
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
        select {
  width: 100%;
  padding: 16px 20px;
  border: none;
  border-radius: 4px;
  background-color: #f1f1f1;
}
        input[type=text] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  box-sizing: border-box;
}
        input[type=text]:focus {
  background-color: lightblue;
}
        input[type=button], input[type=submit], input[type=reset] {
  background-color: #4CAF50;
  border: none;
  color: white;
  padding: 16px 32px;
  text-decoration: none;
  margin: 4px 2px;
  cursor: pointer;
}

    </style>
</head>
<body>
    <h1>LPU Bank Registration</h1>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">Account Number:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtAccountNumber" runat="server" ToolTip="Enter your Account Number" Width="383px"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style1">Account Name:</td>
                    <td>
                        <asp:TextBox ID="txtAccountName" runat="server" ToolTip="Enter your Account Name" Width="383px"></asp:TextBox>
                    </td>
                    
                </tr>
                    <tr>
                    <td class="auto-style3">Account Type:</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="txtAccountType" runat="server" ToolTip="Select Account Type">
                            <asp:ListItem>Savings</asp:ListItem>
                            <asp:ListItem>Current</asp:ListItem>
                            <asp:ListItem>Checking</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                    <tr>
                    <td class="auto-style1">Branch:</td>
                    <td>
                        <asp:DropDownList ID="txtBranch" runat="server" ToolTip="Select Branch">
                            <asp:ListItem>Calamba</asp:ListItem>
                            <asp:ListItem>Tanauan</asp:ListItem>
                            <asp:ListItem>San Pablo</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                    <tr>
                    <td class="auto-style1">Address:</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" ToolTip="Enter your Address" Width="383px"></asp:TextBox>
                    </td>
                    
                </tr>
                    <tr>
                    <td class="auto-style1">Contact Number:</td>
                    <td>
                        <asp:TextBox ID="txtContactNumber" runat="server" ToolTip="Enter your Contact Number" Width="383px"></asp:TextBox>
                    </td>
                    
                </tr>
                    <tr>
                    <td class="auto-style1">Currency:</td>
                    <td>
                        <asp:DropDownList ID="txtCurrency" runat="server" ToolTip="Select Currency">
                            <asp:ListItem>Peso</asp:ListItem>
                            <asp:ListItem>Dollar</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                    <tr>
                    <td class="auto-style1">Initial Deposit:</td>
                    <td>
                        <asp:TextBox ID="txtInitialDeposit" runat="server" ToolTip="Enter your Initial Deposit" Width="383px"></asp:TextBox>
                    </td>
                    
                </tr>
                    <tr>
                    <td class="auto-style1">PIN:</td>
                    <td>
                        <asp:TextBox ID="txtPin" runat="server" ToolTip="Enter your PIN" Width="383px"></asp:TextBox>
                    </td>
                    
                </tr>

                <tr>
                    <td class="auto-style1">
                        
                    <td>
                        <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" Width="383px" />
                    </td>
                 
                </tr>
            </table>
        </div>
        <div class="footer">
  <p>Lyceum of the Philippines University 2021</p>
</div>
        </br>
        <asp:GridView AutoGenerateColumns="false" ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="781px">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />

            <columns>
                <asp:templateField HeaderText ="Number">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:templateField>

                <asp:templateField HeaderText ="Account Number">
                    <ItemTemplate>
                        <asp:Label ID="txtAccountNumber" runat="server" Text='<%# Eval("accountnumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:templateField>

                <asp:templateField HeaderText ="Account Name">
                    <ItemTemplate>
                        <asp:Label ID="txtAccountName" runat="server" Text='<%# Eval("accountname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:templateField>

                <asp:templateField HeaderText ="Account Type">
                    <ItemTemplate>
                        <asp:Label ID="txtAccountType" runat="server" Text='<%# Eval("accounttype") %>'></asp:Label>
                    </ItemTemplate>
                </asp:templateField>

                <asp:templateField HeaderText ="Branch">
                    <ItemTemplate>
                        <asp:Label ID="txtBranch" runat="server" Text='<%# Eval("branch") %>'></asp:Label>
                    </ItemTemplate>
                </asp:templateField>

                <asp:templateField HeaderText ="Address">
                    <ItemTemplate>
                        <asp:Label ID="txtAddress" runat="server" Text='<%# Eval("address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:templateField>

                <asp:templateField HeaderText ="Contact Number">
                    <ItemTemplate>
                        <asp:Label ID="txtContactNumber" runat="server" Text='<%# Eval("contactnumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:templateField>

                <asp:templateField HeaderText ="Currency">
                    <ItemTemplate>
                        <asp:Label ID="txtCurrency" runat="server" Text='<%# Eval("currency") %>'></asp:Label>
                    </ItemTemplate>
                </asp:templateField>

                <asp:templateField HeaderText ="Initial Deposit">
                    <ItemTemplate>
                        <asp:Label ID="txtInitialDeposit" runat="server" Text='<%# Eval("initialdeposit") %>'></asp:Label>
                    </ItemTemplate>
                </asp:templateField>

                <asp:templateField HeaderText ="PIN">
                    <ItemTemplate>
                        <asp:Label ID="txtPin" runat="server" Text='<%# Eval("pinnumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:templateField>
            </columns>
        </asp:GridView>
    </form>
</body>
</html>
