<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Atividade.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="~\Site\Style4.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet">

    <title>Home</title>
</head>
<body class="bg-dark">
    <div class="ESPACO">
    </div>

    <form id="form1" runat="server">
        <div class="row" style="width: 100%;">
            <div class="row" style="width: 100%;">
                <div class="col-sm" data-toggle="collapse">
                </div>
                <div class="col-sm">
                    <div class="d-flex justify-content-center">
                        <div class="h2" style="margin-bottom: 0px;">
                            <h2 class="text-uppercase text-center" style="margin-bottom: 0px; text-shadow: 2px 2px 5px #272727; width: 270px; color: #fff;">Cadastros</h2>
                        </div>
                    </div>
                    <div class="indexbt">
                        <div class="d-flex justify-content-center">
                            <asp:Button ID="CadCliente" runat="server" Text="Cadastro de Clientes" OnClick="CadCliente_Click" class="btn btn-primary rounded" />
                        </div>
                        <div class="d-flex justify-content-center">
                            <asp:Button ID="CadEstado" runat="server" Text="Cadastro de Estados" OnClick="CadEstado_Click" class="btn btn-primary rounded" />
                        </div>
                        <div class="d-flex justify-content-center">
                            <asp:Button ID="CadCidade" runat="server" Text="Cadastro de Cidades" OnClick="CadCidade_Click" class="btn btn-primary rounded" />
                        </div>
                        <div class="d-flex justify-content-center">
                            <asp:Button ID="CadProduto" runat="server" Text="Cadastro de Produtos" OnClick="CadProduto_Click" class="btn btn-primary rounded" />
                        </div>
                    </div>
                </div>
                <div class="col-sm" data-toggle="collapse">
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
