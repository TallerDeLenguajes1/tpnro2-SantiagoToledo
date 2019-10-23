using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public static class EmpleadoABM
    {
        public static Empleado cargarEmpleadoByID(int idEmpleado)
        {
            Empleado empleadoX = new Empleado();

            try
            {
                Conexion con = new Conexion();
                con.Conectar();
                
                string sql = @"select * from  Empleado where idEmpleado='" + idEmpleado + "'";
                var cmd = new MySqlCommand(sql, con.cn);
                var dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    empleadoX.Nombre = dr["Nombre"].ToString();
                    empleadoX.Apellido = dr["Apellido"].ToString();
                    empleadoX.Fnacimiento = DateTime.Parse(dr["Fnacimiento"].ToString());
                    empleadoX.Dni = dr["Dni"].ToString();
                    empleadoX.FdeAlta= DateTime.Parse(dr["fdeAlta"].ToString());
                    empleadoX.Cargo = dr["cargo"].ToString();
                    empleadoX.Sueldo = Double.Parse(dr["sueldo"].ToString());
                }
                dr.Close();
                con.Desconectar();  
                
            }
            catch (Exception)
            {

                throw;
            }

            return empleadoX;
        }

        public static void insertEmpleado(Empleado empleadoX)
        {
            try
            {
                Conexion con = new Conexion();
                string sql = @"Insert into empleado(Nombre,Apellido,Dni,Fnacimiento,FdeAlta,cargo,sueldo) values( @Nombre, @Apellido, @Dni, @Fnacimiento,@FdeAlta, @Cargo, @Sueldo)";
                con.Conectar();

                var cmd = new MySqlCommand(sql, con.cn);
                cmd.Parameters.AddWithValue("@Nombre", empleadoX.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", empleadoX.Apellido);
                cmd.Parameters.AddWithValue("@Dni", empleadoX.Dni);
                cmd.Parameters.AddWithValue("@Fnacimiento", empleadoX.Fnacimiento);
                cmd.Parameters.AddWithValue("@FdeAlta", empleadoX.FdeAlta);
                cmd.Parameters.AddWithValue("@Cargo", empleadoX.Cargo);
                cmd.Parameters.AddWithValue("@Sueldo", empleadoX.Sueldo);

                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT LAST_INSERT_ID()";
                empleadoX.IdEmpleado = Convert.ToInt32(cmd.ExecuteScalar());

                con.Desconectar();
            }
            catch (Exception)
            {

            }
        }

        public static List<Empleado> listaEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            Empleado empleadoX;
            Conexion con = new Conexion();
            con.Conectar();
            try
            {
                string sql = "select * from empleado";
                var cmd = new MySqlCommand(sql, con.cn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    empleadoX = new Empleado();
                    empleadoX.IdEmpleado = dr.GetInt16("idEmpleado");
                    empleadoX.Nombre = dr.GetString("nombre");
                    empleadoX.Apellido = dr.GetString("apellido");
                    empleadoX.Dni = dr.GetString("dni");
                    empleadoX.Fnacimiento = dr.GetDateTime("Fnacimiento");
                    empleadoX.FdeAlta = dr.GetDateTime("FdeAlta");
                    empleadoX.Cargo = dr.GetString("cargo");
                    empleadoX.Sueldo = dr.GetDouble("sueldo");

                    empleados.Add(empleadoX);
                }

            }
            catch (Exception)
            {

            }

            con.Desconectar();
            return empleados;
        }

    }
}
