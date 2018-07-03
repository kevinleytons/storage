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
  		public Date fecha;
  		public int total;
  		public char tipo;

  		public Compra(){}

  		public Compra(int id, Usuario trabajador, Date fecha, int total, char tipo){
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
            MySqlDataReader datos = control.seleccionar("findProducto", parametro);
            while(datos.Read()){
                this.id = Convert.ToInt32(datos["pro_id"]);
                this.nombre = datos["pro_nombre"].ToString();
                this.descripcion = datos["pro_descripcion"].ToString();
                this.foto = datos["pro_foto"].ToString();
                this.stock = Convert.ToInt32(datos["pro_stock"]);
                this.costo = Convert.ToInt32(datos["pro_costo"]);
                this.precio = Convert.ToInt32(datos["pro_precio"]);
                this.tipo = Convert.ToChar(datos["pro_tipo"]);
                this.sub_familia = new SubFamilia(Convert.ToInt32(datos["pro_sbf_id"]));
                this.estado = Convert.ToChar(datos["pro_estado"]);
                this.visibilidad = Convert.ToChar(datos["pro_visibilidad"]);
                this.vencimiento = Convert.ToDateTime(datos["pro_vencimiento"]);
            }
            control.closeConexion();
  		}





	}
}