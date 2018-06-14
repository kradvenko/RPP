using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPPMain
{
    public class Main
    {
        public AreasTrabajoCollection AreasTrabajo
        {
            get
            {
                return new AreasTrabajoCollection();
            }
        }

        public ActosCollection Actos
        {
            get
            {
                return new ActosCollection();
            }
        }

        public MovimientosCollection Movimientos
        {
            get
            {
                return new MovimientosCollection();
            }
        }

        public TarifasCollection Tarifas
        {
            get
            {
                return new TarifasCollection();
            }
        }

        public EstatusCollection Estatus
        {
            get
            {
                return new EstatusCollection();
            }
        }

        public TiposFolioCollection Folios
        {
            get
            {
                return new TiposFolioCollection();
            }
        }

        public MunicipiosCollection Municipios
        {
            get
            {
                return new MunicipiosCollection();
            }
        }

        public PoblacionesCollecion Poblaciones
        {
            get
            {
                return new PoblacionesCollecion();
            }
        }

        public UsuariosCollection Usuarios
        {
            get
            {
                return new UsuariosCollection();
            }
        }

        public TiposUsuarioCollection TiposUsuario
        {
            get
            {
                return new TiposUsuarioCollection();
            }
        }

        public ParametrosCollection Parametros
        {
            get
            {
                return new ParametrosCollection();
            }
        }

        public SeccionArchivoCollection Secciones
        {
            get
            {
                return new SeccionArchivoCollection();
            }
        }
        public TramitantesCollection Tramitantes
        {
            get
            {
                return new TramitantesCollection();
            }
        }
    }
}
