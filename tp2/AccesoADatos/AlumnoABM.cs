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
        public static void altaAlumno(Alumno alumnoX)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = @"Insert into Alumnos(Apellido,Nombre,Dni,Fnacimiento) values( @Apellido , @Nombre, @Dni, @Fnacimiento)";
                con.Conectar();
                
                var cmd = new MySqlCommand(sql, con.cn);
                cmd.Parameters.AddWithValue("@Nombre", alumnoX.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", alumnoX.Apellido);
                cmd.ExecuteNonQuery();
                con.Desconectar();
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
                    alumnoX.Nombre = dr["Nombre"].ToString();
                    alumnoX.Apellido = dr["Apellido"].ToString();
                    alumnoX.Dni = dr["Dni"].ToString();
                    alumnoX.Fnacimiento = DateTime.Parse(dr["Fnacimiento"].ToString());

                    alumnos.Add(alumnoX);
                }

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
