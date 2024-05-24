using APIweb.Data;
using APIweb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Fixtures
{
    public class DataBaseFixture
    {
        public static object _lock = new object();
        private static bool _databaseInitialize;
        private const string _connectionString = @"server=localhost;"" +
                ""Port=5432; Database=TabelaDeProdutos;"" +
                ""User Id=postgres;"" +
                ""Password=1234";
      //  public AppDbContext CreateContext()
      //  {
          //  return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseNpgsql(_connectionString).Options);
      //  }

        
    }
}
