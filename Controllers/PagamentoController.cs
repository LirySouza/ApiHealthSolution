using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoRepositorio _pagamentoRepositorio;

        public PagamentoController(IPagamentoRepositorio pagamentoRepositorio)
        {
            _pagamentoRepositorio = pagamentoRepositorio;
        }

        [HttpGet("GetAllPagamento")]
        public async Task<ActionResult<List<PagamentoModel>>> GetAllPagamento()
        {
            List<PagamentoModel> Pagamento = await _pagamentoRepositorio.GetAll();
            return Ok(Pagamento);
        }

        [HttpGet("GetPagamentoId/{id}")]
        public async Task<ActionResult<PagamentoModel>> GetPagamentoId(int id)
        {
            PagamentoModel pagamento = await _pagamentoRepositorio.GetById(id);
            return Ok(pagamento);
        }

        [HttpPost("CreatePagamento")]
        public async Task<ActionResult<PagamentoModel>> InsertPagamento([FromBody] PagamentoModel PagamentoModel)
        {
            PagamentoModel Pagamento = await _pagamentoRepositorio.InsertPagamento(PagamentoModel);
            return Ok(Pagamento);
        }

        [HttpPut("UpdatePagamento/{id:int}")]
        public async Task<ActionResult<PagamentoModel>> UpdatePagamento(int id, [FromBody] PagamentoModel pagamentoModel)
        {
            pagamentoModel.PagamentoId = id;
            PagamentoModel pagamento = await _pagamentoRepositorio.UpdatePagamento(pagamentoModel, id);
            return Ok(pagamento);
        }

        [HttpDelete("DeletePagamento/{id:int}")]
        public async Task<ActionResult<PagamentoModel>> DeletePagamento(int id)
        {
            bool deleted = await _pagamentoRepositorio.DeletePagamento(id);
            return Ok(deleted);
        }

    }
}

