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
        public Familia(string nombre) {
            this.nombre = nombre;
        }

        public void Insert() {
            Datos.Controlador control = new Datos.Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("nombre", this.nombre));
            parametros.Add(new Parametros("out_id", MySqlDbType.Int32, 10));
            control.ejecutarSql("addFamilia", parametros);
            this.id = Convert.ToInt32(parametros[1].Valor);
        }

        public void Delete() {
            Datos.Controlador control = new Datos.Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id", this.id));
            control.ejecutarSql("deleteFamilia", parametros);
        }

        public void Update() {
            Datos.Controlador control = new Datos.Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id", this.id));
            parametros.Add(new Parametros("nombre", this.nombre));
            control.ejecutarSql("updateFamilia", parametros);
        }

        public List<Familia> FindAllFamilias() {
            Datos.Controlador control = new Datos.Controlador();
            control.openConexion();
            MySqlDataReader datos = control.seleccionar("cargarFamilias", null);
            List<Familia> familias = new List<Familia>();
            while(datos.Read()){
                familias.Add(new Familia(Convert.ToInt32(datos["fam_id"]))); 
            }
            control.closeConexion();
            return familias;
        }

         public List<SubFamilia> FindAllSubFamilia() {
            Datos.Controlador control = new Datos.Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id", this.id));
            MySqlDataReader datos = control.seleccionar("cargarSuSubFamilia", parametros);
            List<SubFamilia> subFamilias = new List<SubFamilia>();
            while(datos.Read()){
                subFamilias.Add(new SubFamilia(Convert.ToInt32(datos["sbf_id"]))); 
            }
            control.closeConexion();
            return subFamilias;
        }
    }
}
