using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RPPMain
{
    public class Municipio
    {
        #region Variables Privadas
        private int idMunicipio;
        private String nombre;
        #endregion

        public Municipio()
        {

        }

        public Municipio(int cveMunicipio){
            idMunicipio = cveMunicipio;
        }

        public int Clave
        {
            get
            {
                return idMunicipio;
            }
            set
            {
                idMunicipio = value;
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
            SqlCommand comm = new SqlCommand("INSERT INTO Municipios VALUES ('" + nombre + "')", con);
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

        public String Actualizar(int idMunicipio, String nombre)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE Municipios SET nombre = '" + nombre + "' WHERE id_municipio = " + idMunicipio, con);
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
