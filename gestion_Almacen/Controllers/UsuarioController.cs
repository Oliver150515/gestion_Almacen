using gestion_Almacen.Models;
using gestion_Almacen.Repositories.Interfaces.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_Almacen.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: UsuarioController
        [HttpGet("usuario/getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usuarios = await _usuarioRepository.GetAll();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }   
        [HttpGet("usuario/getUsuarioId/{id}")]
        public async Task<IActionResult> getUsuarioId(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetById(id);
                if(usuario == null)
                    return NotFound();

                return Ok(usuario);            
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("usuario/createUsuario")]
        public async Task<IActionResult> createUsuario([FromBody] UsuarioLogin usuarioLogin)
        {
            try
            {
                var createUsuario = await _usuarioRepository.CreateUsuario(usuarioLogin);
                return Ok(createUsuario);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
