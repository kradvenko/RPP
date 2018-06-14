using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPMain
{
    public class CompendioDigitalizacion
    {
        public int idCompendio;
        public string tipoDocumento;
        public string numeroDocumento;
        public string fechaDocumento;
        public string lugarOtorgamiento;
        public string notaria;
        public string actos;
        public string antRegLibro;
        public string antRegTomo;
        public string antRegSemestre;
        public string antRegAnio;
        public string antRegSeccion;
        public string antRegSerie;
        public string antRegPartida;
        public string otorgantes;
        public string adquirientes;
        public string valorOperacion;
        public string tipoMoneda;
        public string tipoPredio;
        public string superficie;
        public string unidadSuperficie;
        public string descripcion;
        public string municipio;
        public string poblacion;
        public string claveCatastral;
        public string norte;
        public string sur;
        public string este;
        public string oeste;
        public string noreste;
        public string sureste;
        public string suroeste;
        public string noroeste;
        public string fechaRegistro;
        public string regActLibro;
        public string regActTomo;
        public string regActSemestre;
        public string regActAnio;
        public string regActSeccion;
        public string regActSerie;
        public string regActPartida;
        public string anotacionesMarginales;
        public string anotacionesMarginalesAdicionales;
        public string anMargLibro;
        public string anMargSemestre;
        public string anMargTomo;
        public string anMargAnio;
        public string anMargSeccion;
        public string anMargSerie;
        public string anMargPartida;
        public string observaciones;
        public string inegiEstado;
        public string inegiMunicipio;
        public string inegiPoblacion;
        public string inegiColonia;
        public string inegiCalle;
        public string inegiNumeroCalle;
        public string folioPropiedad;
        public string folioSistema;

        public CompendioDigitalizacion()
        {

        }

        public static string CrearCompendio(Prelacion prelacion)
        {
            try
            {
                List<Movimientos> actos = new List<Movimientos>();
                List<Antecedente> antecedentes = new List<Antecedente>();
                List<RegistroActo> registros = new List<RegistroActo>();
                List<Antecedente> anotaciones = new List<Antecedente>();

                string actosString = "";
                string an_reg_libro = "";
                string an_reg_tomo = "";
                string an_reg_semestre = "";
                string an_reg_anio = "";
                string an_reg_seccion = "";
                string an_reg_serie = "";
                string an_reg_partida = "";

                string otorgantes = "";
                string adquirientes = "";

                string an_marg_observaciones = "";
                string an_marg_libro = "";
                string an_marg_tomo = "";
                string an_marg_semestre = "";
                string an_marg_anio = "";
                string an_marg_seccion = "";
                string an_marg_serie = "";
                string an_marg_partida = "";

                string tipoPredio = "";
                string superficie = "";
                string unidadSuperficie = "";
                string descripcion = "";
                string municipio = "";
                string poblacion = "";
                string claveCatastral = "";
                string norte = "";
                string sur = "";
                string este = "";
                string oeste = "";
                string noreste = "";
                string noroeste = "";
                string sureste = "";
                string suroeste = "";
                string fechaRegistro = "";
                string reg_act_libro = "";
                string reg_act_tomo = "";
                string reg_act_semestre = "";
                string reg_act_anio = "";
                string reg_act_seccion = "";
                string reg_act_serie = "";
                string reg_act_partida = "";
                string inegiEstado = "";
                string inegiMunicipio = "";
                string inegiPoblacion = "";
                string inegiColonia = "";
                string inegiCalle = "";
                string inegiNumeroCalle = "";
                

                bool flag = true;

                actos = Prelacion.ObtenerMovimientosPrelacion(prelacion.IdPrelacion, "");
                antecedentes = Prelacion.ObtenerAntecedentesPrelacion(prelacion.IdPrelacion);
                registros = RegistroActo.ObtenerDatosListaRegistrosPrelacion(prelacion.IdPrelacion);


                foreach (Movimientos item in actos)
                {
                    if (flag)
                    {
                        actosString = actosString + item.NombreActo;
                        flag = false;
                    }
                    else
                    {
                        actosString = actosString + "|"+ item.NombreActo;                        
                    }
                }
                flag = true;
                foreach (Antecedente item in antecedentes)
                {
                    if (flag)
                    {
                        an_reg_libro = an_reg_libro + item.Libro;
                        an_reg_tomo = an_reg_tomo + item.Tomo;
                        an_reg_semestre = an_reg_semestre + item.Semestre;
                        an_reg_anio = an_reg_anio + item.Año;
                        an_reg_seccion = an_reg_seccion + item.Seccion;
                        an_reg_serie = an_reg_serie + item.Serie;
                        an_reg_partida = an_reg_partida + item.Partida;
                        flag = false;
                    }
                    else
                    {
                        an_reg_libro = an_reg_libro + "|" + item.Libro;
                        an_reg_tomo = an_reg_tomo + "|" + item.Tomo;
                        an_reg_semestre = an_reg_semestre + "|" + item.Semestre;
                        an_reg_anio = an_reg_anio + "|" + item.Año;
                        an_reg_seccion = an_reg_seccion + "|" + item.Seccion;
                        an_reg_serie = an_reg_serie + "|" + item.Serie;
                        an_reg_partida = an_reg_partida + "|" + item.Partida;
                    }
                }
                flag = true;
                foreach (RegistroActo item in registros)
	            {		            
                    RegistroActo temp = RegistroActo.ObtenerDatosRegistro(item.IdRegistro);

                    if (temp != null)
                    {
                        if (temp.Otorgantes != null)
                        {
                            foreach (Persona otorgante in temp.Otorgantes)
                            {
                                if (otorgantes.Length > 0)
                                {
                                    otorgantes = otorgantes + "|" + otorgante.Nombre;
                                }
                                else
                                {
                                    otorgantes = otorgante.Nombre;
                                }
                            }
                        }
                        if (temp.Adquirientes != null)
                        {
                            foreach (Persona adquiriente in temp.Adquirientes)
                            {
                                if (adquirientes.Length > 0)
                                {
                                    adquirientes = adquirientes + "|" + adquiriente.Nombre;
                                }
                                else
                                {
                                    adquirientes = adquiriente.Nombre;
                                }
                            }
                        }
                        if (temp.AnotacionesMarginales != null)
                        {
                            foreach (Antecedente anotacion in temp.AnotacionesMarginales)
                            {
                                if (anotacion != null)
                                {
                                    if (an_marg_observaciones.Length > 0)
                                    {
                                        an_marg_observaciones = an_marg_observaciones + "|" + anotacion.Observaciones;
                                    }
                                    else
                                    {
                                        an_marg_observaciones = an_marg_observaciones + anotacion.Observaciones;
                                    }

                                    if (an_marg_libro.Length > 0)
                                    {
                                        an_marg_libro = an_marg_libro + "|" + anotacion.Libro;
                                    }
                                    else
                                    {
                                        an_marg_libro = an_marg_libro + anotacion.Libro;
                                    }

                                    if (an_marg_tomo.Length > 0)
                                    {
                                        an_marg_tomo = an_marg_tomo + "|" + anotacion.Tomo;
                                    }
                                    else
                                    {
                                        an_marg_tomo = an_marg_tomo + anotacion.Tomo;
                                    }

                                    if (an_marg_semestre.Length > 0)
                                    {
                                        an_marg_semestre = an_marg_semestre + "|" + anotacion.Semestre;
                                    }
                                    else
                                    {
                                        an_marg_semestre = an_marg_semestre + anotacion.Semestre;
                                    }

                                    if (an_marg_anio.Length > 0)
                                    {
                                        an_marg_anio = an_marg_anio + "|" + anotacion.Año;
                                    }
                                    else
                                    {
                                        an_marg_anio = an_marg_anio + anotacion.Año;
                                    }

                                    if (an_marg_seccion.Length > 0)
                                    {
                                        an_marg_seccion = an_marg_seccion + "|" + anotacion.Seccion;
                                    }
                                    else
                                    {
                                        an_marg_seccion = an_marg_seccion + anotacion.Seccion;
                                    }

                                    if (an_marg_serie.Length > 0)
                                    {
                                        an_marg_serie = an_marg_serie + "|" + anotacion.Serie;
                                    }
                                    else
                                    {
                                        an_marg_serie = an_marg_serie + anotacion.Serie;
                                    }

                                    if (an_marg_partida.Length > 0)
                                    {
                                        an_marg_partida = an_marg_partida + "|" + anotacion.Partida;
                                    }
                                    else
                                    {
                                        an_marg_partida = an_marg_partida + anotacion.Partida;
                                    }
                                }
                            }
                        }

                        tipoPredio = tipoPredio.Length > 0 ? tipoPredio + "|" + item.TipoPredio : item.TipoPredio;
                        superficie = superficie.Length > 0 ? superficie + "|" + item.Superficie : item.Superficie;
                        unidadSuperficie = unidadSuperficie.Length > 0 ? unidadSuperficie + "|" + item.UnidadSuperficie : item.UnidadSuperficie;
                        
                        municipio = municipio.Length > 0 ? municipio + "|" + item.MunicipioTexto : item.MunicipioTexto;
                        poblacion = poblacion.Length > 0 ? poblacion + "|" + item.PoblacionTexto : item.PoblacionTexto;
                        claveCatastral = claveCatastral.Length > 0 ? claveCatastral + "|" + item.ClaveCatastral : item.ClaveCatastral;
                        norte = norte.Length > 0 ? norte + "|" + item.Norte : item.Norte;
                        sur = sur.Length > 0 ? sur + "|" + item.Sur : item.Sur;
                        este = este.Length > 0 ? este + "|" + item.Este : item.Este;
                        oeste = oeste.Length > 0 ? oeste + "|" + item.Oeste : item.Oeste;
                        noreste = noreste.Length > 0 ? noreste + "|" + item.Noreste : item.Noreste;
                        noroeste = noroeste.Length > 0 ? noroeste + "|" + item.Noroeste : item.Noroeste;
                        sureste = sureste.Length > 0 ? sureste + "|" + item.Sureste : item.Sureste;
                        suroeste = suroeste.Length > 0 ? suroeste + "|" + item.Suroeste : item.Suroeste;
                        fechaRegistro = fechaRegistro.Length > 0 ? fechaRegistro + "|" + item.FechaRegistro : item.FechaRegistro;
                        reg_act_libro = reg_act_libro.Length > 0 ? reg_act_libro + "|" + item.RegistroActual.Libro : item.RegistroActual.Libro;
                        reg_act_tomo = reg_act_tomo.Length > 0 ? reg_act_tomo + "|" + item.RegistroActual.Tomo : item.RegistroActual.Tomo;
                        reg_act_semestre = reg_act_semestre.Length > 0 ? reg_act_semestre + "|" + item.RegistroActual.Semestre : item.RegistroActual.Semestre;
                        reg_act_anio = reg_act_anio.Length > 0 ? reg_act_anio + "|" + item.RegistroActual.Año : item.RegistroActual.Año;
                        reg_act_seccion = reg_act_seccion.Length > 0 ? reg_act_seccion + "|" + item.RegistroActual.Seccion : item.RegistroActual.Seccion;
                        reg_act_serie = reg_act_serie.Length > 0 ? reg_act_serie + "|" + item.RegistroActual.Serie : item.RegistroActual.Serie;
                        reg_act_partida = reg_act_partida.Length > 0 ? reg_act_partida + "|" + item.RegistroActual.Partida : item.RegistroActual.Partida;
                        /*inegiEstado = inegiEstado.Length > 0 ? inegiEstado + "|" + item : item.Superficie;
                        inegiMunicipio = superficie.Length > 0 ? superficie + "|" + item.Superficie : item.Superficie;
                        inegiPoblacion = superficie.Length > 0 ? superficie + "|" + item.Superficie : item.Superficie;
                        inegiColonia = superficie.Length > 0 ? superficie + "|" + item.Superficie : item.Superficie;
                        inegiCalle = superficie.Length > 0 ? superficie + "|" + item.Superficie : item.Superficie;
                        inegiNumeroCalle = superficie.Length > 0 ? superficie + "|" + item.Superficie : item.Superficie;*/
                    }                    
	            }

                SqlConnection con = new SqlConnection(Connection.getConnection());
                con.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO CompendioDigitalizacion VALUES (" +
                                                 "'Escritura Pública', '" + prelacion.NumeroEscritura + "', '" + prelacion.FechaDocumento + "', '" + prelacion.LugarOtorgamiento + "', '" + prelacion.Tramitante + "', '" + actosString + "', '" + an_reg_libro + "', '" + an_reg_tomo + "', '" + an_reg_semestre + "', '" + an_reg_anio + "', '" + an_reg_seccion + "', '" + an_reg_serie + "', '" + an_reg_partida + "', '" + otorgantes + "', '" + adquirientes + "', '" + prelacion.ValorInmueble + "', '" + prelacion.TipoMoneda + "', '" + tipoPredio + "', '" + superficie + "', '" + unidadSuperficie + "', '" + prelacion.DescripcionBien + "', '" + municipio + "', '" + poblacion + "', '" + claveCatastral + "', '" + norte + "', '" + sur + "', '" + este + "', '" + oeste + "', '" + noreste + "', '" + sureste + "', '" + suroeste + "', '" + noroeste + "', '" + fechaRegistro + "', '" + reg_act_libro + "', '" + reg_act_tomo + "', '" + reg_act_semestre + "', '" + reg_act_anio + "', '" + reg_act_seccion + "', '" + reg_act_serie + "', '" + reg_act_partida + "', '" + an_marg_observaciones + "', '', '" + an_marg_libro + "', '" + an_marg_semestre + "', '" + an_marg_semestre + "', '" + an_marg_anio + "', '" + an_marg_seccion + "', '" + an_marg_serie + "', '" + an_marg_partida + "', '" + an_marg_observaciones + "', 'inegiestado', 'inegimunicipio', 'inegipoblacion', 'inegicolonia', 'inegicalle', 'ineginumerocalle', '" + prelacion.Folio + "', '" + prelacion.IdPrelacion + "')", con);
                int result = comm.ExecuteNonQuery();
                if (result > 0)
                {
                    con.Close();                    
                }
                else
                {
                    con.Close();                    
                }

                return "OK";
            }
            catch (Exception exc)
            {
                return (exc.Message);
            }
        }

    }
}
