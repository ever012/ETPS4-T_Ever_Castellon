using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;

namespace APILibMonsRomeroDB.Controllers
{
    [ApiController]
    [Route("movimiento")]
    public class ControladorMovimiento : ControllerBase
    {
        [HttpGet]
        [Route("verMovimientos")]
        public dynamic verMovimientos()
        {

            DataTable verMovimiento = DBDatos.Listar("sp_listarMovimientosConProductos"); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonverMovimiento = JsonConvert.SerializeObject(verMovimiento); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json


            return new
            {
                success = true,
                message = "exito",
                result = JsonConvert.DeserializeObject<List<ProcedimientoLlenarMovi>>(jsonverMovimiento), //aqui convierto el json string en objeto json

            };

        }




        /*
        [HttpPost]
        [Route("llenarMovi")]
        public dynamic llenarMovi(ProcedimientoLlenarMovi llenarMovi) 
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@id_proc", llenarMovi.id_producto.ToString()), //como ya es string noo es necesario convertirlo
                new Parametro("@tipo", llenarMovi.TipoMovi.ToString()),
                new Parametro("@cant", llenarMovi.cantidad.ToString()),

            };

            dynamic result = DBDatos.Ejecutar("LlenarMovi", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };

        }
        */

        [HttpPost]
        [Route("insertarMovimiento")]
        public dynamic insertarMovimiento(ProcedimientoLlenarMovi llenarMovi)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@id_producto", llenarMovi.id_producto.ToString()), //como ya es string noo es necesario convertirlo
                new Parametro("@TipoMovi", llenarMovi.TipoMovi.ToString()),
                new Parametro("@cantidad", llenarMovi.cantidad.ToString()),
                new Parametro("@total", llenarMovi.total.ToString()),
                new Parametro("@fecha", llenarMovi.fecha.ToString()),

            };

            dynamic result = DBDatos.Ejecutar("sp_Insertar_Movimiento", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };

        }



        [HttpDelete]
        [Route("eliminarMovimiento")]
        public dynamic eliminarMovimiento(ProcedimientoLlenarMovi movimiento) //SOLO EL ADMIN PODRA ELIMINAR
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
                    message = "No tienes permisos para eliminar el movimiento",
                    result = ""
                };
            }
            //AQUI TERMINO LA VALIDACION

            //en caso de sí ser admin


            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@id", movimiento.Id_Movimiento.ToString()), //como ya es string noo es necesario convertirlo

            };


            dynamic result = DBDatos.Ejecutar("sp_Eliminar_Movimiento", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };

        }




    }

}
