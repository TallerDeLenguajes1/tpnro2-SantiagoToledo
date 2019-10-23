using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public static class AlumnoABM
    {
        public static void insertAlumno(Alumno alumnoX)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = @"Insert into alumno(Nombre,Apellido,Dni,Fnacimiento) values( @Nombre, @Apellido, @Dni, @Fnacimiento)";
                con.Conectar();
                
                var cmd = new MySqlCommand(sql, con.cn);
                cmd.Parameters.AddWithValue("@Nombre", alumnoX.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", alumnoX.Apellido);
                cmd.Parameters.AddWithValue("Dni", alumnoX.Dni);
                cmd.Parameters.AddWithValue("@Fnacimiento", alumnoX.Fnacimiento);
                cmd.ExecuteNonQuery();
                con.Desconectar();

                cmd.CommandText = "SELECT LAST_INSERT_ID()";
                alumnoX.IdAlumno = Convert.ToInt32(cmd.ExecuteScalar());
                

            }
            catch (Exception)
            {

            }

        }

        public static List<Alumno> listaAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();
            Alumno alumnoX;
            Conexion con = new Conexion();
            con.Conectar();
            try
            {
                string sql = "select * from alumno";
                var cmd = new MySqlCommand(sql, con.cn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    alumnoX = new Alumno();
                    alumnoX.IdAlumno = dr.GetInt16("idAlumno");
                    alumnoX.Nombre = dr.GetString("nombre");
                    alumnoX.Apellido = dr.GetString("apellido");
                    alumnoX.Dni = dr.GetString("dni");
                    alumnoX.Fnacimiento = dr.GetDateTime("Fnacimiento");
                    alumnos.Add(alumnoX);
                }
                dr.Close();

            }
            catch (Exception)
            {
              
            }

            con.Desconectar();
            return alumnos;
        }
        
        /*public Alumno getAlumnoById(int idAlumno)
        {

        }*/
    }
}
