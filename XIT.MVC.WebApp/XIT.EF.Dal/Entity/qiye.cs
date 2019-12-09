namespace XIT.EF.Dal.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qiye")]
    public partial class qiye
    {
        [Key]
        public int qID { get; set; }

        [Required]
        [StringLength(50)]
        public string qName { get; set; }

        [Required]
        [StringLength(50)]
        public string qHe { get; set; }

        [Required]
        [StringLength(200)]
        public string jieshao { get; set; }

        public int ComID { get; set; }

        public virtual ComCity ComCity { get; set; }
    }
}
