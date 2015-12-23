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

    public class DBProveedor
    {
        private DBConexion conn;

        public DBProveedor()
        {
            conn = DBConexion.Instance();
        }



        public bool insert(Proveedor proveedor, string suc, string emp, string sys)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_INSERT_PROVEEDOR";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter fechaI = cmd.Parameters.Add("fechaI", MySqlDbType.Date);
                fechaI.Direction = ParameterDirection.Input;
                MySqlParameter naturalezaPro = cmd.Parameters.Add("naturalezaPro", MySqlDbType.VarChar, 20);
                naturalezaPro.Direction = ParameterDirection.Input;
                MySqlParameter nombrePro = cmd.Parameters.Add("nombrePro", MySqlDbType.VarChar, 100);
                nombrePro.Direction = ParameterDirection.Input;
                MySqlParameter duiPro = cmd.Parameters.Add("duiPro", MySqlDbType.VarChar, 10);
                duiPro.Direction = ParameterDirection.Input;
                MySqlParameter nitPro = cmd.Parameters.Add("nitPro", MySqlDbType.VarChar, 17);
                nitPro.Direction = ParameterDirection.Input;
                MySqlParameter nrcPro = cmd.Parameters.Add("nrcPro", MySqlDbType.VarChar, 50);
                nrcPro.Direction = ParameterDirection.Input;
                MySqlParameter telPro = cmd.Parameters.Add("telPro", MySqlDbType.VarChar, 20);
                telPro.Direction = ParameterDirection.Input;
                MySqlParameter emailPro = cmd.Parameters.Add("emailPro", MySqlDbType.VarChar, 50);
                emailPro.Direction = ParameterDirection.Input;
                MySqlParameter paisPro = cmd.Parameters.Add("paisPro", MySqlDbType.VarChar, 50);
                paisPro.Direction = ParameterDirection.Input;
                MySqlParameter direccionPro = cmd.Parameters.Add("direccionPro", MySqlDbType.VarChar, 255);
                direccionPro.Direction = ParameterDirection.Input;
                MySqlParameter contactoPro = cmd.Parameters.Add("contactoPro", MySqlDbType.VarChar, 100);
                contactoPro.Direction = ParameterDirection.Input;
                MySqlParameter telContactoPro = cmd.Parameters.Add("telContactoPro", MySqlDbType.VarChar, 20);
                telContactoPro.Direction = ParameterDirection.Input;
                MySqlParameter notaPro = cmd.Parameters.Add("notaPro", MySqlDbType.VarChar, 255);
                notaPro.Direction = ParameterDirection.Input;

                MySqlParameter sucursal = cmd.Parameters.Add("sucursal", MySqlDbType.VarChar, 2);
                sucursal.Direction = ParameterDirection.Input;
                MySqlParameter empleado = cmd.Parameters.Add("empleado", MySqlDbType.VarChar, 15);
                empleado.Direction = ParameterDirection.Input;
                MySqlParameter system = cmd.Parameters.Add("sistema", MySqlDbType.VarChar, 20);
                system.Direction = ParameterDirection.Input;

                fechaI.Value = proveedor.FECHA_INICIO;
                naturalezaPro.Value = proveedor.NATURALEZA.ToString();
                nombrePro.Value = proveedor.NOMBRE;
                duiPro.Value = proveedor.DUI;
                nitPro.Value = proveedor.NIT;
                nrcPro.Value = proveedor.NRC;
                telPro.Value = proveedor.TEL;
                emailPro.Value = proveedor.EMAIL;
                paisPro.Value = proveedor.PAIS;
                direccionPro.Value = proveedor.DIRECCION;
                contactoPro.Value = proveedor.CONTACTO;
                telContactoPro.Value = proveedor.TEL_CONTACTO;
                notaPro.Value = proveedor.NOTA;

                sucursal.Value = suc;
                empleado.Value = emp;
                system.Value = sys;

                cmd.ExecuteNonQuery();
                MessageBox.Show("PROVEEDOR REGISTRADO", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL REGISTRAR PROVEEDOR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }



        public bool update(Proveedor proveedor, string suc, string emp, string sys)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_UPDATE_PROVEEDOR";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter codigo = cmd.Parameters.Add("codigo", MySqlDbType.VarChar, 15);
                codigo.Direction = ParameterDirection.Input;
                MySqlParameter naturalezaPro = cmd.Parameters.Add("naturalezaPro", MySqlDbType.VarChar, 20);
                naturalezaPro.Direction = ParameterDirection.Input;
                MySqlParameter nombrePro = cmd.Parameters.Add("nombrePro", MySqlDbType.VarChar, 100);
                nombrePro.Direction = ParameterDirection.Input;
                MySqlParameter duiPro = cmd.Parameters.Add("duiPro", MySqlDbType.VarChar, 10);
                duiPro.Direction = ParameterDirection.Input;
                MySqlParameter nitPro = cmd.Parameters.Add("nitPro", MySqlDbType.VarChar, 17);
                nitPro.Direction = ParameterDirection.Input;
                MySqlParameter nrcPro = cmd.Parameters.Add("nrcPro", MySqlDbType.VarChar, 50);
                nrcPro.Direction = ParameterDirection.Input;
                MySqlParameter telPro = cmd.Parameters.Add("telPro", MySqlDbType.VarChar, 20);
                telPro.Direction = ParameterDirection.Input;
                MySqlParameter emailPro = cmd.Parameters.Add("emailPro", MySqlDbType.VarChar, 50);
                emailPro.Direction = ParameterDirection.Input;
                MySqlParameter paisPro = cmd.Parameters.Add("paisPro", MySqlDbType.VarChar, 50);
                paisPro.Direction = ParameterDirection.Input;
                MySqlParameter direccionPro = cmd.Parameters.Add("direccionPro", MySqlDbType.VarChar, 255);
                direccionPro.Direction = ParameterDirection.Input;
                MySqlParameter contactoPro = cmd.Parameters.Add("contactoPro", MySqlDbType.VarChar, 100);
                contactoPro.Direction = ParameterDirection.Input;
                MySqlParameter telContactoPro = cmd.Parameters.Add("telContactoPro", MySqlDbType.VarChar, 20);
                telContactoPro.Direction = ParameterDirection.Input;
                MySqlParameter notaPro = cmd.Parameters.Add("notaPro", MySqlDbType.VarChar, 255);
                notaPro.Direction = ParameterDirection.Input;

                MySqlParameter sucursal = cmd.Parameters.Add("sucursal", MySqlDbType.VarChar, 2);
                sucursal.Direction = ParameterDirection.Input;
                MySqlParameter empleado = cmd.Parameters.Add("empleado", MySqlDbType.VarChar, 15);
                empleado.Direction = ParameterDirection.Input;
                MySqlParameter system = cmd.Parameters.Add("sistema", MySqlDbType.VarChar, 20);
                system.Direction = ParameterDirection.Input;

                codigo.Value = proveedor.COD_PROVEEDOR;
                naturalezaPro.Value = proveedor.NATURALEZA.ToString();
                nombrePro.Value = proveedor.NOMBRE;
                duiPro.Value = proveedor.DUI;
                nitPro.Value = proveedor.NIT;
                nrcPro.Value = proveedor.NRC;
                telPro.Value = proveedor.TEL;
                emailPro.Value = proveedor.EMAIL;
                paisPro.Value = proveedor.PAIS;
                direccionPro.Value = proveedor.DIRECCION;
                contactoPro.Value = proveedor.CONTACTO;
                telContactoPro.Value = proveedor.TEL_CONTACTO;
                notaPro.Value = proveedor.NOTA;

                sucursal.Value = suc;
                empleado.Value = emp;
                system.Value = sys;

                cmd.ExecuteNonQuery();
                MessageBox.Show("DATOS DE PROVEEDOR ACTUALIZADOS", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ACTUALIZAR PROVEEDOR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }




        public bool delete(string proveedor, string suc, string emp, string sys)
        {
            bool OK = true;
            try
            {
                string sql = "karol.SP_DELETE_PROVEEDOR";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter codigo = cmd.Parameters.Add("codigo", MySqlDbType.VarChar, 15);
                codigo.Direction = ParameterDirection.Input;

                MySqlParameter sucursal = cmd.Parameters.Add("sucursal", MySqlDbType.VarChar, 2);
                sucursal.Direction = ParameterDirection.Input;
                MySqlParameter empleado = cmd.Parameters.Add("empleado", MySqlDbType.VarChar, 15);
                empleado.Direction = ParameterDirection.Input;
                MySqlParameter system = cmd.Parameters.Add("sistema", MySqlDbType.VarChar, 20);
                system.Direction = ParameterDirection.Input;


                codigo.Value = proveedor;

                sucursal.Value = suc;
                empleado.Value = emp;
                system.Value = sys;

                cmd.ExecuteNonQuery();
                MessageBox.Show("PROVEEDOR : " + proveedor + " ELIMINADO DE LA CARTERA", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(e.Message, "ERROR AL ELIMINAR PROVEEDOR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }





        public DataTable showProveedores()
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT * FROM karol.view_proveedores;";
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
                MessageBox.Show("NO SE PUDO CONSULTAR LA CARTERA DE PROVEEDORES", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }



        public DataRow findByCodigo(string codigo)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            DataRow row = null;
            try
            {
                string sql = "SELECT * FROM karol.view_proveedores WHERE COD_PROVEEDOR = @cod;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                MySqlParameter cod = cmd.Parameters.Add("cod", MySqlDbType.VarChar, 15);
                cod.Direction = ParameterDirection.Input;
                cod.Value = codigo + "%";

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL FILTRAR PROVEEDORES\n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (datos.Rows.Count == 1)
            {
                row = datos.Rows[0];
            }
            return row;
        }




        public DataTable findByFechaInicio(DateTime fechaI)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT * FROM karol.view_proveedores WHERE FECHA_INICIO = @fecha;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                MySqlParameter fecha = cmd.Parameters.Add("fecha", MySqlDbType.Date);
                fecha.Direction = ParameterDirection.Input;

                fecha.Value = fechaI.Date;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("NO SE PUDO CONSULTAR PROVEEDORES NUEVOS\n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }



        public DataRow findByDui(string doc)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            DataRow row = null;
            try
            {
                if (doc != null && doc != string.Empty)
                {
                    string sql = "SELECT * FROM karol.view_proveedores WHERE DUI = @dui;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                    cmd.CommandType = CommandType.Text;

                    MySqlParameter dui = cmd.Parameters.Add("dui", MySqlDbType.VarChar, 10);
                    dui.Direction = ParameterDirection.Input;
                    dui.Value = doc;

                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        datos.Load(reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL OBTENER PROVEEDOR", "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (datos.Rows.Count == 1)
            {
                row = datos.Rows[0];
            }
            return row;
        }








        public DataTable findByNombreLIKE(string nombre)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT * FROM karol.view_proveedores WHERE NOMBRE LIKE @proveedor;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                MySqlParameter proveedor = cmd.Parameters.Add("proveedor", MySqlDbType.VarChar, 100);
                proveedor.Direction = ParameterDirection.Input;
                proveedor.Value = "%" + nombre + "%";

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL FILTRAR PROVEEDORS\n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }


        public DataTable findByCodigoLIKE(string codigo)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT * FROM karol.view_proveedores WHERE COD_PROVEEDOR LIKE @codigo;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                MySqlParameter cod = cmd.Parameters.Add("codigo", MySqlDbType.VarChar, 15);
                cod.Direction = ParameterDirection.Input;
                cod.Value = codigo + "%";

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL FILTRAR PROVEEDORES\n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return datos;
        }



        public DataTable findByDuiLIKE(string doc)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT * FROM karol.view_proveedores WHERE DUI LIKE @dui;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                MySqlParameter dui = cmd.Parameters.Add("dui", MySqlDbType.VarChar, 10);
                dui.Direction = ParameterDirection.Input;
                dui.Value = doc + "%";

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL FILTRAR PROVEEDORES\n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }


        public DataTable findByNitLIKE(string doc)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT * FROM karol.view_proveedores WHERE NIT LIKE @dui;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                MySqlParameter dui = cmd.Parameters.Add("dui", MySqlDbType.VarChar, 10);
                dui.Direction = ParameterDirection.Input;
                dui.Value = doc + "%";

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL FILTRAR PROVEEDORES\n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }



        public DataTable findByNrcLIKE(string doc)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "SELECT * FROM karol.view_proveedores WHERE NRC LIKE @doc;";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;

                MySqlParameter nrc = cmd.Parameters.Add("doc", MySqlDbType.VarChar, 10);
                nrc.Direction = ParameterDirection.Input;
                nrc.Value = doc + "%";

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL FILTRAR PROVEEDORES\n" + e.Message, "ERROR EN CONSULTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }
        








    }
}
