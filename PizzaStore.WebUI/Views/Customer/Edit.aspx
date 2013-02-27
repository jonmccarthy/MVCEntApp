<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/OnlineMenu.Master" Inherits="System.Web.Mvc.ViewPage<PizzaStore.Domain.Entities.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 align=center>Customer Signup</h2>

    <% using (Html.BeginForm("Edit", "Customer")) {%>
        <%: Html.ValidationSummary(true) %>
        
            <table align=center>
                <tr><td>Title:</td><td>
                    <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Title) %>
                    <%: Html.ValidationMessageFor(model => model.Title) %>
                    <%: Html.HiddenFor(model => model.CustomerID)%>
                    </div>
                </td></tr>
                <tr><td>First Name:</td><td>
                    <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Firstname) %>
                    <%: Html.ValidationMessageFor(model => model.Firstname) %>
                    </div>
                </td></tr>
                <tr><td>Surname:</td><td>
                    <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Surname) %>
                    <%: Html.ValidationMessageFor(model => model.Surname) %>
                    </div>
                </td></tr>
                <tr><td>Contact Phone:</td><td>
                    <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.ContactPhone) %>
                    <%: Html.ValidationMessageFor(model => model.ContactPhone) %>
                    </div>
                </td></tr>
                <tr><td>Email:</td><td>
                    <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Email) %>
                    <%: Html.ValidationMessageFor(model => model.Email) %>
                    </div>
                </td></tr>
                <tr><td>Password:</td><td>
                    <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.LoginPassword) %>
                    <%: Html.ValidationMessageFor(model => model.LoginPassword) %>
                    </div>
                </td></tr>
                <tr><td>Address:</td><td>
                    <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Address1) %>
                    <%: Html.ValidationMessageFor(model => model.Address1) %>
                    </div>
                </td></tr>
                <tr><td>Address:</td><td>
                <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Address2) %>
                <%: Html.ValidationMessageFor(model => model.Address2) %>
                </div>
                </td></tr>
                <tr><td>Address:</td><td>
                <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Address3) %>
                <%: Html.ValidationMessageFor(model => model.Address3) %>
                </div>
                </td></tr>
                <tr><td>County:</td><td>
                <div class="editor-field">
                <%: Html.TextBoxFor(model => model.County) %>
                <%: Html.ValidationMessageFor(model => model.County) %>
                </div>
                </td></tr>
                <tr><td>Country:</td><td>
                <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Country) %>
                <%: Html.ValidationMessageFor(model => model.Country) %>
                </div>
                </td></tr>
            </table>
            
            
            
            <p align=center>
                <input type="submit" value="Save" />
            </p>

    <% } %>
</asp:Content>

