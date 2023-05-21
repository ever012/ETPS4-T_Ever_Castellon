namespace APILibMonsRomeroDB.Models
{
    public class ProcedimientoLlenarMovi
    {
        public int? Id_Movimiento { get; set; }
        public int? id_producto { get; set; }
        public char? TipoMovi { get; set; }
        public int? cantidad { get; set; }
        public decimal? total { get; set; }
        public string? fecha { get; set; }
    }


}
