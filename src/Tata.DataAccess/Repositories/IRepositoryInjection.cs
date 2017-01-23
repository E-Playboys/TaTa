using Microsoft.EntityFrameworkCore;

namespace TaTa.DataAccess.Repositories
{
    public interface IRepositoryInjection
    {
        IRepositoryInjection SetContext(DbContext context);
    }
}