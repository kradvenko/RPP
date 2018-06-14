using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RPPMain
{
    public class Ubicacion
    {
        /*
         * Esta clase controla los datos relativos a la ubicación de un predio, pero únicamente los que se encuentran en
         * los catálogos de Colonias, Calles y Numeros.
        */
        int idColonia;
        int idCalle;
        int idNumero;
        String colonia;
        String calle;
        String numero;

        public Ubicacion()
        {

        }

        public int IdColonia
        {
            get
            {
                return idColonia;
            }
            set
            {
                idColonia = value;
            }
        }

        public int IdCalle
        {
            get
            {
                return idCalle;
            }
            set
            {
                idCalle = value;
            }
        }

        public int IdNumero
        {
            get
            {
                return idNumero;
            }
            set
            {
                idNumero = value;
            }
        }

        public String Colonia
        {
            get
            {
                return colonia;
            }
            set
            {
                colonia = value;
            }
        }

        public String Calle
        {
            get
            {
                return calle;
            }
            set
            {
                calle = value;
            }
        }

        public String Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }

        public static List<Ubicacion> ListaColonias()
        {
            List<Ubicacion> listaColonias = new List<Ubicacion>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM CatalogoColonias ORDER BY Nomasen", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Ubicacion ub = new Ubicacion();
                    ub.IdColonia = int.Parse(reader["id"].ToString());
                    ub.Colonia = reader["Tipo"].ToString() + " - " + reader["Nomasen"].ToString();
                    listaColonias.Add(ub);
                }
            }
            con.Close();
            return listaColonias;
        }

        public static List<Ubicacion> ListaCalles(int IdColonia)
        {
            List<Ubicacion> listaCalles = new List<Ubicacion>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT Tipovial, Nomvial FROM CatalogoCalles WHERE id_colonia = " + IdColonia + " GROUP BY Tipovial, Nomvial ORDER BY Nomvial", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Ubicacion ub = new Ubicacion();
                    ub.Calle = reader["Tipovial"].ToString() + " - " + reader["Nomvial"].ToString();

                    SqlConnection con2 = new SqlConnection(Connection.getConnection());
                    con2.Open();
                    SqlCommand comm2 = new SqlCommand("SELECT * FROM CatalogoCalles WHERE id_colonia = " + IdColonia + " AND NomVial = '" + reader["NomVial"].ToString() + "'", con2);
                    SqlDataReader reader2 = comm2.ExecuteReader();
                    reader2.Read();
                    ub.IdCalle = int.Parse(reader2["id"].ToString());
                    con2.Close();
                    listaCalles.Add(ub);
                }
            }
            con.Close();
            return listaCalles;
        }

        public static List<Ubicacion> ListaNumerosCalles(String Calle)
        {
            List<Ubicacion> listaNumerosCalles = new List<Ubicacion>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * " +
                                                "FROM catalogonumerocalles " +
                                                "INNER JOIN catalogocalles " +
                                                "ON catalogocalles.id = catalogonumerocalles.id_calle " +
                                                "WHERE (catalogocalles.Tipovial + ' - ' + catalogocalles.Nomvial) = '" + Calle + "' AND CatalogoNumeroCalles.Ne_numero != '' " +
                                                "ORDER BY ne_numero", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Ubicacion ub = new Ubicacion();
                    ub.IdCalle = int.Parse(reader["id_calle"].ToString());
                    ub.IdNumero = int.Parse(reader["id_numero"].ToString());
                    ub.Numero = reader["Ne_numero"].ToString() + " - " + reader["Ne_alf"].ToString();
                    listaNumerosCalles.Add(ub);
                }
            }
            con.Close();
            return listaNumerosCalles;
        }

        public static int ObtenerIdCalle(int IdNumeroCalle)
        {
            int idCalleEncontrada = 0;
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT * FROM catalogonumerocalles", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idCalleEncontrada = int.Parse(reader["id_calle"].ToString());
                }
            }
            con.Close();
            return idCalleEncontrada;
        }

    }
}
