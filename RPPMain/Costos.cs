using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPMain
{
    public class Costos
    {
        #region Variables Privadas
        private int idActo;
        private String claveIngresos;
        private String nombreActo;
        private int cantidad;
        private float importe;
        private float total;
        #endregion

        public Costos()
        {

        }

        public int IdActo
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

        public String Ingresos
        {
            get
            {
                return claveIngresos;
            }
            set
            {
                claveIngresos = value;
            }
        }
        public String  NombreActo
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

        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }

        public float Importe
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

        public float Total
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
    }
}
