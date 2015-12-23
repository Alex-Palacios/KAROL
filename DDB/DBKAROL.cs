using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB
{
    using System.Windows.Forms;
    using System.Data;
    using MySql.Data.MySqlClient;
    using MODELO;

    public class DBKAROL
    {
        private DBConexion conn;

        public DBKAROL()
        {
            conn = DBConexion.Instance();
        }


        //PROCEDIMIENTOS

        public DataTable getDeptos()
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "ddicark.SP_GET_DEPTOS";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e) { }
            return datos;
        }



        public DataTable getMunicipios(string d)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "ddicark.SP_GET_MUNICIPIOS";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter depto = cmd.Parameters.Add("departamento", MySqlDbType.VarChar, 30);
                depto.Direction = ParameterDirection.Input;
                depto.Value = d;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e) { }
            return datos;
        }




        public DataTable getLOG(string sistema, string tabla, string codigo)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "ddicark.SP_GET_LOG;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;
                MySqlParameter tbl = cmd.Parameters.Add("tbl", MySqlDbType.VarChar, 50);
                tbl.Direction = ParameterDirection.Input;
                MySqlParameter cod = cmd.Parameters.Add("cod", MySqlDbType.VarChar, 50);
                cod.Direction = ParameterDirection.Input;

                sys.Value = sistema;
                tbl.Value = tabla;
                cod.Value = codigo;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("NO SE PUDO CONSULTAR EL LOG DE TRANSACCIONES \n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }





        //FUNCIONES
        public DateTime date_system()
        {
            DateTime fecha = new DateTime();
            try
            {
                string sql = "SELECT ddicark.FN_GET_DATE_SYSTEM();";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                fecha = (DateTime)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            { MessageBox.Show("NO SE PUDO OBTENER FECHA DE SERVIDOR", "ERROR SERVER", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            return fecha;
        }



        public bool LOGIN(string sistema, string usuario, string password)
        {
            bool reader = false;
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT ddicark.FN_LOGIN(@sys,@user,@pass)";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;
                MySqlParameter user = cmd.Parameters.Add("user", MySqlDbType.VarChar, 15);
                user.Direction = ParameterDirection.Input;
                MySqlParameter pass = cmd.Parameters.Add("pass", MySqlDbType.VarChar, 32);
                pass.Direction = ParameterDirection.Input;

                user.Value = usuario;
                pass.Value = md5(password);
                sys.Value = sistema;

                reader = (bool)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                reader = false;
                MessageBox.Show(e.Message, "ACCESO DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return reader;
        }



        public static string md5(string password)
        {
            //Declaraciones
            System.Security.Cryptography.MD5 md5;
            md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            //Conversion
            Byte[] encodedBytes = md5.ComputeHash(ASCIIEncoding.Default.GetBytes(password));  //genero el hash a partir de la password original

            //return BitConverter.ToString(encodedBytes);      //esto, devuelve el hash con "-" cada 2 char
            return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(encodedBytes).ToLower(), @"-", "");     //devuelve el hash continuo y en minuscula. (igual que en php)
        }




        //CONTROL DE PRECIOS

        
        //CONTROL DE REGLAS DEL NEGOCIO

        

    }
}
