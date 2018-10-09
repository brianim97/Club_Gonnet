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
    public partial class frm_Persona_Modificar : Form
    {
        public bool canEdit = false;
        int socioActual = 0;
        Principal mdi;

        public frm_Persona_Modificar(Principal mainForm)
        {
            InitializeComponent();
            mdi = mainForm;
            BloquearEdicion();
        }

        public void CargarSocioParaModificar(int id)
        {
            socioActual = id;
            Entidades.Persona socio = new Negocio.Persona().RecuperarSocioPorId(id);
            
            txt_Apellido.Text = socio.Apellido;
            txt_CodPostal.Text = socio.CodigoPostal.ToString();
            txt_Dni.Text = socio.Dni.ToString();
            txt_Domicilio.Text = socio.Domicilio;
            txt_Mail.Text = socio.Mail;
            txt_Nombre.Text = socio.Nombre;
            mtxt_Telefono.Text = socio.Telefono;
            txt_Localidad.Text = socio.Localidad;
            dtp_FechaNacimiento.Value = socio.FechaNacimiento;
            lst_TipoSocio.SetSelected((int)socio.TipoSocio,true);
            pb_Imagen.Image = Negocio.Persona.ByteArrayAImagen(socio.Imagen_bytes);
            txt_Zona.Text = socio.Zona.ToString();
            txt_CodPostal.Text = socio.CodigoPostal.ToString();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            canEdit = true;
            PermitirEdicion();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (canEdit)
            {
                Entidades.Persona persona = new Entidades.Persona();

                persona.Id = socioActual;
                persona.Nombre = txt_Nombre.Text;
                persona.Apellido = txt_Apellido.Text;
                persona.Dni = Negocio.Persona.ParsearDni(txt_Dni.Text);
                persona.Domicilio = txt_Domicilio.Text;
                persona.FechaNacimiento = dtp_FechaNacimiento.Value;
                persona.Localidad = txt_Localidad.Text;
                persona.Mail = txt_Mail.Text;
                persona.Telefono = mtxt_Telefono.Text;
                persona.Imagen_bytes = Negocio.Persona.ImagenAByteArray(pb_Imagen.Image);
                persona.TipoSocio = (Entidades.TipoSocio)lst_TipoSocio.SelectedIndex;
                persona.CodigoPostal = Negocio.Persona.ParsearCodigoPostal(txt_CodPostal.Text);
                persona.Zona = Negocio.Persona.ParsearZona(txt_Zona.Text);

                if (new Negocio.Persona().ModificarPersona(persona))
                {
                    MessageBox.Show("Se modifico correctamente");
                    mdi.Frm_Persona_Buscar.RecuperarDatosUsuario();
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
        private void BloquearEdicion()
        {
            txt_Apellido.ReadOnly = true;
            txt_Nombre.ReadOnly = true;
            txt_Domicilio.ReadOnly = true;
            txt_Localidad.ReadOnly = true;
            txt_Dni.ReadOnly = true;
            txt_Mail.ReadOnly = true;
            mtxt_Telefono.ReadOnly = true;
            txt_Zona.ReadOnly = true;
            lst_TipoSocio.Enabled = false;
            txt_CodPostal.ReadOnly = true;
            dtp_FechaNacimiento.Enabled = false;
        }

        private void PermitirEdicion()
        {
            txt_Apellido.ReadOnly = false;
            txt_Nombre.ReadOnly = false;
            txt_Domicilio.ReadOnly = false;
            txt_Localidad.ReadOnly = false;
            txt_Dni.ReadOnly = false;
            txt_Mail.ReadOnly = false;
            mtxt_Telefono.ReadOnly = false;
            txt_Zona.ReadOnly = false;
            lst_TipoSocio.Enabled = true;
            txt_CodPostal.ReadOnly = false;
            dtp_FechaNacimiento.Enabled = true;
        }

        private void pb_Imagen_Click(object sender, EventArgs e)
        {
            if(canEdit)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Choose Image(*.jpg, *.png, *.gif)|*.jpg; *.png; *.gif";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    pb_Imagen.Image = Image.FromFile(fileDialog.FileName);
                }
            }
        }
    }

}
