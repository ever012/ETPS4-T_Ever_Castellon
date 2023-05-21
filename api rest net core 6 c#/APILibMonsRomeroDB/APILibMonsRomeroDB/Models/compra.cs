using System;

namespace APILibMonsRomeroDB.Models
{
    public class compra
    {
        public string NUMERO { get; set; }
        public string PREFIJO { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string FECHA { get; set; }
        public string PROVEEDOR { get; set; }
        public string DIRECCION { get; set; }
        public decimal SUMAS { get; set; }
        public decimal IVA { get; set; }
        public string CreatedBy { get; set; }
        public string CreateDate { get; set; }

    }

    public class Detallecompra
    {
        public string NUMERO { get; set; }
        public string PREFIJO { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public int PRODUCTO { get; set; }
        public decimal CANTIDAD { get; set; }
        public decimal PRECIO_UNITARIO { get; set; }
        public decimal TOTAL { get; set; }
        public int LINEA { get; set; }
        public string CreatedBy { get; set; }
        public string CreateDate { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal IMPUESTO_PRODUCTO { get; set; }

    }

    public class sp_verCompra
    {
        public string Id_Movimiento { get; set; }
        public string nombre_producto { get; set; }
        public string id_categoria { get; set; }
        public string cantidad { get; set; }
        public string total { get; set; }
    }

}
