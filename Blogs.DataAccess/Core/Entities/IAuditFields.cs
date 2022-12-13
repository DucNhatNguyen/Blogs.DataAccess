
namespace Blogs.DataAccess.Core.Entities
{
    public interface IAuditFields
    {
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
