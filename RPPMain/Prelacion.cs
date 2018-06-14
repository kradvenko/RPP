using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RPPMain
{
    public class Prelacion
    {
        #region Variables Privadas
        private int idPrelacion;
        private int idTramitante;
        private String idUsuario;
        private String usuario;
        private String nombreTitular;
        private String descripcionBien;
        private String numeroEscritura;
        List<Antecedente> antecedentes;
        List<Movimientos> actosprelacion;
        private decimal valorInmueble;
        private String folio;
        private decimal total;
        private String status;
        private String fecha;
        private String nombreTramitante;
        private String tipoDocumento;
        private String lugarOtorgamiento;
        private String tipoMoneda;
        private String fechaDocumento;
        private String observacionesVerificador;
        private Movimientos movimiento;
        private String nombreActo;
        private String fechaAsignacion;

        //Special
        private String repositoryUrl;
        private String nombreRecibe;
        private String numeroDocumento;
        private String partida;
        #endregion

        public Prelacion()
        {

        }

        public int IdPrelacion
        {
            get
            {
                return idPrelacion;
            }
            set
            {
                idPrelacion = value;
            }
        }

        public int IdTramitante
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

        public String IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
            }
        }

        public String Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }

        public String NombreTitular
        {
            get
            {
                return nombreTitular;
            }
            set
            {
                nombreTitular = value;
            }
        }

        public String DescripcionBien
        {
            get
            {
                return descripcionBien;
            }
            set
            {
                descripcionBien = value;
            }
        }

        public String NumeroEscritura
        {
            get
            {
                return numeroEscritura;
            }
            set
            {
                numeroEscritura = value;
            }
        }

        public decimal ValorInmueble
        {
            get
            {
                return valorInmueble;
            }
            set
            {
                valorInmueble = value;
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

        public decimal Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }

        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public String Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }

        public String Tramitante
        {
            get
            {
                return nombreTramitante;
            }
            set
            {
                nombreTramitante = value;
            }
        }

        public String TipoDocumento
        {
            get
            {
                return tipoDocumento;
            }
            set
            {
                tipoDocumento = value;
            }
        }

        public String LugarOtorgamiento
        {
            get
            {
                return lugarOtorgamiento;
            }
            set
            {
                lugarOtorgamiento = value;
            }
        }

        public String TipoMoneda
        {
            get
            {
                return tipoMoneda;
            }
            set
            {
                tipoMoneda = value;
            }
        }

        public String FechaDocumento
        {
            get
            {
                return fechaDocumento;
            }
            set
            {
                fechaDocumento = value;
            }
        }

        public String ObservacionesVerificador
        {
            get
            {
                return observacionesVerificador;
            }
            set
            {
                observacionesVerificador = value;
            }
        }
        public List<Antecedente> Antecedentes
        {
            get
            {
                return antecedentes;
            }
            set
            {
                antecedentes = value;
            }
        }
        public List<Movimientos> ActosPrelacion
        {
            get
            {
                return actosprelacion;
            }
            set
            {
                actosprelacion = value;
            }
        }

        public Movimientos Movimiento
        {
            get
            {
                return movimiento;
            }
            set
            {
                movimiento = value;
            }
        }

        public String RepositoryUrl
        {
            get
            {
                return repositoryUrl;
            }
            set
            {
                repositoryUrl = value;
            }
        }

        public String NombreRecibe
        {
            get
            {
                return nombreRecibe;
            }
            set
            {
                nombreRecibe = value;
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

        public String FechaAsignacion
        {
            get
            {
                return fechaAsignacion;
            }
            set
            {
                fechaAsignacion = value;
            }
        }

        public String NumeroDocumento
        {
            get
            {
                return numeroDocumento;
            }
            set
            {
                numeroDocumento = value;
            }
        }

        public String Partida
        {
            get
            {
                return partida;
            }
            set
            {
                partida = value;
            }
        }

        public static String GuardarPrelacionObjeto(Prelacion prelacion)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            int idPre = 0;
            using (SqlTransaction transaction = con.BeginTransaction())
            {
                try
                {
                    idPre = prelacion.GuardarNueva(prelacion.idTramitante, prelacion.NombreTitular, prelacion.DescripcionBien, prelacion.NumeroEscritura, prelacion.ValorInmueble, prelacion.Folio, prelacion.Total, prelacion.Status, prelacion.Fecha, prelacion.LugarOtorgamiento, prelacion.TipoDocumento, prelacion.TipoMoneda, prelacion.FechaDocumento);
                    if (idPre == 0) { throw new Exception(); }

                    foreach (Movimientos item in prelacion.actosprelacion)
                    {
                        int res = prelacion.GuardarActosPrelacion(idPre, item.ClaveActo, item.Clave, item.Importe);
                        if (res != 0) { throw new Exception(); }
                    }

                    foreach (Antecedente item in prelacion.antecedentes)
                    {
                        int res = prelacion.GuardarAntecedentesPrelacion(idPre, item.Libro, item.Tomo, item.Semestre, item.Seccion, item.Serie, item.Partida, item.Año, item.Folio);
                        if (res != 0) { throw new Exception(); }
                    }
                    transaction.Commit();
                    con.Close();
                }
                catch (Exception exc)
                {
                    transaction.Rollback();
                    return "ERROR: " + exc.Message;
                }
            }
            return idPre.ToString();
        }

        public int GuardarNueva(int IdTramitante, String NombreTitular, String DescripcionBien, String NumeroEscritura, decimal ValorInmueble, String Folio, decimal Total, String Status, String Fecha, String LugarOtorgamiento, String TipoDocumento, String TipoMoneda, String FechaDocumento)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Prelaciones OUTPUT inserted.id_prelacion VALUES (" + IdTramitante + ", '" + NombreTitular + "', '" + DescripcionBien + "', '" + NumeroEscritura + "', @valorI , '" + Folio + "', @total , '" + Status + "', '" + Fecha + "', '" + LugarOtorgamiento + "', '" + TipoDocumento + "', '" + TipoMoneda + "', '" + FechaDocumento + "', '" + "', '')", con);
            comm.Parameters.AddWithValue("@valorI", Convert.ToDecimal(ValorInmueble));
            comm.Parameters.AddWithValue("@total", Convert.ToDecimal(Total));
            int result = (int)comm.ExecuteScalar();
            if (result > 0)
            {
                con.Close();
                return result;
            }
            else
            {
                con.Close();
                return 0;
            }
        }

        public int GuardarActosPrelacion(int IdPrelacion, int IdActo, int IdMovimiento, decimal Importe)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO PrelacionesActos VALUES (" + IdPrelacion + ", " + IdActo + ", " + IdMovimiento + ",'NOREGISTRADA', @importe )", con);
            comm.Parameters.AddWithValue("@importe", Convert.ToDecimal(Importe));
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                con.Close();
                return 0;
            }
            else
            {
                con.Close();
                return 1;
            }
        }

        public int GuardarAntecedentesPrelacion(int IdPrelacion, String Libro, String Tomo, String Semestre, String Seccion, String Serie, String Partida, String Año, String Folio)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO PrelacionesAntecedentes VALUES (" + IdPrelacion + ", '" + Libro + "', '" + Tomo + "', '" + Semestre + "', '" + Seccion + "', '" + Serie + "', '" + Partida + "', '" + Año + "', '" + Folio + "')", con);
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                con.Close();
                return 0;
            }
            else
            {
                con.Close();
                return 1;
            }
        }

        public List<Prelacion> ObtenerPrelacionesEstatus(String estatus)
        {

            List<Prelacion> listaPrelaciones = new List<Prelacion>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select Usuarios.nombre as Unombre, Usuarios.apellido_paterno as Upaterno, Usuarios.apellido_materno as Umaterno,* from Prelaciones inner join Tramitantes on Prelaciones.id_tramitante=Tramitantes.id_tramitante left join PrelacionesUsuarios on Prelaciones.id_prelacion=PrelacionesUsuarios.id_prelacion left join Usuarios on Usuarios.id_usuario=PrelacionesUsuarios.id_usuario where Prelaciones.estatus LIKE '" + estatus + "' order by Prelaciones.id_prelacion", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Prelacion pre = new Prelacion();
                    pre.IdPrelacion = int.Parse(reader["id_prelacion"].ToString());
                    pre.idUsuario = reader["id_usuario"].ToString();
                    pre.Usuario = reader["Unombre"].ToString() + " " + reader["Upaterno"].ToString() + " " + reader["Umaterno"].ToString();
                    pre.NombreTitular = reader["nombre_titular"].ToString();
                    pre.DescripcionBien = reader["descripcion_bien"].ToString();
                    pre.Fecha = reader["fecha"].ToString();
                    pre.FechaDocumento = reader["fecha_documento"].ToString();
                    pre.LugarOtorgamiento = reader["lugar_otorgamiento"].ToString();
                    pre.TipoDocumento = reader["tipo_documento"].ToString();
                    pre.TipoMoneda = reader["tipo_moneda"].ToString();
                    pre.IdTramitante = int.Parse(reader["id_tramitante"].ToString());
                    pre.Tramitante = reader["nombre"].ToString() + " " + reader["apellido_paterno"].ToString() + " " + reader["apellido_materno"].ToString();
                    pre.NumeroEscritura = reader["numero_escritura"].ToString();
                    listaPrelaciones.Add(pre);
                }
            }
            con.Close();
            return listaPrelaciones;
        }

        public List<Prelacion> ObtenerPrelacionesEstatusFiltro(String estatus, String filtro)
        {

            List<Prelacion> listaPrelaciones = new List<Prelacion>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select Usuarios.nombre as Unombre, Usuarios.apellido_paterno as Upaterno, Usuarios.apellido_materno as Umaterno,* from Prelaciones inner join Tramitantes on Prelaciones.id_tramitante=Tramitantes.id_tramitante left join PrelacionesUsuarios on Prelaciones.id_prelacion=PrelacionesUsuarios.id_prelacion left join Usuarios on Usuarios.id_usuario=PrelacionesUsuarios.id_usuario where Prelaciones.estatus='" + estatus + "' and Prelaciones.id_prelacion LIKE '" + filtro + "' order by PrelacionesUsuarios.id_usuario,Prelaciones.id_prelacion", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Prelacion pre = new Prelacion();
                    pre.IdPrelacion = int.Parse(reader["id_prelacion"].ToString());
                    pre.idUsuario = reader["id_usuario"].ToString();
                    pre.Usuario = reader["Unombre"].ToString() + " " + reader["Upaterno"].ToString() + " " + reader["Umaterno"].ToString();
                    pre.NombreTitular = reader["nombre_titular"].ToString();
                    pre.DescripcionBien = reader["descripcion_bien"].ToString();
                    pre.Fecha = reader["fecha"].ToString();
                    pre.FechaDocumento = reader["fecha_documento"].ToString();
                    pre.LugarOtorgamiento = reader["lugar_otorgamiento"].ToString();
                    pre.TipoDocumento = reader["tipo_documento"].ToString();
                    pre.TipoMoneda = reader["tipo_moneda"].ToString();
                    pre.IdTramitante = int.Parse(reader["id_tramitante"].ToString());
                    pre.Tramitante = reader["nombre"].ToString() + " " + reader["apellido_paterno"].ToString() + " " + reader["apellido_materno"].ToString();
                    pre.NumeroEscritura = reader["numero_escritura"].ToString();
                    listaPrelaciones.Add(pre);
                }
            }
            con.Close();
            return listaPrelaciones;
        }

        public static List<Prelacion> ObtenerPrelacionesEstatusFechaReporte(String estatus, String fecha)
        {

            List<Prelacion> listaPrelaciones = new List<Prelacion>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select Usuarios.nombre as Unombre, Usuarios.apellido_paterno as Upaterno, Usuarios.apellido_materno as Umaterno, *, Actos.nombre as nombreActo " + 
                                                "from Prelaciones " + 
                                                "JOIN PrelacionesUsuarios on Prelaciones.id_prelacion=PrelacionesUsuarios.id_prelacion " + 
                                                "JOIN Usuarios on Usuarios.id_usuario=PrelacionesUsuarios.id_usuario " +                                                 
                                                "JOIN PrelacionesActos ON PrelacionesActos.id_prelacion = Prelaciones.id_prelacion " +
                                                "JOIN Actos ON Actos.clave_acto = PrelacionesActos.id_acto " +
                                                "where Prelaciones.estatus LIKE '" + estatus + "' AND Prelaciones.fecha_asignacion LIKE '" + fecha + "' " +
                                                "order by PrelacionesUsuarios.id_usuario, Actos.id_acto, Prelaciones.id_prelacion", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Prelacion pre = new Prelacion();
                    pre.IdPrelacion = int.Parse(reader["id_prelacion"].ToString());
                    pre.NombreActo = reader["nombreActo"].ToString();
                    pre.Usuario = reader["Unombre"].ToString() + " " + reader["Upaterno"].ToString() + " " + reader["Umaterno"].ToString();
                    pre.FechaAsignacion = reader["fecha_asignacion"].ToString();
                    pre.NumeroEscritura = reader["numero_escritura"].ToString();
                    pre.Status = reader["estatus"].ToString();
                    listaPrelaciones.Add(pre);
                }
            }
            con.Close();
            return listaPrelaciones;
        }

        public static List<Prelacion> ObtenerPrelacionesEstatusFechaReporteRango(String estatus, String fechaInicio, String fechaFin)
        {

            List<Prelacion> listaPrelaciones = new List<Prelacion>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select Usuarios.nombre as Unombre, Usuarios.apellido_paterno as Upaterno, Usuarios.apellido_materno as Umaterno, *, Actos.nombre as nombreActo " +
                                                "from Prelaciones " +
                                                "JOIN PrelacionesUsuarios on Prelaciones.id_prelacion=PrelacionesUsuarios.id_prelacion " +
                                                "JOIN Usuarios on Usuarios.id_usuario=PrelacionesUsuarios.id_usuario " +
                                                "JOIN PrelacionesActos ON PrelacionesActos.id_prelacion = Prelaciones.id_prelacion " +
                                                "JOIN Actos ON Actos.clave_acto = PrelacionesActos.id_acto " +
                                                "where Prelaciones.estatus LIKE '" + estatus + "' AND (Cast(Prelaciones.fecha_asignacion As Date) >= '" + fechaInicio + "' And Cast(Prelaciones.fecha_asignacion As Date) <= '" + fechaFin + "') " +
                                                "order by PrelacionesUsuarios.id_usuario, Actos.id_acto, Prelaciones.id_prelacion", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Prelacion pre = new Prelacion();
                    pre.IdPrelacion = int.Parse(reader["id_prelacion"].ToString());
                    pre.NombreActo = reader["nombreActo"].ToString();
                    pre.Usuario = reader["Unombre"].ToString() + " " + reader["Upaterno"].ToString() + " " + reader["Umaterno"].ToString();
                    pre.FechaAsignacion = reader["fecha_asignacion"].ToString();
                    pre.NumeroEscritura = reader["numero_escritura"].ToString();
                    pre.Status = reader["estatus"].ToString();
                    listaPrelaciones.Add(pre);
                }
            }
            con.Close();
            return listaPrelaciones;
        }

        public List<Prelacion> ObtenerPrelacionesEstatusReporte(String estatus)
        {

            List<Prelacion> listaPrelaciones = new List<Prelacion>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select Usuarios.nombre as Unombre, Usuarios.apellido_paterno as Upaterno, Usuarios.apellido_materno as Umaterno, Entregas.nombre_recibe as Recibe, * from Prelaciones inner join Tramitantes on Prelaciones.id_tramitante=Tramitantes.id_tramitante left join PrelacionesUsuarios on Prelaciones.id_prelacion=PrelacionesUsuarios.id_prelacion left join Usuarios on Usuarios.id_usuario=PrelacionesUsuarios.id_usuario LEFT JOIN Entregas ON Entregas.id_prelacion = Prelaciones.id_prelacion where Prelaciones.estatus='" + estatus + "' order by PrelacionesUsuarios.id_usuario,Prelaciones.id_prelacion", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Prelacion pre = new Prelacion();
                    pre.IdPrelacion = int.Parse(reader["id_prelacion"].ToString());
                    pre.idUsuario = reader["id_usuario"].ToString();
                    pre.Usuario = reader["Unombre"].ToString() + " " + reader["Upaterno"].ToString() + " " + reader["Umaterno"].ToString();
                    pre.NombreTitular = reader["nombre_titular"].ToString();
                    pre.DescripcionBien = reader["descripcion_bien"].ToString();
                    pre.Fecha = reader["fecha"].ToString();
                    pre.FechaDocumento = reader["fecha_documento"].ToString();
                    pre.LugarOtorgamiento = reader["lugar_otorgamiento"].ToString();
                    pre.TipoDocumento = reader["tipo_documento"].ToString();
                    pre.TipoMoneda = reader["tipo_moneda"].ToString();
                    pre.IdTramitante = int.Parse(reader["id_tramitante"].ToString());
                    pre.Tramitante = reader["nombre"].ToString() + " " + reader["apellido_paterno"].ToString() + " " + reader["apellido_materno"].ToString();
                    pre.NumeroEscritura = reader["numero_escritura"].ToString();
                    pre.NombreRecibe = reader["Recibe"].ToString();
                    listaPrelaciones.Add(pre);
                }
            }
            con.Close();
            return listaPrelaciones;
        }

        public List<Prelacion> ObtenerPrelacionesActo(int IdActo)
        {

            List<Prelacion> listaPrelaciones = new List<Prelacion>();

            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select Usuarios.nombre as Unombre, Usuarios.apellido_paterno as Upaterno, Usuarios.apellido_materno as Umaterno,* from Prelaciones inner join Tramitantes on Prelaciones.id_tramitante=Tramitantes.id_tramitante left join PrelacionesUsuarios on Prelaciones.id_prelacion=PrelacionesUsuarios.id_prelacion left join Usuarios on Usuarios.id_usuario=PrelacionesUsuarios.id_usuario INNER JOIN PrelacionesActos ON PrelacionesActos.id_prelacion = Prelaciones.id_prelacion where PrelacionesActos.id_acto = " + IdActo + " order by PrelacionesUsuarios.id_usuario,Prelaciones.id_prelacion", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Prelacion pre = new Prelacion();
                    pre.IdPrelacion = int.Parse(reader["id_prelacion"].ToString());
                    pre.idUsuario = reader["id_usuario"].ToString();
                    pre.Usuario = reader["Unombre"].ToString() + " " + reader["Upaterno"].ToString() + " " + reader["Umaterno"].ToString();
                    pre.NombreTitular = reader["nombre_titular"].ToString();
                    pre.DescripcionBien = reader["descripcion_bien"].ToString();
                    pre.Fecha = reader["fecha"].ToString();
                    pre.FechaDocumento = reader["fecha_documento"].ToString();
                    pre.LugarOtorgamiento = reader["lugar_otorgamiento"].ToString();
                    pre.TipoDocumento = reader["tipo_documento"].ToString();
                    pre.TipoMoneda = reader["tipo_moneda"].ToString();
                    pre.IdTramitante = int.Parse(reader["id_tramitante"].ToString());
                    pre.Tramitante = reader["nombre"].ToString() + " " + reader["apellido_paterno"].ToString() + " " + reader["apellido_materno"].ToString();
                    pre.NumeroEscritura = reader["numero_escritura"].ToString();
                    listaPrelaciones.Add(pre);
                }
            }
            con.Close();
            return listaPrelaciones;
        }

        //Funcion que regresa una Prelacion segun el ID, Sin relacionar la tabla PrelacionesUsuarios
        public static Prelacion PrelacionPorId(int idPrelacion)
        {
            Prelacion pre = new Prelacion();
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select * from Prelaciones inner join Tramitantes on Prelaciones.id_tramitante=Tramitantes.id_tramitante where Prelaciones.id_prelacion='" + idPrelacion + "'", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    pre.IdPrelacion = int.Parse(reader["id_prelacion"].ToString());
                    pre.NombreTitular = reader["nombre_titular"].ToString();
                    pre.DescripcionBien = reader["descripcion_bien"].ToString();
                    pre.NumeroEscritura = reader["numero_escritura"].ToString();
                    pre.Folio = reader["folio"].ToString();
                    pre.ValorInmueble = Convert.ToDecimal(reader["valor_inmueble"].ToString());
                    pre.Total = Convert.ToDecimal(reader["total"].ToString());
                    pre.Fecha = reader["fecha"].ToString();
                    pre.IdTramitante = int.Parse(reader["id_tramitante"].ToString());
                    pre.Tramitante = reader["nombre"].ToString() + " " + reader["apellido_paterno"].ToString() + " " + reader["apellido_materno"].ToString();
                    pre.ObservacionesVerificador = reader["observaciones_verificador"].ToString();
                }
            }
            con.Close();
            return pre;
        }
        //Funcion que regresa una Prelacion segun el ID.
        public static Prelacion ObtenerPrelacionPorId(int idPrelacion)
        {
            Prelacion pre = new Prelacion();
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select * from Prelaciones inner join PrelacionesUsuarios on Prelaciones.id_prelacion=PrelacionesUsuarios.id_prelacion " +
                                                " inner join Tramitantes on Prelaciones.id_tramitante=Tramitantes.id_tramitante where Prelaciones.id_prelacion='" + idPrelacion + "'", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    pre.IdPrelacion = int.Parse(reader["id_prelacion"].ToString());
                    pre.idUsuario = reader["id_usuario"].ToString();
                    pre.NombreTitular = reader["nombre_titular"].ToString();
                    pre.DescripcionBien = reader["descripcion_bien"].ToString();
                    pre.NumeroEscritura = reader["numero_escritura"].ToString();
                    pre.Folio = reader["folio"].ToString();
                    pre.Total = Convert.ToDecimal(reader["total"].ToString());
                    pre.Fecha = reader["fecha"].ToString();
                    pre.IdTramitante = int.Parse(reader["id_tramitante"].ToString());
                    pre.Tramitante = reader["nombre"].ToString() + " " + reader["apellido_paterno"].ToString() + " " + reader["apellido_materno"].ToString();
                    pre.ObservacionesVerificador = reader["observaciones_verificador"].ToString();
                }
            }
            con.Close();
            return pre;
        }

        public List<Prelacion> ObtenerPrelacionesUsuario(int idusuario, String estado)
        {
            List<Prelacion> listaPrelaciones = new List<Prelacion>();
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select * from Prelaciones left join PrelacionesUsuarios on Prelaciones.id_prelacion=PrelacionesUsuarios.id_prelacion left join Usuarios on Usuarios.id_usuario=PrelacionesUsuarios.id_usuario where Prelaciones.estatus='" + estado + "' and PrelacionesUsuarios.id_usuario='" + idusuario + "' order by Prelaciones.id_prelacion", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Prelacion pre = new Prelacion();
                    pre.IdPrelacion = int.Parse(reader["id_prelacion"].ToString());
                    pre.idUsuario = reader["id_usuario"].ToString();
                    pre.Usuario = reader["nombre"].ToString() + " " + reader["apellido_paterno"].ToString() + " " + reader["apellido_materno"].ToString();
                    pre.NombreTitular = reader["nombre_titular"].ToString();
                    pre.DescripcionBien = reader["descripcion_bien"].ToString();
                    pre.ObservacionesVerificador = reader["observaciones_verificador"].ToString();
                    listaPrelaciones.Add(pre);
                }
            }
            con.Close();

            return listaPrelaciones;
        }

        public String GuardarNuevaPrelacionUsuario(int IdPrelacion, int IdUsuario, String Bitacora)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE Prelaciones SET estatus = 'ASIGNADA' WHERE id_prelacion = " + IdPrelacion, con);
            comm.ExecuteNonQuery();
            comm = new SqlCommand("INSERT INTO PrelacionesUsuarios VALUES (" + IdPrelacion + ", " + IdUsuario + ", '" + Bitacora + "')", con);
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
        public int ActualizarPrelacionUsuario(int IdPrelacion, int IdUsuario, int IdNuevoUsuario, String Bitacora)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE PrelacionesUsuarios SET id_usuario = " + IdNuevoUsuario + ", bitacora = CONCAT(bitacora, '" + Bitacora + "') WHERE id_prelacion = " + IdPrelacion + " and id_usuario= " + IdUsuario, con);
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                con.Close();
                return result;
            }
            else
            {
                con.Close();
                return 0;
            }
        }
        //Función para obtener la lista de movimientos de una prelación. Estática.
        public static List<Movimientos> ObtenerMovimientosPrelacion(int IdPrelacion, String estadoMov)
        {
            List<Movimientos> listaMovimientos = new List<Movimientos>();
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            String query = "SELECT *, Actos.nombre as nombre_acto, Actos.area as area_acto, Actos.seccion as seccion_acto, Actos.tipo as tipo_acto, PrelacionesActos.estado_movimiento " +
                                                "FROM Movimientos " +
                                                "INNER JOIN Actos ON Actos.clave_acto = Movimientos.id_acto " +
                                                "INNER JOIN PrelacionesActos ON PrelacionesActos.id_acto = Actos.clave_acto " +
                                                "WHERE PrelacionesActos.id_prelacion = " + IdPrelacion + " AND PrelacionesActos.id_movimiento = Movimientos.id_movimiento ";
            if (!estadoMov.Equals("")) query += " AND estado_movimiento='" + estadoMov + "'";
            SqlCommand comm = new SqlCommand(query, con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Movimientos mov = new Movimientos();
                    Acto act = new Acto();
                    act.Nombre = reader["nombre_acto"].ToString();

                    act.Area = reader["area_acto"].ToString();
                    act.Seccion = reader["seccion_acto"].ToString();
                    act.Tipo = reader["tipo_acto"].ToString();
                    mov.Acto = act;

                    mov.Clave = int.Parse(reader["id_movimiento"].ToString());
                    mov.ClaveActo = int.Parse(reader["id_acto"].ToString());
                    mov.ClavePrelacionActo = int.Parse(reader["id_prelacion_acto"].ToString());
                    mov.Nombre = reader["nombre"].ToString();
                    mov.NombreActo = reader["nombre_acto"].ToString();
                    mov.TipoFolio = int.Parse(reader["tipo_folio"].ToString());
                    mov.EstadoMovimiento = reader["estado_movimiento"].ToString();
                    mov.Importe = Convert.ToDecimal(reader["importe"].ToString());

                    listaMovimientos.Add(mov);
                }
            }

            con.Close();
            return listaMovimientos;
        }
        //Función para obtener la lista de antecedentes de una prelación. Estática.
        public static List<Antecedente> ObtenerAntecedentesPrelacion(int IdPrelacion)
        {
            List<Antecedente> listaAntecedentes = new List<Antecedente>();
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT * " +
                                                "FROM PrelacionesAntecedentes " +
                                                "WHERE PrelacionesAntecedentes.id_prelacion = " + IdPrelacion, con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Antecedente ant = new Antecedente();

                    ant.Año = reader["anio"].ToString();
                    ant.ClaveAntecedente = int.Parse(reader["id_prelacion_antecedente"].ToString());
                    ant.ClavePrelacion = int.Parse(reader["id_prelacion"].ToString());
                    ant.Folio = reader["folio"].ToString();
                    ant.Libro = reader["libro"].ToString();
                    ant.Partida = reader["partida"].ToString();
                    ant.Seccion = reader["seccion"].ToString();
                    ant.Semestre = reader["semestre"].ToString();
                    ant.Serie = reader["serie"].ToString();
                    ant.Tomo = reader["tomo"].ToString();

                    listaAntecedentes.Add(ant);
                }
            }

            con.Close();
            return listaAntecedentes;
        }
        //Función para obtener la lista de costos de una prelación para la boleta. Estática.
        public static List<Costos> ObtenerCostosPrelacion(int IdPrelacion)
        {
            List<Costos> listaCostos = new List<Costos>();
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("select actos.clave_acto, importe,clave_ingresos,nombre, count(clave_acto) as cantidad, sum(importe) as total from prelacionesactos " +
                            " inner join Actos on actos.clave_acto=prelacionesactos.id_acto where prelacionesactos.id_prelacion=" + IdPrelacion + " group by actos.clave_acto,importe,clave_ingresos,nombre", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Costos costos = new Costos();
                    costos.IdActo = int.Parse(reader["clave_acto"].ToString());
                    costos.Importe = float.Parse(reader["importe"].ToString());
                    costos.Ingresos = reader["clave_ingresos"].ToString();
                    costos.NombreActo = reader["nombre"].ToString();
                    costos.Cantidad = int.Parse(reader["cantidad"].ToString());
                    costos.Total = float.Parse(reader["total"].ToString());
                    listaCostos.Add(costos);
                }
            }

            con.Close();
            return listaCostos;
        }

        public static String CambiarEstadoPrelacion(String NuevoEstado, int IdPrelacion)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand();

            if (NuevoEstado == "ASIGNADA")
            {
                comm = new SqlCommand("UPDATE Prelaciones SET estatus = '" + NuevoEstado + "', fecha_asignacion = '" + DateTime.Today.Date.ToShortDateString() + "' WHERE id_prelacion = " + IdPrelacion, con);
            }
            else
            {
                comm = new SqlCommand("UPDATE Prelaciones SET estatus = '" + NuevoEstado + "' WHERE id_prelacion = " + IdPrelacion, con);
            }
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                con.Close();
                return "OK";
            }
            else
            {
                con.Close();
                return "Error";
            }
        }

        public static String CambiarObservacionesVerificadorPrelacion(String Observaciones, int IdPrelacion)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE Prelaciones SET observaciones_verificador = '" + Observaciones + "' WHERE id_prelacion = " + IdPrelacion, con);
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                con.Close();
                return "OK";
            }
            else
            {
                con.Close();
                return "Error";
            }
        }

        public static String CambiarEstadoMovimiento(String NuevoEstado, int IdPrelacionActo)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE PrelacionesActos SET estado_movimiento = '" + NuevoEstado + "' WHERE id_prelacion_acto = " + IdPrelacionActo, con);
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                con.Close();
                return "OK";
            }
            else
            {
                con.Close();
                return "Error";
            }
        }

        public static String CambiarEstadoMovimientos(String NuevoEstado, int IdPrelacion)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE PrelacionesActos SET estado_movimiento = '" + NuevoEstado + "' WHERE id_prelacion = " + IdPrelacion, con);
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                con.Close();
                return "OK";
            }
            else
            {
                con.Close();
                return "Error";
            }
        }

        public static String EntregarPrelacion(int IdPrelacion, String Nombre, String TipoIdentificacion, String ClaveIdentificacion)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            using (SqlTransaction trans = con.BeginTransaction())
            {
                try
                {
                    SqlCommand comm = new SqlCommand("INSERT INTO Entregas VALUES (" + IdPrelacion + ", '" + Nombre + "', '" + TipoIdentificacion + "', '" + ClaveIdentificacion + "', CONVERT(VARCHAR(50),getdate(), 109))", con, trans);
                    int result = comm.ExecuteNonQuery();

                    trans.Commit();
                    con.Close();
                    return "OK";
                }
                catch (Exception exc)
                {
                    trans.Rollback();
                    con.Close();
                    return "Error: " + exc.Message;
                }
            }
        }

        //Función para la búsqueda de una prelación en el módulo de modificación de prelación de recepción
        public static Prelacion ObtenerPrelacionPorIdBusqueda(int idPrelacion)
        {
            Prelacion pre = new Prelacion();
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT * FROM Prelaciones " + 
                                                "INNER JOIN Tramitantes ON Prelaciones.id_tramitante = Tramitantes.id_tramitante " +
                                                "WHERE Prelaciones.id_prelacion = '" + idPrelacion + "' AND Prelaciones.estatus LIKE '%'", con);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    pre.IdPrelacion = int.Parse(reader["id_prelacion"].ToString());

                    pre.Folio = reader["folio"].ToString();
                    pre.IdTramitante = int.Parse(reader["id_tramitante"].ToString());
                    pre.Tramitante = reader["nombre"].ToString() + " " + reader["apellido_paterno"].ToString() + " " + reader["apellido_materno"].ToString();
                    pre.NombreTitular = reader["nombre_titular"].ToString();
                    pre.NumeroEscritura = reader["numero_escritura"].ToString();
                    pre.DescripcionBien = reader["descripcion_bien"].ToString();
                    pre.TipoDocumento = reader["tipo_documento"].ToString();
                    pre.FechaDocumento = reader["fecha_documento"].ToString();
                    pre.LugarOtorgamiento = reader["lugar_otorgamiento"].ToString();

                    pre.antecedentes = new List<Antecedente>();
                    pre.antecedentes = Prelacion.ObtenerAntecedentesPrelacion(idPrelacion);

                }
            }
            con.Close();
            return pre;
        }

        public static void ActualizarPrelacion(Prelacion p)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("UPDATE Prelaciones " +
                                                "SET nombre_titular = '" + p.NombreTitular + "', descripcion_bien = '" + p.DescripcionBien + "', numero_escritura = '" + p.NumeroEscritura + "', lugar_otorgamiento = '" + p.LugarOtorgamiento + "', tipo_documento = '" + p.TipoDocumento + "', fecha_documento = '" + p.FechaDocumento + "', folio = '" + p.Folio + "', id_tramitante = " + p.IdTramitante + " " +
                                                "WHERE id_prelacion = " + p.IdPrelacion, con);
            comm.ExecuteNonQuery();

            comm = new SqlCommand("DELETE FROM PrelacionesAntecedentes " +
                                    "WHERE id_prelacion = " + p.IdPrelacion, con);

            comm.ExecuteNonQuery();

            if (p.antecedentes != null)
            {
                foreach (Antecedente item in p.antecedentes)
                {
                    int res = p.GuardarAntecedentesPrelacion(p.IdPrelacion, item.Libro, item.Tomo, item.Semestre, item.Seccion, item.Serie, item.Partida, item.Año, item.Folio);
                }
            }

            con.Close();

        }
    }
}
