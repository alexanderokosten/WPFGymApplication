namespace GymApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subscription")]
    public partial class Subscription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscription()
        {
            Clients = new HashSet<Clients>();
        }

        [Key]
        public int Subscription_Id { get; set; }

        [Required]
        [StringLength(250)]
        public string SubscriptionName { get; set; }

        public int NumberOfMonths { get; set; }
        [NotMapped]
        public int Summa
        {
            get
            {
                int sum = 0;
                if (Subscription_Id == 1)
                {
                    sum = 4500;
                    return sum;
                }
                else if (Subscription_Id == 2)
                {
                    sum = 3000;
                    return sum;
                }
                else
                {
                    return 0;
                }

            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clients> Clients { get; set; }
    }
}
