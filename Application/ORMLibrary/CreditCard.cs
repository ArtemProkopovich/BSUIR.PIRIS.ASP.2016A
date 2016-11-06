namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CreditCard")]
    public partial class CreditCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreditId { get; set; }

        [Required]
        [StringLength(4)]
        public string PinCode { get; set; }

        public virtual Credit Credit { get; set; }
    }
}
