namespace ParcialFinal.Modelo
{
    public class Department
    {
        public int idDepartamento { get; set; }
        public string nombre { get; set; }
        public string ubicacion { get; set; }

        public Department()
        {
            idDepartamento = 0;
            nombre = "";
            ubicacion = "";
        }
    }
}