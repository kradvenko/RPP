using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RPPMain
{
    public class Movimientos
    {
        private int idMovimiento;
        private int idActo;
        private int tipoFolio;
        private String folio;
        private String nombre;
        private String nombreActo;
        private Acto acto;
        private int idPrelacionActo;
        private String estadoMovimiento;
        private decimal importe;

        public int ClaveActo
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
        public int ClavePrelacionActo
        {
            get
            {
                return idPrelacionActo;
            }
            set
            {
                idPrelacionActo = value;
            }
        }
        public int Clave
        {
            get
            {
                return idMovimiento;
            }
            set
            {
                idMovimiento = value;
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
        public String NombreActo
        {
            get
            {
                return nombreActo;
            }
            set
            {
                nombreActo = value;
            }
        }

        public int TipoFolio
        {
            get
            {
                return tipoFolio;
            }
            set
            {
                tipoFolio = value;
            }
        }

        public Acto Acto
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

        public String EstadoMovimiento
        {
            get
            {
                return estadoMovimiento;
            }
            set
            {
                estadoMovimiento = value;
            }
        }
        public decimal Importe
        {
            get
            {
                return importe;
            }
            set
            {
                importe = value;
            }
        }

        public String GuardarNuevo(int idActo, String nombre, int tipoFolio)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Movimientos VALUES (" + idActo + ", '" + nombre + "', " + tipoFolio + ")", con);
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

        public String Actualizar(int idMovimiento, int idActo, String nombre, int tipoFolio)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE Movimientos SET id_acto = " + idActo + ", nombre = '" + nombre + "', tipo_folio = " + tipoFolio + " WHERE id_movimiento = " + idMovimiento, con);
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
        public String Folio
        {
            get
            {
                return folio;
            }
            set
            {
                folio = value;
            }
        }
    }
}
