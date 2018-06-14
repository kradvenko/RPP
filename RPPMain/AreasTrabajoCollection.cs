using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.SqlClient;

namespace RPPMain
{
    public class AreasTrabajoCollection
    {
        //Lista en la que se almacena el catálogo de areas de trabajo.
        List<AreaTrabajo> listaAreas;

        //Este método extrae cada área de trabajo de la base de datos, los inserta en una lista y la retorna.
        public List<AreaTrabajo> Catalogo()
        {
            listaAreas = new List<AreaTrabajo>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM AreasDeTrabajo", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    AreaTrabajo a = new AreaTrabajo();
                    a.Clave = int.Parse(reader["id_area"].ToString());
                    a.Nombre = reader["nombre"].ToString();
                    a.Descripcion = reader["descripcion"].ToString();
                    listaAreas.Add(a);
                }
            }
            con.Close();
            return listaAreas;
        }

        public AreaTrabajo this [int claveAreaTrabajo]
        {
           get
            {
                return new AreaTrabajo(claveAreaTrabajo);
            }            
        }
    }
}
