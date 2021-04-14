using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookStoreAPI
{
    public partial class Data : DbContext
    {
        public Data()
        {
        }

        public Data(DbContextOptions<Data> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WKWIN7019901;Database=BookStoreDb;Integrated Security=SSPI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Bio)
                    .HasColumnType("ntext")
                    .HasColumnName("bio");

                entity.Property(e => e.Creationdate)
                    .HasColumnType("datetime")
                    .HasColumnName("creationdate");

                entity.Property(e => e.Creationname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("creationname");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Revisiondate)
                    .HasColumnType("datetime")
                    .HasColumnName("revisiondate");

                entity.Property(e => e.Revisionname)
                    .HasMaxLength(256)
                    .HasColumnName("revisionname");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.Bookid).HasColumnName("bookid");

                entity.Property(e => e.Authorid).HasColumnName("authorid");

                entity.Property(e => e.Creationdate)
                    .HasColumnType("datetime")
                    .HasColumnName("creationdate");

                entity.Property(e => e.Creationname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("creationname");

                entity.Property(e => e.Description)
                    .HasColumnType("ntext")
                    .HasColumnName("description");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Revisiondate)
                    .HasColumnType("datetime")
                    .HasColumnName("revisiondate");

                entity.Property(e => e.Revisionname)
                    .HasMaxLength(256)
                    .HasColumnName("revisionname");

                entity.Property(e => e.Title)
                    .HasMaxLength(256)
                    .HasColumnName("title");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Authorid)
                    .HasConstraintName("FK_books_authors");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
