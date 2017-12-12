namespace DeveloperDashboard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeviceID { get; set; }

        public int? DeviceTypeID { get; set; }

        [Column("Device")]
        [StringLength(255)]
        public string Device1 { get; set; }

        public int? PixelWidth { get; set; }

        public int? PixelHeight { get; set; }

        public int? VendorID { get; set; }

        public virtual DeviceType DeviceType { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
