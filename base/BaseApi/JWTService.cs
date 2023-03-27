using BaseApi.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaseApi
{
    public class JWTService : IJWTService
    {
        public string Generrate(User user)
        {
            var calims = getclaims(user);
            var secretkey = Encoding.UTF8.GetBytes("Hassankannani123");//longer than 16 char
            SigningCredentials sc = new SigningCredentials(new SymmetricSecurityKey(secretkey), SecurityAlgorithms.HmacSha256Signature);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "hassankanani",
                Audience = "hassankanani",
                IssuedAt = DateTime.Now
            ,
                NotBefore = DateTime.Now.AddMinutes(0),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials =
            sc,
                Subject = new ClaimsIdentity(calims)
            };
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultMapInboundClaims=false;

            var securitytoken = handler.CreateToken(descriptor);
            var token = handler.WriteToken(securitytoken);
            return token;
        }
        private IEnumerable<Claim> getclaims(User user)
        {
            List<Claim> claim = new List<Claim>()
            {
            new Claim(ClaimTypes.Name,user.name),
            new Claim(ClaimTypes.NameIdentifier,user.id.ToString()),
            new Claim("role",user.role.ToString()),

            };

            return null;
        }
    }
}
