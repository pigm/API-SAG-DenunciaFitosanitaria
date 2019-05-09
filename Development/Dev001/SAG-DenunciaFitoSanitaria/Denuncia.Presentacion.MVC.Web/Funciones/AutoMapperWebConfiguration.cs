using AutoMapper;

namespace Denuncia.Presentacion.MVC.Web.Funciones
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureModelMapping();
        }

        private static void ConfigureModelMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entidad.TipoDenuncia, Models.TipoDenunciaModel>();
                cfg.CreateMap<Models.TipoDenunciaModel, Entidad.TipoDenuncia>();


                cfg.CreateMap<Entidad.Categoria, Models.CategoriaModel>();
                cfg.CreateMap<Models.CategoriaModel, Entidad.Categoria>();


                cfg.CreateMap<Entidad.SubCategoria, Models.SubCategoriaModel>()
                    .ForMember(sol => sol.NombreCategoria, opt => opt.MapFrom(src => src.Categoria.Nombre))
                    .ForMember(sol => sol.SubCategoria_Imagenes, opt => opt.MapFrom(src => src.SubCategoria_Imagenes));

                cfg.CreateMap<Entidad.SubCategoria_Imagenes, Models.SubCategoriaImagenesModel>();

                cfg.CreateMap<Entidad.Denuncia, Models.SolicitudDenunciaModel>()
                    .ForMember(sol => sol.IdDenuncia, opt => opt.MapFrom(src => src.IdDenuncia))
                    //.ForMember(sol => sol.Georeferencia, opt => opt.MapFrom(src => src.Georeferencia))
                    .ForMember(sol => sol.EstadoDenuncia, opt => opt.MapFrom(src => src.estadoDenuncia))
                    .ForMember(sol => sol.TipoDenuncia, opt => opt.MapFrom(src => src.tipoDenuncia))
                    .ForMember(sol => sol.Categoria, opt => opt.MapFrom(src => src.catego))
                    .ForMember(sol => sol.SubCategoria, opt => opt.MapFrom(src => src.subcate))
                    .ForMember(sol => sol.CorreoContacto, opt => opt.MapFrom(src => src.CorreoContacto))
                    .ForMember(sol => sol.TelefonoContacto, opt => opt.MapFrom(src => src.TelefonoContacto))
                    .ForMember(sol => sol.FechaEnvio, opt => opt.MapFrom(src => src.FechaEnvio))
                    .ForMember(sol => sol.IdTipoDenuncia, opt => opt.MapFrom(src => src.SubCategoria.Categoria.IdTipoDenuncia))
                    .ForMember(sol => sol.IdCategoria, opt => opt.MapFrom(src => src.SubCategoria.IdCategoria))
                    .ForMember(sol => sol.IdSubCategoriaNueva, opt => opt.MapFrom(src => src.idSubCategoria));


            });
        }
    }
}