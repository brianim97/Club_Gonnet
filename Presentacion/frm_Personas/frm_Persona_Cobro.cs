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
    public partial class frm_Persona_Cobro : Form
    {
        private Principal principalForm;
        private int socioActual;

        public frm_Persona_Cobro(Principal mainForm)
        {
            InitializeComponent();
            principalForm = mainForm;
        }

        public void CargarSocioParaCobrar(int socioId)
        {
            socioActual = socioId;
            Entidades.Persona socio = new Negocio.Persona().RecuperarSocioPorId(socioId);

        }
    }
}
