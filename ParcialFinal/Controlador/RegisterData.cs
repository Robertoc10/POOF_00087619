using System;
using System.Collections.Generic;
using System.Data;
using ParcialFinal.Modelo;

namespace ParcialFinal.Controlador
{
    public static class RegisterData
    {
        public static void NuevoRegistro(int idUsuario, bool entrada, string temperatura)
        {
            string sql = String.Format(
                "INSERT INTO REGISTRO(idUsuario, entrada, temperatura) " +
                "VALUES({0}, '{1}', '{2}');",
                idUsuario, entrada, temperatura);
                
            
            DBConnection.ExecuteNonQuery(sql);
        }

        public static List<Register> RegPersonal(int id)
        {
            string sql =$"SELECT * FROM REGISTRO WHERE idUsuario = {id}";
           DataTable dt = DBConnection.ExecuteQuery(sql);
                
            List<Register> listareg = new List<Register>();
            foreach (DataRow fila in dt.Rows)
            {
                Register u = new Register();
                u.idRegistro = Convert.ToInt32(fila[0].ToString());
                u.idUsuario = Convert.ToInt32(fila[1].ToString());
                u.entrada = Convert.ToBoolean(fila[2].ToString());
                u.fechaHora = Convert.ToDateTime(fila[3].ToString());
                u.temperatura = fila[4].ToString();
               

                listareg.Add(u);
            }

            return listareg;
                
            
        }
       
        public static List<Register> RegGeneral()
        {
            string sql ="SELECT * FROM REGISTRO";
            DataTable dt = DBConnection.ExecuteQuery(sql);
                
            List<Register> listareg = new List<Register>();
            foreach (DataRow fila in dt.Rows)
            {
                Register u = new Register();
                u.idRegistro = Convert.ToInt32(fila[0].ToString());
                u.idUsuario = Convert.ToInt32(fila[1].ToString());
                u.entrada = Convert.ToBoolean(fila[2].ToString());
                u.fechaHora = Convert.ToDateTime(fila[3].ToString());
                u.temperatura = fila[4].ToString();
               

                listareg.Add(u);
            }

            return listareg;
                
            
        }
    }
}