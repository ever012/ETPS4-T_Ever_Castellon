using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace APILibMonsRomeroDB.Controllers
{
    [ApiController]
    [Route("categoria")]
    public class ControladorCategoria : ControllerBase
    {
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
    }




    
}
