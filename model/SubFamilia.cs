using System;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos;

namespace Model{

    public class SubFamilia{
        // Declarar los atributos de la clase
        // estos son los campos de la Base de datos

        public int id;
        public Familia familia;
        public string nombre;

        // Constructor vacio de la clase
        public SubFamilia(){}

        public SubFamilia(int id){
            Datos.Controlador control = new Datos.Controlador();
            control.openConexion();
            List<Parametros> parametro = new List<Parametros>();
            parametro.Add(new Parametros("id", id));
            MySqlDataReader datos = control.seleccionar("findSubFamilia", parametro);
            while(datos.Read()){
                this.id = Convert.ToInt32(datos["sbf_id"]);
                this.nombre = datos["sbf_nombre"].ToString();
                this.familia = new Familia(Convert.ToInt32(datos["sbf_fam_id"]));
            }
            control.closeConexion();
        }
        // Constructor con parametros
        public SubFamilia(Familia familia, string nombre) {
            this.familia = familia;
            this.nombre = nombre;
        }

        public List<SubFamilia> FindAllSubFamily() {
            Datos.Controlador control = new Datos.Controlador();
            control.openConexion();
            MySqlDataReader datos = control.seleccionar("findAllSubFamilias", null);
            List<SubFamilia> subFamilias = new List<SubFamilia>();
            while(datos.Read()){
                subFamilias.Add(new SubFamilia(Convert.ToInt32(datos["sbf_id"]))); 
            }
            control.closeConexion();
            return subFamilias;
        }
    }
}
