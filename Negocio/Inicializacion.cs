using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Inicializacion
    {
        public void Init()
        {
            Persistencia.Connection.LoadConnectionString();
        }
    }
}
