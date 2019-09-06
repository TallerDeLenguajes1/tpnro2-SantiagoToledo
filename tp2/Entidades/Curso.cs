using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Curso
    {
        public DateTime Turno { get; set; }
        private readonly List<Alumno> Alumnos = new List<Alumno>();
        public Empleados Docente { get; set; }
        public string Tema { get; set; }
        public double Cuota { get; set; }
        public double Inscripcion { get; set; }

        public void CargarAlumno()
        {

        }

        public virtual List<Cuota> ValorCuota()
        {
            return null;
        }
    }

    public class Presencial: Curso
    {
        public override List<Cuota> ValorCuota()
        {
            List<Cuota> cuotas = new List<Entidades.Cuota>();
            return null;
        }

    }
    public class SemiPresencial : Curso
    {
        public override double ValorCuota()
        {
            return Cuota * 1.21;
        }

    }
    public class NoPresencial : Curso
    {

    }
}
