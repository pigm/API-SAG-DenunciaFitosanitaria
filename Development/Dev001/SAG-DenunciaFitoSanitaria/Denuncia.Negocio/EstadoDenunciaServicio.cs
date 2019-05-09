using Denuncia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Denuncia.Datos.Repositorio;

namespace Denuncia.Negocio
{
   public class EstadoDenunciaServicio
    {
        public List<EstadoDenuncia> ListaEstado()
        {
            var repositorio = new EstadoRepositorio();
            return repositorio.ListaEstado();
        }
               
        public EstadoDenuncia ObtenerEstado(int idestadoDenuncia)
        {
            var repositorio = new EstadoRepositorio();
            return repositorio.ObtenerEstado(idestadoDenuncia);
        }


        public void Agregar(EstadoDenuncia EstadoDenunciaEntidad)
        {
            var repositorio = new EstadoRepositorio();
            repositorio.Agregar(EstadoDenunciaEntidad);
            repositorio.RealizarCambios();
        }
        
        public void Modificar(EstadoDenuncia EstadoDenunciaEntidad)
        {
            var repositorio = new EstadoRepositorio();
            repositorio.Modificar(EstadoDenunciaEntidad);
            repositorio.RealizarCambios();
        }
    }
}
