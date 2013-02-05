<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductList.ascx.cs" Inherits="Chap8.MVP.UI.Web.Shared.ProductList" %>
<asp:Repeater runat="server" ID="rptProducts">
    <ItemTemplate>
        <%# Eval("Name") %> only <%# Eval("Price", "{0:C}") %> <br/>
        <a href="/Views/Product/ProductDetail.aspx?ProductId=<%# Eval("Id") %>">more info/a>
        <hr/>
    </ItemTemplate>
</asp:Repeater>