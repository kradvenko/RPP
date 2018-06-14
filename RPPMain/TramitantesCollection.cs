using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class TramitantesCollection
    {

        List<Tramitante> listaTramitantes;
        public List<Tramitante> Catalogo()
        {

            listaTramitantes = new List<Tramitante>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM Tramitantes", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Tramitante tramitante = new Tramitante();
                    tramitante.Clave = int.Parse(reader["id_tramitante"].ToString());
                    tramitante.Nombre = reader["nombre"].ToString();
                    tramitante.ApellidoPaterno = reader["apellido_paterno"].ToString();
                    tramitante.ApellidoMaterno = reader["apellido_materno"].ToString();
                    tramitante.RazonSocial = reader["razon_social"].ToString();
                    tramitante.Rfc = reader["rfc"].ToString();
                    tramitante.Curp = reader["curp"].ToString();
                    tramitante.Calle = reader["calle"].ToString();
                    tramitante.Numero = reader["numero"].ToString();
                    tramitante.Colonia = reader["colonia"].ToString();
                    tramitante.CodigoPostal = reader["codigo_postal"].ToString();
                    tramitante.Poblacion = reader["poblacion"].ToString();
                    tramitante.Municipio = reader["municipio"].ToString();
                    tramitante.Estado = reader["estado"].ToString();
                    tramitante.LNotaria = reader["lnotaria"].ToString();
                    tramitante.NumNotaria = reader["num_notaria"].ToString();
                    tramitante.TipoTramitante = reader["tipo_tramitante"].ToString();
                    tramitante.Telefono = reader["telefono"].ToString();
                    tramitante.Fax = reader["fax"].ToString();
                    tramitante.Extension = reader["extension"].ToString();
                    listaTramitantes.Add(tramitante);
                }
            }
            con.Close();
            return listaTramitantes;
        }


        public Tramitante this[int claveTramitante]
        {
            get
            {
                return new Tramitante(claveTramitante);
            }
        }
    }
}
