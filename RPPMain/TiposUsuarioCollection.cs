using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RPPMain
{
    public class TiposUsuarioCollection
    {
        private List<TipoUsuario> listaTipos;

        public List<TipoUsuario> Catalogo()
        {
            listaTipos = new List<TipoUsuario>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM TipoUsuarios", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TipoUsuario est = new TipoUsuario();
                    est.Clave = int.Parse(reader["id_tipo_usuario"].ToString());
                    est.Tipo = reader["tipo"].ToString();
                    listaTipos.Add(est);
                }
            }
            con.Close();
            return listaTipos;
        }
    }
}
