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

  		public Compra(Usuario trabajador, DateTime fecha, int total, char tipo){
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
        MySqlDataReader datos = control.seleccionar("findCompra", parametro);
        while(datos.Read()){
          this.id = Convert.ToInt32(datos["com_id"]);
          this.trabajador = new Usuario(datos["com_tra_rut"].ToString());
          this.fecha = Convert.ToDateTime(datos["com_fecha"]);
          this.total = Convert.ToInt32(datos["com_total"]);
          this.tipo = Convert.ToChar(datos["com_tipo"]);
        }
        control.closeConexion();
  		}

      public void Insert() {
        Controlador control = new Controlador();
        control.openConexion();
        List<Parametros> parametros = new List<Parametros>();
        parametros.Add(new Parametros("trabajador", this.trabajador.rut));
        parametros.Add(new Parametros("fecha", this.fecha));
        parametros.Add(new Parametros("total", this.total));
        parametros.Add(new Parametros("tipo", this.tipo));
        parametros.Add(new Parametros("out_id", MySqlDbType.Int32, 10));
        control.ejecutarSql("addCompra", parametros);
        this.id = Convert.ToInt32(parametros[4].Valor);
      }

      public void Delete() {
        Controlador control = new Controlador();
        control.openConexion();
        List<Parametros> parametros = new List<Parametros>();
        parametros.Add(new Parametros("id", this.id));
        control.ejecutarSql("deleteCompra", parametros);
      }

      public void Update() {
        Controlador control = new Controlador();
        control.openConexion();
        List<Parametros> parametros = new List<Parametros>();
        parametros.Add(new Parametros("id", this.id));
        parametros.Add(new Parametros("trabajador", this.trabajador.rut));
        parametros.Add(new Parametros("fecha", this.fecha));
        parametros.Add(new Parametros("total", this.total));
        parametros.Add(new Parametros("tipo", this.tipo));
        control.ejecutarSql("updateCompra", parametros);
      }

      public List<Compra> FindAllCompras() {
        Controlador control = new Controlador();
        control.openConexion();
        MySqlDataReader datos = control.seleccionar("findAllCompras", null);
        List<Compra> compras = new List<Compra>();
        while(datos.Read()){
          compras.Add(new Compra(Convert.ToInt32(datos["com_id"]))); 
        }
        control.closeConexion();
        return compras;
      }

	}
}