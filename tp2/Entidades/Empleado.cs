using System;

namespace Entidades
{
    public class Empleado : Persona
    {
        public DateTime FdeAlta { get; set; }
        public string Cargo { get; set; }
        public double Sueldo { get; set; }

        public int Antiguedad()
        {
            int ant=0;

            return ant;
        }

        public override string ToString()
        {
            return Apellido+Nombre+", "+Cargo;
        }

    }
}
