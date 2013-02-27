<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/General.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <% foreach (var item in Model.Orders) 
       { %>
    
    
        <li> <%= item.DateOrder %> </li>
    
    
    <% } %>

    <% foreach (var item in Model.OrderItems) 
       { %>
    
    
        <li> <%= item.ProductName %> </li>
    
    
    <% } %>

    <% foreach (var item in Model.DeliveryDetails) 
       { %>
    
    
        <li> <%= item.Surname %> </li>
    
    
    <% } %>


</asp:Content>
