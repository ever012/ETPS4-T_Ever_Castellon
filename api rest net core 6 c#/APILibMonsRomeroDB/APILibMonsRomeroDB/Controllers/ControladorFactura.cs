using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Mvc;

namespace APILibMonsRomeroDB.Controllers
{
    [ApiController]
    [Route("factura")]
    public class ControladorFactura : ControllerBase
    {
        [HttpPost]
        [Route("obtenerFacturaEspecifica")]
        public dynamic obtenerFactura(TablaFactura sP_FACTURA)
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("@FACTURA", sP_FACTURA.NUMERO),
                new Parametro("@PREFIJO", sP_FACTURA.PREFIJO),
                new Parametro("@TIPO_FACTURA", sP_FACTURA.TIPO_FACTURA),
            };
            dynamic result = DBDatos.Ejecutar("SP_FACTURA", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };

        }


        [HttpPost]
        [Route("insertarFactura")]
        public dynamic insertarFactura(TablaFactura sP_FACTURA)
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("@@NUMERO", sP_FACTURA.NUMERO),
                new Parametro("@PREFIJO", sP_FACTURA.PREFIJO),
                new Parametro("@TIPO_FACTURA", sP_FACTURA.TIPO_FACTURA),
                new Parametro("@FECHA", sP_FACTURA.FECHA),
                new Parametro("@CLIENTE", sP_FACTURA.CLIENTE),
                new Parametro("@DIRECCION", sP_FACTURA.DIRECCION),
                new Parametro("@SUMAS", sP_FACTURA.SUMAS.ToString()),
                new Parametro("@IVA", sP_FACTURA.IVA.ToString()),
                new Parametro("@CreatedBy", sP_FACTURA.CreatedBy),
                new Parametro("@CreateDate", sP_FACTURA.CreateDate),
            };
            dynamic result = DBDatos.Ejecutar("sp_Insertar_Factura", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };

        }


        [HttpPost]
        [Route("insertarDetalleFactura")]
        public dynamic insertarDetalleFactura(DetalleFactura detalleFactura)
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("@NUMERO", detalleFactura.NUMERO),
                new Parametro("@PREFIJO", detalleFactura.PREFIJO),
                new Parametro("@TIPO_FACTURA", detalleFactura.TIPO_FACTURA),
                new Parametro("@PRODUCTO", detalleFactura.PRODUCTO.ToString()),
                new Parametro("@CANTIDAD", detalleFactura.CANTIDAD.ToString()),
                new Parametro("@PRECIO_UNITARIO", detalleFactura.PRECIO_UNITARIO.ToString()),
                new Parametro("@TOTAL", detalleFactura.TOTAL.ToString()),
                new Parametro("@LINEA", detalleFactura.LINEA.ToString()),
                new Parametro("@CreatedBy", detalleFactura.CreatedBy),
                new Parametro("@CreateDate", detalleFactura.CreateDate),
                new Parametro("@DESCRIPCION", detalleFactura.DESCRIPCION),
                new Parametro("@IMPUESTO_PRODUCTO", detalleFactura.IMPUESTO_PRODUCTO.ToString()),

            };
            dynamic result = DBDatos.Ejecutar("sp_Insertar_Detalle_Factura", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };

        }
    }
}
