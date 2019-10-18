using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;


        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Database=Taller2;Integrated Security=True");
                //Corregir datos
            }

            catch (Exception ex)
            {
                //Agregar Log
            }
        }

        public void Conectar()
        {
            cn.Open();
        }
        public void Desconectar()
        {
            cn.Close();
        }


        public void NonQuery(string sql)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {

                //asdsd
            }
        }
        public SqlDataReader Reader(string sql)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand(sql, cn);
                dr = cmd.ExecuteReader();
                cn.Close();
            }
            catch (Exception ex)
            {
                //.
            }
            return dr;
        }



    }
}

