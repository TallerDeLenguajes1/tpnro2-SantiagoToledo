using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Turno { Maniana, Tarde }

    public abstract class Curso
    {
        public int IdCurso { get; set; }
        public Turno Turno { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public Empleado Docente { get; set; }
        public string Tema { get; set; }
        public double Cuota { get; set; }
        public double Inscripcion { get; set; }

        public Curso(Turno turno, Empleado docente, string tema, double cuota, double inscripcion)
        {
            Turno = turno;
            Docente = docente;
            Tema = tema;
            Cuota = cuota;
            Inscripcion = inscripcion;
        }

        public void CargarAlumnos(List<Alumno> x)
        {
            Alumnos=x;
        }

        public virtual List<Cuota> CrearCuotas()
        {
            return null;
        }

        public override string ToString()
        {
            return  Tema +", " + Docente ;
        }
    }


    public class Presencial: Curso
    {
        public Presencial(Turno turno, Empleado docente, string tema, double cuota, double inscripcion) : base(turno,docente,tema,cuota,inscripcion){ }

        public override List<Cuota> CrearCuotas()
        {
            List<Cuota> cuotas = new List<Entidades.Cuota>();
            return cuotas;
        }

    }

    public class SemiPresencial : Curso
    {
        public SemiPresencial(Turno turno, Empleado docente, string tema, double cuota, double inscripcion) : base(turno,docente,tema,cuota,inscripcion){ }


        public override List<Cuota> CrearCuotas()
        {
            return null;
        }

    }
    public class NoPresencial : Curso
    {
        public NoPresencial(Turno turno, Empleado docente, string tema, double cuota, double inscripcion) : base(turno,docente,tema,cuota,inscripcion){ }


        public override List<Cuota> CrearCuotas()
        {
            return null;
        }
    }
}
