using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    static class Institucion
    {
        static public string Nombre { get; set; }
        static public int Matricula_Mimisterio { get; set; }
        static public readonly List<Curso> Cursos = new List<Curso>();


        static public void CrearCurso()
        {
            var cursoX = new Curso();
            Cursos.Add(cursoX);
        }

    }
}
