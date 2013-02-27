<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdminOnlineMenu.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<PizzaStore.Domain.Entities.MenuItem>>" %>
<%@ Import Namespace="PizzaStore.Domain.Entities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Menu Items
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        foreach (var menuitems in Model)
        { %>
        <% Html.RenderPartial("AdminPizzaSummary", menuitems); %>

   <% } %>

</asp:Content>
