using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB
{
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;
    using System.Data;

    public class DBConexion
    {
        //PARA MANTENER UNA INSTANCIA UNICA DE LA CLASE//
        private static DBConexion frmInstance = null;

        public static DBConexion Instance()
        {
            if (frmInstance == null)
            {
                frmInstance = new DBConexion();
            }
            return frmInstance;
        }

        public string driver;
        public string server;
        public string puerto;
        public string database;
        public string usuarioDB;
        public string password;
        public MySqlConnection conn;

        public DBConexion()
        {

        }

        public MySqlConnection conection
        {
            get
            {
                startConection();
                return this.conn;
            }
        }



        public DBConexion(string driver, string server, string port, string db, string user, string password)
        {
            this.server = server;
            this.puerto = port;
            this.database = db;
            this.usuarioDB = user;
            this.password = password;
            this.conn = new MySqlConnection("server=" + server + ";port=" + puerto + ";database=" + database + ";userid=" + usuarioDB + ";password=" + password + ";");
            frmInstance = this;
        }


        private void startConection()
        {
            // Iniciamos la conexión si no existe o si esta cerrada...
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                if (conn.Ping())
                {
                    MessageBox.Show("SE PERDIO LA CONEXION AL SERVIDOR", "Conexion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("ERROR AL CONECTAR A LA DB: \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }


        private void Conexion()
        {

        }


    }
}
