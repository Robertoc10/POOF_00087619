using System;
using System.Collections.Generic;
using System.Data;
using ParcialFinal.Modelo;

namespace ParcialFinal.Controlador
{
    public class DepartmentData
    {
        public static List<Department> getDepartment()        {
            string sql = "SELECT * FROM DEPARTAMENTO";

            DataTable dt = DBConnection.ExecuteQuery(sql);
            List<Department> listaDep = new List<Department>();
            foreach (DataRow fila in dt.Rows)
            {  Department u = new Department();
                u.idDepartamento = Convert.ToInt32(fila[0].ToString());
                u.nombre = fila[1].ToString();
                u.ubicacion = fila[2].ToString();
                listaDep.Add(u);

            }

            return listaDep;
        }
        
    }
}