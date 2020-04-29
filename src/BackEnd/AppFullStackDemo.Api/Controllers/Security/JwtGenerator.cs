using AppFullStackDemo.Api.Models;
using AppFullStackDemo.Domain.Results.User;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Claim = System.Security.Claims.Claim;

namespace AppFullStackDemo.Api.Controllers.Security
{
    //Note By Fernando - I've externalize this Class to Generate the Token, because both (Login and RefreshToken) will Generate Tokens
    public class JwtGenerator
    {
        private readonly AppSettings _appSettings; //here i will get the Values storage in appsettings.json that will be used to generate my Token

        public JwtGenerator(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        #region Method to Generate the Token

        public string GenerateToken(GetLoggedUserResult user, List<string> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.TokenSecret); //i take the Secret from the Config that will be used to generate the Token

            //I'll create the Tokens, add the Claims into it, and return the Token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emiter, //here i say who is the emiter of the Token (name of my system backend)
                Audience = _appSettings.ValidIn, //here i will say where it's valid (that's specific in Settings.ValidIn - default there is http://localhost)
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.ExpirationInMinutes), //take how many minutes my token is valid
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("IdUser", user.IdUser),
                        new Claim("NameUser", user.NameUser),
                        new Claim("UsernameOrEmail", user.UsernameOrEmail),
                        new Claim("EmailAddress", user.EmailAddress)
                    })
            };

            //now I'm gonna add the claims to the Token
            claims.ForEach(item =>
            {
                tokenDescriptor.Subject.AddClaim(new Claim("roles", item));
            });

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        #endregion Method to Generate the Token
    }
}