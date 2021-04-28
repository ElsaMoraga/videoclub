using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace videoclub.formularios
{
    public partial class FormVideojuego : Form
    {
        public FormVideojuego()
        {
            InitializeComponent();
        }
        
        private void MostrarDetalle(DAO.videoJuego myItem)
        {
            txtId.Text = myItem.Id.ToString().Trim();
            txtCodigoProd.Text = myItem.CodigoProducto.Trim();
            txtDiscos.Text = myItem.NumeroDiscos.ToString().Trim();
            txtxTitulo.Text = myItem.Titulo.Trim();
            cbEstado.SelectedIndex = cbEstado.Items.IndexOf(myItem.Estado.Trim());
            cbPlataforma.SelectedIndex = cbPlataforma.Items.IndexOf(myItem.Plataforma.Trim());
        }
               
        private void CargarGrid()
        {
            gridVideojuego.Columns.Clear();
            DataTable dt = new DataTable();
            
            dt.Columns.Add("Id");
            dt.Columns.Add("CodigoProducto");
            dt.Columns.Add("Titulo");
            dt.Columns.Add("Estado");

            foreach (var item in DAO.ColeccionArticulo.TodosVideojuegos())
            {
                DataRow oItem = dt.NewRow();
                oItem[0] = item.Id.ToString().Trim();
                oItem[1] = item.CodigoProducto.Trim();
                oItem[2] = item.Titulo.Trim();
                oItem[3] = item.Estado.Trim();
                dt.Rows.Add(oItem);
            }
            gridVideojuego.DataSource = dt;
            
            if (gridVideojuego.Rows.Count != 0)
            {
                gridVideojuego.Rows[0].Selected = true;
                int id = int.Parse(gridVideojuego.Rows[0].Cells[0].Value.ToString());
                DAO.videoJuego item = new DAO.videoJuego();
                item = DAO.ColeccionArticulo.ObtenerVideojuegoPorID(id);
                MostrarDetalle(item);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                DAO.videoJuego myItem = new DAO.videoJuego();
                myItem = DAO.ColeccionArticulo.BuscarVideojuego(txtBuscar.Text);

                if (myItem != null)
                {
                    MostrarDetalle(myItem);
                }
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            DAO.videoJuego newItem = new DAO.videoJuego();

            newItem.CodigoProducto = txtCodigoProd.Text;
            newItem.Titulo = txtxTitulo.Text;
            newItem.NumeroDiscos = int.Parse(txtDiscos.Text);
            newItem.Estado = (cbEstado.SelectedItem == null) ? "Activo" : cbEstado.SelectedItem.ToString();
            newItem.Plataforma = (cbPlataforma.SelectedItem == null) ? "PC" : cbPlataforma.SelectedItem.ToString();

            if (int.Parse(txtDiscos.Text) > 5)
            {
                MessageBox.Show("El número de discos no puede ser mayor a 5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtId.Text == "")
            {
                int id = DAO.ColeccionArticulo.AgregarVideojuego(newItem);
                if (id > 0)
                {
                    MessageBox.Show("Videojuego " + id.ToString() + " creada satisfactoriamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                }
                else
                {
                    MessageBox.Show("Error al grabar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                newItem.Id = int.Parse(txtId.Text);
                if (DAO.ColeccionArticulo.ActualizarVideojuego (newItem))
                {
                    MessageBox.Show("Registro actualizado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                }
                else
                {
                    MessageBox.Show("Error al grabar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDiscos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            btnCancelar.Enabled = true;
            txtId.Text = "";
            txtDiscos.Text = "";
            txtCodigoProd.Text = "";
            txtxTitulo.Text = "";
            cbEstado.SelectedItem = "";
            cbPlataforma.SelectedItem = "";
        }

        private void gridVideojuego_SelectionChanged(object sender, EventArgs e)
        {
            if (gridVideojuego.SelectedRows.Count > 0)
            {
                int id = int.Parse(gridVideojuego.SelectedRows[0].Cells[0].Value.ToString());
                DAO.videoJuego myItem = new DAO.videoJuego();
                myItem = DAO.ColeccionArticulo.ObtenerVideojuegoPorID(id);
                MostrarDetalle(myItem);
            }
        }

        private void FormVideojuego_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            if (gridVideojuego.Rows.Count != 0)
            {
                gridVideojuego.Rows[0].Selected = true;
                int id = int.Parse(gridVideojuego.Rows[0].Cells[0].Value.ToString());
                DAO.videoJuego myItem = new DAO.videoJuego();
                myItem = DAO.ColeccionArticulo.ObtenerVideojuegoPorID(id);
                MostrarDetalle(myItem);
            }
        }
    }
}
