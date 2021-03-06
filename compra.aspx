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

    <link rel="stylesheet" type="text/css" href="assets/css/important.css">

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
                        <ul class="nav nav-second-level">
                            <li><a href="producto.aspx"><i class="fas fa-plus"></i>Nuevo Producto</a></li>
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
                         <ul class="nav nav-second-level collapse in">
                            <li><a class="active-menu" href="compra.aspx"><i class="fas fa-plus"></i>Nueva Compra</a></li>
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
                        <h1 class="page-head-line">Nueva Compra</h1>
                        <h1 class="page-subhead-line">Completar Formulario Con Datos De Compra</h1>
                    </div>
                </div><!-- /. ROW  -->

                <form action="#" method="post" runat="server">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-3">
                            <div class="form-group">
                                <label>Tipo De Compra:</label><br>
                                <asp:RadioButtonList id="tipo" runat="server">
                                    <asp:ListItem Text="Chica" Value="C" />
                                    <asp:ListItem Text="Grande" Value="G" />
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6"></div>
                        <div class="col-lg-3 col-md-3 col-sm-3">
                            <div class="form-group">
                                <label>Fecha y Hora:</label>
                                <asp:TextBox id="fecha" type="datetime-local" class="form-control" runat="server" disabled></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row vertical-align">
                        <!-- INICIO PRODUCTOS -->
                        <div class="col-lg-4 col-md-4 col-sm-5">
                            <h3>Productos</h3>
                        </div>
                        <div class="col-lg-8 col-md-8 col-sm-7">
                            <button type="button" class="btn btn-primary" onclick="agregarProducto()"><i class="fas fa-plus"></i></button>
                        </div>
                    </div>
                    <div id="productos">

                        <div id="producto1" class="row vertical-align padding-top-2">
                            <div class="col-lg-1 col-md-1 col-sm-1">
                                <h4 class="text-center margin">1</h4>
                            </div>
                            <div class="col-lg-5 col-md-5 col-sm-5">
                                <label>Producto</label>
                                <input name="producto" type="text" class="form-control" placeholder="Ingrese ID de producto para buscar" runat="server">
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <label>Precio Costo</label>
                                <input name="precio" type="number" class="form-control" placeholder="Precio" disabled />
                            </div>
                            <div class="col-lg-1 col-md-1 col-sm-1">
                                <label>Cantidad</label>
                                <input name="cantidad" type="number" class="form-control" placeholder="Cantidad"/>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <label>Sub-Total</label>
                                <input name="subTotal" type="number" class="form-control" placeholder="Sub-Total" disabled/>
                            </div>
                            <div class="input-field col-lg-1 col-md-1 col-sm-1"></div>
                        </div>
                        <!-- Crear aca contenido dinamico -->
                    </div><!-- FIN PRODUCTOS -->
                    <hr>
                    <div class="row">
                        <div class="col-lg-4 col-md-4 col-sm-4"></div>
                        <div class="col-lg-4 col-md-4 col-sm-4"></div>
                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <div class="form-group has-error">
                                <label>Total</label>
                                <input name="subTotal" type="number" class="form-control " placeholder="Total" disabled/>
                            </div>
                            
                        </div>
                    </div>    
                    <div class="row margin">
                        <div class="col-lg-5 col-md-5 col-sm-5"></div>
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <button class="btn btn-success btn-lg"><i class="fas fa-check"></i> Realizar Compra</button>
                        </div>
                        <div class="col-lg-5 col-md-5 col-sm-5"></div>
                    </div>
                </form>


            </div><!-- /. PAGE INNER  -->
        </div><!-- /. PAGE WRAPPER  -->
    </div><!-- /. WRAPPER  -->
    <div id="footer-sec">
         2018 Storage System &copy; | Todos Los Derechos Reservados
    </div>
    <!-- /. FOOTER  -->
    <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
    <script src="assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>

    <script src="assets/js/script.js"></script>

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