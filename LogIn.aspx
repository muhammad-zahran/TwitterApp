<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TwitterApp.LogIn" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="display: flex; flex-direction: column; justify-content: center; align-items: center; height: 100vh;">
    <form id="form1" runat="server" method="get" action="Home.aspx">
        <div style="text-align: center;">
            <!-- Twitter logo image with the align attribute set to "right" -->
            <img src="https://static.vecteezy.com/system/resources/thumbnails/018/930/745/small/twitter-logo-twitter-icon-transparent-free-free-png.png" alt="Twitter Logo" style="width: 100px; height: 100px;" align="right">
        </div>
        
        <div style="font-size: 35px; color: #1DA1F2; margin-top: 20px;">
            Twitter App
        </div>
        
        <table>
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td align="right">
                                <label for="username">User Name:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="username" runat="server" required></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label for="password">Password:</label>
                            </td>
                            <td>
                                <asp:TextBox ID="password" runat="server" TextMode="Password" required></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button1" runat="server" Text="Sign In" OnClick="Button1_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
