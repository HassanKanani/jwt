using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BaseApi
{
    public static class JwtConfiguration
    {
        public static void JwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            }).AddJwtBearer(Option => {
                var secretkey = Encoding.UTF8.GetBytes("Hassankannani123");

                var validationparameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromDays(1)
                    ,
                    RequireSignedTokens = true,
                    ValidateIssuerSigningKey = true
                    ,
                    IssuerSigningKey = new SymmetricSecurityKey(secretkey),
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidAudience = "hassankanani",
                    ValidateIssuer = true,
                    ValidIssuer = "hassankanani",
                    //TokenDecryptionKey=new SymmetricSecurityKey(secretkey)

                };
                Option.RequireHttpsMetadata = false;
                Option.SaveToken = true;
                Option.TokenValidationParameters = validationparameters;
                
                
                
                });
        }
    }
}
