using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos;

namespace Model{

    public class Producto{
        // Declarar los atributos de la clase
        // estos son los campos de la Base de datos

        public int id;
        public string nombre;
        public string descripcion;
        public string foto;
        public int stock;
        public int costo;
        public int precio;
        public char tipo;
        public SubFamilia sub_familia;
        public char estado;
        public char visibilidad;
        public DateTime vencimiento;

        // Constructor vacio de la clase
        public Producto(){}

        public Producto(int id){
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
        // Constructor con parametros
        public Producto(string nombre, string descripcion, string foto, int stock, int costo, int precio, char tipo, SubFamilia sub_familia, char estado, char visibilidad, DateTime vencimiento) {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
            this.stock = stock;
            this.costo = costo;
            this.precio = precio;
            this.tipo = tipo; 
            this.sub_familia = sub_familia;
            this.estado = estado;
            this.visibilidad = visibilidad;
            this.vencimiento = vencimiento;
        }
        /*
        public Producto Insert(Producto producto) {
            
        }
        */

        public List<Producto> FindAllProduct() {
            Datos.Controlador control = new Datos.Controlador();
            control.openConexion();
            MySqlDataReader datos = control.seleccionar("cargarProductos", null);
            List<Producto> productos = new List<Producto>();
            while(datos.Read()){
                productos.Add(new Producto(Convert.ToInt32(datos["pro_id"]))); 
            }
            control.closeConexion();
            return productos;
        }
    }

}
