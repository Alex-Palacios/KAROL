using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    using System.Data;

    public class Proveedor
    {

        public string COD_PROVEEDOR;
        public DateTime FECHA_INICIO;
        public eNaturalezaPersona NATURALEZA;
        public string NOMBRE;
        public string DUI;
        public string NIT;
        public string NRC;
        public string TEL;
        public string EMAIL;
        public string PAIS;
        public string DIRECCION;
        public string CONTACTO;
        public string TEL_CONTACTO;
        public string NOTA;

        
        public Proveedor()
        {
            
        }


        public static Proveedor ConvertToProveedor(DataRow dr)
        {
            Proveedor pro = new Proveedor();
            if (dr != null)
            {
                if (dr.Table.Columns.Contains("COD_PROVEEDOR")) { pro.COD_PROVEEDOR = dr.Field<string>("COD_PROVEEDOR"); }
                if (dr.Table.Columns.Contains("FECHA_INICIO")) { pro.FECHA_INICIO = dr.Field<DateTime>("FECHA_INICIO"); }
                if (dr.Table.Columns.Contains("NATURALEZA")) { pro.NATURALEZA = (eNaturalezaPersona)Enum.Parse(typeof(eNaturalezaPersona), dr.Field<string>("NATURALEZA")); }
                if (dr.Table.Columns.Contains("NOMBRE")) { pro.NOMBRE = dr.Field<string>("NOMBRE"); }
                if (dr.Table.Columns.Contains("DUI")) { pro.DUI = dr.Field<string>("DUI"); }
                if (dr.Table.Columns.Contains("NIT")) { pro.NIT = dr.Field<string>("NIT"); }
                if (dr.Table.Columns.Contains("NRC")) { pro.NRC = dr.Field<string>("NRC"); }
                if (dr.Table.Columns.Contains("TEL")) { pro.TEL = dr.Field<string>("TEL"); }
                if (dr.Table.Columns.Contains("EMAIL")) { pro.EMAIL = dr.Field<string>("EMAIL"); }
                if (dr.Table.Columns.Contains("PAIS")) { pro.PAIS = dr.Field<string>("PAIS"); }
                if (dr.Table.Columns.Contains("DIRECCION")) { pro.DIRECCION = dr.Field<string>("DIRECCION"); }
                if (dr.Table.Columns.Contains("CONTACTO")) { pro.CONTACTO = dr.Field<string>("CONTACTO"); }
                if (dr.Table.Columns.Contains("TEL_CONTACTO")) { pro.TEL_CONTACTO = dr.Field<string>("TEL_CONTACTO"); }
                if (dr.Table.Columns.Contains("NOTA")) { pro.NOTA = dr.Field<string>("NOTA"); }

            }
            return pro;
        }


        public Proveedor Copy()
        {
            Proveedor copy = (Proveedor)this.MemberwiseClone();
            return copy;
        }



    }

}
