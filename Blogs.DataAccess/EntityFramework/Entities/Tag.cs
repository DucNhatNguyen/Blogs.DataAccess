using System;
using System.Collections.Generic;

namespace Blogs.DataAccess.EntityFramework.Entities;

public partial class Tag
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public virtual ICollection<Blogtag> Blogtags { get; } = new List<Blogtag>();
}
