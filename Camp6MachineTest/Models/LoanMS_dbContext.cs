using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Camp6MachineTest.Models
{
    public partial class LoanMS_dbContext : DbContext
    {
        public LoanMS_dbContext()
        {
        }

        public LoanMS_dbContext(DbContextOptions<LoanMS_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerTbl> CustomerTbl { get; set; }
        public virtual DbSet<LoanDetailsTbl> LoanDetailsTbl { get; set; }
        public virtual DbSet<LoginTbl> LoginTbl { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=OLIVER\\SQLEXPRESS; Initial Catalog=LoanMS_db; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerTbl>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__customer__213EE77442ABBC4A");

                entity.ToTable("customer_tbl");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId)
                    .HasColumnName("l_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Occupation)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.L)
                    .WithMany(p => p.CustomerTbl)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__customer_t__l_id__38996AB5");
            });

            modelBuilder.Entity<LoanDetailsTbl>(entity =>
            {
                entity.HasKey(e => e.LoanId)
                    .HasName("PK__LoanDeta__A1F79554C713A9D7");

                entity.ToTable("LoanDetails_tbl");

                entity.Property(e => e.LoanId).HasColumnName("loan_id");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnName("accountNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasColumnName("branch")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.InterestRate)
                    .HasColumnName("interestRate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IssueDate)
                    .HasColumnName("issueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoanAmount)
                    .IsRequired()
                    .HasColumnName("loanAmount")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LoanType)
                    .IsRequired()
                    .HasColumnName("loanType")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RequestedDate)
                    .HasColumnName("requestedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.LoanDetailsTbl)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK__LoanDetail__c_id__3B75D760");
            });

            modelBuilder.Entity<LoginTbl>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login_tb__4208A4A611A71556");

                entity.ToTable("Login_tbl");

                entity.Property(e => e.LId)
                    .HasColumnName("L_id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
