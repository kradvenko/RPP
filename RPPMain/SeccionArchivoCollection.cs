using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class SeccionArchivoCollection
    {

        List<SeccionArchivo> listaSeccion;
        public List<SeccionArchivo> Catalogo()
        {

            listaSeccion = new List<SeccionArchivo>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM Secciones", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SeccionArchivo sec = new SeccionArchivo();
                    sec.Clave = int.Parse(reader["id_seccion"].ToString());
                    sec.Nombre = reader["seccion"].ToString();
                    sec.Descripcion = reader["descripcion"].ToString();
                    listaSeccion.Add(sec);
                }
            }
            con.Close();
            return listaSeccion;
        }


        public SeccionArchivo this[int claveSeccion]
        {
            get
            {
                return new SeccionArchivo(claveSeccion);
            }
        }
    }
}
