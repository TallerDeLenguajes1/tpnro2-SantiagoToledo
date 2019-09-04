using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso
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
    }

    public class Presencial: Curso
    {

    }
    public class SemiPresencial : Curso
    {

    }
    public class NoPresencial : Curso
    {

    }
}
