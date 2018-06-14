using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class Antecedente
    {
        private int idAntecendente;
        private int idPrelacion;
        private String libro;
        private String tomo;
        private String semestre;
        private String seccion;
        private String serie;
        private String partida;
        private String anio;
        private String folio;
        private String observaciones;        

        public int ClaveAntecedente
        {
            get
            {
                return idAntecendente;
            }
            set
            {
                idAntecendente = value;
            }
        }

        public int Id
        {
            get
            {
                return idAntecendente;
            }
            set
            {
                idAntecendente = value;
            }
        }

        public int ClavePrelacion
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

        public String Libro
        {
            get
            {
                return libro;
            }
            set
            {
                libro = value;
            }
        }

        public String Tomo
        {
            get
            {
                return tomo;
            }
            set
            {
                tomo = value;
            }
        }

        public String Semestre
        {
            get
            {
                return semestre;
            }
            set
            {
                semestre = value;
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

        public String Serie
        {
            get
            {
                return serie;
            }
            set
            {
                serie = value;
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

        public String Año
        {
            get
            {
                return anio;
            }
            set
            {
                anio = value;
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
    }
}
