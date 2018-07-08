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
            Controlador control = new Controlador();
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

        public void Insert() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id_familia", this.familia.id));
            parametros.Add(new Parametros("nombre", this.nombre));
            parametros.Add(new Parametros("out_id", MySqlDbType.Int32, 10));
            control.ejecutarSql("addSubFamilia", parametros);
            this.id = Convert.ToInt32(parametros[2].Valor);
        }

        public void Delete() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id", this.id));
            control.ejecutarSql("deleteSubFamilia", parametros);
        }

        public void Update() {
            Controlador control = new Controlador();
            control.openConexion();
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("id", this.id));
            parametros.Add(new Parametros("id_familia", this.familia.id));
            parametros.Add(new Parametros("nombre", this.nombre));
            control.ejecutarSql("updateSubFamilia", parametros);
        }

        public List<SubFamilia> FindAllSubFamily() {
            Controlador control = new Controlador();
            control.openConexion();
            MySqlDataReader datos = control.seleccionar("findAllSubFamilias", null);
            List<SubFamilia> subFamilias = new List<SubFamilia>();
            while(datos.Read()){
                subFamilias.Add(new SubFamilia(Convert.ToInt32(datos["sbf_id"]))); 
            }
            control.closeConexion();
            return subFamilias;
        }

        public List<SubFamilia> FindAllSubFamilyByFamily() {
            Controlador control = new Controlador();
            control.openConexion();
            MySqlDataReader datos = control.seleccionar("findAllSubFamiliasByFamilia", null);
            List<SubFamilia> subFamilias = new List<SubFamilia>();
            while(datos.Read()){
                subFamilias.Add(new SubFamilia(Convert.ToInt32(datos["sbf_id"]))); 
            }
            control.closeConexion();
            return subFamilias;
        }
    }
}

