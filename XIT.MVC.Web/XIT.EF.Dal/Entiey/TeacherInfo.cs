namespace XIT.EF.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeacherInfo")]
    public partial class TeacherInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TeacherInfo()
        {
            Appraisal = new HashSet<Appraisal>();
            TeLeave = new HashSet<TeLeave>();
        }

        [Key]
        public int TeaID { get; set; }

        [StringLength(2)]
        public string TeaSex { get; set; }

        public int TeaAge { get; set; }

        public int? ClaID { get; set; }

        public int? LogID { get; set; }

        public int? SubID { get; set; }

        public int? IsDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appraisal> Appraisal { get; set; }

        public virtual ClassInfo ClassInfo { get; set; }

        public virtual LoginInfo LoginInfo { get; set; }

        public virtual Subject Subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeLeave> TeLeave { get; set; }
    }
}
