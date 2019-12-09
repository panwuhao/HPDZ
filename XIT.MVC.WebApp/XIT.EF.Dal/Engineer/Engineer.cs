namespace XIT.EF.Dal.Engineer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Engineer")]
    public partial class Engineer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Engineer()
        {
            Assessment = new HashSet<Assessment>();
        }

        [Key]
        public int EngID { get; set; }

        [Required]
        [StringLength(100)]
        public string EngName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assessment> Assessment { get; set; }
    }
}
