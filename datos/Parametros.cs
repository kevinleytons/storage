using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Datos{
	public class Parametros{
		// Parametros 
		public string Nombre { get; set;}
		public Object Valor { get; set;}
		public MySqlDbType TipoDato { get; set;}
		public Int32 Tamano { get; set;}
		public ParameterDirection Direccion { get; set;}

		// Constructor de entra

		public Parametros(string name, Object values){
			this.Nombre = name;
			this.Valor = values;
			this.Direccion = ParameterDirection.Input;
		}

		// Constructor de salida

		public Parametros(string name, MySqlDbType type, Int32 size){
			this.Nombre = name;
			this.TipoDato = type;
			this.Tamano = size;
			this.Direccion = ParameterDirection.Output;
		}
	}
}