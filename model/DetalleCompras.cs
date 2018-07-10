using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos;

namespace Model{

	public class DetalleCompras{

		//Atributos de la clase

		public Compra compra;
		public Producto producto;
		public int cantidad;
		public int subtotal;
		public char estado;
		//Constructor vacio
		public DetalleCompras(){}

		public DetalleCompras(Compra compra, Producto producto){
			Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametro = new List<Parametros>();
            parametro.Add(new Parametros("id_compra", compra.id));
            parametro.Add(new Parametros("id_producto", producto.id));
            MySqlDataReader datos = control.seleccionar("findDetalleCompra", parametro);
            while(datos.Read()){
                this.compra = new Compra(Convert.ToInt32(datos["dtc_com_id"]));
                this.producto = new Producto(Convert.ToInt32(datos["dtc_pro_id"]));
                this.cantidad = Convert.ToInt32(datos["dtc_cantidad"]);
                this.subtotal = Convert.ToInt32(datos["dtc_subtotal"]);
                this.estado = Convert.ToChar(datos["dtc_estado"]);
            }
            control.closeConexion();
		}

		//Constructor con parametros
		public DetalleCompras(Compra compra, Producto producto, int cantidad, int subtotal, char estado){
			this.compra = compra;
			this.producto = producto;
			this.cantidad = cantidad;
			this.subtotal = subtotal;
			this.estado = estado;
		}

		public string Insert() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id_compra", this.compra.id));
            parametros.Add(new Parametros("id_producto", this.producto.id));
            parametros.Add(new Parametros("cantidad", this.cantidad));
            parametros.Add(new Parametros("subtotal", this.subtotal));
            parametros.Add(new Parametros("estado", this.estado));
            parametros.Add(new Parametros("mensaje", MySqlDbType.VarChar, 50));
            control.ejecutarSql("addDetalleCompra", parametros);
            string mensaje = parametros[5].Valor.ToString();
            return mensaje;
        }

        public void Delete() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id_compra", this.compra.id));
            parametros.Add(new Parametros("id_producto", this.producto.id));
            control.ejecutarSql("deleteDetalleCompra", parametros);
        }

        public void Update() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id_compra", this.compra.id));
            parametros.Add(new Parametros("id_producto", this.producto.id));
            parametros.Add(new Parametros("cantidad", this.cantidad));
            parametros.Add(new Parametros("subtotal", this.subtotal));
            parametros.Add(new Parametros("estado", this.estado));
            control.ejecutarSql("updateDetalleCompra", parametros);
        }

        public List<DetalleCompras> FindAllDetalleCompras() {
            Controlador control = new Controlador();
            control.openConexion();
            MySqlDataReader datos = control.seleccionar("findAllDetalleCompras", null);
            List<DetalleCompras> detalleCompras = new List<DetalleCompras>();
            while(datos.Read()){
                detalleCompras.Add(new DetalleCompras(new Compra(Convert.ToInt32(datos["dtc_com_id"])), new Producto(Convert.ToInt32(datos["dtc_pro_id"]))));  
            }
            control.closeConexion();
            return detalleCompras;
        }

        public List<DetalleCompras> FindAllDetallesCompra(Compra compra) {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id_compra", compra.id));
            MySqlDataReader datos = control.seleccionar("findAllDetallesCompra", parametros);
            List<DetalleCompras> detallesCompra = new List<DetalleCompras>();
            while(datos.Read()){
                detallesCompra.Add(new DetalleCompras(new Compra(Convert.ToInt32(datos["dtc_com_id"])), new Producto(Convert.ToInt32(datos["dtc_pro_id"])))); 
            }
            control.closeConexion();
            return detallesCompra;
        }

	}
}