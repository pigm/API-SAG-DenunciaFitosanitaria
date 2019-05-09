using AutoMapper;
using Denuncia.Entidad;
using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class MantencionSubCategoriaViewModel
    {
        public SubCategoriaModel SubCategoriaModel { get; set; }
        public List<SubCategoriaModel> ListaSubCategoria { get; set; }

        public void ListarSubCategoria()
        {
            ListaSubCategoria = new List<SubCategoriaModel>();
            var subCategoriaServicio = new SubCategoriaServicio();
            var listadoSubCategoria = subCategoriaServicio.ListaSubCategoria();
            ListaSubCategoria = Mapper.Map<List<SubCategoriaModel>>(listadoSubCategoria);
        }

        public void ListarSubCategoriaMantenedor()
        {
            ListaSubCategoria = new List<SubCategoriaModel>();
            var subCategoriaServicio = new SubCategoriaServicio();
            var listadoSubCategoria = subCategoriaServicio.ListaSubCategoriaMantenedor();
            ListaSubCategoria = Mapper.Map<List<SubCategoriaModel>>(listadoSubCategoria);
        }

        public void Obtener(int idSubCategoria)
        {
            SubCategoriaModel = new SubCategoriaModel();
            var subCategoriaServicio = new SubCategoriaServicio();
            var subCategoriaEntidad = subCategoriaServicio.Obtener(idSubCategoria);
            SubCategoriaModel = Mapper.Map<SubCategoriaModel>(subCategoriaEntidad);
        }

        public void Agregar(SubCategoriaModel subCategoriaModel)
        {
            var subCategoriaServicio = new SubCategoriaServicio();
            var subCategoriaEntidad = new SubCategoria();
            subCategoriaEntidad.IdCategoria = subCategoriaModel.IdCategoria;
            subCategoriaEntidad.Nombre = subCategoriaModel.Nombre;
            subCategoriaEntidad.Descripcion = subCategoriaModel.Descripcion;
            subCategoriaEntidad.Estado = subCategoriaModel.Estado;
            subCategoriaEntidad.Anonimo = subCategoriaModel.Anonimo;

            var archivo = GuardarImagen(subCategoriaModel.FotoImagen, true);
            subCategoriaEntidad.ImagenUrl = string.Format("~/assets/apps/img/{0}", archivo);


            //subCategoriaEntidad.SubCategoria_Imagenes = subCategoriaImagenes;
            var subc = subCategoriaServicio.Agregar(subCategoriaEntidad);
            var subCategoriaImagenes = AgregarImagenes(subCategoriaModel.SubCategoria_Imagenes, subCategoriaModel.IdCategoria, subc);
        }

        public void Modificar(SubCategoriaModel subCategoriaModel)
        {
            var subCategoriaServicio = new SubCategoriaServicio();
            var subCategoriaEntidad = new SubCategoria();

            subCategoriaEntidad.IdSubCategoria = subCategoriaModel.IdSubCategoria;
            subCategoriaEntidad.IdCategoria = subCategoriaModel.IdCategoria;
            subCategoriaEntidad.Nombre = subCategoriaModel.Nombre;
            subCategoriaEntidad.Descripcion = subCategoriaModel.Descripcion;
            subCategoriaEntidad.Estado = subCategoriaModel.Estado;
            subCategoriaEntidad.Anonimo = subCategoriaModel.Anonimo;

            var archivo = GuardarImagen(subCategoriaModel.FotoImagen, false, subCategoriaModel.ImagenUrl);
            subCategoriaEntidad.ImagenUrl = !string.IsNullOrEmpty(archivo) ? string.Format("~/assets/apps/img/{0}", archivo) : subCategoriaModel.ImagenUrl;

            ModificarImagenes(subCategoriaModel.SubCategoria_Imagenes, subCategoriaModel.IdSubCategoria);

            subCategoriaServicio.Modificar(subCategoriaEntidad);
        }

        private SubCategoria_Imagenes AgregarImagenes(SubCategoriaImagenesModel subCategoriaImagenes, int idSubCategoria, SubCategoria subc)
        {
            var subCategoriaImagenesEntidad = new SubCategoria_Imagenes();

            var archivo = GuardarImagen(subCategoriaImagenes.FotoImagen1, true);

            subCategoriaImagenesEntidad.Descripcion1 = subCategoriaImagenes.Descripcion1;
            subCategoriaImagenesEntidad.Imagen1 = !string.IsNullOrEmpty(archivo) ? string.Format("~/assets/apps/img/{0}", archivo) : subCategoriaImagenes.Imagen1;

            var archivo2 = GuardarImagen(subCategoriaImagenes.FotoImagen2, true);
            subCategoriaImagenesEntidad.Descripcion2 = subCategoriaImagenes.Descripcion2;
            subCategoriaImagenesEntidad.Imagen2 = !string.IsNullOrEmpty(archivo2) ? string.Format("~/assets/apps/img/{0}", archivo2) : subCategoriaImagenes.Imagen2;


            var archivo3 = GuardarImagen(subCategoriaImagenes.FotoImagen3, true);
            subCategoriaImagenesEntidad.Descripcion3 = subCategoriaImagenes.Descripcion3;
            subCategoriaImagenesEntidad.Imagen3 = !string.IsNullOrEmpty(archivo3) ? string.Format("~/assets/apps/img/{0}", archivo3) : subCategoriaImagenes.Imagen3;


            var archivo4 = GuardarImagen(subCategoriaImagenes.FotoImagen4, true);
            subCategoriaImagenesEntidad.Descripcion4 = subCategoriaImagenes.Descripcion4;
            subCategoriaImagenesEntidad.Imagen4 = !string.IsNullOrEmpty(archivo4) ? string.Format("~/assets/apps/img/{0}", archivo4) : subCategoriaImagenes.Imagen4;

            subCategoriaImagenesEntidad.SubCategoria = subc;
            subCategoriaImagenesEntidad.IdSubCategoria = subc.IdSubCategoria;

            var subCategoriaImagenesServicio = new SubCategoriaImagenesServicio();
            subCategoriaImagenesServicio.Agregar(subCategoriaImagenesEntidad);

            return subCategoriaImagenesEntidad;
        }

        private void ModificarImagenes(SubCategoriaImagenesModel subCategoriaImagenes, int idSubCategoria)
        {
            var subCategoriaImagenesServicio = new SubCategoriaImagenesServicio();
            var subCategoriaImagenesEntidad = subCategoriaImagenesServicio.Obtener(idSubCategoria);
            var modifica = true;
            if (subCategoriaImagenesEntidad == null)
            {
                modifica = false;
                subCategoriaImagenesEntidad = new SubCategoria_Imagenes();
            }

            var archivo = GuardarImagen(subCategoriaImagenes.FotoImagen1, true, subCategoriaImagenes.Imagen1);
            subCategoriaImagenesEntidad.Descripcion1 = subCategoriaImagenes.Descripcion1;
            subCategoriaImagenesEntidad.Imagen1 = !string.IsNullOrEmpty(archivo) ? string.Format("~/assets/apps/img/{0}", archivo) : subCategoriaImagenes.Imagen1;

            var archivo2 = GuardarImagen(subCategoriaImagenes.FotoImagen2, true, subCategoriaImagenes.Imagen2);
            subCategoriaImagenesEntidad.Descripcion2 = subCategoriaImagenes.Descripcion2;
            subCategoriaImagenesEntidad.Imagen2 = !string.IsNullOrEmpty(archivo2) ? string.Format("~/assets/apps/img/{0}", archivo2) : subCategoriaImagenes.Imagen2;


            var archivo3 = GuardarImagen(subCategoriaImagenes.FotoImagen3, true, subCategoriaImagenes.Imagen3);
            subCategoriaImagenesEntidad.Descripcion3 = subCategoriaImagenes.Descripcion3;
            subCategoriaImagenesEntidad.Imagen3 = !string.IsNullOrEmpty(archivo3) ? string.Format("~/assets/apps/img/{0}", archivo3) : subCategoriaImagenes.Imagen3;

            var archivo4 = GuardarImagen(subCategoriaImagenes.FotoImagen4, true, subCategoriaImagenes.Imagen4);
            subCategoriaImagenesEntidad.Descripcion4 = subCategoriaImagenes.Descripcion4;
            subCategoriaImagenesEntidad.Imagen4 = !string.IsNullOrEmpty(archivo4) ? string.Format("~/assets/apps/img/{0}", archivo4) : subCategoriaImagenes.Imagen4;

            if (modifica)
                subCategoriaImagenesServicio.Modificar(subCategoriaImagenesEntidad);
            else
                subCategoriaImagenesServicio.Agregar(subCategoriaImagenesEntidad);
        }

        private string GuardarImagen(HttpPostedFileBase file, bool esNuevo, string url = null)
        {
            string formatoArchivo = null;

            if (file != null)
            {
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
                    var nombreArchivoAnterior = Path.GetFileName(url);
                    string ruta = Path.Combine(HostingEnvironment.MapPath("~/assets/apps/img"), nombreArchivoAnterior);
                    if (!string.IsNullOrEmpty(nombreArchivoAnterior))
                    {
                        File.Delete(ruta);
                    }
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