using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaTa.DataAccess.Entities;

namespace TaTa.DataAccess.Context
{
    public class EntityContextBase<TContext> : IdentityDbContext<User>, IEntityContext where TContext : DbContext
    {
        public EntityContextBase(DbContextOptions<TContext> options) : base(options)
        {
        }
    }
}
