using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("GetAllUsuario")]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllUsuario()
        {
            List<UsuarioModel> Usuario = await _usuarioRepositorio.GetAll();
            return Ok(Usuario);
        }

        [HttpGet("GetUsuarioId/{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuarioId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("CreateUsuario")]
        public async Task<ActionResult<UsuarioModel>> InsertUsuario([FromBody]UsuarioModel usuarioModel)
        {
            UsuarioModel Usuario = await _usuarioRepositorio.InsertUsuario(usuarioModel);
            return Ok(Usuario);
        }

        [HttpPut("UpdateUsuario/{id:int}")]
        public async Task<ActionResult<UsuarioModel>> UpdateUsuario(int id, [FromBody] UsuarioModel usuarioModel)
        {
            usuarioModel.UsuarioId = id;
            UsuarioModel usuario = await _usuarioRepositorio.UpdateUsuario(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("DeleteUsuario/{id:int}")]
        public async Task<ActionResult<UsuarioModel>> DeleteUsuario(int id)
        {
            bool deleted = await _usuarioRepositorio.DeleteUsuario(id);
            return Ok(deleted);
        }

        [HttpPost("LoginUsuario")]
        public async Task<ActionResult<UsuarioModel>> LoginUsuario([FromBody] UsuarioModel usuarioModel)
        {
            var email = usuarioModel.UsuarioEmail;
            var senha = usuarioModel.UsuarioSenha;
            UsuarioModel Usuario = await _usuarioRepositorio.LoginUsuario(email, senha);

            if (Usuario == null){
                return  Problem("Usuário não encontrado");
                    
             }

            else
                return Ok(Usuario);
        }

    }
}
