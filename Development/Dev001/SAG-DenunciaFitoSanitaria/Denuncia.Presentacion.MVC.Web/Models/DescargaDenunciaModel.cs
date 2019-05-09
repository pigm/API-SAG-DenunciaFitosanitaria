using Denuncia.Entidad.Enums;
using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class DescargaDenunciaModel
    {
        public byte[] DescargaBandejaEntrada(FormCollection form)
        {

            string IdTipoDenuncia = Convert.ToString(form["IdTipoDenuncia"]);
            string IdEstado = ((int)Entidad.Enums.EnumEstadoDenuncia.Pendiente).ToString();
            string FechaSolicitudDesde = Convert.ToString(form["FechaSolicitudDesde"]);
            string FechaSolicitudHasta = Convert.ToString(form["FechaSolicitudHasta"]);
            string IdCategoria = Convert.ToString(form["IdCategoria"]);
            string IdSubCategoria = Convert.ToString(form["IdSubCategoria"]);
            string IdRegion = Convert.ToString(form["IdRegion"]);
            string IdComuna = Convert.ToString(form["IdComuna"]);

            SolicitudDenunciaServicio servicio = new SolicitudDenunciaServicio();
            var listaDenuncia = servicio.Buscar(
               IdEstado,
               IdTipoDenuncia,
               FechaSolicitudDesde,
               FechaSolicitudHasta,
               IdCategoria,
               IdSubCategoria,
               IdRegion,
               IdComuna,
               Autorizacion.IdentityUser.UserName);

            return generaExcelBandejaEntrada(listaDenuncia);
        }

        public byte[] DescargaReporteGeneral(FormCollection form)
        {

            string IdTipoDenuncia = Convert.ToString(form["IdTipoDenuncia"]);
            string IdEstado = Convert.ToString(form["IdEstado"]);
            string FechaSolicitudDesde = Convert.ToString(form["FechaSolicitudDesde"]);
            string FechaSolicitudHasta = Convert.ToString(form["FechaSolicitudHasta"]);
            string IdCategoria = Convert.ToString(form["IdCategoria"]);
            string IdSubCategoria = Convert.ToString(form["IdSubCategoria"]);
            string IdRegion = Convert.ToString(form["IdRegion"]);
            string IdComuna = Convert.ToString(form["IdComuna"]);

            SolicitudDenunciaServicio servicio = new SolicitudDenunciaServicio();
            var listaDenuncia = servicio.Buscar(
               IdEstado,
               IdTipoDenuncia,
               FechaSolicitudDesde,
               FechaSolicitudHasta,
               IdCategoria,
               IdSubCategoria,
               IdRegion,
               IdComuna,
               Autorizacion.IdentityUser.UserName);

            return generaExcelReporteGeneral(listaDenuncia);
        }


        private byte[] generaExcelBandejaEntrada(List<Entidad.Denuncia> listaDenuncia)
        {
            var fileName = string.Empty;
            fileName = HostingEnvironment.MapPath("~/Templates/DescargaBandejaEntrada.xlsx");
            var file = new FileInfo(fileName);
            using (var package = new OfficeOpenXml.ExcelPackage(file))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                worksheet.Name = "Denuncias";
                var rowCounter = 2;
                foreach (var denuncia in listaDenuncia)
                {
                    worksheet.Cells[rowCounter, 1].Value = denuncia.estadoDenuncia;
                    worksheet.Cells[rowCounter, 2].Value = denuncia.tipoDenuncia;
                    worksheet.Cells[rowCounter, 3].Value = denuncia.catego;
                    worksheet.Cells[rowCounter, 4].Value = denuncia.subcate;
                    worksheet.Cells[rowCounter, 5].Value = denuncia.CorreoContacto;
                    worksheet.Cells[rowCounter, 6].Value = denuncia.TelefonoContacto;
                    worksheet.Cells[rowCounter, 7].Value = denuncia.FechaEnvio.ToShortDateString();
                    worksheet.Cells[rowCounter, 8].Value = denuncia.Region;
                    worksheet.Cells[rowCounter, 9].Value = denuncia.Comuna;
                    worksheet.Cells[rowCounter, 10].Value = denuncia.DescripcionCortada;
                    worksheet.Cells[rowCounter, 11].Value = denuncia.Direccion;
                    worksheet.Cells[rowCounter, 12].Value = denuncia.Referencia;
                    worksheet.Cells[rowCounter, 13].Value = denuncia.Comentario;
                    worksheet.Cells[rowCounter, 14].Value = denuncia.latitud;
                    worksheet.Cells[rowCounter, 15].Value = denuncia.longitud;
                    rowCounter++;
                }
                return package.GetAsByteArray();
            }
        }

        private byte[] generaExcelReporteGeneral(List<Entidad.Denuncia> listaDenuncia)
        {
            var fileName = string.Empty;
            fileName = HostingEnvironment.MapPath("~/Templates/DescargaReporteGeneral.xlsx");
            var file = new FileInfo(fileName);
            using (var package = new OfficeOpenXml.ExcelPackage(file))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                worksheet.Name = "Denuncias";
                var rowCounter = 2;
                foreach (var denuncia in listaDenuncia)
                {
                    worksheet.Cells[rowCounter, 1].Value = denuncia.tipoDenuncia;
                    worksheet.Cells[rowCounter, 2].Value = denuncia.catego;
                    worksheet.Cells[rowCounter, 3].Value = denuncia.subcate;
                    worksheet.Cells[rowCounter, 4].Value = denuncia.DescripcionCortada;
                    worksheet.Cells[rowCounter, 5].Value = denuncia.Direccion;
                    worksheet.Cells[rowCounter, 6].Value = denuncia.Referencia;
                    worksheet.Cells[rowCounter, 7].Value = denuncia.Region;
                    worksheet.Cells[rowCounter, 8].Value = denuncia.Comuna;
                    worksheet.Cells[rowCounter, 9].Value = denuncia.estadoDenuncia;
                    worksheet.Cells[rowCounter, 10].Value = denuncia.FechaEnvio.ToShortDateString();
                    worksheet.Cells[rowCounter, 11].Value = denuncia.UserAprobacion;
                    worksheet.Cells[rowCounter, 12].Value = denuncia.Comentario;
                    if (denuncia.FechaAprobacion.HasValue && denuncia.IdEstadoDenuncia != (int)EnumEstadoDenuncia.Pendiente)
                        worksheet.Cells[rowCounter, 13].Value = denuncia.FechaAprobacion.Value.ToShortDateString();
                    else
                        worksheet.Cells[rowCounter, 13].Value = "";
                    worksheet.Cells[rowCounter, 14].Value = denuncia.latitud;
                    worksheet.Cells[rowCounter, 15].Value = denuncia.longitud;
                    rowCounter++;
                }
                return package.GetAsByteArray();
            }
        }
    }
}