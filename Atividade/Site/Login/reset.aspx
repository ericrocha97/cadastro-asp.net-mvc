<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reset.aspx.cs" Inherits="Atividade.Site.Login.reset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta name="author" content="Kodinger">
    <title>Redefinir Senha &mdash; RealDelivery</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/my-login.css">
</head>
<body class="my-login-page bg-dark">
    <section class="h-100">
        <div class="container h-100">
            <div class="row justify-content-md-center align-items-center h-100">
                <div class="card-wrapper">
                    <div class="brand">
                        <img src="img/logo.jpg">
                    </div>
                    <div class="card fat">
                        <div class="card-body">
                            <h4 class="card-title">Redefinir Senha</h4>
                            <form id="form1" runat="server">
                                <div class="form-group">
                                    <label for="newpassword">Nova senha</label>
                                  <!--  <input id="new-password" type="password" class="form-control" name="password" required autofocus data-eye> -->
                                    <asp:TextBox ID="newpassword" type="password" runat="server" class="form-control" name="password" required autofocus data-eye ></asp:TextBox>
                                    <div class="form-text text-muted">
                                        Certifique-se de que sua senha seja forte e fácil de lembrar
                                    </div>
                                </div>

                                <div class="form-group no-margin">
                                   <!-- <button type="submit" class="btn btn-primary btn-block">
                                        Redefinir Senha
                                    </button> -->
                                    <asp:Button ID="Reset" runat="server" Text="Redefinir Senha"  class="btn btn-primary btn-block" OnClick="ButtonReset"/>
                                </div>
                            </form>
                        </div>
                    </div>
                    <div class="footer">
                        Copyright &copy; BENR 2018
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script src="js/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <script src="js/my-login.js"></script>
</body>
</html>
