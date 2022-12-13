using Microsoft.EntityFrameworkCore;

namespace Blogs.DataAccess.EntityFramework
{
    public class BlogsDbContextFactory : IDbContextFactory<BlogsDbContext>
    {
        private readonly IDbContextFactory<BlogsDbContext> _pooledFactory;

        public BlogsDbContextFactory(IDbContextFactory<BlogsDbContext> pooledFactory)
        {
            _pooledFactory = pooledFactory;
        }

        public BlogsDbContext CreateDbContext()
        {
            return _pooledFactory.CreateDbContext();
        }
    }
}
