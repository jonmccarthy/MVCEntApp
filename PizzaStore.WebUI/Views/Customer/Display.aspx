<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/OnlineMenu.Master" Inherits="System.Web.Mvc.ViewPage<PizzaStore.Domain.Entities.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Display
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 align=center>Display Customer Details</h2>
    <table align=center><tr><td>
    <table>
    <tr><td>Title:</td><td><%: Model.Title %></td></tr>
    <tr><td>Firstname:</td><td><%: Model.Firstname %></td></tr>
    <tr><td>Surname:</td><td><%: Model.Surname %></td></tr>
    <tr><td>Phone:</td><td><%: Model.ContactPhone %></td></tr>
    <tr><td>Email:</td><td><%: Model.LoginPassword %></td></tr>
    <tr><td>Password:</td><td><%: Model.Email %></td></tr>
    <tr><td>Address:</td><td><%: Model.Address1 %></td></tr>
    <tr><td>Address:</td><td><%: Model.Address2 %></td></tr>
    <tr><td>Address:</td><td><%: Model.Address3 %></td></tr>
    <tr><td>County:</td><td><%: Model.County %></td></tr>
    <tr><td>Country:</td><td><%: Model.Country %></td></tr>
    </table>
       
    <p>

        <%: Html.ActionLink("Edit your details", "Edit", new { id=Model.CustomerID }) %> | <a href="/MenuItems/List">Continue to Menu</a> 
    </p>
    </td></tr></table>
</asp:Content>

