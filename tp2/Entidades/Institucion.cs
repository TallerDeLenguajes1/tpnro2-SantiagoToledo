using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Institucion
    {
        static public string Nombre { get; set; }
        static public int Matricula_Mimisterio { get; set; }
        static public readonly List<Curso> Cursos = new List<Curso>();
        static public readonly List<Alumno> Alumnos = new List<Alumno>();
        static public readonly List<Empleado> Empleados = new List<Empleado>();

        static public void AgregarCurso(Curso cursoX)
        {
            Cursos.Add(cursoX);
        }

    }
}
