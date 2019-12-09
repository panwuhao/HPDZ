namespace XIT.EF.Dal
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class XITDataModel1 : DbContext
    {
        public XITDataModel1()
            : base("name=XITDataModel1")
        {
            Configuration.ProxyCreationEnabled =false;
        }

        public virtual DbSet<Appraisal> Appraisal { get; set; }
        public virtual DbSet<ClassInfo> ClassInfo { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Finance> Finance { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<StuInfo> StuInfo { get; set; }
        public virtual DbSet<StuLeave> StuLeave { get; set; }
        public virtual DbSet<StuScore> StuScore { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<TeacherInfo> TeacherInfo { get; set; }
        public virtual DbSet<TeLeave> TeLeave { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appraisal>()
                .Property(e => e.AppRemark)
                .IsUnicode(false);

            modelBuilder.Entity<ClassInfo>()
                .Property(e => e.ClaName)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CouName)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CouTime)
                .IsUnicode(false);

            modelBuilder.Entity<Finance>()
                .Property(e => e.FinType)
                .IsUnicode(false);

            modelBuilder.Entity<LoginInfo>()
                .Property(e => e.LogNum)
                .IsUnicode(false);

            modelBuilder.Entity<LoginInfo>()
                .Property(e => e.LogPwd)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.roleName)
                .IsUnicode(false);

            modelBuilder.Entity<Semester>()
                .Property(e => e.StrName)
                .IsUnicode(false);

            modelBuilder.Entity<StuInfo>()
                .Property(e => e.StuSex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StuInfo>()
                .Property(e => e.StuPost)
                .IsUnicode(false);

            modelBuilder.Entity<StuInfo>()
                .Property(e => e.StuAdmintime)
                .IsUnicode(false);

            modelBuilder.Entity<StuInfo>()
                .Property(e => e.StuGradtime)
                .IsUnicode(false);

            modelBuilder.Entity<StuLeave>()
                .Property(e => e.LeaCause)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.SubName)
                .IsUnicode(false);

            modelBuilder.Entity<TeacherInfo>()
                .Property(e => e.TeaSex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TeLeave>()
                .Property(e => e.LeaCause)
                .IsUnicode(false);
        }
    }
}
