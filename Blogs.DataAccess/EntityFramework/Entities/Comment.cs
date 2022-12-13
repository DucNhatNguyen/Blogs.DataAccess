using System;
using System.Collections.Generic;

namespace Blogs.DataAccess.EntityFramework.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public int? Rootcommentid { get; set; }

    public int? Blogid { get; set; }

    public string? Content { get; set; }

    public int? Status { get; set; }

    public int? Senderid { get; set; }

    public int? Receiverid { get; set; }

    public DateTime? Createddate { get; set; }
}
