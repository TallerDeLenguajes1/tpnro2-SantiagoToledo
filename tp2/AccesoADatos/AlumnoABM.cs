using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class AlumnoABM
    {
        public void altaAlumno(Alumno al, Conexion con = null)
        {
            try
            {
                if (con == null)
                {
                    con = new Conexion();
                }
                string sql = @"Insert into Alumnos(Apellido,Nombre,Dni,Fnacimiento) values( @Apellido ",'" + al.Nombre + "','" + al.Dni + "','" + al.Fnacimiento + "')";
                con.Conectar();
                var cmd = new SqlCommand(sql, co.);
                cmd.Parameters.AddWithValue("@Apellido", al.Apellido);
                cmd.Parameters.AddWithValue("@Apellido", al.Apellido);
                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch (Exception)
            {

            }

        }
    }
}
