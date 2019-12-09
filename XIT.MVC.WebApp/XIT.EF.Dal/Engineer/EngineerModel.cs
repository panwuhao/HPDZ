namespace XIT.EF.Dal.Engineer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EngineerModel : DbContext
    {
        public EngineerModel()
            : base("name=EngineerModel")
        {
        }

        public virtual DbSet<Engineer> Engineer { get; set; }
        public virtual DbSet<Assessment> Assessment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Engineer>()
                .Property(e => e.EngName)
                .IsUnicode(false);

            modelBuilder.Entity<Engineer>()
                .HasMany(e => e.Assessment)
                .WithOptional(e => e.Engineer)
                .HasForeignKey(e => e.AssEngID);

            modelBuilder.Entity<Assessment>()
                .Property(e => e.AssName)
                .IsUnicode(false);
        }
    }
}
