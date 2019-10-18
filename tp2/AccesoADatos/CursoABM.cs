using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class CursoABM
    {
        public List<Curso> listaCursos()
        {
            List<Curso> cursos = new List<Curso>();
            Curso cursoX;
            Conexion con = new Conexion();
            con.Conectar();

            try
            {
                string sql = "select * from Cursos";
                var cmd = new MySqlCommand(sql, con.cn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Empleado docente = cargarDocente(dr["idDocente"]); //completar. Consideracion al hacer la bdd

                    switch (dr["Modalidad"].ToString())
                    {
                        case "Presencial":
                            cursoX = new Presencial(DateTime.Parse(dr["Turno"].ToString()),
                                docente,
                                dr["tema"].ToString(),
                                Double.Parse(dr["cuota"].ToString()),
                                Double.Parse(dr["inscripcion"].ToString()) );
                            break;
                        case "SemiPresencial":
                            cursoX = new SemiPresencial(DateTime.Parse(dr["Turno"].ToString()),
                                docente,
                                dr["tema"].ToString(),
                                Double.Parse(dr["cuota"].ToString()),
                                Double.Parse(dr["inscripcion"].ToString()));
                            break;
                        case "NoPresencial":
                            cursoX = new NoPresencial(DateTime.Parse(dr["Turno"].ToString()),
                                docente,
                                dr["tema"].ToString(),
                                Double.Parse(dr["cuota"].ToString()),
                                Double.Parse(dr["inscripcion"].ToString()));
                            break;
                    }

                    cursos.Add(cursoX);
                }

            }
            catch (Exception)
            {
                throw;
            }

            con.Desconectar();
            return cursos;

        }

    }

    }
}
