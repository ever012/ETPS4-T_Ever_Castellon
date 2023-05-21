using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Mvc;

namespace APILibMonsRomeroDB.Controllers
{
    [ApiController]
    [Route("proveedores")]
    public class ControladorProveedor : ControllerBase
    {
        [HttpPost]
        [Route("insertarProveedores")]
        public dynamic insertarProveedores(Proveedores proveedores)
        {

            List<Parametro> parametros = new List<Parametro>
            {
            new Parametro("@CODIGO", proveedores.CODIGO),
            new Parametro("@NOMBRES", proveedores.NOMBRES),
            new Parametro("@APELLIDOS", proveedores.APELLIDOS),
            new Parametro("@IDENTIFICACION", proveedores.IDENTIFICACION),
            new Parametro("@TELEFONO", proveedores.TELEFONO),
            new Parametro("@DIRECCION", proveedores.DIRECCION),
            new Parametro("@ESTADO", proveedores.ESTADO),
            new Parametro("@CreatedBy", proveedores.CreatedBy),
            new Parametro("@CreateDate", proveedores.CreateDate),
            };

            dynamic result = DBDatos.Ejecutar("sp_Insertar_Proveedor", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };
        }



        [HttpPatch]
        [Route("actualizarProveedores")]
        public dynamic actualizarProveedores(Proveedores proveedores)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@CODIGO", proveedores.CODIGO),
                new Parametro("@NOMBRES", proveedores.NOMBRES),
                new Parametro("@APELLIDOS", proveedores.APELLIDOS),
                new Parametro("@IDENTIFICACION", proveedores.IDENTIFICACION),
                new Parametro("@TELEFONO", proveedores.TELEFONO),
                new Parametro("@DIRECCION", proveedores.DIRECCION),
                new Parametro("@ESTADO", proveedores.ESTADO),
                new Parametro("@UpdatedBy", proveedores.UpdatedBy),
                new Parametro("@UpdateDate", proveedores.UpdateDate),

            };

            dynamic result = DBDatos.Ejecutar("LlenarMovi", parametros);

            return new
            {
                success = result.exito,
                message = result.mensaje,
                result = ""

            };
        }
    }
}
