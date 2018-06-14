using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class ParametrosCollection
    {
        List<Parametro> listaParametros;
        public List<Parametro> Catalogo()
        {

            listaParametros = new List<Parametro>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM Parametros", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Parametro par = new Parametro();
                    par.Clave = int.Parse(reader["id_parametro"].ToString());
                    par.Nombre = reader["nombre"].ToString();
                    par.ValorN = reader["valor_num"].ToString();
                    par.ValorC = reader["valor_car"].ToString();
                    listaParametros.Add(par);
                }
            }
            con.Close();
            return listaParametros;
        }


        public Parametro this[int claveParametro]
        {
            get
            {
                return new Parametro(claveParametro);
            }
        }
    }
}
