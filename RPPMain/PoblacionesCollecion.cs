using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class PoblacionesCollecion
    {
        List<Poblacion> listaPoblaciones;

        public List<Poblacion> Catalogo()
        {

            listaPoblaciones = new List<Poblacion>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("select Municipios.id_municipio, id_poblacion, Municipios.nombre as municipio, Poblaciones.nombre as poblacion, ambito from Poblaciones inner join Municipios "+
                                             " on Poblaciones.id_municipio=Municipios.id_municipio order by Municipios.id_municipio, id_poblacion ASC", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Poblacion pob = new Poblacion();
                    pob.ClaveMunicipio = int.Parse(reader["id_municipio"].ToString());
                    pob.ClavePoblacion = int.Parse(reader["id_poblacion"].ToString());
                    pob.Nombre = reader["poblacion"].ToString();
                    pob.Ambito = reader["ambito"].ToString();
                    listaPoblaciones.Add(pob);
                }
            }
            con.Close();
            return listaPoblaciones;
        }

        public List<Poblacion> CatalogoPorMunicipio(int idMunicipio)
        {

            listaPoblaciones = new List<Poblacion>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * from Poblaciones where Poblaciones.id_municipio = " + idMunicipio + " order by id_poblacion ASC", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Poblacion pob = new Poblacion();
                    pob.ClaveMunicipio = int.Parse(reader["id_municipio"].ToString());
                    pob.ClavePoblacion = int.Parse(reader["id_poblacion"].ToString());
                    pob.Nombre = reader["nombre"].ToString();
                    pob.Ambito = reader["ambito"].ToString();
                    listaPoblaciones.Add(pob);
                }
            }
            con.Close();
            return listaPoblaciones;
        }

        public Poblacion this[int claveMunicipio, int clavePoblacion]
        {
            get
            {
                return new Poblacion(claveMunicipio,clavePoblacion);
            }
        }
    }
}
