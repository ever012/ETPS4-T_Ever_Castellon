using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Mvc;

namespace APILibMonsRomeroDB.Controllers
{
    [ApiController]
    [Route("movimiento")]
    public class ControladorMovimiento : ControllerBase
    {
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



    }
    
}
