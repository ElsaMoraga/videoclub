using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace videoclub
{
    public partial class FormVideoClub : Form
    {
        public FormVideoClub()
        {
            InitializeComponent();
            
        }

        private void mnuCliente_Click(object sender, EventArgs e)
        {
            formularios.FormEditCliente myForm = new formularios.FormEditCliente();
            myForm.MdiParent = this;
            myForm.Show();

        }

        private void mnuPelicula_Click(object sender, EventArgs e)
        {
            formularios.FormPeliculas myForm = new formularios.FormPeliculas();
            myForm.MdiParent = this;
            myForm.Show();
        }

        private void mnuVideoJuego_Click(object sender, EventArgs e)
        {
            formularios.FormVideojuego myForm = new formularios.FormVideojuego();
            myForm.MdiParent = this;
            myForm.Show();
        }

        private void mnuAltaAlquiler_Click(object sender, EventArgs e)
        {
            Forms.FormAltaAlquiler myForm = new Forms.FormAltaAlquiler();
            myForm.MdiParent = this;
            myForm.Show();
        }

        private void mnuBajaAlquiler_Click(object sender, EventArgs e)
        {
            Forms.FormBajaAlquiler myForm = new Forms.FormBajaAlquiler();
            myForm.MdiParent = this;
            myForm.Show();
        }

        private void mnuListaAlquiler_Click(object sender, EventArgs e)
        {
            Forms.FormListaAlquiler myForm = new Forms.FormListaAlquiler();
            myForm.MdiParent = this;
            myForm.Show();
        }

        private void FormVideoClub_Load(object sender, EventArgs e)
        {

            DAO.ColeccionCliente.ActualizarStatusCliente();

            DAO.ColeccionCliente.ActualizarPorcentajeDescuento();            
            
        }
    }
}
