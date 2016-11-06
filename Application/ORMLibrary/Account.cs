namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Transactions = new HashSet<Transaction>();
            Transactions1 = new HashSet<Transaction>();
            Credits = new HashSet<Credit>();
            Deposits = new HashSet<Deposit>();
        }

        public int Id { get; set; }

        public int PlanId { get; set; }

        [Required]
        [StringLength(13)]
        public string AccountNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal DebitValue { get; set; }

        [Column(TypeName = "money")]
        public decimal CreditValue { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        public virtual PlanOfAccount PlanOfAccount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Credit> Credits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deposit> Deposits { get; set; }
    }
}
