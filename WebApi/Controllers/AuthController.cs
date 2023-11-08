using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _context.TblUsuarios.ToListAsync());
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string correo, string password)
        {
            var user = await _context.TblUsuarios
                .Where(x => x.Email.Equals(correo)).FirstOrDefaultAsync();
            if (user == null) return BadRequest("Usuario NO Encontrado!");

            if(VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                var Token = GenerateToken(user);
                return Ok($"Token: {Token}");
            }
            return BadRequest("Credenciales Incorrectas");
        }


        [HttpPost]
        [Route("Registro")]
        public async Task<IActionResult> Registro(UsuarioDTO usuarioDTO)
        {
            //TODO: Validar Username y Correo (que no esten en uso)
            if(usuarioDTO != null)
            {
                if (usuarioDTO.Password.Equals(usuarioDTO.PasswordConfirm))
                {
                    var NewUser = new Usuario();
                    NewUser.Email = usuarioDTO.Email;
                    NewUser.Username = usuarioDTO.Username;
                    NewUser.Name = usuarioDTO.Name;
                    //Hasheamos la Password del DTO
                    CreatePasswordHash(usuarioDTO.Password, out byte[] hash, out byte[] salt);
                    NewUser.PasswordHash = hash;
                    NewUser.PasswordSalt = salt;
                    _context.Add(NewUser);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest("Las Contraseñas NO Coinciden!");
                }
            }
            return BadRequest();
        }

        private void CreatePasswordHash(string password, 
            out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text
                    .Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password,
            byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var decodedPassword = hmac.ComputeHash(System.Text
                    .Encoding.UTF8.GetBytes(password));
                return decodedPassword.SequenceEqual(passwordHash);
            }
        }

        //Metodo tiene que ser Private, sino, ocaciona Grave Error!!!
        private string GenerateToken(Usuario user)
        {
            //Informacion que va en el Token
            List<Claim> Datos = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Free")
            };

            var Key = new SymmetricSecurityKey(System.Text
                .Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:TokenKey").Value));

            var Credencial = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature);

            var Token = new JwtSecurityToken(
                claims: Datos,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials : Credencial
            );

            var JWTToken = new JwtSecurityTokenHandler().WriteToken(Token);

            return JWTToken;
        }



    }
}
