using System;
using System.Collections.Generic;

namespace Blogs.DataAccess.EntityFramework.Entities;

public partial class Function
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Text { get; set; } = null!;

    public string Link { get; set; } = null!;

    public string Target { get; set; } = null!;

    public int Orderby { get; set; }

    public string? Cssclass { get; set; }

    public bool Islocked { get; set; }

    public bool Isdeleted { get; set; }

    public string? Parentid { get; set; }

    public DateTime Createddate { get; set; }

    public string Createdby { get; set; } = null!;

    public DateTime? Updateddate { get; set; }

    public string? Updatedby { get; set; }

    public string? Slug { get; set; }
}
