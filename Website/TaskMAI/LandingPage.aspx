<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LandingPage.aspx.cs" Inherits="LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Helper/css/style.default.css" rel="stylesheet" />
    <link href="Helper/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header class="header1">
            <nav class="navbar navbar-expand-lg px-4 py-4 bg-white shadow">

            </nav>
        </header>

        <div class="page-holder w-100 d-flex flex-wrap">
            <div class="container-fluid px-x1-5">
                <section class="py-5">
                    <div class="row">

                        <div class="col-lg-5">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="h6 text-uppercase mb-0">Already have an account? Log-in here</h3>
                                </div>
                                <div class="card-body">
                                    <a href="Login.aspx" type="button" class="btn btn-primary">Log-in</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="h6 text-uppercase mb-0">Don't have an account yet? Sign up here</h3>
                                </div>
                                <div class="card-body">
                                    <a href="Register.aspx" type="button" class="btn btn-primary">Sign up</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>

                <footer class="footer bg-white shadow align-self-end py-3 px-xl-5 w-100 "
                    style="text-align:end;margin-top:390px">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-6 text-center text-md-left text-primary">
                                <p class="mb-2 mb-md-0"></p>
                            </div>
                        </div>
                    </div>
                </footer>
            </div>
        </div>
    </form>
</body>
</html>
