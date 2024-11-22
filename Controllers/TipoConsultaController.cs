using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoConsultaController : ControllerBase
    {
        private readonly ITipoConsultaRepositorio _tipoconsultaRepositorio;

        public TipoConsultaController(ITipoConsultaRepositorio tipoconsultaRepositorio)
        {
            _tipoconsultaRepositorio = tipoconsultaRepositorio;
        }

        [HttpGet("GetAllTipoConsulta")]
        public async Task<ActionResult<List<TipoConsultaModel>>> GetAllConsulta()
        {
            List<TipoConsultaModel> TipoConsulta = await _tipoconsultaRepositorio.GetAll();
            return Ok(TipoConsulta);
        }

        [HttpGet("GetTipoConsultaId/{id}")]
        public async Task<ActionResult<TipoConsultaModel>> GetTipoConsultaId(int id)
        {
            TipoConsultaModel tipoconsulta = await _tipoconsultaRepositorio.GetById(id);
            return Ok(tipoconsulta);
        }

        [HttpPost("CreateTipoConsulta")]
        public async Task<ActionResult<TipoConsultaModel>> InsertTipoConsulta([FromBody] TipoConsultaModel TipoConsultaModel)
        {
            TipoConsultaModel TipoConsulta = await _tipoconsultaRepositorio.InsertTipoConsulta(TipoConsultaModel);
            return Ok(TipoConsulta);
        }

        [HttpPut("UpdateTipoConsulta/{id:int}")]
        public async Task<ActionResult<TipoConsultaModel>> UpdateTipoConsulta(int id, [FromBody] TipoConsultaModel tipoconsultaModel)
        {
            //tipoconsultaModel.TipoConsultaId = id;
            TipoConsultaModel tipoconsulta = await _tipoconsultaRepositorio.UpdateTipoConsulta(tipoconsultaModel, id);
            return Ok(tipoconsulta);
        }

        [HttpDelete("DeleteTipoConsulta/{id:int}")]
        public async Task<ActionResult<TipoConsultaModel>> DeleteTipoConsulta(int id)
        {
            bool deleted = await _tipoconsultaRepositorio.DeleteTipoConsulta(id);
            return Ok(deleted);
        }

    }
}

