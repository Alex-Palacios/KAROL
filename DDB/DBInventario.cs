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

    public class DBInventario
    {
        private DBConexion conn;

        public DBInventario()
        {
            conn = DBConexion.Instance();
        }


        //FUNCIONES CRUD 
        // PREINGRESO


        private string buildItemsPreingreso(Preingreso pre)
        {
            string items = "";
            foreach (DataRow row in pre.ITEMS.Rows)
            {
                items = items + row.Field<string>("COLOR") + ">"
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
                    + row.Field<int>("T13") + "&";
            }
            return items;
        }






        public bool insertPREINGRESO(Preingreso preingreso, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_INSERT_PREINGRESO";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter crud_pre = cmd.Parameters.Add("crud_pre", MySqlDbType.VarChar, 20);
                crud_pre.Direction = ParameterDirection.Input;
                MySqlParameter como_pre = cmd.Parameters.Add("como_pre", MySqlDbType.Int32);
                como_pre.Direction = ParameterDirection.Input;
                MySqlParameter codigo_pre = cmd.Parameters.Add("codigo_pre", MySqlDbType.VarChar, 50);
                codigo_pre.Direction = ParameterDirection.Input;
                MySqlParameter estilo_pre = cmd.Parameters.Add("estilo_pre", MySqlDbType.VarChar, 20);
                estilo_pre.Direction = ParameterDirection.Input;
                MySqlParameter corrida_pre = cmd.Parameters.Add("corrida_pre", MySqlDbType.VarChar, 1);
                corrida_pre.Direction = ParameterDirection.Input;
                MySqlParameter monto_pre = cmd.Parameters.Add("monto_pre", MySqlDbType.Decimal);
                monto_pre.Direction = ParameterDirection.Input;

                MySqlParameter items_pre = cmd.Parameters.Add("items_pre", MySqlDbType.LongText);
                items_pre.Direction = ParameterDirection.Input;

                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                crud_pre.Value = preingreso.CRUD.ToString();
                como_pre.Value = (int)preingreso.COMO;
                codigo_pre.Value = preingreso.CODIGO;
                estilo_pre.Value = preingreso.ESTILO;
                corrida_pre.Value = preingreso.CORRIDA.ToString();
                monto_pre.Value = preingreso.MONTO;

                items_pre.Value = buildItemsPreingreso(preingreso);

                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL GUARDAR PREINGRESO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }






        public bool deletePREINGRESO(int id, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_DELETE_PREINGRESO";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter idpreingreso = cmd.Parameters.Add("idpreingreso", MySqlDbType.Int32);
                idpreingreso.Direction = ParameterDirection.Input;

                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                idpreingreso.Value = id;

                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ELIMINAR ITEM DE PREINGRESO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }





        public bool limpiarPREINGRESO(eOperacion accion, string empleado)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_CLEAN_PREINGRESO";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter crud_pre = cmd.Parameters.Add("crud_pre", MySqlDbType.VarChar, 20);
                crud_pre.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;

                crud_pre.Value = accion.ToString();
                emp.Value = empleado;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL LIMPIAR PREINGRESO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }






        public DataTable getPREINGRESO(eOperacion accion, string empleado)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "karol.SP_GET_PREINGRESO";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter crud_pre = cmd.Parameters.Add("crud_pre", MySqlDbType.VarChar, 20);
                crud_pre.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;

                crud_pre.Value = accion.ToString();
                emp.Value = empleado;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL OBTENER PREINGRESO", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }




        public DataTable setPREINGRESO(Compra compra, string empleado)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "karol.SP_SET_PREINGRESO";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter idcompra = cmd.Parameters.Add("idcompra", MySqlDbType.Int32);
                idcompra.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;

                idcompra.Value = compra.ID_COMPRA;
                emp.Value = empleado;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL EDITAR DETALLE DE COMPRA", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }





        //INVENTARIO INICIAL

        private string buildItemsImport(DataTable ITEMS)
        {
            string items = "";
            foreach (DataRow row in ITEMS.Rows)
            {
                items = items 
                    + row.Field<string>("CODIGO") + ">"
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
                    + row.Field<decimal>("COSTO") + ">"
                    + row.Field<decimal>("MONTO") + "&";
            }
            return items;
        }



        public bool importInvInit(string bodega,DateTime fecha,DataTable items, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_IMPORT_INV_INICIAL";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter bodega_inv = cmd.Parameters.Add("bodega_inv", MySqlDbType.VarChar,2);
                bodega_inv.Direction = ParameterDirection.Input;
                MySqlParameter fecha_inv = cmd.Parameters.Add("fecha_inv", MySqlDbType.Date);
                fecha_inv.Direction = ParameterDirection.Input;
                MySqlParameter items_inv = cmd.Parameters.Add("items_inv", MySqlDbType.LongText);
                items_inv.Direction = ParameterDirection.Input;


                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                bodega_inv.Value = bodega;
                fecha_inv.Value = fecha;
                items_inv.Value = buildItemsImport(items);

                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
                MessageBox.Show("IMPORTACION DE INVENTARIO INICIAL COMPLETADO", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL IMPORTAR PRODUCTO DE INVENTARIO INICIAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }






        public bool insertInvInit(Preingreso inv, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_INSERT_INV_INICIAL";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter bodega_inv = cmd.Parameters.Add("bodega_inv", MySqlDbType.VarChar, 2);
                bodega_inv.Direction = ParameterDirection.Input;
                MySqlParameter fecha_inv = cmd.Parameters.Add("fecha_inv", MySqlDbType.Date);
                fecha_inv.Direction = ParameterDirection.Input;
                MySqlParameter como_inv = cmd.Parameters.Add("como_inv", MySqlDbType.Int32);
                como_inv.Direction = ParameterDirection.Input;
                MySqlParameter codigo_inv = cmd.Parameters.Add("codigo_inv", MySqlDbType.VarChar, 50);
                codigo_inv.Direction = ParameterDirection.Input;
                MySqlParameter estilo_inv = cmd.Parameters.Add("estilo_inv", MySqlDbType.VarChar, 20);
                estilo_inv.Direction = ParameterDirection.Input;
                MySqlParameter corrida_inv = cmd.Parameters.Add("corrida_inv", MySqlDbType.VarChar, 1);
                corrida_inv.Direction = ParameterDirection.Input;
                MySqlParameter monto_inv = cmd.Parameters.Add("monto_inv", MySqlDbType.Decimal);
                monto_inv.Direction = ParameterDirection.Input;

                MySqlParameter items_inv = cmd.Parameters.Add("items_inv", MySqlDbType.LongText);
                items_inv.Direction = ParameterDirection.Input;

                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;


                bodega_inv.Value = inv.COD_SUC;
                fecha_inv.Value = inv.FECHA_INGRESO;
                como_inv.Value = (int)inv.COMO;
                codigo_inv.Value = inv.CODIGO;
                estilo_inv.Value = inv.ESTILO;
                corrida_inv.Value = inv.CORRIDA.ToString();
                monto_inv.Value = inv.MONTO;

                items_inv.Value = buildItemsPreingreso(inv);

                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
                MessageBox.Show("PRODUCTO REGISTRADO EN INVENTARIO INICIAL", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL REGISTRAR PRODUCTO EN INVENTARIO INICIAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }




        public bool updateInvInit(Preingreso inv, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_UPDATE_INV_INICIAL";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;


                MySqlParameter idmov = cmd.Parameters.Add("idmov", MySqlDbType.Int32);
                idmov.Direction = ParameterDirection.Input;
                MySqlParameter fecha_inv = cmd.Parameters.Add("fecha_inv", MySqlDbType.Date);
                fecha_inv.Direction = ParameterDirection.Input;
                MySqlParameter estilo_inv = cmd.Parameters.Add("estilo_inv", MySqlDbType.VarChar, 20);
                estilo_inv.Direction = ParameterDirection.Input;
                MySqlParameter corrida_inv = cmd.Parameters.Add("corrida_inv", MySqlDbType.VarChar, 1);
                corrida_inv.Direction = ParameterDirection.Input;
                MySqlParameter monto_inv = cmd.Parameters.Add("monto_inv", MySqlDbType.Decimal);
                monto_inv.Direction = ParameterDirection.Input;

                MySqlParameter items_inv = cmd.Parameters.Add("items_inv", MySqlDbType.LongText);
                items_inv.Direction = ParameterDirection.Input;

                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                idmov.Value = inv.ID;
                fecha_inv.Value = inv.FECHA_INGRESO;
                estilo_inv.Value = inv.ESTILO;
                corrida_inv.Value = inv.CORRIDA.ToString();
                monto_inv.Value = inv.MONTO;

                items_inv.Value = buildItemsPreingreso(inv);

                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
                MessageBox.Show("PRODUCTO ACTUALIZADO DE INVENTARIO INICIAL", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ACTUALIZAR PRODUCTO DE INVENTARIO INICIAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }




        public bool deleteInvInit(int id, string sucursal, string empleado, string sistema)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_DELETE_INV_INICIAL";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;


                MySqlParameter idmov = cmd.Parameters.Add("idmov", MySqlDbType.Int32);
                idmov.Direction = ParameterDirection.Input;


                MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
                suc.Direction = ParameterDirection.Input;
                MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
                emp.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                idmov.Value = id;

                suc.Value = sucursal;
                emp.Value = empleado;
                sys.Value = sistema;

                cmd.ExecuteNonQuery();
                MessageBox.Show("PRODUCTO ELIMINADO DE INVENTARIO INICIAL", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ELIMINAR PRODUCTO DE INVENTARIO INICIAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }








        public DataTable getItemInv(int id)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "karol.SP_GET_ITEM_INV";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;


                MySqlParameter idmov = cmd.Parameters.Add("idmov", MySqlDbType.Int32);
                idmov.Direction = ParameterDirection.Input;


                idmov.Value = id;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL CONSULTAR INVENTARIO INICIAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }



        public DataTable showInvInicial()
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT * FROM karol.view_inv_inicial;";
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
                MessageBox.Show(e.Message, "ERROR AL CONSULTAR INVENTARIO INICIAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }

















        //EXISTENCIAS


        //public bool updateArticuloInv(Existencia exist, string sucursal, string empleado, string sistema)
        //{
        //    bool OK = true;
        //    try
        //    {
        //        string sql = "prendasal.SP_UPDATE_ARTICULO_INV";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter cod_inv = cmd.Parameters.Add("cod_inv", MySqlDbType.VarChar, 50);
        //        cod_inv.Direction = ParameterDirection.Input;
        //        MySqlParameter suc_inv = cmd.Parameters.Add("suc_inv", MySqlDbType.VarChar, 2);
        //        suc_inv.Direction = ParameterDirection.Input;
        //        MySqlParameter item_inv = cmd.Parameters.Add("item_inv", MySqlDbType.VarChar, 20);
        //        item_inv.Direction = ParameterDirection.Input;
        //        MySqlParameter descrip_inv = cmd.Parameters.Add("descrip_inv", MySqlDbType.VarChar, 100);
        //        descrip_inv.Direction = ParameterDirection.Input;
        //        MySqlParameter precio_inv = cmd.Parameters.Add("precio_inv", MySqlDbType.Decimal);
        //        precio_inv.Direction = ParameterDirection.Input;
        //        MySqlParameter nota_inv = cmd.Parameters.Add("nota_inv", MySqlDbType.VarChar, 100);
        //        nota_inv.Direction = ParameterDirection.Input;

        //        MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
        //        suc.Direction = ParameterDirection.Input;
        //        MySqlParameter emp = cmd.Parameters.Add("emp", MySqlDbType.VarChar, 15);
        //        emp.Direction = ParameterDirection.Input;
        //        MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
        //        sys.Direction = ParameterDirection.Input;

        //        cod_inv.Value = exist.CODIGO;
        //        suc_inv.Value = exist.BODEGA;
        //        item_inv.Value = exist.COD_ITEM;
        //        descrip_inv.Value = exist.DESCRIPCION;
        //        precio_inv.Value = exist.PRECIO;
        //        nota_inv.Value = exist.NOTA;

        //        suc.Value = sucursal;
        //        emp.Value = empleado;
        //        sys.Value = sistema;

        //        cmd.ExecuteNonQuery();
        //        MessageBox.Show("ARTICULO ACTUALIZADO", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception e)
        //    {
        //        OK = false;
        //        MessageBox.Show(e.Message, "ERROR AL ACTUALIZAR ARTICULO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return OK;
        //}





        //public DataTable getExistenciasORO()
        //{
        //    MySqlDataReader reader;
        //    DataTable datos = new DataTable();
        //    try
        //    {
        //        string sql = "SELECT * FROM prendasal.view_inv_oro;";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
        //        cmd.CommandType = CommandType.Text;

        //        reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            datos.Load(reader);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "ERROR AL CONSULTAR EXISTENCIAS DE ORO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return datos;
        //}




        //public DataTable getExistenciasARTICULOSbySuc(string sucursal)
        //{
        //    MySqlDataReader reader;
        //    DataTable datos = new DataTable();
        //    try
        //    {
        //        string sql = string.Empty;
        //        if (sucursal == "00")
        //        {
        //            sql = "SELECT * FROM prendasal.view_inv_articulos;";
        //        }
        //        else
        //        {
        //            sql = "SELECT * FROM prendasal.view_inv_articulos WHERE BODEGA = @suc";
        //        }
        //        MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
        //        cmd.CommandType = CommandType.Text;
        //        MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
        //        suc.Direction = ParameterDirection.Input;

        //        suc.Value = sucursal;

        //        reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            datos.Load(reader);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "ERROR AL CONSULTAR EXISTENCIAS DE ARTICULOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return datos;
        //}








        //public DataTable getExistenciasARTICULOS(string sucursal, string articulo)
        //{
        //    MySqlDataReader reader;
        //    DataTable datos = new DataTable();
        //    try
        //    {
        //        string sql = "SELECT * FROM prendasal.view_inv_articulos WHERE 1=1 ";
        //        if (sucursal != "00")
        //        {
        //            sql = sql + "AND BODEGA = @suc ";
        //        }
        //        if (articulo != "TODAS")
        //        {
        //            sql = sql + "AND COD_ITEM LIKE @item ";
        //        }
        //        sql = sql + "ORDER BY CODIGO;";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
        //        cmd.CommandType = CommandType.Text;
        //        MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
        //        suc.Direction = ParameterDirection.Input;
        //        MySqlParameter item = cmd.Parameters.Add("item", MySqlDbType.VarChar, 20);
        //        item.Direction = ParameterDirection.Input;

        //        suc.Value = sucursal;
        //        item.Value = articulo;

        //        reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            datos.Load(reader);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "ERROR AL CONSULTAR EXISTENCIAS DE ARTICULOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return datos;
        //}





        //public DataTable getExistenciasARTICULOSbyCodigo(string codigo)
        //{
        //    MySqlDataReader reader;
        //    DataTable datos = new DataTable();
        //    try
        //    {
        //        string sql = "SELECT * FROM prendasal.view_inv_articulos WHERE CODIGO LIKE @cod";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
        //        cmd.CommandType = CommandType.Text;
        //        MySqlParameter cod = cmd.Parameters.Add("cod", MySqlDbType.VarChar, 25);
        //        cod.Direction = ParameterDirection.Input;

        //        cod.Value = codigo + "%";

        //        reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            datos.Load(reader);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "ERROR AL CONSULTAR EXISTENCIAS DE ARTICULOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return datos;
        //}












        // ENVIOS

        //public DataTable getInvCustodia(string sucursal, string categoria, string articulo)
        //{
        //    MySqlDataReader reader;
        //    DataTable datos = new DataTable();
        //    try
        //    {
        //        string sql = "SELECT * FROM prendasal.view_inv_custodia WHERE 1=1 ";
        //        if (sucursal != "00")
        //        {
        //            sql = sql + "AND BODEGA = @suc ";
        //        }
        //        if (categoria != "TODAS")
        //        {
        //            sql = sql + "AND CATEGORIA = @cat ";
        //        }
        //        if (articulo != "TODAS")
        //        {
        //            sql = sql + "AND COD_ITEM = @item ";
        //        }
        //        sql = sql + "ORDER BY CATEGORIA,CONTRATO;";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
        //        cmd.CommandType = CommandType.Text;
        //        MySqlParameter suc = cmd.Parameters.Add("suc", MySqlDbType.VarChar, 2);
        //        suc.Direction = ParameterDirection.Input;
        //        MySqlParameter cat = cmd.Parameters.Add("cat", MySqlDbType.VarChar, 2);
        //        cat.Direction = ParameterDirection.Input;
        //        MySqlParameter item = cmd.Parameters.Add("item", MySqlDbType.VarChar, 2);
        //        item.Direction = ParameterDirection.Input;

        //        suc.Value = sucursal;
        //        cat.Value = categoria;
        //        item.Value = articulo;

        //        reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            datos.Load(reader);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "ERROR AL CONSULTAR INVENTARIO EN CUSTODIA PRENDASAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return datos;
        //}





        //public DataTable getInvCustodia(string codigo)
        //{
        //    MySqlDataReader reader;
        //    DataTable datos = new DataTable();
        //    try
        //    {
        //        string sql = "SELECT * FROM prendasal.view_inv_custodia WHERE CONTRATO LIKE @contrato;";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
        //        cmd.CommandType = CommandType.Text;
        //        MySqlParameter contrato = cmd.Parameters.Add("contrato", MySqlDbType.VarChar, 25);
        //        contrato.Direction = ParameterDirection.Input;

        //        contrato.Value = codigo + "%";

        //        reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            datos.Load(reader);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "ERROR AL CONSULTAR EXISTENCIAS PRENDASAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return datos;
        //}















    }
}
