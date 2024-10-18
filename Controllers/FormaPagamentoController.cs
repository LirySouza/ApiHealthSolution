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
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoRepositorio _formapagamentoRepositorio;

        public FormaPagamentoController(IFormaPagamentoRepositorio formapagamentoRepositorio)
        {
            _formapagamentoRepositorio = formapagamentoRepositorio;
        }

        [HttpGet("GetAllFormaPagamento")]
        public async Task<ActionResult<List<FormaPagamentoModel>>> GetAllFormaPagamento()
        {
            List<FormaPagamentoModel> FormaPagamento = await _formapagamentoRepositorio.GetAll();
            return Ok(FormaPagamento);
        }

        [HttpGet("GetFormaPagamentoId/{id}")]
        public async Task<ActionResult<FormaPagamentoModel>> GetFormaPagamentoId(int id)
        {
            FormaPagamentoModel formapagamento = await _formapagamentoRepositorio.GetById(id);
            return Ok(formapagamento);
        }

        [HttpPost("CreateFormaPagamento")]
        public async Task<ActionResult<FormaPagamentoModel>> InsertFormaPagamento([FromBody] FormaPagamentoModel FormaPagamentoModel)
        {
            FormaPagamentoModel FormaPagamento = await _formapagamentoRepositorio.InsertFormaPagamento(FormaPagamentoModel);
            return Ok(FormaPagamento);
        }

        [HttpPut("UpdateFormaPagamento/{id:int}")]
        public async Task<ActionResult<FormaPagamentoModel>> UpdateFormaPagamento(int id, [FromBody] FormaPagamentoModel formapagamentoModel)
        {
            formapagamentoModel.FormaPagamentoId = id;
            FormaPagamentoModel formapagamento = await _formapagamentoRepositorio.UpdateFormaPagamento(formapagamentoModel, id);
            return Ok(formapagamento);
        }

        [HttpDelete("DeleteFormaPagamento/{id:int}")]
        public async Task<ActionResult<FormaPagamentoModel>> DeleteFormaPagamento(int id)
        {
            bool deleted = await _formapagamentoRepositorio.DeleteFormaPagamento(id);
            return Ok(deleted);
        }

    }
}

