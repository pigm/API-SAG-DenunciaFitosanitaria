namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class CategoriaTipoDenunciaModel
    {
        public CategoriaTipoDenunciaModel()
        {
            CategoriaModel = new CategoriaModel();
            TipoDenunciaModel = new TipoDenunciaModel();
        }
        public int idCatTipoDenuncia { get; set; }
        public int idTipoDenuncia { get; set; }
        public int idCategoria { get; set; }
        public bool estado { get; set; }
        
        public TipoDenunciaModel denuncia { get; set; }

        public CategoriaModel CategoriaModel { get; set; }
        public TipoDenunciaModel TipoDenunciaModel { get; set; }
        

        //public List<SelectListItem> ListaTipoDenuncia { get; private set; }


        //public void ObtenerTipoDenuncia()
        //{
        //    ListaTipoDenuncia = new List<SelectListItem>();

        //    var tipoDenunciaServicio = new TipoDenunciaServicio();

        //    var listaTipoDenuncia = tipoDenunciaServicio.ListaTipoDenuncia();

        //    ListaTipoDenuncia.Add(new SelectListItem { Value = "0", Text = "Seleccione Tipo Denuncia" });

        //    foreach (var tipoDenuncia in listaTipoDenuncia)
        //    {
        //        if (tipoDenuncia.Nombre.ToUpper() != "OTRO")
        //        {
        //            ListaTipoDenuncia.Add(new SelectListItem
        //            {
        //                Value = tipoDenuncia.IdTipoDenuncia.ToString(),
        //                Text = tipoDenuncia.Nombre
        //            });
        //        }
        //    }
        //}
    }
}