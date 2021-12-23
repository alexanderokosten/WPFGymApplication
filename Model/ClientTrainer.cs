namespace GymApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientTrainer")]
    public partial class ClientTrainer
    {
        [Key]
        public int ClientTrainer_Id { get; set; }

        public int Trainer_Id { get; set; }

        public int Client_Id { get; set; }

        public int NumberOfWorkouts { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Trainers Trainers { get; set; }
    }
}
