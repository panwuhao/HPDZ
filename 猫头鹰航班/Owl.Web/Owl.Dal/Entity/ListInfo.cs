namespace Owl.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ListInfo")]
    public partial class ListInfo
    {
        [Key]
        public int ListID { get; set; }

        //public int? FlightID { get; set; }

        public int? UserID { get; set; }

        public DateTime? ListTime { get; set; }

        public int? ListState { get; set; }

        //public virtual FlightInfo FlightInfo { get; set; }

        public virtual Users Users { get; set; }
    }
}
