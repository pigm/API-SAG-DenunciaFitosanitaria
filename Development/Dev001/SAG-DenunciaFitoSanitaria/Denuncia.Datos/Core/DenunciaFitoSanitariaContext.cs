using Denuncia.Datos.Modelo;
using Denuncia.Transversal.Contenedor;

namespace Denuncia.Entidad
{
    public class DenunciaFitoSanitariaContext
    {
        private readonly dbDenunciaFitoSanitariaEntities singleton;
        private static readonly string UOW_INSTANCE_KEY = "DenunciaFitoSanitaria_Instance";
        private static readonly object s_objSync = new object();

        public DenunciaFitoSanitariaContext()
        {
            singleton = new dbDenunciaFitoSanitariaEntities();
        }

        static public dbDenunciaFitoSanitariaEntities getSingleton()
        {
            object instance = UnitOfWorkStore.GetData(UOW_INSTANCE_KEY);

            // Dirty, non-thread safe check
            if (instance == null)
            {
                lock (s_objSync)
                {
                    // Thread-safe check, now that we're locked
                    if (instance == null) // Ignore resharper warning that "expression is always true".  It's not considering thread-safety.
                    {
                        // Create a new instance of the MyDataLayer management class, and store it in the UnitOfWorkStore,
                        // using the string literal key defined in this class.
                        instance = new dbDenunciaFitoSanitariaEntities();
                        UnitOfWorkStore.SetData(UOW_INSTANCE_KEY, instance);
                    }
                }
            }

            return (dbDenunciaFitoSanitariaEntities)instance;
        }

        static public void setDispose()
        {
            UnitOfWorkStore.SetData(UOW_INSTANCE_KEY, null);
        }

    }
}

