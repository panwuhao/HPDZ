namespace XIT.EF.Dal.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("comGww")]
    public partial class comGww
    {
        [Key]
        public int GwwID { get; set; }

        [DisplayName("岗位名称")]
        public int GwwName { get; set; }

        [DisplayName("人数")]
        public int Peo { get; set; }

        [DisplayName("开始时间")]
        public DateTime Addtime { get; set; }

        [DisplayName("结束时间")]
        public DateTime Endtime { get; set; }

        [DisplayName("平均薪资")]
        public int Mone { get; set; }

        public virtual comGw comGw { get; set; }
    }
}
