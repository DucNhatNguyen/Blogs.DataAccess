using System;
using System.Collections.Generic;

namespace Blogs.DataAccess.EntityFramework.Entities;

public partial class Author
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Avatar { get; set; }

    public string? Intro { get; set; }

    public string? Youtube { get; set; }

    public string? Facebook { get; set; }

    public virtual ICollection<Blog> Blogs { get; } = new List<Blog>();
}
