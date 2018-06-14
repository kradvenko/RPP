using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPPMain
{
    public class TipoUsuario
    {
        private int idTipoUsuario;
        private String tipo;

        public int Clave
        {
            get
            {
                return idTipoUsuario;
            }
            set
            {
                idTipoUsuario = value;
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
    }
}
