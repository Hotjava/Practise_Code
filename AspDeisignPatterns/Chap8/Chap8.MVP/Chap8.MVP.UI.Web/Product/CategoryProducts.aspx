<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Shop.Master" AutoEventWireup="true" CodeBehind="CategoryProducts.aspx.cs" Inherits="Chap8.MVP.UI.Web.Product.CategoryProducts" %>
<%@ Register src="~/Shared/ProductList.ascx" tagName="ProductList" tagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><asp:Literal runat="server" ID="litCategoryName"></asp:Literal></h2>
    <uc1:ProductList runat="server" ID="plCategoryProducts"  />
</asp:Content>
