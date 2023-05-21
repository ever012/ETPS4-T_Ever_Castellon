using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Mvc;

namespace APILibMonsRomeroDB.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ControladorCliente : ControllerBase
    {
        [HttpPost]
        [Route("insertarCliente")]
        public dynamic insertarCliente(Cliente cliente)
        {
            //obtengo la fecha y hora actual
            DateTime Ahora = DateTime.Now;
            string fechaFormateada = Ahora.ToString("dd/MM/yyyy HH:mm:ss");


            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@CODIGO", cliente.CODIGO),
                new Parametro("@NOMBRES", cliente.NOMBRES),
                new Parametro("@APELLIDOS", cliente.APELLIDOS),
                new Parametro("@IDENTIFICACION", cliente.IDENTIFICACION), //yyyyMMdd ingresado por el usuario
                new Parametro("@TELEFONO", cliente.TELEFONO),
                new Parametro("@DIRECCION", cliente.DIRECCION),
                new Parametro("@ESTADO", cliente.ESTADO),
                new Parametro("@CreatedBy", cliente.CreatedBy),
                new Parametro("@CreateDate", fechaFormateada),
            };

            dynamic result = DBDatos.Ejecutar("sp_Insertar_Cliente", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };
        }


        [HttpPatch]
        [Route("actualizarCliente")]
        public dynamic actualizarCliente(Cliente cliente)
        {
            //obtengo la fecha y hora actual
            DateTime Ahora = DateTime.Now;
            string fechaFormateada = Ahora.ToString("dd/MM/yyyy HH:mm:ss");


            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@CODIGO", cliente.CODIGO),
                new Parametro("@NOMBRES", cliente.NOMBRES),
                new Parametro("@APELLIDOS", cliente.APELLIDOS),
                new Parametro("@IDENTIFICACION", cliente.IDENTIFICACION), //yyyyMMdd ingresado por el usuario
                new Parametro("@TELEFONO", cliente.TELEFONO),
                new Parametro("@DIRECCION", cliente.DIRECCION),
                new Parametro("@ESTADO", cliente.ESTADO),
                new Parametro("@UpdatedBy", cliente.UpdatedBy),
                new Parametro("@UpdateDate", fechaFormateada),
            };

            dynamic result = DBDatos.Ejecutar("sp_Actualizar_Cliente", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };
        }
    }
}
