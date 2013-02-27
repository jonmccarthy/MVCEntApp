<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/OnlineMenu.Master" Inherits="System.Web.Mvc.ViewPage<PizzaStore.Domain.Entities.DeliveryDetails>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CheckOut
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2 align=center>Check out now</h2>
    <p align=center>To complete your order, please fill out the form below!</p>

    <% using(Html.BeginForm()) { %>
        <%: Html.ValidationSummary() %>
        <table align=center>
        <tr><td>
        <h3>Name</h3>
        <table>
        <tr><td>First Name:</td><td><%: Html.EditorFor(x => x.Firstname)%></td></tr>
        <tr><td>Surname:</td><td><%: Html.EditorFor(x => x.Surname)%></td></tr>
        </table>

        <h3>Delivery Address</h3>
        <table>
        <tr><td>Address:</td><td><%: Html.EditorFor(x => x.Address1) %></td></tr>
        <tr><td>Address:</td><td><%: Html.EditorFor(x => x.Address2) %></td></tr>
        <tr><td>Address:</td><td><%: Html.EditorFor(x => x.Address3) %></td></tr>
        <tr><td>County:</td><td><%: Html.EditorFor(x => x.County) %></td></tr>
        <tr><td>Country:</td><td><%: Html.EditorFor(x => x.Country)%></td></tr>
        </table>
    
        <h3>Contact Phone</h3>
        <table>
        <tr><td>Phone:</td><td><%: Html.EditorFor(x => x.ContactPhone)%></td></tr>
        </table>
        </td></tr></table>

        <p align="center"><input type="submit" value="Complete order" /></p>
    <% } %>

</asp:Content>
