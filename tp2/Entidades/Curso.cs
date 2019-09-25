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
        public List<Alumno> Alumnos { get; set; }
        public Empleado Docente { get; set; }
        public string Tema { get; set; }
        public double Cuota { get; set; }
        public double Inscripcion { get; set; }

        public Curso(DateTime turno, Empleado docente, string tema, double cuota, double inscripcion)
        {
            Turno = turno;
            Docente = docente;
            Tema = tema;
            Cuota = cuota;
            Inscripcion = inscripcion;
            Alumnos = new List<Alumno>();
        }

        public void CargarAlumno(Alumno x)
        {
            Alumnos.Add(x);
        }

        public virtual List<Cuota> ValorCuota()
        {
            return null;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Presencial: Curso
    {
        public Presencial(DateTime turno, Empleado docente, string tema, double cuota, double inscripcion) : base(turno,docente,tema,cuota,inscripcion){ }

        public override List<Cuota> ValorCuota()
        {
            List<Cuota> cuotas = new List<Entidades.Cuota>();
            return null;
        }

    }
    public class SemiPresencial : Curso
    {
        public SemiPresencial(DateTime turno, Empleado docente, string tema, double cuota, double inscripcion) : base(turno,docente,tema,cuota,inscripcion){ }


        public override List<Cuota> ValorCuota()
        {
            return null;
        }

    }
    public class NoPresencial : Curso
    {
        public NoPresencial(DateTime turno, Empleado docente, string tema, double cuota, double inscripcion) : base(turno,docente,tema,cuota,inscripcion){ }


        public override List<Cuota> ValorCuota()
        {
            return null;
        }
    }
}
