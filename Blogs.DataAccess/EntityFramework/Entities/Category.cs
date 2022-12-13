using System;
using System.Collections.Generic;

namespace Blogs.DataAccess.EntityFramework.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Status { get; set; }

    public DateTime? Createddate { get; set; }

    public string? Createdby { get; set; }

    public int? Parentid { get; set; }

    public bool? Isparentcate { get; set; }

    public virtual ICollection<Blog> Blogs { get; } = new List<Blog>();
}
