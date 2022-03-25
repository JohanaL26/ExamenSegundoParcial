using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoExamen
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        //CREACION DE OBJEOS CON CLASES
        ProductosAccs productoAccs = new ProductosAccs();
        string operacion = string.Empty;//INCIALIZACION DE VARIABLE 
        Productos producto = new Productos();


        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion="Nuevo";

        }

        private void ListarProductos()
        {
            //ASIGNAR LOS VALORES DE LOS PRODUCTOS AL DATAGRIDVIEW
            ProductosDataGridView.DataSource = productoAccs.ListarProductos();

        }


        private void HabilitarControles()
        {
            //HABILITACION DE CONTROLES
            CodigoTextBox.Enabled = true;
            DescripcionTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            ExistenciaTextBox.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            NuevoButton.Enabled = false;
            ModificarButton.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            //DESHABILITACION DE CONTROLES
            CodigoTextBox.Enabled = false;
            DescripcionTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            ExistenciaTextBox.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            NuevoButton.Enabled = true;
            ModificarButton.Enabled = true;
        }

        private void LimpiarControles()
        {
            //LIMPIAR CONTROLES
            CodigoTextBox.Clear();
            DescripcionTextBox.Clear();
            PrecioTextBox.Clear();
            ExistenciaTextBox.Clear();
        }


        private void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                //VALIDACION DE CONTROLES PARA NO INGRESAR NINGUNO VACIO
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese el codigo");
                    CodigoTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(DescripcionTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionTextBox, "Ingrese una descripcion");
                    DescripcionTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(PrecioTextBox.Text))
                {
                    errorProvider1.SetError(PrecioTextBox, "Ingrese el precio");
                    PrecioTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(ExistenciaTextBox.Text))
                {
                    errorProvider1.SetError(ExistenciaTextBox, "Ingrese la existencia");
                    ExistenciaTextBox.Focus();
                    return;
                }

                //SE PASAN LOS PARÁMETROS A LOS TEXTBOXS
                producto.Codigo = CodigoTextBox.Text;
                producto.Descripcion = DescripcionTextBox.Text;
                producto.Precio = Convert.ToDecimal(PrecioTextBox.Text);
                producto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);

                if (operacion == "Nuevo")
                {
                    bool inserto = productoAccs.InsertarProducto(producto);

                    if (inserto)
                    {
                        MessageBox.Show("Producto Insertado");
                        DeshabilitarControles();
                        LimpiarControles();
                        ListarProductos();

                    }
                }
                else if (operacion == "Modificar")
                {
                    bool modifico = productoAccs.ModificarProducto(producto);
                    if (modifico)
                    {
                        LimpiarControles();
                        DeshabilitarControles();
                        ListarProductos();
                        MessageBox.Show("Producto modificado");
                    }
                    //MessageBox.Show("Producto No Insertado");
                }

            }
            catch (Exception ex)
            {

            }


        }



        private void ModificarButton_Click_1(object sender, EventArgs e)
        {

            operacion = "Modificar";

            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                DescripcionTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                PrecioTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Precio"].Value.ToString();
                ExistenciaTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Existencia"].Value.ToString();


                HabilitarControles();
                CodigoTextBox.Focus();


            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto");
            }

        }



        private void EliminarButton_Click(object sender, EventArgs e)
        {

            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = productoAccs.EliminarProducto(ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());

                if (elimino)
                {
                    ListarProductos();
                    MessageBox.Show("Producto eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Producto no eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            ProductosDataGridView.DataSource = productoAccs.ListarProductos();
        }
    }
}
