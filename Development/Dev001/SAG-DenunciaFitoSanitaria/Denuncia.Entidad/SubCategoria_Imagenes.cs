//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Denuncia.Entidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubCategoria_Imagenes
    {
        public int IdSubCategoria { get; set; }
        public string Imagen1 { get; set; }
        public string Descripcion1 { get; set; }
        public string Imagen2 { get; set; }
        public string Descripcion2 { get; set; }
        public string Imagen3 { get; set; }
        public string Descripcion3 { get; set; }
        public string Imagen4 { get; set; }
        public string Descripcion4 { get; set; }
    
        public virtual SubCategoria SubCategoria { get; set; }
    }
}
