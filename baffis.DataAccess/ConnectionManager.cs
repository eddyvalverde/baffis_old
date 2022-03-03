using baffis.DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baffis.DataAccess
{
    public class ConnectionManager : IConnectionManager
    {
        public const string Prueba_Key = "DefaultConnection";
        private readonly IConfiguration configuration;

        public ConnectionManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IDbConnection CreateConnection(string keyName)
        {
            var connstring = ConfigurationExtensions.GetConnectionString(configuration, $"{keyName}");
            return new NpgsqlConnection(connstring);
        }
    }
}
