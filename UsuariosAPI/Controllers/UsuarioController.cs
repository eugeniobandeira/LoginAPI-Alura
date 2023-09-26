using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Services;
using UsuariosAPI.Data.Dtos;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {

        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }


        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario
            (CreateUsuarioDto dto)
        {
            await _usuarioService.CadastraUsuario(dto);
            return Ok("Usuário cadastrado!");

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
        {
            await _usuarioService.LoginAsync(dto);
            return Ok("Usuário autenticado!");
        }
    }
}