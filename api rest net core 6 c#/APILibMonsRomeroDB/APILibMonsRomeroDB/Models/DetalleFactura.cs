namespace APILibMonsRomeroDB.Models
{
    public class DetalleFactura
    {
        public int? CODIGO { get; set; }
        public string? NUMERO { get; set; }
        public string? PREFIJO { get; set; }
        public string? TIPO_FACTURA { get; set; }
        public int? PRODUCTO { get; set; }
        public decimal? CANTIDAD { get; set; }
        public decimal? PRECIO_UNITARIO { get; set; }
        public decimal? TOTAL { get; set; }
        public int? LINEA { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreateDate { get; set; }
        public string? DESCRIPCION { get; set; }
        public decimal? IMPUESTO_PRODUCTO { get; set; }
    }
}
