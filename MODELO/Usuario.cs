using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    using System.Data;

    

    public class Usuario
    {
        public string COD_EMPLEADO;
        public string NOMBRE;
        public string PASSWORD;
        public eTipoUsuario TIPO;
        public bool ACTIVO;

        public DataTable PERMISOS;

        public Usuario()
        {

        }


        public static Usuario ConvertToUsuario(DataRow dr)
        {
            Usuario user = null;
            if (dr != null)
            {
                user = new Usuario();
                if (dr.Table.Columns.Contains("COD_EMPLEADO")) { user.COD_EMPLEADO = dr.Field<string>("COD_EMPLEADO"); }
                if (dr.Table.Columns.Contains("NOMBRE")) { user.NOMBRE = dr.Field<string>("NOMBRE"); }
                if (dr.Table.Columns.Contains("PASSWORD")) { user.PASSWORD = dr.Field<string>("PASSWORD"); }
                if (dr.Table.Columns.Contains("TIPO_USER")) { user.TIPO = (eTipoUsuario)dr.Field<int>("TIPO_USER"); }
                if (dr.Table.Columns.Contains("ACTIVO")) { user.ACTIVO = dr.Field<bool>("ACTIVO"); }
            }
            return user;

        }


    }

}
