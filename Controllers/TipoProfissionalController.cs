﻿using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProfissionalController : ControllerBase
    {
        private readonly ITipoProfissionalRepositorio _tipoprofissionalRepositorio;

        public TipoProfissionalController(ITipoProfissionalRepositorio tipoprofissionalRepositorio)
        {
            _tipoprofissionalRepositorio = tipoprofissionalRepositorio;
        }

        [HttpGet("GetAllTipoProfissional")]
        public async Task<ActionResult<List<TipoProfissionalModel>>> GetAllTipoProfissional()
        {
            List<TipoProfissionalModel> TipoProfissional = await _tipoprofissionalRepositorio.GetAll();
            return Ok(TipoProfissional);
        }

        [HttpGet("GetTipoProfissionalId/{id}")]
        public async Task<ActionResult<TipoProfissionalModel>> GetTipoProfissionalId(int id)
        {
            TipoProfissionalModel usuario = await _tipoprofissionalRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("CreateTipoProfissional")]
        public async Task<ActionResult<TipoProfissionalModel>> InsertTipoProfissional([FromBody] TipoProfissionalModel TipoProfissionalModel)
        {
            TipoProfissionalModel TipoProfissional = await _tipoprofissionalRepositorio.InsertTipoProfissional(TipoProfissionalModel);
            return Ok(TipoProfissional);
        }

    }
}

