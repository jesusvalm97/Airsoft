using System;
using System.Collections.Generic;
using System.Text;

namespace AirsoftDeliciasChihuahua.Standard
{
    public class Propietario
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string CURP { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string ClubPerteneciente { get; set; }
    }
}
