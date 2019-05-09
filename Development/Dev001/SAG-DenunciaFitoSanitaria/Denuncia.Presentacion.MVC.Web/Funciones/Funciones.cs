using Denuncia.Entidad;
using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Web.Hosting;

namespace Denuncia.Presentacion.MVC.Web.Funciones
{
    public class Funciones
    {
        public static List<SelectListItem> ObtenerTipos()
        {
            List<SelectListItem> listaTipo = new List<SelectListItem>();
            var tipoDenuncia = new TipoDenunciaServicio();
            var tipos = tipoDenuncia.ListaTipoDenuncia();

            listaTipo.Add(new SelectListItem()
            {
                Value = "",
                Text = "Seleccione Tipo"
            });
            foreach (var tipo in tipos)
            {
                listaTipo.Add(new SelectListItem
                {
                    Value = tipo.IdTipoDenuncia.ToString(),
                    Text = tipo.Nombre
                });
            }
            return listaTipo;
        }

        public static List<SelectListItem> ObtenerTipos(string userName)
        {
            List<SelectListItem> listaTipo = new List<SelectListItem>();
            var tipoDenuncia = new TipoDenunciaServicio();
            var tipos = tipoDenuncia.ListaTipoDenuncia(userName);

            listaTipo.Add(new SelectListItem()
            {
                Value = "",
                Text = "Seleccione Tipo"
            });
            foreach (var tipo in tipos)
            {
                listaTipo.Add(new SelectListItem
                {
                    Value = tipo.IdTipoDenuncia.ToString(),
                    Text = tipo.Nombre
                });
            }
            return listaTipo;
        }

        //public static List<SelectListItem> ObtenerCategoria()
        //{
        //    List<SelectListItem> listaTipo = new List<SelectListItem>();
        //    var Categoria = new CategoriaServicio();
        //    var Categorias = Categoria.ListaCategoriasPorRol(Autorizacion.IdentityUser.RolName).Where(ent => ent.Estado == true);

        //    listaTipo.Add(new SelectListItem()
        //    {
        //        Value = "",
        //        Text = "Seleccione Categoría"
        //    });
        //    foreach (var tipo in Categorias)
        //    {
        //        listaTipo.Add(new SelectListItem
        //        {
        //            Value = tipo.IdCategoria.ToString(),
        //            Text = tipo.Nombre
        //        });
        //    }
        //    return listaTipo;
        //}


        public static List<SelectListItem> ObtenerCategoria(string userName)
        {
            List<SelectListItem> listaTipo = new List<SelectListItem>();
            var Categoria = new CategoriaServicio();
            var Categorias = Categoria.ListaCategoriasPorRol(userName).Where(ent => ent.Estado == true);

            listaTipo.Add(new SelectListItem()
            {
                Value = "",
                Text = "Seleccione Categoría"
            });
            foreach (var tipo in Categorias)
            {
                listaTipo.Add(new SelectListItem
                {                    
                    Value = tipo.IdCategoria.ToString(),
                    Text = tipo.Nombre
                });
            }
            return listaTipo;
        }
        public static List<SelectListItem> ObtenerRegion(string userName)
        {
            List<SelectListItem> listaRegion = new List<SelectListItem>();
            var serivicoRegion = new RegionServicio();
            var regiones = serivicoRegion.ListaRegionesUser(userName);

            listaRegion.Add(new SelectListItem()
            {
                Value = "",
                Text = "Seleccione Región"
            });
            foreach (var region in regiones)
            {
                listaRegion.Add(new SelectListItem
                {
                    Value = region,
                    Text = region
                });
            }
            return listaRegion;
        }

        public static List<SelectListItem> ObtenerSubcategoriaxCategoria(int idCategoria)
        {
            List<SelectListItem> listaSubCategoria = new List<SelectListItem>();
            var subCategoria = new SubCategoriaServicio();
            var subCategorias = subCategoria.ListaSubCategoria().Where(ent => ent.IdCategoria == idCategoria && ent.Estado == true);

            foreach (var SubCat in subCategorias)
            {
                listaSubCategoria.Add(new SelectListItem
                {
                    Value = SubCat.IdSubCategoria.ToString(),
                    Text = SubCat.Nombre
                });
            }
            return listaSubCategoria;
        }

        public static List<SelectListItem> ObtenerSubcategoria()
        {
            List<SelectListItem> listaSubCategoria = new List<SelectListItem>();
            var subCategoria = new SubCategoriaServicio();
            var subCategorias = subCategoria.ListaSubCategoriaPorRol(Autorizacion.IdentityUser.RolName).Where(ent => ent.Estado == true);
            
            listaSubCategoria.Add(new SelectListItem()
            {
                Value = "",
                Text = "Seleccione SubCategoría"
            });
            foreach (var SubCat in subCategorias)
            {
                listaSubCategoria.Add(new SelectListItem
                {
                    Value = SubCat.IdSubCategoria.ToString(),
                    Text = SubCat.Nombre
                });
            }
            return listaSubCategoria;
        }

