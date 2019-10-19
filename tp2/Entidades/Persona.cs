using Entidades;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fnacimiento { get; set; }
        public string Dni { get; set; }

        public int Edad()
        {
            int edad= 0;
          //  DateTime now = new DateTime();

            return edad;
        }

    }
}
