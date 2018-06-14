using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.SqlClient;

namespace RPPMain
{
    public class MovimientosCollection
    {
        List<Movimientos> listaMovimientos;

        //Este método retorna una lista de los movimientos.
        public List<Movimientos> Catalogo()
        {
            listaMovimientos = new List<Movimientos>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("select TipoFolios.nombre as folio,* from Movimientos inner join TipoFolios on Movimientos.tipo_folio=TipoFolios.id_tipoFolio", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Movimientos a = new Movimientos();
                    a.ClaveActo = int.Parse(reader["id_acto"].ToString());
                    a.Nombre = reader["nombre"].ToString();
                    a.Clave = int.Parse(reader["id_movimiento"].ToString());
                    a.TipoFolio = int.Parse(reader["tipo_folio"].ToString());
                    a.Folio = reader["folio"].ToString();
                    listaMovimientos.Add(a);
                }
            }
            con.Close();
            return listaMovimientos;
        }
        //Este método retorna una lista de los movimientos de un acto en particular.
        public List<Movimientos> Catalogo(int idActo)
        {
            listaMovimientos = new List<Movimientos>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("select TipoFolios.nombre as folio,* from Movimientos inner join TipoFolios on Movimientos.tipo_folio=TipoFolios.id_tipoFolio WHERE id_acto = " + idActo.ToString(), con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Movimientos a = new Movimientos();
                    a.ClaveActo = int.Parse(reader["id_acto"].ToString());
                    a.Nombre = reader["nombre"].ToString();
                    a.Clave = int.Parse(reader["id_movimiento"].ToString());
                    a.TipoFolio = int.Parse(reader["tipo_folio"].ToString());
                    a.Folio = reader["folio"].ToString();
                    listaMovimientos.Add(a);
                }
            }
            con.Close();
            return listaMovimientos;
        }
    }
}
