namespace DeveloperDashboard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FLAtype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FLAtype()
        {
            FLAs = new HashSet<FLA>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FLAtypeID { get; set; }

        [Column("FLAtype")]
        [StringLength(255)]
        public string FLAtype1 { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLA> FLAs { get; set; }
    }
}
