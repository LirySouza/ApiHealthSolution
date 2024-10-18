using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepositorio _consultaRepositorio;

        public ConsultaController(IConsultaRepositorio consultaRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
        }

        [HttpGet("GetAllConsulta")]
        public async Task<ActionResult<List<ConsultaModel>>> GetAllConsulta()
        {
            List<ConsultaModel> Consulta = await _consultaRepositorio.GetAll();
            return Ok(Consulta);
        }

        [HttpGet("GetConsultaId/{id}")]
        public async Task<ActionResult<ConsultaModel>> GetConsultaId(int id)
        {
            ConsultaModel consulta = await _consultaRepositorio.GetById(id);
            return Ok(consulta);
        }

        [HttpPost("CreateConsulta")]
        public async Task<ActionResult<ConsultaModel>> InsertConsulta([FromBody] ConsultaModel ConsultaModel)
        {
            ConsultaModel Consulta = await _consultaRepositorio.InsertConsulta(ConsultaModel);
            return Ok(Consulta);
        }

        [HttpPut("UpdateConsulta/{id:int}")]
        public async Task<ActionResult<ConsultaModel>> UpdateConsulta(int id, [FromBody] ConsultaModel consultaModel)
        {
            consultaModel.ConsultaId = id;
            ConsultaModel consulta = await _consultaRepositorio.UpdateConsulta(consultaModel, id);
            return Ok(consulta);
        }

        [HttpDelete("DeleteConsulta/{id:int}")]
        public async Task<ActionResult<ConsultaModel>> DeleteConsulta(int id)
        {
            bool deleted = await _consultaRepositorio.DeleteConsulta(id);
            return Ok(deleted);
        }

    }
}

