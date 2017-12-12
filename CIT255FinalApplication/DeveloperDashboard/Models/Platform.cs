namespace DeveloperDashboard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Platform
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Platform()
        {
            DBengines = new HashSet<DBengine>();
            FLAs = new HashSet<FLA>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlatformID { get; set; }

        public int? VendorID { get; set; }

        [Column("Platform")]
        [StringLength(255)]
        public string Platform1 { get; set; }

        [StringLength(255)]
        public string ImgFilePath { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DBengine> DBengines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLA> FLAs { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
