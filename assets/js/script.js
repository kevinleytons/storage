function contarProductos(){
    var cantidad = $('#productos > div').length;
    return cantidad+1;
}

function agregarProducto(){
    $('#productos').append(
    	'<div id="producto'+contarProductos()+'" class="row vertical-align padding-top-2">'
	    	+'<div class="col-lg-1 col-md-1 col-sm-1">'
				+'<h4 class="text-center">'+contarProductos()+'</h4>'
			+'</div>'
	    	+'<div class="col-lg-5 col-md-5 col-sm-5">'
	    		+'<input name="producto" type="text" class="form-control" placeholder="Ingrese ID de producto para buscar" runat="server">'
			+'</div>'
			+'<div class="col-lg-2 col-md-2 col-sm-2">'
	    		+'<input name="cantidad" type="number" class="form-control" placeholder="Precio" disabled/>'
			+'</div>'
			+'<div class="col-lg-1 col-md-1 col-sm-1">'
	    		+'<input name="cantidad" type="number" class="form-control" placeholder="Cantidad"/>'
			+'</div>'
			+'<div class="col-lg-2 col-md-2 col-sm-2">'
	    		+'<input name="subTotal" type="number" class="form-control" placeholder="Sub-Total" disabled/>'
			+'</div>'
			+'<div class="input-field col-lg-1 col-md-1 col-sm-1">'
				+'<button id="btnQuitar'+contarProductos()+'" type="button" class="btn btn-danger" onclick="borrarProducto()">'
					+'<i class="fas fa-trash"></i>'
				+'</button>'
			+'</div>'
		+'</div>'); 
}

function borrarProducto(){
    var id = contarProductos()-1;
    $('#producto'+id).remove();
}