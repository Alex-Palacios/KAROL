using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    using System.Data;


    public class Compra
    {
        public int ID_COMPRA;
        public string COD_SUC;
        public string COD_TRANS;
        public int? ID_IMPORT;
        public string COD_PROVEEDOR;
        public DateTime FECHA;
        public eTipoCompra TIPO;
        public string NUMCOMPRA;
        public eTipoDoc TIPO_DOC;
        public string DOCUMENTO;
        public decimal AJUSTE;
        public decimal TOTAL;
        public eCategoria CATEGORIA;
        public eEstado ESTADO;
        public bool INIT_BALANCE;
        public string NOTA;

        public string RESPONSABLE;
        public eNaturalezaPersona PERSONA;
        public string PROVEEDOR;
        public string TELEFONO;

        public int UNIDADES;
        public decimal MONTO;

        public DataTable ITEMS_COMPRA;


        public Compra()
        {
            //DATOS POR DEFECTO
            ITEMS_COMPRA = new DataTable();
            ITEMS_COMPRA.Columns.Add("CODIGO").DataType = System.Type.GetType("System.String");
            ITEMS_COMPRA.Columns.Add("COMO").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("COD_ITEM").DataType = System.Type.GetType("System.String");
            ITEMS_COMPRA.Columns.Add("COLOR").DataType = System.Type.GetType("System.String");
            ITEMS_COMPRA.Columns.Add("CORRIDA").DataType = System.Type.GetType("System.String");
            ITEMS_COMPRA.Columns.Add("T1").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T2").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T3").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T4").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T5").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T6").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T7").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T8").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T9").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T10").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T11").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T12").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("T13").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("UNIDADES").DataType = System.Type.GetType("System.Int32");
            ITEMS_COMPRA.Columns.Add("COSTO").DataType = System.Type.GetType("System.Decimal");
            ITEMS_COMPRA.Columns.Add("MONTO").DataType = System.Type.GetType("System.Decimal");
        }

        

        public static Compra ConvertToCompra(DataRow dr)
        {
            Compra compra = null;
            if (dr != null)
            {
                compra = new Compra();
                if (dr.Table.Columns.Contains("ID_COMPRA")) { compra.ID_COMPRA = dr.Field<int>("ID_COMPRA"); }
                if (dr.Table.Columns.Contains("COD_SUC")) { compra.COD_SUC = dr.Field<string>("COD_SUC"); }
                if (dr.Table.Columns.Contains("COD_TRANS")) { compra.COD_TRANS = dr.Field<string>("COD_TRANS"); }
                if (dr.Table.Columns.Contains("ID_IMPORT")) { compra.ID_IMPORT = dr.Field<int?>("ID_IMPORT"); }
                if (dr.Table.Columns.Contains("COD_PROVEEDOR")) { compra.COD_PROVEEDOR = dr.Field<string>("COD_PROVEEDOR"); }
                if (dr.Table.Columns.Contains("FECHA")) { compra.FECHA = dr.Field<DateTime>("FECHA"); }
                if (dr.Table.Columns.Contains("TIPO")) { compra.TIPO = (eTipoCompra)dr.Field<int>("TIPO"); }
                if (dr.Table.Columns.Contains("NUMCOMPRA")) { compra.NUMCOMPRA = dr.Field<string>("NUMCOMPRA"); }
                if (dr.Table.Columns.Contains("TIPO_DOC")) { compra.TIPO_DOC = (eTipoDoc)Enum.Parse(typeof(eTipoDoc), dr.Field<string>("TIPO_DOC")); }
                if (dr.Table.Columns.Contains("DOCUMENTO")) { compra.DOCUMENTO = dr.Field<string>("DOCUMENTO"); }
                if (dr.Table.Columns.Contains("AJUSTE")) { compra.AJUSTE = dr.Field<decimal>("AJUSTE"); }
                if (dr.Table.Columns.Contains("TOTAL")) { compra.TOTAL = dr.Field<decimal>("TOTAL"); }
                if (dr.Table.Columns.Contains("CATEGORIA")) { compra.CATEGORIA = (eCategoria)Enum.Parse(typeof(eCategoria), dr.Field<string>("CATEGORIA")); }
                if (dr.Table.Columns.Contains("ESTADO")) { compra.ESTADO = (eEstado)dr.Field<int>("ESTADO"); }
                if (dr.Table.Columns.Contains("INIT_BALANCE")) { compra.INIT_BALANCE = dr.Field<bool>("INIT_BALANCE"); }
                if (dr.Table.Columns.Contains("NOTA")) { compra.NOTA = dr.Field<string>("NOTA"); }

                if (dr.Table.Columns.Contains("RESPONSABLE")) { compra.RESPONSABLE = dr.Field<string>("RESPONSABLE"); }
                if (dr.Table.Columns.Contains("NATURALEZA")) { compra.PERSONA = (eNaturalezaPersona)Enum.Parse(typeof(eNaturalezaPersona), dr.Field<string>("NATURALEZA")); }
                if (dr.Table.Columns.Contains("PROVEEDOR")) { compra.PROVEEDOR = dr.Field<string>("PROVEEDOR"); }
                if (dr.Table.Columns.Contains("TEL")) { compra.RESPONSABLE = dr.Field<string>("TEL"); }
                if (dr.Table.Columns.Contains("UNIDADES")) { compra.UNIDADES = Int32.Parse(dr.Field<Int64>("UNIDADES").ToString()); }
                if (dr.Table.Columns.Contains("MONTO")) { compra.MONTO = dr.Field<decimal>("MONTO"); }
                

            }
            return compra;

        }



        public Compra Copy()
        {
            Compra copy = (Compra)this.MemberwiseClone();
            copy.ITEMS_COMPRA = this.ITEMS_COMPRA.Copy();
            return copy;
        }






    }
}
