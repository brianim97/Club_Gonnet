using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Principal : Form
    {
        private int childFormNumber = 0;
        

        private Personas.frm_Persona_Crear frm_Persona_Crear;
        public Personas.frm_Persona_Crear Frm_Persona_Crear
        {
            get {

                if (frm_Persona_Crear != null)
                {
                    if (frm_Persona_Crear.IsDisposed)
                    {
                        frm_Persona_Crear = null;
                    }
                    else
                    {
                        frm_Persona_Crear.BringToFront();
                    }
                }

                if (frm_Persona_Crear == null)
                {
                    frm_Persona_Crear = new Personas.frm_Persona_Crear();
                    frm_Persona_Crear.MdiParent = this;
                    frm_Persona_Crear.Show();
                }

                return frm_Persona_Crear;
            }
        }

        private Personas.frm_Persona_Buscar frm_Persona_Buscar;
        public Personas.frm_Persona_Buscar Frm_Persona_Buscar
        {
            get
            {
                if (frm_Persona_Buscar != null)
                {
                    if (frm_Persona_Buscar.IsDisposed)
                    {
                        frm_Persona_Buscar = null;
                    }
                    else
                    {
                        frm_Persona_Buscar.BringToFront();
                    }
                }

                if (frm_Persona_Buscar == null)
                {
                    frm_Persona_Buscar = new Personas.frm_Persona_Buscar(this);
                    frm_Persona_Buscar.MdiParent = this;
                    frm_Persona_Buscar.Show();
                }

                return frm_Persona_Buscar;
            }
        }

        public Personas.frm_Persona_Modificar frm_Persona_Modificar;
        public Personas.frm_Persona_Modificar Frm_Persona_Modificar
        {
            get
            {
                if (frm_Persona_Modificar != null)
                {
                    if (frm_Persona_Modificar.IsDisposed)
                    {
                        frm_Persona_Modificar = null;
                    }
                    else
                    {
                        frm_Persona_Modificar.BringToFront();
                    }
                }

                if (frm_Persona_Modificar == null)
                {
                    frm_Persona_Modificar = new Personas.frm_Persona_Modificar(this);
                    frm_Persona_Modificar.MdiParent = this;
                    frm_Persona_Modificar.Show();
                }

                return frm_Persona_Modificar;
            }
        }

        public Personas.frm_Persona_Cobro frm_Persona_Cobrar;
        public Personas.frm_Persona_Cobro Frm_Persona_Cobrar
        {
            get
            {
                if (frm_Persona_Cobrar != null)
                {
                    if (frm_Persona_Cobrar.IsDisposed)
                    {
                        frm_Persona_Cobrar = null;
                    }
                    else
                    {
                        frm_Persona_Cobrar.BringToFront();
                    }
                }

                if (frm_Persona_Cobrar == null)
                {
                    frm_Persona_Cobrar = new Personas.frm_Persona_Cobro(this);
                    frm_Persona_Cobrar.MdiParent = this;
                    frm_Persona_Cobrar.Show();
                }

                return frm_Persona_Cobrar;
            }
        }

        public Principal()
        {
            InitializeComponent();
        }



        #region Eventos

        private void Principal_Load(object sender, EventArgs e)
        {
            new Negocio.Inicializacion();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Persona_Crear = Frm_Persona_Crear;
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Persona_Buscar = Frm_Persona_Buscar;
        }


        #endregion


        #region Auto Creados por MDI 
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion




    }
}
