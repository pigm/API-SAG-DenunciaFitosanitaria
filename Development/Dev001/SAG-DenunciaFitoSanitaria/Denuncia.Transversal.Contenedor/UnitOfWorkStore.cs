using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Denuncia.Transversal.Contenedor
{
    /// <summary>
    /// Utility class for storing objects pertinent to a unit of work.
    /// </summary>
    public static class UnitOfWorkStore
    {
        /// <summary>
        /// Retrieve an object from this store via unique key.
        /// Will return null if it doesn't exist in the store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetData(string key)
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Items[key];
            return CallContext.GetData(key);
        }


        /// <summary>
        /// Put an item in this store, by unique key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public static void SetData(string key, object data)
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items[key] = data;
            else
                CallContext.SetData(key, data);
        }
    }
}
