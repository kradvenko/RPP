using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class TarifasCollection
    {
        List<Tarifa> listaTarifas;
        public List<Tarifa> Catalogo()
        {

            listaTarifas = new List<Tarifa>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT nombre,* FROM Tarifas inner join Actos on Tarifas.clave_acto=Actos.clave_acto", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Tarifa tar = new Tarifa();
                    tar.Clave = int.Parse(reader["id_tarifa"].ToString());
                    tar.ClaveActo = int.Parse(reader["clave_acto"].ToString());
                    tar.Acto = reader["nombre"].ToString();
                    tar.ClaveIngresos = reader["clave_ingresos"].ToString();
                    tar.Descuento = float.Parse(reader["descuento"].ToString());
                    tar.Porcentaje = float.Parse(reader["porcentaje"].ToString());
                    tar.SmMinimo = float.Parse(reader["sm_min"].ToString());
                    tar.SmMaximo= float.Parse(reader["sm_max"].ToString());
                    tar.SmFijo= float.Parse(reader["sm_fijo"].ToString());
                    listaTarifas.Add(tar);
                }
            }
            con.Close();
            return listaTarifas;
        }


        public Tarifa this[int claveTarifa]
        {
            get
            {
                return new Tarifa(claveTarifa);
            }
        }
    }
}
