using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class Tramitante
    {
        #region Variables Privadas
        private int idTramitante;
        private String nombre;
        private String apPaterno;
        private String apMaterno;
        private String razonSocial;
        private String rfc;
        private String curp;
        private String calle;
        private String numero;
        private String colonia;
        private String codigoPostal;
        private String poblacion;
        private String municipio;
        private String estado;
        private String lnotaria;
        private String numNotaria;
        private String tipoTramitante;
        private String telefono;
        private String fax;
        private String extension;
        #endregion

        public Tramitante()
        {

        }

        public Tramitante(int cveTramitante)
        {
            idTramitante = cveTramitante;
        }

        #region Propiedades
        public int Clave
        {
            get
            {
                return idTramitante;
            }
            set
            {
                idTramitante = value;
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

        public String ApellidoPaterno
        {
            get
            {
                return apPaterno;
            }
            set
            {
                apPaterno = value;
            }
        }

        public String ApellidoMaterno
        {
            get
            {
                return apMaterno;
            }
            set
            {
                apMaterno = value;
            }
        }

        public String RazonSocial
        {
            get
            {
                return razonSocial;
            }
            set
            {
                razonSocial = value;
            }
        }

        public String Rfc
        {
            get
            {
                return rfc;
            }
            set
            {
                rfc = value;
            }
        }

        public String Curp
        {
            get
            {
                return curp;
            }
            set
            {
                curp = value;
            }
        }

        public String Calle
        {
            get
            {
                return calle;
            }
            set
            {
                calle = value;
            }
        }

        public String Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }

        public String Colonia
        {
            get
            {
                return colonia;
            }
            set
            {
                colonia = value;
            }
        }

        public String CodigoPostal
        {
            get
            {
                return codigoPostal;
            }
            set
            {
                codigoPostal = value;
            }
        }

        public String Poblacion
        {
            get
            {
                return poblacion;
            }
            set
            {
                poblacion = value;
            }
        }
        public String Municipio
        {
            get
            {
                return municipio;
            }
            set
            {
                municipio = value;
            }
        }

        public String Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public String LNotaria
        {
            get
            {
                return lnotaria;
            }
            set
            {
                lnotaria = value;
            }
        }

        public String NumNotaria
        {
            get
            {
                return numNotaria;
            }
            set
            {
                numNotaria = value;
            }
        }

        public String TipoTramitante
        {
            get
            {
                return tipoTramitante;
            }
            set
            {
                tipoTramitante = value;
            }
        }

        public String Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }
        public String Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        public String Extension
        {
            get
            {
                return extension;
            }
            set
            {
                extension = value;
            }
        }
        #endregion

        public String Guardar(String nombre, String apellido_paterno, String apellido_materno, String razonsocial, String rfc, String curp, String calle, String numero, String colonia, String codigo_postal, int poblacion, int municipio, String estado, String lnotaria, String numnotaria, String tipo_tramitante, String telefono, String fax, String extension)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("INSERT INTO Tramitantes VALUES ('" + nombre + "', '" + apellido_paterno + "', '" + apellido_materno + "', '" + razonsocial + "', '" + rfc + "', '" + curp + "', '" + calle + "', '" + numero + "', '" + colonia + "', '" + codigo_postal + "', " + poblacion + ", " + municipio + ", '" + estado + "', '" + lnotaria + "', '" + numnotaria + "', '" + tipo_tramitante + "', '" + telefono + "', '" + fax + "', '" + extension + "')", con);
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                return "OK";
            }
            else
            {
                return "Error.";
            }
        }

        public String Actualizar(int id_tramitante, String nombre, String apellido_paterno, String apellido_materno, String razonsocial, String rfc, String curp, String calle, String numero, String colonia, String codigo_postal, int poblacion, int municipio, String estado, String lnotaria, String numnotaria, String tipo_tramitante, String telefono, String fax, String extension)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("UPDATE Tramitantes SET nombre='" + nombre + "', apellido_paterno='" + apellido_paterno + "', apellido_materno='" + apellido_materno + "', razon_social='" + razonsocial + "', rfc='" + rfc + "', curp='" + curp + "', calle='" + calle + "', numero='" + numero + "', colonia='" + colonia + "', codigo_postal='" + codigo_postal + "', poblacion=" + poblacion + ", municipio=" + municipio + ", estado='" + estado + "', lnotaria='" + lnotaria + "', num_notaria='" + numnotaria + "', tipo_tramitante='" + tipo_tramitante + "', telefono='" + telefono + "', fax='" + fax + "', extension='" + extension + "' where id_tramitante ='"+ id_tramitante + "'", con);
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                return "OK";
            }
            else
            {
                return "Error.";
            }
        }

        public static Tramitante ObtenerTramitantePorId(int idTramitante)
        {
            Tramitante tram = new Tramitante();
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select Municipios.nombre as mun,Poblaciones.nombre as pob, * from Tramitantes inner join Municipios on Municipios.id_municipio=Tramitantes.municipio " +
                                            " inner join Poblaciones on Poblaciones.id_poblacion=Tramitantes.poblacion and Poblaciones.id_municipio=Tramitantes.municipio  where id_tramitante='" + idTramitante + "'", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tram.Clave = int.Parse(reader["id_tramitante"].ToString());
                    tram.Nombre = reader["nombre"].ToString();
                    tram.ApellidoPaterno = reader["apellido_paterno"].ToString();
                    tram.ApellidoMaterno = reader["apellido_materno"].ToString();
                    tram.Calle = reader["calle"].ToString();
                    tram.Colonia = reader["colonia"].ToString();
                    tram.Numero = reader["numero"].ToString();
                    tram.Municipio = reader["mun"].ToString();
                    tram.Poblacion = reader["pob"].ToString();
                    tram.Estado = reader["estado"].ToString();
                    tram.CodigoPostal = reader["codigo_postal"].ToString();
                    tram.Rfc = reader["rfc"].ToString();
                }
            }
            con.Close();
            return tram;
        }
    }
}
