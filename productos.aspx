<%@ Page Language="C#" Src="Controllers/Productos.aspx.cs" Inherits="Controllers.Productos" %>
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
    <link rel="stylesheet" type="text/css" href="assets/css/jquery.dataTables.css">

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
                        <ul class="nav nav-second-level collapse in">
                            <li><a href="producto.aspx?op=nuevo"><i class="fas fa-plus"></i>Nuevo Producto</a></li>
                            <li><a class="active-menu" href="productos.aspx"><i class="fas fa-store-alt"></i>Todos Los productos</a></li>
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
                        <asp:Label id="titulo" runat="server"></asp:Label>
                        <h1 class="page-head-line">Productos</h1>
                        <h1 class="page-subhead-line">Lista con Productos</h1>
                    </div>
                </div><!-- /. ROW  -->

                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <asp:Literal id="mensaje" runat="server"></asp:Literal>
                    </div>
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <table id="tablaProductos" class="display">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Nombre</th>
                                    <th>Stock</th>
                                    <th>Precio</th>
                                    <th>Visibilidad</th>
                                    <th>Estado</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal id="listProduct" runat="server"></asp:Literal>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Id</th>
                                    <th>Nombre</th>
                                    <th>Stock</th>
                                    <th>Precio</th>
                                    <th>Visibilidad</th>
                                    <th>Estado</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>

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

    <!-- DATATABLES JQuery -->
    <!-- DATATABLES JQuery -->
    <script type="text/javascript" charset="utf8" src="assets/js/jquery.dataTables.js"></script>
    <script type="text/javascript" charset="utf8" src="assets/js/dataTables.bootstrap.min.js"></script>

    <!-- JQUERY DATA TABLES SCRIPT -->
    <script>
        $(document).ready( function () {
            var tabla = $('#tablaProductos').DataTable({

                "initComplete": function () {
                    this.api().columns().every( function () {
                        var column = this;
                        var select = $('<br><select class="form-control"><option value=""></option></select>')
                            .appendTo( $(column.header()))
                            .on( 'change', function () {
                                var val = $.fn.dataTable.util.escapeRegex(
                                    $(this).val()
                                );
                                column
                                    .search( val ? '^'+val+'$' : '', true, false )
                                    .draw();
                            } );
         
                        column.data().unique().sort().each( function ( d, j ) {
                            select.append( '<option value="'+d+'">'+d+'</option>' )
                        } );
                    } );
                },


                "language": {
                    "search": "Buscar:",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando Datos...",
                    "zeroRecords": "No se encontraron datos",
                    "infoEmpty": "No hay datos para mostrar",
                    "processing": "Procesando..",
                    "info": "Mostrando del _START_ al _END_, de un total de _TOTAL_ productos",
                    "paginate": {
                        "next": "Siguiente",
                        "previous": "Anterior"
                    },
                },

            });

            $('th').off();
            $(".form-control").css("cursor","default");
            $("th").css("cursor","pointer");

            var orden = false;
  
            //$("#tablaProductos thead tr th:not(:input[type=select])").on("click",function(event){
            $("th").on("click",function(event){

                var columna = tabla.column($(this)).index();
                
                if (orden == false){
                    tabla.order([columna, 'desc']).draw();
                    orden = true;
                }else{
                    tabla.order([columna, 'asc']).draw();
                    orden = false;
                }
            });
            

        } );
    </script>


</body>
</html>