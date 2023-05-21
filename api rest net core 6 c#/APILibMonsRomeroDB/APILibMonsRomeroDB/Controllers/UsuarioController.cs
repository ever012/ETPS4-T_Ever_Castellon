using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APILibMonsRomeroDB.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController: ControllerBase
    {
        public IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public dynamic IniciarSesion(Usuario usuario) //cambiar por ([FromBody] Object optData)
        {

            //obtengo los datos de la lista DB() de Usuario
            /*var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            string user = data.usuario.ToString();
            string password = data.password.ToString();
            */
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Usuario", usuario.USUARIO.ToString()), //como ya es string noo es necesario convertirlo
                new Parametro("@Contrasena", usuario.CLAVE.ToString()),

            };

            DataTable sp_ValidarLogin = DBDatos.Listar("sp_ValidarLogin", parametros); //aui no se usan parametros
            string jsonsp_ValidarLogin = JsonConvert.SerializeObject(sp_ValidarLogin); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json

            // Analizar el arreglo JSON
            JArray jsonArray = JArray.Parse(jsonsp_ValidarLogin);

            // Acceder al primer elemento del arreglo (asumiendo que solo hay uno)
            JObject jsonObject = (JObject)jsonArray[0];

            string Resultado = (string)jsonObject["Resultado"];


            if (Resultado == "Usuario no encontrado." || Resultado == "Contraseña incorrecta.")
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = Resultado
                };
            /*else
                return new
                {
                    success = false,
                    message = "Credenciales correctas",
                    result = Resultado
                };
            */

            var id_usuario = (string)jsonObject["id_usuario"];

            var jwt = _configuration.GetSection("Jwt").Get<Jwt>(); //esto es para obtener los datos del appsettings.json

                        //clains = reclamos, aqui guardamos todo lo que va a almacenar el token
                        var clains = new[]
                        {
                            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, jwt.Subject),
                            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()), //fecha de reacion del token
                            new Claim("id", id_usuario), //lo guardo para poder identificar a que usuario pertenece el token
                            new Claim("usuario", usuario.USUARIO),
                            new Claim("contrasena", usuario.CLAVE)

                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            jwt.Issuer,
                            jwt.Audience,
                            clains,
                            expires: DateTime.Now.AddMinutes(60), //esto es opcional y quiere o no que expire el token, en este caso expira en 60 minutos
                            signingCredentials: signIn
                            );

                        return new
                        {
                            success = true,
                            message = "exito",
                            result = new JwtSecurityTokenHandler().WriteToken(token)
                        };
        }
    }


}
