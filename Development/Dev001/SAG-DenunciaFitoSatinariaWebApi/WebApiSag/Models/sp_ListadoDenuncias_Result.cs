//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiSag.Models
{
    using System;
    
    public partial class sp_ListadoDenuncias_Result
    {
        public int IdDenuncia { get; set; }
        public string estadoDenuncia { get; set; }
        public string tipoDenuncia { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }
        public string Descripcion { get; set; }
    }
}
