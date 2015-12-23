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


        private string buildItemsCompra(Compra compra)
        {
            string items = "";
            foreach (DataRow row in compra.ITEMS_COMPRA.Rows)
            {
                items = items + row.Field<string>("COD_ITEM") + ">"
                    + row.Field<string>("COLOR") + ">"
                    + row.Field<string>("CORRIDA") + ">"
                    + row.Field<int>("T1") + ">"
                    + row.Field<int>("T2") + ">"
                    + row.Field<int>("T3") + ">"
                    + row.Field<int>("T4") + ">"
                    + row.Field<int>("T5") + ">"
                    + row.Field<int>("T6") + ">"
                    + row.Field<int>("T7") + ">"
                    + row.Field<int>("T8") + ">"
                    + row.Field<int>("T9") + ">"
                    + row.Field<int>("T10") + ">"
                    + row.Field<int>("T11") + ">"
                    + row.Field<int>("T12") + ">" 
                    + row.Field<int>("T13") + ">"
                    + row.Field<decimal>("MONTO") + "&";
            }
            return items;
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
                MySqlParameter doc_compra = cmd.Parameters.Add("doc_compra", MySqlDbType.VarChar, 20);
                doc_compra.Direction = ParameterDirection.Input;
                MySqlParameter tipo_pago = cmd.Parameters.Add("pago_compra", MySqlDbType.Int32);
                tipo_pago.Direction = ParameterDirection.Input;
                MySqlParameter total_compra = cmd.Parameters.Add("total_compra", MySqlDbType.Decimal);
                total_compra.Direction = ParameterDirection.Input;
                MySqlParameter cat_compra = cmd.Parameters.Add("cat_compra", MySqlDbType.VarChar, 50);
                cat_compra.Direction = ParameterDirection.Input;
                MySqlParameter nota_compra = cmd.Parameters.Add("nota_compra", MySqlDbType.VarChar, 100);
                nota_compra.Direction = ParameterDirection.Input;
                MySqlParameter items_compra = cmd.Parameters.Add("items_compra", MySqlDbType.LongText);
                items_compra.Direction = ParameterDirection.Input;

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
                doc_compra.Value = compra.DOCUMENTO;
                tipo_pago.Value = (int)compra.TIPO_PAGO;
                total_compra.Value = compra.TOTAL;
                cat_compra.Value = compra.CATEGORIA.ToString();
                nota_compra.Value = compra.NOTA;

                items_compra.Value = buildItemsCompra(compra);

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
                MySqlParameter doc_compra = cmd.Parameters.Add("doc_compra", MySqlDbType.VarChar, 20);
                doc_compra.Direction = ParameterDirection.Input;
                MySqlParameter tipo_pago = cmd.Parameters.Add("pago_compra", MySqlDbType.Int32);
                tipo_pago.Direction = ParameterDirection.Input;
                MySqlParameter total_compra = cmd.Parameters.Add("total_compra", MySqlDbType.Decimal);
                total_compra.Direction = ParameterDirection.Input;
                MySqlParameter cat_compra = cmd.Parameters.Add("cat_compra", MySqlDbType.VarChar, 50);
                cat_compra.Direction = ParameterDirection.Input;
                MySqlParameter nota_compra = cmd.Parameters.Add("nota_compra", MySqlDbType.VarChar, 100);
                nota_compra.Direction = ParameterDirection.Input;
                MySqlParameter items_compra = cmd.Parameters.Add("items_compra", MySqlDbType.LongText);
                items_compra.Direction = ParameterDirection.Input;

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
                doc_compra.Value = compra.DOCUMENTO;
                tipo_pago.Value = (int)compra.TIPO_PAGO;
                total_compra.Value = compra.TOTAL;
                cat_compra.Value = compra.CATEGORIA.ToString();
                nota_compra.Value = compra.NOTA;

                items_compra.Value = buildItemsCompra(compra);

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





        public DataRow getCompraByDoc(string documento)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            DataRow row = null;
            try
            {
                string sql = "SELECT * FROM karol.view_compras WHERE DOCUMENTO = @doc;";
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
            if (datos.Rows.Count == 1)
            {
                row = datos.Rows[0];
            }
            return row;
        }






    }
}
