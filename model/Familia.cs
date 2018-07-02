using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos;

namespace Model{

    public class Familia{
        // Declarar los atributos de la clase
        // estos son los campos de la Base de datos

        public int id;
        public string nombre;

        // Constructor vacio de la clase
        public Familia(){}

        public Familia(int id){
            Datos.Controlador control = new Datos.Controlador();
            control.openConexion();
            List<Parametros> parametro = new List<Parametros>();
            parametro.Add(new Parametros("id", id));
            MySqlDataReader datos = control.seleccionar("findFamilia", parametro);
            while(datos.Read()){
                this.id = Convert.ToInt32(datos["fam_id"]);
                this.nombre = datos["fam_nombre"].ToString();
            }
            control.closeConexion();
        }
        // Constructor con parametros
        public Familia(Familia familia, string nombre) {
            this.nombre = nombre;
        }
    }
}
