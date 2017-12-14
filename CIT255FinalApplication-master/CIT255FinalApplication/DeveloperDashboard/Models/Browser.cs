namespace DeveloperDashboard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Browser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BrowserID { get; set; }

        [Column("Browser")]
        [StringLength(255)]
        public string Browser1 { get; set; }

        [StringLength(255)]
        public string ImgFilePath { get; set; }

        public decimal? UserShare { get; set; }
    }
}
