using AutoMapper;
using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class MantencionTipoInsectoViewModel
    {
        //public TipoInsectoModel TipoInsectoModel { get; set; }
        //public List<TipoInsectoModel> ListaTipoInsecto { get; set; }

        //public void ListarTipoInsecto()
        //{
        //    ListaTipoInsecto = new List<TipoInsectoModel>();
        //    var tipoInsectoServicio = new SubCategoriaServicio();
        //    var listadoTipoInsecto = tipoInsectoServicio.ListaTipoInsecto();
        //    ListaTipoInsecto = Mapper.Map<List<TipoInsectoModel>>(listadoTipoInsecto);
        //}

        //public void ObtenerInsecto(int idTipoInsecto)
        //{
        //    TipoInsectoModel = new TipoInsectoModel();
        //    var tipoInsectoServicio = new SubCategoriaServicio();
        //    var tipoInsectoEntidad = tipoInsectoServicio.ObtenerInsecto(idTipoInsecto);
        //    TipoInsectoModel = Mapper.Map<TipoInsectoModel>(tipoInsectoEntidad);
        //}

        //public void Agregar(TipoInsectoModel tipoInsectoModel)
        //{
        //    var tipoInsectoServicio = new SubCategoriaServicio();
        //    var tipoInsectoEntidad = new TipoInsecto();
        //    tipoInsectoEntidad.IdTipoCategoria = tipoInsectoModel.IdTipoCategoria;
        //    tipoInsectoEntidad.Nombre = tipoInsectoModel.Nombre;
        //    tipoInsectoEntidad.Descripcion= tipoInsectoModel.Descripcion;
        //    tipoInsectoEntidad.Estado = true;
        //    var archivo = GuardarImagen(tipoInsectoModel.FotoImagen, true);
        //    tipoInsectoEntidad.ImagenUrl = string.Format("~\\assets\\apps\\archivos\\imagenes\\{0}", archivo);
        //    tipoInsectoServicio.Agregar(tipoInsectoEntidad);
        //}

        //public void Modificar(TipoInsectoModel tipoInsectoModel)
        //{
        //    var tipoInsectoServicio = new SubCategoriaServicio();
        //    var tipoInsectoEntidad = new TipoInsecto();
        //    tipoInsectoEntidad.IdTipoInsecto = tipoInsectoModel.IdTipoInsecto;
        //    tipoInsectoEntidad.IdTipoCategoria = tipoInsectoModel.IdTipoCategoria;            
        //    tipoInsectoEntidad.Nombre = tipoInsectoModel.Nombre;
        //    tipoInsectoEntidad.Descripcion = tipoInsectoModel.Descripcion;
        //    tipoInsectoEntidad.Estado = tipoInsectoModel.Estado;
        //    var archivo = GuardarImagen(tipoInsectoModel.FotoImagen, false, tipoInsectoModel.ImagenUrl);
        //    tipoInsectoEntidad.ImagenUrl = !string.IsNullOrEmpty(archivo) ? string.Format("~\\assets\\apps\\archivos\\imagenes\\{0}", archivo) : tipoInsectoModel.ImagenUrl;
        //    tipoInsectoServicio.Modificar(tipoInsectoEntidad);
        //}

        //private string GuardarImagen(HttpPostedFileBase file, bool esNuevo, string url = null)
        //{
        //    string formatoArchivo = null;
        //    if (esNuevo)
        //    {
        //        string ruta3 = HttpContext.Current.Server.MapPath("~/assets/apps/archivos/imagenes");
        //        var nombreArchivo = Path.GetFileNameWithoutExtension(file.FileName);
        //        var extension = Path.GetExtension(file.FileName);
        //        formatoArchivo = string.Format("{0}-{1}{2}", nombreArchivo, DateTime.Now.ToString("yyyyMMddHHmmss"), extension);
        //        string fullpath = String.Format("{0}\\{1}", ruta3, formatoArchivo);
        //        file.SaveAs(fullpath);
        //    }
        //    else
        //    {
        //        if (file != null)
        //        {
        //            var nombreArchivoAnterior = Path.GetFileName(url);
        //            string ruta = Path.Combine(HostingEnvironment.MapPath("~/assets/apps/archivos/imagenes"), nombreArchivoAnterior);
        //            File.Delete(ruta);

        //            string ruta3 = HttpContext.Current.Server.MapPath("~/assets/apps/archivos/imagenes");
        //            var nombreArchivoNuevo = Path.GetFileNameWithoutExtension(file.FileName);
        //            var extension = Path.GetExtension(file.FileName);
        //            formatoArchivo = string.Format("{0}-{1}{2}", nombreArchivoNuevo, DateTime.Now.ToString("yyyyMMddHHmmss"), extension);
        //            string fullpath = String.Format("{0}\\{1}", ruta3, formatoArchivo);
        //            file.SaveAs(fullpath);
        //        }
        //    }
        //    return formatoArchivo;
        //}

        //public bool Eliminar(int idTipoInsecto)
        //{
        //    var tipoInsectoServicio = new SubCategoriaServicio();
        //    var tipoInsectoEntidad = tipoInsectoServicio.ObtenerInsecto(idTipoInsecto);
        //    if (tipoInsectoEntidad != null)
        //    {
        //        //if (tipoInsectoEntidad..TipoInsecto.Count == 0)
        //        //{
        //            string nombreArchivo = Path.GetFileName(tipoInsectoEntidad.ImagenUrl);
        //            string ruta = Path.Combine(HostingEnvironment.MapPath("~/assets/apps/archivos/imagenes"), nombreArchivo);
        //            File.Delete(ruta);
        //            tipoInsectoServicio.Eliminar(tipoInsectoEntidad);
        //            return true;
        //        //}
        //    }
        //    return false;
        //}
    }
}