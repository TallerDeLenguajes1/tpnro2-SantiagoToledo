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
        static public List<Curso> Cursos = new List<Curso>();
        static public List<Alumno> Alumnos = new List<Alumno>();
        static public List<Empleado> Empleados = new List<Empleado>();
    }
}
