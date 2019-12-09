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
        [DisplayName("ѧ��ѧ��")]
        public int StuID { get; set; }
        [Required]
        [StringLength(2)]
        [DisplayName("�Ա�")]
        
        public string StuSex { get; set; }
        [DisplayName("����")]
        public int StuAge { get; set; }

        [StringLength(100)]
        [DisplayName("ְλ")]
        public string StuPost { get; set; }

        [Required]
        [DisplayName("��ѧʱ��")]
        [StringLength(100)]
        public string StuAdmintime { get; set; }

        [Required]
        [DisplayName("��ҵʱ��")]
        [StringLength(100)]
        public string StuGradtime { get; set; }
        [DisplayName("��ɫ���")]
        public int? LogID { get; set; }
        [DisplayName("�༶ID")]
        public int? ClaID { get; set; }
        [DisplayName("�Ƿ�ɾ��")]
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
