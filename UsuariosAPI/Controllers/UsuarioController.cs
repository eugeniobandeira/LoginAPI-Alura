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
            try
            {
            await _usuarioService.CadastraUsuario(dto);
            return Ok("Usuário cadastrado!");
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao cadastrar usuário!" +  ex.Message);
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
        {
            try
            { 
            var token = await _usuarioService.Login(dto);
            return Ok(token);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao efetuar login! " + ex.Message);
            }
        }
    }
}