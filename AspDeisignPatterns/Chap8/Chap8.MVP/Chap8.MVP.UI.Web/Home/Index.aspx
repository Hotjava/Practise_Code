<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Chap8.MVP.UI.Web.Home.Index" MasterPageFile="../Shared/Shop.Master" %>
<%@ Register src="../Shared/ProductList.ascx" tagName="ProductList" tagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Today’s Top Products</h2>
<uc1:ProductList ID="plBestSellingProducts" runat="server" />
</asp:Content>