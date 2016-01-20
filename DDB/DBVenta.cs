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

    public class DBVenta
    {

        private DBConexion conn;

        public DBVenta()
        {
            conn = DBConexion.Instance();
        }




        private string buildItemsVenta(Venta venta)
        {
            string items = "";
            foreach (DataRow row in venta.ITEMS_VENTA.Rows)
            {
                items = items + row.Field<string>("CODIGO") + ">"
                    + row.Field<int>("COMO") + ">"
                    + row.Field<string>("COD_ITEM") + ">"
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
                    + row.Field<decimal>("PRECIO") + ">"
                    + row.Field<decimal>("MONTO") + ">"
                    + row.Field<decimal>("DESC_PORCENT") + "&";
            }
            return items;
        }


        // FUNCIONES CRUD
        public bool insert(Venta venta, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_INSERT_VENTA";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter suc_venta = cmd.Parameters.Add("suc_venta", MySqlDbType.VarChar, 2);
                suc_venta.Direction = ParameterDirection.Input;
                MySqlParameter vendedor = cmd.Parameters.Add("vendedor", MySqlDbType.VarChar, 20);
                vendedor.Direction = ParameterDirection.Input;
                MySqlParameter cli_venta = cmd.Parameters.Add("cli_venta", MySqlDbType.VarChar, 15);
                cli_venta.Direction = ParameterDirection.Input;
                MySqlParameter enviodirec = cmd.Parameters.Add("enviodirec", MySqlDbType.VarChar, 255);
                enviodirec.Direction = ParameterDirection.Input;
                MySqlParameter pedido = cmd.Parameters.Add("pedido", MySqlDbType.VarChar, 20);
                pedido.Direction = ParameterDirection.Input;
                MySqlParameter fecha_venta = cmd.Parameters.Add("fecha_venta", MySqlDbType.Date);
                fecha_venta.Direction = ParameterDirection.Input;
                MySqlParameter tipo_venta = cmd.Parameters.Add("tipo_venta", MySqlDbType.Int32);
                tipo_venta.Direction = ParameterDirection.Input;
                MySqlParameter num_envio = cmd.Parameters.Add("num_envio", MySqlDbType.VarChar, 20);
                num_envio.Direction = ParameterDirection.Input;
                MySqlParameter pago_venta = cmd.Parameters.Add("pago_venta", MySqlDbType.Int32);
                pago_venta.Direction = ParameterDirection.Input;
                MySqlParameter plazo_venta = cmd.Parameters.Add("plazo_venta", MySqlDbType.Int32);
                plazo_venta.Direction = ParameterDirection.Input;
                MySqlParameter plazodesc_venta = cmd.Parameters.Add("plazodesc_venta", MySqlDbType.Int32);
                plazodesc_venta.Direction = ParameterDirection.Input;
                MySqlParameter aplidesc = cmd.Parameters.Add("aplidesc", MySqlDbType.Bit);
                aplidesc.Direction = ParameterDirection.Input;
                MySqlParameter desc_venta = cmd.Parameters.Add("desc_venta", MySqlDbType.Decimal);
                desc_venta.Direction = ParameterDirection.Input;
                MySqlParameter total_venta = cmd.Parameters.Add("total_venta", MySqlDbType.Decimal);
                total_venta.Direction = ParameterDirection.Input;
                MySqlParameter imp_venta = cmd.Parameters.Add("imp_venta", MySqlDbType.Decimal);
                imp_venta.Direction = ParameterDirection.Input;
                MySqlParameter imp_desc = cmd.Parameters.Add("imp_desc", MySqlDbType.Decimal);
                imp_desc.Direction = ParameterDirection.Input;
                MySqlParameter cat_venta = cmd.Parameters.Add("cat_venta", MySqlDbType.VarChar, 50);
                cat_venta.Direction = ParameterDirection.Input;
                MySqlParameter nivel_venta = cmd.Parameters.Add("nivel_venta", MySqlDbType.Int32);
                nivel_venta.Direction = ParameterDirection.Input;
                MySqlParameter nota_venta = cmd.Parameters.Add("nota_venta", MySqlDbType.VarChar, 100);
                nota_venta.Direction = ParameterDirection.Input;

                MySqlParameter items_venta = cmd.Parameters.Add("items_venta", MySqlDbType.Text);
                items_venta.Direction = ParameterDirection.Input;

                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                suc_venta.Value = venta.COD_SUC;
                vendedor.Value = venta.COD_EMPLEADO;
                cli_venta.Value = venta.COD_CLIENTE;
                pedido.Value = venta.NUMPEDIDO;
                fecha_venta.Value = venta.FECHA.Date;
                tipo_venta.Value = (int)venta.TIPO;
                num_envio.Value = venta.NUMENVIO;
                plazo_venta.Value = venta.PLAZO_CREDITO;
                plazodesc_venta.Value = venta.PLAZO_CREDITO;
                aplidesc.Value = venta.APLICAR_DESC;
                desc_venta.Value = venta.DESCUENTO;
                total_venta.Value = venta.TOTAL;
                imp_venta.Value = venta.IVA;
                imp_desc.Value = venta.IVA_DESC;
                cat_venta.Value = venta.CATEGORIA.ToString();
                nivel_venta.Value = (int)venta.NIVEL;
                enviodirec.Value = venta.DIRECCION_ENVIO;
                nota_venta.Value = venta.NOTA;

                items_venta.Value = buildItemsVenta(venta);


                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
                MessageBox.Show("VENTA REGISTRADA", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL REGISTRAR VENTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }




        public bool update(Venta venta, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_UPDATE_VENTA";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter idventa = cmd.Parameters.Add("idventa", MySqlDbType.Int32);
                idventa.Direction = ParameterDirection.Input;
                MySqlParameter suc_venta = cmd.Parameters.Add("suc_venta", MySqlDbType.VarChar, 2);
                suc_venta.Direction = ParameterDirection.Input;
                MySqlParameter vendedor = cmd.Parameters.Add("vendedor", MySqlDbType.VarChar, 20);
                vendedor.Direction = ParameterDirection.Input;
                MySqlParameter cli_venta = cmd.Parameters.Add("cli_venta", MySqlDbType.VarChar, 15);
                cli_venta.Direction = ParameterDirection.Input;
                MySqlParameter enviodirec = cmd.Parameters.Add("enviodirec", MySqlDbType.VarChar, 255);
                enviodirec.Direction = ParameterDirection.Input;
                MySqlParameter pedido = cmd.Parameters.Add("pedido", MySqlDbType.VarChar, 20);
                pedido.Direction = ParameterDirection.Input;
                MySqlParameter fecha_venta = cmd.Parameters.Add("fecha_venta", MySqlDbType.Date);
                fecha_venta.Direction = ParameterDirection.Input;
                MySqlParameter tipo_venta = cmd.Parameters.Add("tipo_venta", MySqlDbType.Int32);
                tipo_venta.Direction = ParameterDirection.Input;
                MySqlParameter num_envio = cmd.Parameters.Add("num_envio", MySqlDbType.VarChar, 20);
                num_envio.Direction = ParameterDirection.Input;
                MySqlParameter pago_venta = cmd.Parameters.Add("pago_venta", MySqlDbType.Int32);
                pago_venta.Direction = ParameterDirection.Input;
                MySqlParameter plazo_venta = cmd.Parameters.Add("plazo_venta", MySqlDbType.Int32);
                plazo_venta.Direction = ParameterDirection.Input;
                MySqlParameter plazodesc_venta = cmd.Parameters.Add("plazodesc_venta", MySqlDbType.Int32);
                plazodesc_venta.Direction = ParameterDirection.Input;
                MySqlParameter aplidesc = cmd.Parameters.Add("aplidesc", MySqlDbType.Bit);
                aplidesc.Direction = ParameterDirection.Input;
                MySqlParameter desc_venta = cmd.Parameters.Add("desc_venta", MySqlDbType.Decimal);
                desc_venta.Direction = ParameterDirection.Input;
                MySqlParameter total_venta = cmd.Parameters.Add("total_venta", MySqlDbType.Decimal);
                total_venta.Direction = ParameterDirection.Input;
                MySqlParameter imp_venta = cmd.Parameters.Add("imp_venta", MySqlDbType.Decimal);
                imp_venta.Direction = ParameterDirection.Input;
                MySqlParameter imp_desc = cmd.Parameters.Add("imp_desc", MySqlDbType.Decimal);
                imp_desc.Direction = ParameterDirection.Input;
                MySqlParameter cat_venta = cmd.Parameters.Add("cat_venta", MySqlDbType.VarChar, 50);
                cat_venta.Direction = ParameterDirection.Input;
                MySqlParameter nivel_venta = cmd.Parameters.Add("nivel_venta", MySqlDbType.Int32);
                nivel_venta.Direction = ParameterDirection.Input;
                MySqlParameter nota_venta = cmd.Parameters.Add("nota_venta", MySqlDbType.VarChar, 100);
                nota_venta.Direction = ParameterDirection.Input;

                MySqlParameter items_venta = cmd.Parameters.Add("items_venta", MySqlDbType.Text);
                items_venta.Direction = ParameterDirection.Input;

                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                idventa.Value = venta.ID_VENTA;
                suc_venta.Value = venta.COD_SUC;
                vendedor.Value = venta.COD_EMPLEADO;
                cli_venta.Value = venta.COD_CLIENTE;
                pedido.Value = venta.NUMPEDIDO;
                fecha_venta.Value = venta.FECHA.Date;
                tipo_venta.Value = (int)venta.TIPO;
                num_envio.Value = venta.NUMENVIO;
                plazo_venta.Value = venta.PLAZO_CREDITO;
                plazodesc_venta.Value = venta.PLAZO_CREDITO;
                aplidesc.Value = venta.APLICAR_DESC;
                desc_venta.Value = venta.DESCUENTO;
                total_venta.Value = venta.TOTAL;
                imp_venta.Value = venta.IVA;
                imp_desc.Value = venta.IVA_DESC;
                cat_venta.Value = venta.CATEGORIA.ToString();
                nivel_venta.Value = (int)venta.NIVEL;
                enviodirec.Value = venta.DIRECCION_ENVIO;
                nota_venta.Value = venta.NOTA;

                items_venta.Value = buildItemsVenta(venta);

                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;


                cmd.ExecuteNonQuery();
                MessageBox.Show("VENTA ACTUALIZADA", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ACTUALIZAR VENTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }





        public bool changeDOC(Venta venta,string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_CHANGE_DOC_VENTA";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter idventa = cmd.Parameters.Add("idventa", MySqlDbType.Int32);
                idventa.Direction = ParameterDirection.Input;
                MySqlParameter tipodoc = cmd.Parameters.Add("tipodoc", MySqlDbType.VarChar, 5);
                tipodoc.Direction = ParameterDirection.Input;
                MySqlParameter doc = cmd.Parameters.Add("doc", MySqlDbType.VarChar, 20);
                doc.Direction = ParameterDirection.Input;


                idventa.Value = venta.ID_VENTA;
                tipodoc.Value = venta.TIPO_DOC.ToString();
                doc.Value = venta.DOCUMENTO;



                cmd.ExecuteNonQuery();
                MessageBox.Show("VENTA FACTURADA", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL FACTURAR VENTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }





        public bool changeFOLIO(Venta venta, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_CHANGE_FOLIO_VENTA";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter idventa = cmd.Parameters.Add("idventa", MySqlDbType.Int32);
                idventa.Direction = ParameterDirection.Input;
                MySqlParameter folio = cmd.Parameters.Add("folio", MySqlDbType.VarChar, 20);
                folio.Direction = ParameterDirection.Input;

                idventa.Value = venta.ID_VENTA;
                folio.Value = venta.AEROFLASH;


                cmd.ExecuteNonQuery();
                MessageBox.Show("VENTA ENVIADA POR AEROFLASH", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ENVIAR VENTA POR AEROFLASH", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }





        public bool delete(Venta venta, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_DELETE_VENTA";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter idventa = cmd.Parameters.Add("idventa", MySqlDbType.Int32);
                idventa.Direction = ParameterDirection.Input;

                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                idventa.Value = venta.ID_VENTA;

                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO DE VENTA ELIMINADO", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ELIMINAR VENTA ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }





        public DataTable getItemsVenta(Venta venta)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "karol.SP_GET_ITEMS_VENTA";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter idventa = cmd.Parameters.Add("idventa", MySqlDbType.Int32);
                idventa.Direction = ParameterDirection.Input;

                idventa.Value = venta.ID_VENTA;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL CONSULTAR DETALLE DE VENTA", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }






        public DataTable getItemsFactura(Venta venta)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "karol.SP_GET_ITEMS_FACTURA";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter idventa = cmd.Parameters.Add("idventa", MySqlDbType.Int32);
                idventa.Direction = ParameterDirection.Input;

                idventa.Value = venta.ID_VENTA;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL CONSULTAR DETALLE DE FACTURA", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }





        public string nextNumEnvio(string codsuc)
        {
            string reader = null;
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT karol.FN_NEXT_NUMENVIO(@sucursal)";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                MySqlParameter sucursal = cmd.Parameters.Add("sucursal", MySqlDbType.VarChar, 2);
                sucursal.Direction = ParameterDirection.Input;

                sucursal.Value = codsuc;

                reader = (string)cmd.ExecuteScalar();
            }
            catch (Exception e)
            { reader = null; }
            return reader;
        }




        public DataRow getVentaByNUMENVIO(string numenvio)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            DataRow row = null;
            try
            {
                string sql = "SELECT * FROM karol.view_ventas WHERE NUMENVIO = @envio ORDER BY ID_VENTA DESC;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                MySqlParameter envio = cmd.Parameters.Add("envio", MySqlDbType.VarChar, 20);
                envio.Direction = ParameterDirection.Input;

                envio.Value = numenvio;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL OBTENER VENTA", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (datos.Rows.Count > 0)
            {
                row = datos.Rows[0];
            }
            return row;
        }








    }
}
