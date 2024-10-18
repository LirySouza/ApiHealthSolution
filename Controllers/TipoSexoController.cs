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
    public class TipoSexoController : ControllerBase
    {
        private readonly ITipoSexoRepositorio _tiposexoRepositorio;

        public TipoSexoController(ITipoSexoRepositorio tiposexoRepositorio)
        {
            _tiposexoRepositorio = tiposexoRepositorio;
        }

        [HttpGet("GetAllTipoSexo")]
        public async Task<ActionResult<List<TipoSexoModel>>> GetAllTipoSexo()
        {
            List<TipoSexoModel> tiposexo = await _tiposexoRepositorio.GetAll();
            return Ok(tiposexo);
        }

        [HttpGet("GetTipoSexoId/{id}")]
        public async Task<ActionResult<TipoSexoModel>> TipoSexoId(int id)
        {
            TipoSexoModel usuario = await _tiposexoRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("CreateTipoSexo")]
        public async Task<ActionResult<TipoSexoModel>> InsertTipoSexo([FromBody]TipoSexoModel tiposexoModel)
        {
            TipoSexoModel tiposexo = await _tiposexoRepositorio.InsertTipoSexo(tiposexoModel);
            return Ok(tiposexo);
        }

        [HttpPut("UpdateTipoSexo/{id:int}")]
        public async Task<ActionResult<TipoSexoModel>> UpdateTipoSexo(int id, [FromBody] TipoSexoModel tiposexoModel)
        {
            tiposexoModel.TipoSexoId = id;
            TipoSexoModel tiposexo = await _tiposexoRepositorio.UpdateTipoSexo(tiposexoModel, id);
            return Ok(tiposexo);
        }

        [HttpDelete("DeleteTipoSexo/{id:int}")]
        public async Task<ActionResult<TipoSexoModel>> DeleteTipoSexo(int id)
        {
            bool deleted = await _tiposexoRepositorio.DeleteTipoSexo(id);
            return Ok(deleted);
        }

    }
}
