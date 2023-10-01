using System;
using System.Data;
using Npgsql;

namespace NetDapperExample.Context
{
	public class DapperContext
	{
		private readonly string _connectionString;
		private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("dev");
        }
        
        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}