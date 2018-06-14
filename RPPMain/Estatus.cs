using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RPPMain
{
    public class Estatus
    {
        #region Variables Privadas
        private int idEstatus;
        private String nombre;
        #endregion

        public Estatus()
        {

        }

        public Estatus(int cveEstatus)
        {
            idEstatus = cveEstatus;
        }

        public int Clave
        {
            get
            {
                return idEstatus;
            }
            set
            {
                idEstatus = value;
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

        public String GuardarNuevo(String nombre)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Estatus VALUES ('" + nombre + "')", con);
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

        public String Actualizar(int idEstatus, String nombre)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE Estatus SET nombre = '" + nombre + "' WHERE id_estatus = " + idEstatus, con);
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
