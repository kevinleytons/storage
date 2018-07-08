using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos;

namespace Model{

    public class Venta{
        // Declarar los atributos de la clase
        // estos son los campos de la Base de datos

        public int id;
        public Usuario cliente;
        public Usuario vendedor;
        public DateTime fecha;
        public int descuento;
        public int total;
        public int iva;
        public char documento;

        // Constructor vacio de la clase
        public Venta(){}

        public Venta(int id){
            Datos.Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametro = new List<Parametros>();
            parametro.Add(new Parametros("id", id));
            MySqlDataReader datos = control.seleccionar("findVenta", parametro);
            while(datos.Read()){
                this.id = Convert.ToInt32(datos["vnt_id"]);
                this.cliente = new Usuario(datos["vnt_cli_rut"].ToString());
                this.vendedor = new Usuario(datos["vnt_tra_rut"].ToString());
                this.fecha = Convert.ToDateTime(datos["vnt_fecha"]);
                this.descuento = Convert.ToInt32(datos["vnt_descuento"]);
                this.total = Convert.ToInt32(datos["vnt_total"]);
                this.iva = Convert.ToInt32(datos["vnt_iva"]);
                this.documento = Convert.ToChar(datos["vnt_documento"]);
            }
            control.closeConexion();
        }

        // Constructor con parametros
        public Venta(Usuario cliente, Usuario vendedor, DateTime fecha, int descuento, int total, int iva, char documento) {
            this.cliente = cliente;
            this.vendedor = vendedor;
            this.fecha = fecha;
            this.descuento = descuento;
            this.total = total;
            this.iva = iva;
            this.documento = documento;
        }

        public void Insert() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("cliente", this.cliente.rut));
            parametros.Add(new Parametros("vendedor", this.vendedor.rut));
            parametros.Add(new Parametros("fecha", this.fecha));
            parametros.Add(new Parametros("descuento", this.descuento));
            parametros.Add(new Parametros("total", this.total));
            parametros.Add(new Parametros("iva", this.iva));
            parametros.Add(new Parametros("documento", this.documento));
            parametros.Add(new Parametros("out_id", MySqlDbType.Int32, 10));
            control.ejecutarSql("addVenta", parametros);
            this.id = Convert.ToInt32(parametros[7].Valor);
        }

        public void Delete() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id", this.id));
            control.ejecutarSql("deleteVenta", parametros);
        }

        public void Update() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id", this.id));
            parametros.Add(new Parametros("cliente", this.cliente.rut));
            parametros.Add(new Parametros("vendedor", this.vendedor.rut));
            parametros.Add(new Parametros("fecha", this.fecha));
            parametros.Add(new Parametros("descuento", this.descuento));
            parametros.Add(new Parametros("total", this.total));
            parametros.Add(new Parametros("iva", this.iva));
            parametros.Add(new Parametros("documento", this.documento));
            control.ejecutarSql("updateVenta", parametros);
        }

        public Venta FindById(int id) {
            //MySqlConnection conexion = Conexion.GetConexion();
            
            //MySqlCommand comandoSQL = new MySqlCommand("F_SONG_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
                comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
                comandoSQL.ExecutenNonQuery();
            */
            return new Venta(); 
        }

        public List<Venta> FindAllVentas() {
            Controlador control = new Controlador();
            control.openConexion();
            MySqlDataReader datos = control.seleccionar("findAllVentas", null);
            List<Venta> ventas = new List<Venta>();
            while(datos.Read()){
                ventas.Add(new Venta(Convert.ToInt32(datos["vnt_id"]))); 
            }
            control.closeConexion();
            return ventas;
        }

    }

}
