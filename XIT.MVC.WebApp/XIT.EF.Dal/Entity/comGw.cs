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
        [DisplayName("岗位名称")]
        public string GwName { get; set; }

        [DisplayName("工作年限")]
        public int age { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("岗位描述")]
        public string jieshao { get; set; }

        [DisplayName("方向")]
        public int ComFxID { get; set; }

        [DisplayName("来源")]
        public int ComLyID { get; set; }

        public virtual ComFx ComFx { get; set; }

        public virtual ComLy ComLy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comGww> comGww { get; set; }
    }
}
