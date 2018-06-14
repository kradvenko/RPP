using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class ActosCollection
    {
        //Lista en la que se almacena el catálogo de areas de trabajo.
        List<Acto> listaActos;

        public List<Acto> Catalogo()
        {

            listaActos = new List<Acto>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT AreasDeTrabajo.nombre as NombreArea,* FROM Actos inner join AreasDeTrabajo  on Actos.area=AreasDeTrabajo.id_area", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Acto act = new Acto();
                    act.Clave = int.Parse(reader["id_acto"].ToString());
                    act.ClaveActo = int.Parse(reader["clave_acto"].ToString());
                    act.ClaveIngresos = reader["clave_ingresos"].ToString();
                    act.Nombre = reader["nombre"].ToString();
                    act.Cuenta = reader["cuenta"].ToString();
                    act.IdArea = int.Parse(reader["area"].ToString());
                    act.Area = reader["NombreArea"].ToString();
                    act.Seccion = reader["seccion"].ToString();
                    listaActos.Add(act);
                }
            }
            con.Close();
            return listaActos;
        }
        public Acto this[int claveActo]
        {
            get
            {
                return new Acto(claveActo);
            }
        }
    }
}
