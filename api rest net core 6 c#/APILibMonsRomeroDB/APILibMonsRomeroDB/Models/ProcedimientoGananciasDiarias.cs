using Newtonsoft.Json;

namespace APILibMonsRomeroDB.Models
{
    public class ProcedimientoGananciasDiarias
    {
        [JsonProperty("[Ventas Diarias")] //JsonProperty es necesario porque en la base de datos, el resultado del procedimiento da
                                           //los resultados con columnas con espacios
        public decimal? VentasDiarias { get; set; }
        [JsonProperty("Compras Diarias")]
        public decimal? ComprasDiarias { get; set; }
        [JsonProperty("Ganancia Diarias")]
        public decimal? GananciaDiarias { get; set; }
    }

    public class ProcedimientoGanancias
    {
        [JsonProperty("Ventas Generales")] //JsonProperty es necesario porque en la base de datos, el resultado del procedimiento da
                                           //los resultados con columnas con espacios
        public decimal? VentasGenerales { get; set; }

        [JsonProperty("Compras Generales")]
        public decimal? ComprasGenerales { get; set; }

        [JsonProperty("Ganancia General")]
        public decimal? GananciaGeneral { get; set; }
    }
}
