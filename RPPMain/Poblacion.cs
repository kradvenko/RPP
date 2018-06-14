using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RPPMain
{
    public class Poblacion
    {
        #region Variables Privadas
        private int idMunicipio;
        private int idPoblacion;
        private String nombre;
        private String ambito;
        #endregion

        public Poblacion()
        {

        }

        public Poblacion(int cveMun, int cvePob)
        {
            idMunicipio = cveMun;
            idPoblacion = cvePob;
        }

        public int ClaveMunicipio
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
        public int ClavePoblacion
        {
            get
            {
                return idPoblacion;
            }
            set
            {
                idPoblacion = value;
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

        public String Ambito
        {
            get
            {
                return ambito;
            }
            set
            {
                ambito = value;
            }
        }

        public String GuardarNuevo(int idMunicipio, String nombre, String ambito)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Poblaciones VALUES (" + idMunicipio + ", '" + nombre + "','"+ambito+"')", con);
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

        public String Actualizar(int idPoblacion, int idMunicipio, String nombre,String ambito)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE Poblaciones SET poblacion = '" + nombre + "', id_municipio = " + idMunicipio +" , ambito=' "+ambito+"' WHERE id_poblacion = " + idPoblacion, con);
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
