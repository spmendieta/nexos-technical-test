using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BooksAPIRest.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost\\sqlexpress; user=dev; password=gU52#v$XzFcP%:f9; database=books_store;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.HasComment("Información de los autores vinculados a los libros dentro del sistema");

                entity.HasIndex(e => e.AuthorEmail, "author_authorEmail_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.AuthorId, "author_authorId_uindex")
                    .IsUnique();

                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.AuthorEmail)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("authorEmail");

                entity.Property(e => e.AuthorFirstLastName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("authorFirstLastName");

                entity.Property(e => e.AuthorFirstName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("authorFirstName");

                entity.Property(e => e.AuthorSecondLastName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("authorSecondLastName");

                entity.Property(e => e.AuthorSecondName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("authorSecondName");

                entity.Property(e => e.BornDate)
                    .HasColumnType("date")
                    .HasColumnName("bornDate");

                entity.Property(e => e.OriginCity).HasColumnName("originCity");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.HasComment("Tabla para el almacenamiento de la información relacionada a los libros");

                entity.HasIndex(e => e.BookId, "book_bookId_uindex")
                    .IsUnique();

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.EditorialId).HasColumnName("editorialId");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genreId")
                    .HasComment("Genero");

                entity.Property(e => e.NumberOfPages).HasColumnName("numberOfPages");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Year)
                    .HasColumnType("date")
                    .HasColumnName("year");

                entity.HasOne(d => d.Editorial)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.EditorialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__book__editorial");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__book__genre");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasComment("Ciudades disponibles para crear registros ligados a ubicación");

                entity.HasIndex(e => e.CityId, "city_cityId_uindex")
                    .IsUnique();

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("cityName");

                entity.Property(e => e.ProvinceId).HasColumnName("provinceId");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__city__province");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.HasComment("Paises disponibles para crear registros ligados a ubicación");

                entity.HasIndex(e => e.CountryId, "country_countryId_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.CountryName, "country_countryName_uindex")
                    .IsUnique();

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("countryName");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.ToTable("editorial");

                entity.HasComment("Tabla para el almacenamiento de la información relacionada a las editoriales");

                entity.HasIndex(e => e.EditorialId, "editorial_editorialId_uindex")
                    .IsUnique();

                entity.Property(e => e.EditorialId).HasColumnName("editorialId");

                entity.Property(e => e.BookRegistrationLimit)
                    .HasColumnName("bookRegistrationLimit")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.CityId)
                    .HasColumnName("cityId")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CorrespondanceAdress)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("correspondanceAdress");

                entity.Property(e => e.EditorialName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("editorialName");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Editorials)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__editorial__city");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.HasComment("Tabla para el almacenamiento de la información relacionada a los generos que puede tener un libro");

                entity.HasIndex(e => e.GenreId, "genre_genreId_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.GenreName, "genre_genreName_uindex")
                    .IsUnique();

                entity.Property(e => e.GenreId).HasColumnName("genreId");

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("genreName");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("province");

                entity.HasComment("Provincias o departamentos geográficos disponibles para crear registros ligados a ubicación");

                entity.HasIndex(e => e.ProvinceId, "province_provinceId_uindex")
                    .IsUnique();

                entity.Property(e => e.ProvinceId).HasColumnName("provinceId");

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("provinceName");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk___province__country");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