        public static List<SelectListItem> ObtenerComuna(string userName)
        {
            List<SelectListItem> listaComuna = new List<SelectListItem>();
            var servicioComuna = new ComunaServicio();
            var comunas = servicioComuna.ListaComunaUser(userName);

            listaComuna.Add(new SelectListItem()
            {
                Value = "",
                Text = "Seleccione Comuna"
            });
            foreach (var comuna in comunas)
            {
                listaComuna.Add(new SelectListItem
                {
                    Value = comuna,
                    Text = comuna
                });
            }
            return listaComuna;
        }

        public static List<SelectListItem> ObtenerEstado()
        {
            List<SelectListItem> listaEstado = new List<SelectListItem>();
            var EstadoDe = new EstadoDenunciaServicio();
            var EstadoDes = EstadoDe.ListaEstado();

            listaEstado.Add(new SelectListItem()
            {
                Value = "",
                Text = "Seleccione Estado"
            });
            foreach (var estado in EstadoDes)
            {
                listaEstado.Add(new SelectListItem
                {
                    Value = estado.IdEstadoDenuncia.ToString(),
                    Text = estado.Nombre
                });
            }
            return listaEstado;
        }

        public static List<SelectListItem> ObtenerEstadoInformeGeneral()
        {
            List<SelectListItem> listaEstado = new List<SelectListItem>();
            var EstadoDe = new EstadoDenunciaServicio();
            var EstadoDes = EstadoDe.ListaEstado().Where(ent => ent.IdEstadoDenuncia != (int)Entidad.Enums.EnumEstadoDenuncia.Pendiente);

            listaEstado.Add(new SelectListItem()
            {
                Value = "",
                Text = "Seleccione Estado"
            });
            foreach (var estado in EstadoDes)
            {
                listaEstado.Add(new SelectListItem
                {
                    Value = estado.IdEstadoDenuncia.ToString(),
                    Text = estado.Nombre
                });
            }
            return listaEstado;
        }

        public static List<SelectListItem> ObtenerEstadoInformeEspacial()
        {
            List<SelectListItem> listaEstado = new List<SelectListItem>();
            var EstadoDe = new EstadoDenunciaServicio();
            var EstadoDes = EstadoDe.ListaEstado().Where(ent => ent.IdEstadoDenuncia == (int)Entidad.Enums.EnumEstadoDenuncia.Positivo || ent.IdEstadoDenuncia == (int)Entidad.Enums.EnumEstadoDenuncia.Negativo);

            listaEstado.Add(new SelectListItem()
            {
                Value = "",
                Text = "Seleccione Estado"
            });
            foreach (var estado in EstadoDes)
            {
                listaEstado.Add(new SelectListItem
                {
                    Value = estado.IdEstadoDenuncia.ToString(),
                    Text = estado.Nombre
                });
            }
            return listaEstado;
        }

        public static void EnviarCorreo(Entidad.Denuncia solicitudDenuncia)
        {
            var fromAddress = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["CasillaCorreo"]);
            var toAddress = new MailAddress(solicitudDenuncia.CorreoContacto);
            string fromPassword = System.Configuration.ConfigurationManager.AppSettings["Password"];
            string denunciaCategoria = solicitudDenuncia.SubCategoria.Categoria.Nombre + " - *" + solicitudDenuncia.SubCategoria.Nombre;
            string denuncia = solicitudDenuncia.SubCategoria.Categoria.TipoDenuncia.Nombre;

            var template = HostingEnvironment.MapPath("~/Templates/CorreoResolucion.html");//System.Configuration.ConfigurationManager.AppSettings["RutaTemplate"];



            string lectura = File.ReadAllText(template);
            string body = lectura.Replace("_Correo_", solicitudDenuncia.CorreoContacto)
                            .Replace("_Denuncia_", denuncia)
                            .Replace("_Categoria_", denunciaCategoria)
                            .Replace("_IdDenuncia_", solicitudDenuncia.IdDenuncia.ToString())
                            .Replace("_FechaAlerta_", solicitudDenuncia.FechaEnvio.ToShortDateString())
                            .Replace("_Descripcion_", solicitudDenuncia.Descripcion)
                            .Replace("_Comentarios_", solicitudDenuncia.Comentario);

            var smtp = new SmtpClient
            {
                Host = System.Configuration.ConfigurationManager.AppSettings["Host"],
                Port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Resolución Denuncia Fitosanitaria",
                Body = body,
                IsBodyHtml = true
            })
            {
                try
                {
                    smtp.Send(message);
                }
                catch { }
            }
        }

    }
}