using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Ado.Net.Web.Data
{
    public class DbAccessor : IDbAccessor
    {
        public DbAccessor()
        {
            this.OnConfiguring();
        }
        public string ConnectionString { get; private set; }

        public async Task<SqlConnection> Open()
        {
            var connection = new SqlConnection(this.ConnectionString);

            await connection.OpenAsync();

            return connection;
        }

        private void OnConfiguring()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            this.ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
