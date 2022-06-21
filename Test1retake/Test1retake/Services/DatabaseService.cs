using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1retake.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _configuration;
        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration.GetConnectionString("PjatkDbConnection");
        }
    }
}
