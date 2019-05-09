using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class MantencionUsuarioViewModel
    {
        public UsuarioModel UsuarioModel { get; set; }
        public List<UsuarioModel> ListaUsuarioModel { get; set; }
        public List<SubCategoriaModel> ListaSubCategoria { get; set; }
        public MultiSelectList SubCategoriaMultiSelect
        {
            get { return new MultiSelectList(this.ListaSubCategoria, "IdSubCategoria", "Nombre", "NombreCategoria"); }
        }

        public void ObtenerUsuarios()
        {
            ListaUsuarioModel = new List<UsuarioModel>();
            var listaUsuarios = Membership.GetAllUsers();
            var subcate = new List<SubCategoriaModel>();
            foreach (MembershipUser usuario in listaUsuarios)
            {
                var role = Roles.GetRolesForUser(usuario.UserName);

                ListaUsuarioModel.Add(new UsuarioModel
                {
                    IdUsuario = (Guid)usuario.ProviderUserKey,
                    Email = usuario.Email,
                    Rol = role.SingleOrDefault()
                });
            }
        }

        public void ObtenerUsuario(Guid idUsuario)
        {
            UsuarioModel = new UsuarioModel();
            var usuario = Membership.GetUser(idUsuario);
            var rol = Roles.GetRolesForUser(usuario.UserName);
            var profile = System.Web.Profile.ProfileBase.Create(usuario.UserName);


            UsuarioModel.IdUsuario = (Guid)usuario.ProviderUserKey;
            UsuarioModel.Email = usuario.Email;
            UsuarioModel.Rol = rol.SingleOrDefault();
            UsuarioModel.ModificaDenuncia = (bool)profile.GetPropertyValue("ModificaDenuncia");
        }

        public void Agregar()
        {
            MembershipUser membershipUser = Membership.CreateUser(UsuarioModel.Email, UsuarioModel.Email, UsuarioModel.Email);
            var profile = System.Web.Profile.ProfileBase.Create(UsuarioModel.Email);
            profile.SetPropertyValue("ModificaDenuncia", UsuarioModel.ModificaDenuncia);
            profile.Save();
            Roles.AddUserToRole(membershipUser.UserName, UsuarioModel.Rol);
        }

        public void Modificar()
        {
            MembershipUser membershipUser = Membership.GetUser(UsuarioModel.IdUsuario);
            if (membershipUser != null)
            {
                membershipUser.Email = UsuarioModel.Email;
                Membership.UpdateUser(membershipUser);

                var profile = System.Web.Profile.ProfileBase.Create(UsuarioModel.Email);
                profile.SetPropertyValue("ModificaDenuncia", UsuarioModel.ModificaDenuncia);
                profile.Save();

                string role = Roles.GetRolesForUser(membershipUser.UserName)[0];
                string newRole = UsuarioModel.Rol;
                if (role != newRole)
                {
                    Roles.RemoveUserFromRole(membershipUser.UserName, role);
                    Roles.AddUserToRole(membershipUser.UserName, newRole);
                }
            }
        }

        public void Eliminar(Guid idUsuario)
        {
            var usuario = Membership.GetUser(idUsuario);
            if (usuario != null)
            {
                Membership.DeleteUser(usuario.UserName);
            }
        }
    }
}