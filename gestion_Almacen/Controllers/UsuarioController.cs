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
        [HttpGet("usuario/get")]
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
        [HttpGet("usuario/Prueba")]
        public String prueba()
        {
            return "Hola";
        }
    }
}
