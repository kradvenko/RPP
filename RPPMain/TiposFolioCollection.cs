using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class TiposFolioCollection
    {
        List<TipoFolio> listaFolios;
        public List<TipoFolio> Catalogo()
        {

            listaFolios = new List<TipoFolio>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM TipoFolios", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TipoFolio folio = new TipoFolio();
                    folio.Clave = int.Parse(reader["id_tipoFolio"].ToString());
                    folio.Nombre = reader["nombre"].ToString();
                    listaFolios.Add(folio);
                }
            }
            con.Close();
            return listaFolios;
        }


        public TipoFolio this[int claveTipoFolio]
        {
            get
            {
                return new TipoFolio(claveTipoFolio);
            }
        }
    }
}
