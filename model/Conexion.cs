
using System;
using MySql.Data.MySqlClient;

namespace Model{

  public class Conexion {

    /*
    *  Variables de clase con la configuracion de la base de datos
    */
    private static string ip = "127.0.0.1";
    private static string port = "3306";
    private static string database = "storage";
    private static string Uid = "root";
    private static string Pwd = "leyton995";
    private static string con = "Server='"+ip+"';Port='"+port+"';Database='"+database+"';Uid='"+Uid+"';Pwd='"+Pwd+"'";

    private static MySqlConnection conexion;

    /**
     * getConexion
     * @return
     */
    public static MySqlConnection GetConexion() {
      try {
        conexion = new MySqlConnection(con);
        conexion.Open();
        Console.WriteLine("Conexión Exitosa");
      } catch (MySqlException ex) {
        Console.WriteLine("Error en GetConexion(): " + ex.ToString());
      }
      return conexion;
    }

  }
}
