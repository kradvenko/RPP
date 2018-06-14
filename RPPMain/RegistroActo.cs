using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RPPMain
{
    public class RegistroActo
    {

        private int idRegistro;
        private int idPrelacionActo;
        private String folio;        
        private List<Antecedente> antecedentes;
        private List<Persona> otorgantes;
        private List<Persona> adquirientes;
        private String tipoPredio;
        private String superficie;
        private String unidadSuperfice;
        private int ubicacionInmuebleCalle;
        private int ubicacionInmuebleColonia;
        private int ubicacionInmuebleNumero;
        private String coloniaTexto;
        private String calleTexto;
        private String numeroExterior;
        private String numeroInterior;
        private String manzana;
        private String lote;
        private int municipio;
        private int poblacion;
        private String claveCatastral;
        private String norte;
        private String sur;
        private String este;
        private String oeste;
        private String noreste;
        private String noroeste;
        private String sureste;
        private String suroeste;
        private String fechaRegistro;
        private Antecedente registroActual;
        private List<Antecedente> anotacionesMarginales;
        private String observaciones;
        private String anotacionActualizada;
        //Variables extras para almacenar el texto de ciertos datos
        private String municipioTexto;
        private String poblacionTexto;

        public RegistroActo()
        {

        }

        public int IdRegistro
        {
            get
            {
                return idRegistro;
            }
            set
            {
                idRegistro = value;
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

        public int IdPrelacionActo
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

        public List<Persona> Otorgantes
        {
            get
            {
                return otorgantes;
            }
            set
            {
                otorgantes = value;
            }
        }

        public List<Persona> Adquirientes
        {
            get
            {
                return adquirientes;
            }
            set
            {
                adquirientes = value;
            }
        }

        public String TipoPredio
        {
            get
            {
                return tipoPredio;
            }
            set
            {
                tipoPredio = value;
            }
        }

        public String Superficie
        {
            get
            {
                return superficie;
            }
            set
            {
                superficie = value;
            }
        }

        public String UnidadSuperficie
        {
            get
            {
                return unidadSuperfice;
            }
            set
            {
                unidadSuperfice = value;
            }
        }

        public int UbicacionInmuebleCalle
        {
            get
            {
                return ubicacionInmuebleCalle;
            }
            set
            {
                ubicacionInmuebleCalle = value;
            }
        }

        public int UbicacionInmuebleColonia
        {
            get
            {
                return ubicacionInmuebleColonia;
            }
            set
            {
                ubicacionInmuebleColonia = value;
            }
        }

        public int UbicacionInmuebleNumero
        {
            get
            {
                return ubicacionInmuebleNumero;
            }
            set
            {
                ubicacionInmuebleNumero = value;
            }
        }

        public String ColoniaTexto
        {
            get
            {
                return coloniaTexto;
            }
            set
            {
                coloniaTexto = value;
            }
        }

        public String CalleTexto
        {
            get
            {
                return calleTexto;
            }
            set
            {
                calleTexto = value;
            }
        }

        public String NumeroExterior
        {
            get
            {
                return numeroExterior;
            }
            set
            {
                numeroExterior = value;
            }
        }

        public String NumeroInterior
        {
            get
            {
                return numeroInterior;
            }
            set
            {
                numeroInterior = value;
            }
        }

        public String Manzana
        {
            get
            {
                return manzana;
            }
            set
            {
                manzana = value;
            }
        }

        public String Lote
        {
            get
            {
                return lote;
            }
            set
            {
                lote = value;
            }
        }

        public int Municipio
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

        public int Poblacion
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

        public String ClaveCatastral
        {
            get
            {
                return claveCatastral;
            }
            set
            {
                claveCatastral = value;
            }
        }

        public String Norte
        {
            get
            {
                return norte;
            }
            set
            {
                norte = value;
            }
        }

        public String Sur
        {
            get
            {
                return sur;
            }
            set
            {
                sur = value;
            }
        }

        public String Este
        {
            get
            {
                return este;
            }
            set
            {
                este = value;
            }
        }

        public String Oeste
        {
            get
            {
                return oeste;
            }
            set
            {
                oeste = value;
            }
        }

        public String Noreste
        {
            get
            {
                return noreste;
            }
            set
            {
                noreste = value;
            }
        }

        public String Noroeste
        {
            get
            {
                return noroeste;
            }
            set
            {
                noroeste = value;
            }
        }

        public String Sureste
        {
            get
            {
                return sureste;
            }
            set
            {
                sureste = value;
            }
        }

        public String Suroeste
        {
            get
            {
                return suroeste;
            }
            set
            {
                suroeste = value;
            }
        }

        public String FechaRegistro
        {
            get
            {
                return fechaRegistro;
            }
            set
            {
                fechaRegistro = value;
            }
        }

        public Antecedente RegistroActual
        {
            get
            {
                return registroActual;
            }
            set
            {
                registroActual = value;
            }
        }

        public List<Antecedente> AnotacionesMarginales
        {
            get
            {
                return anotacionesMarginales;
            }
            set
            {
                anotacionesMarginales = value;
            }
        }

        public String Observaciones
        {
            get
            {
                return observaciones;
            }
            set
            {
                observaciones = value;
            }
        }

        public String AnotacionActualizada
        {
            get
            {
                return anotacionActualizada;
            }
            set
            {
                anotacionActualizada = value;
            }
        }

        public String MunicipioTexto
        {
            get
            {
                return municipioTexto;
            }
            set
            {
                municipioTexto = value;
            }
        }

        public String PoblacionTexto
        {
            get
            {
                return poblacionTexto;
            }
            set
            {
                poblacionTexto = value;
            }
        }

        public int GuardarRegistro(int IdPrelacionActo, String Folio, String TipoPredio, String Superficie, String UnidadSuperficie, int UbicacionInmuebleCalle, int UbicacionInmuebleColonia, int ubicacionInmuebleNumero, String coloniaText, String calleTexto, String NumeroExterior, String NumeroInterior, String Manzana, String Lote, int Municipio, int Poblacion, String ClaveCatastral, String Norte, String Sur, String Este, String Oeste, String Noreste, String Noroeste, String Sureste, String Suroeste, String FechaRegistro, String RegistroActualLibro, String RegistroActualSeccion, String RegistroActualPartida, String Observaciones, String RegistroActualSerie)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Registro " + 
                                                "OUTPUT inserted.id_prelacion " + 
                                                "VALUES (" + IdPrelacionActo + ", '" + Folio + "', '" + TipoPredio + "', '" + Superficie + "', '" + UnidadSuperficie + "', " + UbicacionInmuebleCalle + ", " + UbicacionInmuebleColonia + ", " + UbicacionInmuebleNumero + ", '" + ColoniaTexto + "', '" + CalleTexto + "', '" + NumeroExterior + "', '" + NumeroInterior + "', '" + Manzana + "', '" + Lote + "', " + Municipio + ", " + Poblacion + ", '" + ClaveCatastral + "', '" + Norte + "', '" + Sur + "', '" + Este + "', '" + Oeste + "', '" + Noreste + "', '" + Noroeste + "', '" + Sureste + "', '" + Suroeste + "', '" + FechaRegistro + "', '" + RegistroActualLibro + "', '" + RegistroActualSeccion + "', '" + RegistroActualPartida + "', '" + Observaciones + "', '" + RegistroActualSerie  + "')", con);

            int result = (int)comm.ExecuteScalar();
            if (result > 0)
            {
                SqlCommand comm2 = new SqlCommand("UPDATE PrelacionesActos SET estado_movimiento ='REGISTRADA'  WHERE id_prelacion_acto = " + IdPrelacionActo, con);
                int result2 = comm2.ExecuteNonQuery();
                con.Close();
                return result;
            }
            else
            {
                con.Close();
                return 0;
            }
        }

        public String GuardarAdquiriente(int IdRegistro, String Nombre, String Paterno, String Materno)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Adquirientes " +
                                                "VALUES (" + IdRegistro + ", '" + Nombre + "', '" + Paterno + "', '" + Materno + "')", con);
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

        public String GuardarOtorgante(int IdRegistro, String Nombre, String Paterno, String Materno)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Otorgantes " +
                                                "VALUES (" + IdRegistro + ", '" + Nombre + "', '" + Paterno + "', '" + Materno + "')", con);
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

        public String GuardarAnotacionesMarginales(int IdRegistro, String AnotacionLibro, String AnotacionTomo, String AnotacionSemestre, String AnotacionAnio, String AnotacionSeccion, String AnotacionSerie, String AnotacionPartida, String AnotacionObservaciones)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO AnotacionesMarginales " +
                                                "VALUES (" + IdRegistro + ", '" + AnotacionLibro + "', '" + AnotacionTomo + "', '" + AnotacionSemestre + "', '" + AnotacionAnio + "', '" + AnotacionSeccion + "', '" + AnotacionSerie + "', '" + AnotacionPartida + "', '" + AnotacionObservaciones + "')", con);
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
        //Función que retorna la lista completa de registros de una prelación recibiendo como parámetro el id de la prelación
        public static List<RegistroActo> ObtenerDatosListaRegistrosPrelacion(int IdPrelacion)
        {
            List<RegistroActo> registros = new List<RegistroActo>();
            RegistroActo reg = new RegistroActo();
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT Registro.* " +
                                                "FROM PrelacionesActos " +
                                                "INNER JOIN Registro " +
                                                "ON Registro.id_prelacion_acto = PrelacionesActos.id_prelacion_acto " +
                                                "WHERE PrelacionesActos.id_prelacion = " + IdPrelacion, con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    reg = new RegistroActo();
                    reg.IdRegistro = int.Parse(reader["id_registro"].ToString());
                    reg.IdPrelacionActo = int.Parse(reader["id_prelacion_acto"].ToString());
                    reg.Folio = reader["folio"].ToString();
                    reg.TipoPredio = reader["tipo_predio"].ToString();
                    reg.Superficie = reader["superficie"].ToString();
                    reg.UnidadSuperficie = reader["unidad_superficie"].ToString();
                    reg.UbicacionInmuebleCalle = int.Parse(reader["ubicacion_inmueble_calle"].ToString());
                    reg.UbicacionInmuebleColonia = int.Parse(reader["ubicacion_inmueble_colonia"].ToString());
                    reg.UbicacionInmuebleNumero = int.Parse(reader["ubicacion_inmueble_numero"].ToString());
                    reg.ColoniaTexto = reader["colonia_texto"].ToString();
                    reg.CalleTexto = reader["calle_texto"].ToString();
                    reg.NumeroExterior = reader["numero_exterior_texto"].ToString();
                    reg.NumeroInterior = reader["numero_interior_texto"].ToString();
                    reg.Manzana = reader["manzana_texto"].ToString();
                    reg.Lote = reader["lote_texto"].ToString();
                    reg.Municipio = int.Parse(reader["id_municipio"].ToString());
                    reg.Poblacion = int.Parse(reader["id_poblacion"].ToString());
                    reg.ClaveCatastral = reader["clave_catastral"].ToString();
                    reg.Norte = reader["norte"].ToString();
                    reg.Sur = reader["sur"].ToString();
                    reg.Este = reader["este"].ToString();
                    reg.Oeste = reader["oeste"].ToString();
                    reg.Noreste = reader["noreste"].ToString();
                    reg.Noroeste = reader["noroeste"].ToString();
                    reg.Sureste = reader["sureste"].ToString();
                    reg.Suroeste = reader["suroeste"].ToString();
                    reg.FechaRegistro = reader["fecha_registro"].ToString();
                    reg.registroActual = new Antecedente();
                    reg.RegistroActual.Libro = reader["actual_libro"].ToString();
                    reg.RegistroActual.Seccion = reader["actual_seccion"].ToString();
                    reg.RegistroActual.Partida = reader["actual_partida"].ToString();
                    reg.Observaciones = reader["observaciones"].ToString();
                    reg.AnotacionActualizada = reader["anotacion_actualizada"].ToString();

                    SqlConnection con2 = new SqlConnection(Connection.getConnection());
                    con2.Open();
                    SqlCommand comm2 = new SqlCommand("SELECT * FROM AnotacionesMarginales WHERE id_registro = " + reg.IdRegistro , con2);
                    SqlDataReader reader2 = comm2.ExecuteReader();
                    List<Antecedente> anotaciones = new List<Antecedente>();

                    if (reader2.HasRows)
                    {
                        while(reader2.Read())
                        {
                            Antecedente anotacion = new Antecedente();
                            anotacion.ClaveAntecedente = int.Parse(reader2["id_anotacion"].ToString());
                            anotacion.Libro = reader2["anotacion_libro"].ToString();
                            anotacion.Tomo = reader2["anotacion_tomo"].ToString();
                            anotacion.Semestre = reader2["anotacion_semestre"].ToString();
                            anotacion.Año = reader2["anotacion_anio"].ToString();
                            anotacion.Seccion = reader2["anotacion_seccion"].ToString();
                            anotacion.Serie = reader2["anotacion_serie"].ToString();
                            anotacion.Partida = reader2["anotacion_partida"].ToString();
                            anotacion.Observaciones = reader2["anotacion_observaciones"].ToString();
                            anotaciones.Add(anotacion);
                        }
                    }
                    reg.AnotacionesMarginales = anotaciones;
                    registros.Add(reg);
                    con2.Close();
                }
            }

            con.Close();
            return registros;
        }
        //Función que retorna un objeto Registro con la información de los datos de registro recibiendo como parámetro el id de la
        //relación de una prelación con un aco/movimiento.
        public static RegistroActo ObtenerDatosRegistro(int IdPrelacionActo)
        {
            RegistroActo reg = null;
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();

            SqlCommand comm = new SqlCommand("SELECT Registro.*, Municipios.nombre AS nombre_municipio, Poblaciones.nombre AS nombre_poblacion " +
                                                "FROM PrelacionesActos " +
                                                "INNER JOIN Registro " +
                                                "ON Registro.id_prelacion_acto = PrelacionesActos.id_prelacion_acto " +
                                                "INNER JOIN Municipios " +
                                                "ON Municipios.id_municipio = Registro.id_municipio " +
                                                "LEFT JOIN Poblaciones " +
                                                "ON Poblaciones.id_poblacion = Registro.id_poblacion " + 
                                                "WHERE PrelacionesActos.id_prelacion_acto = " + IdPrelacionActo + " " +
                                                "AND Poblaciones.id_municipio = Registro.id_municipio AND Poblaciones.id_poblacion = Registro.id_poblacion ", con);
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    reg = new RegistroActo();
                    reg.IdRegistro = int.Parse(reader["id_registro"].ToString());
                    reg.IdPrelacionActo = int.Parse(reader["id_prelacion_acto"].ToString());
                    reg.Folio = reader["folio"].ToString();
                    reg.TipoPredio = reader["tipo_predio"].ToString();
                    reg.Superficie = reader["superficie"].ToString();
                    reg.UnidadSuperficie = reader["unidad_superficie"].ToString();
                    reg.UbicacionInmuebleCalle = int.Parse(reader["ubicacion_inmueble_calle"].ToString());
                    reg.UbicacionInmuebleColonia = int.Parse(reader["ubicacion_inmueble_colonia"].ToString());
                    reg.UbicacionInmuebleNumero = int.Parse(reader["ubicacion_inmueble_numero"].ToString());
                    reg.ColoniaTexto = reader["colonia_texto"].ToString();
                    reg.CalleTexto = reader["calle_texto"].ToString();
                    reg.NumeroExterior = reader["numero_exterior_texto"].ToString();
                    reg.NumeroInterior = reader["numero_interior_texto"].ToString();
                    reg.Manzana = reader["manzana_texto"].ToString();
                    reg.Lote = reader["lote_texto"].ToString();
                    reg.Municipio = int.Parse(reader["id_municipio"].ToString());
                    reg.Poblacion = int.Parse(reader["id_poblacion"].ToString());
                    reg.ClaveCatastral = reader["clave_catastral"].ToString();
                    reg.Norte = reader["norte"].ToString();
                    reg.Sur = reader["sur"].ToString();
                    reg.Este = reader["este"].ToString();
                    reg.Oeste = reader["oeste"].ToString();
                    reg.Noreste = reader["noreste"].ToString();
                    reg.Noroeste = reader["noroeste"].ToString();
                    reg.Sureste = reader["sureste"].ToString();
                    reg.Suroeste = reader["suroeste"].ToString();
                    reg.FechaRegistro = reader["fecha_registro"].ToString();
                    reg.RegistroActual = new Antecedente();
                    reg.RegistroActual.Libro = reader["actual_libro"].ToString();
                    reg.RegistroActual.Seccion = reader["actual_seccion"].ToString();
                    reg.RegistroActual.Partida = reader["actual_partida"].ToString();
                    reg.RegistroActual.Serie = reader["actual_serie"].ToString();
                    reg.Observaciones = reader["observaciones"].ToString();
                    reg.municipioTexto = reader["nombre_municipio"].ToString();
                    reg.poblacionTexto = reader["nombre_poblacion"].ToString();
                    reg.AnotacionActualizada = reader["anotacion_actualizada"].ToString();

                    SqlConnection con2 = new SqlConnection(Connection.getConnection());
                    con2.Open();
                    SqlCommand comm2 = new SqlCommand("SELECT * FROM AnotacionesMarginales WHERE id_registro = " + reg.IdRegistro, con2);
                    SqlDataReader reader2 = comm2.ExecuteReader();
                    List<Antecedente> anotaciones = new List<Antecedente>();

                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            Antecedente anotacion = new Antecedente();
                            anotacion.ClaveAntecedente = int.Parse(reader2["id_anotacion"].ToString());
                            anotacion.Libro = reader2["anotacion_libro"].ToString();
                            anotacion.Tomo = reader2["anotacion_tomo"].ToString();
                            anotacion.Semestre = reader2["anotacion_semestre"].ToString();
                            anotacion.Año = reader2["anotacion_anio"].ToString();
                            anotacion.Seccion = reader2["anotacion_seccion"].ToString();
                            anotacion.Serie = reader2["anotacion_serie"].ToString();
                            anotacion.Partida = reader2["anotacion_partida"].ToString();
                            anotacion.Observaciones = reader2["anotacion_observaciones"].ToString();
                            anotaciones.Add(anotacion);
                        }
                    }
                    reg.AnotacionesMarginales = anotaciones;
                    con2.Close();

                    SqlConnection con3 = new SqlConnection(Connection.getConnection());
                    con3.Open();
                    SqlCommand comm3 = new SqlCommand("SELECT * FROM Otorgantes WHERE id_registro = " + reg.IdRegistro, con3);
                    SqlDataReader reader3 = comm3.ExecuteReader();
                    List<Persona> otorgantes = new List<Persona>();

                    if (reader3.HasRows)
                    {
                        while (reader3.Read())
                        {
                            Persona otorgante = new Persona();
                            otorgante.Nombre = reader3["otorgante_nombre"].ToString();
                            otorgante.Paterno = reader3["otorgante_paterno"].ToString();
                            otorgante.Materno = reader3["otorgante_materno"].ToString();
                            otorgantes.Add(otorgante);
                        }
                    }
                    reg.Otorgantes = otorgantes;
                    con3.Close();

                    SqlConnection con4 = new SqlConnection(Connection.getConnection());
                    con4.Open();
                    SqlCommand comm4 = new SqlCommand("SELECT * FROM Adquirientes WHERE id_registro = " + reg.IdRegistro, con4);
                    SqlDataReader reader4 = comm4.ExecuteReader();
                    List<Persona> adquirientes = new List<Persona>();

                    if (reader4.HasRows)
                    {
                        while (reader4.Read())
                        {
                            Persona adquiriente = new Persona();
                            adquiriente.Nombre = reader4["adquiriente_nombre"].ToString();
                            adquiriente.Paterno = reader4["adquiriente_paterno"].ToString();
                            adquiriente.Materno = reader4["adquiriente_materno"].ToString();
                            adquirientes.Add(adquiriente);
                        }
                    }
                    reg.Adquirientes = adquirientes;
                    con4.Close();
                }
            }
            con.Close();
            return reg;
        }

        public static String GuardarRegistroObjeto(RegistroActo registro)
        {
            SqlConnection con = new SqlConnection(Connection.getConnection());
            con.Open();
            using (SqlTransaction transaction = con.BeginTransaction())
            {
                //Si el id. del objeto registro es mayor a 0 se va a actualizar un registro
                if (registro.IdRegistro > 0)
                {
                    SqlCommand comm = new SqlCommand("UPDATE Registro " +
                                                        "SET folio = '" + registro.Folio + "', tipo_predio = '" + registro.TipoPredio + "', superficie = '" + registro.Superficie + "', unidad_superficie = '" + registro.UnidadSuperficie + "', ubicacion_inmueble_calle = " + registro.UbicacionInmuebleCalle + ", ubicacion_inmueble_colonia = " + registro.UbicacionInmuebleColonia + ", ubicacion_inmueble_numero = " + registro.UbicacionInmuebleNumero + ", colonia_texto = '" + registro.ColoniaTexto + "', calle_texto = '" + registro.CalleTexto + "', numero_exterior_texto = '" + registro.NumeroExterior + "', numero_interior_texto = '" + registro.NumeroInterior + "', manzana_texto = '" + registro.Manzana + "', lote_texto = '" + registro.Lote + "', id_municipio = " + registro.Municipio + ", id_poblacion = " + registro.Poblacion + ", clave_catastral = '" + registro.ClaveCatastral + "', norte = '" + registro.Norte + "', sur = '" + registro.Sur + "', este = '" + registro.Este + "', oeste = '" + registro.Oeste + "', noreste = '" + registro.Noreste + "', noroeste = '" + registro.Noroeste + "', sureste = '" + registro.Sureste + "', suroeste = '" + registro.Suroeste + "', fecha_registro = '" + registro.FechaRegistro + "', actual_libro = '" + registro.RegistroActual.Libro + "', actual_seccion = '" + registro.RegistroActual.Seccion + "', actual_partida = '" + registro.RegistroActual.Partida + "', observaciones = '" + registro.Observaciones + "', anotacion_actualizada ='" + registro.AnotacionActualizada + "' " + ", actual_serie = '" + registro.RegistroActual.Serie + "' " +
                                                        "WHERE id_registro = " + registro.IdRegistro, con, transaction);

                    comm.ExecuteNonQuery();

                    SqlCommand comm2 = new SqlCommand("DELETE FROM Adquirientes WHERE id_registro = " + registro.IdRegistro, con, transaction);
                    comm2.ExecuteNonQuery();

                    comm2 = new SqlCommand("DELETE FROM Otorgantes WHERE id_registro = " + registro.IdRegistro, con, transaction);
                    comm2.ExecuteNonQuery();

                    comm2 = new SqlCommand("DELETE FROM AnotacionesMarginales WHERE id_registro = " + registro.IdRegistro, con, transaction);
                    comm2.ExecuteNonQuery();

                    foreach (Persona item in registro.Adquirientes)
                    {
                        String res = registro.GuardarAdquiriente(registro.IdRegistro, item.Nombre, item.Paterno, item.Materno);
                        if (res != "OK")
                        {
                            throw new Exception();
                        }
                    }

                    foreach (Persona item in registro.Otorgantes)
                    {
                        String res = registro.GuardarOtorgante(registro.IdRegistro, item.Nombre, item.Paterno, item.Materno);
                        if (res != "OK")
                        {
                            throw new Exception();
                        }
                    }

                    foreach (Antecedente item in registro.AnotacionesMarginales)
                    {
                        String res = registro.GuardarAnotacionesMarginales(registro.IdRegistro, item.Libro, item.Tomo, item.Semestre, item.Año, item.Seccion, item.Serie, item.Partida, item.Observaciones);
                        if (res != "OK")
                        {
                            throw new Exception();
                        }
                    }

                    transaction.Commit();
                    con.Close();
                }
                else //de lo contrario se va a ingresar un registro nuevo
                {
                    try
                    {
                        SqlCommand comm = new SqlCommand("INSERT INTO Registro " +
                                                            "OUTPUT inserted.id_registro " +
                                                            "VALUES (" + registro.IdPrelacionActo + ", '" + registro.Folio + "', '" + registro.TipoPredio + "', '" + registro.Superficie + "', '" + registro.UnidadSuperficie + "', " + registro.UbicacionInmuebleCalle + ", " + registro.UbicacionInmuebleColonia + ", " + registro.UbicacionInmuebleNumero + ", '" + registro.ColoniaTexto + "', '" + registro.CalleTexto + "', '" + registro.NumeroExterior + "', '" + registro.NumeroInterior + "', '" + registro.Manzana + "', '" + registro.Lote + "', " + registro.Municipio + ", " + registro.Poblacion + ", '" + registro.ClaveCatastral + "', '" + registro.Norte + "', '" + registro.Sur + "', '" + registro.Este + "', '" + registro.Oeste + "','" + registro.Noreste + "', '" + registro.Noroeste + "', '" + registro.Sureste + "', '" + registro.Suroeste + "', '" + registro.FechaRegistro + "', '" + registro.RegistroActual.Libro + "', '" + registro.RegistroActual.Seccion + "', '" + registro.RegistroActual.Partida + "', '" + registro.Observaciones + "', '" + registro.AnotacionActualizada + "', '" + registro.RegistroActual.Serie + "')", con, transaction);

                        int result = (int)comm.ExecuteScalar();
                        registro.IdRegistro = result;
                        if (result > 0)
                        {
                            SqlCommand comm2 = new SqlCommand("UPDATE PrelacionesActos SET estado_movimiento = 'REGISTRADA' WHERE id_prelacion_acto = " + registro.IdPrelacionActo, con, transaction);
                            int result2 = comm2.ExecuteNonQuery();
                        }

                        foreach (Persona item in registro.Adquirientes)
                        {
                            String res = registro.GuardarAdquiriente(registro.IdRegistro, item.Nombre, item.Paterno, item.Materno);
                            if (res != "OK")
                            {
                                throw new Exception();
                            }
                        }

                        foreach (Persona item in registro.Otorgantes)
                        {
                            String res = registro.GuardarOtorgante(registro.IdRegistro, item.Nombre, item.Paterno, item.Materno);
                            if (res != "OK")
                            {
                                throw new Exception();
                            }
                        }

                        foreach (Antecedente item in registro.AnotacionesMarginales)
                        {
                            String res = registro.GuardarAnotacionesMarginales(registro.IdRegistro, item.Libro, item.Tomo, item.Semestre, item.Año, item.Seccion, item.Serie, item.Partida, item.Observaciones);
                            if (res != "OK")
                            {
                                throw new Exception();
                            }
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
            }
            return "OK";
        }
    }
}
