﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Personas
{
    public partial class frm_Persona_Buscar : Form
    {
        DataTable dataTable;
        DataTable v;

        public frm_Persona_Buscar()
        {
            InitializeComponent();
            RecuperarDatosUsuario();
            
        }

        public void RecuperarDatosUsuario()
        {
            dataTable = new Negocio.Persona().RecuperarTodaLaTabla();
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Imagen"].Visible = false;
        }

        private void txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
                v = dataGridView1.DataSource as DataTable;
             
                v.DefaultView.RowFilter = "Apellido like '%" + txt_Busqueda.Text + "%' OR " +
                "Dni like '%" + txt_Busqueda.Text + "%'";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count <= 0)
                return;

            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            byte[] imgEnBytes = dataGridView1["Imagen", rowIndex].Value as byte[];
            if(imgEnBytes != null)
                pictureBox1.Image = Negocio.Persona.ByteArrayAImagen(imgEnBytes);
        }
    }
}
