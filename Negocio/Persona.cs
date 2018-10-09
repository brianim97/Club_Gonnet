using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Entidades;

namespace Negocio
{
    public class Persona
    {


        public bool CrearPersona(Entidades.Persona persona)
        {
            return new Persistencia.Persona().AgregarPersona(persona);
        }

        public DataTable RecuperarTodaLaTabla()
        {
            return new Persistencia.Persona().RecuperarTodaLaTabla();
        }

        public Entidades.Persona RecuperarSocioPorId(int id)
        {
            return new Persistencia.Persona().RecuperarSocioPorId(id);
        }

        #region Metodos de estaticos de ayuda

        public static long ParsearDni(string codigopostal)
        {
            try
            {
                return long.Parse(codigopostal);
            }
            catch
            {
                throw new ArgumentException("Hay un error en el dni");
            }
        }

        public static int ParsearCodigoPostal(string codigopostal)
        {
            try
            {
                return int.Parse(codigopostal);
            }
            catch
            {
                throw new ArgumentException("Hay un error en el codigo postal");
            }
        }

        public static int ParsearZona(string codigoZona)
        {
            try
            {
                return int.Parse(codigoZona);
            }
            catch
            {
                throw new ArgumentException("Hay un error en la zona");
            }
        }

        public static byte[] ImagenAByteArray(Image imagen)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                imagen.Save(ms, imagen.RawFormat);
                return ms.ToArray();
            }
            catch
            {

                throw new ArgumentException("Hay un error en la imagen cargada");
            }
        }

        public static Image ByteArrayAImagen(byte[] imagenEnBytes)
        {
            try
            {
                MemoryStream ms = new MemoryStream(imagenEnBytes);
                return Image.FromStream(ms);
            }
            catch
            {
                throw new ArgumentException("Ocurrio un error al cargar la imagen");
            }
        }

        public bool ModificarPersona(Entidades.Persona persona)
        {
            return new Persistencia.Persona().ModificarPersona(persona);
        }

        #endregion
    }
}
