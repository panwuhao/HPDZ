namespace XIT.EF.Dal.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ComCity> ComCity { get; set; }
        public virtual DbSet<ComFx> ComFx { get; set; }
        public virtual DbSet<comGw> comGw { get; set; }
        public virtual DbSet<comGww> comGww { get; set; }
        public virtual DbSet<ComLy> ComLy { get; set; }
        public virtual DbSet<qiye> qiye { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComCity>()
                .Property(e => e.Cityname)
                .IsUnicode(false);

            modelBuilder.Entity<ComCity>()
                .HasMany(e => e.qiye)
                .WithRequired(e => e.ComCity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ComFx>()
                .Property(e => e.ComFxname)
                .IsUnicode(false);

            modelBuilder.Entity<ComFx>()
                .HasMany(e => e.comGw)
                .WithRequired(e => e.ComFx)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<comGw>()
                .Property(e => e.GwName)
                .IsUnicode(false);

            modelBuilder.Entity<comGw>()
                .Property(e => e.jieshao)
                .IsUnicode(false);

            modelBuilder.Entity<comGw>()
                .HasMany(e => e.comGww)
                .WithRequired(e => e.comGw)
                .HasForeignKey(e => e.GwwName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ComLy>()
                .Property(e => e.ComLyname)
                .IsUnicode(false);

            modelBuilder.Entity<ComLy>()
                .HasMany(e => e.comGw)
                .WithRequired(e => e.ComLy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<qiye>()
                .Property(e => e.qName)
                .IsUnicode(false);

            modelBuilder.Entity<qiye>()
                .Property(e => e.qHe)
                .IsUnicode(false);

            modelBuilder.Entity<qiye>()
                .Property(e => e.jieshao)
                .IsUnicode(false);
        }
    }
}
