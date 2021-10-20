using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoqApp.Models;
using MoqApp.Services;

namespace MoqApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var allUsuarios = await _usuarioService.GetAllAsync();
            return Ok(allUsuarios);
        }

        // GET: api/Usuarios/codigoUsuario
        [HttpGet("{codigoUsuario}")]
        public async Task<IActionResult> GetUsuario(string codigoUsuario)
        {
            var usuario = await _usuarioService.GetByIdAsync(codigoUsuario);
            return usuario != null ? (IActionResult)Ok(usuario) : NotFound();
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<IActionResult> PostUsuario(Usuario usuario)
        {
            var createdUsuario = await _usuarioService.CreateAsync(usuario);

            if(createdUsuario == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetUsuario", new { customerId = createdUsuario.CodigoUsuario }, createdUsuario);
        }

        // DELETE: api/Usuarios/codigoUsuario
        [HttpDelete("{codigoUsuario}")]
        public async Task<IActionResult> DeleteUsuario(string codigoUsuario)
        {
            var deletedUsuario = await _usuarioService.DeleteUsuario(codigoUsuario);

            if (!deletedUsuario)
            {
                return NotFound("Usuario: " + codigoUsuario + " not found!");
            }

            return Ok("Usuario: " + codigoUsuario + " deleted");

        }


    }
}
