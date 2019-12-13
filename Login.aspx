<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookFactorys.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;height:100%">
           <tr>
               <td align="CENTER"><h1>Bodhidharma Heritage Books</h1></td>
           </tr>
            <tr>
                <td>
                    <table align ="center">
                        <tr>
                            <td>
                                User Name : 
                            </td>
                            <td>
                                <asp:TextBox runat="server" id="txtUsername"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            Password :
                                </td>
                            <td>
                                 <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button runat="server" Text="Login" OnClick="Unnamed1_Click" ID="btnLogin" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label runat="server" ForeColor="Red" id="lblMsg"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
