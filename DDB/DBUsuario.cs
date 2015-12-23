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

    public class DBUsuario
    {

        private DBConexion conn;


        public DBUsuario()
        {
            conn = DBConexion.Instance();
        }




        public DataRow getUser(string sistema, string usuario)
        {
            MySqlDataReader reader;
            DataTable dt = new DataTable();
            DataRow row = null;
            try
            {
                string sql = "ddicark.SP_GET_USER";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter user = cmd.Parameters.Add("user", MySqlDbType.VarChar, 15);
                user.Direction = ParameterDirection.Input;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                user.Value = usuario;
                sys.Value = sistema;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL OBTENER DATOS DEL USUARIO " + usuario, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dt.Rows.Count == 1)
            {
                row = dt.Rows[0];
            }
            return row;
        }





        public DataTable showUsuarios(string sistema)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "ddicark.SP_SHOW_USUARIOS";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                sys.Value = sistema;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL OBTENER USUARIOS DE " + sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }



        public DataTable showNoUser(string sistema)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "ddicark.SP_SHOW_NO_USER";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;

                sys.Value = sistema;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL OBTENER USUARIOS PERSONAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }






        public bool insert(string sistema, Usuario usuario)
        {
            bool ok = true;
            try
            {
                string sql = "ddicark.SP_INSERT_USUARIO";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;
                MySqlParameter user = cmd.Parameters.Add("user", MySqlDbType.VarChar, 15);
                user.Direction = ParameterDirection.Input;
                MySqlParameter pass = cmd.Parameters.Add("pass", MySqlDbType.VarChar, 32);
                pass.Direction = ParameterDirection.Input;
                MySqlParameter tipo = cmd.Parameters.Add("tipo", MySqlDbType.Int32);
                tipo.Direction = ParameterDirection.Input;
                MySqlParameter activo = cmd.Parameters.Add("ok", MySqlDbType.Bit);
                activo.Direction = ParameterDirection.Input;


                sys.Value = sistema;
                user.Value = usuario.COD_EMPLEADO;
                pass.Value = DBKAROL.md5(usuario.PASSWORD);
                tipo.Value = (int)usuario.TIPO;
                activo.Value = usuario.ACTIVO;


                cmd.ExecuteNonQuery();
                MessageBox.Show("USUARIO REGISTRADO", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                ok = false;
                MessageBox.Show(null, e.Message, "ERROR AL REGISTRAR USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ok;
        }




        public bool update(string sistema, Usuario usuario)
        {
            bool ok = true;
            try
            {
                string sql = "ddicark.SP_UPDATE_USUARIO";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;
                MySqlParameter user = cmd.Parameters.Add("user", MySqlDbType.VarChar, 15);
                user.Direction = ParameterDirection.Input;
                MySqlParameter pass = cmd.Parameters.Add("pass", MySqlDbType.VarChar, 32);
                pass.Direction = ParameterDirection.Input;
                MySqlParameter tipo = cmd.Parameters.Add("tipo", MySqlDbType.Int32);
                tipo.Direction = ParameterDirection.Input;
                MySqlParameter activo = cmd.Parameters.Add("ok", MySqlDbType.Bit);
                activo.Direction = ParameterDirection.Input;


                sys.Value = sistema;
                user.Value = usuario.COD_EMPLEADO;
                pass.Value = DBKAROL.md5(usuario.PASSWORD);
                tipo.Value = (int)usuario.TIPO;
                activo.Value = usuario.ACTIVO;

                cmd.ExecuteNonQuery();
                MessageBox.Show("USUARIO ACTUALIZADO", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                ok = false;
                MessageBox.Show(null, e.Message, "ERROR AL ACTUALIZAR USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ok;
        }




        public bool delete(string sistema, Usuario usuario)
        {
            bool ok = true;
            try
            {
                string sql = "ddicark.SP_DELETE_USUARIO";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;
                MySqlParameter user = cmd.Parameters.Add("user", MySqlDbType.VarChar, 15);
                user.Direction = ParameterDirection.Input;

                sys.Value = sistema;
                user.Value = usuario.COD_EMPLEADO;

                cmd.ExecuteNonQuery();
                MessageBox.Show("USUARIO ELIMINADO", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                ok = false;
                MessageBox.Show(e.Message, "ERROR AL ELIMINAR USUARIO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ok;
        }




        public bool changePassword(string sistema, Usuario usuario, string newPassword)
        {
            bool ok = true;
            try
            {
                string sql = "SELECT ddicark.FN_CHANGE_PASSWORD_USER(@sys,@user,@pass);";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;
                MySqlParameter user = cmd.Parameters.Add("user", MySqlDbType.VarChar, 15);
                user.Direction = ParameterDirection.Input;
                MySqlParameter pass = cmd.Parameters.Add("pass", MySqlDbType.VarChar, 15);
                pass.Direction = ParameterDirection.Input;

                sys.Value = sistema;
                user.Value = usuario.COD_EMPLEADO;
                pass.Value = DBKAROL.md5(newPassword);

                ok = (bool)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                ok = false;
                MessageBox.Show(e.Message, "ERROR AL CAMBIAR PASSWORD DE USUARIO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ok;
        }



        public bool activeChange(string sistema, Usuario usuario)
        {
            bool ok = true;
            try
            {
                string sql = "SELECT ddicark.FN_ACTIVE_CHANGE_USER(@sys,@user);";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.Text;
                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;
                MySqlParameter user = cmd.Parameters.Add("user", MySqlDbType.VarChar, 15);
                user.Direction = ParameterDirection.Input;

                sys.Value = sistema;
                user.Value = usuario.COD_EMPLEADO;

                ok = (bool)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                ok = false;
                MessageBox.Show(e.Message, "ERROR AL CAMBIAR ESTADO DE USUARIO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ok;
        }




        public DataTable getPermisos(string sistema, eTipoUsuario tipoUser)
        {
            MySqlDataReader reader;
            DataTable datos = new DataTable();
            try
            {
                string sql = "ddicark.SP_GET_PERMISOS";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;
                MySqlParameter tipo = cmd.Parameters.Add("tipo", MySqlDbType.Int32);
                tipo.Direction = ParameterDirection.Input;

                sys.Value = sistema;
                tipo.Value = (int)tipoUser;

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    datos.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR AL OBTENER PERMISOS ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return datos;
        }







        public bool setPermisos(string sistema, Permiso permiso)
        {
            bool OK = true;
            try
            {
                string sql = "ddicark.SP_SET_PERMISOS";
                MySqlCommand cmd = new MySqlCommand(sql, conn.conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter sys = cmd.Parameters.Add("sys", MySqlDbType.VarChar, 20);
                sys.Direction = ParameterDirection.Input;
                MySqlParameter tipo = cmd.Parameters.Add("tipoP", MySqlDbType.Int32);
                tipo.Direction = ParameterDirection.Input;
                MySqlParameter codigo = cmd.Parameters.Add("codigoP", MySqlDbType.VarChar, 5);
                codigo.Direction = ParameterDirection.Input;
                MySqlParameter acceso = cmd.Parameters.Add("accesoP", MySqlDbType.Bit);
                acceso.Direction = ParameterDirection.Input;
                MySqlParameter registrar = cmd.Parameters.Add("registrarP", MySqlDbType.Bit);
                registrar.Direction = ParameterDirection.Input;
                MySqlParameter actualizar = cmd.Parameters.Add("actualizarP", MySqlDbType.Bit);
                actualizar.Direction = ParameterDirection.Input;
                MySqlParameter clave = cmd.Parameters.Add("claveP", MySqlDbType.Bit);
                clave.Direction = ParameterDirection.Input;
                MySqlParameter anular = cmd.Parameters.Add("anularP", MySqlDbType.Bit);
                anular.Direction = ParameterDirection.Input;
                MySqlParameter eliminar = cmd.Parameters.Add("eliminarP", MySqlDbType.Bit);
                eliminar.Direction = ParameterDirection.Input;
                MySqlParameter buscar = cmd.Parameters.Add("buscarP", MySqlDbType.Bit);
                buscar.Direction = ParameterDirection.Input;
                MySqlParameter log = cmd.Parameters.Add("logP", MySqlDbType.Bit);
                log.Direction = ParameterDirection.Input;
                MySqlParameter reimprimir = cmd.Parameters.Add("reimprimirP", MySqlDbType.Bit);
                reimprimir.Direction = ParameterDirection.Input;
                MySqlParameter config = cmd.Parameters.Add("configP", MySqlDbType.Bit);
                config.Direction = ParameterDirection.Input;


                sys.Value = sistema;
                tipo.Value = (int)permiso.TIPO_USER;
                codigo.Value = permiso.CODIGO;
                acceso.Value = permiso.ACCESO;
                registrar.Value = permiso.REGISTRAR;
                actualizar.Value = permiso.ACTUALIZAR;
                clave.Value = permiso.CLAVE;
                anular.Value = permiso.ANULAR;
                eliminar.Value = permiso.ELIMINAR;
                buscar.Value = permiso.BUSCAR;
                log.Value = permiso.LOG;
                reimprimir.Value = permiso.REIMPRIMIR;
                config.Value = permiso.CONFIG;


                cmd.ExecuteNonQuery();
                MessageBox.Show("PERMISOS ACTUALIZADOS", "OPERACION FINALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                OK = false;
                MessageBox.Show(null, e.Message, "ERROR AL ACTUALZIAR PERMISOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return OK;
        }


    }
}
