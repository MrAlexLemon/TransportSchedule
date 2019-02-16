<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseWay.aspx.cs" Inherits="Khomenko_Is61.ChooseWay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Welcome !</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/Custom-Cs.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <div>
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="Default.aspx"><span>
                            <img alt="Logo" src="Images/log.jpg" height="30" /></span>Be aware of urban transport</a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="Default.aspx">Home</a></li>
                            <li><a href="AboutPage.aspx">About</a></li>
                            <li class="active"><a href="ChooseWay.aspx">Choose Way</a></li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Schedule<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="ShowLocation.aspx">Show Location</a></li>
                                    <li><a href="ShowCompany.aspx">Show Company</a></li>
                                    <li><a href="ShowType.aspx">Show Type of vehicle</a></li>
                                    <li><a href="ShowVehicle.aspx">Show Vehicle</a></li>
                                    <li><a href="ShowRoute.aspx">Show Route</a></li>
                                </ul>
                            </li>
                            <li>
                                <asp:Button ID="btnSignOut" runat="server" Class="btn btn-default navbar-btn" Text="Sign Out" OnClick="btnSignOut_Click" />
                            </li>

                        </ul>
                    </div>
                </div>
            </div>
        </div>
        </div>

        <div class="container">
        <div class="form-horizontal">
            <h2>Choose Route</h2>
            <hr />
            
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Start Location"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlStar" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="This field is Required!" ControlToValidate="ddlStar"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="Finish Location"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlFin" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="This field is Required!" ControlToValidate="ddlFin"></asp:RequiredFieldValidator>
                </div>
            </div>
            

            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Vehicle Type"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="This field is Required!" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                </div>
            </div>

            <%--<div class="form-group">
                <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="Time"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="This field is Required!" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                </div>
            </div>--%>
            

            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="btnAdd" runat="server" Text="Find Route" CssClass="btn btn-default" OnClick="btnAdd_Click"/>
            </div>
                </div>
            </div>


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
</div>
       
    </form>

    <!--- Footer -->
    <hr />
    <footer>
        <div class="container">
            <p class="pull-right"><a href="#">Back to top</a></p>
            <p>&copy; 2018 Khomenko Olexandr Is6128 &middot; <a href="Default.aspx">Home</a> &middot; <a href="AboutPage.aspx">About</a> &middot; <a href="ChooseWay.aspx">Choose Way</a> &middot; <a href="ShowRoute.aspx">Schedule</a> &middot;</p>
        </div>
    </footer>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>