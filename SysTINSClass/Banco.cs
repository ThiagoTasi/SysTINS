using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTINSClass
{
    // classe é a nossa classe de conexão
    public static class Banco //static pois não precisaremos criar uma instancia
                              //de banco para conectar às nossas bases de dados
    {
        public static MySqlCommand Abrir() // método para abrir conexão
        {
            string strcon = @"server=127.0.0.1;database=systinsdb01;user=root;password=";
            MySqlConnection cn = new(strcon);
            MySqlCommand cmd = new();
            try
            {
                cn.Open();
                cmd.Connection = cn;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                
            }

            return cmd; 
        }
    }
  }
