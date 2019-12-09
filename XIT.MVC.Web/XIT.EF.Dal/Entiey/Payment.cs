namespace XIT.EF.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        public int PayID { get; set; }

        public int? StuID { get; set; }

        public int Payable { get; set; }

        public DateTime? PayTime { get; set; }

        public int? PayPaidin { get; set; }

        public int? PayArrearage { get; set; }

        public int? IsDelete { get; set; }

        public virtual StuInfo StuInfo { get; set; }
    }
}
