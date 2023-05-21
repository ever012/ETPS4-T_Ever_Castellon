namespace APILibMonsRomeroDB.Models
{
    public class UsuarioInfoCompleto
    {
        public string USUARIO { get; set; }
        public string CLAVE { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string SEXO { get; set; }
        public int ROL { get; set; }
        public string CODIGO_SUCURSAL { get; set; }
        public string CreateDate { get; set; }
        public string ACTIVO { get; set; }
        public int id_usuario { get; set; }
    }
}
