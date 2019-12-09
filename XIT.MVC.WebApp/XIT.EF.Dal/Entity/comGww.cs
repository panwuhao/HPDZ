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

        [DisplayName("��λ����")]
        public int GwwName { get; set; }

        [DisplayName("����")]
        public int Peo { get; set; }

        [DisplayName("��ʼʱ��")]
        public DateTime Addtime { get; set; }

        [DisplayName("����ʱ��")]
        public DateTime Endtime { get; set; }

        [DisplayName("ƽ��н��")]
        public int Mone { get; set; }

        public virtual comGw comGw { get; set; }
    }
}
