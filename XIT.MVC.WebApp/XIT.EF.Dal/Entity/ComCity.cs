namespace XIT.EF.Dal.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComCity")]
    public partial class ComCity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComCity()
        {
            qiye = new HashSet<qiye>();
        }

        [Key]
        public int ComID { get; set; }

        [Required]
        [StringLength(20)]
        public string Cityname { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<qiye> qiye { get; set; }
    }
}
