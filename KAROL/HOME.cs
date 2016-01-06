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
using System.Media;
using System.IO;
using Microsoft.Win32;

namespace KAROL
{
    using DDB;
    using MODELO;

    public partial class HOME : Office2007Form
    {
        //PARA MANTENER UNA INSTANCIA UNICA DE LA CLASE//
        private static HOME frmInstance = null;
        
        public static HOME Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new HOME();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        //VARIABLES
        private DBSucursal dbSucursal;
        private DBUsuario dbUser;
        private DBKAROL dbKAROL;

        public DateTime FECHA_SISTEMA;
        public Sucursal SUCURSAL;
        public Usuario USUARIO;
        public string TIPO_SESION;


        public string[] CalzadoA = { "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
        public string[] CalzadoB = { "26", "27", "28","29", "30", "31", "32", "33", "34", "35", "36", "37", "38" };
        public string[] CalzadoC = { "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46" };


        public ToolStripProgressBar progress {
            get
            {
                return this.progressBarStatus;
            }
       }

        public DataTable datSUCURSALES;

        public HOME()
        {
            InitializeComponent();
            this.Font = SystemFonts.IconTitleFont;
            SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            this.PerformAutoScale();
            dbKAROL = new DBKAROL();
            dbSucursal = new DBSucursal();
            dbUser = new DBUsuario();
            
        }


        void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.Window)
            {
                this.Font = SystemFonts.IconTitleFont;
            }
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
        }


        private void HOME_Load(object sender, EventArgs e)
        {
            moduloMOVIMIENTOS.Select();
            MENU_PRINCIPAL.Expanded = false;
            cargarDatosIniciales();
        }







        public void LOGOUT()
        {
            USUARIO = null;
            SUCURSAL = null;
            LoginForm logear = new LoginForm();
            logear.Show();
            this.Hide();
        }






        public void OPEN_SESION(Usuario USER, Sucursal SUC, DateTime FECHA)
        {
            
            this.Show();
            USUARIO = USER;
            SUCURSAL = SUC;
            FECHA_SISTEMA = FECHA;
            MENU_PRINCIPAL.Visible = true;
            STATUS_BAR.Visible = true;// Sonido de inicio de sesion
            SoundPlayer player = new SoundPlayer();
            player.Stream = Properties.Resources.Startup_Ubuntu;

            statusLabelFecha.Text = FECHA_SISTEMA.Date.ToString("dd/MM/yyyy");
            statusLabelSucursal.Text = SUCURSAL.SUCURSAL;
            statusCODEMPLEADO.Text = USUARIO.COD_EMPLEADO;
            statusEMPLEADO.Text = USUARIO.NOMBRE;
            statusTipoSesion.Text = USUARIO.TIPO.ToString();

            cargarPermisos();
            player.Play();
        }





        private void bloquearTodo()
        {
            //MODULO CATALOGOS
            moduloCATALOGOS.Visible = false;
            btnCatalogoClientes.Visible = false;
            btnCatalogoProveedores.Visible = false;
            btnCatalogoProductos.Visible = false;
            //MODULO MOVIMIENTOS
            
            //MODULO OPERACIONES
            
            //MODULO REPORTES
            
            //MODULO CONFIGURACION
            
        }






        private void cargarPermisos()
        {
            bloquearTodo();
            USUARIO.PERMISOS = dbUser.getPermisos(Properties.Settings.Default.SISTEMA, USUARIO.TIPO);
            foreach (DataRow p in USUARIO.PERMISOS.Rows)
            {
                switch (p.Field<string>("MODULO"))
                {
                    //MODULO CATALOGOS
                    case "CATALOGOS":
                        switch (p.Field<string>("MENU"))
                        {
                            case "Clientes":
                                btnCatalogoClientes.Visible = p.Field<bool>("ACCESO");
                                break;
                            case "Proveedores":
                                btnCatalogoProveedores.Visible = p.Field<bool>("ACCESO");
                                break;
                            case "Catalogo":
                                btnCatalogoProductos.Visible = p.Field<bool>("ACCESO");
                                break;
                        }
                        break;

                    //MODULO MOVIMIENTOS
                    
                    //MODULO OPERACIONES
                    
                    //MODULO REPORTES
                    
                    //MODULO CONFIGURACION
                    

                }
            }


            //VISIBILIDAD DE MODULOS
            moduloCATALOGOS.Visible = (btnCatalogoClientes.Visible || btnCatalogoProveedores.Visible || btnCatalogoProductos.Visible);
            grupoCarteras.Visible = (btnCatalogoClientes.Visible || btnCatalogoProveedores.Visible);
            grupoCatalogos.Visible = (btnCatalogoProductos.Visible);
            
        }
                    




