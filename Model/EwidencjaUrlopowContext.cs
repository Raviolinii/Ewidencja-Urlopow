using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EwidencjaUrlopow.Model
{
    public partial class EwidencjaUrlopowContext : DbContext
    {
        public EwidencjaUrlopowContext()
        {
        }

        public EwidencjaUrlopowContext(DbContextOptions<EwidencjaUrlopowContext> options)
            : base(options)
        {
        }

        private string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EwidencjaUrlopow;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public virtual DbSet<Kalendarz> Kalendarzs { get; set; }
        public virtual DbSet<Pracownik> Pracowniks { get; set; }
        public virtual DbSet<Urlop> Urlops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(conString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Kalendarz>(entity =>
            {
                entity.HasKey(e => e.DzienRoku)
                    .HasName("PK__Kalendar__718031A3610E3D11");

                entity.ToTable("Kalendarz");

                entity.Property(e => e.DzienRoku).HasColumnType("date");
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownika)
                    .HasName("PK__Pracowni__7BF2E880C63E099C");

                entity.ToTable("Pracownik");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StanowiskoPracy)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Urlop>(entity =>
            {
                entity.HasKey(e => e.IdUrlopu)
                    .HasName("PK__Urlop__3FEB4D1D0DC9F0BB");

                entity.ToTable("Urlop");

                entity.Property(e => e.DataRozpoczeciaUrlopu).HasColumnType("date");

                entity.Property(e => e.DataZakonczeniaUrlopu).HasColumnType("date");

                entity.Property(e => e.OpisUrlopu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPracownikaNavigation)
                    .WithMany(p => p.Urlops)
                    .HasForeignKey(d => d.IdPracownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pracownik");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public void EditWorker(Pracownik toSave)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Pracownik " +
                    "SET Imie = @Imie, Nazwisko = @Nazwisko, StanowiskoPracy = @Stanowisko, " +
                    "LataPracy = @LataPracy, DostepnyUrlop = @DostepnyUrlop " +
                    "WHERE IdPracownika = @id"
                    );
                command.Parameters.AddWithValue("Imie", toSave.Imie);
                command.Parameters.AddWithValue("Nazwisko", toSave.Nazwisko);
                command.Parameters.AddWithValue("Stanowisko", toSave.StanowiskoPracy);
                command.Parameters.AddWithValue("LataPracy", toSave.LataPracy);
                command.Parameters.AddWithValue("DostepnyUrlop", toSave.DostepnyUrlop);
                command.Parameters.AddWithValue("id", toSave.IdPracownika);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public void DeleteWorker(Pracownik toDelete)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE Pracownik " +
                    "WHERE IdPracownika = @id"
                    );

                command.Parameters.AddWithValue("id", toDelete.IdPracownika);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public void AddLeave(int days, DateTime beginDate, DateTime endDate, string descryption, int workerId)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Urlop " +
                    "VALUES (@days, @beginDate, @endDate, @descr, @workerId)"
                    );
                command.Parameters.AddWithValue("days", days);
                command.Parameters.AddWithValue("beginDate", beginDate);
                command.Parameters.AddWithValue("endDate", endDate);
                command.Parameters.AddWithValue("descr", descryption);
                command.Parameters.AddWithValue("workerId", workerId);
                command.Connection = connection;
                command.ExecuteNonQuery();

                DecreseLeaveDays(days, workerId);
            }
        }

        public void SaveLeave(Urlop toSave)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                var getDaysCommand = new SqlCommand(
                    "SELECT DniUrlopu " +
                    "FROM Urlop " +
                    "WHERE IdUrlopu = @id"
                    );
                getDaysCommand.Parameters.AddWithValue("id", toSave.IdUrlopu);
                getDaysCommand.Connection = connection;
                int oldDays = (int)getDaysCommand.ExecuteScalar();

                var command = new SqlCommand(
                    "UPDATE Urlop " +
                    "SET DniUrlopu = @days, DataRozpoczeciaUrlopu = @beginDate, DataZakonczeniaUrlopu = @endDate, OpisUrlopu = @descr, IdPracownika = @workerId " +
                    "WHERE IdUrlopu = @idUrlopu"
                    );
                command.Parameters.AddWithValue("days", toSave.DniUrlopu);
                command.Parameters.AddWithValue("beginDate", toSave.DataRozpoczeciaUrlopu);
                command.Parameters.AddWithValue("endDate", toSave.DataZakonczeniaUrlopu);
                command.Parameters.AddWithValue("descr", toSave.OpisUrlopu);
                command.Parameters.AddWithValue("workerId", toSave.IdPracownika);
                command.Parameters.AddWithValue("idUrlopu", toSave.IdUrlopu);
                command.Connection = connection;
                command.ExecuteNonQuery();

                IncreseLeaveDays(oldDays, toSave.IdPracownika);
                DecreseLeaveDays((int)toSave.DniUrlopu, toSave.IdPracownika);
            }
        }

        public void DeleteLeave(Urlop toDelete)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE Urlop " +
                    "WHERE IdUrlopu = @idUrlopu"
                    );
                command.Parameters.AddWithValue("idUrlopu", toDelete.IdUrlopu);
                command.Connection = connection;
                command.ExecuteNonQuery();

                IncreseLeaveDays((int)toDelete.DniUrlopu, toDelete.IdPracownika);
            }
        }

        public void DecreseLeaveDays(int count, int workerId)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Pracownik " +
                    "SET DostepnyUrlop -= @days " +
                    "WHERE IdPracownika = @id "
                    );
                command.Parameters.AddWithValue("days", count);
                command.Parameters.AddWithValue("id", workerId);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public void IncreseLeaveDays(int count, int workerId)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Pracownik " +
                    "SET DostepnyUrlop += @days " +
                    "WHERE IdPracownika = @id "
                    );
                command.Parameters.AddWithValue("days", count);
                command.Parameters.AddWithValue("id", workerId);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public void MakeDayFree(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Kalendarz " +
                    "SET DzienWolny = 1 " +
                    "WHERE DzienRoku = @date "
                    );
                command.Parameters.AddWithValue("date", date);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public void CancelDayFree(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE Kalendarz " +
                    "SET DzienWolny = 0 " +
                    "WHERE DzienRoku = @date "
                    );
                command.Parameters.AddWithValue("date", date);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
    }
}
