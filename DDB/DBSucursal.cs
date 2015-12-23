using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDB
{
    using MODELO;
    using System.Data;
    using MySql.Data.MySqlClient;

    public class DBSucursal
    {
        private DBConexion conn;

        public DBSucursal()
        {
            conn = DBConexion.Instance();
        }



        public DataTable showSucursales()
        {
            // Bien... Tenemos que crear un adaptador para volcar los datos de la BD en un objeto DataSet
            MySqlDataReader reader;
            // Creamos nuestro queridisimo DataSet
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT * FROM karol.view_sucursales;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL CONSULTAR SUCURSALES", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }





        public DataRow findByCodigo(string cod)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT * FROM karol.view_sucursales WHERE COD_SUC = @codigo; ";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;
                MySqlParameter codigo = cmd.Parameters.Add("codigo", MySqlDbType.VarChar, 2);
                codigo.Direction = ParameterDirection.Input;

                codigo.Value = cod;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL OBTENER SUCURSAL", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos.Rows[datos.Rows.Count - 1];
        }


        /// <summary>
        /// /////////////////////////////////////////
        /// </summary>
        /// <param name="cod"></param>
        /// <returns></returns>


        public DataRow findByCodigoConfig(string cod)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "karol.SP_GET_SUCURSAL_CONFIG";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter codigo = cmd.Parameters.Add("codigoSuc", MySqlDbType.VarChar, 2);
                codigo.Direction = ParameterDirection.Input;

                codigo.Value = cod;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL OBTENER SUCURSAL", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos.Rows[datos.Rows.Count - 1];
        }



        public DataTable showSucursalesConfig()
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "karol.SP_SHOW_SUCURSALES_CONFIG";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("NO SE PUDO CONSULTAR LAS CONFIGURACIONES DE LAS SUCURSALES DE PRENDASAL\n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }



        public DataTable showSucursalesNoConfig()
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "karol.SP_SHOW_SUCURSALES_NO_CONFIG";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("NO SE PUDO CONSULTAR LAS SUCURSALES DE PRENDASAL\n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }





        public bool insertSucConfig(Sucursal sucursal)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_INSERT_SUCURSAL_CONFIG";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter codigoSuc = cmd.Parameters.Add("codigoSuc", MySqlDbType.VarChar, 2);
                codigoSuc.Direction = ParameterDirection.Input;
                MySqlParameter ipSuc = cmd.Parameters.Add("ipSuc", MySqlDbType.VarChar, 20);
                ipSuc.Direction = ParameterDirection.Input;
                MySqlParameter hostSuc = cmd.Parameters.Add("hostSuc", MySqlDbType.VarChar, 50);
                hostSuc.Direction = ParameterDirection.Input;
                MySqlParameter fechaSuc = cmd.Parameters.Add("fechaSuc", MySqlDbType.Int32);
                fechaSuc.Direction = ParameterDirection.Input;

                codigoSuc.Value = sucursal.COD_SUC;
                ipSuc.Value = sucursal.IP;
                hostSuc.Value = sucursal.HOSTNAME;
                fechaSuc.Value = (int)sucursal.FECHA_SISTEMA;

                cmd.ExecuteNonQuery();
                MessageBox.Show("CONFIGURACION DE SUCURSAL AGREGADA", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL AGREGAR CONFIGURACION DE SUCURSAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }


        public bool updateSucConfig(Sucursal sucursal)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_UPDATE_SUCURSAL_CONFIG";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter codigoSuc = cmd.Parameters.Add("codigoSuc", MySqlDbType.VarChar, 2);
                codigoSuc.Direction = ParameterDirection.Input;
                MySqlParameter ipSuc = cmd.Parameters.Add("ipSuc", MySqlDbType.VarChar, 20);
                ipSuc.Direction = ParameterDirection.Input;
                MySqlParameter hostSuc = cmd.Parameters.Add("hostSuc", MySqlDbType.VarChar, 50);
                hostSuc.Direction = ParameterDirection.Input;
                MySqlParameter fechaSuc = cmd.Parameters.Add("fechaSuc", MySqlDbType.Int32);
                fechaSuc.Direction = ParameterDirection.Input;

                codigoSuc.Value = sucursal.COD_SUC;
                ipSuc.Value = sucursal.IP;
                hostSuc.Value = sucursal.HOSTNAME;
                fechaSuc.Value = (int)sucursal.FECHA_SISTEMA;

                cmd.ExecuteNonQuery();
                MessageBox.Show("CONFIGURACION DE SUCURSAL ACTUALIZADA", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ACTUALIZAR CONFIGURACION DE SUCURSAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }


        public bool deleteSucConfig(Sucursal sucursal)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_DELETE_SUCURSAL_CONFIG";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter codigo = cmd.Parameters.Add("codigoSuc", MySqlDbType.VarChar, 2);
                codigo.Direction = ParameterDirection.Input;


                codigo.Value = sucursal.COD_SUC;

                cmd.ExecuteNonQuery();
                MessageBox.Show("CONFIGURACION DE SUCURSAL ELIMINADA", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ELIMINAR CONFIGURACION DE SUCURSAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }


    }
}
