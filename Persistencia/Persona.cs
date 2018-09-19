﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Persistencia
{
    public class Persona
    {
        public void AgregarPersona(Entidades.Persona p)
        {
            MySqlConnection conn = Connection.ConstructConnectorInstance();

            conn.Open();

            string sqlcommand =
                @"INSERT INTO clubgonnet.personas 
                (                               
                    dni, nombre, apellido, fecha_nacimiento, fecha_ingreso, 
                    domicilio,localidad, cod_postal, telefono, mail, tipo_socio_id, 
                    es_activo, zona
                ) 
                VALUES
                (
                    @dni, @nombre, @apellido, @fecha_nacimiento, @fecha_ingreso, 
                    @domicilio, @localidad, @cod_postal, @telefono, @mail, @tipo_socio_id, 
                    @es_activo, @zona
                );";

            MySqlCommand cmd = new MySqlCommand(sqlcommand, conn);

            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@apellido", p.Apellido);
            cmd.Parameters.AddWithValue("@fecha_nacimiento", p.FechaNacimiento);
            cmd.Parameters.AddWithValue("@fecha_ingreso", p.FechaIngreso);
            cmd.Parameters.AddWithValue("@domicilio", p.Domicilio);
            cmd.Parameters.AddWithValue("@localidad", p.Localidad);
            cmd.Parameters.AddWithValue("@zona", p.Zona);
            cmd.Parameters.AddWithValue("@cod_postal)", p.CodigoPostal);
            cmd.Parameters.AddWithValue("@telefono", p.Telefono);
            cmd.Parameters.AddWithValue("@mail", p.Mail);
            cmd.Parameters.AddWithValue("@tipo_socio_id", p.TipoSocio);
            cmd.Parameters.AddWithValue("@es_activo", p.EsActivo);


            cmd.ExecuteNonQuery();
            conn.Close();


        }
    }
}