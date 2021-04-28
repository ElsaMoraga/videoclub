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
    public partial class FormListaAlquiler : Form
    {
        public FormListaAlquiler()
        {
            InitializeComponent();
        }

        private void FormListaAlquiler_Load(object sender, EventArgs e)
        {
            gridAlquileres.Columns.Clear();
            DataTable dt = new DataTable();
            double total = 0;
            dt.Columns.Add("idAlquiler");
            dt.Columns.Add("NIF");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Titulo");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Dias");
            dt.Columns.Add("TotalPagar");

            foreach (var item in DAO.ColeccionAlquiler.ListarAlquiler())
            {
                DataRow oItem = dt.NewRow();
                oItem[0] = item.idAlquiler.ToString().Trim();
                oItem[1] = item.cliente.NIF.Trim();
                oItem[2] = item.cliente.Nombre.Trim() + " " + item.cliente.Apellido.Trim();
                oItem[3] = item.articulo.Titulo.Trim();
                oItem[4] = ((DateTime)item.Fecha).ToString("dd/MM/yyyy");
                oItem[5] = item.Dias.ToString();
                oItem[6] = item.TotalPagar.ToString();
                dt.Rows.Add(oItem);
                total += (Double)item.TotalPagar;
            }

            txtCantidad.Text = dt.Rows.Count.ToString();
            txtTotal.Text = total.ToString();
            gridAlquileres.DataSource = dt;
        }
    }
}
