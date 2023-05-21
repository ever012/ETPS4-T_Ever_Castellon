namespace APILibMonsRomeroDB.Models
{
    public class ProcedimientoVerTransaccionesDia
    {
        public int? Id_Movimiento { get; set; }
        public string? nombre_producto { get; set; }
        public int? id_categoria { get; set; }
        public char? TipoMovi { get; set; }
        public int? cantidad { get; set; }
        public decimal? total { get; set; }
    }
}
