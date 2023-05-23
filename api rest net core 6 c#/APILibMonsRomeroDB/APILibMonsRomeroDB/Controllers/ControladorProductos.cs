using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Drawing;
using System.Security.Claims;

namespace APILibMonsRomeroDB.Controllers
{
    [ApiController]
    [Route("productos")]
    public class ControladorProductos : ControllerBase
    {
        [HttpGet]
        [Route("verProductos")]
        public dynamic verProducto()
        {
            
            string sql = @"SELECT * FROM producto";

            DataTable verProducto = DBDatos.ListarConsulta(sql); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonverProducto = JsonConvert.SerializeObject(verProducto); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json


            return new
            {
                success = true,
                message = "exito",
                result = JsonConvert.DeserializeObject<List<Producto>>(jsonverProducto), //aqui convierto el json string en objeto json
                
            };

        }




        [HttpPost]
        [Route("agregarProducto")]
        public dynamic agregarProducto(Producto producto)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@nombre_producto", producto.nombre_producto), //como ya es string noo es necesario convertirlo
                new Parametro("@id_categoria", producto.id_categoria.ToString()),
                new Parametro("@precio", producto.precio.ToString()),
                new Parametro("@descripcion", producto.descripcion),
                new Parametro("@cantidad", producto.cantidad.ToString()),
                new Parametro("@precio_venta", producto.precio_venta.ToString())

            };

            dynamic result = DBDatos.Ejecutar("Agregar_Producto", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };

        }


        //UTILIZANDO SQL DIRECTAMENTE Y NO UN PROCEDIMIENTO ALMACENADO   ***
        [HttpDelete]
        [Route("eliminarProducto")]
        public dynamic eliminarProducto(Producto producto) //SOLO EL ADMIN PODRA ELIMINAR
        {
            //aqui valido con json web token que sea un admin
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return rToken;

            UsuarioInfoCompleto usuario = rToken.result;
            if ( usuario.ROL != 1)
            {
                return new
                {
                    success = false,
                    message = "No tienes permisos para eliminar el producto",
                    result = ""
                };
            }
            //AQUI TERMINO LA VALIDACION

            //en caso de sí ser admin
            

            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@id", producto.id_producto.ToString()), //como ya es string noo es necesario convertirlo

            };

            string sql = @"DELETE FROM existencia WHERE id_producto = @id;
                   DELETE FROM producto WHERE id_producto = @id;
                   DELETE FROM Movimiento WHERE id_producto = @id;";

            dynamic result = DBDatos.EjecutarConsulta(sql, parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };

        }


        [HttpPatch]
        [Route("actualizarProducto")]
        public dynamic actualizarProducto(Producto producto)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@id_producto", producto.id_producto.ToString()),
                new Parametro("@nombre_producto", producto.nombre_producto), //como ya es string noo es necesario convertirlo
                new Parametro("@id_categoria", producto.id_categoria.ToString()),
                new Parametro("@precio", producto.precio.ToString()),
                new Parametro("@descripcion", producto.descripcion),
                new Parametro("@cantidad", producto.cantidad.ToString()),
                new Parametro("@ESTADO", producto.ESTADO.ToString()),
                new Parametro("@precio_venta", producto.precio_venta.ToString())

            };

            dynamic result = DBDatos.Ejecutar("sp_Actualizar_Producto", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };

        }



    }
}
