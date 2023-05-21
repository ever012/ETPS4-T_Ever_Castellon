using APILibMonsRomeroDB.Recursos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Numerics;
using System.Security.Claims;

namespace APILibMonsRomeroDB.Models
{
    public class Jwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public static dynamic validarToken(ClaimsIdentity identity)
        {
            try 
            { 
                if(identity.Claims.Count() == 0) //si el token es igual a cero
                {
                    return new
                    {
                        success = false,
                        message = "Verificar si estas enviando un token valido",
                        result = ""
                    };
                }

                //primero voy a saber a que usuario le pertenece el token en base al id
                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;
                var usuario = identity.Claims.FirstOrDefault(x => x.Type == "usuario").Value;
                var contrasena = identity.Claims.FirstOrDefault(x => x.Type == "contrasena").Value;


                List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Usuario", usuario), //como ya es string noo es necesario convertirlo
                new Parametro("@Contrasena", contrasena),

            };

                DataTable sp_ValidarLogin2 = DBDatos.Listar("sp_ValidarLogin", parametros);
                string jsonsp_ValidarLogin2 = JsonConvert.SerializeObject(sp_ValidarLogin2); //son
                                                                                           // Analizar el arreglo JSON
                JArray jsonArray2 = JArray.Parse(jsonsp_ValidarLogin2);
                JObject jsonObject2 = (JObject)jsonArray2[0];
                string USUARIO1 = (string)jsonObject2["USUARIO"];
                string CLAVE1 = (string)jsonObject2["CLAVE"];
                string NOMBRES1 = (string)jsonObject2["NOMBRES"];
                string APELLIDOS1 = (string)jsonObject2["APELLIDOS"];
                string SEXO1 = (string)jsonObject2["SEXO"];
                string ROL1 = (string)jsonObject2["ROL"];
                string CODIGO_SUCURSAL1 = (string)jsonObject2["CODIGO_SUCURSAL"];
                string CreateDate1 = (string)jsonObject2["CreateDate"];
                string ACTIVO1 = (string)jsonObject2["ROL"];
                string id_usuario1 = (string)jsonObject2["id_usuario"];


                //Usuario usuario = Usuario.DB().FirstOrDefault(x => x.id_usuario == id);

                return new
                {
                    success = true,
                    message = "exito!!",
                    result = new UsuarioInfoCompleto
                    {
                        USUARIO = USUARIO1,
                        CLAVE = CLAVE1,
                        NOMBRES = NOMBRES1,
                        APELLIDOS = APELLIDOS1,
                        SEXO = SEXO1,
                        ROL = Convert.ToInt32(ROL1),
                        CODIGO_SUCURSAL = CODIGO_SUCURSAL1,
                        CreateDate = CreateDate1,
                        ACTIVO = ACTIVO1,
                        id_usuario = Convert.ToInt32(id_usuario1),

                    }
                };


            } catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = "Catch: " + ex.ToString(),
                    result = ""
                };
            }
        }



    }
}
