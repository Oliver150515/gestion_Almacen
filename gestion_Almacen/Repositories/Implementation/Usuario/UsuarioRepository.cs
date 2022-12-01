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

        public async Task<Models.UsuarioLogin> CreateUsuario(Models.UsuarioLogin usuarioLogin)
        {
            string sql_maxIdAudit = "execute usp_audit_SelectMaxId";
            string sql_maxIdUsuario = "execute usp_Usuario_SelectMaxId";
            string sql_insertAudit = "EXECUTE usp_Audit_Insert @ID, @FechaCreacion,@FechaModificacion,@Usuario,Null,@Inactivo";
            string sql_insertUsuario = "EXECUTE usp_Usuario_Insert @ID, @NombreCompleto,@NombreUsuario,@Clave,@Audit";
            
            using (var conn = _context.CreateConnection())
            {
                int maxIdAudit = await conn.QueryFirstAsync<int>(sql_maxIdAudit);
                int maxIdUsuario = await conn.QueryFirstAsync<int>(sql_maxIdUsuario);

                // valores Audit
                var values_Audit = new
                {
                    ID = maxIdAudit,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = "",
                    Usuario = 1,                 
                    Inactivo = false
                };

                // insertando en Audit
                var insertAudit = await conn.ExecuteAsync(sql_insertAudit, values_Audit);

                // valores Usuario
                var values_User = new
                {
                    ID = maxIdUsuario,
                    NombreCompleto = usuarioLogin.NombreCompleto,
                    NombreUsuario = usuarioLogin.NombreUsuario,
                    Clave = usuarioLogin.Clave,
                    Audit = maxIdAudit
                };

                // insertando en Usuario
                var insertUsuario = await conn.ExecuteAsync(sql_insertUsuario, values_User);

                // seleccionando el usuario para retornarlo
                Models.UsuarioLogin usuarioCreate = new UsuarioLogin { NombreCompleto = usuarioLogin.NombreCompleto, NombreUsuario = usuarioLogin.NombreUsuario};

                return usuarioCreate;
            }
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

        public async Task<Models.Usuario> GetById(int id)
        {
            var query = "SELECT * FROM USUARIO WHERE ID = @id";

            using (var conn = _context.CreateConnection())
            {
                var usuario = await conn.QuerySingleOrDefaultAsync<Models.Usuario>(query, new { id});
                return usuario;
            }
        }
    }
}
