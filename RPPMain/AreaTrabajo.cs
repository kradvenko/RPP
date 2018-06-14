using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RPPMain
{
    public class AreaTrabajo
    {
        #region Variables Privadas
        private int idArea;
        private String descripcion;
        private String nombre;
        #endregion 

        public AreaTrabajo()
        {
            
        }

        public AreaTrabajo(int cveTrabajo)
        {
            idArea = cveTrabajo;
        }
        
        public int Clave
        {
            get
            {
                return idArea;
            }
            set
            {
                idArea = value;
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
            SqlCommand comm = new SqlCommand("INSERT INTO AreasDeTrabajo VALUES ('" + nombre + "', '" + descripcion + "')", con);
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

        public String Actualizar(int idArea, String nombre, String descripcion)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE AreasDeTrabajo SET nombre = '" + nombre + "', descripcion = '" + descripcion + "' WHERE id_area = " + idArea, con);
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
