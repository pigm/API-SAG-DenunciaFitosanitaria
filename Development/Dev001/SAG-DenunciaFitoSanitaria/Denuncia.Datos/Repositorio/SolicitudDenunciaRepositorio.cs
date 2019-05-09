using Denuncia.Datos.Core;
using Denuncia.Datos.Core.Specification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Denuncia.Datos.Repositorio
{
    public class SolicitudDenunciaRepositorio : BaseRepositorio<Entidad.Denuncia>
    {

        public List<Entidad.Denuncia> ListaDenuncias(string userName)
        {
            List<Entidad.Denuncia> result = new List<Entidad.Denuncia>();
            var conn = this._Context.Database.Connection;
            ConnectionState initialState = conn.State;

            if (initialState != ConnectionState.Open)
            {
                conn.Open();
            }

            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "sp_ListadoDenuncias";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@UserName", userName));

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var lde = new Entidad.Denuncia();
                        lde.IdDenuncia = (int)rd["idDenuncia"];
                        lde.estadoDenuncia = string.IsNullOrEmpty(rd["estadoDenuncia"].ToString()) ? null : rd["estadoDenuncia"].ToString();
                        lde.tipoDenuncia = string.IsNullOrEmpty(rd["tipoDenuncia"].ToString()) ? null : rd["tipoDenuncia"].ToString();
                        lde.catego = string.IsNullOrEmpty(rd["Categoria"].ToString()) ? null : rd["Categoria"].ToString();
                        lde.subcate = string.IsNullOrEmpty(rd["SubCategoria"].ToString()) ? null : rd["SubCategoria"].ToString();
                        lde.CorreoContacto = string.IsNullOrEmpty(rd["Email"].ToString()) ? null : rd["Email"].ToString();
                        lde.TelefonoContacto = string.IsNullOrEmpty(rd["Telefono"].ToString()) ? null : rd["Telefono"].ToString();
                        lde.FechaEnvio = (DateTime)rd["Fecha"];
                        lde.Comuna = string.IsNullOrEmpty(rd["Comuna"].ToString()) ? null : rd["Comuna"].ToString();
                        lde.Region = string.IsNullOrEmpty(rd["Region"].ToString()) ? null : rd["Region"].ToString();
                        lde.Descripcion = string.IsNullOrEmpty(rd["Descripcion"].ToString()) ? null : rd["Descripcion"].ToString();
                        lde.IdEstadoDenuncia = (int)rd["IdEstadoDenuncia"];
                        lde.latitud = string.IsNullOrEmpty(rd["latitud"].ToString()) ? null : rd["latitud"].ToString();
                        lde.longitud = string.IsNullOrEmpty(rd["latitud"].ToString()) ? null : rd["latitud"].ToString();
                        lde.DenunciaRapida = (rd["DenunciaRapida"] == null || rd["DenunciaRapida"].ToString() == "0") ? false : true;
                        lde.MensajeVoz = string.IsNullOrEmpty(rd["MensajeVoz"].ToString()) ? null : rd["MensajeVoz"].ToString();
                        lde.ImagenUrl = string.IsNullOrEmpty(rd["ImagenUrl"].ToString()) ? null : rd["ImagenUrl"].ToString();
                        lde.Georeferencia = string.IsNullOrEmpty(rd["Georeferencia"].ToString()) ? null : rd["Georeferencia"].ToString();
                        lde.DenunciaRapida = string.IsNullOrEmpty(rd["DenunciaRapida"].ToString()) ? false : true;
                        result.Add(lde);
                    }
                }
            }
            return result;
        }


        public IEnumerable<Entidad.Denuncia> Buscar(string estadoDenuncia, string TipoDenuncia, string FechaSolicitudDesde, string FechaSolicitudHasta, string IdCategoria, string IdSubCategoria, string Region, string Comuna, string userName)
        {
            List<Entidad.Denuncia> result = new List<Entidad.Denuncia>();
            var conn = this._Context.Database.Connection;
            ConnectionState initialState = conn.State;
            if (initialState != ConnectionState.Open)
            {
                conn.Open();
            }
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "sp_ListadoDenuncias";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@EstadoDenuncia", estadoDenuncia));
                cmd.Parameters.Add(new SqlParameter("@TipoDenuncia", TipoDenuncia));
                cmd.Parameters.Add(new SqlParameter("@FechaDesde", FechaSolicitudDesde));
                cmd.Parameters.Add(new SqlParameter("@FechaHasta", FechaSolicitudHasta));
                cmd.Parameters.Add(new SqlParameter("@Categoria", IdCategoria));
                cmd.Parameters.Add(new SqlParameter("@SubCategoria", IdSubCategoria));
                cmd.Parameters.Add(new SqlParameter("@Region", Region));
                cmd.Parameters.Add(new SqlParameter("@Comuna", Comuna));
                cmd.Parameters.Add(new SqlParameter("@UserName", userName));


                using (var sqlDataReader = cmd.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            var Denuncia = new Entidad.Denuncia();
                            Denuncia.IdDenuncia = (int)sqlDataReader["idDenuncia"];
                            Denuncia.estadoDenuncia = string.IsNullOrEmpty(sqlDataReader["estadoDenuncia"].ToString()) ? null : sqlDataReader["estadoDenuncia"].ToString();
                            Denuncia.tipoDenuncia = string.IsNullOrEmpty(sqlDataReader["tipoDenuncia"].ToString()) ? null : sqlDataReader["tipoDenuncia"].ToString();
                            Denuncia.catego = string.IsNullOrEmpty(sqlDataReader["Categoria"].ToString()) ? null : sqlDataReader["Categoria"].ToString();
                            Denuncia.subcate = string.IsNullOrEmpty(sqlDataReader["SubCategoria"].ToString()) ? null : sqlDataReader["SubCategoria"].ToString();
                            Denuncia.CorreoContacto = string.IsNullOrEmpty(sqlDataReader["Email"].ToString()) ? null : sqlDataReader["Email"].ToString();
                            Denuncia.TelefonoContacto = string.IsNullOrEmpty(sqlDataReader["Telefono"].ToString()) ? null : sqlDataReader["Telefono"].ToString();
                            Denuncia.FechaEnvio = (DateTime)sqlDataReader["Fecha"];
                            Denuncia.Comuna = string.IsNullOrEmpty(sqlDataReader["Comuna"].ToString()) ? null : sqlDataReader["Comuna"].ToString();
                            Denuncia.Region = string.IsNullOrEmpty(sqlDataReader["Region"].ToString()) ? null : sqlDataReader["Region"].ToString();
                            Denuncia.Descripcion = string.IsNullOrEmpty(sqlDataReader["Descripcion"].ToString()) ? null : sqlDataReader["Descripcion"].ToString();
                            Denuncia.IdEstadoDenuncia = (int)sqlDataReader["IdEstadoDenuncia"];
                            Denuncia.latitud = string.IsNullOrEmpty(sqlDataReader["latitud"].ToString()) ? string.Empty : !IsNumeric(sqlDataReader["latitud"].ToString()) ? string.Empty : sqlDataReader["latitud"].ToString();
                            Denuncia.longitud = string.IsNullOrEmpty(sqlDataReader["longitud"].ToString()) ? string.Empty : !IsNumeric(sqlDataReader["longitud"].ToString()) ? string.Empty : sqlDataReader["longitud"].ToString();
                            if (sqlDataReader["Comentario"] != null)
                                Denuncia.Comentario = sqlDataReader["Comentario"].ToString();
                            if (sqlDataReader["UserAprobacion"] != null)
                                Denuncia.UserAprobacion = sqlDataReader["UserAprobacion"].ToString();
                            if (sqlDataReader["FechaAprobacion"] != null)
                                Denuncia.FechaAprobacion = (DateTime)sqlDataReader["FechaAprobacion"];
                            result.Add(Denuncia);
                            Denuncia.Georeferencia = string.IsNullOrEmpty(sqlDataReader["Georeferencia"].ToString()) ? null : sqlDataReader["Georeferencia"].ToString();
                            Denuncia.DenunciaRapida = (bool)sqlDataReader["DenunciaRapida"];
                        }
                    }
                }
            }
            return result;
        }


        public Entidad.Denuncia ObtenerDenuncia(int idDenuncia)
        {
            return this._Context.Denuncia.Include("SubCategoria").Include("SubCategoria.Categoria").SingleOrDefault(den => den.IdDenuncia == idDenuncia);
        }

        public string[] ListaRegiones()
        {
            return this._Context.Denuncia.Where(den => den.Region != null).Select(den => den.Region).Distinct().ToArray();
        }

        public string[] ListaComunas()
        {
            return this._Context.Denuncia.Where(den => den.Comuna != null).Select(den => den.Comuna).Distinct().ToArray();
        }
        public bool IsNumeric(string input)
        {
            Double test;
            return Double.TryParse(input, out test);
        }

        public string[] ListaRegionesUser(string userName)
        {
            List<string> arreglo = new List<string>();
            var conn = this._Context.Database.Connection;
            ConnectionState initialState = conn.State;

            if (initialState != ConnectionState.Open)
            {
                conn.Open();
            }

            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ObtieneRegionComunaPorUsuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@UserName", userName));

                using (var rd = cmd.ExecuteReader())
                {

                    while (rd.Read())
                    {
                        string region = string.IsNullOrEmpty(rd["Region"].ToString()) ? null : rd["Region"].ToString();
                        arreglo.Add(region);
                    }
                }
            }
            return arreglo.Distinct().ToArray();
        }

        public string[] ListaComunaUser(string userName)
        {
            List<string> arreglo = new List<string>();
            var conn = this._Context.Database.Connection;
            ConnectionState initialState = conn.State;

            if (initialState != ConnectionState.Open)
            {
                conn.Open();
            }

            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ObtieneRegionComunaPorUsuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@UserName", userName));

                using (var rd = cmd.ExecuteReader())
                {

                    while (rd.Read())
                    {
                        string region = string.IsNullOrEmpty(rd["Comuna"].ToString()) ? null : rd["Comuna"].ToString();
                        arreglo.Add(region);
                    }
                }
            }
            return arreglo.Distinct().ToArray();
        }



        public List<Entidad.Categoria> ListaCategoriasUser(string userName)
        {
            List<Entidad.Categoria> arreglo = new List<Entidad.Categoria>();
            var conn = this._Context.Database.Connection;
            ConnectionState initialState = conn.State;

            if (initialState != ConnectionState.Open)
            {
                conn.Open();
            }

            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ObtieneCategoriaPorUsuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@UserName", userName));

                using (var rd = cmd.ExecuteReader())
                {

                    while (rd.Read())
                    {
                        Entidad.Categoria categori = new Entidad.Categoria();                       
                        categori.IdCategoria = Convert.ToInt32(rd["IdCategoria"]);
                        categori.Nombre = string.IsNullOrEmpty(rd["Nombre"].ToString()) ? null : rd["Nombre"].ToString();
                        categori.Estado = Convert.ToBoolean( rd["Estado"]);
                        arreglo.Add(categori);
                       
                    }
                }
            }

            return arreglo;
        }


        public List<Entidad.TipoDenuncia> ListaTiposUser(string userName)
        {
            List<Entidad.TipoDenuncia> arreglo = new List<Entidad.TipoDenuncia>();
            var conn = this._Context.Database.Connection;
            ConnectionState initialState = conn.State;

            if (initialState != ConnectionState.Open)
            {
                conn.Open();
            }

            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ObtieneTiposPorUsuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@UserName", userName));

                using (var rd = cmd.ExecuteReader())
                {

                    while (rd.Read())
                    {
                        Entidad.TipoDenuncia categori = new Entidad.TipoDenuncia();
                        categori.IdTipoDenuncia = Convert.ToInt32(rd["IdTipoDenuncia"]);
                        categori.Nombre = string.IsNullOrEmpty(rd["Nombre"].ToString()) ? null : rd["Nombre"].ToString();
                        arreglo.Add(categori);

                    }
                }
            }

            return arreglo;
        }


        public List<Entidad.SubCategoria> ListaSubCategoriasUser(string userName)
        {
            List<Entidad.SubCategoria> arreglo = new List<Entidad.SubCategoria>();
            var conn = this._Context.Database.Connection;
            ConnectionState initialState = conn.State;

            if (initialState != ConnectionState.Open)
            {
                conn.Open();
            }

            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "ObtieneSubcategoriaPorUsuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@UserName", userName));

                using (var rd = cmd.ExecuteReader())
                {

                    while (rd.Read())
                    {
                        Entidad.SubCategoria categori = new Entidad.SubCategoria();
                        categori.IdSubCategoria = Convert.ToInt32(rd["IdSubCategoria"]);
                        categori.Nombre = string.IsNullOrEmpty(rd["Nombre"].ToString()) ? null : rd["Nombre"].ToString();
                        categori.Estado = Convert.ToBoolean(rd["Estado"]);
                        arreglo.Add(categori);

                    }
                }
            }

            return arreglo;
        }


        //public string[] ListaCategoriasUser(string userName)
        //{
        //    List<string> arreglo = new List<string>();
        //    var conn = this._Context.Database.Connection;
        //    ConnectionState initialState = conn.State;

        //    if (initialState != ConnectionState.Open)
        //    {
        //        conn.Open();
        //    }

        //    using (DbCommand cmd = conn.CreateCommand())
        //    {
        //        cmd.CommandText = "ObtieneCategoriaPorUsuario";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = 0;
        //        cmd.Parameters.Add(new SqlParameter("@UserName", userName));

        //        using (var rd = cmd.ExecuteReader())
        //        {

        //            while (rd.Read())
        //            {
        //                string region = string.IsNullOrEmpty(rd["Comuna"].ToString()) ? null : rd["Comuna"].ToString();
        //                arreglo.Add(region);
        //            }
        //        }
        //    }
        //    return arreglo.Distinct().ToArray();
        //}


    }
}
