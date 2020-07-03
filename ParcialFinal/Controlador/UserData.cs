using System;
using System.Collections.Generic;
using System.Data;
using ParcialFinal.Modelo;

namespace ParcialFinal.Controlador
{
    public static class UserData
    {
        public static List<User> getListaUsu()
        {
            string sql = "select * from USUARIO";

            DataTable dt = DBConnection.ExecuteQuery(sql);

            List<User> listausu = new List<User>();
            foreach (DataRow fila in dt.Rows)
            {
                User u = new User();
                u.idUsuario = Convert.ToInt32(fila[0].ToString());
                u.idDepartamento = Convert.ToInt32(fila[1].ToString());
                u.contrasenia = fila[2].ToString();
                u.nombre = fila[3].ToString();
                u.apellido = fila[4].ToString();
                u.dui = fila[5].ToString();
                u.fechaNacimiento = fila[6].ToString();

                listausu.Add(u);
            }

            return listausu;
        }
       
        public static void crearNuevo( int idDepartamento, string contrasenia, string nombre, string apellido, string dui, string fechaNacimiento)
        {
            string sql = String.Format(
                "INSERT INTO USUARIO(idDepartamento, contrasenia, nombre, apellido, dui, fechaNacimiento) " +
                "VALUES({0}, '{1}', '{2}', '{3}', '{4}', '{5}');",
                idDepartamento, contrasenia, nombre, apellido, dui, fechaNacimiento);
                
            
            DBConnection.ExecuteNonQuery(sql);
        }
        public static void eliminar(int iduser)
        {
            string sql = String.Format(
                "DELETE FROM USUARIO WHERE idUsuario = {0};",
               
                iduser);
            
            DBConnection.ExecuteNonQuery(sql);
        }
        
    }
}