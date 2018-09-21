using System;
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

        public long Dni { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public string Domicilio { get; set; }

        public string Localidad { get; set; }

        public int Zona { get; set; }

        public int CodigoPostal { get; set; }

        public string Telefono { get; set; }

        public string Mail { get; set; }

        public TipoSocio TipoSocio { get; set; }

        public bool EsActivo { get; set; }

        public byte[] Imagen_bytes { get; set; }

        public Persona()
        {

        }

        public Persona(long dni, string nombre, string apellido, DateTime fechaNacimiento, DateTime fechaIngreso, string domicilio, string localidad, int codigoPostal, int zona, string telefono, string mail, TipoSocio tipoSocio, byte[] imageByte ,bool esActivo = false)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNacimiento = FechaNacimiento;
            this.FechaIngreso = FechaIngreso;
            this.Domicilio = domicilio;
            this.CodigoPostal = codigoPostal;
            this.Zona = zona;
            this.Localidad = localidad;
            this.Telefono = telefono;
            this.Mail = mail;
            this.TipoSocio = TipoSocio;
            this.Imagen_bytes = imageByte;
            this.EsActivo = esActivo;
                
        }

    }
}
