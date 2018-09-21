using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Personas
{
    
    public partial class frm_Persona_Crear : Form
    {

        //Autocompletar el formulario al iniciar la ventana
        bool autofill = true;

        #region Inicializacion
        /// <summary>
        /// Funciones de inicializacion de la clase.
        /// </summary>
        public frm_Persona_Crear()
        {
            InitializeComponent();
            dtp_FechaNacimiento.Value = DateTime.Today;
            lst_TipoSocio.SelectedItem = lst_TipoSocio.Items[0];

            if(autofill)
            {
                txt_Apellido.Text = "Punta";
                txt_CodPostal.Text = "1864";
                txt_Dni.Text = "32868994";
                txt_Domicilio.Text = "MAFFIA 343";
                txt_Mail.Text = "patito.cuak@gmail.com";
                txt_Nombre.Text = "Jorge";
                mtxt_Telefono.Text = "0221155708240";
                txt_Localidad.Text = "ALEJANDRO KORN";
                dtp_FechaNacimiento.Value = new DateTime(1987,3,8);
                lst_TipoSocio.SelectedItem = lst_TipoSocio.Items[2];
                pb_Imagen.Image = Properties.Resources.NoUser;
                txt_Zona.Text = "20";
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Crea una Entidad.Persona y la envia para su procesamiento y persistencia.
        /// </summary>

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            try
            {
                var persona = new Entidades.Persona();
                RecolectarCampos(persona);

                if (new Negocio.Persona().CrearPersona(persona))
                {
                    MessageBox.Show("El contacto fue agregado correctamente");
                    limpiarCampos();
                }
            }
            catch (ArgumentException ex)
            {
                lbl_Log.Text = ex.Message;
            }
        }


        /// <summary>
        /// evento del boton limpiar: reestablece todos los campos del formulario.
        /// </summary>
        
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        /// <summary>
        /// Evento de la imagen: abre un selector de imagen y permite elegir una.
        /// </summary>

        private void pb_Imagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Choose Image(*.jpg, *.png, *.gif)|*.jpg; *.png; *.gif";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                pb_Imagen.Image = Image.FromFile(fileDialog.FileName);
            }
        }

        #endregion

        #region Metodos de consumo privado

        private void limpiarCampos()
        {
            txt_Apellido.Clear();
            txt_CodPostal.Clear();
            txt_Dni.Clear();
            txt_Domicilio.Clear();
            txt_Mail.Clear();
            txt_Nombre.Clear();
            mtxt_Telefono.Clear();
            txt_Localidad.Clear();
            dtp_FechaNacimiento.Value = DateTime.Today;
            lst_TipoSocio.SelectedItem = lst_TipoSocio.Items[0];
            pb_Imagen.Image = Properties.Resources.NoUser;
            lbl_Log.Text = string.Empty;
        }

        private void RecolectarCampos(Entidades.Persona persona)
        {
            persona.Nombre = txt_Nombre.Text;
            persona.Apellido = txt_Apellido.Text;
            persona.Dni = Negocio.Persona.ParsearDni(txt_Dni.Text);
            persona.Domicilio = txt_Domicilio.Text;
            persona.FechaNacimiento = dtp_FechaNacimiento.Value;
            persona.FechaIngreso = DateTime.Today;
            persona.Localidad = txt_Localidad.Text;
            persona.EsActivo = false;
            persona.Mail = txt_Mail.Text;
            persona.Telefono = mtxt_Telefono.Text;
            persona.Imagen_bytes = Negocio.Persona.ImagenAByteArray(pb_Imagen.Image);
            persona.TipoSocio = (Entidades.TipoSocio)lst_TipoSocio.SelectedIndex;
            persona.CodigoPostal = Negocio.Persona.ParsearCodigoPostal(txt_CodPostal.Text);
            persona.Zona = Negocio.Persona.ParsearZona(txt_Zona.Text);
        }

        #endregion

    }
}
