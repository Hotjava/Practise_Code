<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPPatterns.Chap3.Layered.WebUI.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList runat="server" AutoPostBack="True" ID="ddlCustomerType">
            <asp:ListItem Value="0">Standard</asp:ListItem>
            <asp:ListItem Value="1">Trade</asp:ListItem>
        </asp:DropDownList>
        <asp:Label runat="server" ID="lblErrorMessage">
            
        </asp:Label>
        <asp:Repeater runat="server" ID="rptProducts">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            Name
                        </td>
                        <td>
                            RRP
                        </td>
                        <td>
                            Selling Price
                        </td>
                        <td>
                            Discount
                        </td>
                        <td>
                            Saving
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("Name") %>
                    </td>
                    <td>
                        <%# Eval("RRP")%>
                    </td>
                    <td>
                        <%# Eval("SellingPrice") %>
                    </td>
                    <td>
                        <%# Eval("Discount") %>
                    </td>
                    <td>
                        <%# Eval("Saving") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
