using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public static class CursoABM
    {
        public static List<Curso> listaCursos()
        {
            List<Curso> cursos = new List<Curso>();
            Curso cursoX;
            Conexion con = new Conexion();
            con.Conectar();

            try
            {
                string sql = "select * from Curso";
                var cmd = new MySqlCommand(sql, con.cn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    
                    Empleado docente = EmpleadoABM.cargarEmpleadoByID( int.Parse(dr["idDocente"].ToString())) ; 

                    switch (dr["Modalidad"].ToString())
                    {
                        case "Presencial":
                            cursoX = new Presencial(
                                (Turno) Enum.Parse(typeof(Turno), dr.GetString("turno")),
                                docente,
                                dr["tema"].ToString(),
                                Double.Parse(dr["cuota"].ToString()),
                                Double.Parse(dr["inscripcion"].ToString()) );
                            break;

                        case "SemiPresencial":
                            cursoX = new SemiPresencial(
                                (Turno)Enum.Parse(typeof(Turno), dr.GetString("turno")),
                                docente,
                                dr["tema"].ToString(),
                                Double.Parse(dr["cuota"].ToString()),
                                Double.Parse(dr["inscripcion"].ToString()));
                            break;

                        case "NoPresencial":
                            cursoX = new NoPresencial(
                                (Turno)Enum.Parse(typeof(Turno), dr.GetString("turno")),
                                docente,
                                dr["tema"].ToString(),
                                Double.Parse(dr["cuota"].ToString()),
                                Double.Parse(dr["inscripcion"].ToString()));
                            break;
                        default:
                            cursoX = null;
                            break;
                    }

                    cursos.Add(cursoX);
                }

            }
            catch (Exception)
            {
               // throw;
            }

            con.Desconectar();
            return cursos;
        }


        public static void insertCurso(Curso cursoX)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = @"Insert into curso(Tema,Docente,Cuota,Inscripcion,Turno) values( @Tema, @Docente, @Cuota, @Inscripcion, @Turno)";
                con.Conectar();

                var cmd = new MySqlCommand(sql, con.cn);
                cmd.Parameters.AddWithValue("@Tema", cursoX.Tema);
                cmd.Parameters.AddWithValue("@Docente", cursoX.Docente.IdEmpleado);
                cmd.Parameters.AddWithValue("@Cuota", cursoX.Cuota);
                cmd.Parameters.AddWithValue("@Inscripcion", cursoX.Inscripcion);
                cmd.Parameters.AddWithValue("@Turno", cursoX.Turno.ToString());

                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT LAST_INSERT_ID()";
                cursoX.IdCurso = Convert.ToInt32(cmd.ExecuteScalar());

                foreach(var alumnoX in cursoX.Alumnos)
                {
                    cmd.CommandText = "INSERT into cursa(idAlumno,idCurso) values (@idAlumno, @IdCurso";
                    cmd.Parameters.AddWithValue("@idAlumno", alumnoX.IdAlumno);
                    cmd.Parameters.AddWithValue("@idCurso", cursoX.IdCurso);

                    cmd.ExecuteNonQuery();
                }

                con.Desconectar();
            }
            catch (Exception)
            {

            }
        }

    }

}
