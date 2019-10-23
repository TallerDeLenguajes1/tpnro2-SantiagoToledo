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

    }
}
