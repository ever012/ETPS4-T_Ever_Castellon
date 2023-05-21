using System.Data.SqlTypes;

namespace APILibMonsRomeroDB.Models
{
    public class Producto
    {
        public int? id_producto { get; set; }
        public string? nombre_producto { get; set; }
        public int? id_categoria { get; set; }
        public decimal? precio { get; set; }
        public string? descripcion { get; set; }
        public int? cantidad { get; set; }
        public string? ESTADO { get; set; }
        public decimal? precio_venta { get; set; }

    }
}
