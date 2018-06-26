function contarProductos(){
    var cantidad = $('#productos > div').length;
    return cantidad+1;
}

function agregarProducto(){
    $('#productos').append(
    	'<div id="producto'+contarProductos()+'" class="row vertical-align">'
	    	+'<div class="col-lg-1 col-md-1 col-sm-1">'
				+'<h4 class="text-center">'+contarProductos()+'</h4>'
			+'</div>'
	    	+'<div class="col-lg-10 col-md-10 col-sm-10">'
	    		+'<asp:TextBox name="producto" type="text" class="form-control" placeholder="Ingrese ID de producto para buscar"></asp:TextBox>'
			+'</div>'
			+'<div class="input-field col-lg-1 col-md-1 col-sm-1">'
				+'<button id="btnQuitar'+contarProductos()+'" type="button" class="btn btn-danger" onclick="borrarProducto(this)">'
					+'<i class="fas fa-trash"></i>'
				+'</button>'
			+'</div>'
		+'</div>'); 
}

function borrarProducto(boton){
    boton = boton.id;
    var id = boton.substring(9, boton.length);
    $('#producto'+id).remove();
}