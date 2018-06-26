using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Controllers{

	public class Productos : Page{

		// Se capturan con ID de input
		protected Literal prueba;
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


		}

	}
}