namespace WebService
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string[] Audiences { get; set; } // Audiencias como un arreglo de cadenas
    }
}
