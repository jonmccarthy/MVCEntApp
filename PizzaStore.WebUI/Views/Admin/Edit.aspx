<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/General.Master" Inherits="System.Web.Mvc.ViewPage<PizzaStore.Domain.Entities.MenuItem>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Admin : Edit <%: Model.ProductName %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script language=javascript>
    <!--
    var delayTime = 50 * 5
    setTimeout(CheckCategory, delayTime)
    //-->
    function MultipleFields()
    {

        if (document.all.SinglePrice.style.visibility == 'visible') {
            document.all.MultiplePricing1.style.visibility = 'visible';
            document.all.MultiplePricing2.style.visibility = 'visible';
            document.all.MultiplePricing3.style.visibility = 'visible';
            document.all.SinglePrice.style.visibility = 'hidden';
            document.all.PriceSmall.value = "0";
            document.all.PriceMedium.value = "0";
            document.all.PriceLarge.value = "0";
        } else {
            document.all.MultiplePricing1.style.visibility = 'hidden';
            document.all.MultiplePricing2.style.visibility = 'hidden';
            document.all.MultiplePricing3.style.visibility = 'hidden';
             document.all.SinglePrice.style.visibility = 'visible';
        }

     }

     function CheckCategory() {
         if (document.all.Category.value == 'Pizzas') {
             document.all.MultiplePricing1.style.visibility = 'visible';
             document.all.MultiplePricing2.style.visibility = 'visible';
             document.all.MultiplePricing3.style.visibility = 'visible';
             document.all.SinglePrice.style.visibility = 'hidden';
             document.all.PriceSwitch.checked = 1;
         } else {
             document.all.MultiplePricing1.style.visibility = 'hidden';
             document.all.MultiplePricing2.style.visibility = 'hidden';
             document.all.MultiplePricing3.style.visibility = 'hidden';
             document.all.SinglePrice.style.visibility = 'visible';
         }

     }
</script>

    <h2 align=center>Edit <%: Model.ProductName %></h2>

    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Edit", "Admin", FormMethod.Post,
                             new { enctype = "multipart/form-data" })) { %>
    <table width=100% align=center>
        <tr>
            <td>
            
                <table align=center>
                <tr><td>Category:</td><td>
                    <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Category) %>
                    
                    <%: Html.ValidationMessageFor(model => model.Category) %>
                    </div>
                </td></tr>
                <tr><td>Product Name:</td><td>
                    <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.ProductName) %>
                    <%: Html.ValidationMessageFor(model => model.ProductName) %>
                    </div>
                </td></tr>
                <tr><td valign=top>Product Description:</td><td>
                    <div class="editor-field">
                    <%: Html.TextAreaFor(model => model.ProductDescription, new { cols = 22, rows = 7 })%>
                    <%: Html.ValidationMessageFor(model => model.ProductDescription) %>
                    </div>
                </td></tr>
                <tr><td>Portion Size:</td><td>
                    <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.PortionSize) %>
                    <%: Html.ValidationMessageFor(model => model.PortionSize) %>
                    </div>
                </td></tr>
                <tr><td>Multiple Pricing:</td><td>
                    <div class="editor-field">
                        <input type="checkbox" id="PriceSwitch" name="PriceSwitch" onclick="MultipleFields();" />
                    </div>
                </td></tr>
                <tr id="SinglePrice" style="visibility: visible;"><td>Price:</td><td>
                    <div class="editor-field">
                    <%: Html.EditorFor(model => model.Price, new { @class = "money" })%>
                    <%: Html.ValidationMessageFor(model => model.Price)%>
                    </div>
                </td></tr>
                <tr id="MultiplePricing1" style="visibility: hidden;"><td>Price Small:</td><td>
                    <div class="editor-field">
                    <%: Html.EditorFor(model => model.PriceSmall, new { @class = "money" })%>
                    <%: Html.ValidationMessageFor(model => model.PriceSmall)%>
                    </div>
                </td></tr>
                <tr id="MultiplePricing2" style="visibility: hidden;"><td>Price Medium:</td><td>
                    <div class="editor-field">
                    <%: Html.EditorFor(model => model.PriceMedium, new { @class = "money" })%>
                    <%: Html.ValidationMessageFor(model => model.PriceMedium)%>
                    </div>
                </td></tr>
                <tr id="MultiplePricing3" style="visibility: hidden;"><td>Price Large:</td><td>
                <div class="editor-field">
                <%: Html.EditorFor(model => model.PriceLarge, new { @class = "money" })%>
                <%: Html.ValidationMessageFor(model => model.PriceLarge)%>
                </div>
                </td></tr>
                </table>
            </td>
            <td valign=top>
                <div class="editor-label">Image</div>
                <div class="editor-field">
                    <% if (Model.ImageData == null)
                       { %>
                        None
                    <% }
                       else
                       { %>
                        <img src="<%: Url.Action("GetImage", "MenuItems", new { Model.MenuItemsID})  %>" />
                    <% } %>
                    <div>Upload new image: <input type="file" name="Image" /></div>
                </div>
            </td>
        </tr>
    </table>
    <p align=center>
    <%: Html.HiddenFor(x => x.MenuItemsID) %>
    <input type="submit" value="Save" />
    </p>

    <% } %>
</asp:Content>

