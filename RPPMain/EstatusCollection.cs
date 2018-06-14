using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class EstatusCollection
    {
        List<Estatus> listaEstatus;
        
        public List<Estatus> Catalogo()
        {
            listaEstatus = new List<Estatus>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM Estatus", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Estatus est = new Estatus();
                    est.Clave = int.Parse(reader["id_estatus"].ToString());
                    est.Nombre = reader["nombre"].ToString();
                    listaEstatus.Add(est);
                }
            }
            con.Close();
            return listaEstatus;
        }

        public Estatus this[int claveEstatus]
        {
            get
            {
                return new Estatus(claveEstatus);
            }
        }
    }
}
