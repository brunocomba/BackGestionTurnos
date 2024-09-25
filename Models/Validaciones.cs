using Microsoft.EntityFrameworkCore;
using Models.ConnectionDB;
using Models.Interfaces;
using System.Net;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models
{
    public class Validaciones<T> : IValidaciones<T> where T : class  
    {
        protected readonly AppDbContext _context;

        public Validaciones(AppDbContext context)
        {
            _context = context;
        }

        public bool SoloLetras(string textBox)
        {
            foreach (char c in textBox)
            {
                if (char.IsAsciiLetter(c) == false && c != ' ')
                {
                    throw new Exception($"Error: No se aceptan numeros en los campos de texto.");
                }
            }

            return true;
        }

        public bool SoloNumeros(int textBox)
        {
            foreach (char c in textBox.ToString())
            {
                if (char.IsAsciiDigit(c) == false)
                {
                    throw new Exception($"Error: No se aceptan letras en los campos numericos.");
                }
            }

            return true;
        }

        public bool SoloNumerosEnTel(uint textBox)
        {
            foreach (char c in textBox.ToString())
            {
                if (char.IsAsciiDigit(c) == false)
                {
                    throw new Exception($"Error: No se aceptan letras en el campo de telefono.");
                }
            }

            return true;
        }

        public bool SoloNumerosEnPrecio(decimal textBox)
        {
            foreach (char c in textBox.ToString())
            {
                if (char.IsDigit(c) == false)
                {
                    throw new Exception($"Error: No se aceptan letras en el campo de precio.");
                }
            }

            return true;
        }
        public bool TelCompleto(uint Tel)
        {
            int minimoDeCaracteres = 10;

            if (Tel.ToString().Length < minimoDeCaracteres)
            {
                throw new Exception($"Error: El telefono ingresado esta incompleto.");
            }
            return true;
        }

        public bool DniCompleto(int DNI)
        {
            int minimoDeCaracteres = 8;

            if (DNI.ToString().Length < minimoDeCaracteres)
            {
                throw new Exception($"Error: El DNI ingresado esta incompleto.");
            }

            return true;
        }

        public bool CumpleRequisitosEmail(string email)
        {
            if (email.Contains("@") && email.Contains(".") && email.Contains("com"))
            {
                return true;
            }

            throw new Exception("Error: El email ingresado esta en un formato incorrecto.");
        }

        public bool CumpleRequisitosPass(string Pass)
        {
            bool tieneMayuscula = Regex.IsMatch(Pass, @"[A-Z]");
            bool tieneNumero = Regex.IsMatch(Pass, @"\d");

            if (tieneMayuscula && tieneNumero)
            {
                return true;
            }

            throw new Exception("Error: La contraseña debe contener al menos una mayuscula y un numero.");
        }

        public bool ConfirmarPass(string Pass, string ConfirPass)
        {
            if (Pass == ConfirPass)
            {
                return true;

            }
            throw new Exception("Error: Las contraseñas ingresadas no coinciden.");

        }

        public bool ConfirmarEmail(string email, string confirEmail)
        {
            if (email == confirEmail)
            {
                return true;

            }
            throw new Exception("Error: Los email ingresados no coinciden.");

        }

        public bool PassAnteriorCorrecta(string passIngresada, string passAnterior)
        {
            if (passIngresada != passAnterior)
            {
                throw new Exception($"Error: La contraseña anterior es incorrecta");
            }

            return true;
        }

        public bool PassRegistradaDistinta(string passNew, string passRegistrada)
        {
            if (passNew == passRegistrada)
            {
                throw new Exception($"Error: La contraseña ingresada es la misma que la actual");
            }

            return true;

        }
        public bool EmailAnteriorCorrecto(string emailIngresdo, string emailAnterior)
        {
            if (emailIngresdo != emailAnterior)
            {
                throw new Exception($"Error: El email anterior es incorrecto");
            }

            return true;
        }
        public bool EmailRegistradoDistinto(string emailIngresado, string emailRegistado)
        {
            if (emailIngresado == emailRegistado)
            {
                throw new Exception($"Error: El Email ingresado es el mismo que el actual");

            }

            return true;

        }
       
        public bool Mayor18(DateTime nacimiento)
        {
            int edad = DateTime.Now.Year - nacimiento.Year;

            if (edad >= 18)
            {
                return true;
            }
            throw new Exception("Error: Es necesario ser mayor de 18 años.");
        }

        public bool MayorDe0(int numero)
        {
            if(numero <= 0)
            {
                throw new Exception($"Error: Los campos numericos no pueden tener numeros menor a 0.");
            }
            return true;
        }

        public bool TelMayorDe0(uint tel)
        {
            if (tel <= 0)
            {
                throw new Exception("Error: Telefono no puede contener un numero menor a 0");
            }
            return true;
        }


        public bool PrecioMayorDe0(decimal precio)
        {
            if (precio <= 0)
            {
                throw new Exception("Error: Precio no puede contener un numero menor a 0");
            }
            return true;
        }


        public async Task<bool> DniRegistrado(int dni)
        {
            if (typeof(IConDni).IsAssignableFrom(typeof(T))) // verifica si el tipo T (la clase genérica) implementa la interfaz IConDni
            {
                var obj = await _context.Set<T>().FirstOrDefaultAsync(obj => ((IConDni)obj).Dni == dni);

                if (obj == null)
                {
                    return true;
                }

                throw new Exception($"Ya existe un {typeof(T).Name} registrado con el DNI: {dni}");
            }
            throw new Exception($"Error interno: {typeof(T)} no implementa la interfaz IConDni");

        }


        public async Task<T> IdRegistrado(int id)
        {
            var obj =  await _context.Set<T>().FindAsync(id);
            if (obj == null)
            {
                throw new Exception($"No existe un {typeof(T).Name} registrado con el ID: {id}");
            }

            return obj;
        }

      
        public async Task<bool> NombreRegistrado(string nombre)
        {
            if (typeof(IConName).IsAssignableFrom(typeof(T))) // verifica si el tipo T (la clase genérica) implementa la interfaz IConName
            {
                var obj = await _context.Set<T>().FirstOrDefaultAsync(obj => ((IConName)obj).Name == nombre);

                if (obj == null)
                {
                    return true;
                }

                throw new Exception($"Ya existe un {typeof(T).Name} registrado con el nombre: {nombre}");
            }

            throw new Exception($"Error interno: {typeof(T)} no implementa la interfaz IConName");
        }

    
        public async Task<T> BuscarPorNombre(string nombre)
        {
            if (typeof(IConName).IsAssignableFrom(typeof(T))) // verifica si el tipo T (la clase genérica) implementa la interfaz IConName
            {
                var obj = await _context.Set<T>().FirstOrDefaultAsync(obj => ((IConName)obj).Name == nombre);

                if (obj == null)
                {
                    throw new Exception($"No existe un {typeof(T).Name} registrado con el nombre: {nombre}");
                }

                return obj;
            }

            throw new Exception($"Error interno: {typeof(T)} no implementa la interfaz IConName");
        }


        public async Task<bool> EmailRegistrado(string email)
        {
            if (typeof(IConEmailAndPass).IsAssignableFrom(typeof(T))) // verifica si el tipo T (la clase genérica) implementa la interfaz IConEmailAndPass
            {
                var obj = await _context.Set<T>().FirstOrDefaultAsync(obj => ((IConEmailAndPass)obj).Email == email);

                if (obj == null)
                {
                    return true;
                }

                throw new Exception($"Ya existe un {typeof(T).Name} registrado con el Email: {email}");
            }

            throw new Exception($"Error interno: {typeof(T)} no implementa la interfaz IConEmailAndPass");
        }

        public async Task<bool> DniRegistradoMenosActual(int dniNew, int dniRegistrado)
        {
            if (typeof(IConDni).IsAssignableFrom(typeof(T))) // verifica si el tipo T (la clase genérica) implementa la interfaz IConDni
            {
                if (dniNew != dniRegistrado)
                {
                    var obje = await _context.Set<T>().FirstOrDefaultAsync(obj => ((IConDni)obj).Dni == dniNew);
                    if (obje != null)
                    {
                        throw new Exception($"Ya existe un {typeof(T).Name} registrado con el DNI: {dniNew}");

                    }
                }

                return true;
            }

            throw new Exception($"Error interno: {typeof(T)} no implementa la interfaz IConDni");
        }

        public async Task<bool> NombreRegistradoMenosActual(string nombreNew, string nombreRegistrado)
        {
            if (typeof(IConName).IsAssignableFrom(typeof(T))) // verifica si el tipo T (la clase genérica) implementa la interfaz IConName
            {
                if (nombreNew != nombreRegistrado)
                {
                    var obje = await _context.Set<T>().FirstOrDefaultAsync(obj => ((IConName)obj).Name == nombreNew);
                    if (obje != null)
                    {
                        throw new Exception($"Ya existe un {typeof(T).Name} registrado con el nombre: {nombreNew}");

                    }
                }

                return true;
            }

            throw new Exception($"Error interno: {typeof(T)} no implementa la interfaz IConName");

        }



      
    }
}
