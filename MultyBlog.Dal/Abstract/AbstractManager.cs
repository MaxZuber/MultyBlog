using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyBlog.Dal.Abstract
{
    public abstract class AbstractManager
    {
        private readonly string _connectionString;
        protected AbstractManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected DbContext CreateDbContext()
        {
            return new DbContext(_connectionString);
        }
    }
}
