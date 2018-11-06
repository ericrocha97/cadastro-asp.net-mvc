<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroEstado.aspx.cs" Inherits="Atividade.Views.Cadastro_Estado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet">
    <link href="~\site\Style3.css" rel="stylesheet" />
    <title>Cadastro de Estados</title>
</head>
<body class="bg-dark">
    <div class="ESPACO">
    </div>
    <form id="form1" runat="server">
        
         
    <div class="row" style="width: 100%;">
     <div class="col-sm-3 data-toggle="collapse"">
     </div>
    <div class="col-sm-6">
        <div class="h2">
                <h2 class="text-uppercase text-center" style="color: #fff;text-shadow: 2px 2px 5px #272727;">Cadastro de Estados</h2>
        </div>
        <div class="form-group  ">
            <!--
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                     <span class="input-group-text">ID Estado</span>
                </div>
                <asp:TextBox ID="TextBoxID" runat="server" class="form-control"></asp:TextBox> <br />
            </div>
            -->
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Nome Estado</span>
                </div>
                <asp:TextBox ID="TextBoxNome" runat="server" class="form-control" required="required"></asp:TextBox> <br />
                </div>
            <div class="input-group mb-3">
                 <div class="input-group-prepend">
                    <span class="input-group-text">UF</span>
                 </div>
                    <asp:TextBox ID="TextBoxUF" runat="server" class="form-control" required="required"></asp:TextBox> <br />
             </div>
        </div>
        <asp:Button UseSubmitBehavior="false" ID="Gravar" runat="server" Text="Gravar" onclick="ButtonGravar" class="btn btn-success" /> 
             
        <button id="btexcluir" type="button" class="btn btn-danger" data-toggle="modal" data-target="#myModal">
  Excluir
</button>
<div class="modal" id="myModal">
  <div class="modal-dialog">
    <div class="modal-content">

      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title">Excluir</h4>
        <button type="button" class="close" data-dismiss="modal">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body">
          <div class="form-group  ">
              <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Código do Estado</span>
                </div>
                <asp:TextBox ID="TextBoxIdEx" runat="server" class="form-control" required="required"></asp:TextBox> <br />
                </div>
              </div>
        <asp:Button UseSubmitBehavior="false" ID="Excluir" runat="server" Text="Excluir" onclick="ButtonExcluir"  class="btn btn-danger" />
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Fechar</button>
      </div>

    </div>
  </div>
</div>

        <asp:Button UseSubmitBehavior="false" ID="Voltar" runat="server" Text="Voltar" onclick="ButtonVoltar" class="btn btn-primary" /> <br />
      <br />
        </div>
        <div class="row" style="width: 100%;">  
            <div class="col-sm-3 data-toggle="collapse"">
            </div>
            <div class="col-sm-6">
                 <div class="ESPACO">
                </div>
                <div style="margin-left: 20px;">
                    <asp:GridView ID="GridEstado" runat="server" AutoGenerateColumns="false" class="table table-striped table-dark"> 
                        <Columns>        
                            <asp:BoundField DataField="codigo" HeaderText="#" />
                            <asp:BoundField DataField="nome" HeaderText="Nome Estado" />
                            <asp:BoundField DataField="UF" HeaderText="UF" />
                       </Columns> 
                    </asp:GridView>
               </div>
            </div>
            <br />
        </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
