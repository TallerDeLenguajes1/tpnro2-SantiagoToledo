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


    }
}

