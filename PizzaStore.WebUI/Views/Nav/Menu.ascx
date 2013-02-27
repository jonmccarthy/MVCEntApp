<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<PizzaStore.WebUI.Models.NavLink>>" %>
<table><tr>
<% foreach (var link in Model) { %>
<td><%: Html.RouteLink(link.Text, link.RouteValues, new Dictionary<string, object> { 
    { "class", link.IsSelected ? "selected" : null }
    }) %></td>
<% } %>
</tr></table>
