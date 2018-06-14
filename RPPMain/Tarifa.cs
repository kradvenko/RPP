using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RPPMain
{
    public class Tarifa
    {
        #region Variables Privadas
        private int idTarifa;
        private int clave_acto;
        private String clave_ingresos;
        private String acto;
        private float descuento;
        private float porcentaje;
        private float sm_minimo;
        private float sm_maximo;
        private float sm_fijo;
        #endregion

        public Tarifa()
        {

        }

        public Tarifa(int cveTarifa)
        {
            idTarifa = cveTarifa;
        }

        public int Clave
        {
            get
            {
                return idTarifa;
            }
            set
            {
                idTarifa = value;
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
        public String Acto
        {
            get
            {
                return acto;
            }
            set
            {
                acto = value;
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

        public float Descuento
        {
            get
            {
                return descuento;
            }
            set
            {
                descuento = value;
            }
        }

        public float Porcentaje
        {
            get
            {
                return porcentaje;
            }
            set
            {
                porcentaje = value;
            }
        }

        public float SmMinimo
        {
            get
            {
                return sm_minimo;
            }
            set
            {
                sm_minimo = value;
            }
        }

        public float SmMaximo
        {
            get
            {
                return sm_maximo;
            }
            set
            {
                sm_maximo = value;
            }
        }

        public float SmFijo
        {
            get
            {
                return sm_fijo;
            }
            set
            {
                sm_fijo = value;
            }
        }

        public String GuardarNuevo(int claveActo, String claveIngresos, decimal descuento, decimal porcentaje, decimal salariosMinimosMinimo, decimal salariosMinimosMaximo, decimal salariosMinimosFijo)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Tarifas VALUES (" + claveActo + ", '" + claveIngresos + "', @descuento, @porcentaje, @minimo, @maximo, @fijo)", con);
            comm.Parameters.AddWithValue("@descuento", Convert.ToDecimal(descuento));
            comm.Parameters.AddWithValue("@porcentaje", Convert.ToDecimal(porcentaje));
            comm.Parameters.AddWithValue("@minimo",Convert.ToDecimal(salariosMinimosMinimo));
            comm.Parameters.AddWithValue("@maximo",Convert.ToDecimal(salariosMinimosMaximo));
            comm.Parameters.AddWithValue("@fijo", Convert.ToDecimal(salariosMinimosFijo));
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

        public String Actualizar(int idTarifa, int claveActo, String claveIngresos, decimal descuento, decimal porcentaje, decimal salariosMinimosMinimo, decimal salariosMinimosMaximo, decimal salariosMinimosFijo)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE Tarifas SET clave_acto = " + claveActo + ", clave_ingresos = '" + claveIngresos + "', descuento = @descuento , porcentaje = @porcentaje, sm_min = @minimo, sm_max = @maximo , sm_fijo =@fijo WHERE id_tarifa = " + idTarifa , con);
            comm.Parameters.AddWithValue("@descuento", Convert.ToDecimal(descuento));
            comm.Parameters.AddWithValue("@porcentaje", Convert.ToDecimal(porcentaje));
            comm.Parameters.AddWithValue("@minimo", Convert.ToDecimal(salariosMinimosMinimo));
            comm.Parameters.AddWithValue("@maximo", Convert.ToDecimal(salariosMinimosMaximo));
            comm.Parameters.AddWithValue("@fijo", Convert.ToDecimal(salariosMinimosFijo));
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

        public static String ObtenerClaveActoPorId(String idActo)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT * FROM Actos WHERE id_acto = " + idActo, con);
            String claveActo = "0";

            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    claveActo = reader["clave_acto"].ToString();
                }
            }

            con.Close();
            return claveActo;
        }
    }
}
