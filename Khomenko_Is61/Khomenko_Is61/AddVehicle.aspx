<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddVehicle.aspx.cs" Inherits="Khomenko_Is61.AddVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Add Vehicle</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Name of transport"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtNam" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="This field is Required!" ControlToValidate="txtNam"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="Name of Driver"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="txtDriv" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="This field is Required!" ControlToValidate="txtDriv"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Company"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlCom" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="This field is Required!" ControlToValidate="ddlCom"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="Type of transport"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="This field is Required!" ControlToValidate="ddlType"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default" OnClick="btnAdd_Click"/>
            </div>
                </div>
            </div>
        <h1>Transport/Vehicle</h1>
        <hr />
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Transport</div>

            <asp:Repeater ID="rptrLoc" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Name of transport</th>
                                <th>Name of driver</th>
                                
                                <th>Transport name</th>
                                <th>Speed</th>
                                <th>Price</th>
                                <th>Interval</th>
                                <th>Company name</th>
                                <th>Location</th>
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("Id") %></th>
                        <td><%# Eval("VName") %></td>
                        <td><%# Eval("Driver") %></td>
                        
                        <td><%# Eval("TName") %></td>
                        <td><%# Eval("Speed") %></td>
                        <td><%# Eval("Price") %></td>
                        <td><%# Eval("Interval") %></td>
                        <td><%# Eval("CName") %></td>
                        <td><%# Eval("AName") %></td>
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
