using System.Collections.Generic;

namespace Entidades
{
    public class Alumno : Persona
    {
        public int IdAlumno { get; set; }
        private List<Cuota> cuotas;

        public override string ToString()
        {
            return Apellido+", " + Nombre;
        }

        public void setCuotas(List<Cuota> cuotasX)
        {
            cuotas = cuotasX;
        }


        //Hace falta instancear una cuota si se la recibe directamente????
    }
}
