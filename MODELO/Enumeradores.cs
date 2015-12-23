using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public enum eTransaccion
    {
        INVENTARIO_INICIAL,
        COMPRA,
        IMPORTACION,
        VENTA,
        DEVOLUCION_COMPRA,
        DEVOLUCION_VENTA,
        PAGO,
        COBRO,
        GASTO,
        TRASLADO
    }




    public enum eOperacion
    {
        INSERT,
        UPDATE,
        DELETE,
        SEARCH,
        PREVIEW
    }


    public enum GlobalFechaSistema
    {
        SERVIDOR = 1,
        CLIENTE
    }


    public enum eEstado
    {
        HISTORICO = -2,
        PREINGRESADO = -1,
        ANULADO = 0,
        CONTABILIZADO = 1
    }


    public enum eTipoPago
    {
        EFECTIVO = 1,
        CHEQUE,
        REMESA
    }

    public enum eTipoUsuario
    {
        ADMIN = 1,
        GERENTE,
        CONTADOR,
        BODEGA,
        VENDEDOR
    }

    public enum eTipoDoc
    {
        DUI,
        NIT,
        NRC
    }


    public enum eSexo
    {
        MASCULINO = 'M',
        FEMENINO = 'F',
    }

    public enum eNaturalezaPersona
    {
        NATURAL,
        JURIDICA
    }


    public enum eCategoria
    {
        CALZADO,
        CARTERA,
        ROPA,
        MOCHILA
    }





    public enum eUnidadMedida
    {
        UDS
    }


    

    public enum eTipoCompra
    {
        NACIONAL = 1,
        IMPORTADO
    }



    public enum eIngresarComo
    {
        CAJA,
        UNITARIO
    }


    public enum eCorridaCalzado
    {
        A,
        B,
        C
    }


    


    class Enumeradores
    {
    }
}
