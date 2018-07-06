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

        private int id;
        private Usuario usuario;
        private DateTime fecha;
        private int descuento;
        private int total;
        private int iva;
        private char documento;

        // Constructor vacio de la clase
        public Venta(){}

        // Constructor con parametros
        public Venta(Usuario usuario, DateTime fecha, int descuento, int total, int iva, char documento) {
            this.usuario = usuario;
            this.fecha = fecha;
            this.descuento = descuento;
            this.total = total;
            this.iva = iva;
            this.documento = documento;
        }

        public Venta Insert(Usuario cliente, DateTime fecha, int descuento, int total, int iva, char documento) {
            
            //MySqlConnection conexion = Conexion.GetConexion();

            //MySqlCommand comandoSQL = new MySqlCommand("INS_SONG_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
    			comandoSQL.CommandType = CommandType.StoredProcedure;
    			comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
    			comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
    			comandoSQL.ExecutenNonQuery();
    		*/
            return new Venta();
        }

        public Venta Update(Usuario cliente, DateTime fecha, int descuento, int total, int iva, char documento) {
            //MySqlConnection conexion = Conexion.GetConexion();
            
            //MySqlCommand comandoSQL = new MySqlCommand("UPT_SONG_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
                comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
                comandoSQL.ExecutenNonQuery();
            */
            return new Venta();

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

        public void FindAllAlbums() {

            //MySqlConnection conexion = Conexion.GetConexion();
            //MySqlCommand comandoSQL = new MySqlCommand("FAA_SONG_SP", conexion);

            //MySqlDataReader canciones = comandoSQL.ExecuteReader();

        }

        public void FindAllByAlbum(string album) {

            //MySqlDataReader canciones = null;

            //List<Usuario> usuarios = new List<Usuario>();
            //MySqlConnection conexion = Conexion.GetConexion();

            //MySqlCommand comandoSQL = new MySqlCommand("FA_SONG_SP", conexion); 
            //comandoSQL.CommandType = CommandType.StoredProcedure;
            //comandoSQL.Parameters.AddWithValue("@album", album);   
            //MySqlCommand comandoSQL = new MySqlCommand("SELECT * FROM canciones WHERE can_album = '"+album+"';", conexion);    

            //canciones = comandoSQL.ExecuteReader();

            //if (canciones != null) {
            //    return canciones;
            //}else{
            //}
        }

        public void Remove(int id) {
            //MySqlConnection conexion = Conexion.GetConexion();
            
            //MySqlCommand comandoSQL = new MySqlCommand("RMV_SONG_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
                comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
                comandoSQL.ExecutenNonQuery();
            */            
        }
    }

}
