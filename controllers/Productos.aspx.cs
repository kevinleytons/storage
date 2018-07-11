using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Model;

namespace Controllers{

	public class Productos : Page{
		protected Literal mensaje, listProduct, listaFamilias;
		protected TextBox nombre, precio, costo, stock, descripcion, familia, fechaV;
		protected FileUpload foto;
		protected DropDownList tipo, familiaDP, subFamiliaDP;
		private List<Producto> productos;
		private List<Familia> familias; 
		private List<SubFamilia> subfamilias;
		private Producto p = null;
		private Familia f;
		private SubFamilia sf;
		protected string opcion;
		protected string url = HttpContext.Current.Request.Url.AbsoluteUri;
		private string[] view;
		private List<string> errores;
		
		protected void Page_Init(){
			// Autenticacion de usuario
		}

		/*
		*	Page_PreLoad()
		*/
		protected void Page_PreLoad(){
			mensaje.Text=("");
			// Cargar recursos
			try{
				opcion = Convert.ToString(Request.QueryString["op"]);
				string[] path = url.Split('/');
				string vista = (path[path.Length-1]);
			 	view = vista.Split('.');

				switch (view[0]){
				
				// Peticiones de Vista "Producto.aspx"
					case "producto":
						if (IsPostBack){
							// ¡¡Registrar nuevo producto!!
							errores = ValidarNuevoProducto();
							if (errores.Count > 0) {
								ImprimirErrores();
							}else{
								p = RegistrarProducto();
							}
						}else{
							// Cargar Elementos de Vista
							tipo.Items.Clear();
							familiaDP.Items.Clear();
							subFamiliaDP.Items.Clear();

							f = new Familia();
							familias = f.FindAllFamilias();

							sf = new SubFamilia();
							subfamilias = sf.FindAllSubFamily();
						}
					break;

				// Peticiones de Vista "Productos.aspx"
					case "productos":
						

					break;
					
				// Peticiones de Vista "Familias.aspx"
					case "familias":
						// Guardar Familia
						if(IsPostBack){
							switch (opcion){
								case "familia":
									// Guardar Nueva Familia
								break;
								case "subFamilia":
									// Guardar Nueva Sub-Familia
								break;
							}
						}else{
							f = new Familia();
							familias = f.FindAllFamilias();

							sf = new SubFamilia();
							subfamilias = sf.FindAllSubFamily();
						}
					break;
				}	
			}catch(Exception ex){
				mensaje.Text+=("Error :"+ex.ToString()+"");
			}
		}

		/*
		*	Page_Load()
		*/
		protected void Page_Load(){
			switch (view[0]){
				case "producto":
					if(IsPostBack){
						if( p != null){
							Response.Redirect("productos.aspx?op=SuccessRedirect");
						}
					}else{
						CargarFormulario();
					}
				break;
				case "productos":
					switch (opcion){
						// Redirección desde Creación de Producto
						case "SuccessRedirect":
							mensaje.Text=("");
							mensaje.Text+=(
								"<div class='alert alert-success alert-dismissable text-center'>"+
		                        	"<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>"+
		                        	"Producto Registrado Correctamente! "+
		                    	"</div>"
							);
						break;
						default:
						break;
					}
					// Cargando Lista de Productos
					//CargarProductos();

				break;
				case "familias":
					if (familias != null) {
						ImprimirFamilias();
					}	
				break;
				case "4":
					//Mostrar mensaje de error
					mensaje.Text+=("hola");
				break;
				default:
					mensaje.Text+=("<h1 class='text-success text-center'>Default Page_Load()</h1>");
			  	break;
			}
		}

		/******************************************  FUNCIONES  ******************************************/

		/*
		*	Metodo validador de TextBoxes
		*   Formulario de creación de nuevo Producto
		*	View (producto.aspx)
		*/
		public List<string> ValidarNuevoProducto(){
			DateTime fecha;
			List<string> errs = new List<String>(); 
			TextBox[] textBoxes = new TextBox[] {nombre,descripcion,stock,costo,precio};
			foreach (var txtBx in textBoxes){
				if (String.IsNullOrEmpty(txtBx.Text)) {
					errs.Add(txtBx.ID);
				}
			}
			if (tipo.Text == "0") {
				errs.Add("Tipo");
			}
			if (!foto.HasFile) {
				errs.Add("Foto");
			}
			if (String.IsNullOrEmpty(familiaDP.Text)) {
				errs.Add("Familia");
			}
			if (Request.Form["subFamiliaDP"] == "0") {
				errs.Add("Sub-Familia");
			}
			if (DateTime.TryParse(fechaV.Text ,out fecha)) {
				fecha = Convert.ToDateTime(fechaV.Text);
			}else{
				fecha = new DateTime();
			}
			return errs;
		}

