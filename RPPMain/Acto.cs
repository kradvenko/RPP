using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RPPMain
{
    public class Acto
    {
        #region Variables Privadas
        private int idActo;
        private int clave_acto;
        private String clave_ingresos;
        private String nombre;
        private String cuenta;
        private int idarea;
        private String area;
        private String seccion;
        private String tipo;
        #endregion

        public Acto()
        {

        }

        public Acto(int cveActo)
        {
            idActo = cveActo;
        }
        public int Clave
        {
            get
            {
                return idActo;
            }
            set
            {
                idActo = value;
            }
        }

        public int ClaveActo
        {
            get
            {
                return clave_acto;
            }
            set
            {
                clave_acto = value;
            }
           
        }

        public String ClaveIngresos
        {
            get
            {
                return clave_ingresos;
            }
            set
            {
                clave_ingresos = value;
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

        public String Cuenta
        {
            get
            {
                return cuenta;
            }
            set
            {
                cuenta = value;
            }
        }
        public int IdArea
        {
            get
            {
                return idarea;
            }
            set
            {
                idarea = value;
            }
        }

        public String Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
            }
        }

        public String Seccion
        {
            get
            {
                return seccion;
            }
            set
            {
                seccion = value;
            }
        }

        public String Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }

        public String GuardarNuevo(int claveActo, String claveIngresos, String nombre, String cuenta, int area, String secciones)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Actos VALUES (" + claveActo + ", '" + claveIngresos + "', '" + nombre + "', '" + cuenta + "', " + area + ",'"+secciones+"', '')", con);
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

        public String Actualizar(int idActo, int claveActo, String claveIngresos, String nombre, String cuenta, int area, String secciones)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE Actos SET clave_acto = " + claveActo + ", clave_ingresos = " + claveIngresos + ", nombre = '" + nombre + "', cuenta = '" + cuenta + "', area = " + area + " , seccion='"+secciones+"' WHERE id_acto = " + idActo, con);
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

        public Tarifa ObtenerTarifa(int idActo)
        {
            Tarifa tarifa = new Tarifa();
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT * FROM Tarifas WHERE clave_acto = " + idActo, con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tarifa.Clave = int.Parse(reader["clave_acto"].ToString());
                    tarifa.Descuento = float.Parse(reader["descuento"].ToString());
                    tarifa.Porcentaje = float.Parse(reader["porcentaje"].ToString());
                    tarifa.SmMinimo = float.Parse(reader["sm_min"].ToString());
                    tarifa.SmMaximo = float.Parse(reader["sm_max"].ToString());
                    tarifa.SmFijo = float.Parse(reader["sm_fijo"].ToString());
                }
            }
            else
            {
                tarifa = null;
            }
            con.Close();
            return tarifa;
        }

        public static String ObtenerSeccion(String Seccion)
        {
            String seccion = "";
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select descripcion from Secciones where seccion='"+Seccion+"'", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                     seccion = reader["descripcion"].ToString();
                }
            }

            con.Close();
            return seccion;
        }

    }
}
