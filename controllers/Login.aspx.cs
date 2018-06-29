using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Controllers{

	public class Login : Page{

		// Se capturan con ID de input
		
		protected TextBox rut, pass;

		protected void Page_PreLoad(){
			
			if (IsPostBack){
				
			}
			
		}

		protected void Page_Load(){


		}

	}
}
