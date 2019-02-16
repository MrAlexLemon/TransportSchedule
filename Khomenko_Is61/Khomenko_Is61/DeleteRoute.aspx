<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DeleteRoute.aspx.cs" Inherits="Khomenko_Is61.DeleteRoute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Delete Route</h2>
            <hr />

            <div class="form-group">
                <asp:Label ID="Label10" runat="server" CssClass="col-md-2 control-label" Text="Number of row, which tou want to delete"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="text-danger" runat="server" ErrorMessage="This field is Required!" ControlToValidate="TextBox7"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="Button1" runat="server" Text="Delete" CssClass="btn btn-default" OnClick="Button1_Click"/>
                    <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
            </div>
                </div>

            

        <h1>Route</h1>
        <hr />
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Routes</div>

            <asp:Repeater ID="rptrLoc" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Name of Route</th>
                                <th>Start Time</th>
                                <th>Arrival Time</th>
                                <th>Vehicle Name</th>
                                <th>Transport Name</th>
                                <th>Speed</th>
                                <th>Price</th>
                                <th>Interval</th>
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><asp:Label id="Id" runat="server" Text='<%# Eval("Id") %>'></asp:Label></td>
                        <td><asp:Label id="RName" runat="server" Text='<%# Eval("RName") %>'></asp:Label></td>
                        <td><asp:Label id="StartTime" runat="server" Text='<%# Eval("StartTime") %>'></asp:Label></td>
                        <td><asp:Label id="ArrivalTime" runat="server" Text='<%# Eval("ArrivalTime") %>'></asp:Label></td>
                        <td><asp:Label id="VName" runat="server" Text='<%# Eval("VName") %>'></asp:Label></td>
                        <td><asp:Label id="TName" runat="server" Text='<%# Eval("TName") %>'></asp:Label></td>
                        <td><asp:Label id="Speed" runat="server" Text='<%# Eval("Speed") %>'></asp:Label></td>
                        <td><asp:Label id="Price" runat="server" Text='<%# Eval("Price") %>'></asp:Label></td>
                        <td><asp:Label id="Interval" runat="server" Text='<%# Eval("Interval") %>'></asp:Label></td>
                        <%--<td><%# Eval("RName") %></td>
                        <td><%# Eval("StartTime") %></td>
                        <td><%# Eval("ArrivalTime") %></td>
                        <td><%# Eval("VName") %></td>
                        <td><%# Eval("TName") %></td>
                        <td><%# Eval("Speed") %></td>
                        <td><%# Eval("Price") %></td>
                        <td><%# Eval("Interval") %></td>--%>

                        <td>Edit</td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>

        </div>

        </div>
</asp:Content>
