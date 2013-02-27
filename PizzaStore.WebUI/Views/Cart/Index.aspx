<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/OnlineMenu.Master" Inherits="System.Web.Mvc.ViewPage<PizzaStore.WebUI.Models.CartIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Pizza Store : Your Cart
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Your Cart</h2>

    <table width="90%" align="center">
        <thead>
            <tr>
                <th align="center">Quantity</th>
                <th align="left">Item</th>
                <th align="right">Price</th>
                <th align="right">Subtotal</th>
            </tr>
        </thead>
        <tbody>
            <% foreach(var line in Model.Cart.Lines) { %>
                <tr>
                    <td align="center"><%: line.Quantity %></td>
                    <td align="left"><%: line.MenuItem.ProductName %></td>
                    <td align="right"><%: line.MenuItem.Price.ToString("c")%></td>
                    <td align="right">
                        <%: (line.Quantity * line.MenuItem.Price).ToString("c")%>
                    </td>
                    <td>
                        <% using(Html.BeginForm("RemoveFromCart", "Cart")) { %>
                            <%: Html.Hidden("MenuItemsID", line.MenuItem.MenuItemsID)%>
                            <%: Html.HiddenFor(x => x.ReturnUrl) %>
                            <input type="submit" value="Remove" />
                        <% } %>
                    </td>
                </tr>
            <% } %>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="3" align="right">Total:</td>
                <td align="right">
                    <%: Model.Cart.ComputeTotalValue().ToString("c") %>
                </td>
            </tr>
        </tfoot>
    </table>

    <p align="center" class="actionButtons">
        <a href="<%: Model.ReturnUrl %>">Continue shopping</a>
        <%: Html.ActionLink("Check out now", "CheckOut") %>
    </p>
</asp:Content>
