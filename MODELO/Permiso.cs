using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    using System.Data;

    public class Permiso
    {

        public int ID;
        public eTipoUsuario TIPO_USER;
        public string CODIGO;
        public string MODULO;
        public string MENU;
        public bool ACCESO;
        public bool REGISTRAR;
        public bool ACTUALIZAR;
        public bool CLAVE;
        public bool ANULAR;
        public bool ELIMINAR;
        public bool BUSCAR;
        public bool LOG;
        public bool REIMPRIMIR;
        public bool CONFIG;


        public Permiso()
        {

        }



        public static Permiso ConvertToPermiso(DataRow dr)
        {
            Permiso permiso = null;
            if (dr != null)
            {
                permiso = new Permiso();

                if (dr.Table.Columns.Contains("ID")) { permiso.ID = dr.Field<int>("ID"); }
                if (dr.Table.Columns.Contains("TIPO_USER")) { permiso.TIPO_USER = (eTipoUsuario)dr.Field<int>("TIPO_USER"); }
                if (dr.Table.Columns.Contains("CODIGO")) { permiso.CODIGO = dr.Field<string>("CODIGO"); }
                if (dr.Table.Columns.Contains("MODULO")) { permiso.MODULO = dr.Field<string>("MODULO"); }
                if (dr.Table.Columns.Contains("MENU")) { permiso.MENU = dr.Field<string>("MENU"); }
                if (dr.Table.Columns.Contains("ACCESO")) { permiso.ACCESO = dr.Field<bool>("ACCESO"); }
                if (dr.Table.Columns.Contains("REGISTRAR")) { permiso.REGISTRAR = dr.Field<bool>("REGISTRAR"); }
                if (dr.Table.Columns.Contains("ACTUALIZAR")) { permiso.ACTUALIZAR = dr.Field<bool>("ACTUALIZAR"); }
                if (dr.Table.Columns.Contains("ELIMINAR")) { permiso.ELIMINAR = dr.Field<bool>("ELIMINAR"); }
                if (dr.Table.Columns.Contains("CLAVE")) { permiso.CLAVE = dr.Field<bool>("CLAVE"); }
                if (dr.Table.Columns.Contains("ANULAR")) { permiso.ANULAR = dr.Field<bool>("ANULAR"); }
                if (dr.Table.Columns.Contains("BUSCAR")) { permiso.BUSCAR = dr.Field<bool>("BUSCAR"); }
                if (dr.Table.Columns.Contains("CONFIG")) { permiso.CONFIG = dr.Field<bool>("CONFIG"); }
                if (dr.Table.Columns.Contains("LOG")) { permiso.LOG = dr.Field<bool>("LOG"); }
                if (dr.Table.Columns.Contains("REIMPRIMIR")) { permiso.REIMPRIMIR = dr.Field<bool>("REIMPRIMIR"); }

            }
            return permiso;

        }
    }
}
