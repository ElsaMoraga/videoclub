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
    public partial class FormBajaAlquiler : Form
    {
        public FormBajaAlquiler()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DAO.alquiler myAlquiler = DAO.ColeccionAlquiler.DevolverAlquiler(int.Parse(txtBuscar.Text));
            if (myAlquiler != null)
            {
                txtArticulo.Text = myAlquiler.articulo.Titulo;
                txtCliente.Text = myAlquiler.cliente.Nombre.Trim() + " " + myAlquiler.cliente.Apellido.Trim();
                DateTime fechaEntrega = ((DateTime) myAlquiler.Fecha).AddDays((Double)(myAlquiler.Dias));
                if(fechaEntrega < DateTime.Today)
                {
                    TimeSpan diasExtra = fechaEntrega - DateTime.Today;
                    double multa = (Double) myAlquiler.articulo.PrecioPorDia * (diasExtra.Days);
                    txtMulta.Text = multa.ToString();
                    MessageBox.Show("El cliente debe pagar una multa de " + multa.ToString() + " por " + diasExtra.Days + " de retrazo." , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
