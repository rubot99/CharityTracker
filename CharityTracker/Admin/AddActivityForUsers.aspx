<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddActivityForUsers.aspx.cs" Inherits="CharityTracker.Admin.AddActivityForUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="page-header"><h1>Add Activities for Other Users</h1></div> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="panel panel-default" data-ng-controller="TodoCtrl">
            <div class="panel-heading un-bold"><h4>Add Mileage</h4></div>
            <div class="panel-body">
                <table class="col-sm-6">                                
                    <tr>
                        <td>
                            <label class="col-sm-2 control-label">Mileage:</label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtMileage" runat="server" class="form-control"></asp:TextBox>
                            </div>     
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td>
                            <label class="col-sm-2 control-label">Type:</label>
                            <div class="col-sm-7">
                                <asp:DropDownList ID="ddlActivityType" runat="server" CssClass="form-control chosen-select"></asp:DropDownList>   
                            </div>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr> 
                    <tr>
                        <td>
                            <label class="col-sm-2 control-label">Activity Date:</label>
                            <div class="col-sm-7">
                                <asp:Calendar ID="dtActivityDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                            </div>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>                   
                    <tr>
                        <td>
                            <div class="col-sm-7">
                                <asp:Button ID="btnAddMileage" class="btn-primary btn" runat="server" Text="Add" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="panel-footer"><div class="input-group"></div></div>
        </div>                   
    </div>
    <div class="row">
        <div class="col-lg-12">                
            <div class="panel panel-default">                
                <div class="panel-heading clean">All Activities added Today<div class="pull-right"></div></div>
                <div class="panel-body">
                    <div>
                        <asp:Repeater ID="ActivitiesRepeater" runat="server">
                            <HeaderTemplate>
                                <table class="table no-margn">
                                    <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Activity Type</th>
                                        <th>Mileage</th>
                                        <th>Activity Date</th>
                                    </tr>
                                    </thead>
                                <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="active">
                                    <td><%# Eval("RowNumber")%></td>
                                    <td><%# Eval("ActivityType")%></td>
                                    <td><%# Eval("Mileage")%></td>
                                    <td><%# Eval("DateAdded")%></td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr class="warning">
                                    <td><%# Eval("RowNumber")%></td>
                                    <td><%# Eval("ActivityType")%></td>
                                    <td><%# Eval("Mileage")%></td>
                                    <td><%# Eval("DateAdded")%></td>
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
