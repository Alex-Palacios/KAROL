using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ControlesPersonalizados;

namespace KAROL.Catalogos
{
    using DDB;
    using MODELO;

    public partial class CatalogoForm : Form
    {
        //PARA MANTENER UNA INSTANCIA UNICA DE LA CLASE//
        private static CatalogoForm frmInstance = null;
        private string formName;

        public static CatalogoForm Instance(string form)
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new CatalogoForm();
            }
            frmInstance.formName = form;
            frmInstance.BringToFront();
            return frmInstance;
        }


        public static CatalogoForm Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new CatalogoForm();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }


        //VARIABLES
        private DBKAROL dbKAROL;
        private DBCatalogo dbCatalogo;

        private DataTable CATALOGO;
        private DataTable FILTRO;
        private Catalogo SELECTED;

        private eOperacion ACCION;

        public CatalogoForm()
        {
            InitializeComponent();
            dbCatalogo = new DBCatalogo();
            dbKAROL = new DBKAROL();
        }



        private void permisos()
        {
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            
            foreach(DataRow p in HOME.Instance().USUARIO.PERMISOS.Rows)
            {
                if (p.Field<string>("CODIGO") == "P3")
                {
                    btnNuevo.Visible = p.Field<bool>("REGISTRAR");
                    btnEditar.Visible = p.Field<bool>("ACTUALIZAR");
                    btnEliminar.Visible = p.Field<bool>("ELIMINAR");
                }
            }
        }


        private void CatalogoForm_Load(object sender, EventArgs e)
        {
            permisos();
            tblCATALOGO.AutoGenerateColumns = false;

            cbxFiltroCategoria.DataSource = Enum.GetValues(new eCategoria().GetType());

            ACCION = eOperacion.INSERT;
            cargarDatos();
            bloquear();

        }


        private void bloquear()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        public void cargarDatos()
        {
            CATALOGO = dbCatalogo.showCatalogo((eCategoria)cbxFiltroCategoria.SelectedItem);
            actualizarfiltros();
            filtarDatos();
            bloquear();
        }


        private void actualizarfiltros()
        {
            List<string> marcas = new List<string>();
            marcas.Add("TODAS");
            txtFiltroEstilo.Text = string.Empty;
            var result = CATALOGO.AsEnumerable()
                                .Select(row => new
                                {
                                    MARCA = row.Field<string>("MARCA")
                                })
                                .Distinct().OrderBy(row => row.MARCA);
            foreach (var v in result)
            {
                marcas.Add(v.MARCA);
            }
            cbxFiltroMarca.DataSource = marcas;
        }


        private void cbxFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFiltroCategoria.SelectedIndex >= 0)
            {
                cargarDatos();
            }
        }


        private void txtFiltroEstilo_TextChanged(object sender, EventArgs e)
        {
            filtarDatos();
        }


        private void cbxFiltroMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFiltroMarca.SelectedIndex >= 0)
            {
                filtarDatos();
            }
        }


        private void filtarDatos()
        {
            DataRow[] filtros;
            FILTRO = CATALOGO.Copy();
            if (FILTRO.Rows.Count > 0)
            {
                if (txtFiltroEstilo.Text.Trim() != string.Empty)
                {
                    filtros = FILTRO.Select("COD_ITEM LIKE '" + txtFiltroEstilo.Text.Trim() + "%'");
                    if (filtros.Count() > 0)
                    {
                        FILTRO = filtros.CopyToDataTable();
                    }
                    else
                    {
                        FILTRO.Clear();
                    }
                }
                if (cbxFiltroMarca.SelectedIndex > 0)
                {
                    filtros = FILTRO.Select("MARCA LIKE '" + cbxFiltroMarca.Text.Trim() + "%'");
                    if (filtros.Count() > 0)
                    {
                        FILTRO = filtros.CopyToDataTable();
                    }
                    else
                    {
                        FILTRO.Clear();
                    }
                } 
            }
            tblCATALOGO.DataSource = FILTRO;
            
        }


        private void cargarSelected(){
            SELECTED = new Catalogo();
            if (tblCATALOGO.CurrentCell != null )
            {
                SELECTED = Catalogo.ConvertToCatalogo(FILTRO.Rows[tblCATALOGO.CurrentCell.RowIndex]);
                
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }




        private void btnNew_Click(object sender, EventArgs e)
        {
            ACCION = eOperacion.INSERT;
            RegistrarCatalogoForm nuevo = new RegistrarCatalogoForm();
            nuevo.ShowDialog(this);
        }




        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tblCATALOGO.SelectedRows.Count == 1)
            {
                ACCION = eOperacion.UPDATE;
                cargarSelected();
                RegistrarCatalogoForm editar = new RegistrarCatalogoForm(SELECTED);
                editar.ShowDialog(this);
            }
        }


        private void btnChangeID_Click(object sender, EventArgs e)
        {
            if (tblCATALOGO.SelectedRows.Count == 1)
            {
                ACCION = eOperacion.UPDATE;
                cargarSelected();
                string oldCodigo = FILTRO.Rows[tblCATALOGO.CurrentCell.RowIndex].Field<string>("COD_ITEM");
                string newCodigo = Controles.InputBox("CAMBIAR ESTILO " + oldCodigo + " POR : ", "EDITAR ESTILO");
                if (newCodigo.Trim() != "")
                {
                    if (dbCatalogo.changeID(oldCodigo, newCodigo.ToUpper().Trim(), HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                    {
                        cargarDatos();
                    }
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tblCATALOGO.SelectedRows.Count == 1)
            {
                DialogResult eliminar = MessageBox.Show("¿Está seguro que desea eliminar el estilo " + SELECTED.COD_ITEM + " del catalogo ?", "Eliminar ESTILO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (eliminar == DialogResult.Yes)
                {
                    string autorizacion = Controles.InputBoxPassword("CODIGO", "CODIGO DE AUTORIZACION");
                    if (autorizacion != "" && DBKAROL.md5(autorizacion) == HOME.Instance().USUARIO.PASSWORD)
                    {
                        ACCION = eOperacion.DELETE;
                        cargarSelected();
                        if (dbCatalogo.delete(SELECTED, HOME.Instance().SUCURSAL.COD_SUC, HOME.Instance().USUARIO.COD_EMPLEADO, Properties.Settings.Default.SISTEMA))
                        {
                            cargarDatos();
                        }
                     }
                     else
                     {
                         MessageBox.Show("CODIGO DE AUTORIZACION INVALIDO", "DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                     }
                }
            }
        }





     


        private void tblCATALOGO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblCATALOGO.CurrentCell != null && tblCATALOGO.CurrentCell.RowIndex >= 0)
            {
                cargarSelected();
            }
        }






        private void tblCATALOGO_DataSourceChanged(object sender, EventArgs e)
        {
            if (tblCATALOGO.DataSource != null)
            {
                lbTOTAL.Text = tblCATALOGO.Rows.Count + " ESTILOS";
            }
        }



        private void tblCATALOGO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblCATALOGO.CurrentCell != null && tblCATALOGO.CurrentCell.RowIndex >= 0 && tblCATALOGO.SelectedRows.Count == 1)
            {
                cargarSelected();
                switch (formName)
                {
                    case "ComprasForm":
                        //Movimientos.ComprasForm.Instance().cargarDatosCliente(SELECTED);
                        this.Close();
                        break;
                    case "ContratosForm":
                        //Movimientos.ContratosForm.Instance().cargarDatosCliente(SELECTED);
                        this.Close();
                        break;
                    case "VentasForm":
                        //Movimientos.VentasForm.Instance().cargarDatosCliente(SELECTED);
                        this.Close();
                        break;
                    case "REstadoCuentaForm":
                        //Reportes.REstadoCuentaForm.Instance().cargarDatosCliente(SELECTED);
                        this.Close();
                        break;
                }
            }
        }





        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (FILTRO != null)
            {
                HOME.Instance().exportDataGridViewToExcel("CATALOGO", tblCATALOGO.Columns, FILTRO, "Catalogo");
            }
        }

       

        
        
        



    }
}
