using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    using System.Data;

    public class Catalogo
    {
        public string COD_ITEM;
        public eCategoria CATEGORIA;
        public string MARCA;
        public string DESCRIPCION;
        public eUnidadMedida UNIDAD_MEDIDA;


        public Catalogo()
        {

        }



        public static Catalogo ConvertToCatalogo(DataRow dr)
        {
            Catalogo item = null;
            if (dr != null)
            {
                item = new Catalogo();
                if (dr.Table.Columns.Contains("COD_ITEM")) { item.COD_ITEM = dr.Field<string>("COD_ITEM"); }
                if (dr.Table.Columns.Contains("CATEGORIA")) { item.CATEGORIA = (eCategoria)Enum.Parse(typeof(eCategoria), dr.Field<string>("CATEGORIA")); }
                if (dr.Table.Columns.Contains("MARCA")) { item.MARCA = dr.Field<string>("MARCA"); }
                if (dr.Table.Columns.Contains("DESCRIPCION")) { item.DESCRIPCION = dr.Field<string>("DESCRIPCION"); }
                if (dr.Table.Columns.Contains("UNIDAD_MEDIDA")) { item.UNIDAD_MEDIDA = (eUnidadMedida)Enum.Parse(typeof(eUnidadMedida), dr.Field<string>("UNIDAD_MEDIDA")); }

            }
            return item;

        }


    }
}
