<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/OnlineMenu.Master" Inherits="System.Web.Mvc.ViewPage<PizzaStore.Domain.Entities.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align=center><tr><td>
    <h2>Customer Login</h2>
    
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
                    
            <div class="editor-label">
                Email:
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
            
            <div class="editor-label">
                Password:
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(model => model.LoginPassword)%>
                <%: Html.ValidationMessageFor(model => model.LoginPassword) %>
            </div>
                       
            
            <p>
                <table><tr><td><input type="submit" value="Login" /></td><td>Don't have an Account? <a href="/Customer/Create">Click here</a> to sign up!!</td></tr></table>
                
            </p>

    <% } %>
    </td></tr></table>


</asp:Content>

