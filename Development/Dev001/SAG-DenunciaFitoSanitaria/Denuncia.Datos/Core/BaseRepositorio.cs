using Denuncia.Datos.Core.Specification;
using Denuncia.Datos.Modelo;
using Denuncia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Denuncia.Datos.Core
{
    //public abstract class BaseRepositorio<TEntity> : IRepositorio<TEntity>
    public abstract class BaseRepositorio<TEntity> : IDisposable
         where TEntity : class
    {
        protected dbDenunciaFitoSanitariaEntities _Context;

        //private IConsultableUnidadDeTrabajo _unidadDeTrabajo;
        //public IUnidadDeTrabajo UnidadDeTrabajo { get { return _unidadDeTrabajo; } }


        public BaseRepositorio()
        {
            _Context = DenunciaFitoSanitariaContext.getSingleton();
        }

        public IEnumerable<TEntity> ObtenerTodos()
        {
            return _Context.Set<TEntity>().AsEnumerable<TEntity>();
        }

        public void Agregar(TEntity item)
        {
            _Context.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Added;
        }

        public void Modificar(TEntity item)
        {
            _Context.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Eliminar(TEntity item)
        {
            _Context.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Deleted;
        }

        public virtual IEnumerable<TEntity> ObtenerPorParametros(ISpecification<TEntity> specification)
        {
            return _Context.Set<TEntity>().Where(specification.SatisfiedBy()).AsEnumerable<TEntity>();
        }

        public void RealizarCambios()
        {
            try
            {
                _Context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public void SetCambiosMasivos()
        {
            _Context.Configuration.AutoDetectChangesEnabled = false;
            _Context.Configuration.ValidateOnSaveEnabled = false;
        }

        public void ResetCambiosMasivos()
        {
            _Context.Configuration.AutoDetectChangesEnabled = false;
            _Context.Configuration.ValidateOnSaveEnabled = false;
        }
        public void Dispose()
        {
            _Context.Dispose();
            DenunciaFitoSanitariaContext.setDispose();
        }
    }
}
