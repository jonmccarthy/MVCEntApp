<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdminHome.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<PizzaStore.Domain.Entities.Customer>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table border=1 width="90%">
    <tr><th>Customer ID</th><th>Firstname:</th><th>Surname:</th><th>Address:</th><th>Address:</th><th>Address:</th><th>Email:</th><th>Password:</th><th>County:</th><th>Country</th><th>Edit</th></tr>
    <% foreach (var customer in Model) { %>
    
        <tr>
            <td>
                <%: customer.CustomerID %>
            </td>
            <td>
                <%: customer.Firstname %>
            </td>
            <td>
                <%: customer.Surname %>
            </td>
            <td>
                <%: customer.Address1 %>
            </td>
            <td>
                <%: customer.Address2 %>
            </td>
            <td>
                <%: customer.Address3 %>
            </td>
            <td>
                <%: customer.Email %>
            </td>
            <td>
                <%: customer.LoginPassword %>
            </td>
            <td>
                <%: customer.County %>
            </td>
            <td>
                <%: customer.Country %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id = customer.CustomerID })%> 
            </td>
        </tr>
    
    <% } %>

    </table>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>
