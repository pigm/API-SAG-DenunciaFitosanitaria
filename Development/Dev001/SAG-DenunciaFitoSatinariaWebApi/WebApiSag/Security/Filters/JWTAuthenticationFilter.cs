using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApiSag.Security.Authentication;
using WebApiSag.Security.Identity;
using WebApiSag.Security.Response;


namespace WebApiSag.Security.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class JWTAuthenticationFilter : AuthorizationFilterAttribute
    {    
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                if (!IsUserAuthorized(actionContext))
                {
                    ShowAuthenticationError(actionContext);
                    return;
                }
                base.OnAuthorization(actionContext);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="actionContext"></param>
            /// <returns></returns>
            public bool IsUserAuthorized(HttpActionContext actionContext)
            {
                var authHeader = FetchFromHeader(actionContext);


                if (authHeader != null)
                {
                    var auth = new AuthenticationModule();
                    JwtSecurityToken userPayloadToken = auth.GenerateUserClaimFromJWT(authHeader);

                    if (userPayloadToken != null)
                    {

                        var identity = auth.PopulateUserIdentity(userPayloadToken);
                        string[] roles = { "All" };
                        var genericPrincipal = new GenericPrincipal(identity, roles);
                        Thread.CurrentPrincipal = genericPrincipal;
                        var authenticationIdentity = Thread.CurrentPrincipal.Identity as JWTAuthenticationIdentity;
                        if (authenticationIdentity != null && !String.IsNullOrEmpty(authenticationIdentity.UserName))
                        {
                            authenticationIdentity.UserId = identity.UserId;
                            authenticationIdentity.UserName = identity.UserName;
                        }
                        return true;
                    }

                }
                return false;


            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="actionContext"></param>
            /// <returns></returns>
            private string FetchFromHeader(HttpActionContext actionContext)
            {
                string requestToken = null;

                var authRequest = actionContext.Request.Headers.Authorization;
                if (authRequest != null)
                {
                    requestToken = authRequest.Parameter;
                    if (requestToken == null)
                    {
                        requestToken = authRequest.Scheme;
                    }
                }

                return requestToken;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="filterContext"></param>
            private static void ShowAuthenticationError(HttpActionContext filterContext)
            {
                //var responseDTO = new ResponseDTO() { Code = 401, Message = ConfigurationManager.AppSettings["NoAutorizado"] };
                var response = new Models.Response.DynamicResponse();
                Utils.ResponseFormat.PrepareResponseNoAuthorized(401, ConfigurationManager.AppSettings["NoAutorizado"], response);
                filterContext.Response =
                filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized, response);
            }
        }
}