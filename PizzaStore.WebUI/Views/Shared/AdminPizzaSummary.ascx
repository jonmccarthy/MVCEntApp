<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PizzaStore.Domain.Entities.MenuItem>" %>
<div class="items">
        <div class="item">
        <table border=0 width=500px align=center>
            <tr>
                <td><h2><%: Model.ProductName %></h2></td>
            </tr>
            <tr>
                <td><h3><%: Model.ProductDescription %></h3></td>
            </tr>
            <tr>
                <td>
                    <table width=100%>
                        <tr>
                            <td width=300px valign=top>
                            <% if (Model.ImageData != null)
                               { %>
                                <div>
                                    <img src="<%: Url.Action("GetImage", "MenuItems", new { Model.MenuItemsID }) %>" ? />
                                </div>
                            <% }
                               else
                               { %>
                               <div>
                                    <img src="/Content/images/image_coming_soon.jpg" />
                               </div>
                            <% } %>
                            </td>
                            <td valign=top>
                                <% if (Model.PriceSmall > 0)
                                   { %>
                                        <h3>Small: <%: Model.PriceSmall.ToString("#0.00") %></h3>
                                        <h3>Medium: <%: Model.PriceMedium.ToString("#0.00") %></h3>
                                        <h3>Large: <%: Model.PriceLarge.ToString("#0.00") %></h3>
                                <% }
                                   else
                                   { %>
                                        <h3>Price: <%: Model.Price.ToString("#0.00") %></h3>
                                <% } %>
                                
                                
                                <h3>Portion Size: <%: Model.PortionSize %></h3><br />
                                <%: Html.ActionLink("Create New", "Create") %> |
                                <%: Html.ActionLink("Edit", "Edit", new { id = Model.MenuItemsID })%> |
                                <%: Html.ActionLink("Delete", "Delete", new { id = Model.MenuItemsID })%>
                           </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
            
             
            
            
            
            <hr />
        </div> 
</div>
