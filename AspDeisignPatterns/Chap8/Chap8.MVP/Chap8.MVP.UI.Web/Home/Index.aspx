<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Chap8.MVP.UI.Web.Home.Index" MasterPageFile="../Shared/Shop.Master" %>
<%@ Register src="../Shared/ProductList.ascx" tagName="ProductList" tagPrefix="uc1" %>
<!<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Today’s Top Products</h2>
<uc1:ProductList ID="plBestSellingProducts" runat="server" />
</asp:Content>