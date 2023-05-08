using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApiContext : DbContext
    {
        #region Ctor

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        #endregion

        public DbSet<User> Users { get; set; }

    }
}
