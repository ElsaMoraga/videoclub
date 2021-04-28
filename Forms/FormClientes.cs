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
    public partial class FormEditCliente : Form
    {
        public FormEditCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DAO.cliente newCliente = new DAO.cliente();
            Regex mRegxExpression;
            if (txtEmail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("E-mail invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
            }

            if (txtNif.Text.Length > 8)
            {
                MessageBox.Show("NIF invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            if (txtTelefono1.Text.Length > 9)
            {
                MessageBox.Show("Telefono 1 invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono1.Focus();
                return;
            }

            if (txtTelefono2.Text.Length > 9)
            {
                MessageBox.Show("Telefono 1 invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono2.Focus();
                return;
            }

            newCliente.Nombre = txtNombre.Text;
            newCliente.Apellido = txtApellido.Text;
            newCliente.Direccion = txtDireccion.Text;
            newCliente.NIF = txtNif.Text;
            newCliente.Telefono1 = txtTelefono1.Text;
            newCliente.Telefono2 = txtTelefono2.Text;
            newCliente.Email = txtEmail.Text;
            newCliente.FechaAlta = DateTime.Today;
            newCliente.Estado = (cbEstado.SelectedItem == null) ? "Activo": cbEstado.SelectedItem.ToString();
            newCliente.VIP = bVIP.Checked;


            if (txtId.Text == "")
            {
                int id = DAO.ColeccionCliente.AgregarCliente(newCliente);
                if (id > 0)
                {
                    MessageBox.Show("Cliente " + id.ToString() + " creado satisfactoriamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                }
                else
                {
                    MessageBox.Show("Error al grabar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                newCliente.idCliente = int.Parse(txtId.Text);
                if (DAO.ColeccionCliente.ActualizarCliente(newCliente))
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

        private void MostrarDetalle(DAO.cliente myCliente)
        {            
            txtId.Text = myCliente.idCliente.ToString();
            txtNif.Text = myCliente.NIF;
            txtApellido.Text = myCliente.Apellido;
            txtDireccion.Text = myCliente.Direccion;
            txtEmail.Text = myCliente.Email;
            txtNombre.Text = myCliente.Nombre;
            txtTelefono1.Text = myCliente.Telefono1;
            txtTelefono2.Text = myCliente.Telefono2;
            cbEstado.SelectedItem = myCliente.Estado;
            bVIP.Checked = bool.Parse(myCliente.VIP.ToString());
            txtFecha.Text = myCliente.FechaAlta.ToString();
            cbEstado.SelectedIndex = myCliente.Estado == null ? -1 : cbEstado.Items.IndexOf(myCliente.Estado.Trim());
        }

        private void gridCliente_SelectionChanged(object sender, EventArgs e)
        {
            if(gridCliente.SelectedRows.Count > 0)
            {
                int id = int.Parse(gridCliente.SelectedRows[0].Cells[0].Value.ToString());
                DAO.cliente myCliente = new DAO.cliente();
                myCliente = DAO.ColeccionCliente.ObtenerClientesPorID(id);
                MostrarDetalle(myCliente);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNif.Text = ""; 
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtTelefono1.Text = "";
            txtTelefono2.Text = "";
            cbEstado.SelectedItem = "";
            bVIP.Checked = false;
            txtFecha.Text = DateTime.Today.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (gridCliente.Rows.Count != 0)
            {
                gridCliente.Rows[0].Selected = true;
                int id = int.Parse(gridCliente.Rows[0].Cells[0].Value.ToString());
                DAO.cliente myCliente = new DAO.cliente();
                myCliente = DAO.ColeccionCliente.ObtenerClientesPorID(id);
                MostrarDetalle(myCliente);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtBuscar.Text != "")
            {
                DAO.cliente myCliente = new DAO.cliente();
                myCliente = DAO.ColeccionCliente.BuscarCliente(txtBuscar.Text);

                if(myCliente != null)
                {
                    MostrarDetalle(myCliente);
                }
            }
        }
        private void CargarGrid()
        {
            gridCliente.Columns.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("IdCliente");
            dt.Columns.Add("NIF");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido");

            foreach (var item in DAO.ColeccionCliente.ObtenerClientes())
            {
                DataRow oItem = dt.NewRow();
                oItem[0] = item.idCliente;
                oItem[1] = item.NIF;
                oItem[2] = item.Nombre;
                oItem[3] = item.Apellido;
                dt.Rows.Add(oItem);
            }
            gridCliente.DataSource = dt;

            if (gridCliente.Rows.Count != 0)
            {
                gridCliente.Rows[0].Selected = true;
                int id = int.Parse(gridCliente.Rows[0].Cells[0].Value.ToString());
                DAO.cliente myCliente = new DAO.cliente();
                myCliente = DAO.ColeccionCliente.ObtenerClientesPorID(id);
                MostrarDetalle(myCliente);
            }
        }

        private void txtTelefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
