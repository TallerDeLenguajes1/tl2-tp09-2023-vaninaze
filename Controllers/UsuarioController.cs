using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_vaninaze.Controllers;
using EspacioTablero;
using kanbanRespository;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private IUsuarioRepository usuarioRepo;
    private readonly ILogger<UsuarioController> _logger;
    
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepo = new UsuarioRepository();
    }

    [HttpPost("CrearUsuario")]
    public ActionResult<bool> CrearUsuario(Usuario usuario){
        usuarioRepo.Create(usuario);
        return Ok("Usuario creado");
    }
    [HttpGet("ListarUsuarios")]
    public ActionResult<List<Usuario>> ListarUsuarios(){
        return usuarioRepo.GetAll();
    }
    [HttpGet("GetById")]
    public ActionResult<Usuario> GetById(int id){
        return usuarioRepo.GetById(id);
    }
    [HttpPut("ModificarUsuario")]
    public ActionResult<bool> ModificarUsuario(int id, string nombre){
        usuarioRepo.Update(id,nombre);
        return Ok("Usuario modificado");
    }
}
