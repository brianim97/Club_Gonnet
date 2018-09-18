using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        public int Id { get; set; }

        public string Dni { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public string Domicilio { get; set; }

        public int CodigoPostal { get; set; }

        public string Telefono { get; set; }

        public string Mail { get; set; }

        public TipoSocio TipoSocio { get; set; }

        public bool EsActivo { get; set; }
    }
}
