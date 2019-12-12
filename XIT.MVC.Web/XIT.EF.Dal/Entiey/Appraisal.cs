namespace XIT.EF.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appraisal")]
    public partial class Appraisal
    {
        [Key]
        public int AppID { get; set; }

        public int? StuID { get; set; }

        public int? TeaID { get; set; }

        [Required]
        [StringLength(200)]
        public string AppRemark { get; set; }

        public int AppGrade { get; set; }

        public DateTime? AppTime { get; set; }

        public bool? AppState { get; set; }

        public int? IsDelete { get; set; }

        public virtual StuInfo StuInfo { get; set; }

        public virtual TeacherInfo TeacherInfo { get; set; }
    }
}
