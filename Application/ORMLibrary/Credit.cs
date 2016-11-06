namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Credit")]
    public partial class Credit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Credit()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }

        public int ClientId { get; set; }

        public int PlanId { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public virtual Client Client { get; set; }

        public virtual PlanOfCredit PlanOfCredit { get; set; }

        public virtual CreditCard CreditCard { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
