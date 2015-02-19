<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="AddUsers.aspx.cs" Inherits="CharityTracker.Admin.AddUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="page-header"><h1>Add User</h1></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="panel panel-default" data-ng-controller="TodoCtrl">
            <div class="panel-heading un-bold"><h4>Add Mileage</h4></div>
                <div class="panel-body">
                    <table class="col-sm-6">                                
                        <tr>
                            <td>
                                <label class="col-sm-2 control-label">User Name:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtUserName" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="User name is required" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                                </div>     
                            </td>
                        </tr>
                        <tr><td>&nbsp;</td></tr>                                
                        <tr>
                            <td>
                                <label class="col-sm-2 control-label">Password:</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr><td>&nbsp;</td></tr>
                        <tr>
                            <td>
                                <label class="col-sm-2 control-label">Role:</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="ddlRoleType" runat="server" CssClass="form-control chosen-select"></asp:DropDownList>   
                                </div>
                            </td>
                        </tr>
                        <tr><td>&nbsp;</td></tr>                                
                        <tr>
                            <td>
                                <div class="col-sm-7">
                                    <asp:Button ID="btnAddUser" class="btn-primary btn" runat="server" Text="Add" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="panel-footer"><div class="input-group"></div>
            </div>
        </div>                   
    </div>
    <div class="row">
        <div class="col-lg-12">                
            <div class="panel panel-default">
                <div class="panel-heading clean">Total Activities<div class="pull-right"></div></div>
                <div class="panel-body">
                <div>
                    <asp:Repeater ID="UserRepeater" runat="server">
                        <HeaderTemplate>
                            <table class="table no-margn">
                                <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Name</th>
                                    <th>Roles</th>
                                </tr>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="active">
                                <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%></td>
                                <td><%# Eval("UserName")%></td>
                                <td><%# Eval("RoleName")%></td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="warning">
                                <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%></td>
                                <td><%# Eval("UserName")%></td>
                                <td><%# Eval("RoleName")%></td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate></tbody></table></FooterTemplate>
                    </asp:Repeater>
                </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
