<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutPage.aspx.cs" Inherits="Khomenko_Is61.AboutPage" %>

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
                            <li><a href="Default.aspx">Home</a></li>
                            <li class="active"><a href="AboutPage.aspx">About</a></li>
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

            <div class="container">
                <h2>Хоменко Олександр  Група ІС-61</h2>
                <h3>Тема курсової: "Міський транспорт"</h3>
                <h3>Заліковка: ІС6128</h3>
                <div class="row">
                    <div class="col-md-4">
                        <div class="thumbnail">
                            <a href="Images/Khomenko.jpg" target="_blank">
                                <img src="Images/Khomenko.jpg" alt="Lights" style="width: 100%">
                                <%--<div class="caption">
            <p>Lorem ipsum donec id elit non mi porta gravida at eget metus.</p>
          </div>--%>
                            </a>
                        </div>
                    </div>
                    <p>Для візуалізації результату виконання курсової роботи була написана програма, яка взаємодіє з базою даних і представляє графічний інтерфейс до обраної теми.</p>
                    <p>Програма(сайт) написаний за допомогою технології ASP.NET. Сайт є гнучким, тобно з ним можна працювати з браузера на комп'ютері і на телефоні. Це досягається за допомогою Bootstrap.</p>
                    <p>Для кращого орієнтування на сайті була створена навігаційна панель. Home-початкова сторінка. About-сторінка з інформацією про автора і курсову. Choose Way-сторінка для вибору маршруту/розкладу міського транспорту.</p>
                    <p>Schedule - випадаюче меню з підпунктами. Якщо ви не зареєструвалися на сайті або зайшли як корисувач, то ви можете подивитися данні по таблицям відповідно до пунктів меню.</p>
                    <p>Sign Up - сторінка для реєстрації користувача. Sign In - сторінка для входу в систему. Можна ввійти як адмін Логін-admin , Пароль-admin.</p>
                    <p>Можна ввійти як користувач, то перед цим потрібно зареєструватися.</p>
                    <p>Знизу на сторінках є панель для швидкого переміщення вверх сторінки і пунктах меню. Якщо ви знаходитися в системі ви можете вийти з акаунта, натиснувши Logout.</p>
                    <p>Якщо Ви ввійшли як адміністратор, то Вам відкриваються можливості редагувати таблиці бази данних(Добавляти нові записи,Оновлювати старі і видаляти). При цьому данні відображаються у таблицях.</p>
                    <p>Ви можете змінювати маршрут/розклад міського транспорту при необхідності, а також зв'язаних факторів.</p>
                    <p>Щоб добавити другорядні фактори потрібно у вкладці Manage вибрати таблицю і там добавити новий запис.</p>
                    <p>У вкладці Schedule Ви можете добавляти,оновлювати,видаляти дані з розкладу міського транспорту, ці дані відповідно будуть добавлятися,оновлюватися,видалятися у зв'язаних/залежних таблицях. </p>
                    <p>Інші загальні вкладки залишаються і їх функіонал не змінюється.</p>


                </div>
            </div>


        </div>
    </form>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