        private void HOME_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult cerrar = MessageBox.Show("CERRAR LA APLICACION?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (cerrar == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                LOGOUT();
            }
        }



        private void CERRAR_SESION(object sender, EventArgs e)
        {
            ventanasCERRAR(null, null);
            moduloMOVIMIENTOS.Select();
            LOGOUT();
        }


        public void RESTART(object sender, EventArgs e)
        {
            DialogResult reiniciar = MessageBox.Show("DESEA REINICIAR APLICACION?", "ERROR INESPERADO", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (reiniciar == DialogResult.Yes)
            {
                Application.Restart();
            }
        }



        public void EXIT(object sender, EventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }



        private void cargarDatosIniciales()
        {
            //SUCURSALES PRENDASAL
            datSUCURSALES = dbSucursal.showSucursales();
        }


        public Sucursal getSucursal(string codsuc)
        {
            Sucursal suc = null;
            if (datSUCURSALES != null)
            {
                foreach (DataRow row in datSUCURSALES.Rows)
                {
                    if (row.Field<string>("COD_SUC") == codsuc)
                    {
                        suc = Sucursal.ConverterToSucursal(row);
                        break;
                    }
                }
            }
            return suc;
        }


        public DataTable getSucursalesException(string codsuc)
        {
            DataTable SUCURSALES = datSUCURSALES.Copy();
            if (SUCURSALES != null)
            {
                foreach (DataRow row in SUCURSALES.Rows)
                {
                    if (row.Field<string>("COD_SUC") == codsuc)
                    {
                        SUCURSALES.Rows.Remove(row);
                        break;
                    }
                }
            }
            return SUCURSALES;
        }






        
        private void ventanasCASCADA(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }



        private void ventanasPARALELO(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void ventanasCERRAR(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void ventanasMinimizar(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.WindowState = FormWindowState.Minimized;
            }
        }



        private void BUSCAR_TRANSACCION(object sender, EventArgs e)
        {

        }



        // MENU CATALOGOS
        private void menuCatalogosClientes(object sender, EventArgs e)
        {
            Catalogos.ClientesForm cartera;
            cartera = Catalogos.ClientesForm.Instance();
            cartera.MdiParent = this;
            cartera.Show();
            if (cartera.WindowState == FormWindowState.Minimized)
            {
                cartera.WindowState = FormWindowState.Normal;
            }
        }


        private void menuCatalogosProveedores(object sender, EventArgs e)
        {
            Catalogos.ProveedoresForm proveedores;
            proveedores = Catalogos.ProveedoresForm.Instance();
            proveedores.MdiParent = this;
            proveedores.Show();
            if (proveedores.WindowState == FormWindowState.Minimized)
            {
                proveedores.WindowState = FormWindowState.Normal;
            }
        }

        private void menuCatalogosProductos(object sender, EventArgs e)
        {
            Catalogos.CatalogoForm catalogo;
            catalogo = Catalogos.CatalogoForm.Instance();
            catalogo.MdiParent = this;
            catalogo.Show();
            if (catalogo.WindowState == FormWindowState.Minimized)
            {
                catalogo.WindowState = FormWindowState.Normal;
            }
        }

        // MENU MOVIMIENTOS
        private void btnMovCompras_Click(object sender, EventArgs e)
        {
            Transacciones.ComprasForm compras;
            compras = Transacciones.ComprasForm.Instance();
            compras.MdiParent = this;
            compras.Show();
            if (compras.WindowState == FormWindowState.Minimized)
            {
                compras.WindowState = FormWindowState.Normal;
            }
        }
       

       



        //MENU OPERACIONES
        private void btnOperacionesCorteInv_Click(object sender, EventArgs e)
        {
            Operaciones.CorteInvForm corte;
            corte = Operaciones.CorteInvForm.Instance();
            corte.MdiParent = this;
            corte.Show();
            if (corte.WindowState == FormWindowState.Minimized)
            {
                corte.WindowState = FormWindowState.Normal;
            }
        }

       


        // MENU CONFIGURACION
        private void menuConfigPrecios(object sender, EventArgs e)
        {
            Configuraciones.ConfigPreciosForm precios;
            precios = Configuraciones.ConfigPreciosForm.Instance();
            precios.MdiParent = this;
            precios.Show();
            if (precios.WindowState == FormWindowState.Minimized)
            {
                precios.WindowState = FormWindowState.Normal;
            }
        }


        // MENU REPORTES
        

        
        //MENU AYUDA
        
        
        
        
        
        
        // FUNCIONES GLOBALES


        public String convertirCantidadEnLetras(Decimal monto)
        {
            //float fraccion = new funciones().redondearMas(monto.floatValue() - (int)monto.floatValue(), 2);
            decimal fraccion = monto - (int)monto;
            int parteEntera = (int)monto;
            string Moneda = "DOLAR"; //Nombre de Moneda (Singular)
            string Monedas = "DOLARES";      //Nombre de Moneda (Plural)
            string Centimos = "CTVS.";  //Nombre de Céntimos (Plural)
            string Preposicion = "CON";    //Preposición entre Moneda y Céntimos
            int NumCentimos;
            string Letra = "";
            double Maximo = 1999999999.99;
            //Validar que el Numero está dentro de los límites
            if ((double)monto >= 0 && (double)monto <= Maximo)
            {
                Letra = convertirNumeroLetra(parteEntera);              //Convertir la parte Entera en letras

                NumCentimos = (int)(fraccion * 100);   //Obtener los centimos del Numero

                //Si Numero = 1 agregar leyenda Moneda (Singular)
                if (parteEntera == 1)
                {
                    Letra = Letra + " " + Moneda;
                    //De lo contrario agregar leyenda Monedas (Plural)
                }
                else
                {
                    Letra = Letra + " " + Monedas;
                }
                //Si NumCentimos es mayor a cero inicar la conversión
                if (NumCentimos > 0)
                {
                    //Si el parámetro CentimosEnLetra es VERDADERO obtener letras para los céntimos
                    //Mostrar los céntimos como número
                    if (NumCentimos < 10)
                    {
                        Letra = Letra + " " + " " + Preposicion + " " + NumCentimos + "/100" + Centimos;
                    }
                    else
                    {
                        Letra = Letra + " " + Preposicion + " " + NumCentimos + "/100" + Centimos;
                    }
                }

                return Letra;
            }
            else
            {
                return "ERROR: El número excede los limites";
            }
        }




        public string convertirNumeroLetra(int Numero)
        {
            String resultado = "";

            //Nombre de los números
            List<string> Unidades = new List<string>();
            Unidades.Add(""); Unidades.Add("UN"); Unidades.Add("DOS"); Unidades.Add("TRES"); Unidades.Add("CUATRO"); Unidades.Add("CINCO"); Unidades.Add("SEIS"); Unidades.Add("SIETE"); Unidades.Add("OCHO"); Unidades.Add("NUEVE"); Unidades.Add("DIEZ"); Unidades.Add("ONCE"); Unidades.Add("DOCE"); Unidades.Add("TRECE"); Unidades.Add("CATARCE"); Unidades.Add("QUINCE"); Unidades.Add("DIECISEIS"); Unidades.Add("DIECISIETE"); Unidades.Add("DIECIOCHO"); Unidades.Add("DIECINUEVE"); Unidades.Add("VEINTE"); Unidades.Add("VEINTIUNO"); Unidades.Add("VEINTIDOS"); Unidades.Add("VEINTITRES"); Unidades.Add("VEINTICUATRO"); Unidades.Add("VEINTICINCO"); Unidades.Add("VEINTISEIS"); Unidades.Add("VEINTISIETE"); Unidades.Add("VEINTIOCHO"); Unidades.Add("VEINTINUEVE");
            List<string> Decenas = new List<string>();
            Decenas.Add(""); Decenas.Add("DIEZ"); Decenas.Add("VEINTE"); Decenas.Add("TREINTA"); Decenas.Add("CUARENTA"); Decenas.Add("CINCUENTA"); Decenas.Add("SESENTA"); Decenas.Add("SETENTA"); Decenas.Add("OCHENTA"); Decenas.Add("NOVENTA"); Decenas.Add("CIEN");
            List<string> Centenas = new List<string>();
            Centenas.Add(""); Centenas.Add("CIENTO"); Centenas.Add("DOSCIENTOS"); Centenas.Add("TRESCIENTOS"); Centenas.Add("CUATROCIENTOS"); Centenas.Add("QUINIENTOS"); Centenas.Add("SEISCIENTOS"); Centenas.Add("SETECIENTOS"); Centenas.Add("OCHOCIENTOS"); Centenas.Add("NOVECIENTOS");

            //Convertir a Letra
            if (Numero == 0)
            {
                resultado = "CERO";
            }
            else if (Numero >= 1 && Numero <= 29)
            {
                resultado = Unidades[Numero];
            }
            else if (Numero >= 30 && Numero <= 100)
            {
                resultado = Decenas[Numero / 10];
                if (Numero % 10 != 0)
                {
                    resultado = resultado + " Y ";
                    resultado = resultado + convertirNumeroLetra(Numero % 10);
                }
            }
            else if (Numero >= 101 && Numero <= 999)
            {
                resultado = Centenas[Numero / 100];
                if (Numero % 100 != 0)
                {
                    resultado = resultado + " ";
                    resultado = resultado + convertirNumeroLetra(Numero % 100);
                }
            }
            else if (Numero >= 1000 && Numero <= 1999)
            {
                resultado = "MIL";
                if (Numero % 1000 != 0)
                {
                    resultado = resultado + " ";
                    resultado = resultado + convertirNumeroLetra(Numero % 1000);
                }
            }
            else if (Numero >= 2000 && Numero <= 999999)
            {
                resultado = convertirNumeroLetra(Numero % 1000);
                resultado = resultado + "MIL";
                if (Numero % 1000 != 0)
                {
                    resultado = resultado + " ";
                    resultado = resultado + convertirNumeroLetra(Numero % 1000);
                }
            }
            else if (Numero >= 1000000 && Numero <= 1999999)
            {
                resultado = "UN MILLON";
                if (Numero % 1000000 != 0)
                {
                    resultado = resultado + " ";
                    resultado = resultado + convertirNumeroLetra(Numero % 1000000);
                }
            }
            else if (Numero >= 2000000 && Numero <= 1999999999)
            {
                resultado = convertirNumeroLetra(Numero % 1000000);
                resultado = resultado + "MILLONES";
                if (Numero % 1000000 != 0)
                {
                    resultado = resultado + " ";
                    resultado = resultado + convertirNumeroLetra(Numero % 1000000);
                }
            }

            return resultado;
        }



        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }


        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }



        public void exportDataGridViewToExcel(string titulo, DataGridViewColumnCollection encabezados, DataTable datos,string nombreArchivo)
        {
            int columna = 1;
            int fila = 1;
            if (encabezados != null && datos != null)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Workbooks.Add(true);
                    
                    foreach (DataGridViewColumn column in encabezados)
                    {
                        excel.Cells[fila, columna] = column.HeaderText;
                        excel.ActiveCell.Font.Bold = true;
                        excel.ActiveCell.EntireColumn.NumberFormat = convertFormatExcel(column.DefaultCellStyle.Format);
                        excel.ActiveCell.get_Offset(0, 1).Activate();
                        columna++;
                    }
                    fila++;
                    foreach (DataRow row in datos.Rows)
                    {
                        columna = 1;
                        foreach (DataGridViewColumn column in encabezados)
                        {
                            if (column.Visible)
                            {
                                excel.Cells[fila, columna] = row.Field<object>(column.Name);
                                columna++;
                            }
                        }
                        fila++;
                    }
                    excel.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR AL GENERAR ARCHIVO EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private string convertFormatExcel(string formatDataGrid)
        {
            string formato = string.Empty;
            switch (formatDataGrid)
            {
                case "N0":
                    formato = "#,##0";
                    break;
                case "N1":
                    formato = "#,##0.0";
                    break;
                case "C2":
                    formato = "$#,##0.00_);[Red]($#,##0.00)";
                    break;
                case "P2":
                    formato = "0.00%";
                    break;
                default:
                    formato = "@";
                    break;
            }
            return formato;
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            PruebasForm prueba;
            prueba = new PruebasForm();
            prueba.MdiParent = this;
            prueba.Show();
            if (prueba.WindowState == FormWindowState.Minimized)
            {
                prueba.WindowState = FormWindowState.Normal;
            }
        }

        

        


        
        




       



        
       




       
    }
}
