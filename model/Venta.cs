using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;


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

        public Usuario getCliente() {
            return usuario;
        }

        public void setCliente(Usuario usuario) {
            this.usuario = usuario;
        }

        public DateTime getFecha() {
            return fecha;
        }

        public void setFecha(DateTime fecha) {
            this.fecha = fecha;
        }

        public int getDescuento() {
            return descuento;
        }

        public void setDescuento(int descuento) {
            this.descuento = descuento;
        }

        public int getTotal() {
            return total;
        }

        public void setTotal(int total) {
            this.total = total;
        }

        public int getIva() {
            return iva;
        }

        public void setIva(int iva) {
            this.iva = iva;
        }

        public char getDocumeto() {
            return documento;
        }

        public void setDocumento(char documento) {
            this.documento = documento;
        }

        public Venta Insert(Usuario cliente, DateTime fecha, int descuento, int total, int iva, char documento) {
            
            MySqlConnection conexion = Conexion.GetConexion();

            MySqlCommand comandoSQL = new MySqlCommand("INS_SONG_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
    			comandoSQL.CommandType = CommandType.StoredProcedure;
    			comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
    			comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
    			comandoSQL.ExecutenNonQuery();
    		*/
            return new Venta();
        }

        public Venta Update(Usuario cliente, DateTime fecha, int descuento, int total, int iva, char documento) {
            MySqlConnection conexion = Conexion.GetConexion();
            
            MySqlCommand comandoSQL = new MySqlCommand("UPT_SONG_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
                comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
                comandoSQL.ExecutenNonQuery();
            */
            return new Venta();

        }

        public Venta FindById(int id) {
            MySqlConnection conexion = Conexion.GetConexion();
            
            MySqlCommand comandoSQL = new MySqlCommand("F_SONG_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
                comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
                comandoSQL.ExecutenNonQuery();
            */
            return new Venta(); 
        }

        public MySqlDataReader FindAllAlbums() {

            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand comandoSQL = new MySqlCommand("FAA_SONG_SP", conexion);

            MySqlDataReader canciones = comandoSQL.ExecuteReader();

            return canciones;
        }

        public MySqlDataReader FindAllByAlbum(string album) {

            MySqlDataReader canciones = null;

            //List<Usuario> usuarios = new List<Usuario>();
            MySqlConnection conexion = Conexion.GetConexion();

            MySqlCommand comandoSQL = new MySqlCommand("FA_SONG_SP", conexion); 
            comandoSQL.CommandType = CommandType.StoredProcedure;
            comandoSQL.Parameters.AddWithValue("@album", album);   
            //MySqlCommand comandoSQL = new MySqlCommand("SELECT * FROM canciones WHERE can_album = '"+album+"';", conexion);    

            canciones = comandoSQL.ExecuteReader();

            if (canciones != null) {
                return canciones;
            }else{
                return canciones;
            }
        }

        public void Remove(int id) {
            MySqlConnection conexion = Conexion.GetConexion();
            
            MySqlCommand comandoSQL = new MySqlCommand("RMV_SONG_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
                comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
                comandoSQL.ExecutenNonQuery();
            */            
        }
    }

}
