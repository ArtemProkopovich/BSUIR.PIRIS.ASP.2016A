namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlanOfCredit")]
    public partial class PlanOfCredit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanOfCredit()
        {
            Credits = new HashSet<Credit>();
            PlanOfAccounts = new HashSet<PlanOfAccount>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime Period { get; set; }

        public double Percent { get; set; }

        public bool Anuity { get; set; }

        [Column(TypeName = "money")]
        public decimal? MinAmount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Credit> Credits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanOfAccount> PlanOfAccounts { get; set; }
    }
}
