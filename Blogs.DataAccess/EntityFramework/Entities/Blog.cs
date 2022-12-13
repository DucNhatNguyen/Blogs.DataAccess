using System;
using System.Collections.Generic;

namespace Blogs.DataAccess.EntityFramework.Entities;

public partial class Blog
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int Status { get; set; }

    public string? Sortdesc { get; set; }

    public string? Content { get; set; }

    public DateTime? Publicdate { get; set; }

    public int? View { get; set; }

    public int? Author { get; set; }

    public string? Thumbnail { get; set; }

    public bool? Ishotblog { get; set; }

    public string? Slug { get; set; }

    public int? Cateid { get; set; }

    public string? Filegoogledriveid { get; set; }

    public virtual Author? AuthorNavigation { get; set; }

    public virtual ICollection<Blogtag> Blogtags { get; } = new List<Blogtag>();

    public virtual Category? Cate { get; set; }
}
