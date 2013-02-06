<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductList.ascx.cs" Inherits="Chap8.MVP.UI.Web.Shared.ProductList" %>
<asp:Repeater runat="server" ID="rptProducts"> 
    onitemcommand="rptProducts_ItemCommand>
    <ItemTemplate>
        <%# Eval("Name") %> only <%# Eval("Price", "{0:C}") %> <br/>
        <a href="/ViewProduct/ProductDetail.aspx?ProductId=<%# Eval("Id") %>">more info</a>
        <asp:Button runat="server" Text="Add to Basket"/>
        <hr/>
    </ItemTemplate>
</asp:Repeater>