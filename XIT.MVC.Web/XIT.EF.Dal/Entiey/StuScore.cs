namespace XIT.EF.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StuScore")]
    public partial class StuScore
    {
        [Key]
        public int stuSID { get; set; }

        public int? StuID { get; set; }

        public double? Score { get; set; }

        public int? SubID { get; set; }

        public int? StrID { get; set; }

        public int? IsDelete { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual StuInfo StuInfo { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
