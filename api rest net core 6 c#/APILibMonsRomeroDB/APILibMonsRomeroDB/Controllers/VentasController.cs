using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace APILibMonsRomeroDB.Controllers
{
    [ApiController]
    [Route("ventas")]
    public class VentasController : ControllerBase
    {

        [HttpGet]
        [Route("verVenta")]
        public dynamic verVenta()
        {
            //esta solo retornará una tabla
            
            DataTable VerVenta = DBDatos.Listar("VerVenta"); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonVerVenta = JsonConvert.SerializeObject(VerVenta); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json

            return new
            {
                success = true,
                message = "exito",
                result = JsonConvert.DeserializeObject<List<ProcedimientoVerVenta>>(jsonVerVenta), //aqui convierto el json string en objeto json
                
            };

        }

        [HttpGet]
        [Route("verVentaDia")]
        public dynamic verVentaDia()
        {
            //esta solo retornará una tabla

            DataTable VerVentaDia = DBDatos.Listar("VerVentaDia"); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonVerVentaDia = JsonConvert.SerializeObject(VerVentaDia); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json

            return new
            {
                success = true,
                message = "exito",
                result = JsonConvert.DeserializeObject<List<ProcedimientoVerVenta>>(jsonVerVentaDia), //aqui convierto el json string en objeto json
                
            };
        }








       /* IMPRIMIR VARIOS PROCEDIMIENTOS
        * 
        * [HttpGet]
        [Route("listar")]
        public dynamic ListarVentas(int id)
        {
            //esta solo retornará una tabla
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@id", id.ToString())

            };

            DataTable tEliminarVenta = DBDatos.Listar("EliminarProducto",parametros); //en caso de no tener paramatros solo se deja así, pero si tiene paramentros entonces se agrega la lista
            Console.WriteLine(tEliminarVenta);
            DataTable tVentas = DBDatos.Listar("VerVenta"); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonEliminarVenta = JsonConvert.SerializeObject(tEliminarVenta); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json
            string jsonVentas = JsonConvert.SerializeObject(tVentas);

            return new
            {
                success = true,
                message = "exito",
                result = new
                {
                    eliminarVenta = JsonConvert.DeserializeObject<List<ProcedimientoEliminarProducto>>(jsonEliminarVenta), //aqui convierto el json string en objeto json
                    Listaventas = JsonConvert.DeserializeObject<List<ProcedimientoVerVenta>>(jsonVentas)
                }
            };

            
        }

      

        }*/
    }


}
