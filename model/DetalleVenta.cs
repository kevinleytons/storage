using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos;

namespace Model{

	public class DetalleVenta{

		//Atributos de la clase
		public Venta venta;
		public Producto producto;
		public int cantidad;
		public int subtotal;
		//Constructor vacio
		public DetalleVenta(){}

		public DetalleVenta(Venta venta, Producto producto){
			Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametro = new List<Parametros>();
            parametro.Add(new Parametros("id_venta", venta.id));
            parametro.Add(new Parametros("id_producto", producto.id));
            MySqlDataReader datos = control.seleccionar("findDetalleVenta", parametro);
            while(datos.Read()){
                this.venta = new Venta(Convert.ToInt32(datos["dvt_vnt_id"]));
                this.producto = new Producto(Convert.ToInt32(datos["dvt_pro_id"]));
                this.cantidad = Convert.ToInt32(datos["dvt_cantidad"]);
                this.subtotal = Convert.ToInt32(datos["dvt_subtotal"]);
            }
            control.closeConexion();
		}

		//Constructoor con parametros 
		public DetalleVenta(Venta venta, Producto producto, int cantidad, int subtotal){
			this.venta = venta;
			this.producto = producto;
			this.cantidad = cantidad;
			this.subtotal = subtotal;
		}

		public string Insert() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id_venta", this.venta.id));
            parametros.Add(new Parametros("id_producto", this.producto.id));
            parametros.Add(new Parametros("cantidad", this.cantidad));
            parametros.Add(new Parametros("subtotal", this.subtotal));
            parametros.Add(new Parametros("mensaje", MySqlDbType.VarChar, 50));
            control.ejecutarSql("addDetalleVenta", parametros);
            string mensaje = parametros[4].Valor.ToString();
            return mensaje;
        }

        public void Delete() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id_venta", this.venta.id));
            parametros.Add(new Parametros("id_producto", this.producto.id));
            control.ejecutarSql("deleteDetalleVenta", parametros);
        }

        public void Update() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id_venta", this.venta.id));
            parametros.Add(new Parametros("id_producto", this.producto.id));
            parametros.Add(new Parametros("cantidad", this.cantidad));
            parametros.Add(new Parametros("subtotal", this.subtotal));
            control.ejecutarSql("updateDetalleVenta", parametros);
        }

        public List<DetalleVenta> FindAllDetalleVentas() {
            Controlador control = new Controlador();
            control.openConexion();
            MySqlDataReader datos = control.seleccionar("findAllDetalleVentas", null);
            List<DetalleVenta> detallesVentas = new List<DetalleVenta>();
            while(datos.Read()){
                detallesVentas.Add(new DetalleVenta(new Venta(Convert.ToInt32(datos["dvt_vnt_id"])), new Producto(Convert.ToInt32(datos["dvt_pro_id"]))));  
            }
            control.closeConexion();
            return detallesVentas;
        }

        public List<DetalleVenta> FindAllDetallesVenta(Venta venta) {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id_venta", venta.id));
            MySqlDataReader datos = control.seleccionar("FindAllDetallesVenta", parametros);
            List<DetalleVenta> detallesVenta = new List<DetalleVenta>();
            while(datos.Read()){
                detallesVenta.Add(new DetalleVenta(new Venta(Convert.ToInt32(datos["dvt_vnt_id"])), new Producto(Convert.ToInt32(datos["dvt_pro_id"])))); 
            }
            control.closeConexion();
            return detallesVenta;
        }
	}
}