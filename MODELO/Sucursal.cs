using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    using System.Data;

    public class Sucursal
    {
        //VARIABLES DB
        public string COD_SUC;
        public string SUCURSAL;
        public string TEL;
        public string COD_MUNICIPIO;
        public string DIRECCION;
        public bool ACTIVA;

        //VARIABLES AUX
        public string DEPTO;
        public string MUNICIPIO;

        public string IP;
        public string HOSTNAME;
        public GlobalFechaSistema FECHA_SISTEMA;

        public Sucursal()
        {

        }

        public static Sucursal ConverterToSucursal(DataRow dr)
        {
            Sucursal suc = null;
            if (dr != null)
            {
                suc = new Sucursal();
                if (dr.Table.Columns.Contains("COD_SUC")) { suc.COD_SUC = dr.Field<string>("COD_SUC"); }
                if (dr.Table.Columns.Contains("SUCURSAL")) { suc.SUCURSAL = dr.Field<string>("SUCURSAL"); }
                if (dr.Table.Columns.Contains("TEL")) { suc.TEL = dr.Field<string>("TEL"); }
                if (dr.Table.Columns.Contains("COD_MUNICIPIO")) { suc.COD_MUNICIPIO = dr.Field<string>("COD_MUNICIPIO"); }
                if (dr.Table.Columns.Contains("DEPTO")) { suc.DEPTO = dr.Field<string>("DEPTO"); }
                if (dr.Table.Columns.Contains("MUNICIPIO")) { suc.MUNICIPIO = dr.Field<string>("MUNICIPIO"); }
                if (dr.Table.Columns.Contains("DIRECCION")) { suc.DIRECCION = dr.Field<string>("DIRECCION"); }
                if (dr.Table.Columns.Contains("ACTIVA")) { suc.ACTIVA = dr.Field<bool>("ACTIVA"); }

                if (dr.Table.Columns.Contains("IP")) { suc.IP = dr.Field<string>("IP"); }
                if (dr.Table.Columns.Contains("HOSTNAME")) { suc.HOSTNAME = dr.Field<string>("HOSTNAME"); }
                if (dr.Table.Columns.Contains("FECHA_SISTEMA")) { suc.FECHA_SISTEMA = (GlobalFechaSistema)dr.Field<int>("FECHA_SISTEMA"); }
            }
            return suc;
        }


        public Sucursal Copy()
        {
            return (Sucursal)this.MemberwiseClone();
        }

    }
}