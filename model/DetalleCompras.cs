using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos;

namespace Model{

	public class DetalleCompras{

		//Atributos de la clase

		public Compra compraID;
		public Producto productoID;
		public int cantidad;
		public int subtotal;
		public char estado;
		//Constructor vacio
		public DetalleCompras(){}

		//Constructor con parametros
		public DetalleCompras(Compra compraID, Producto productoID, int cantidad, int subtotal, char estado){
			this.compraID = compraID;
			this.productoID = productoID;
			this.cantidad = cantidad;
			this.subtotal = subtotal;
			this.estado = estado;
		}

	}
}