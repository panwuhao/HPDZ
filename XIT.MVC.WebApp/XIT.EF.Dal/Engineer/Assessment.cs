namespace XIT.EF.Dal.Engineer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Assessment")]
    public partial class Assessment
    {
        public int? AssEngID { get; set; }

        [Key]
        [StringLength(100)]
        public string AssName { get; set; }

        public virtual Engineer Engineer { get; set; }
    }
}
