using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiSag.Request.User
{
    public class InsertDenuncia
    {
        [Required]
        public int idestadodenuncia { get; set; }
        [Required]
        public string descripcion { get; set; }
        public string CorreoContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public DateTime FechaEnvio  { get; set; }
        public string MensajeVoz { get; set; }
        [Required]
        public string imagenurl { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        [Required]
        public int idsubcategoria { get; set; }
        public string geolocalizacion { get; set; }
    }
}