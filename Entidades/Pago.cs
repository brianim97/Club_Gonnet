using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pago
    {
        public Persona Persona{ get; set; }
        public Meses Mes { get; set; }
        public Actividad Actividad { get; set; }
        public TiposDePago MedioDePago { get; set; }
        public int Año { get; set; }
        public float Monto { get; set; }
        public DateTime FechaDePago { get; set; }
    }
}
