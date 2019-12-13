<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="BookFactorys.BookDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:MultiView ID="mulView" runat="server">

            <asp:View ID="searchView" runat="server">
                <table style="width: 100%; height: 100%">
                    <tr>
                        <td>
                            <h1>Search Book</h1>
                        </td>
                    </tr>
                    <tr>
                        <td>search Author, Publisher or Title :
                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearch" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnSearch" Text="Search Book" runat="server" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grdBookDetails" runat="server"></asp:GridView>
                        </td>
                    </tr>
                    <tr>
                            <td align="center" colspan="2">
                                <asp:Label runat="server" ForeColor="Red" id="lblMsg"></asp:Label>
                            </td>
                        </tr>
                </table>
            </asp:View>

            <asp:View ID="addView" runat="server">
               <table>
                   <tr>
                       <td colspan="2">
                           <h1>Add New Book</h1>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           Book Name :
                       </td>
                           <td>
                               <asp:TextBox ID="txtBookName" runat="server"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBookName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                   <tr>
                       <td>
                           Book Catetory :
                       </td>
                       <td>
                           <asp:TextBox ID="txtBookCategoty" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBookCategoty" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           Author Name :
                       </td>
                       <td>
                           <asp:TextBox ID="txtAuthorName" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAuthorName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           Edition :
                       </td>
                       <td>
                           <asp:TextBox ID="txtEdition" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEdition" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                       </td>
                       </tr>
                   <tr>
                       <td>
                           Price :
                       </td>
                       <td>
                           <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPrice" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2" align="right">
                           <asp:Button ID="btnAdd" runat="server" Text="Add Book" OnClick="btnAdd_Click" />
                       </td>
                   </tr>
               </table>
            </asp:View>
        </asp:MultiView>

    </div>
    </form>
</body>
</html>
