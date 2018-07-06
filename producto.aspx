<%@ Page Language="C#" Src="Controllers/Productos.aspx.cs" Inherits="Controllers.Productos"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Nuevo Producto | Storage System</title>

    <!-- BOOTSTRAP STYLES-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css" integrity="sha384-lKuwvrZot6UHsBSfcMvOkWwlCMgc0TaWr+30HWe3a4ltaBwTZhyTEggF5tJv8tbt" crossorigin="anonymous">
    <!--CUSTOM BASIC STYLES-->
    <link href="assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <!-- FileUpload -->
    <link href="assets/css/bootstrap-fileupload.min.css" rel="stylesheet">
    <!--CSS IMPORTANT-->
    <link href="assets/css/important.css" rel="stylesheet">
</head>
<body>
    <div id="wrapper">
        <nav class="navbar navbar-default navbar-cls-top " role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="home.aspx">Storage System</a>
            </div>

            <div class="header-right">
                <a href="index.aspx" class="btn btn-danger" title="Logout"><i class="fas fa-power-off fa-2x"></i></a>
			</div>
        </nav>
        <!-- /. NAV TOP  -->

        <nav class="navbar-default navbar-side" role="navigation">
            <div class="sidebar-collapse">
                <ul class="nav" id="main-menu">
                    <li>
                        <div class="user-img-div">
                            <div class="inner-text">
                                Jhon Deo Alex
                            <br />
                                <small>Last Login : 2 Weeks Ago </small>
                            </div>
                        </div>
                    </li>
                    <li><a href="home.aspx"><i class="fas fa-home "></i>Home</a></li>
                    <li>
                        <a href="productos.aspx"><i class="fa fa-desktop "></i>Productos <span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level collapse in">
                            <li><a class="active-menu" href="producto.aspx"><i class="fas fa-plus"></i>Nuevo Producto</a></li>
                            <li><a href="productos.aspx"><i class="fas fa-store-alt"></i>Todos Los productos</a></li>
                            <li><a href="familias.aspx"><i class="fas fa-th"></i>Familias de Productos</a></li>
                            <li><a href="productos.aspx"><i class="far fa-list-alt"></i>Mis Activos Fijos</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#"><i class="fas fa-shopping-cart "></i>Ventas <span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                            <li><a href="venta.aspx"><i class="fas fa-plus"></i>Nueva Venta</a></li>
                            <li><a href="ventas.aspx"><i class="fas fa-archive "></i>Mis Ventas</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#"><i class="fas fa-shopping-basket "></i>Compras <span class="fa arrow"></span></a>
                         <ul class="nav nav-second-level">
                            <li><a href="compra.aspx"><i class="fas fa-plus"></i>Nueva Compra</a></li>
                            <li><a href="compras.aspx"><i class="fas fa-archive "></i>Mis Compras</a></li>
                            <li><a href="pendientes.aspx"><i class="far fa-clock"></i>Recepcionar Compra</a></li>
                        </ul>
                    </li>
                    <li><a href="clientes.aspx"><i class="fas fa-users "></i>Clientes</a></li>
                    <li><a href="reportes.aspx"><i class="fa fa-flash "></i>Reportes </a></li>
                </ul>
            </div>
        </nav><!-- /. NAV SIDE  -->

        <div id="page-wrapper">
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">                    	
                        <h1 class="page-head-line">Nuevo Producto</h1>
                        <h1 class="page-subhead-line"><span class="text-rigth text-danger">*</span>Campos Obligatorios</h1>
                    </div>
                </div><!-- /. ROW  -->
                <asp:Literal id="mensaje" runat="server"></asp:Literal>
                <form id="nuevoProducto" action="" method="post" enctype="multipart/form-data" runat="server">
                    <asp:TextBox type="hidden" id="op" runat="server" value="0"></asp:TextBox>
                     <div class="row">
                    
                        <div class="col-lg-4 col-md-4 col-sm-12">
                            <div class="form-group text-center">
                                <label class="control-label">Seleccionar Imagen<span class="text-danger">*</span></label>
                                <div class="fileupload fileupload-new" data-provides="fileupload">
                                    <asp:TextBox type="hidden" runat="server"></asp:TextBox>
                                    <div class="fileupload-preview thumbnail" style="width: 200px; height: 150px; line-height: 150px;">
                                    </div>
                                    <div>
                                        <span class="btn btn-file btn-success">
                                            <span class="fileupload-new">Subir Imagen</span>
                                            <span class="fileupload-exists">Cambiar</span>
                                            <asp:FileUpload id="foto" type="file" accept="image/*" runat="server"></asp:FileUpload>
                                        </span>
                                        <a href="#" class="btn btn-danger fileupload-exists" data-dismiss="fileupload">Quitar</a>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-5 col-md-5 col-sm-5">
                            <div class="form-group">
                                <label for="nombre" class="control-label">Nombre Producto<span class="text-danger">*</span></label>
                                <asp:TextBox id="nombre" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-sm-3">
                            <div class="form-group">
                                <label for="tipo" class="control-label">Tipo Producto<span class="text-danger">*</span></label>
                                <asp:DropDownList id="tipo" class="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    
                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <div class="form-group">
                                <label for="familia" class="control-label">Familia Producto<span class="text-danger">*</span></label>
                                <asp:DropDownList id="familiaDP" class="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    
                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <div class="form-group">
                                <label for="subFamilia" class="control-label">Sub Familia Producto<span class="text-danger">*</span></label>
                                <asp:DropDownList id="subFamiliaDP" class="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-3">
                            <div class="form-group">
                                <label for="precio" class="control-label">Precio<span class="text-danger">*</span></label>
                                <asp:TextBox id="precio" type="number" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-3">
                            <div class="form-group">
                                <label for="costo" class="control-label">Costo<span class="text-danger">*</span></label>
                                <asp:TextBox id="costo" type="number" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <label for="stock" class="control-label">Stock<span class="text-danger">*</span></label>
                                <asp:TextBox id="stock" type="number" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                    </div>  
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="form-group">
                                <label for="descripcion" class="control-label">Descripción de Producto<span class="text-danger">*</span></label><br>
                                <asp:TextBox id="descripcion" class="form-control" TextMode="multiline" Rows="5" runat="server"></asp:TextBox>  
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 text-center">
                            <a href="#" class="btn btn-danger btn-sm">Cancelar</a>
                            <asp:Button id="btnSubmit" class="btn btn-success" Text="Guardar Producto" runat="server"></asp:Button>
                        </div>
                    </div>
                    
                </form>

            </div><!-- /. PAGE INNER  -->
        </div><!-- /. PAGE WRAPPER  -->
    </div><!-- /. WRAPPER  -->
    <div id="footer-sec">
         2018 Storage System &copy; | Todos Los Derechos Reservados
    </div><!-- /. FOOTER  -->

    <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
    <script src="assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>
    <!-- FileUpload -->
    <script src="assets/js/bootstrap-fileupload.js"></script>

    <script type="text/javascript">
        $( "#familia" ).change(function() {
            $.ajax({
                type: "GET",
                url: 'localhost/producto.aspx?',
                data: { op : 3 }, 
                dataType: "json",
                success: function(data){
                  $.each(data,function(key, registro) {
                    $("#subFamilia").append('<option value='+registro.id+'>'+registro.nombre+'</option>');
                  });        
                },
                error: function(data) {
                  alert('error');
                }
            });
        });          
        
    </script>

</body>
</html>