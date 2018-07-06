using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos;

namespace Model{
	public class Compra{
  		public int id;
  		public Usuario trabajador;
  		public DateTime fecha;
  		public int total;
  		public char tipo;

  		public Compra(){}

  		public Compra(int id, Usuario trabajador, DateTime fecha, int total, char tipo){
  			this.id = id;
  			this.trabajador = trabajador;
  			this.fecha = fecha;
  			this.total = total;
  			this.tipo = tipo;
  		}

  		public Compra(int id){
		    Datos.Controlador control = new Datos.Controlador();
        control.openConexion();
        List<Parametros> parametro = new List<Parametros>();
        parametro.Add(new Parametros("id", id));
        MySqlDataReader datos = control.seleccionar("", parametro);
        while(datos.Read()){
            
        }
        control.closeConexion();
  		}





	}
}