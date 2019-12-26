namespace Owl.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            //ListInfo = new HashSet<ListInfo>();
        }

        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string Tel { get; set; }

        [Required]
        [StringLength(50)]
        public string IDCard { get; set; }

        public int  GradeID { get; set; }

        public virtual Grade Grade { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ListInfo> ListInfo { get; set; }
    }
}
