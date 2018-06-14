using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class MunicipiosCollection
    {
        List<Municipio> listaMunicipios;
        public List<Municipio> Catalogo()
        {

            listaMunicipios = new List<Municipio>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM Municipios", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Municipio mun = new Municipio();
                    mun.Clave = int.Parse(reader["id_municipio"].ToString());
                    mun.Nombre = reader["nombre"].ToString();
                    listaMunicipios.Add(mun);
                }
            }
            con.Close();
            return listaMunicipios;
        }


        public Municipio this[int claveMunicipio]
        {
            get
            {
                return new Municipio(claveMunicipio);
            }
        }
    }
}
