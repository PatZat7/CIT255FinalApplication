namespace DeveloperDashboard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DBengine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DBID { get; set; }

        public int? VendorID { get; set; }

        [StringLength(255)]
        public string ImgPath { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string ImgFilePath { get; set; }

        public decimal? StackOverflow { get; set; }

        public int? PlatformID { get; set; }

        public virtual Platform Platform { get; set; }
    }
}
