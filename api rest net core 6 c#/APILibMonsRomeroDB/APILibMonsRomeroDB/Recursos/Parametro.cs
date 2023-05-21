namespace APILibMonsRomeroDB.Recursos
{
    //este archivo es para consumir los procedimientos que tengan parametros
    public class Parametro
    {
        public Parametro(string nombre,string valor) 
        {
            Nombre = nombre;
            Valor = valor;
        }
        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
