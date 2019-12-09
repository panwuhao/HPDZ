namespace XIT.EF.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeLeave")]
    public partial class TeLeave
    {
        [Key]
        public int LeaID { get; set; }

        public int? TeaID { get; set; }

        public DateTime? LeaBegintime { get; set; }

        public DateTime? LeaEndtime { get; set; }

        [Required]
        [StringLength(100)]
        public string LeaCause { get; set; }

        public bool? LeaState { get; set; }

        public int? IsDelete { get; set; }

        public virtual TeacherInfo TeacherInfo { get; set; }
    }
}
