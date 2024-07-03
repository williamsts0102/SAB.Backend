using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SAB.Backend.DataAccess;
using SAB.Backend.Entities.Request;
using SAB.Backend.Entities.Response;
using SAB.Backend.Models.SAB.DB;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SAB.Backend.Providers
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly SABContext _context;
        private readonly IConfiguration _configuration;
        private readonly ISABDO _iSABDO;

        public AuthorizationService(SABContext context, IConfiguration configuration, ISABDO iSABDO)
        {
            _context = context;
            _configuration = configuration;
            _iSABDO = iSABDO;
        }

        private async Task<string> GenerarToken(string idUsuario, string username, string password)
        {
            var key = _configuration.GetValue<string>("JwtSettings:key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            // Obtener el usuario encontrado según el username y password
            var usuario_encontrado = await _iSABDO.GetUsuario(username, password);

            if (usuario_encontrado == null)
            {
                // Manejar el caso donde no se encuentra el usuario
                throw new Exception("Usuario no encontrado o no autorizado.");
            }

            Rol rol = null;

            // Obtener el rol asociado al usuario encontrado
            rol = await _iSABDO.GetRol((int)usuario_encontrado.IdRol);

            // Construir los claims para el token JWT
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUsuario));
            claims.AddClaim(new Claim("username", username));

            if (rol != null)
            {
                claims.AddClaim(new Claim("rol", rol.NombreRol)); // Aquí se cambió a NombreRol
            }

            // Configurar el descriptor del token JWT
            var credencialesToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(3600), // Token expira en 1 hora
                SigningCredentials = credencialesToken
            };

            // Generar el token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            return tokenCreado;
        }

        public async Task<AuthorizationResponse> ReturnToken(AuthorizationRequest authorization)
        {
            var usuario_encontrado = await _context.tblUsuario.FirstOrDefaultAsync(x =>
                x.Username == authorization.Usuario &&
                x.Password == authorization.Clave &&
                x.Activo == true &&
                x.Eliminado == false
            );

            if (usuario_encontrado == null)
            {
                return await Task.FromResult<AuthorizationResponse>(null);
            }

            string tokenCreado = await GenerarToken(usuario_encontrado.IdUsuario.ToString(), usuario_encontrado.Username, usuario_encontrado.Password);

            return new AuthorizationResponse() { Token = tokenCreado, Resultado = true, Message = "Ok" };
        }
    }
}
