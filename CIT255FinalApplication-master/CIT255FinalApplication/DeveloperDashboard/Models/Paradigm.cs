namespace DeveloperDashboard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Paradigm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ParadigmID { get; set; }

        [Column("Paradigm")]
        [StringLength(255)]
        public string Paradigm1 { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string CoreConcepts { get; set; }
    }
}
