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

        private string buildItemsPrecio(DataTable precios)
        {
            string items = "";
            foreach (DataRow row in precios.Rows)
            {
                items = items + row.Field<string>("COD_ITEM") + ">"
                    + row.Field<decimal>("PRECIO_MAYOREO") + ">"
                    + row.Field<decimal>("DESCUENTO") + ">"
                    + row.Field<decimal>("LIQUIDACION") + ">"
                    + row.Field<decimal>("PRECIO_DETALLE") +  "&";
            }
            return items;
        }


        public DataTable getPrecios(eCategoria categoria)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            DataRow row = null;
            try
            {
                string sql = "SELECT * FROM karol.view_lista_precios WHERE CATEGORIA = @cat_inv;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                MySqlParameter cat_inv = cmd.Parameters.Add("cat_inv", MySqlDbType.VarChar, 50);
                cat_inv.Direction = ParameterDirection.Input;

                cat_inv.Value = categoria.ToString();

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("NO SE PUDO CONSULTAR LOS PRECIOS DE "+categoria.ToString()+" \n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }


        public bool setPrecios(DataTable precios, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_SET_PRECIOS";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter items_precios = cmd.Parameters.Add("items_precios", MySqlDbType.LongText);
                items_precios.Direction = ParameterDirection.Input;

                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                items_precios.Value = buildItemsPrecio(precios);

                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
                MessageBox.Show("LISTA DE PRECIOS ACTUALIZADA", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ACTUALIZAR PRECIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }








        //CONTROL DE PARAMETROS GLOBALES

        public bool setParam(Parametros param)
        {
            bool OK = true;
            try
            {

                string sql = "karol.SP_SET_PARAM";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter nivel = cmd.Parameters.Add("nivelP", MySqlDbType.Int32);
                nivel.Direction = ParameterDirection.Input;
                MySqlParameter fecha = cmd.Parameters.Add("fechaP", MySqlDbType.Date);
                fecha.Direction = ParameterDirection.Input;
                MySqlParameter auto = cmd.Parameters.Add("autorizoP", MySqlDbType.VarChar, 15);
                auto.Direction = ParameterDirection.Input;
                MySqlParameter p_credito = cmd.Parameters.Add("p_credito", MySqlDbType.Int32);
                p_credito.Direction = ParameterDirection.Input;
                MySqlParameter p_desc = cmd.Parameters.Add("p_desc", MySqlDbType.Int32);
                p_desc.Direction = ParameterDirection.Input;

                nivel.Value = (int)param.NIVEL;
                fecha.Value = param.FECHA.Date.ToString("yyyy-MM-dd"); ;
                auto.Value = param.COD_EMPLEADO.ToUpper();
                p_credito.Value = param.PLAZO_CREDITO;
                p_desc.Value = param.PLAZO_DESC;

                cmd.ExecuteNonQuery();
                MessageBox.Show("PARAMETROS DE NEGOCIO ACTUALIZADOS", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(null, e.Message, "ERROR AL ACTUALIZAR PARAMETROS DE NEGOCIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }




        public DataRow getParam(eNIVEL nivel)
        {
            MySqlDataReader reader;
            // Creamos nuestro queridisimo DataSet
            DataTable datos = new DataTable();
            DataRow row = null;
            try
            {
                string sql = "karol.SP_GET_PARAM";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter n = cmd.Parameters.Add("nivelP", MySqlDbType.Int32);
                n.Direction = ParameterDirection.Input;

                n.Value = (int)nivel;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("NO SE PUDO CONSULTAR LOS PARAMETROS DE NEGOCIO" + nivel.ToString() + "\n Detalle: "+e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (datos.Rows.Count == 1)
            {
                row = datos.Rows[0];
            }
            return row;
        }


        

        //PERSONAL
        public DataTable getPersonal(ePuestoPersonal puesto)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            DataRow row = null;
            try
            {
                string sql = "ddicark.SP_GET_PERSONAL;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter tipo = cmd.Parameters.Add("tipo", MySqlDbType.VarChar, 50);
                tipo.Direction = ParameterDirection.Input;

                tipo.Value = puesto.ToString();

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("NO SE PUEDE CONSULTAR "+puesto.ToString()+ "\n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }

    }
}
