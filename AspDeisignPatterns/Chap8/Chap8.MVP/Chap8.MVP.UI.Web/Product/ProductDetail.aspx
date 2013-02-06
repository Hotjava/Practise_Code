<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Shop.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="Chap8.MVP.UI.Web.Product.ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><asp:Literal ID="litName" runat="server"/></h2>
<p>pay: <asp:Literal ID="litPrice" runat="server"/></p>
<p><asp:Literal ID="litDescription" runat="server"/></p>
<p><asp:Button ID="btnAddToBasket" runat="server" Text="Add to Basket" onclick="btnAddToBasket_Click"/></p> 
</asp:Content>
