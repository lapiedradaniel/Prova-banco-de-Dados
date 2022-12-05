using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_banco_de_Dados
{
    internal class Conexão
    {
        private static string conexao = @"server=localhost;port=3306;user id=root;pwd=1234;database=bd_aula16";
        private bool resultado;
        private MySqlCommand comando;
        private MySqlConnection connection = new MySqlConnection(conexao);
        public bool ComandoSql(string sql)
        {
            try
            {
                connection.Open();
                comando = new MySqlCommand(sql,connection);
                comando.ExecuteNonQuery();
                resultado = true;   
            } catch (Exception ex)
            {
                resultado= false;
                Console.WriteLine("ERRO! " + ex);
            }
            finally
            {
                connection.Close();
            }
            return resultado;
        }

        public DataTable Busca(string sql)
        {
            try
            {
                connection.Open();
                comando = new MySqlCommand(sql,connection); 
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand= comando;
                DataTable dt = new DataTable();
                da.Fill(dt);    
                return dt;  
            }catch(Exception ex)
            {
                Console.WriteLine("Erro!" + ex)
                    ; return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }

}
