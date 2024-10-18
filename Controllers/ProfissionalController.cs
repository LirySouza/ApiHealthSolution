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
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepositorio _profissionalRepositorio;

        public ProfissionalController(IProfissionalRepositorio profissionalRepositorio)
        {
            _profissionalRepositorio = profissionalRepositorio;
        }

        [HttpGet("GetAllProfissional")]
        public async Task<ActionResult<List<ProfissionalModel>>> GetAllProfissional()
        {
            List<ProfissionalModel> Profissional = await _profissionalRepositorio.GetAll();
            return Ok(Profissional);
        }

        [HttpGet("GetPacienteId/{id}")]
        public async Task<ActionResult<ProfissionalModel>> GetProfissionalId(int id)
        {
            ProfissionalModel usuario = await _profissionalRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("CreateProfissional")]
        public async Task<ActionResult<ProfissionalModel>> InsertProfissional([FromBody] ProfissionalModel ProfissionalModel)
        {
            ProfissionalModel Profissional = await _profissionalRepositorio.InsertProfissional(ProfissionalModel);
            return Ok(Profissional);
        }
        [HttpPut("UpdateProfissional/{id:int}")]
        public async Task<ActionResult<ProfissionalModel>> UpdateProfissional(int id, [FromBody] ProfissionalModel profissionalModel)
        {
            profissionalModel.ProfissionalId = id;
            ProfissionalModel profissional = await _profissionalRepositorio.UpdateProfissional(profissionalModel, id);
            return Ok(profissional);
        }

        [HttpDelete("DeleteProfissional/{id:int}")]
        public async Task<ActionResult<ProfissionalModel>> DeleteProfissional(int id)
        {
            bool deleted = await _profissionalRepositorio.DeleteProfissional(id);
            return Ok(deleted);
        }

    }
}

