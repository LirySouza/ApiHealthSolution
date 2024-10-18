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
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public PacienteController(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        [HttpGet("GetAllPaciente")]
        public async Task<ActionResult<List<PacienteModel>>> GetAllPaciente()
        {
            List<PacienteModel> Paciente = await _pacienteRepositorio.GetAll();
            return Ok(Paciente);
        }

        [HttpGet("GetPacienteId/{id}")]
        public async Task<ActionResult<PacienteModel>> GetPacienteId(int id)
        {
            PacienteModel usuario = await _pacienteRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("CreatePaciente")]
        public async Task<ActionResult<PacienteModel>> InsertPaciente([FromBody] PacienteModel PacienteModel)
        {
            PacienteModel Paciente = await _pacienteRepositorio.InsertPaciente(PacienteModel);
            return Ok(Paciente);
        }
        [HttpPut("UpdatePaciente/{id:int}")]
        public async Task<ActionResult<PacienteModel>> UpdatePaciente(int id, [FromBody] PacienteModel pacienteModel)
        {
            pacienteModel.PacienteId = id;
            PacienteModel paciente = await _pacienteRepositorio.UpdatePaciente(pacienteModel, id);
            return Ok(paciente);
        }

        [HttpDelete("DeletePaciente/{id:int}")]
        public async Task<ActionResult<PacienteModel>> DeletePaciente(int id)
        {
            bool deleted = await _pacienteRepositorio.DeletePaciente(id);
            return Ok(deleted);
        }

    }
}

