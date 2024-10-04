

using Models.Interfaces;

namespace Models.Clases
{
    public class Administrador : IConEmailAndPass, IConDni, IConNombreAndApellido
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public Administrador(string? nombre, string? apellido, int dni, DateTime FechaNacimiento, string? calle, int altura, string? email, string? pass)
        //{
        //    Nombre = nombre; Apellido = apellido; Dni = dni;fechaNacimiento = FechaNacimiento; Calle = calle; Altura = altura; Email = email; Password = pass;
        //}


    }
}
