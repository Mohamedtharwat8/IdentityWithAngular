using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
      public   DbSet<User> Users { get; set; }
    }
}
