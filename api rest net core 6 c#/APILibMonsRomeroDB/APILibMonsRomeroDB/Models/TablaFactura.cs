namespace APILibMonsRomeroDB.Models
{
    public class TablaFactura
    {
        public string? NUMERO { get; set; }
        public string? PREFIJO { get; set; }
        public string? TIPO_FACTURA { get; set; }
        public string? FECHA { get; set; }
        public string? CLIENTE { get; set; }
        public string? DIRECCION { get; set; }
        public decimal? SUMAS { get; set; }
        public decimal? IVA { get; set; }
        public string? COMENTARIO_ANULACION { get; set; }
        public string? AnulledBy { get; set; }
        public string? AnulledDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreateDate { get; set; }
    }
}
