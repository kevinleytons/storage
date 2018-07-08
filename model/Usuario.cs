using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos;

namespace Model{

    public class Usuario{
        public string rut;
        public char dv;
        public string nombre;
        public string pass;
        public char tipo;

        // Constructor vacio de la clase usuario
        public Usuario(){}

        public Usuario(string rut) {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametro = new List<Parametros>();
            parametro.Add(new Parametros("rut", rut));
            MySqlDataReader datos = control.seleccionar("findUsuario", parametro);
            while(datos.Read()){
                this.rut = datos["usu_rut"].ToString();
                this.dv = Convert.ToChar(datos["usu_dv"]);
                this.nombre = datos["usu_nombre"].ToString();
                this.pass = datos["usu_pass"].ToString();
                this.tipo = Convert.ToChar(datos["usu_tipo"]);
            }
            control.closeConexion();
        }

        // Constructor con parametros
        public Usuario(string rut, char dv, string nombre, string pass, char tipo) {
            this.rut = rut;
            this.dv = dv;
            this.nombre = nombre;
            this.pass = pass;
            this.tipo = tipo;
        }

        public string Insert() {
            string mensaje = "";
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("rut", this.rut));
            parametros.Add(new Parametros("dv", this.dv));
            parametros.Add(new Parametros("nombre", this.nombre));
            parametros.Add(new Parametros("pass", this.pass));
            parametros.Add(new Parametros("tipo", this.tipo));
            parametros.Add(new Parametros("mensaje", MySqlDbType.VarChar, 50));
            control.ejecutarSql("addUsuario", parametros);
            mensaje = parametros[5].Valor.ToString();
            return mensaje;
        }

        public void Delete() {
            Datos.Controlador control = new Datos.Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("rut", this.rut));
            control.ejecutarSql("deleteUsuario", parametros);
        }

        public void Update() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("rut", this.rut));
            parametros.Add(new Parametros("dv", this.dv));
            parametros.Add(new Parametros("nombre", this.nombre));
            parametros.Add(new Parametros("pass", this.pass));
            parametros.Add(new Parametros("tipo", this.tipo));
            control.ejecutarSql("updateUsuario", parametros);
        }

        public Usuario FindByRut(string rut) {
            //MySqlConnection conexion = Conexion.GetConexion();
            
            //MySqlCommand comandoSQL = new MySqlCommand("F_USER_SP", conexion);    
            /* CODIGO PARA EJECUTAR PROCEDIMIENTO
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Parameters.Add(new MySqlParameter("nusuario", user.Text));
                comandoSQL.Parameters.Add(new MySqlParameter("npassword", pass.Text));
                comandoSQL.ExecutenNonQuery();
            */
            return new Usuario();
        }

        public List<Usuario> FindAllUsuarios(char tipo) {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("tipo", tipo));
            MySqlDataReader datos = control.seleccionar("findAllUsuarios", parametros);
            List<Usuario> usuarios = new List<Usuario>();
            while(datos.Read()){
                usuarios.Add(new Usuario(datos["usu_rut"].ToString())); 
            }
            control.closeConexion();
            return usuarios;
        }
    
    }
}