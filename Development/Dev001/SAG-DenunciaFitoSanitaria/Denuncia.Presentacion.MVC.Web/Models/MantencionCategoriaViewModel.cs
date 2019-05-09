using AutoMapper;
using Denuncia.Entidad;
using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class MantencionCategoriaViewModel
    {
        public CategoriaModel CategoriaModel { get; set; }

        public List<CategoriaModel> ListaCategoria { get; set; }

        public List<CategoriaModel> ListaTipoDenuncia { get; set; }

        public void ListarCategorias()
        {
            ListaCategoria = new List<CategoriaModel>();
            var categoriaServicio = new CategoriaServicio();
            var listadoCategoria = categoriaServicio.ListaCategorias();
            ListaCategoria = Mapper.Map<List<CategoriaModel>>(listadoCategoria);
        }

        public void ListarCategoriasMantenedor()
        {
            ListaCategoria = new List<CategoriaModel>();
            var categoriaServicio = new CategoriaServicio();
            var listadoCategoria = categoriaServicio.ListaCategoriasMantenedor();
            ListaCategoria = Mapper.Map<List<CategoriaModel>>(listadoCategoria);
        }



        public void ObtenerCategoria(int idCategoria)
        {
            CategoriaModel = new CategoriaModel();
            var categoriaServicio = new CategoriaServicio();
            var categoriaEntidad = categoriaServicio.ObtenerCategoria(idCategoria);
            CategoriaModel = Mapper.Map<CategoriaModel>(categoriaEntidad);
        }




        public void Agregar(CategoriaModel categoriaModel)
        {
            var categoriaServicio = new CategoriaServicio();
            var categoriaEntidad = new Categoria();
            categoriaEntidad.IdTipoDenuncia = categoriaModel.IdTipoDenuncia;
            categoriaEntidad.Nombre = categoriaModel.Nombre;
            categoriaEntidad.Estado = categoriaModel.Estado;
            var archivo = GuardarImagen(categoriaModel.FotoImagen, true);
            categoriaEntidad.ImagenUrl = string.Format("~/assets/apps/img/{0}", archivo);
            categoriaServicio.Agregar(categoriaEntidad);
        }




        public void Modificar(CategoriaModel categoriaModel)
        {
            var categoriaServicio = new CategoriaServicio();
            var categoriaEntidad = new Categoria();
            categoriaEntidad.IdCategoria = categoriaModel.IdCategoria;
            categoriaEntidad.IdTipoDenuncia = categoriaModel.IdTipoDenuncia;
            categoriaEntidad.Nombre = categoriaModel.Nombre;
            categoriaEntidad.Estado = categoriaModel.Estado;
            var archivo = GuardarImagen(categoriaModel.FotoImagen, false, categoriaModel.ImagenUrl);
            categoriaEntidad.ImagenUrl = !string.IsNullOrEmpty(archivo) ? string.Format("~/assets/apps/img/{0}", archivo) : categoriaModel.ImagenUrl;
            categoriaServicio.Modificar(categoriaEntidad);
        }




        private string GuardarImagen(HttpPostedFileBase file, bool esNuevo, string url = null)
        {
            string formatoArchivo = null;
            if (esNuevo)
            {
                string ruta3 = HttpContext.Current.Server.MapPath("~/assets/apps/img");
                var nombreArchivo = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                formatoArchivo = string.Format("{0}-{1}{2}", nombreArchivo, DateTime.Now.ToString("yyyyMMddHHmm"), extension);
                string fullpath = String.Format("{0}\\{1}", ruta3, formatoArchivo);
                file.SaveAs(fullpath);
            }
            else
            {
                if (file != null)
                {
                    var nombreArchivoAnterior = Path.GetFileName(url);
                    string ruta = Path.Combine(HostingEnvironment.MapPath("~/assets/apps/img"), nombreArchivoAnterior);
                    File.Delete(ruta);

                    string ruta3 = HttpContext.Current.Server.MapPath("~/assets/apps/img");
                    var nombreArchivoNuevo = Path.GetFileNameWithoutExtension(file.FileName);
                    var extension = Path.GetExtension(file.FileName);
                    formatoArchivo = string.Format("{0}-{1}{2}", nombreArchivoNuevo, DateTime.Now.ToString("yyyyMMddHHmm"), extension);
                    string fullpath = String.Format("{0}\\{1}", ruta3, formatoArchivo);
                    file.SaveAs(fullpath);
                }
            }
            return formatoArchivo;
        }
    }
}