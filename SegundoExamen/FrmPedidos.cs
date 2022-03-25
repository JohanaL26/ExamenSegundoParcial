﻿using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SegundoExamen
{
    public partial class FrmPedidos : Form
    {
        public FrmPedidos()
        {
            InitializeComponent();
        }

        ProductosAccs productosAccs = new ProductosAccs();
        Pedidos pedidos = new Pedidos();
        Productos productos;
        PedidosAccs pedidosAccs = new PedidosAccs();

        List<DetallePedidos> detallePedidosLista = new List<DetallePedidos>();



        

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            DetalleDataGridView.DataSource = detallePedidosLista;
        }

        private void CodigoProductoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                productos = new Productos();
                productos = productosAccs.GetProductoPorCodigo(CodigoProductoTextBox.Text);
                DescripcionProductoTextBox.Text = productos.Descripcion;
                CantidadTextBox.Focus();
            }
            else
            {
                productos = null;
                DescripcionProductoTextBox.Clear();
                CantidadTextBox.Clear();
            }
        }



        private void GuardarButton_Click(object sender, EventArgs e)
        {
            pedidos.IdentidadCliente = IdentidadMaskedTextBox.Text;
            pedidos.Cliente = NombreTextBox.Text;
            pedidos.Fecha = FechaDateTimePicker.Value;


            DetallePedidos detallePedidos = new DetallePedidos();
            detallePedidos.CodigoProducto = productos.Codigo;
            detallePedidos.Descripcion = productos.Descripcion;
            detallePedidos.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
            detallePedidos.Precio = productos.Precio;
            detallePedidos.Total = productos.Precio * Convert.ToInt32(CantidadTextBox.Text);


            detallePedidosLista.Add(detallePedidos);
            DetalleDataGridView.DataSource = null;
            DetalleDataGridView.DataSource = detallePedidosLista;




            int idPedido = 0;

            idPedido = pedidosAccs.InsertarPedido(pedidos);

            if (idPedido != 0)
            {
                foreach (var item in detallePedidosLista)
                {
                    item.IdPedido = idPedido;
                    pedidosAccs.InsertarDetalle(item);
                }
            }



        }



    }
}
