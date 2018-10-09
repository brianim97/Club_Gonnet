using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Entidades;

namespace Persistencia
{
    public class Persona
    {
        public bool AgregarPersona(Entidades.Persona p)
        {

            MySqlConnection conn = Connection.ConstructConnectorInstance();

            conn.Open();

            string sqlcommand =
                @"INSERT INTO clubgonnet.personas
                (                               
                    dni, nombre, apellido, fecha_nacimiento, fecha_ingreso, 
                    domicilio,localidad, cod_postal, telefono, mail, tipo_socio_id, 
                    es_activo, zona, imagen
                ) 
                VALUES
                (
                    @dni, @nombre, @apellido, @fecha_nacimiento, @fecha_ingreso, 
                    @domicilio, @localidad, @cod_postal, @telefono, @mail, @tipo_socio_id, 
                    @es_activo, @zona, @imagen
                );";

            MySqlCommand cmd = new MySqlCommand(sqlcommand, conn);

            cmd.Parameters.AddWithValue("@dni", p.Dni);
            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@apellido", p.Apellido);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", p.FechaNacimiento);
            cmd.Parameters.AddWithValue("@fecha_ingreso", p.FechaIngreso);
            cmd.Parameters.AddWithValue("@domicilio", p.Domicilio);
            cmd.Parameters.AddWithValue("@localidad", p.Localidad);
            cmd.Parameters.AddWithValue("@zona", p.Zona);
            cmd.Parameters.AddWithValue("@cod_postal", p.CodigoPostal);
            cmd.Parameters.AddWithValue("@telefono", p.Telefono);
            cmd.Parameters.AddWithValue("@mail", p.Mail);
            cmd.Parameters.AddWithValue("@tipo_socio_id", p.TipoSocio);
            cmd.Parameters.AddWithValue("@es_activo", p.EsActivo);
            cmd.Parameters.AddWithValue("@imagen", p.Imagen_bytes);
            

            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public Entidades.Persona RecuperarSocioPorId(int id)
        {
            var socio = new Entidades.Persona();

            MySqlConnection conn = Connection.ConstructConnectorInstance();

            string sqlString = @"SELECT * FROM clubgonnet.personas WHERE id=@id";

            MySqlCommand cmd = new MySqlCommand(sqlString, conn);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("Socios");
            da.Fill(dt);

            if (dt.Rows.Count <= 0)
                return null;
             
            socio.Nombre = dt.Rows[0]["nombre"].ToString();
            socio.Apellido = dt.Rows[0]["apellido"].ToString();
            socio.Dni = int.Parse( dt.Rows[0]["dni"].ToString());
            socio.FechaNacimiento = DateTime.Parse( dt.Rows[0]["fecha_nacimiento"].ToString());
            socio.Imagen_bytes = dt.Rows[0]["imagen"] as byte[];
            socio.Telefono = dt.Rows[0]["telefono"].ToString();
            socio.Zona = int.Parse(dt.Rows[0]["zona"].ToString());
            socio.Mail = dt.Rows[0]["mail"].ToString();
            socio.TipoSocio = (TipoSocio) dt.Rows[0]["tipo_socio_id"];
            socio.Localidad = dt.Rows[0]["localidad"].ToString();
            socio.Domicilio = dt.Rows[0]["domicilio"].ToString();



            return socio;
        }

        public bool ModificarPersona(Entidades.Persona p)
        {

            MySqlConnection conn = Connection.ConstructConnectorInstance();

            conn.Open();

            string sqlcommand =
                @"UPDATE clubgonnet.personas SET
                    dni=@dni, nombre=@nombre, apellido=@apellido, fecha_nacimiento=@fecha_nacimiento, 
                    domicilio=@domicilio,localidad=@localidad, cod_postal=@cod_postal, telefono=@telefono, 
                    mail=@mail, tipo_socio_id=@tipo_socio_id, zona=@zona, imagen=@imagen WHERE id=@id;";

            MySqlCommand cmd = new MySqlCommand(sqlcommand, conn);

            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.Parameters.AddWithValue("@dni", p.Dni);
            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@apellido", p.Apellido);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", p.FechaNacimiento);
            cmd.Parameters.AddWithValue("@domicilio", p.Domicilio);
            cmd.Parameters.AddWithValue("@localidad", p.Localidad);
            cmd.Parameters.AddWithValue("@zona", p.Zona);
            cmd.Parameters.AddWithValue("@cod_postal", p.CodigoPostal);
            cmd.Parameters.AddWithValue("@telefono", p.Telefono);
            cmd.Parameters.AddWithValue("@mail", p.Mail);
            cmd.Parameters.AddWithValue("@tipo_socio_id", p.TipoSocio);
            cmd.Parameters.AddWithValue("@imagen", p.Imagen_bytes);


            cmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public DataTable RecuperarTodaLaTabla()
        {
            MySqlConnection conn = Connection.ConstructConnectorInstance();
            string sqlCommand = @"SELECT * FROM clubgonnet.personas";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlCommand, conn);
            DataTable dt = new DataTable("Socios");
            da.Fill(dt);
            return dt; 
        }
    }
}
