namespace Owl.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FlightInfo")]
    public partial class FlightInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FlightInfo()
        {
            //ListInfo = new HashSet<ListInfo>();
        }

        [Key]
        public int FlightID { get; set; }

        [Required]
        [StringLength(50)]
        public string FlightLoad { get; set; }

        public DateTime FlightDate { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public string FlightTime { get; set; }

        [Required]
        [StringLength(20)]
        public string CabinType { get; set; }

        [Column(TypeName = "money")]
        public decimal TicketPrice { get; set; }

        public int? IsDelay { get; set; }

        [StringLength(50)]
        public string DelayCause { get; set; }

        public int SurTicket { get; set; }

        [Required]
        [StringLength(20)]
        public string PlaneType { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ListInfo> ListInfo { get; set; }
    }
}
