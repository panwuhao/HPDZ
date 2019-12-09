namespace XIT.EF.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoginInfo")]
    public partial class LoginInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoginInfo()
        {
            StuInfo = new HashSet<StuInfo>();
            TeacherInfo = new HashSet<TeacherInfo>();
        }

        [Key]
        public int LogID { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("ÐÕÃû")]
        public string LogNum { get; set; }

        [Required]
        [StringLength(20)]
        public string LogPwd { get; set; }

        public int? roleID { get; set; }

        public int? IsDelete { get; set; }

        public virtual role role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StuInfo> StuInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherInfo> TeacherInfo { get; set; }
    }
}
