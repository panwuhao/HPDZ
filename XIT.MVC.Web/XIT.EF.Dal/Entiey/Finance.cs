namespace XIT.EF.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Finance")]
    public partial class Finance
    {
        [Key]
        public int FinID { get; set; }

        [StringLength(100)]
        public string FinType { get; set; }

        public DateTime? FinTime { get; set; }

        public int FinLimit { get; set; }

        public int? IsDelete { get; set; }
    }
}
