

namespace Blogs.DataAccess.Core.Entities
{
    public interface ISoftDeletedFields
    {
        public bool IsDeleted { get; set; }
    }
}
