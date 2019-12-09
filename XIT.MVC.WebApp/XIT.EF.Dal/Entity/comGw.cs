namespace XIT.EF.Dal.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("comGw")]
    public partial class comGw
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public comGw()
        {
            comGww = new HashSet<comGww>();
        }

        [Key]
        public int GwID { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("��λ����")]
        public string GwName { get; set; }

        [DisplayName("��������")]
        public int age { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("��λ����")]
        public string jieshao { get; set; }

        [DisplayName("����")]
        public int ComFxID { get; set; }

        [DisplayName("��Դ")]
        public int ComLyID { get; set; }

        public virtual ComFx ComFx { get; set; }

        public virtual ComLy ComLy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comGww> comGww { get; set; }
    }
}
