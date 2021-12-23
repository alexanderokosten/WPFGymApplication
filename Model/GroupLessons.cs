namespace GymApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GroupLessons
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GroupLessons()
        {
            SignUpForGroupLessons = new HashSet<SignUpForGroupLessons>();
        }

        [Key]
        public int GroupLessons_Id { get; set; }

        [Required]
        [StringLength(250)]
        public string LessonName { get; set; }

        public int Trainer_Id { get; set; }

        public virtual Trainers Trainers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SignUpForGroupLessons> SignUpForGroupLessons { get; set; }
    }
}
