using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_vaninaze.Controllers;
using EspacioTablero;
using kanbanRespository;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private ITareaRepository tareaRepo;
    private readonly ILogger<TareaController> _logger;
    
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepo = new TareaRepository();
    }

    [HttpPost("CrearTarea")]
    public ActionResult<bool> CrearTarea(int idTablero, Tarea tarea){
        tareaRepo.Create(idTablero, tarea);
        return Ok("Tarea creada");
    }
    [HttpPut("ModificarTareaNombre")]
    public ActionResult<bool> ModificarTareaNombre(int id, string nombre){
        tareaRepo.UpdateName(id, nombre);
        return Ok("Nombre modificado");
    }
    [HttpPut("ModificarTareaEstado")]
    public ActionResult<bool> ModificarTareaEstado(int id, Estado estado){
        tareaRepo.UpdateEstado(id, estado);
        return Ok("Estado modificado");
    }

    [HttpDelete("BorrarTarea")]
    public ActionResult<bool> BorrarTarea(int id)
    {
        tareaRepo.Remove(id);
        return Ok("Tarea borrada");
    }
    [HttpGet("GetCantEstado")]
    public ActionResult<int> GetCantEstado(Estado estado)
    {
        int cant = tareaRepo.GetCantEstado(estado);
        return cant;
    }
    [HttpGet("GetByUsu")]
    public ActionResult<List<Tarea>> GetByUsu(int idUsu)
    {
        List<Tarea> lista = tareaRepo.ListarDeUsuario(idUsu);
        return lista;
    } 
    [HttpGet("GetByTablero")]
    public ActionResult<List<Tarea>> GetByTablero(int idTab)
    {
        List<Tarea> lista = tareaRepo.ListarDeTablero(idTab);
        return lista;
    }
}