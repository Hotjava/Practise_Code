<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="Chap8.MVP.UI.Web.Shared.CategoryList" %>
<asp:Repeater runat="server" ID="rptCategoryList">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
        <ItemTemplate>
            <li>
                <a href="/Views/Product/CategoryProducts.aspx?CategoryId=<%# Eval("Id") %>"></a>
            </li>
        </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>