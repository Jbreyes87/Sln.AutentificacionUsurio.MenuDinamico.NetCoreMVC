using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Emsoir.Transversal.Common;
using System.Data;

namespace Emsoir.Infraestructura.Data
{
    public class ConectionFactory: IConectionFactory
    {
        private readonly IConfiguration _configuration;
        public ConectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

            public SqlConnection GetConection { get
            {
                var sqlConection = new SqlConnection();
                if (sqlConection == null) return null;

                sqlConection.ConnectionString = _configuration.GetConnectionString("Cadena");
                sqlConection.Open();
                return sqlConection;
            } }



    }
}
