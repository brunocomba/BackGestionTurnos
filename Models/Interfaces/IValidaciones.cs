
namespace Models.Interfaces
{
    public interface IValidaciones<T> where T : class
    {
        bool SoloLetras(string textBox);
        bool SoloNumeros(int textBox);
        bool SoloNumerosEnTel(uint tel);
        bool SoloNumerosEnPrecio(decimal precio);
        bool TelCompleto(uint Tel);
        bool DniCompleto(int DNI);
        bool CumpleRequisitosEmail(string email);
        bool CumpleRequisitosPass(string Pass);
        bool ConfirmarPass(string Pass, string ConfirPazs);
        bool ConfirmarEmail(string email, string confirEmail);
        bool Mayor18(DateTime nacimiento);
        bool MayorDe0(int numero);
        bool TelMayorDe0(uint tel);
        bool PrecioMayorDe0(decimal precio);    
        Task<bool> DniRegistrado(int dni);
        Task<bool> DniRegistradoMenosActual(int dniNew, int dniActual);

        Task<T> IdRegistrado(int id);
        Task<T> BuscarPorNombre(string nombre);
        Task<bool> NombreRegistrado(string nombre);
        Task<bool> EmailRegistrado(string email);
        bool PassAnteriorCorrecta(string passIngresada, string passAnterior);
        bool PassRegistradaDistinta(string passNew, string passRegistrada);
        bool EmailRegistradoDistinto(string emailIngresado, string emailRegistrado);
        bool EmailAnteriorCorrecto(string emailIngresdo, string emailAnterior);
        bool ExisteAsignacion(int idCancha, int idAsignacion);
        Task<T> BuscarAsignacion(string nombreCancha, string nombreElemento);

    }

}
