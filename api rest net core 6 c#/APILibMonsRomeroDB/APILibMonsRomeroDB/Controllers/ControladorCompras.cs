using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;
using System.Security.Claims;

namespace APILibMonsRomeroDB.Controllers
{
    //al heredar de ControllerBase decimos que la clase se convierte en un controlador
   [ApiController]
    [Route("compras")]
    public class ControladorCompras : ControllerBase
    {

        [HttpGet]
        [Route("verCompra")]
        public dynamic verCompra()
        {
            //esta solo retornará una tabla

            DataTable VerCompra = DBDatos.Listar("VerCompra"); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonVerCompra = JsonConvert.SerializeObject(VerCompra); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json

            return new
            {
                success = true,
                message = "exito",
                result = JsonConvert.DeserializeObject<List<sp_verCompra>>(jsonVerCompra), //aqui convierto el json string en objeto json
                
            };
        }

        [HttpGet]
        [Route("verCompraDia")]
        public dynamic verCompraDia()
        {
            //esta solo retornará una tabla

            DataTable VerCompraDia = DBDatos.Listar("VerCompraDia"); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonVerCompraDia = JsonConvert.SerializeObject(VerCompraDia); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json

            return new
            {
                success = true,
                message = "exito",
                result = JsonConvert.DeserializeObject<List<sp_verCompra>>(jsonVerCompraDia), //aqui convierto el json string en objeto json
                
            };
        }


        [HttpPost]
        [Route("agregarCompra")]
        public dynamic agregarCompra(compra compra)
        {
            //obtengo la fecha y hora actual
            DateTime Ahora = DateTime.Now;
            string fechaFormateada = Ahora.ToString("dd/MM/yyyy HH:mm:ss");


            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@NUMERO", compra.NUMERO),
                new Parametro("@PREFIJO", compra.PREFIJO),
                new Parametro("@TIPO_DOCUMENTO", compra.TIPO_DOCUMENTO),
                new Parametro("@FECHA", compra.FECHA), //yyyyMMdd ingresado por el usuario
                new Parametro("@PROVEEDOR", compra.PROVEEDOR),
                new Parametro("@DIRECCION", compra.DIRECCION),
                new Parametro("@SUMAS", compra.SUMAS.ToString()),
                new Parametro("@IVA", compra.IVA.ToString()),
                new Parametro("@CreatedBy", compra.CreatedBy),
                new Parametro("@CreateDate", fechaFormateada),
            };

            dynamic result = DBDatos.Ejecutar("sp_agregar_compra", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };
        }


        [HttpPost]
        [Route("InsertarDetalleCompra")]
        public dynamic InsertarDetalleCompra(Detallecompra detallecompra)
        {
            //obtengo la fecha y hora actual
            DateTime Ahora = DateTime.Now;
            string fechaFormateada = Ahora.ToString("dd/MM/yyyy HH:mm:ss");

            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@NUMERO", detallecompra.NUMERO),
                new Parametro("@PREFIJO", detallecompra.PREFIJO),
                new Parametro("@TIPO_DOCUMENTO", detallecompra.TIPO_DOCUMENTO),
                new Parametro("@FECHA", detallecompra.PRODUCTO.ToString()),
                new Parametro("@PROVEEDOR", detallecompra.CANTIDAD.ToString()),
                new Parametro("@DIRECCION", detallecompra.PRECIO_UNITARIO.ToString()),
                new Parametro("@SUMAS", detallecompra.TOTAL.ToString()),
                new Parametro("@IVA", detallecompra.LINEA.ToString()),
                new Parametro("@CreatedBy", detallecompra.CreatedBy),
                new Parametro("@CreateDate", fechaFormateada),
                new Parametro("@CreatedBy", detallecompra.DESCRIPCION),
                new Parametro("@CreatedBy", detallecompra.IMPUESTO_PRODUCTO.ToString()),
            };

            dynamic result = DBDatos.Ejecutar("sp_Insertar_Detalle_Compra", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };
        }

    }
}
