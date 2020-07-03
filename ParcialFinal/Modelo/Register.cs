using System;

namespace ParcialFinal.Modelo
{
    public class Register
    {
        public int idRegistro { get; set; }
        public int idUsuario { get; set; }
        public bool entrada { get; set; }
        public DateTime fechaHora { get; set; }
        public string temperatura { get; set; }

        public Register()
        {
            idRegistro = 0;
            idUsuario = 0;
            entrada = true;
            fechaHora = DateTime.Now;
            temperatura ="";
        }
    }
}