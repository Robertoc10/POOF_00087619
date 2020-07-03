namespace ParcialFinal.Modelo
{
    public class User
    {
      public int idUsuario { get; set; }
      public int idDepartamento { get; set; }
      public string contrasenia { get; set; }
      public string nombre { get; set; }
      public string apellido { get; set; }
      public string dui { get; set; }
      public string fechaNacimiento { get; set; }

      public User()
      {
          idUsuario = 0;
          idDepartamento = 0;
          contrasenia = "";
          nombre = "";
          apellido = "";
          dui = "";
          fechaNacimiento = "";
      }
    }
    
}