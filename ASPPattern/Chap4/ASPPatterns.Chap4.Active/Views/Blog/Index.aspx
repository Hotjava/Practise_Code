<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BlogMaster.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="ASPPatterns.Chap4.ActiveReport.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="content">
    <h2>
        <%= Html.Encode((Post)ViewData) %>
    </h2>
</div>

</asp:Content>
