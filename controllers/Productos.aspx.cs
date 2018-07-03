using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Globalization;

namespace Controllers{

	public class Productos : Page{

		// Se capturan con ID de input
		protected Literal prueba,listProduct;
		protected string opcion;

		protected void Page_PreLoad(){
			
			try{
				opcion = Convert.ToString(Request.QueryString["opcion"]);
				if (opcion != null){
					switch (opcion){
						// Mostrar todos los productos
						case "1":
						break;
						case "2":
						break;
						case "3":
						break;
						case "4":
						break;
					}
				}else{
					prueba.Text+=("<p class='text-success'>Hola</p>");
				}
				

				if (IsPostBack){
				}

			}catch(Exception ex){
				prueba.Text+=(""+ex.ToString()+"");
			}
			
		}

		protected void Page_Load(){
			Model.Producto p = new Model.Producto();
			List<Model.Producto> productos = p.FindAllProduct();
			foreach (Model.Producto producto in productos){
				listProduct.Text += ("<tr><td>"+producto.id+"</td><td>"+producto.nombre+"</td><td>"+producto.stock+"</td><td>"+producto.precio+"</td><td>"+producto.visibilidad+"</td><td>"+producto.estado+"</td></tr>");
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
}