		/*
		*  Registrar Nuevo Producto
		*/
		public Producto RegistrarProducto(){
			DateTime fecha;
			if (DateTime.TryParse(fechaV.Text ,out fecha)) {
				fecha = Convert.ToDateTime(fechaV.Text);
			}else{
				fecha = new DateTime();
			}
			Producto p = null;
			p = new Producto(
				nombre.Text, 
				descripcion.Text, 
				foto.FileName,
				Int32.Parse(stock.Text),
				Int32.Parse(costo.Text),
				Int32.Parse(precio.Text),
				Convert.ToChar(tipo.Text), 
				new SubFamilia(Int32.Parse(Request.Form["subFamiliaDP"])), 
				'D', 
				'V',
				Convert.ToDateTime(fecha)
			);
			p.Insert();
			GuardarFoto(p);
			return p;
		}

		/*
		*	Guardar foto en server
		*/
		// Problemas acá!
		public bool GuardarFoto(Producto p){
			bool op = false;
			string directorio = Server.MapPath("assets/img/productos/");
			if (foto.HasFile) {
				string extension = Path.GetExtension(foto.PostedFile.FileName);
        		if(Directory.Exists(directorio)){
        			mensaje.Text+=(directorio);
            		foto.SaveAs(directorio+p.id+extension);
            		op = true;
        		}else{
        			mensaje.Text+=(directorio);
        			Directory.CreateDirectory(directorio);
            		foto.SaveAs(directorio+p.id+extension);
            		op = true;
        		}
			}
			return op;
		}

		/*
		*	Cargar formulario de Creación de productos
		*/
		public void CargarFormulario(){
			// cargar pagina
			tipo.Items.Insert(tipo.Items.Count, new ListItem("--- Seleccionar Tipo ---", "0"));
			tipo.Items[0].Attributes.Add("selected", "selected");
			tipo.Items[0].Attributes.Add("disabled", "disabled");
			tipo.Items.Insert( tipo.Items.Count, new ListItem("Activo Fijo", "A"));
			tipo.Items.Insert( tipo.Items.Count, new ListItem("Fungible", "F"));

			familiaDP.Items.Insert(familiaDP.Items.Count, new ListItem("--- Seleccionar Familia ---", "0"));
			familiaDP.Items[0].Attributes.Add("selected", "selected");
			familiaDP.Items[0].Attributes.Add("disabled", "disabled");
			foreach(Familia fam in familias) {
				familiaDP.Items.Insert( familiaDP.Items.Count, new ListItem(fam.nombre, fam.id.ToString()));
			}

			subFamiliaDP.Items.Insert(subFamiliaDP.Items.Count, new ListItem("--- Seleccionar Sub-Familia ---", "0"));
			subFamiliaDP.Items[0].Attributes.Add("disabled", "disabled");
			subFamiliaDP.Items[0].Attributes.Add("selected", "selected");
		}
		
		public void ImprimirErrores(){
			mensaje.Text+=(
				"<h3 class='text-danger text-center'>Complete los siguientes campos</h3>"
					+"<div class='row'>"
						+"<div class='col-md-2'></div>"
						+"<div class='col-md-8 alert alert-warning'>"
							+"<ul class='text-center list-inline text-info'>"
			);
			foreach (var err in errores){
				mensaje.Text+=("<li>"+err+"</li>");
			}
			mensaje.Text+=("</ul></div></div>");
		}

		/*
		*	Cargar Familias Para Vista "familias.apsx"
		*/
		public void ImprimirFamilias(){
			foreach (Model.Familia familia in familias){
				List<Model.SubFamilia> subFamilias = familia.FindAllSubFamilia();
				int cantidad = subFamilias.Count;
				string numSubFamilias = "";
				if(cantidad > 0){
					numSubFamilias = cantidad+" Sub-Familias";
				}else{
					numSubFamilias = "Sin Sub-Familia";
				}
				listaFamilias.Text += (
					"<div id='fam"+familia.id+"' class='list-group-item'>"+
						familia.nombre+
						"<span class='pull-right text-muted small'>"+
							"<em>"+numSubFamilias+"</em>"+
						"</span>"+
					"</div>"
				);
			}
		}

		/*
		*	Cargar Lista Con Productos en vista "Productos.aspx"
		*/
		[WebMethod]
		public static List<Producto> CargarProductos(){
			Producto p = new Producto();
			return p.FindAllProduct();
		}

		/*
		*	WebMethod utilizado con ajax
		*	Obtener todas las subfamilias de una familia
		*/
		[WebMethod]
		public static string GetSubFamilias(int idFamilia){
			Familia familia = new Familia(idFamilia);
			List<SubFamilia> subFamilias = familia.FindAllSubFamilia();
			JArray sbfArray = new JArray();
		    string json;
			foreach (SubFamilia sbf in subFamilias) {
				json = JsonConvert.SerializeObject(sbf);
				sbfArray.Add(json);
			}
			json = sbfArray.ToString();
		    return json;
		}
	}
}