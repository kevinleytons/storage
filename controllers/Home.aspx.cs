using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Model;

namespace Controllers{

	public class Home : Page{

		// Se capturan con ID de input
		protected Literal listVentas;
		protected void Page_PreLoad(){
			
			if (IsPostBack){
				
			}
			
		}

		protected void Page_Load(){
			DetalleCompras dtc = new DetalleCompras();
			List<DetalleCompras> detalles = dtc.FindAllDetalleCompras();
			foreach (DetalleCompras detalle in detalles){
				listVentas.Text += ("<tr><td>"+detalle.compra.id+
								"</td><td>"+detalle.producto.id+
								"</td><td>"+detalle.cantidad+
								"</td><td>"+detalle.subtotal+
								"</td><td>"+detalle.estado+"</td></tr>"
							);
			}
		}

	}
}