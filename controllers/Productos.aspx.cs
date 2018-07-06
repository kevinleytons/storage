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

		// Se capturan con ID de input
		protected Literal mensaje, listProduct, listaFamilias;
		protected TextBox nombre, precio, costo, stock, descripcion, familia;
		protected FileUpload foto;
		protected DropDownList tipo, familiaDP, subFamiliaDP;
		private List<Producto> productos;
		private List<Familia> familias; 
		private List<SubFamilia> subfamilias;
		private Producto p;
		private Familia f;
		private SubFamilia sf;
		protected string opcion;
		protected string url = HttpContext.Current.Request.Url.AbsoluteUri;
		private string[] view;
		
		protected void Page_Init(){
			// Autenticacion de usuario
		}

		protected void Page_PreLoad(){
			// Cargar recursos
			try{
				opcion = Convert.ToString(Request.QueryString["op"]);
				string[] path = url.Split('/');
				string vista = (path[path.Length-1]);
			 	view = vista.Split('.');

				switch (view[0]){
					case "producto":
						if (IsPostBack){
							// ¡¡Registrar nuevo producto!!
							try {
								bool 	img_pro = foto.HasFile;
								string 	nom_pro = nombre.Text;
								string 	fam_pro = familiaDP.Text;
								string 	sbm_pro = subFamiliaDP.Text;
								string  tip_pro = tipo.Text;
								int 	pre_pro = Int32.Parse(precio.Text);
								int 	cos_pro = Int32.Parse(costo.Text);
								int 	sto_pro = Int32.Parse(stock.Text);
								string 	des_pro = descripcion.Text;
								if (img_pro != null) {
									
								}
								p = new Producto(
									nom_pro, 
									des_pro, 
									foto.FileName,
									sto_pro,
									cos_pro,
									pre_pro, 
									'F', 
									new SubFamilia(1), 
									'D', 
									'V', 
									new DateTime()
								);

								// Guardando Nuevo Producto!
								//p.Insert();
								

							} catch (System.Exception e) {
								mensaje.Text+=("<h2 class='text-danger text-center'>*Debe Completar Formulario*</h2>");
							}
							
						}else{

							tipo.Items.Clear();
							familiaDP.Items.Clear();
							subFamiliaDP.Items.Clear();

							f = new Familia();
							familias = f.FindAllFamily();

							sf = new SubFamilia();
							subfamilias = sf.FindAllSubFamily();
							if (familias.Count == 0 || subfamilias.Count == 0 ) {
								opcion = "4";
							}
						}
					break;
					case "productos":
						// Mostrar todos los productos
						// Cargando recursos
						p = new Producto();
						productos = p.FindAllProduct();
					break;
					case "familias":

						if(IsPostBack){
							switch (opcion){
								case "todos":
									// Obtener subfamilias para familia
									sf = new SubFamilia();

									subfamilias = sf.FindAllSubFamilyByFamily();
									/*
									string json = "{\"name\":\"Joe\"}";
									Response.Clear();
									Response.ContentType = "application/json; charset=utf-8";
									Response.Write(json);
									Response.End();
									*/
								break;
								default:
									// Guardar Nueva Familia
									
								break;
							}
						}else{
							f = new Familia();
							familias = f.FindAllFamily();

							sf = new SubFamilia();
							subfamilias = sf.FindAllSubFamily();
						}
						

					break;
					case "3":
						// Buscar Subfamilias de familia

					break;
					case "4":
						// Mostrar producto especifico

					break;
					default:
						mensaje.Text+=("<h1 class='text-danger text-center'>Default</h1>");
			  		break;
				}	

			}catch(Exception ex){
				mensaje.Text+=(""+ex.ToString()+"");
			}
		}

		protected void Page_Load(){

			switch (view[0]){
				case "producto":
					if(IsPostBack){
						mensaje.Text+=(
							"<h4 class='text-info text-center'>"+
								p.nombre+" - "+
								p.tipo+" - "+
								p.descripcion+" - "+
								p.foto+" - "+
								p.precio+" - "+
								p.costo+" - "+
								p.stock+" - "+
								p.sub_familia.id+" - "+
							"</h4>"
						);

					}else{
						mensaje.Text+=("<h1 class='text-success text-center'>productos : Page_Load()</h1>");

						// cargar pagina
						tipo.Items.Insert(tipo.Items.Count, new ListItem("--- Seleccionar Tipo ---", "0"));
						tipo.Items[0].Attributes.Add("selected", "selected");
						tipo.Items[0].Attributes.Add("disabled", "disabled");
						tipo.Items.Insert( tipo.Items.Count, new ListItem("Activo Fijo", "1"));
						tipo.Items.Insert( tipo.Items.Count, new ListItem("Fungible", "2"));

						familiaDP.Items.Insert(familiaDP.Items.Count, new ListItem("--- Seleccionar Familia ---", "0"));
						familiaDP.Items[0].Attributes.Add("selected", "selected");
						familiaDP.Items[0].Attributes.Add("disabled", "disabled");
						int loop = 1;
						foreach(Familia fam in familias) {
							familiaDP.Items.Insert( familiaDP.Items.Count, new ListItem(fam.nombre, loop.ToString()));
							loop++;
						}

						subFamiliaDP.Items.Insert(subFamiliaDP.Items.Count, new ListItem("--- Seleccionar Sub-Familia ---", "0"));
						subFamiliaDP.Items[0].Attributes.Add("selected", "selected");
						subFamiliaDP.Items[0].Attributes.Add("disabled", "disabled");
						loop = 1;
						foreach(SubFamilia sfam in subfamilias) {
							subFamiliaDP.Items.Insert( subFamiliaDP.Items.Count, new ListItem(sfam.nombre, loop.ToString()));
							loop++;
						}
					}
					

				break;
				case "productos":
					mensaje.Text+=("<h1 class='text-success text-center'>productos : Page_Load()</h1>");

					foreach (Producto producto in productos){
						listProduct.Text += 
							("<tr><td>"+producto.id+
								"</td><td>"+producto.nombre+
								"</td><td>"+producto.stock+
								"</td><td>"+producto.precio+
								"</td><td>"+(producto.visibilidad=='V'?"Visible":"No Visible")+
								"</td><td>"+(producto.estado=='D'?"Disponible":(producto.estado=='A'?"Agotado":"Crítico"))+"</td></tr>"
							);
					}

				break;
				case "familias":
					mensaje.Text+=("<h1 class='text-success text-center'>familias : Page_Load()</h1>");
					if (familias != null) {
						foreach (Familia fam in familias){
						listaFamilias.Text += 
							("<div id='"+fam.id+"' class='list-group-item'>"+
									fam.nombre+
									"<span class='pull-right text-muted small'>"+
										"<em>"+fam.subfamilias+" Sub-Familias</em>"+
									"</span>"+	
								"</div>"
							);
						}
					}	
				break;
				case "3":

				break;
				case "4":
					//Mostrar mensaje de error
					mensaje.Text+=("hola");
				break;
				default:
					mensaje.Text+=("<h1 class='text-success text-center'>Default Page_Load()</h1>");
			  	break;

			}

			/*
			// Este es un ejemplo de como agregar un nuevo producto 
			string nombre = "Lavadora LG";
			string descripcion = "Dimension 15x10x8";
			string foto = "lavadora.jpg";
			int stock = 10;
			int costo = 55000;
			int precio = 123500;
			char tipo = 'A';
			Model.SubFamilia sub_familia = new Model.SubFamilia(1);
			char estado = 'D';
			char visibilidad = 'V';
			DateTime vencimiento = new DateTime(2018, 3, 1, 7, 0, 0);
			Model.Producto pro = new Model.Producto(nombre,descripcion,foto,stock,costo,precio,tipo,sub_familia,estado,visibilidad,vencimiento);
			pro.Insert();
			listProduct.Text += ("<tr><td>"+pro.id+"</td><td>"+pro.nombre+"</td><td>"+pro.stock+"</td><td>"+pro.precio+"</td><td>"+pro.visibilidad+"</td><td>"+pro.estado+"</td></tr>");
			*/
		}

	}
	
	/*
	public partial class _Default : Page {
	  	[WebMethod]
	  	public static string GetDate(string someParameter) {
	    	return DateTime.Now.ToString();
	  	}
	}
	
	[ScriptService]
	public class Subfamilias : WebService{
		private static SubFamilia sf;
		private static List<SubFamilia> subfamilias;

		[WebMethod]
	    public static string GetSubFamilies(int id){
	        sf = new SubFamilia();
			subfamilias = sf.FindAllSubFamilyByFamily();

			JArray array = new JArray();
			foreach (SubFamilia sb in subfamilias) {
				array.Add(sb);
			}

			JObject o = new JObject();
			o["subFamilias"] = array;
			
	        return o.ToString();
	    }
	}
	*/

	/*

	[WebInvoke(UriTemplate = "GetSubFamilies", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
	
		public Object GetSubFamilies(Object data){
			private SubFamilia sf;
			private List<SubFamilia> subfamilias;
		 	
		 	sf = new SubFamilia();
			subfamilias = sf.FindAllSubFamilyByFamily();

			JArray array = new JArray();
			foreach (SubFamilia sb in subfamilias) {
				array.Add(sb);
			}

			JObject o = new JObject();
			o["subFamilias"] = array;
			
	        return o.ToString();
		 	return ;
		}
	
	*/

}

