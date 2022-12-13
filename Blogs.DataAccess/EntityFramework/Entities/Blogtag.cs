using System;
using System.Collections.Generic;

namespace Blogs.DataAccess.EntityFramework.Entities;

public partial class Blogtag
{
    public int Blogid { get; set; }

    public int Tagid { get; set; }

    public DateTime Createddate { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
