using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SegundoExamen
{
    public partial class FrmMenu : Syncfusion.Windows.Forms.Office2010Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        FrmProductos frmProductos = null;
        FrmPedidos frmPedidos=null;
 
      

        private void ProductosToolStripButton_Click(object sender, EventArgs e)
        {
            if (frmProductos == null)
            {
                frmProductos = new FrmProductos();
                frmProductos.MdiParent = this;
                frmProductos.FormClosed += FrmProducto_FormClosed;
                frmProductos.Show();
            }
            else
            {
                frmProductos.Activate();
            }
        }

        private void FrmProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProductos = null;
        }

        private void PedidosToolStripButton_Click(object sender, EventArgs e)
        {
            if (frmPedidos == null)
            {
                frmPedidos = new FrmPedidos();
                frmPedidos.MdiParent = this;
                frmPedidos.FormClosed += FrmPedidos_FormClosed;
                frmPedidos.Show();
            }
            else
            {
                frmPedidos.Activate();
            }
        }

        private void FrmPedidos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPedidos = null;
        }
    }
}
