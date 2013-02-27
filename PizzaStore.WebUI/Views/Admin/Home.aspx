<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdminHome.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    

    <table>
    <tr>
        <td><h2>This is the landing page for the Backend Admin section</h2></td>
    </tr>
    <tr>
        <td>
            <table>
                <tr><td><%: Html.ActionLink("Update Menu", "List") %></td></tr>
                <tr><td><%: Html.ActionLink("View Customer Info", "List") %></td></tr>
                <tr><td><%: Html.ActionLink("Promotions", "List") %></td></tr>
                <tr><td><%: Html.ActionLink("Vouchers", "List") %></td></tr>
            </table>
        </td>
    </tr>
    </table>

</asp:Content>
