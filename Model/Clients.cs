namespace GymApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clients()
        {
            ClientTrainer = new HashSet<ClientTrainer>();
            SignUpForGroupLessons = new HashSet<SignUpForGroupLessons>();
        }

        [Key]
        public int Client_Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Surname { get; set; }

        [Required]
        [StringLength(250)]
        public string Patronymic { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public int Sex { get; set; }

        public int NumberOfContract { get; set; }

        public int Subscription { get; set; }

        [Column(TypeName = "date")]
        public DateTime SubscriptionStartTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime SubscriptionEndTime { get; set; }

        public virtual SexTable SexTable { get; set; }

        public virtual Subscription Subscription1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientTrainer> ClientTrainer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SignUpForGroupLessons> SignUpForGroupLessons { get; set; }
    }
}
