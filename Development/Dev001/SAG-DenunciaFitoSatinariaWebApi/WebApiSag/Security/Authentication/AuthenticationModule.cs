using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using WebApiSag.Security.Identity;

namespace WebApiSag.Security.Authentication
{
    /// <summary>
    /// Modulo de Autenticacion 
    /// </summary>
    public class AuthenticationModule
    {
        public static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(AuthenticationModule));
        private const string communicationKey = "GQDstc21ewfffffffffffFiwDffVvVBrk";
        SecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));
       
         
        /// <summary>
        /// The Method is used to generate token for user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GenerateTokenForUser(string userName, int userId)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));
            var now = DateTime.UtcNow;
            var signingCredentials = new SigningCredentials(signingKey,
               SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            }, "Custom");

            var dateExpires = DateTime.Now.AddMinutes(int.Parse(ConfigurationManager.AppSettings["MinutosExpiracion"]));
            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                NotBefore = DateTime.Now,
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Audience = "http://www.sag.cl",       //http ://www.lider.cl
                Expires = dateExpires,
                Issuer = "self",
                IssuedAt = DateTime.Now
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;

        }



        /// <summary>
        /// Using the same key used for signing token, user payload is generated back
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public JwtSecurityToken GenerateUserClaimFromJWT(string authToken)
        {

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidAudience = "http://www.sag.cl",  //http ://www.lider.cl
                ValidateIssuer = true,
                ValidIssuer = "self",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;

            try
            {
                tokenHandler.ValidateToken(authToken, tokenValidationParameters, out validatedToken);
            }
            catch (Exception e)
            {
                Logger.Info(e.Message);
                Logger.Info(e.StackTrace);
                return null;
            }

            return validatedToken as JwtSecurityToken;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userPayloadToken"></param>
        /// <returns></returns>
        public JWTAuthenticationIdentity PopulateUserIdentity(JwtSecurityToken userPayloadToken)
        {
            string name = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "unique_name").Value;
            string userId = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "nameid").Value;
            return new JWTAuthenticationIdentity(name) { UserId = Convert.ToInt32(userId), UserName = name };

        }
    }
}