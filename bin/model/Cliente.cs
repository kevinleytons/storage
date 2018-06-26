using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Model{

    public class Usuario{
        // Declarar los atributos de la clase
        // estos son los campos de la Base de datos

        private string rut;
        private char dv;
        private string name;
        private string pass;
        private char tipo;

        // Constructor vacio de la clase usuario
        public Usuario(){}

        // Constructor con parametros
        public Usuario(string rut, char dv, string name, string pass, char tipo) {
            this.rut = rut;
            this.dv = dv;
            this.name = name;
            this.pass = pass;
            this.tipo = tipo;
        }

        public string getRut() {
            return rut;
        }

        public void setRut(string rut) {
            this.rut = rut;
        }

        public string getDV() {
            return dv;
        }

        public void setDV(string dv) {
            this.dv = dv;
        }

        public string getName() {
            return name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public string getPass() {
            return pass;
        }

        public void setPass(string pass) {
            this.pass = pass;
        }

        public string getTipo() {
            return tipo;
        }

        public void setTipo(chat tipo) {
            this.tipo = tipo;
        }

        public Usuario Insert(string rut, char dv, string name, string pass, char tipo) {
            
            MySqlConnection conexion = Conexion.GetConexion();

            MySqlCommand comandoSQL = new MySqlCommand("INS_USER_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
    			comandoSQL.CommandType = CommandType.StoredProcedure;
    			comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
    			comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
    			comandoSQL.ExecutenNonQuery();
    		*/
            return new Usuario();

        }

        public Usuario Update(string rut, char dv, string name, string pass, char tipo) {
            MySqlConnection conexion = Conexion.GetConexion();

            MySqlCommand comandoSQL = new MySqlCommand("UPT_USER_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
                comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
                comandoSQL.ExecutenNonQuery();
            */
            return new Usuario();
        }

        public Usuario FindByRut(string rut) {
            MySqlConnection conexion = Conexion.GetConexion();
            
            MySqlCommand comandoSQL = new MySqlCommand("F_USER_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
                comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
                comandoSQL.ExecutenNonQuery();
            */
            return new Cliente();
        }

        public MySqlDataReader FindAll() {

            MySqlConnection conexion = Conexion.GetConexion();
            
            //MySqlCommand comandoSQL = new MySqlCommand("FA_USER_SP", conexion);    
            MySqlCommand comandoSQL = new MySqlCommand("SELECT * FROM canciones;", conexion);    

            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.ExecutenNonQuery();
            */

            MySqlDataReader usuarios = comandoSQL.ExecuteReader();

            return usuarios;
        }
        

        public void Remove(string rut) {
            MySqlConnection conexion = Conexion.GetConexion();
            
            MySqlCommand comandoSQL = new MySqlCommand("RMV_USER_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
                comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
                comandoSQL.ExecutenNonQuery();
            */ 

        }
    }
}