namespace Owl.Dal
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DalModel1 : DbContext
    {
        public DalModel1()
            : base("name=DalModel1")
        {
        }

        public virtual DbSet<FlightInfo> FlightInfo { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<ListInfo> ListInfo { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightInfo>()
                .Property(e => e.FlightLoad)
                .IsUnicode(false);

            modelBuilder.Entity<FlightInfo>()
                .Property(e => e.FlightTime)
                .IsUnicode(false);

            modelBuilder.Entity<FlightInfo>()
                .Property(e => e.CabinType)
                .IsUnicode(false);

            modelBuilder.Entity<FlightInfo>()
                .Property(e => e.TicketPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FlightInfo>()
                .Property(e => e.DelayCause)
                .IsUnicode(false);

            modelBuilder.Entity<FlightInfo>()
                .Property(e => e.PlaneType)
                .IsUnicode(false);

            modelBuilder.Entity<Grade>()
                .Property(e => e.GradeTypes)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.IDCard)
                .IsUnicode(false);
        }
    }
}
