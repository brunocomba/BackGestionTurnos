using Microsoft.AspNetCore.Mvc;
using Models.Clases;
using Models.Managers;

namespace WebService.Controllers
{
    [ApiController]
    [Route("turnos")]
    public class TurnoController : ControllerBase
    {
        //[HttpPost("add")]
        //public async Task<ActionResult<Turno>> Add(string horario, DateTime fecha, string nombreCancha, int dniCliente)
        //{
        //    string response;
        //    try
        //    {
        //        response = TurnosMG.Instancia.Add(horario, fecha, nombreCancha, dniCliente);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok(response);
        //}

        //[HttpPut("update/day")]
        //public async Task<ActionResult<Turno>> UpdateDay(int turnoID, DateTime fechaNEW)
        //{
        //    string response;
        //    try
        //    {
        //        response = TurnosMG.Instancia.UpdateDay(turnoID, fechaNEW);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok(response);
        //}

        //[HttpPut("update/horario")]
        //public async Task<ActionResult<Turno>> UpdateHorario(int turnoID, string horario)
        //{
        //    string response;
        //    try
        //    {
        //        response = TurnosMG.Instancia.UdpateHorario(turnoID, horario);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok(response);
        //}

        //[HttpPut("update/cliente")]
        //public async Task<ActionResult<Turno>> UpdateCliente(int turnoID, int dniCliente)
        //{
        //    string response;
        //    try
        //    {
        //        response = TurnosMG.Instancia.UpdateCliente(turnoID, dniCliente);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok(response);
        //}

        //[HttpPut("update/cancha")]
        //public async Task<ActionResult<Turno>> UpdateCancha(int turnoID, string nameCancha)
        //{
        //    string response;
        //    try
        //    {
        //        response = TurnosMG.Instancia.UpdateCancha(turnoID, nameCancha);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok(response);
        //}

        //[HttpDelete("delete")]
        //public async Task<ActionResult<Turno>> Delete(int turnoID)
        //{
        //    string response;
        //    try
        //    {
        //        response = TurnosMG.Instancia.Delete(turnoID);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok(response);
        //}

        //[HttpGet("listado")]
        //public async Task<ActionResult<IEnumerable<Turno>>> Listado()
        //{
        //    IEnumerable<Turno> response;
        //    try
        //    {
        //        response = TurnosMG.Instancia.Listado();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok(response);

        //}

        //[HttpGet("listado/cliente")]
        //public async Task<ActionResult<IEnumerable<Turno>>> ListadoCliente(int dniCliente)
        //{
        //    IEnumerable<Turno> response;
        //    try
        //    {
        //        response = TurnosMG.Instancia.TurnosDeUnCliente(dniCliente);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok(response);

        //}

        //[HttpGet("buscar")]
        //public async Task<ActionResult<IEnumerable<Turno>>> BuscarTurnoPorID(int turnoID)
        //{
        //    Turno response;
        //    try
        //    {
        //        response = TurnosMG.Instancia.Buscar(turnoID);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok(response);

        //}

        //[HttpGet("gananciasdelmes")]
        //public async Task<ActionResult<decimal>> GananciasDelMes(DateTime fechaDelDia)
        //{
        //    decimal response;
        //    try
        //    {
        //        response = TurnosMG.Instancia.ResultadoEconomicoDelMes(fechaDelDia);
        //    }

        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    return Ok(response);

        //}

    }
}
