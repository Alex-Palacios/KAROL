using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    using System.Data;

    public class Cliente
    {

        public string COD_CLIENTE;
        public DateTime FECHA_INICIO;
        public eNaturalezaPersona NATURALEZA;
        public string NOMBRE;
        public eSexo SEXO;
        public DateTime? FECHA_NAC;
        public string NIT;
        public string DUI;
        public string EXT;
        public DateTime? FECHA_VENC;
        public string NRC;
        public string TEL;
        public string EMAIL;
        public string PROFESION;
        public string COD_MUNICIPIO;
        public string DIRECCION;
        public string DIRECCION_OPCIONAL;
        public string NEGOCIO;
        public string TEL_NEGOCIO;
        public string DIRECCION_NEGOCIO;
        public string NOTA;

        public string EXTENDIDO;
        public Int64? EDAD;  
        public string DEPTO;
        public string DOMICILIO;

        public decimal LIMITE_CREDITO;
        public decimal CREDITO_DISPONIBLE;


        public Cliente()
        {
            
        }


        public static Cliente ConvertToCliente(DataRow dr)
        {
            Cliente cli = new Cliente();
            if (dr != null)
            {
                if (dr.Table.Columns.Contains("COD_CLIENTE")) { cli.COD_CLIENTE = dr.Field<string>("COD_CLIENTE"); }
                if (dr.Table.Columns.Contains("FECHA_INICIO")) { cli.FECHA_INICIO = dr.Field<DateTime>("FECHA_INICIO"); }
                if (dr.Table.Columns.Contains("NATURALEZA")) { cli.NATURALEZA = (eNaturalezaPersona)Enum.Parse(typeof(eNaturalezaPersona), dr.Field<string>("NATURALEZA")); }
                if (dr.Table.Columns.Contains("NOMBRE")) { cli.NOMBRE = dr.Field<string>("NOMBRE"); }
                if (dr.Table.Columns.Contains("SEXO")) { cli.SEXO = (eSexo)Char.ConvertToUtf32(dr.Field<string>("SEXO"),0); }
                if (dr.Table.Columns.Contains("FECHA_NAC")) { cli.FECHA_NAC = dr.Field<DateTime?>("FECHA_NAC"); }
                if (dr.Table.Columns.Contains("DUI")) { cli.DUI = dr.Field<string>("DUI"); }
                if (dr.Table.Columns.Contains("EXT")) { cli.EXT = dr.Field<string>("EXT"); }
                if (dr.Table.Columns.Contains("FECHA_VENC")) { cli.FECHA_VENC = dr.Field<DateTime?>("FECHA_VENC"); }
                if (dr.Table.Columns.Contains("NIT")) { cli.NIT = dr.Field<string>("NIT"); }
                if (dr.Table.Columns.Contains("NRC")) { cli.NRC = dr.Field<string>("NRC"); }
                if (dr.Table.Columns.Contains("TEL")) { cli.TEL = dr.Field<string>("TEL"); }
                if (dr.Table.Columns.Contains("EMAIL")) { cli.EMAIL = dr.Field<string>("EMAIL"); }
                if (dr.Table.Columns.Contains("PROFESION")) { cli.PROFESION = dr.Field<string>("PROFESION"); }
                if (dr.Table.Columns.Contains("COD_MUNICIPIO")) { cli.COD_MUNICIPIO = dr.Field<string>("COD_MUNICIPIO"); }
                if (dr.Table.Columns.Contains("DIRECCION")) { cli.DIRECCION = dr.Field<string>("DIRECCION"); }
                if (dr.Table.Columns.Contains("DIRECCION_OPCIONAL")) { cli.DIRECCION_OPCIONAL = dr.Field<string>("DIRECCION_OPCIONAL"); }
                if (dr.Table.Columns.Contains("NEGOCIO")) { cli.NEGOCIO = dr.Field<string>("NEGOCIO"); }
                if (dr.Table.Columns.Contains("TEL_NEGOCIO")) { cli.TEL_NEGOCIO = dr.Field<string>("TEL_NEGOCIO"); }
                if (dr.Table.Columns.Contains("DIRECCION_NEGOCIO")) { cli.DIRECCION_NEGOCIO = dr.Field<string>("DIRECCION_NEGOCIO"); }
                if (dr.Table.Columns.Contains("NOTA")) { cli.NOTA = dr.Field<string>("NOTA"); }

                if (dr.Table.Columns.Contains("EXTENDIDO")) { cli.EXTENDIDO = dr.Field<string>("EXTENDIDO"); }
                if (dr.Table.Columns.Contains("EDAD")) { cli.EDAD = dr.Field<Int64?>("EDAD"); }
                if (dr.Table.Columns.Contains("DEPTO")) { cli.DEPTO = dr.Field<string>("DEPTO"); }
                if (dr.Table.Columns.Contains("DOMICILIO")) { cli.DOMICILIO = dr.Field<string>("DOMICILIO"); }

                if (dr.Table.Columns.Contains("LIMITE_CREDITO")) { cli.LIMITE_CREDITO = dr.Field<decimal>("LIMITE_CREDITO"); }
                if (dr.Table.Columns.Contains("CREDITO_DISPONIBLE")) { cli.CREDITO_DISPONIBLE = dr.Field<decimal>("CREDITO_DISPONIBLE"); }
                
            }
            return cli;
        }


        public Cliente Copy()
        {
            Cliente copy = (Cliente)this.MemberwiseClone();
            return copy;
        }



    }

}
