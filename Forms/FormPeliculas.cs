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
    public partial class FormPeliculas : Form
    {
        public FormPeliculas()
        {
            InitializeComponent();
        }
        


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DAO.pelicula newItem = new DAO.pelicula();

            newItem.AnioCompra = int.Parse(txtAnioCompra.Text);
            newItem.AnioPublicacion = int.Parse(txtAnioPublicacion.Text);
            newItem.CodigoProducto = txtCodigoProd.Text;
            newItem.Duracion = int.Parse(txtDuracion.Text);
            newItem.Estado = (cbEstado.SelectedItem == null) ? "Activo" : cbEstado.SelectedItem.ToString(); ;
            newItem.NumeroDvd = int.Parse(txtDVD.Text);
            newItem.Titulo = txtxTitulo.Text;

            if (int.Parse(txtAnioPublicacion.Text) > DateTime.Today.Year)
            {
                MessageBox.Show("Año de publicación no puede ser mayor al año actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(txtAnioCompra.Text) > DateTime.Today.Year)
            {
                MessageBox.Show("Año de compra no puede ser mayor al año actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(txtDVD.Text) > 5)
            {
                MessageBox.Show("El número de DVD no puede ser mayor a 5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(txtDuracion.Text) > 500)
            {
                MessageBox.Show("La duración no puede ser mayor a 500 minutos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtId.Text == "")
            {
                int id = DAO.ColeccionArticulo.AgregarPelicula(newItem);
                if (id > 0)
                {
                    MessageBox.Show("Pelicula " + id.ToString() + " creada satisfactoriamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (DAO.ColeccionArticulo.ActualizarPelicula(newItem))
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

        private void FormEditCliente_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void MostrarDetalle(DAO.pelicula myItem)
        {
            txtId.Text = myItem.Id.ToString();
            txtDuracion.Text = myItem.Duracion.ToString();
            txtAnioPublicacion.Text = myItem.AnioPublicacion.ToString();
            txtCodigoProd.Text = myItem.CodigoProducto;
            txtDVD.Text = myItem.NumeroDvd.ToString();
            txtAnioCompra.Text = myItem.AnioCompra.ToString();
            txtxTitulo.Text = myItem.Titulo;
            cbEstado.SelectedItem = myItem.Estado;
        }

        private void gridPelicula_SelectionChanged(object sender, EventArgs e)
        {
            
            if(gridPelicula.Rows.Count > 0)
            {
                if (gridPelicula.SelectedRows.Count == 0)
                {
                    gridPelicula.Rows[0].Selected = true;
                }
                int id = int.Parse(gridPelicula.SelectedRows[0].Cells[0].Value.ToString());
                DAO.pelicula myItem = new DAO.pelicula();
                myItem = DAO.ColeccionArticulo.ObtenerPeliculaPorID(id);
                MostrarDetalle(myItem);

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnCancelar.Enabled = true;
            CleanForm();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (gridPelicula.Rows.Count != 0)
            {
                gridPelicula.Rows[0].Selected = true;
                int id = int.Parse(gridPelicula.Rows[0].Cells[0].Value.ToString());
                DAO.pelicula myItem = new DAO.pelicula();
                myItem = DAO.ColeccionArticulo.ObtenerPeliculaPorID(id);
                MostrarDetalle(myItem);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtBuscar.Text != "")
            {
                DAO.pelicula myItem = new DAO.pelicula();
                myItem = DAO.ColeccionArticulo.BuscarPelicula(txtBuscar.Text);                

                if (myItem != null)
                {
                    MostrarDetalle(myItem);
                }
            }
        }

        private void CleanForm()
        {            
            txtId.Text = "";
            txtDuracion.Text = "";
            txtAnioPublicacion.Text = "";
            txtAnioCompra.Text = "";
            txtCodigoProd.Text = "";
            txtDVD.Text = "";
            txtxTitulo.Text = "";
            cbEstado.SelectedItem = "";
        }
        private void CargarGrid(string estado = "")
        {
            gridPelicula.Columns.Clear();
            DataTable dt = new DataTable();
            
            dt.Columns.Add("Id");
            dt.Columns.Add("CodigoProducto");
            dt.Columns.Add("Titulo");
            dt.Columns.Add("Estado");

            List<DAO.pelicula> peliculas = new List<DAO.pelicula>();

            if (estado == "")
            {
                peliculas = DAO.ColeccionArticulo.TodasPeliculas();
            }
            else
            {
                peliculas = DAO.ColeccionArticulo.ObtenerPeliculasPorEstado(estado);
            }

            if (peliculas.Count > 0)
            {
                foreach (var item in peliculas)
                {
                    DataRow oItem = dt.NewRow();
                    oItem[0] = item.Id.ToString().Trim();
                    oItem[1] = item.CodigoProducto.Trim();
                    oItem[2] = item.Titulo.Trim();
                    oItem[3] = item.Estado.Trim();
                    dt.Rows.Add(oItem);
                }
                gridPelicula.DataSource = dt;

                if (gridPelicula.Rows.Count != 0)
                {
                    gridPelicula.Rows[0].Selected = true;
                    int id = int.Parse(gridPelicula.Rows[0].Cells[0].Value.ToString());
                    DAO.pelicula item = new DAO.pelicula();
                    item = DAO.ColeccionArticulo.ObtenerPeliculaPorID(id);
                    MostrarDetalle(item);
                }
            }else {
                CleanForm();
            }
        }

        private void txtAnioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAnioPublicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDVD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox item = sender as ComboBox;
            CargarGrid(item.SelectedItem.ToString() == "Todos"? "": item.SelectedItem.ToString());            
        }
    }
}
