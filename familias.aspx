<%@ Page Language="C#" Src="Controllers/Home.aspx.cs" Inherits="Controllers.Home" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Productos | Storage System</title>

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

    <!-- DATATABLES CSS -->
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css">

    <!-- Important! -->
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
        </nav><!-- /. NAV TOP  -->

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
                            <li><a href="producto.aspx"><i class="fas fa-plus"></i>Nuevo Producto</a></li>
                            <li><a href="productos.aspx"><i class="fas fa-store-alt"></i>Todos Los productos</a></li>
                            <li><a class="active-menu" href="familias.aspx"><i class="fas fa-th"></i>Familias de Productos</a></li>
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
                        <h1 class="page-head-line">Familias De Productos</h1>
                        <h1 class="page-subhead-line">Familias y Sub-Familias De Productos</h1>
                    </div>
                </div><!-- /. ROW  -->

                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3"></div>
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="alert alert-success alert-dismissable text-center">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                            Familia <b>tanto</b> Creada Correctamente <a href="#" class="alert-link"></a>.
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3"></div>
                </div>

                <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-12 text-center">
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#nuevaFamilia">
                          Nueva Familia <i class="fas fa-plus"></i>
                        </button>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-12 text-center">
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#nuevaSubFamilia">
                          Nueva Sub-Familia <i class="fas fa-plus"></i>
                        </button>
                    </div>
                </div>
                <br>
                
                <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <div class="list-group contenedor">
                            <!-- Lista con Familias -->
                            <div class="list-group-item">
                                Electrónica
                                <span class="pull-right text-muted small">
                                    <em>5 Sub-Familias</em>
                                </span>
                            </div>
                            <div class="list-group-item">
                                Electrónica
                                <span class="pull-right text-muted small">
                                    <em>5 Sub-Familias</em>
                                </span>
                            </div>
                            <div class="list-group-item">
                                Electrónica
                                <span class="pull-right text-muted small">
                                    <em>5 Sub-Familias</em>
                                </span>
                            </div>
                            <div class="list-group-item">
                                Electrónica
                                <span class="pull-right text-muted small">
                                    <em>5 Sub-Familias</em>
                                </span>
                            </div>
                            
                            
                        </div>
                    </div>
                    
                </div><!-- /. ROW  -->

            </div><!-- /. PAGE INNER  -->
        </div><!-- /. PAGE WRAPPER  -->
    </div><!-- /. WRAPPER  -->
    <div id="footer-sec">
         2018 Storage System &copy; | Todos Los Derechos Reservados
    </div><!-- /. FOOTER  -->

    <!-- Modal Creación de Familia -->
    <div class="modal fade" id="nuevaFamilia" tabindex="-1" role="dialog" aria-labelledby="nuevaFamiliaLabel">
      <div class="modal-dialog modal-sm" role="document">
        <form action="#" method="post" runat="server">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="nuevaFamiliaLabel">Crear Nueva Familia</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <label for="familia">Nombre De Familia</label>
                            <asp:TextBox id="familia" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal">Cancelar</button>
                    <asp: type="button" class="btn btn-success">Guardar</button>
                </div>
            </div>
        </form>
      </div>
    </div>

    <!-- Modal Creación de Sub-Familia -->
    <div class="modal fade" id="nuevaSubFamilia" tabindex="-1" role="dialog" aria-labelledby="nuevaSubFamiliaLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="nuevaSubFamiliaLabel">Modal title</h4>
          </div>
          <div class="modal-body">
            ...
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal">Cancelar</button>
            <button type="button" class="btn btn-success">Guardar</button>
          </div>
        </div>
      </div>
    </div>

    
    <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
    <script src="assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>

    <!-- DATATABLES JQuery -->
    <!-- DATATABLES JQuery -->
    <script type="text/javascript" charset="utf8" src="assets/js/jquery.dataTables.js"></script>
    <script type="text/javascript" charset="utf8" src="assets/js/dataTables.bootstrap.min.js"></script>

    <!-- JQUERY DATA TABLES SCRIPT -->
    <script>
        $(document).ready( function () {
            $('#tablaProductos').DataTable({
                "ajax": "",
                "language": {
                    "search": "Buscar:",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando Datos...",
                    "zeroRecords": "No se encontraron datos",
                    "infoEmpty": "No hay datos para mostrar",
                    "processing": "Procesando..",
                    "info": "Mostrando del _START_ al _END_, de un total de _TOTAL_ entradas",
                    "paginate": {
                        "next": "Siguiente",
                        "previous": "Anterior"
                    },
                }   
            });
        } );
    </script>

</body>
</html>