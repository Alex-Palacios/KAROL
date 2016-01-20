using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB
{
    using MODELO;
    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Windows.Forms;

    public class DBCompra
    {

        private DBConexion conn;

        public DBCompra()
        {
            conn = DBConexion.Instance();
        }






        // FUNCIONES CRUD
        public bool insert(Compra compra, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_INSERT_COMPRA";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter suc_compra = cmd.Parameters.Add("suc_compra", MySqlDbType.VarChar, 2);
                suc_compra.Direction = ParameterDirection.Input;
                MySqlParameter prov_compra = cmd.Parameters.Add("prov_compra", MySqlDbType.VarChar, 15);
                prov_compra.Direction = ParameterDirection.Input;
                MySqlParameter fecha_compra = cmd.Parameters.Add("fecha_compra", MySqlDbType.Date);
                fecha_compra.Direction = ParameterDirection.Input;
                MySqlParameter tipo_compra = cmd.Parameters.Add("tipo_compra", MySqlDbType.Int32);
                tipo_compra.Direction = ParameterDirection.Input;
                MySqlParameter num_compra = cmd.Parameters.Add("num_compra", MySqlDbType.VarChar, 20);
                num_compra.Direction = ParameterDirection.Input;
                MySqlParameter tipodoc_compra = cmd.Parameters.Add("tipodoc_compra", MySqlDbType.VarChar,5);
                tipodoc_compra.Direction = ParameterDirection.Input;
                MySqlParameter doc_compra = cmd.Parameters.Add("doc_compra", MySqlDbType.VarChar, 20);
                doc_compra.Direction = ParameterDirection.Input;
                MySqlParameter ajuste_compra = cmd.Parameters.Add("ajuste_compra", MySqlDbType.Decimal);
                ajuste_compra.Direction = ParameterDirection.Input;
                MySqlParameter total_compra = cmd.Parameters.Add("total_compra", MySqlDbType.Decimal);
                total_compra.Direction = ParameterDirection.Input;
                MySqlParameter cat_compra = cmd.Parameters.Add("cat_compra", MySqlDbType.VarChar, 50);
                cat_compra.Direction = ParameterDirection.Input;
                MySqlParameter nota_compra = cmd.Parameters.Add("nota_compra", MySqlDbType.VarChar, 100);
                nota_compra.Direction = ParameterDirection.Input;

                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                suc_compra.Value = compra.COD_SUC;
                prov_compra.Value = compra.COD_PROVEEDOR;
                fecha_compra.Value = compra.FECHA.Date;
                tipo_compra.Value = (int)compra.TIPO;
                num_compra.Value = compra.NUMCOMPRA;
                tipodoc_compra.Value = compra.TIPO_DOC.ToString();
                doc_compra.Value = compra.DOCUMENTO;
                ajuste_compra.Value = compra.AJUSTE;
                total_compra.Value = compra.TOTAL;
                cat_compra.Value = compra.CATEGORIA.ToString();
                nota_compra.Value = compra.NOTA;


                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
                MessageBox.Show("COMPRA REGISTRADA", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL REGISTRAR COMPRA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }




        public bool update(Compra compra, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_UPDATE_COMPRA";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter idcompra = cmd.Parameters.Add("idcompra", MySqlDbType.Int32);
                idcompra.Direction = ParameterDirection.Input;
                MySqlParameter suc_compra = cmd.Parameters.Add("suc_compra", MySqlDbType.VarChar, 2);
                suc_compra.Direction = ParameterDirection.Input;
                MySqlParameter prov_compra = cmd.Parameters.Add("prov_compra", MySqlDbType.VarChar, 15);
                prov_compra.Direction = ParameterDirection.Input;
                MySqlParameter fecha_compra = cmd.Parameters.Add("fecha_compra", MySqlDbType.Date);
                fecha_compra.Direction = ParameterDirection.Input;
                MySqlParameter tipo_compra = cmd.Parameters.Add("tipo_compra", MySqlDbType.Int32);
                tipo_compra.Direction = ParameterDirection.Input;
                MySqlParameter num_compra = cmd.Parameters.Add("num_compra", MySqlDbType.VarChar, 20);
                num_compra.Direction = ParameterDirection.Input;
                MySqlParameter tipodoc_compra = cmd.Parameters.Add("tipodoc_compra", MySqlDbType.VarChar, 5);
                tipodoc_compra.Direction = ParameterDirection.Input;
                MySqlParameter doc_compra = cmd.Parameters.Add("doc_compra", MySqlDbType.VarChar, 20);
                doc_compra.Direction = ParameterDirection.Input;
                MySqlParameter ajuste_compra = cmd.Parameters.Add("ajuste_compra", MySqlDbType.Decimal);
                ajuste_compra.Direction = ParameterDirection.Input;
                MySqlParameter total_compra = cmd.Parameters.Add("total_compra", MySqlDbType.Decimal);
                total_compra.Direction = ParameterDirection.Input;
                MySqlParameter cat_compra = cmd.Parameters.Add("cat_compra", MySqlDbType.VarChar, 50);
                cat_compra.Direction = ParameterDirection.Input;
                MySqlParameter nota_compra = cmd.Parameters.Add("nota_compra", MySqlDbType.VarChar, 100);
                nota_compra.Direction = ParameterDirection.Input;

                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                idcompra.Value = compra.ID_COMPRA;
                suc_compra.Value = compra.COD_SUC;
                prov_compra.Value = compra.COD_PROVEEDOR;
                fecha_compra.Value = compra.FECHA.Date;
                tipo_compra.Value = (int)compra.TIPO;
                num_compra.Value = compra.NUMCOMPRA;
                tipodoc_compra.Value = compra.TIPO_DOC.ToString();
                doc_compra.Value = compra.DOCUMENTO;
                ajuste_compra.Value = compra.AJUSTE;
                total_compra.Value = compra.TOTAL;
                cat_compra.Value = compra.CATEGORIA.ToString();
                nota_compra.Value = compra.NOTA;
                
                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
                MessageBox.Show("COMPRA ACTUALIZADA", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ACTUALIZAR COMPRA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }




        public bool delete(Compra compra, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_DELETE_COMPRA";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter idcompra = cmd.Parameters.Add("idcompra", MySqlDbType.Int32);
                idcompra.Direction = ParameterDirection.Input;

                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                idcompra.Value = compra.ID_COMPRA;

                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO DE COMPRA ELIMINADA", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ELIMINAR COMPRA ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }





        public DataTable getItemsCompra(Compra compra)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "karol.SP_GET_ITEMS_COMPRA";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter idcompra = cmd.Parameters.Add("idcompra", MySqlDbType.Int32);
                idcompra.Direction = ParameterDirection.Input;

                idcompra.Value = compra.ID_COMPRA;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL CONSULTAR DETALLE DE COMPRA", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }




        public DataRow getUltimaCompra(string sucursal)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            DataRow row = null;
            try
            {
                string sql = "SELECT * FROM karol.view_compras WHERE ID_COMPRA = (SELECT MAX(ID_COMPRA) FROM karol.compra);";
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
                MessageBox.Show("ERROR AL OBTENER COMPRA", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (datos.Rows.Count == 1)
            {
                row = datos.Rows[0];
            }
            return row;
        }



        public DataRow getCompraByDoc(string documento)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            DataRow row = null;
            try
            {
                string sql = "SELECT * FROM karol.view_compras WHERE DOCUMENTO = @doc ORDER BY ID_COMPRA DESC;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                MySqlParameter doc = cmd.Parameters.Add("doc", MySqlDbType.VarChar, 20);
                doc.Direction = ParameterDirection.Input;

                doc.Value = documento;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL OBTENER COMPRA", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (datos.Rows.Count > 0)
            {
                row = datos.Rows[0];
            }
            return row;
        }




        



    }
}
