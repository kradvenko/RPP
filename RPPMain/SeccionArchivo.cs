using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RPPMain
{
    public class SeccionArchivo
    {
        #region Variables Privadas
        private int idSeccion;
        private String nombre;
        private String descripcion;
        #endregion

        public SeccionArchivo()
        {

        }

        public SeccionArchivo(int cveSeccion)
        {
            idSeccion = cveSeccion;
        }

        public int Clave
        {
            get
            {
                return idSeccion;
            }
            set
            {
                idSeccion = value;
            }
        }

        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public String Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
            }
        }

        public String GuardarNuevo(String nombre, String descripcion)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Secciones VALUES ('" + nombre + "', '" + descripcion + ")", con);
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                con.Close();
                return "OK";
            }
            else
            {
                con.Close();
                return "Error.";
            }
        }

        public String Actualizar(int idSeccion, String nombre, String descripcion)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE Secciones SET seccion = '" + nombre + "', descripcion = '" + descripcion + "' WHERE id_seccion = " + idSeccion, con);
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                con.Close();
                return "OK";
            }
            else
            {
                con.Close();
                return "Error.";
            }
        }
    }
}
