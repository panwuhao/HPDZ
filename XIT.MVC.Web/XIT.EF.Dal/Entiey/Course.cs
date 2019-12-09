namespace XIT.EF.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [Key]
        public int CouID { get; set; }

        [Required]
        [StringLength(50)]
        public string CouName { get; set; }

        [Required]
        [StringLength(20)]
        public string CouTime { get; set; }

        public int? ClaID { get; set; }

        public int? IsDelete { get; set; }

        public virtual ClassInfo ClassInfo { get; set; }
    }
}
