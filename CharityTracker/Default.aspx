<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CharityTracker.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="page-header"><h1>Dashboard <small>Let's get a quick overview...</small></h1></div> 
    <div class="row">            
        <div class="col-md-2 col-sm-4">
            <div class="panel panel-default clearfix dashboard-stats rounded">
                <span class="sparkline transit"><span class="text-red"><asp:Literal ID="litTotalUsersMiles" runat="server"></asp:Literal> of <asp:Literal ID="litTotalOfficeMiles" runat="server"></asp:Literal></span></span>
                <i class="fa fa-circle bg-success transit stats-icon"></i>
                <h3 class="transit"><asp:Literal ID="litTotalMileage" runat="server"></asp:Literal> <small class="text-green"><%--<i class="fa fa-caret-up"></i>--%> </small></h3>
                <p class="text-muted transit">Total Mileage</p>
            </div>
        </div>               
    </div>
    <div class="row">                
        <asp:Repeater ID="ActivityOffices" runat="server">
            <ItemTemplate>
                <div class="col-md-2 col-sm-4">
                    <div class="panel panel-default clearfix dashboard-stats rounded">
                    <span class="sparkline transit"><span class="text-red"><%# Eval("MileageCompleted")%> of <%# Eval("Mileage")%></span></span>
                    <i class="fa fa-university bg-info transit stats-icon"></i>
                    <h3 class="transit"><%# Eval("Mileage")%> <small class="text-red"></small></h3>
                    <p class="text-muted transit"><%# Eval("Office1")%> Office</p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
