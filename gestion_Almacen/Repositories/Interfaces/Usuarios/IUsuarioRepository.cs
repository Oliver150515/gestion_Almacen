using gestion_Almacen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_Almacen.Repositories.Interfaces.Usuarios
{
    public interface IUsuarioRepository
    {
        public Task<IEnumerable<Usuario>> GetAll();
        public Task<Usuario> GetById(int id);
        public Task<UsuarioLogin> CreateUsuario(UsuarioLogin usuarioLogin);
    }
}
