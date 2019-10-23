using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class Conexion
    {
        public MySqlConnection cn { get; }
       
        public Conexion()
        {
            try
            {
                cn = new MySqlConnection("Server = localhost; Database = instituto; Uid = root; Pwd = 1234 ;");
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

