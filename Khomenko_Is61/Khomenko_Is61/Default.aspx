﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Khomenko_Is61.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Home</title>

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
                            <li class="active"><a href="Default.aspx">Home</a></li>
                            <li><a href="AboutPage.aspx">About</a></li>
                            <li><a href="ChooseWay.aspx">Choose Way</a></li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Schedule<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li class="dropdown-header">Transport</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="ShowLocation.aspx">Show Location</a></li>
                                    <li><a href="ShowCompany.aspx">Show Company</a></li>
                                    <li><a href="ShowType.aspx">Show Type of vehicle</a></li>
                                    <li><a href="ShowVehicle.aspx">Show Vehicle</a></li>
                                    <li><a href="ShowRoute.aspx">Show Route</a></li>
                                </ul>
                            </li>
                            <li><a href="SignUp.aspx">Sign up</a></li>
                            <li><a href="SignIn.aspx">Sign in</a></li>
                        </ul>
                    </div>
                </div>
            </div>


            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    <%--<li data-target="#carousel-example-generic" data-slide-to="2"></li>--%>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src="Images/logo.jpg" alt="...">
                        <div class="carousel-caption">
                            ...
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/back3.jpg" alt="..." width="100000">
                        <div class="carousel-caption">
                            ...
                        </div>
                    </div>
                    ...
                </div>

                <!-- Controls -->
                <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>

        <br />
        <br />
        <div class="container center">
            <div class="row">
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/back.jpg" alt="thumb01" width="140" height="140" />
                    <h2>About</h2>
                    <p>Ви можете переглянути інформацію про автора та курсову роботу.</p>
                    <p><a class="btn btn-default" href="AboutPage.aspx" role="button">View &raquo;</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/back.jpg" alt="thumb02" width="140" height="140" />
                    <h2>Schedule</h2>
                    <p>Переглянути інформацію про розклад транспорту.</p>
                    <p><a class="btn btn-default" href="ShowRoute.aspx" role="button">View &raquo;</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/back.jpg" alt="thumb03" width="140" height="140" />
                    <h2>Choose Way</h2>
                    <p>Обрати маршрут/розклад по критеріям.</p>
                    <p><a class="btn btn-default" href="#" role="button">View &raquo;</a></p>
                </div>
            </div>
        </div>

        <!--- Footer -->
        <hr />
        <footer>
            <div class="container">
                <p class="pull-right"><a href="#">Back to top</a></p>
                <p>&copy; 2018 Khomenko Olexandr Is6128 &middot; <a href="Default.aspx">Home</a> &middot; <a href="AboutPage.aspx">About</a> &middot; <a href="ChooseWay.aspx">Choose Way</a> &middot; <a href="ShowRoute.aspx">Schedule</a> &middot;</p>
            </div>
        </footer>


    </form>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
