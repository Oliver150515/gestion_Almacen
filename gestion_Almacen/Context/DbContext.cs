using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_Almacen.Context
{
    public class DbContext
    {
        private readonly IConfiguration _iconfiguration;
        private readonly string _connectionString;

        public DbContext(IConfiguration configuration)
        {
            _iconfiguration = configuration;
            _connectionString = _iconfiguration.GetConnectionString("DbLocalCon");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);


    }
}
