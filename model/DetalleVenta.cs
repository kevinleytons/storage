using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos;

namespace Model{

	public class DetalleVenta{

		//Atributos de la clase
		public Venta ventaID;
		public Producto productoID;
		public int cantidad;
		public int subtotal;
		//Constructor vacio
		public DetalleVenta(){}
		//Constructoor con parametros 
		public DetalleVenta(Venta ventaID, Producto productoID, int cantidad, int subtotal){
			this.ventaID = ventaID;
			this.productoID = productoID;
			this.cantidad = cantidad;
			this.subtotal = subtotal;
		}
	}
}