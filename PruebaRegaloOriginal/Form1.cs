using PruebaRegaloOriginal.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaRegaloOriginal
{
    public partial class Form1 : Form
    {
        List<Producto> Carrito = new List<Producto>();
        List<Producto> Favoritos = new List<Producto>();
        public Form1()
        {
            InitializeComponent();
            tbCantidad.KeyPress += TbCantidad_KeyPress;
            tbPrecioUnitario.KeyPress += TbCantidad_KeyPress;
            cbItems.SelectedIndex = 0;
        }

        private void TbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validartxt.NumerosDecimales(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbNombre.Text)
                ||string.IsNullOrEmpty(tbPrecioUnitario.Text)) 
            {
                
            } else {
                if (cbItems.SelectedIndex==1)
                {
                    if (string.IsNullOrEmpty(tbCantidad.Text))
                    {
                        MessageBox.Show("No se puede agregar el producto porque no tiene cantidad");

                    }
                    else {
                        Producto p1 = new Producto();
                        p1.Nombre = tbNombre.Text;
                        p1.Cantidad = Convert.ToInt32(tbCantidad.Text);
                        p1.PrecioUnitario = Convert.ToDecimal(tbPrecioUnitario.Text);
                        Carrito.Add(p1);
                        dgvCarrito.DataSource = null;
                        dgvCarrito.DataSource = Carrito;
                        decimal precioTotal=0;
                        foreach(Producto p in Carrito)
                        {
                            precioTotal += p.Cantidad * p.PrecioUnitario;
                        }
                        lbSubtotal.Text = precioTotal.ToString();
                    }
                }
                else
                {
                
                   Producto p1 = new Producto();
                   p1.Nombre = tbNombre.Text;
                   p1.Cantidad = 0;
                   p1.PrecioUnitario = Convert.ToDecimal(tbPrecioUnitario.Text);
                   Favoritos.Add(p1);
                    dgvFavoritos.DataSource = null;
                    dgvFavoritos.DataSource = Favoritos;
                   
                }
                
            }

        }
    }
}
