using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPMain
{
    public class Persona
    {

        private int idPersona;
        private String tipo;
        private String nombre;
        private String paterno;
        private String materno;

        public Persona()
        {

        }

        public int Clave
        {
            get
            {
                return idPersona;
            }
            set
            {
                idPersona = value;
            }
        }

        public int IdPersona
        {
            get
            {
                return idPersona;
            }
            set
            {
                idPersona = value;
            }
        }

        public int Id
        {
            get
            {
                return idPersona;
            }
            set
            {
                idPersona = value;
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

        public String Paterno
        {
            get
            {
                return paterno;
            }
            set
            {
                paterno = value;
            }
        }

        public String Materno
        {
            get
            {
                return materno;
            }
            set
            {
                materno = value;
            }
        }
    }
}
