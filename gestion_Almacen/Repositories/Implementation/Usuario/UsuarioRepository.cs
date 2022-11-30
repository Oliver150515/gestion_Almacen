using Dapper;
using gestion_Almacen.Context;
using gestion_Almacen.Repositories.Interfaces.Usuarios;
using gestion_Almacen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace gestion_Almacen.Repositories.Implementation.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContext _context;

        public UsuarioRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Usuario>> GetAll()
        {
            var query = "SELECT * FROM USUARIO";

            using (var conn = _context.CreateConnection())
            {
                var usuarios = await conn.QueryAsync<Models.Usuario>(query);
                return usuarios;
            }
        }
    }
}
