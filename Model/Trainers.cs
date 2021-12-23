namespace GymApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trainers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainers()
        {
            ClientTrainer = new HashSet<ClientTrainer>();
            GroupLessons = new HashSet<GroupLessons>();
        }

        [Key]
        public int Trainer_Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Surname { get; set; }

        [Required]
        [StringLength(250)]
        public string Patronymic { get; set; }

        public int Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public double CoachingExperience { get; set; }

        [Required]
        [StringLength(2000)]
        public string ParticularQualities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientTrainer> ClientTrainer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupLessons> GroupLessons { get; set; }

        public virtual SexTable SexTable { get; set; }
    }
}
