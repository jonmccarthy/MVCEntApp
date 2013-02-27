<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<PizzaStore.Domain.Entities.MenuItem>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                MenuItemsID
            </th>
            <th>
                Category
            </th>
            <th>
                ProductName
            </th>
            <th>
                ProductDescription
            </th>
            <th>
                PortionSize
            </th>
            <th>
                ImageName
            </th>
            <th>
                MultiplePricing
            </th>
            <th>
                Price
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id = item.MenuItemsID })%> |
                <%: Html.ActionLink("Details", "Details", new { id=item.MenuItemsID })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.MenuItemsID })%>
            </td> 
            <td>
                <%: item.MenuItemsID %>
            </td>
            <td>
                <%: item.Category %>
            </td>
            <td>
                <%: item.ProductName %>
            </td>
            <td>
                <%: item.ProductDescription %>
            </td>
            <td>
                <%: item.PortionSize %>
            </td>
            <td>
                <%: item.ImageName %>
            </td>
            <td>
                <%: item.MultiplePricing %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Price) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.PriceSmall) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.PriceMedium) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.PriceLarge) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

