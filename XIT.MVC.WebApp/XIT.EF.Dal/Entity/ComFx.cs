namespace XIT.EF.Dal.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComFx")]
    public partial class ComFx
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComFx()
        {
            comGw = new HashSet<comGw>();
        }

        public int ComFxID { get; set; }

        [Required]
        [StringLength(20)]
        public string ComFxname { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comGw> comGw { get; set; }
    }
}
