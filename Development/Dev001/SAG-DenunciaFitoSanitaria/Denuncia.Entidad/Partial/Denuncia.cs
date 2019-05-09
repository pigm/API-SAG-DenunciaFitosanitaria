using Newtonsoft.Json.Linq;
using System;

namespace Denuncia.Entidad
{
    public partial class Denuncia
    {
        public string tipoDenuncia { get; set; }
        public string estadoDenuncia { get; set; }
        public string subcate { get; set; }
        public string catego { get; set; }

        public string Direccion
        {
            get
            {
                var Result = Georeferencia;
                try
                {
                    JObject jArray = JObject.Parse(Result);
                    return (string)jArray["results"][0]["formatted_address"];
                }
                catch (Exception e)
                {
                    return "Sin Dirección";
                }
            }
        }

        public string Referencia
        {
            get
            {
                if (string.IsNullOrEmpty(Descripcion))
                    return string.Empty;
                else
                {
                    string s = Descripcion;
                    string[] words = s.Split('\n');
                    return words[1].Replace("Referencia:", string.Empty).ToString();
                }
            }
        }

        public string DescripcionCortada
        {
            get
            {
                if (string.IsNullOrEmpty(Descripcion))
                    return string.Empty;
                else
                {
                    string s = Descripcion;
                    string[] words = s.Split('\n');
                    return words[0].ToString();
                }
            }
        }

    }
}
