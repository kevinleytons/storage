using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Datos{
	public class Controlador{
		public Controlador(){

		}
		MySqlConnection conexion = new MySqlConnection("Server=127.0.0.1;Database=storage;Uid=root;Pwd='';");
		// Metodo para abrir la conexion
		public void openConexion(){
			if(conexion.State == ConnectionState.Closed){
				conexion.Open();
			}
		}

		// Metodo para cerrar la conexion

		public void closeConexion(){
			if(conexion.State == ConnectionState.Open){
				conexion.Close();
			}
		}

		// Metodo para insertar, actualizar y borrar datos

		public void ejecutarSql(string nombre, List<Parametros> parametros){
			MySqlCommand comando;
			try{
				openConexion();
				comando = new MySqlCommand(nombre, conexion);
				comando.CommandType = CommandType.StoredProcedure;
				if(parametros != null){
					for(int i = 0; i < parametros.Count; i++){
						if(parametros[i].Direccion == ParameterDirection.Input){
							comando.Parameters.AddWithValue(parametros[i].Nombre, parametros[i].Valor);
						}
						if(parametros[i].Direccion == ParameterDirection.Output){
							comando.Parameters.Add(parametros[i].Nombre, parametros[i].TipoDato, parametros[i].Tamano).Direction = ParameterDirection.Output;
						}
					}
					comando.ExecuteNonQuery();
					for(int i = 0; i < parametros.Count; i++){
						if(parametros[i].Direccion == ParameterDirection.Output){
							parametros[i].Valor = comando.Parameters[i].Value.ToString();
						}
					}
				}
			}catch(Exception ex){
				throw ex;
			}
			closeConexion();
		}

		// Metodo para selecionar datos de la base de datos

		public MySqlDataReader seleccionar(string nombre, List<Parametros> parametros){
			MySqlDataReader datos;
			MySqlCommand comando;
			try{
				comando = new MySqlCommand(nombre, conexion);
				comando.CommandType = CommandType.StoredProcedure;
				if(parametros != null){
					for(int i = 0; i < parametros.Count; i++){
						comando.Parameters.AddWithValue(parametros[i].Nombre, parametros[i].Valor);
					}
				}
				datos = comando.ExecuteReader();
			}catch(Exception ex){
				throw ex;
			}
			return datos;
		}
	}
}