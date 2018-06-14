using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class Parametro
    {
        #region Variables Privadas
        private int idParametro;
        private String nombre;
        private String valorNumerico;
        private String valorCaracter;
        #endregion 

        public Parametro()
        {

        }

        public Parametro(int cveParametro)
        {
            idParametro = cveParametro;
        }

        public int Clave
        {
            get
            {
                return idParametro;
            }
            set
            {
                idParametro = value;
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

        public String ValorN
        {
            get
            {
                return valorNumerico;
            }
            set
            {
                valorNumerico = value;
            }
        }

        public String ValorC
        {
            get
            {
                return valorCaracter;
            }
            set
            {
                valorCaracter = value;
            }
        }
        public String GuardarNuevo(String nombre, String valornum, String valorcar)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Parametros VALUES ('" + nombre + "', '" + valornum + "', '" + valorcar + "')", con);
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

        public String Actualizar(int idParametro, String nombre, String valornum, String valorcar)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE Parametros SET nombre = '" + nombre + "', valor_num = '" + valornum + "', valor_car = '" + valorcar + "' WHERE id_parametro = " + idParametro, con);
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

        public String ObtenerSalario()
        {
            String salario="";
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select * from Parametros where nombre='salario minimo'", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    salario = reader["valor_num"].ToString();
                }
            }
            else
            {
                salario = "";
            }
            con.Close();
            return salario;
        }
    }
}
