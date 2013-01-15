<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BlogMaster.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="ASPPatterns.Chap4.ActiveReport.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="content">
    <h2>
        <%= Html.Encode(((Post)ViewData["LatestPost"]).Subject) %>
    </h2>
    <%= ((Post)ViewData["LastestPost"]).Text.Replace("\n", "<br/>") %>
    <br/>
    <i>
        Posted on <%= Html.Encode(((Post)ViewData["LastestPost"]).DataAdded.ToLongDateString())%>
    </i>
    <hr/>
    Comments<br/>
    <% foreach (var item in ((Post)ViewData["LatestPost"]).Comments)
       { %>

            <p> <i> <%= Html.Encode(item.Auther) %>
            said on <%= Html.Encode(item.DateAdded.ToLongDateString()) %>
                    at <%= Html.Encode(item.DateAdded.ToShortTimeString()) %> </i><br/>
            <%= Html.Encode(item.Text) %>
            </p>
       <% } 
    %>
    

</div>

</asp:Content>
