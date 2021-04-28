using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace videoclub.Forms
{
    public partial class FormAltaAlquiler : Form
    {
        public FormAltaAlquiler()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (txtBuscarCliente.Text != "")
            {
                DAO.cliente myCliente = new DAO.cliente();
                myCliente = DAO.ColeccionCliente.BuscarCliente(txtBuscarCliente.Text);

                if (myCliente != null)
                {
                    txtCodCliente.Text = myCliente.idCliente.ToString().Trim();
                    txtCliente.Text = myCliente.Nombre.Trim() + " " + myCliente.Apellido.Trim();
                    txtDescuento.Text = myCliente.Descuento.ToString().Trim() ==""?"0": myCliente.Descuento.ToString().Trim();
                }
            }
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            DAO.articulo myArticulo = DAO.ColeccionArticulo.BuscarArticulo(txtCodArticulo.Text, txtTitulo.Text);
            if(myArticulo != null)
            {
                txtCodArticul.Text = myArticulo.Id.ToString();
                txtArticulo.Text = myArticulo.Titulo;
                decimal totalSinDescuento = (decimal)((myArticulo.PrecioPorDia == null ? 0 : myArticulo.PrecioPorDia) * int.Parse(txtDias.Text));
                decimal descuento = decimal.Parse(txtDescuento.Text.Trim() == "" ? "0" : txtDescuento.Text.ToString().Trim());
                txtTotal.Text = (totalSinDescuento - (descuento * totalSinDescuento)).ToString();
            }
        }

        private void btnAlquilar_Click(object sender, EventArgs e)
        {
            if(txtCliente.Text.Trim() == "")
            {
                MessageBox.Show("Debe buscar al cliente primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtArticulo.Text.Trim() == "")
            {
                MessageBox.Show("Debe buscar el artículo primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idAlquiler = DAO.ColeccionAlquiler.RealizarAlquiler(int.Parse(txtCodCliente.Text), int.Parse(txtCodArticul.Text.Trim()), int.Parse(txtDias.Text.Trim()), double.Parse(txtTotal.Text.Trim()));
            if (idAlquiler>0)
            {
                MessageBox.Show("Alquiler " + idAlquiler.ToString() + " creado satisfactoriamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al grabar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
