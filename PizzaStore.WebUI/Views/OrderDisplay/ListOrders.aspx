<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/StoreList.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<PizzaStore.Domain.Entities.Order>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ListOrders
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 align="center">New Orders</h2>

    <table align="center">
        <tr>
            
            <th>
                
            </th>
            <th>
                Order Number
            </th>
            <th>
                DateOrder
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>            
                New order placed:
            </td>
            <td>
                <%: item.OrdersID %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DateOrder) %>
            </td>
            <td>
                <%: Html.ActionLink("View", "DisplayOrders", new { orderID=item.OrdersID })%> |
                <%: Html.ActionLink("Delete", "DeleteOrder", new { orderID = item.OrdersID })%>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

