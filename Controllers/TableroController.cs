using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_vaninaze.Controllers;
using EspacioTablero;
using kanbanRespository;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    private ITableroRepository tableroRepo;
    private readonly ILogger<TableroController> _logger;
    
    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepo = new TableroRepository();
    }

    [HttpPost("CrearTablero")]
    public ActionResult<bool> CrearTablero(Tablero tablero){
        tableroRepo.Create(tablero);
        return Ok("Tablero creado");
    }
    [HttpPut("ModificarTablero")]
    public ActionResult<bool> ModificarTablero(int id, Tablero tablero){
        tableroRepo.Update(id, tablero);
        return Ok("Tablero modificado");
    }
    [HttpGet("GetById")]
    public ActionResult<Tablero> GetById(int id){
        Tablero tab = tableroRepo.GetById(id);
        return Ok(tab);
    }
    [HttpGet("GetAll")]    
    public ActionResult<List<Tablero>> GetAll(){
        List<Tablero> lista = tableroRepo.GetAll();
        return lista;
    }
    [HttpGet("GetAllByUsuario")]   
    public ActionResult<List<Tablero>> GetAllByUsuario(int idUsu){
        List<Tablero> lista = tableroRepo.GetByIdUsuario(idUsu);
        return lista;
    }
}