namespace APILibMonsRomeroDB.Models
{
    public class Venta
    {
        public string? Id_Movimiento { get; set; }
        public string? nombre_producto { get; set; }
        public string? id_categoria { get; set; }
        public string? cantidad { get; set; }
        public string? total { get; set; }
    }

    public class ProcedimientoVerVenta
    {
        //aqui hago set y get de cada cosa que obtendre de ejecutar el procedimiento
        //el nombre tiene que ser identico al de las columnas de las tablas que estoy obteniendo
        public int? id_producto { get; set; }
        public string? nombre_producto { get; set; }
        public int? id_categoria { get; set; }
        public int? cantidad { get; set; }
        public decimal? total { get; set; }

    }
}
