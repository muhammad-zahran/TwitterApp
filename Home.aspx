<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TwitterApp.Home" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" style="width: 100%;">
            <tr>
                <td align="center">
                    <div>
                        &nbsp;<br />
                        Write a Post here
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:TextBox ID="tweet" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="Button1" runat="server" Text="Add Post" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
