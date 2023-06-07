using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;
using System.Text.Json.Nodes;

namespace APILibMonsRomeroDB.Controllers
{
    [ApiController]
    [Route("categoria")]
    public class ControladorCategoria : ControllerBase
    {
        [HttpGet]
        [Route("verCategorias")]
        public dynamic verCategorias()
        {

            DataTable verCategoria = DBDatos.Listar("sp_ver_categorias"); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonverCategoria = JsonConvert.SerializeObject(verCategoria); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json


            return new
            {
                success = true,
                message = "exito",
                result = JsonConvert.DeserializeObject<List<Categoria>>(jsonverCategoria), //aqui convierto el json string en objeto json

            };

        }



        [HttpPost]
        [Route("agregarCategoria")]
        public dynamic agregarCategoria(Categoria agregarCategoria)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@nombCate", agregarCategoria.nombCate),
                new Parametro("@descripcionCate", agregarCategoria.descripcionCate),

            };

            dynamic result = DBDatos.Ejecutar("sp_Agregar_categoria", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };
        }

        [HttpPatch]
        [Route("actualizarCategoria")]
        public dynamic actualizarCategoria(Categoria categoria)
        {

            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@id_categoria", categoria.id_categoria.ToString()),
                new Parametro("@nombCate", categoria.nombCate),
                new Parametro("@descripcionCate", categoria.descripcionCate),
                new Parametro("@ESTADO", categoria.ESTADO),

            };

            dynamic result = DBDatos.Ejecutar("sp_Actualizar_categoria", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };
        }



        [HttpDelete]
        [Route("eliminarCategoria")]
        public dynamic eliminarCategoria(Categoria categoria) //SOLO EL ADMIN PODRA ELIMINAR
        {
            //aqui valido con json web token que sea un admin
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return rToken;

            UsuarioInfoCompleto usuario = rToken.result;
            if (usuario.ROL != 1)
            {
                return new
                {
                    success = false,
                    message = "No tienes permisos para eliminar la categoria",
                    result = ""
                };
            }
            //AQUI TERMINO LA VALIDACION

            //en caso de sí ser admin


            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@id", categoria.id_categoria.ToString()), //como ya es string noo es necesario convertirlo

            };


            dynamic result = DBDatos.Ejecutar("sp_Eliminar_Categoria", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };

        }




    }





}
