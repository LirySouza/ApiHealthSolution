﻿using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepositorio _usersRepositorio;

        public UsersController(IUsersRepositorio usersRepositorio)
        {
            _usersRepositorio = usersRepositorio;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UsersModel>>> GetAllUsers()
        {
            List<UsersModel> users = await _usersRepositorio.GetAll();
            return Ok(users);
        }

        [HttpGet("GetUserId/{id}")]
        public async Task<ActionResult<UsersModel>> GetUserId(int id)
        {
            UsersModel usuario = await _usersRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UsersModel>> InsertUser([FromBody]UsersModel userModel)
        {
            UsersModel user = await _usersRepositorio.InsertUser(userModel);
            return Ok(user);
        }

        [HttpPut("UpdateUsers/{id:int}")]
        public async Task<ActionResult<UsersModel>> UpdateTipoSexo(int id, [FromBody] UsersModel usersModel)
        {
            usersModel.UserId = id;
            UsersModel users = await _usersRepositorio.UpdateUser(usersModel, id);
            return Ok(users);
        }

        [HttpDelete("DeleteUsers/{id:int}")]
        public async Task<ActionResult<UsersModel>> DeleteUsers(int id)
        {
            bool deleted = await _usersRepositorio.DeleteUser(id);
            return Ok(deleted);
        }

    }
}
