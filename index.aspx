<%@ Page Language="C#" Src="bin/Controllers/Login.aspx.cs" Inherits="Controllers.Login"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Responsive Bootstrap Advance Admin Template</title>

    <!-- BOOTSTRAP STYLES-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

</head>
<body style="background-color: #E2E2E2;">
      <div class="container">
        <div class="row text-center " style="padding-top:100px;">
          <div class="col-md-12">
              <h1>Storage System</h1>
              <p>Sistema de control de inventario</p>
          </div>
        </div>
        <div class="row ">
          <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                       
            <div class="panel-body">
              <form role="form" action="#" method="post" runat="server">
                  <hr />
                  <h5>Ingrese Rut y Contraseña</h5>
                  <br />
                  <div class="form-group input-group">
                      <span class="input-group-addon"><i class="fa fa-tag"  ></i></span>
                      <asp:TextBox type="text" class="form-control" placeholder="RUT " name="rut" id="rut" runat="server"/></asp:TextBox>
                  </div>
                  <div class="form-group input-group">
                      <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>
                      <asp:TextBox type="password" class="form-control"  placeholder="Contraseña" name="pass" id="pass" runat="server"/></asp:TextBox>
                  </div>
                  <div class="form-group">
                      <label class="checkbox-inline">
                          <input type="checkbox" /> Recordarme
                      </label>
                      <span class="pull-right">
                             <a href="index.html" >Olvidó Su Contraseña? </a> 
                      </span>
                  </div>
                   
                  <a href="index.html" class="btn btn-primary ">Iniciar Sesión</a>
                  <hr />
                  No Registrado? <a href="index.html" >Click Aquí </a> O simplemente ir a <a href="index.aspx">Home</a> 
              </form>
            </div>
          </div>
        </div>
      </div>

</body>
</html>
