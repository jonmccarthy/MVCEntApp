﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/General.Master" Inherits="System.Web.Mvc.ViewPage<PizzaStore.WebUI.Controllers.OrderViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DisplayOrders
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 align="center">Order Display</h1>
    
    <% foreach (var item in Model.DeliveryDetails) 
       { %>
        
        <table align="center" width=90%><tr><td>
        <h3>Customer Details</h3>
        <table>
        <tr><td>Customer Name:</td><td><%= item.Firstname %> <%= item.Surname%></td></tr>
        <tr><td>Contact Phone:</td><td><%= item.ContactPhone%></td></tr>
        </table>
        <br />
        <h3>Delivery Address</h3>
        <table>
        <tr><td><%= item.Address1%></td></tr>
        <tr><td><%= item.Address2%></td></tr>
        <tr><td><%= item.Address3%></td></tr>
        <tr><td><%= item.County%></td></tr>
        <tr><td><%= item.Country%></td></tr>
        </table>
        </td><td valign=top width=500px>
        <%: Html.ActionLink("Complete", "CompleteOrder", new { orderID = item.FKOrderID })%> - <%: Html.ActionLink("Back to List", "ListOrders")%> - <%: Html.ActionLink("Delete", "DeleteOrder", new { orderID = item.FKOrderID })%>
    <% } %>

    <h3 align="center">Order Items</h3>
    <table align="center" border=1 width=90%>
    <tr><th>Name</th><th>Description</th><th>Quantity</th><th>Price</th></tr>
    <% foreach (var item in Model.OrderItems) 
       { %>
           <tr><td><%= item.ProductName %></td><td><%= item.ProductDescription%></td><td><%= item.Quantity%></td><td><%= String.Format("{0:F}",item.Price) %></td></tr>
    <% } %>
    </table>
    <br />
    </td></tr></table>
    
</asp:Content>
