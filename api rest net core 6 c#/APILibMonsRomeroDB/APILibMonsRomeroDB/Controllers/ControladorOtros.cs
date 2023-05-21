using APILibMonsRomeroDB.Models;
using APILibMonsRomeroDB.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace APILibMonsRomeroDB.Controllers
{
    [ApiController]
    [Route("otros")]
    public class ControladorOtros : ControllerBase
    {
        [HttpGet]
        [Route("ganancias")]
        public dynamic ganancias()
        {
            //esta solo retornará una tabla

            DataTable Ganancias = DBDatos.Listar("Ganancias"); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonGanancias = JsonConvert.SerializeObject(Ganancias); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json

            return new
            {
                success = true,
                message = "exito",
                result = JsonConvert.DeserializeObject<List<ProcedimientoGanancias>>(jsonGanancias), //aqui convierto el json string en objeto json
                
            };
        }


        [HttpGet]
        [Route("gananciasDiarias")]
        public dynamic gananciasDiarias()
        {
            //esta solo retornará una tabla

            DataTable GananciasDiarias = DBDatos.Listar("GananciasDiarias"); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonGananciasDiarias = JsonConvert.SerializeObject(GananciasDiarias); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json

            return new
            {
                success = true,
                message = "exito",
                result = JsonConvert.DeserializeObject<List<ProcedimientoGananciasDiarias>>(jsonGananciasDiarias), //aqui convierto el json string en objeto json
                
            };
        }


        [HttpGet]
        [Route("verTransacciones")]
        public dynamic verTransacciones()
        {
            //esta solo retornará una tabla

            DataTable VerTransacciones = DBDatos.Listar("VerTransacciones"); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonVerTransacciones = JsonConvert.SerializeObject(VerTransacciones); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json

            return new
            {
                success = true,
                message = "exito",
                result = JsonConvert.DeserializeObject<List<ProcedimientoVerTransaccionesDia>>(jsonVerTransacciones), //aqui convierto el json string en objeto json
                
            };
        }


        [HttpGet]
        [Route("verTransaccionesDia")]
        public dynamic verTransaccionesDia()
        {
            //esta solo retornará una tabla

            DataTable VerTransaccionesDia = DBDatos.Listar("VerTransaccionesDia"); //aui no se usan parametros

            //los dataTables nos devuelven objetos y hay que transformarlos a json
            string jsonVerTransaccionesDia = JsonConvert.SerializeObject(VerTransaccionesDia); //SerializeObject es el metodo que convierte el DataTable en JSON en un string pero no en un objeto json

            return new
            {
                success = true,
                message = "exito",
                result = JsonConvert.DeserializeObject<List<ProcedimientoVerTransaccionesDia>>(jsonVerTransaccionesDia), //aqui convierto el json string en objeto json
                
            };
        }
    }
}
