using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RPPMain
{
    public class TipoFolio
    {
        #region Variables Privadas
        private int idTipoFolio;
        private String nombre;
        #endregion

        public TipoFolio()
        {

        }

        public TipoFolio(int cveTipoFolio)
        {
            idTipoFolio = cveTipoFolio;
        }
        public int Clave
        {
            get
            {
                return idTipoFolio;
            }
            set
            {
                idTipoFolio = value;
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
            SqlCommand comm = new SqlCommand("INSERT INTO TipoFolios VALUES ('" + nombre + "')", con);
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

        public String Actualizar(int idTipoFolio, String nombre)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE TipoFolios SET nombre = '" + nombre +"' WHERE id_tipoFolio = " + idTipoFolio, con);
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
