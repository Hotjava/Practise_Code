<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="Chap8.MVP.UI.Web.Shared.CategoryList" %>
<asp:Repeater runat="server" ID="rptCategoryList">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
        <ItemTemplate>
            <li>
                <a href="/Views/PProduct/CategoryProducts.aspx?CategoryId=<%# Eval("Id") %>"><%# Eval("Name") %           </li>
        </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>