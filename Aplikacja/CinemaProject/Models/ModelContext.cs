using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CinemaProject.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Actoraward> Actorawards { get; set; }
        public virtual DbSet<Archive> Archives { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Directoraward> Directorawards { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Languageversion> Languageversions { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Movieactor> Movieactors { get; set; }
        public virtual DbSet<Moviedirector> Moviedirectors { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Screening> Screenings { get; set; }
        public virtual DbSet<Search> Searches { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=SBD_ST_PS5_1;PASSWORD=SBD_ST_PS5_1;DATA SOURCE=212.33.90.213:1521/xe;PERSIST SECURITY INFO=True", options =>
                options.UseOracleSQLCompatibility("11"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SBD_ST_PS5_1");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("ACTOR");

                entity.Property(e => e.ActorId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACTOR_ID");

                entity.Property(e => e.Birthday)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTHDAY");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(40)
                    .HasColumnName("NATIONALITY");
            });

            modelBuilder.Entity<Actoraward>(entity =>
            {
                entity.HasKey(e => new { e.ActorActorId, e.AwardAwardId })
                    .HasName("ACTORAWARD_PK");

                entity.ToTable("ACTORAWARD");

                entity.Property(e => e.ActorActorId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACTOR_ACTOR_ID");

                entity.Property(e => e.AwardAwardId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AWARD_AWARD_ID");

                entity.Property(e => e.Date).HasColumnType("DATE");

                entity.HasOne(d => d.ActorActor)
                    .WithMany(p => p.Actorawards)
                    .HasForeignKey(d => d.ActorActorId)
                    .HasConstraintName("ACTORAWARD_ACTOR_FK");

                entity.HasOne(d => d.AwardAward)
                    .WithMany(p => p.Actorawards)
                    .HasForeignKey(d => d.AwardAwardId)
                    .HasConstraintName("ACTORAWARD_AWARD_FK");
            });

            modelBuilder.Entity<Archive>(entity =>
            {
                entity.HasKey(e => new { e.UserUserId, e.ScreeningScreeningId })
                    .HasName("ARCHIVE_PK");

                entity.ToTable("ARCHIVE");

                entity.Property(e => e.UserUserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_USER_ID");

                entity.Property(e => e.ScreeningScreeningId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCREENING_SCREENING_ID");

                entity.Property(e => e.Date).HasColumnType("DATE");

                entity.HasOne(d => d.ScreeningScreening)
                    .WithMany(p => p.Archives)
                    .HasForeignKey(d => d.ScreeningScreeningId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ARCHIVE_SCREENING_FK");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Archives)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ARCHIVE_USER_FK");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("ARTICLE");

                entity.Property(e => e.ArticleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ARTICLE_ID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Date).HasColumnType("DATE");

                entity.Property(e => e.WorkerWorkerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WORKER_WORKER_ID");

                entity.HasOne(d => d.WorkerWorker)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.WorkerWorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ARTICLE_WORKER_FK");
            });

            modelBuilder.Entity<Award>(entity =>
            {
                entity.ToTable("AWARD");

                entity.Property(e => e.AwardId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AWARD_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.ToTable("CINEMA");

                entity.Property(e => e.CinemaId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CINEMA_ID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CITY");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("DIRECTOR");

                entity.Property(e => e.DirectorId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DIRECTOR_ID");

                entity.Property(e => e.Birthday)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTHDAY");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(40)
                    .HasColumnName("NATIONALITY");
            });

            modelBuilder.Entity<Directoraward>(entity =>
            {
                entity.HasKey(e => new { e.DirectorDirectorId, e.AwardAwardId })
                    .HasName("DIRECTORAWARD_PK");

                entity.ToTable("DIRECTORAWARD");

                entity.Property(e => e.DirectorDirectorId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DIRECTOR_DIRECTOR_ID");

                entity.Property(e => e.AwardAwardId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AWARD_AWARD_ID");

                entity.Property(e => e.Date).HasColumnType("DATE");

                entity.HasOne(d => d.AwardAward)
                    .WithMany(p => p.Directorawards)
                    .HasForeignKey(d => d.AwardAwardId)
                    .HasConstraintName("DIRECTORAWARD_AWARD_FK");

                entity.HasOne(d => d.DirectorDirector)
                    .WithMany(p => p.Directorawards)
                    .HasForeignKey(d => d.DirectorDirectorId)
                    .HasConstraintName("DIRECTORAWARD_DIRECTOR_FK");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("GENRE");

                entity.Property(e => e.GenreId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GENRE_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Languageversion>(entity =>
            {
                entity.HasKey(e => e.LvId)
                    .HasName("LANGUAGEVERSION_PK");

                entity.ToTable("LANGUAGEVERSION");

                entity.Property(e => e.LvId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LV_ID");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LANGUAGE");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("MOVIE");

                entity.Property(e => e.MovieId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MOVIE_ID");

                entity.Property(e => e.Country)
                    .HasMaxLength(35)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.GenreGenreId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GENRE_GENRE_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Productionyear)
                    .HasColumnType("DATE")
                    .HasColumnName("PRODUCTIONYEAR");

                entity.HasOne(d => d.GenreGenre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreGenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MOVIE_GENRE_FK");
            });

            modelBuilder.Entity<Movieactor>(entity =>
            {
                entity.HasKey(e => new { e.MovieMovieId, e.ActorActorId })
                    .HasName("MOVIEACTOR_PK");

                entity.ToTable("MOVIEACTOR");

                entity.Property(e => e.MovieMovieId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MOVIE_MOVIE_ID");

                entity.Property(e => e.ActorActorId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACTOR_ACTOR_ID");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ROLE");

                entity.HasOne(d => d.ActorActor)
                    .WithMany(p => p.Movieactors)
                    .HasForeignKey(d => d.ActorActorId)
                    .HasConstraintName("MOVIEACTOR_ACTOR_FK");

                entity.HasOne(d => d.MovieMovie)
                    .WithMany(p => p.Movieactors)
                    .HasForeignKey(d => d.MovieMovieId)
                    .HasConstraintName("MOVIEACTOR_MOVIE_FK");
            });

            modelBuilder.Entity<Moviedirector>(entity =>
            {
                entity.HasKey(e => new { e.MovieMovieId, e.DirectorDirectorId })
                    .HasName("MOVIEDIRECTOR_PK");

                entity.ToTable("MOVIEDIRECTOR");

                entity.Property(e => e.MovieMovieId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MOVIE_MOVIE_ID");

                entity.Property(e => e.DirectorDirectorId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DIRECTOR_DIRECTOR_ID");

                entity.HasOne(d => d.DirectorDirector)
                    .WithMany(p => p.Moviedirectors)
                    .HasForeignKey(d => d.DirectorDirectorId)
                    .HasConstraintName("MOVIEDIRECTOR_DIRECTOR_FK");

                entity.HasOne(d => d.MovieMovie)
                    .WithMany(p => p.Moviedirectors)
                    .HasForeignKey(d => d.MovieMovieId)
                    .HasConstraintName("MOVIEDIRECTOR_MOVIE_FK");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("REVIEW");

                entity.Property(e => e.ReviewId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REVIEW_ID");

                entity.Property(e => e.Content)
                    .HasMaxLength(1000)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Creationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATIONDATE");

                entity.Property(e => e.MovieMovieId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MOVIE_MOVIE_ID");

                entity.Property(e => e.Rating)
                    .HasPrecision(2)
                    .HasColumnName("RATING");

                entity.Property(e => e.UserUserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_USER_ID");

                entity.HasOne(d => d.MovieMovie)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MovieMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REVIEW_MOVIE_FK");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REVIEW_USER_FK");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("ROOM");

                entity.Property(e => e.RoomId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROOM_ID");

                entity.Property(e => e.Capacity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CAPACITY");

                entity.Property(e => e.CinemaCinemaId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CINEMA_CINEMA_ID");

                entity.Property(e => e.IsAvalible)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IS_AVALIBLE")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.CinemaCinema)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CinemaCinemaId)
                    .HasConstraintName("ROOM_CINEMA_FK");
            });

            modelBuilder.Entity<Screening>(entity =>
            {
                entity.ToTable("SCREENING");

                entity.Property(e => e.ScreeningId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCREENING_ID");

                entity.Property(e => e.LanguageversionLvId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LANGUAGEVERSION_LV_ID");

                entity.Property(e => e.MovieMovieId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MOVIE_MOVIE_ID");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE");

                entity.Property(e => e.RoomRoomId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROOM_ROOM_ID");

                entity.Property(e => e.ScreeningDate)
                    .HasColumnName("SCREENING_DATE")
                    .HasColumnType("DATE");                 

                entity.HasOne(d => d.LanguageversionLv)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.LanguageversionLvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SCREENING_LANGUAGEVERSION_FK");

                entity.HasOne(d => d.MovieMovie)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.MovieMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SCREENING_MOVIE_FK");

                entity.HasOne(d => d.RoomRoom)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.RoomRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SCREENING_ROOM_FK");
            });

            modelBuilder.Entity<Search>(entity =>
            {
                entity.ToTable("SEARCH");

                entity.Property(e => e.SearchId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEARCH_ID");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("CATEGORY");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.UserUserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_USER_ID");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Searches)
                    .HasForeignKey(d => d.UserUserId)
                    .HasConstraintName("SEARCH_USER_FK");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => new { e.UserUserId, e.ScreeningScreeningId })
                    .HasName("TICKET_PK");

                entity.ToTable("TICKET");

                entity.Property(e => e.UserUserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_USER_ID");

                entity.Property(e => e.ScreeningScreeningId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCREENING_SCREENING_ID");

                entity.Property(e => e.Date).HasColumnType("DATE");

                entity.HasOne(d => d.ScreeningScreening)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ScreeningScreeningId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TICKET_SCREENING_FK");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TICKET_USER_FK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("WORKER");

                entity.Property(e => e.WorkerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WORKER_ID");

                entity.Property(e => e.CinemaCinemaId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CINEMA_CINEMA_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("POSITION");

                entity.Property(e => e.Salary)
                    .HasPrecision(6)
                    .HasColumnName("SALARY");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SURNAME");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");

                entity.HasOne(d => d.CinemaCinema)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.CinemaCinemaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("WORKER_CINEMA_FK");
            });

            modelBuilder.HasSequence("S_PUBLISHER");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
