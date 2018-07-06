using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Controllers{

	public class Home : Page{

		// Se capturan con ID de input
		protected Literal listFamilia;
		protected void Page_PreLoad(){
			
			if (IsPostBack){
				
			}
			
		}

		protected void Page_Load(){
			Model.Familia f = new Model.Familia();
			List<Model.Familia> familias = f.FindAllFamilias();
			foreach (Model.Familia familia in familias){
				List<Model.SubFamilia> subFamilias = familia.FindAllSubFamilia();
				int cantidad = subFamilias.Count;
				string numSubFamilias = "";
				if(cantidad > 0){
					numSubFamilias = cantidad+" Sub-Familias";
				}else{
					numSubFamilias = "Sin Sub-Familia";
				}
				listFamilia.Text += ("<div class='list-group-item'>"+familia.nombre+"<span class='pull-right text-muted small'><em>"+numSubFamilias+"</em></span></div>");
			}
		}

	}
}