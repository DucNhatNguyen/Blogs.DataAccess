using Blogs.DataAccess.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogs.DataAccess.EntityFramework;

public partial class BlogsDbContext : DbContext
{
    //public BlogsDbContext()
    //{
    //}

    public BlogsDbContext(DbContextOptions<BlogsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Blogtag> Blogtags { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Function> Functions { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-dawn-moon-817013.us-east-2.aws.neon.tech;Database=neondb;Username=nguyw461;Password=dFTMSj4oV7yx");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_author");

            entity.ToTable("author");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(100)
                .HasColumnName("avatar");
            entity.Property(e => e.Facebook)
                .HasMaxLength(50)
                .HasColumnName("facebook");
            entity.Property(e => e.Intro)
                .HasMaxLength(200)
                .HasColumnName("intro");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Youtube)
                .HasMaxLength(50)
                .HasColumnName("youtube");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_blog");

            entity.ToTable("blogs");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.Cateid).HasColumnName("cateid");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Filegoogledriveid)
                .HasMaxLength(100)
                .HasColumnName("filegoogledriveid");
            entity.Property(e => e.Ishotblog).HasColumnName("ishotblog");
            entity.Property(e => e.Publicdate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("publicdate");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("slug");
            entity.Property(e => e.Sortdesc)
                .HasMaxLength(200)
                .HasColumnName("sortdesc");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(100)
                .HasColumnName("thumbnail");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.View).HasColumnName("view");

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.Author)
                .HasConstraintName("fk_blog_author");

            entity.HasOne(d => d.Cate).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.Cateid)
                .HasConstraintName("fk_blog_category");
        });

        modelBuilder.Entity<Blogtag>(entity =>
        {
            entity.HasKey(e => new { e.Blogid, e.Tagid }).HasName("pk_blogtag");

            entity.ToTable("blogtag");

            entity.Property(e => e.Blogid).HasColumnName("blogid");
            entity.Property(e => e.Tagid).HasColumnName("tagid");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createddate");

            entity.HasOne(d => d.Blog).WithMany(p => p.Blogtags)
                .HasForeignKey(d => d.Blogid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_blogtag_blog");

            entity.HasOne(d => d.Tag).WithMany(p => p.Blogtags)
                .HasForeignKey(d => d.Tagid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_blogtag_tag");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_category");

            entity.ToTable("category");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isparentcate).HasColumnName("isparentcate");
            entity.Property(e => e.Parentid).HasColumnName("parentid");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_comment");

            entity.ToTable("comment");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Blogid).HasColumnName("blogid");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Receiverid).HasColumnName("receiverid");
            entity.Property(e => e.Rootcommentid).HasColumnName("rootcommentid");
            entity.Property(e => e.Senderid).HasColumnName("senderid");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Function>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_functions");

            entity.ToTable("functions");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(20)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Cssclass)
                .HasMaxLength(50)
                .HasColumnName("cssclass");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Islocked).HasColumnName("islocked");
            entity.Property(e => e.Link)
                .HasMaxLength(250)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Orderby).HasColumnName("orderby");
            entity.Property(e => e.Parentid)
                .HasMaxLength(50)
                .HasColumnName("parentid");
            entity.Property(e => e.Slug)
                .HasMaxLength(256)
                .HasColumnName("slug");
            entity.Property(e => e.Target)
                .HasMaxLength(10)
                .HasColumnName("target");
            entity.Property(e => e.Text)
                .HasMaxLength(250)
                .HasColumnName("text");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(20)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tag");

            entity.ToTable("tag");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Slug)
                .HasMaxLength(256)
                .HasColumnName("slug");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
