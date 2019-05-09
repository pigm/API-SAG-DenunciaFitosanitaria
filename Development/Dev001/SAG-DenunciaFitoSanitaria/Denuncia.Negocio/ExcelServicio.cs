using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Denuncia.Negocio
{
    public class ExcelServicio
    {
        //private byte[] generaExcel(List<Entidad.Denuncia> denuncias)
        //{
        //    var fileName = string.Empty;

        //    fileName = HostingEnvironment.MapPath("~/Template/Descarga.xlsx");


        //    var file = new FileInfo(fileName);
        //    using (var package = new OfficeOpenXml.ExcelPackage(file))
        //    {
        //        var worksheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Denuncias");
        //        var rowCounter = 2;
        //        foreach (var denuncia in denuncias)
        //        {
        //            //if (producto.IdTipoMecanica == (int)Entidad.Enums.EnumMecanicaDestacado.SinMecanica)
        //            //{
        //            //    worksheet.Cells[rowCounter, 1].Value = producto.NumeroProducto.ToString();
        //            //    worksheet.Cells[rowCounter, 2].Value = "SinMecanica";
        //            //    worksheet.Cells[rowCounter, 3].Value = producto.DescripcionCartel;
        //            //    rowCounter++;
        //            //}
        //            //else if (producto.IdTipoMecanica == (int)Entidad.Enums.EnumMecanicaDestacado.AntesyAhora || producto.IdTipoMecanica == (int)Entidad.Enums.EnumMecanicaDestacado.NxPeso)
        //            //{
        //            //var numeroProducto = denuncia.NumeroProducto.ToString();
        //            worksheet.Cells[rowCounter, 1].Value = denuncia.IdDenuncia;
        //            worksheet.Cells[rowCounter, 2].Value = denuncia.estadoDenuncia;
        //            worksheet.Cells[rowCounter, 3].Value = denuncia.tipoDenuncia;
        //            worksheet.Cells[rowCounter, 4].Value = denuncia.SubCategoria.Categoria.Nombre;
        //            worksheet.Cells[rowCounter, 5].Value = denuncia.SubCategoria.Nombre;
        //            worksheet.Cells[rowCounter, 6].Value = denuncia.CorreoContacto;
        //            worksheet.Cells[rowCounter, 7].Value = denuncia.TelefonoContacto;
        //            worksheet.Cells[rowCounter, 8].Value = denuncia.FechaEnvio;
        //            worksheet.Cells[rowCounter, 9].Value = denuncia.Comuna;
        //            worksheet.Cells[rowCounter, 10].Value = denuncia.Region;
        //            worksheet.Cells[rowCounter, 11].Value = denuncia.Descripcion;
        //            rowCounter++;

        //            worksheet.Cells.AutoFitColumns();
        //            package.Workbook.Properties.Title = "Error";

        //            return package.GetAsByteArray();
        //            //if (producto.TieneLinks)
        //            //{
        //            //    foreach (var link in producto.ObtenerLinks())
        //            //    {
        //            //        worksheet.Cells[rowCounter, 1].Value = numeroProducto;

        //            //        switch (IdTipoIdentificador)
        //            //        {
        //            //            case (int)Entidad.Enums.EnumTipoIdentificador.Barra:
        //            //                worksheet.Cells[rowCounter, 2].Value = link.UpcNbr;
        //            //                break;
        //            //            case (int)Entidad.Enums.EnumTipoIdentificador.Item:
        //            //                worksheet.Cells[rowCounter, 2].Value = link.ItemPrimario;
        //            //                break;
        //            //            case (int)Entidad.Enums.EnumTipoIdentificador.ProductNbr:
        //            //                worksheet.Cells[rowCounter, 2].Value = link.ProductNbr;
        //            //                break;
        //            //        }
        //            //        rowCounter++;
        //            //    }
        //            //}

        //            //if (producto.TieneAsociados)
        //            //{
        //            //    foreach (var asociado in producto.ObtenerAsociados())
        //            //    {
        //            //        worksheet.Cells[rowCounter, 1].Value = numeroProducto;
        //            //        switch (IdTipoIdentificador)
        //            //        {
        //            //            case (int)Entidad.Enums.EnumTipoIdentificador.Barra:
        //            //                worksheet.Cells[rowCounter, 2].Value = asociado.UpcNbr;
        //            //                break;
        //            //            case (int)Entidad.Enums.EnumTipoIdentificador.Item:
        //            //                worksheet.Cells[rowCounter, 2].Value = asociado.ItemPrimario;
        //            //                break;
        //            //            case (int)Entidad.Enums.EnumTipoIdentificador.ProductNbr:
        //            //                worksheet.Cells[rowCounter, 2].Value = asociado.ProductNbr;
        //            //                break;
        //            //        }

        //            //        rowCounter++;
        //            //    }
        //            //}
        //            //    }
        //            //}

        //        }
        //    }
        //}
    }
}
