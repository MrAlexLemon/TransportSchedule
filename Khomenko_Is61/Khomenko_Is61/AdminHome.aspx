<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="Khomenko_Is61.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome Admin !</h1>
    <br />
        <br />
        <div class="container">
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
                        <th><%# Eval("Id") %></th>
                        <td><%# Eval("RName") %></td>
                        <td><%# Eval("StartTime") %></td>
                        <td><%# Eval("ArrivalTime") %></td>
                        <td><%# Eval("VName") %></td>
                        <td><%# Eval("TName") %></td>
                        <td><%# Eval("Speed") %></td>
                        <td><%# Eval("Price") %></td>
                        <td><%# Eval("Interval") %></td>

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
