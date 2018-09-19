using System;
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
    public partial class frm_Persona_Crear : Form
    {
        /// <summary>
        /// Funciones de inicializacion de la clase.
        /// </summary>
        public frm_Persona_Crear()
        {
            InitializeComponent();
            dtp_FechaNacimiento.Value = DateTime.Today;
            lst_TipoSocio.SelectedItem = lst_TipoSocio.Items[0];
        }





        /// <summary>
        /// Crea una Entidad.Persona y la envia para su procesamiento y persistencia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            var persona = new Entidades.Persona();

            persona.Nombre = txt_Nombre.Text;
            persona.Apellido = txt_Nombre.Text;
            persona.Dni= txt_Dni.Text;
            persona.Domicilio = txt_Domicilio.Text;
            persona.FechaNacimiento = dtp_FechaNacimiento.Value;
            persona.FechaIngreso = DateTime.Today;
            persona.EsActivo = false;
            persona.Mail = txt_Mail.Text;
            try { persona.CodigoPostal = Int32.Parse(txt_CodPostal.Text); }
            catch { lbl_Log.Text = "Error al ingresar codigo postal"; return; }
            
            persona.TipoSocio = persona.ConvertirATipoSocio(lst_TipoSocio.SelectedIndex);

            if(new Negocio.Persona().CrearPersona(persona))
            {
                lbl_Log.Text = "El contacto fue agregado correctamente";
            }
        }





        /// <summary>
        /// Limpia todos los campos del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Limpiar_Click(object sender, EventArgs e)
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
        }
    }
}
