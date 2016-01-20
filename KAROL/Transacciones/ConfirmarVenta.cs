using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlesPersonalizados;

namespace KAROL.Transacciones
{
    using MODELO;
    using DDB;

    public partial class ConfirmarVenta : Form
    {
        private DBUsuario dbUser;
        private DBVenta dbVenta;

        private Venta VENTA;
        private eOperacion ACCION;


        public ConfirmarVenta(Venta v, eOperacion operacion)
        {
            InitializeComponent();
            dbUser = new DBUsuario();
            dbVenta = new DBVenta();
            ACCION = operacion;
            VENTA = v;
            mostrarDatos();
        }

        private void mostrarDatos()
        {
            if (VENTA != null)
            {
                lbNUMENVIO.Text = VENTA.NUMENVIO;
                lbFECHA.Text = VENTA.FECHA.ToString("dd/MM/yyyy");
                lbCLIENTE.Text = VENTA.CLIENTE;
                lbSUMAS.Text = VENTA.MONTO.ToString("C2");
                lbDESCUENTO.Text = VENTA.DESCUENTO.ToString("C2");
                lbTOTAL.Text = VENTA.TOTAL.ToString("C2");
                lbNIVEL.Text = VENTA.NIVEL.ToString();
                switch (VENTA.NIVEL)
                {
                    case eNIVEL.MAYOREO:
                        lbNIVEL.ForeColor = Color.Green;
                        break;
                    case eNIVEL.DETALLE:
                        lbNIVEL.ForeColor = Color.Blue;
                        break;
                    case eNIVEL.DONACION:
                        lbNIVEL.ForeColor = Color.Red;
                        break;
                }
                
            }
        }




        private void GUARDAR_Click(object sender, EventArgs e)
        {
            string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
            if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
            {
                switch (ACCION)
                {
                    case eOperacion.INSERT:
                        if (dbVenta.insert(VENTA, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                        {
                            //VentasForm.Instance().IMPRIMIR(VENTA);
                            VentasForm.Instance().buscarVenta(VENTA.NUMENVIO);
                            this.Close();
                        }
                        break;
                    case eOperacion.UPDATE:
                        if (dbVenta.update(VENTA, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                        {
                            VentasForm.Instance().buscarVenta(VENTA.NUMENVIO);
                            this.Close();
                        }
                        break;

                }
            }
            else
            {
                MessageBox.Show("CODIGO DE AUTORIZACION INVALIDO", "DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void CANCELAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
