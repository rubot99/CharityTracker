<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CharityTracker.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="page-header"><h1>Login Page</h1></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="panel panel-default" data-ng-controller="TodoCtrl">
                <div class="panel-body">
                    <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
                        <LayoutTemplate>
                            <p class="validation-summary-errors">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                            <fieldset>
                                <legend>Log in Form</legend>
                                <table>
                                    <tr>
                                        <td><label class="col-sm-2 control-label">Username:</label>&nbsp;&nbsp;</td>
                                        <td><asp:TextBox runat="server" ID="UserName" class="form-control"/>&nbsp;&nbsp;</td>
                                        <td><asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." /></td>
                                    </tr>
                                    <tr><td colspan="3">&nbsp;</td></tr>
                                    <tr>
                                        <td><label class="col-sm-2 control-label">Password:</label>&nbsp;&nbsp;</td>
                                        <td><asp:TextBox runat="server" ID="Password" TextMode="Password" class="form-control"/>&nbsp;&nbsp;</td>
                                        <td><asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." /></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td colspan="2"><asp:CheckBox runat="server" ID="RememberMe" /><asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"><asp:Button runat="server" CommandName="Login" Text="Log in" class="btn-primary btn"/></td>
                                    </tr>
                                </table>                                
                            </fieldset>
                        </LayoutTemplate>
                    </asp:Login>
                </div>
            </div>
        </div>
</asp:Content>
