namespace XIT.EF.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("StuInfo")]
    public partial class StuInfo
    {
        public StuInfo()
        {
            Appraisal = new HashSet<Appraisal>();
            Payment = new HashSet<Payment>();
            StuLeave = new HashSet<StuLeave>();
            StuScore = new HashSet<StuScore>();
        }
        [Key]
        [DisplayName("学生学号")]
        public int StuID { get; set; }
        [Required]
        [StringLength(2)]
        [DisplayName("性别")]
        
        public string StuSex { get; set; }
        [DisplayName("年龄")]
        public int StuAge { get; set; }

        [StringLength(100)]
        [DisplayName("职位")]
        public string StuPost { get; set; }

        [Required]
        [DisplayName("入学时间")]
        [StringLength(100)]
        public string StuAdmintime { get; set; }

        [Required]
        [DisplayName("毕业时间")]
        [StringLength(100)]
        public string StuGradtime { get; set; }
        [DisplayName("角色编号")]
        public int? LogID { get; set; }
        [DisplayName("班级ID")]
        public int? ClaID { get; set; }
        [DisplayName("是否删除")]
        public int? IsDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appraisal> Appraisal { get; set; }

        public virtual ClassInfo ClassInfo { get; set; }
        public virtual LoginInfo LoginInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StuLeave> StuLeave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StuScore> StuScore { get; set; }
    }
}
